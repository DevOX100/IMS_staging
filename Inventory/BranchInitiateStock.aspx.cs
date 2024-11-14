using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inventory_BranchInitiateStock : System.Web.UI.Page
{

    public DataSet ds = new DataSet();
    Inventory_System ISS = new Inventory_System();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindProduct();
            BindGrid2();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BindGrid();
        BindGrid2();
    }

    protected void BindProduct()
    {
        ds = ISS.GetProductList(Session["UserCode"].ToString());
        ddlProduct.DataSource = ds;
        ddlProduct.DataTextField = "PM_Description1";
        ddlProduct.DataValueField = "PM_ItemCode1";
        ddlProduct.DataBind();
        ddlProduct.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void BindGrid()
    {
        string Branch_id = Session["UserCode"].ToString();
        string ProductID = ddlProduct.SelectedValue;
        gvStockInitiate.DataSource = ISS.GetProductListByProductID(ProductID,Branch_id);
        gvStockInitiate.DataBind();
    }

    protected void BindGrid2()
    {
        string Branch_id = Session["UserCode"].ToString();
        string ProductID = ddlProduct.SelectedValue;
        gv_BranchDelConf.DataSource = ISS.GetBranchInitiateStock(ProductID, Branch_id);
        gv_BranchDelConf.DataBind();
    }

    protected void gvStockInitiate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Submit")
        {

            int chkCount = 0;
            for (int i = 0; i < gvStockInitiate.Rows.Count; i++)
            {
                if (((CheckBox)gvStockInitiate.Rows[i].FindControl("chkAction")).Checked)
                {
                    chkCount++;
                }
            }

            if (chkCount == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('No One Checked!', 'Please choose at least one!', 'error');", true);
                return;
            }
            else
            {
                for (int i = 0; i < gvStockInitiate.Rows.Count; i++)
                {

                    if (((CheckBox)gvStockInitiate.Rows[i].FindControl("chkAction")).Checked)
                    {
                        CheckBox Approve = ((CheckBox)gvStockInitiate.Rows[i].FindControl("chkAction"));
                        int PM_ItemCode1 = Convert.ToInt32(gvStockInitiate.DataKeys[i]["PM_ItemCode1"].ToString());
                        Label productID = (Label)gvStockInitiate.Rows[i].FindControl("lblProductID");

                        TextBox Quantity = ((TextBox)gvStockInitiate.Rows[i].FindControl("txtQuantityBIS"));
                        TextBox Initiator_remarks = ((TextBox)gvStockInitiate.Rows[i].FindControl("txtRemarksBIS"));

                        string BIS_branchID = Session["UserCode"].ToString();
                        int BIS_productID = Convert.ToInt32(productID.Text);
                        string BIS_insertBY = Session["UserCode"].ToString();
                        decimal BIS_Quantity = Convert.ToDecimal(Quantity.Text);
                        string BIS_Initiator_remarks = Initiator_remarks.Text;

                        ISS.insertBranchInitiateStock(BIS_branchID, BIS_productID, BIS_insertBY, BIS_Quantity, BIS_Initiator_remarks);
                    }

                }

                BindGrid2();
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Submitted', 'success');", true);
            BindGrid();


        }
    }

    protected void gv_BranchDelConf_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument.ToString());

        if (e.CommandName == "StockDelete")
        {
            ISS.usp_deleteBranch_Initiate_Stock(id);
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Deleted', 'success');", true);
            BindGrid2();
        }

        if (e.CommandName == "StockConfirm")
        {
            ISS.confirmBranchInitiateStock(id);
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Confirmed', 'success');", true);
            BindGrid2();
        }
    }
}