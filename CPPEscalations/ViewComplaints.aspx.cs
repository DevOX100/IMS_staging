using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class CPPEscalations_ViewComplaints : System.Web.UI.Page
{
    public DataSet ds = new DataSet();
    Inventory_System ISS = new Inventory_System();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["LoginType"].ToString() == "B")
            {
                ddlBranch.Visible = false;
                ddlRegion.Visible = false;
                lblBranch.Visible = false;
                Region.Visible = false;
            }
         
            BindStatus();
            BindRegion();
            BindGrid();
        }
    }
    protected void BindGrid()
    {
        string status = ddlStatus.SelectedValue;
        string region = ddlRegion.SelectedValue;
        string branch = ddlBranch.SelectedValue;
        if (string.IsNullOrEmpty(region) ){
            region = "0";
        }
        if (string.IsNullOrEmpty(branch))
        {
            branch = "0";
        }
        if (string.IsNullOrEmpty(status))
        { 
        status = "0";
        }
        if(Session["LoginType"].ToString() == "B")
        {
            branch = Session["UserCOde"].ToString();
        }
        ds =ISS.ViewEscalation(region, branch,status);
        GVViewEscalationns.DataSource = ds;
        GVViewEscalationns.DataBind();

    }
    protected void BindRegion()
    {
        ds = ISS.RegionDetail();
        ddlRegion.DataSource = ds;
        ddlRegion.DataTextField = "Cluster_ID";
        ddlRegion.DataValueField = "Cluster_ID";
        ddlRegion.DataBind();
        ddlRegion.Items.Insert(0, new ListItem("Select", "0"));
    }
    protected void BindBranch()
    {
        string clusterID = ddlRegion.SelectedValue;
        ds = ISS.BranchDetailsByRegion(clusterID);

        ddlBranch.DataSource = ds;
        ddlBranch.DataTextField = "Branch_Name";
        ddlBranch.DataValueField = "Branch_ID";
        ddlBranch.DataBind();
        ddlBranch.Items.Insert(0, new ListItem("Select", "0"));

    }
    protected void BindStatus()
    {
        ds = ISS.SelectStatus();
        ddlStatus.DataSource = ds;
        ddlStatus.DataTextField = "EM_Status";
        ddlStatus.DataValueField = "EM_Status";
        ddlStatus.DataBind();
        ddlStatus.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();

    }

    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBranch();
        BindGrid();
    }

    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();

    }


    protected void GVViewEscalationns_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            string issueID = e.CommandArgument.ToString();

            // Fetch data from the database
            DataSet ds = ISS.ViewEscalationDetails(issueID);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow issueDetails = ds.Tables[0].Rows[0];

                // Assign fetched values to modal labels, replacing null-propagating operator with explicit null check
                lblProductType.Text = (issueDetails["EM_Damage_Product_Type"] != DBNull.Value) ? issueDetails["EM_Damage_Product_Type"].ToString() : "N/A";
                lblAvailableStock.Text = (issueDetails["EM_AvailableStockInBranch"] != DBNull.Value) ? issueDetails["EM_AvailableStockInBranch"].ToString() : "N/A";
                lblRemarks.Text = (issueDetails["EM_Remarks"] != DBNull.Value) ? issueDetails["EM_Remarks"].ToString() : "N/A";
                lblComplaint.Text = (issueDetails["EM_Damage_ProductComplaint_date"] != DBNull.Value) ? issueDetails["EM_Damage_ProductComplaint_date"].ToString() : "N/A";
                lblEscalation.Text = (issueDetails["EM_EscalationDate"] != DBNull.Value) ? issueDetails["EM_EscalationDate"].ToString() : "N/A";
                lblVendorConfirmDate.Text = (issueDetails["EM_VendorConfirmDate"] != DBNull.Value) ? issueDetails["EM_VendorConfirmDate"].ToString() : "N/A";
                lblEM_VendorRejectDate.Text = (issueDetails["EM_VendorRejectDate"] != DBNull.Value) ? issueDetails["EM_VendorRejectDate"].ToString() : "N/A";
                lblEM_VendorStatusDate.Text = (issueDetails["EM_VendorStatusDate"] != DBNull.Value) ? issueDetails["EM_VendorStatusDate"].ToString() : "N/A";

                // Trigger the modal using ScriptManager
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#divModel_InvoiceDetails').modal('show');", true);
            }
            else
            {
                // Handle no data scenario
                ScriptManager.RegisterStartupScript(this, this.GetType(), "NoData", "alert('No details found for the selected issue.');", true);
            }
        }
    }



    //protected void btnClose_Click(object sender, EventArgs e)
    //{
    //    divModel_InvoiceDetails.Visible = false;
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "open_Invoice", "setTimeout(function () {OpenNewPopUp('0','divModel_InvoiceDetails')}, 300);", true);

    //}
}