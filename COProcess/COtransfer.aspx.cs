using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Speech.Synthesis;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class COProcess_COtransfer : System.Web.UI.Page
{
    Inventory_System ISS = new Inventory_System();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
    protected void BindGrid()
    {
        string UserCode = txtUCode.Text;
        if (string.IsNullOrEmpty(UserCode))
        {
            UserCode="0";
        }
        gvUsers.DataSource = ISS.INV_TransferCO(UserCode);
        gvUsers.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        cleardata();
       
    }

    private void cleardata()
    {
        txtUCode.Text = "";
    }

   protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
{
    if (e.CommandName == "ChangeStatus")
    {
        // Get the control that triggered the event
        LinkButton lnkButton = (LinkButton)e.CommandSource;
            string UserAccountID = e.CommandArgument.ToString();
        // Use NamingContainer to get the GridViewRow
        GridViewRow row = (GridViewRow)lnkButton.NamingContainer;


        DropDownList ddlRegion = (DropDownList)row.FindControl("ddlRegion");
        DropDownList ddlBranch = (DropDownList)row.FindControl("ddlBranch");

        // Retrieve selected values from the dropdowns
        string regionID = ddlRegion != null ? ddlRegion.SelectedValue : string.Empty;
        string branchID = ddlBranch != null ? ddlBranch.SelectedValue : string.Empty;

        // Retrieve the UserCode from the session
        string userCode = Session["UserCode"] != null ? Session["UserCode"].ToString() : string.Empty;

        // Execute your business logic (uncomment the line below when ready)
         ISS.INV_ModifyCODetails(UserAccountID, regionID, branchID, userCode);
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Completed!', 'Region and Branch Changed Successfully!', 'success');", true);  
            // Rebind the GridView to reflect changes
            BindGrid();
    }
}

    protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
                   
        DropDownList regions = (DropDownList)e.Row.FindControl("ddlRegion");
        DropDownList ddlBranch = (DropDownList)e.Row.FindControl("ddlBranch");
            
            ds = ISS.RegionDetail();
        regions.DataSource = ds;
        regions.DataTextField = "Cluster_ID";
        regions.DataValueField = "Cluster_ID";
        regions.DataBind();
        regions.Items.Insert(0, new ListItem("Select", "0"));
         }
    }

    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlRegion = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlRegion.NamingContainer;
        DropDownList ddlBranch = (DropDownList)row.FindControl("ddlBranch");
        string clusterID = ddlRegion.SelectedValue;
        ds = ISS.BranchDetailsByRegion(clusterID);
        ddlBranch.DataSource = ds;
        ddlBranch.DataTextField = "Branch_Name";
        ddlBranch.DataValueField = "BranchforCO";
        ddlBranch.DataBind();
        ddlBranch.Items.Insert(0, new ListItem("Select", "0"));
    }
}