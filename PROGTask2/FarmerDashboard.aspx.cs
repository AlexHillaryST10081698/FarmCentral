using PROGTask2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PROGTask2
{
    public partial class Farmer1 : System.Web.UI.Page
    {
        //--------------------------------------------------------Variables--------------------------------------------------------------------------------------------//
        private String ProductName;
        private int ProductBarcode;
        private String ProductPrice;
        private Boolean isDataEntered;
        private String ProductType;

        private String employeeUsername = null; //Going to be null because a farmer is logged in
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }
        protected void ddlProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductType = ListProductType.SelectedItem.ToString();
        }
        //----------------------------------------------------button event created for when a farmer wants too add a Product--------------------------------------------//  
        protected void BtnAddProduct_Click(object sender, EventArgs e)
        {
            // Retrieve farmerUsername from session variable
            string farmerUsername = Session["FarmerUsername"] as string;

            if (!string.IsNullOrWhiteSpace(txtProductBarcode.Text))
            {
                //------------------------------------------Captures farmer input and stores it a a variable------------------------------------------------------------//
                ProductBarcode = Convert.ToInt32(txtProductBarcode.Text);
                txtProductBarcode.Text = string.Empty;
                isDataEntered = true;
                
            }
            if (!string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                //------------------------------------------Captures farmer input and stores it a a variable------------------------------------------------------------//
                ProductName = txtProductName.Text;
                txtProductName.Text = string.Empty;
                isDataEntered = true;
            }
            if (!string.IsNullOrWhiteSpace(txtProductPrice.Text))
            {
                //------------------------------------------Captures farmer input and stores it a a variable------------------------------------------------------------//
                ProductPrice = txtProductPrice.Text;
                txtProductPrice.Text = string.Empty;
                isDataEntered = true;
            }
            if (!string.IsNullOrWhiteSpace(txtProductPrice.Text))
            {
                //------------------------------------------Captures farmer input and stores it a a variable------------------------------------------------------------//
                ProductType = ListProductType.SelectedValue;
                //txtProductPrice.Text = string.Empty;
                isDataEntered = true;
            }
            //------------------------------------------------if statement to prompt user that a new farmer has been added if true--------------------------------------//
            if (isDataEntered)
            {
                MessageBox.Show("A New Product has Been Added");
                //--------------------------------------------Class the database Class---------------------------------------------------------------------------------//
                DatabaseClass DBClass = new DatabaseClass();
                //------------------------------Sends the farmers inputs to the database class-------------------------------------------------------------------------//
                DBClass.InsertProduct(ProductBarcode.ToString(),farmerUsername, ProductName, ProductPrice, ProductType);
            }
            
            
        }
        //--------------------------------------------------------Method created to allow farmer to logout------------------------------------------------------------//
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }


    }
}
//-----------------------------------------------------------End of File----------------------------------------------------------------------------------------------//