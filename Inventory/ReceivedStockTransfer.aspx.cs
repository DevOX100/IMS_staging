using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inventory_ReceivedStockTransfer : System.Web.UI.Page
{

    Inventory_System ISS = new Inventory_System();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BindBranch();
            BindGrid();
        }
    }

    protected void BindBranch()
    {
        string clusterID = Session["RegionId"].ToString();
        string BranchCode = Session["UserCode"].ToString();
        ds = ISS.usp_BranchDetailsByRegionForTransfer(clusterID, BranchCode);
        ddlBranch.DataSource = ds;
        ddlBranch.DataTextField = "Branch_Name";
        ddlBranch.DataValueField = "Branch_ID";
        ddlBranch.DataBind();
        ddlBranch.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void BindGrid()
    {
        string RecBranchCode = Session["UserCode"].ToString();
        string SentBranchCode;
        if (ddlBranch.SelectedValue == "0")
        {
            SentBranchCode = "NULL";
        }
        else
        {
            SentBranchCode = ddlBranch.SelectedValue;
        }
        
        ds = ISS.usp_RecStockTransferDetails(RecBranchCode, SentBranchCode);
        gvStockTransfer.DataSource = ds;
        gvStockTransfer.DataBind();
    }

    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void gvStockTransfer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Submit")
        {

            int chkCount = 0;
            for (int i = 0; i < gvStockTransfer.Rows.Count; i++)
            {
                if (((CheckBox)gvStockTransfer.Rows[i].FindControl("chkAction")).Checked)
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
                for (int i = 0; i < gvStockTransfer.Rows.Count; i++)
                {

                    if (((CheckBox)gvStockTransfer.Rows[i].FindControl("chkAction")).Checked)
                    {
                        int STID = Convert.ToInt32(gvStockTransfer.DataKeys[i]["ST_ID"].ToString());
                        TextBox Quantity = ((TextBox)gvStockTransfer.Rows[i].FindControl("txtRecQuantity"));
                        TextBox remarks = ((TextBox)gvStockTransfer.Rows[i].FindControl("txtRemarks"));
                        Label productid = ((Label)gvStockTransfer.Rows[i].FindControl("lblProductID"));
                        Label lblSTFromBranch = ((Label)gvStockTransfer.Rows[i].FindControl("lblSTFromBranch"));
                        Label lblSendQty = ((Label)gvStockTransfer.Rows[i].FindControl("lblSendQty"));

                        string ReceivedBy = Session["UserCode"].ToString();
                        string BIS_insertBY = Session["UserCode"].ToString();
                        int ReceivedQuantity = Convert.ToInt32(Quantity.Text);
                        string ReceivedRemarks = remarks.Text;
                        string product_id = productid.Text;
                        string SentBy = lblSTFromBranch.Text;
                        int SentQty = Convert.ToInt32(lblSendQty.Text);
                        int ReverseQuantity = SentQty - ReceivedQuantity;

                        if (ReceivedQuantity > SentQty)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Warning', 'Received Quantity must be Less than or equal to sent Quantity.', 'info');", true);
                            return;
                        }

                        ds = ISS.usp_ModifyRecTransfer(ReceivedBy, ReceivedRemarks, ReceivedQuantity, ReverseQuantity, STID, product_id, SentBy);
                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Stock has been Received successfully', 'success');", true);
                    }
                }

                BindGrid();
            }
        }
    }

    protected void chkAction_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAction = sender as CheckBox;
        GridViewRow currentRow = chkAction.NamingContainer as GridViewRow;
        RequiredFieldValidator rfvREmarks = gvStockTransfer.Rows[currentRow.RowIndex].FindControl("rfvRemarks") as RequiredFieldValidator;
        RequiredFieldValidator rfvQuantity = gvStockTransfer.Rows[currentRow.RowIndex].FindControl("rfvQuantity") as RequiredFieldValidator;

        if (chkAction.Checked)
        {
            rfvREmarks.Enabled = true;
            rfvQuantity.Enabled = true;
        }
        else
        {
            rfvREmarks.Enabled = false;
            rfvQuantity.Enabled = false;
        }
    }
}