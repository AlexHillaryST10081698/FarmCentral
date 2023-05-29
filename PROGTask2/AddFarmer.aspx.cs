using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text; //used to convert strings and byte arrays 
using System.EnterpriseServices;
using PROGTask2.Classes;
using System.Data.SqlClient;

namespace PROGTask2
{
    public partial class AddFarmer : System.Web.UI.Page
    {
        //----------------------------------------------------Classes Called------------------------------------------------------------------------//
        private PasswordEncryption PE = new PasswordEncryption();
        private DatabaseClass DBClass = new DatabaseClass();
        //-------------------------------------------Variables----------------------------------------------------------------------------------------//
        private String FarmerUsername;
        private String FarmerName;
        private String FarmerSurname;
        private String FarmerPassword;
        private String ConfimPassword;
        private Boolean IsDataEntered;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //---------------------------------------------------------Event created when user clicks Add Farmer Button-----------------------------------//
        protected void BtnAddFarmer_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtUsername.Text))
            {
                FarmerUsername = txtUsername.Text;
                txtUsername.Text = string.Empty;
                IsDataEntered = true;
            }
            if (!String.IsNullOrWhiteSpace(txtName.Text))
            {
                FarmerName = txtName.Text;
                txtName.Text = string.Empty;
                IsDataEntered = true;
            }
            if (!String.IsNullOrWhiteSpace(txtSurname.Text))
            {
                FarmerSurname = txtSurname.Text;
                txtSurname.Text = string.Empty;
                IsDataEntered = true;
            }
            if (!String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                FarmerPassword = txtPassword.Text;
                txtPassword.Text = string.Empty;
                IsDataEntered = true;
            }
            if (!String.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                ConfimPassword = txtConfirmPassword.Text;
                //-------------------------------------------checks  if the password and confirm password match-------------------------------------//
                if (ConfimPassword.Equals(FarmerPassword))
                {
                    txtConfirmPassword.Text = string.Empty;
                    IsDataEntered = true;

                    //--------------------------------------sends all the new farmer data to the Databaseclass--------------------------------------//
                    DBClass.InsertFarmerIntoDatabase(FarmerUsername,FarmerName,FarmerSurname,FarmerPassword);
                }
                else
                {
                    
                    MessageBox.Show("Your Password Do Not Match Please Make Sure They Are The Same");
                    IsDataEntered=false;
                    txtPassword.Text = string.Empty;
                    txtConfirmPassword.Text += string.Empty;
                }
                
            }
            //------------------------------------------------------if statement to display to user----------------------------------------------------//
            if(IsDataEntered)
            {
                //displays if a new farmer has been sucessfully added
                MessageBox.Show("A new Farmer has been added");
            }
            else
            {
                //displays if a new farmer has not been added
                MessageBox.Show("An Error has Occured");
            }
        }
        
        
    }
}
//---------------------------------------------------------------------------End of File--------------------------------------------------------------//