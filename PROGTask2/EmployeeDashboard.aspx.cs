using PROGTask2.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;


namespace PROGTask2
{
    public partial class Employee : System.Web.UI.Page
    {
        //--------------------------------------------------------------Variables----------------------------------------------------------------------------------------//
        string GetSelectedFarmer;
        string SelectedProductType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                List1SelectFarmers.DataValueField = "FarmerUsername"; 
                                                              
                List1SelectFarmers.DataTextField = "FarmerUsername";

                // Bind the data to the dropdown list
                List1SelectFarmers.DataBind();
            }
        }
        //-------------------------------------------------Method created to give the employee the option to log out----------------------------------------------------//
        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
        }
        protected void ddlProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void List1SelectFarmers_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedFarmer = List1SelectFarmers.SelectedValue;
            
        }
        protected void ddl2Farmers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //------------------------------------------------------Method created to display all the associated ptoducts for a specific farmer------------------------------//
        protected void btnViewProducts_Click(object sender, EventArgs e)
        {
            GetSelectedFarmer = List1SelectFarmers.SelectedValue;
            DatabaseClass DBClass = new DatabaseClass();
            //DBClass.GetProduct(GetSelectedFarmer);
            if (!string.IsNullOrEmpty(GetSelectedFarmer))
            {
                DataTable productsTable = DBClass.GetProduct(GetSelectedFarmer);

                if (productsTable.Rows.Count > 0)
                {
                    dataListProducts.DataSource = productsTable;
                    dataListProducts.DataBind();
                }
                else
                {
                    dataListProducts.DataSource = null;
                    dataListProducts.DataBind();
                    //lblMessage.Text = "No products found for the selected farmer.";
                }
            }
        }
        //---------------------------------------------------------Method created to execute when employee wishes to filter--------------------------------------------//
        protected void btnFilterProducts_Click(object sender, EventArgs e)
        {
            GetSelectedFarmer = List1SelectFarmers.SelectedValue;//captures which Farmer username the employee has selected
            SelectedProductType = ddlProductType.SelectedValue;//captures which Product type the employee has selected
            if (!string.IsNullOrEmpty(GetSelectedFarmer) && !string.IsNullOrEmpty(SelectedProductType))
            {
                //------------------------------------------------Calls The Database class------------------------------------------------------------------------------//
                DatabaseClass DBClass = new DatabaseClass();
                //------------------------------------------------sends the variables to the database class for quering-------------------------------------------------//
                DataTable productsTable = DBClass.GetFilteredProducts(GetSelectedFarmer, SelectedProductType);

                if (productsTable.Rows.Count > 0)
                {
                    dataListProducts.DataSource = productsTable;
                    dataListProducts.DataBind();
                }
                else
                {
                    MessageBox.Show("No Products found for the selected farmer and product type");
                    dataListProducts.DataSource = null;
                    dataListProducts.DataBind();
                }
            }
        }
    }
}
//---------------------------------------------------------------------End Of File--------------------------------------------------------------------------------------//