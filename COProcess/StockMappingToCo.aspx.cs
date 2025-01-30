using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class COProcess_StockMappingToCo : System.Web.UI.Page
{
    Inventory_System ISS=new Inventory_System();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
            BindProduct();
            BindCenter();
            lblCOs.Visible = false;
            lblCO.Visible = false;
        }
    }

    protected void BindGrid()
    {
        string BranchID = Session["UserCode"].ToString();
        ds=ISS.ProductMappingwithCOs(BranchID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GvStockAllocation.DataSource = ds;
            GvStockAllocation.DataBind();
        }
        else
        {
            GvStockAllocation.EmptyDataText="No Data Found against this Branch";
            GvStockAllocation.DataBind();
        }

    }
    protected void BindProduct()
    {
        string branchID = Session["UserCode"].ToString();
        ds = ISS.GetProductList(branchID);
        ddlProductType.DataSource = ds;
        ddlProductType.DataTextField = "PM_Description1";
        ddlProductType.DataValueField = "PM_ItemCode1";
        ddlProductType.DataBind();
        ddlProductType.Items.Insert(0, new ListItem("Select", "0"));
    }
    protected void BindCenter()
    {
        string BranchCode=Session["BranchID"].ToString();
        ds = ISS.INV_CenterOfficer(BranchCode);
        lstCenterOfficer.DataSource = ds;
        lstCenterOfficer.DataTextField = "UserName";
        lstCenterOfficer.DataValueField = "usercode";
        lstCenterOfficer.DataBind();
        lstCenterOfficer.Items.Insert(0, new ListItem("Select", "0"));
    }




    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string productType = ddlProductType.SelectedValue;
        string userCode = Session["UserCode"].ToString();
        int quantity = Convert.ToInt32(txtQuantity.Text);
    
        var selectedCenterO = lstCenterOfficer.Items.Cast<ListItem>()
                               .Where(item => item.Selected)
                               .Select(item => item.Value)
                               .ToList();

       
        string connectionString = ConfigurationManager.ConnectionStrings["Mydatabaseconnection"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            foreach (string branchID in selectedCenterO)
            {
                
                string query = "SELECT bcode FROM userlogin WHERE userCode = @branchID";
                string bcode = null;
              
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@branchID", branchID);

             
                    bcode = command.ExecuteScalar().ToString();
                }

                if (!string.IsNullOrEmpty(bcode))
                {
                   
                   
                    try
                    {

                        ds = ISS.INV_insertINProductMappingWIthCO(branchID, productType, bcode, quantity, userCode);
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Invalid!', '" + ex.Message.Replace("'", "\\'") + "', 'error');", true);
                    }
                }
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Product is added in the product list!', 'success');", true);
        }

      
        BindGrid();
       
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        
    }

    protected void lstCenterOfficer_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblCOs.Visible = true;
        lblCO.Visible = true;
        var selectedItem= lstCenterOfficer.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Text).ToList();
        lblCO.Text = string.Join(", ", selectedItem);
    }
}