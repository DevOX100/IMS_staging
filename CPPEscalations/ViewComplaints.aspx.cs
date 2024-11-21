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
        ddlStatus.DataTextField = "IS_Esclation_status";
        ddlStatus.DataValueField = "IS_Esclation_status";
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

}