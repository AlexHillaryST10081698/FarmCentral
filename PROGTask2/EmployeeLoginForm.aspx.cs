using PROGTask2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PROGTask2
{
    public partial class Farmer : System.Web.UI.Page
    {
        //-------------------------------------------------------------Variables----------------------------------------------------------------------------------------//
        private String EmployeeUsername;
        private String EmployeePassword;
        private Boolean IsDataEntered;
        private DatabaseClass db = new DatabaseClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            //------------------------------------------captures the employee inputs into variables---------------------------------------------------------------------//
            EmployeeUsername = txtUsername.Text; 
            EmployeePassword = txtPassword.Text;

            //----------------------------------sends the EmployeeUsername to the DatabaseClass to check if that Username and password exists in Database---------------//
            string DatabasePassword = db.GetEmployeeDetails(EmployeeUsername);

            //-------------------executes only if password in the database and password entered by employee attempting to login is correct------------------------------//
            if (DatabasePassword != null && DatabasePassword.Equals(EmployeePassword))
            {
                MessageBox.Show("Login Suceeded"); //displays to the user
                Response.Redirect("~/EmployeeDashboard.aspx"); // takes user to the Employee Dashboard
                txtUsername.Text = string.Empty; //clears the textbox
                txtPassword.Text = string.Empty; //clears the textbox
            }
            //----------------------------------executes if password do not match--------------------------------------------------------------------------------------//
            else
            {
                MessageBox.Show("Invalid Username or Paassword");          
                txtUsername.Text = string.Empty; //clears the textbox
                txtPassword.Text = string.Empty; //clears the textbox
            }
           
        }
    }
}
//------------------------------------------------------------------End of File-----------------------------------------------------------------------------------------//