using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inventory_HeadOffice_ApprovalStock : System.Web.UI.Page
{

    public DataSet ds = new DataSet();
    Inventory_System ISS = new Inventory_System();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindBranch();
            BindGridBranchWise();
        
          
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BindGridBranchWise();

    }
 


    protected void BindBranch()
    {
        string clusterID = Session["RegionID"].ToString();
        ds = ISS.BranchDetailsByRegion(clusterID);
        ddlBranch.DataSource = ds;
        ddlBranch.DataTextField = "Branch_Name";
        ddlBranch.DataValueField = "Branch_ID";
        ddlBranch.DataBind();
        ddlBranch.Items.Insert(0, new ListItem("Select", "0"));
    }
    //protected void BindRegion()
    //{
    //    ds = ISS.RegionDetail();
    //    ddlRegion.DataSource = ds;
    //    ddlRegion.DataTextField = "Cluster_ID";
    //    ddlRegion.DataValueField ="Cluster_ID";
    //    ddlRegion.DataBind();
    //    ddlRegion.Items.Insert(0, new ListItem("Select", "0"));
    //}

   protected void BindGridBranchWise()
 {
     string RegionID = Session["RegionID"].ToString();
     string BranchID = ddlBranch.SelectedValue;
     gvHOApproval.DataSource = ISS.usp_GetBranchStockData_ForHO(BranchID, RegionID);
     gvHOApproval.DataBind();
 }
    //protected void BindGridRegionWise()
    //{
    //    string RegionID = ddlRegion.SelectedValue;
    //    gvHOApproval.DataSource = ISS.usp_GetRegionStockData_ForHO(RegionID);
    //    gvHOApproval.DataBind();
    //}
    protected void gvHOApproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        TextBox txtRemarks = (TextBox)e.Row.FindControl("txtRemarksHOAP");
        if (txtRemarks != null)
        {
            txtRemarks.Text = "Approved";
        }

    }
    protected void gvHOApproval_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Submit")
        {

            int chkCount = 0;
            for (int i = 0; i < gvHOApproval.Rows.Count; i++)
            {
                if (((CheckBox)gvHOApproval.Rows[i].FindControl("chkAction")).Checked)
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
                for (int i = 0; i < gvHOApproval.Rows.Count; i++)
                {

                    if (((CheckBox)gvHOApproval.Rows[i].FindControl("chkAction")).Checked)
                    {
                        CheckBox Approve = ((CheckBox)gvHOApproval.Rows[i].FindControl("chkAction"));
                        int ID = Convert.ToInt32(gvHOApproval.DataKeys[i]["BIS_id"].ToString());
                        Label ReqQty = ((Label)gvHOApproval.Rows[i].FindControl("lblReqQty"));
                        TextBox Quantity = ((TextBox)gvHOApproval.Rows[i].FindControl("txtQuantityHOAP"));
                        TextBox Approval_remarks = ((TextBox)gvHOApproval.Rows[i].FindControl("txtRemarksHOAP"));
                        string ApprovedBY = Session["UserCode"].ToString();
                        decimal approvedquantity = Convert.ToDecimal(Quantity.Text);
                        string ApprovalRemarks = Approval_remarks.Text;
                        int RequestQty = Convert.ToInt32(ReqQty.Text);

                        //if (RequestQty < approvedquantity)
                        //{
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Info!', 'Do not Enter Approved Quantity more than Request Quantity.', 'info');", true);
                        //    return;
                        //}

                        ISS.HOApprovalForStock(ApprovedBY, approvedquantity, ApprovalRemarks, ID);
                    }

                }

                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Submitted', 'success');", true);
                BindGridBranchWise();
            }
           


        }

else
{
    int chkCount = 0;
    for (int i = 0; i < gvHOApproval.Rows.Count; i++)
    {
        if (((CheckBox)gvHOApproval.Rows[i].FindControl("chkAction")).Checked)
        {
            chkCount++;
        }
    }

    if (chkCount == 0)
    {
        // Replace ScriptManager.RegisterStartupScript with this line for page refresh:
        Response.Redirect(Request.Url.AbsoluteUri);


        return;
    }
    else
    {
        for (int i = 0; i < gvHOApproval.Rows.Count; i++)
        {
            if (((CheckBox)gvHOApproval.Rows[i].FindControl("chkAction")).Checked)
            {
                int ID = Convert.ToInt32(gvHOApproval.DataKeys[i]["BIS_id"]);
                TextBox Approval_remarks = (TextBox)gvHOApproval.Rows[i].FindControl("txtRemarksHOAP");
                string RejectedRemarks = Approval_remarks.Text;
                string RejectedBY = Session["UserCode"].ToString();
                ISS.INV_BIS_Delete(ID, RejectedRemarks, RejectedBY);
            }
        }

        // Show delete success message and refresh grid
        Response.Redirect(Request.Url.AbsoluteUri);
        BindGridBranchWise(); // Refresh your grid after deletion
    }
}
    }

    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGridBranchWise();
    }

    protected void chkAction_CheckedChanged(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.CheckBox chkAction = sender as System.Web.UI.WebControls.CheckBox;
        GridViewRow currentRow = chkAction.NamingContainer as GridViewRow;
        RequiredFieldValidator rfvREmarks = gvHOApproval.Rows[currentRow.RowIndex].FindControl("rfvRemarksHOAP") as RequiredFieldValidator;
        RequiredFieldValidator rfvQuantity = gvHOApproval.Rows[currentRow.RowIndex].FindControl("rfvQuantyHOAP") as RequiredFieldValidator;

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

    //protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    BindBranch();
    //    BindGridRegionWise();
    //}
}