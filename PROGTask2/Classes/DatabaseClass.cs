using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services.Description;
using System.Windows.Forms;
using static PROGTask2.Classes.DatabaseClass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PROGTask2.Classes
{
    public class DatabaseClass
    {
        private PasswordEncryption PE = new PasswordEncryption();
        private string MyConnectString;

        //----------------------------------------------------------------Constructor----------------------------------------------------------------------------------//
        public DatabaseClass()
        {

            MyConnectString = ConfigurationManager.ConnectionStrings["PROGTask2.Properties.Settings.MyDatabase"].ConnectionString; //Database Connection
        }


        //---------------------------------------Method Created to Insert Farmer Data into the FArmerTable-------------------------------------------------------------//
        #region Inserts a new Farmer into FarmerTable
        public void InsertFarmerIntoDatabase(string farmerUsername, string farmerName, string farmerSurname, string farmerPassword)
        {
            // query to insert  new Farmer data into a the farmerTable
            string sql = "INSERT INTO FarmerTable (FarmerUsername, FarmerName, FarmerSurname, FarmerPassword) VALUES (@Username, @Name, @Surname, @Password)";

            using (SqlConnection connection = new SqlConnection(MyConnectString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", farmerUsername);
                    command.Parameters.AddWithValue("@Name", farmerName);
                    command.Parameters.AddWithValue("@Surname", farmerSurname);
                    command.Parameters.AddWithValue("@Password", PE.HashedPassword(farmerPassword));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion


        
        //---------------------------------------------------------------Verifies the User-----------------------------------------------------------------------------//
        #region verifys if the user is entering the correct password
        public bool VerifyLogin(string username, string password)
        {
            string storedHashedPassword = GetHashedPassword(username);

            if (string.IsNullOrEmpty(storedHashedPassword))
            {
                return false; // User not found
            }

            string hashedPassword = HashPassword(password);

            return string.Equals(storedHashedPassword, hashedPassword);
        }
        #endregion

        //--------------------------------------Method created to retrieve the farmer password based on FarmerUsername-------------------------------------------------//
        private string GetHashedPassword(string username)
        {
            //Sql query 
            string query = "SELECT FarmerPassword FROM FarmerTable WHERE FarmerUsername = @Username";

            using (SqlConnection connection = new SqlConnection(MyConnectString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    return result != null ? result.ToString() : null;
                }
            }
        }
        //-----------------------------------------Hashing The Password------------------------------------------------------------------------------------------------//
        #region HashPassword
        private string HashPassword(string password)
        {
            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedBytes = sha1.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashedBytes);
            }
        }
        #endregion

        //--------------------------------------------------------Method Created To retrieve the Employee Password From Database---------------------------------------//
        public string GetEmployeeDetails(string username)
        {
            
            string password = null;
            //sql query to fetch the employee password from the database based on if the usernames are the same
            string sql = "SELECT EmployeePassword FROM EmployeeTable WHERE EmployeeUsername = @Username";

            using (SqlConnection connection = new SqlConnection(MyConnectString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        password = result.ToString();
                    }
                }
            }

            return password;
        }

        //----------------------------------------------------------Method Created to insert the Farmers Products------------------------------------------------------//
        public void InsertProduct(string productBarcode, string farmerUsername,string productName, string productPrice, string productType)
        {
            

            using (SqlConnection connection = new SqlConnection(MyConnectString))
            {
                connection.Open();

                // Insert the product into the FarmerProductsTable
                string farmerProductsQuery = "INSERT INTO FarmerProductsTable (ProductBarcode, FarmerUsername, ProductName, ProductPrice) " +
                    "VALUES (@Barcode, @FUsername, @Name, @Price)";

                using (SqlCommand farmerProductsCommand = new SqlCommand(farmerProductsQuery, connection))
                {
                    farmerProductsCommand.Parameters.AddWithValue("@Barcode", productBarcode);
                    farmerProductsCommand.Parameters.AddWithValue("@FUsername", farmerUsername);
                    farmerProductsCommand.Parameters.AddWithValue("@Name", productName);
                    farmerProductsCommand.Parameters.AddWithValue("@Price", productPrice);

                    farmerProductsCommand.ExecuteNonQuery();
                }

                // Insert the Product into the corresponding product type table chosen by Farmer 
                if (productType == "Vegetables")
                {
                    //Inserts Vegetable related data into the VegetableTable
                    string vegetableQuery = "INSERT INTO VegetableTable (VegetableName, ProductBarcode) VALUES (@VegetableName, @Barcode)";

                    using (SqlCommand vegetableCommand = new SqlCommand(vegetableQuery, connection))
                    {
                        vegetableCommand.Parameters.AddWithValue("@VegetableName", productName);
                        vegetableCommand.Parameters.AddWithValue("@Barcode", productBarcode);

                        vegetableCommand.ExecuteNonQuery();
                    }
                }
                else if (productType == "Grains")
                {
                    //Inserts Grain related data into the GrainTable
                    string grainQuery = "INSERT INTO GrainsTable (GrainName, ProductBarcode) VALUES (@GrainName, @Barcode)";

                    using (SqlCommand grainCommand = new SqlCommand(grainQuery, connection))
                    {
                        grainCommand.Parameters.AddWithValue("@GrainName", productName);
                        grainCommand.Parameters.AddWithValue("@Barcode", productBarcode);

                        grainCommand.ExecuteNonQuery();
                    }
                }
                else if (productType == "Dairy")
                {
                    //Inserts Dairy related data into the DairyTable
                    string dairyQuery = "INSERT INTO DairyTable (DairyName, ProductBarcode) VALUES (@DairyName, @Barcode)";

                    using (SqlCommand dairyCommand = new SqlCommand(dairyQuery, connection))
                    {
                        dairyCommand.Parameters.AddWithValue("@DairyName", productName);
                        dairyCommand.Parameters.AddWithValue("@Barcode", productBarcode);

                        dairyCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        //---------------------------------------------------------Method Created to Fetch associated products for specific farmer-------------------------------------//
        public DataTable GetProduct(string getselectedFarmer)
        {
            DataTable productsTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(MyConnectString))
            {
                connection.Open();
                // SQL query to fetch the ProductBarcode, ProductName and ProductPrice From FarmerProductTable based on the Username in database equallying the farmer username from the dropdown lsit
                string query = "SELECT ProductBarcode, ProductName, ProductPrice FROM FarmerProductsTable WHERE FarmerUsername = @SelectedFarmerUsername";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SelectedFarmerUsername", getselectedFarmer);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        //Fills the Table wwith Data
                        adapter.Fill(productsTable);
                    }
                }
            }
            return productsTable;
        }

        //---------------------------------------------------------Method Created to Filter the list of Farmer Products By Product Type--------------------------------//
        public DataTable GetFilteredProducts(string farmerUsername, string productType)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(MyConnectString))
            {
                connection.Open();

                //I used chatcpt to help with this sql query 

                string query = @"SELECT F.ProductBarcode, F.ProductName, F.ProductPrice
                        FROM FarmerProductsTable F
                        LEFT JOIN VegetableTable V ON F.ProductBarcode = V.ProductBarcode
                        LEFT JOIN DairyTable D ON F.ProductBarcode = D.ProductBarcode
                        LEFT JOIN GrainsTable G ON F.ProductBarcode = G.ProductBarcode
                        WHERE F.FarmerUsername = @SelectedFarmerUsername AND
                              (V.VegetableName IS NOT NULL AND @ProductType = 'Vegetables' OR
                               D.DairyName IS NOT NULL AND @ProductType = 'Dairy' OR
                               G.GrainName IS NOT NULL AND @ProductType = 'Grains')";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SelectedFarmerUsername", farmerUsername);
                    command.Parameters.AddWithValue("@ProductType", productType);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        //repopulates table with the filter query
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

    }
}


//------------------------------------------------------------------End of File----------------------------------------------------------------------------------------//