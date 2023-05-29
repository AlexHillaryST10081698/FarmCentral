using PROGTask2.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PROGTask2
{
    public partial class FarmerLoginForm : System.Web.UI.Page
    {
        //-------------------------------------------------------------Variables----------------------------------------------------------------------------------------//
        private String FarmerUsername;
        private String FarmerPassword;
        private Boolean ValidLogin;
        private string MyConnectString;
        private DatabaseClass DBClass = new DatabaseClass();
        private AddFarmer AF = new AddFarmer();
        private PasswordEncryption PE = new PasswordEncryption();
        private Boolean IsDataEntered;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //--------------------------------Executes Method When the login Button is clicked-----------------------------------------------------------------------------//
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtUsername.Text) && !String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                //-------------------------------------------------captues the users inputs into variables-------------------------------------------------------------//
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string loginPassword = PE.HashedPassword(password);
                //Calls the databaseClass
                DatabaseClass db = new DatabaseClass();

                //------------Sends the variables to the corresponding method in database class to check if username and password exist in database and matches--------//
                bool LoginSucess = db.VerifyLogin(username, password);
                //---------------------------Displays a meesage if username and/or password does not match-------------------------------------------------------------//
                if (LoginSucess)
                {
                    
                    MessageBox.Show("Login Suceeded");
                    Session["FarmerUsername"] = username;
                    Response.Redirect("~/FarmerDashboard.aspx");
                    txtUsername.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                }
                //---------------------------Displays a meesage if username and/or password does not match-------------------------------------------------------------//
                else
                {
                    MessageBox.Show("You have entered an invalid username or password");
                    txtUsername.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                }
            }

        }
        
    }
    //---------------------------------------------------End of File--------------------------------------------------------------------------------------------------//
}