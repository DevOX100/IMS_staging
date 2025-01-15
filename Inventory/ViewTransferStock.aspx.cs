using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inventory_ViewTransferStock : System.Web.UI.Page
{

    Inventory_System ISS = new Inventory_System();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            // BindBranch();
            string HOLogins = Session["RCode"].ToString();
            string Division = Session["Division"].ToString();
            string Cluster = Session["Cluster"].ToString();
            string[] loginType = { "U", "D", "C" };

            //string[] HOLogins = { "10000", "01479", "01823", "09917", "08000" };
            //string[] CppHUBWise = { "15020", "12307", "15704", "18269", "18891" };
            //string UserCode = Session["UserCode"].ToString();
            if (loginType.Contains(Session["loginType"].ToString()) && HOLogins != "R000" && !HOLogins.StartsWith("BH", StringComparison.OrdinalIgnoreCase))
            {
                BindBranch();
                Region.Visible = false;
            }

            else
            {
                Region.Visible = true;
            }

            if (Session["loginType"].ToString() == "B")
            {
                ddlBranch.Visible = false;
                ddlRegion.Visible = false;
                lblBranch.Visible = false;
                lblRegion.Visible = false;


            }
            else
            {
                ddlBranch.Visible = true;
                ddlRegion.Visible = true;
                lblBranch.Visible = true;
                lblRegion.Visible = true;
            }
            BindGrid();
            BindRegion();
        }
       
    }


    //protected void BindBranch()
    //{
    //    string clusterID = Session["RegionId"].ToString();
    //    string BranchCode = Session["UserCode"].ToString();
    //    ds = ISS.usp_BranchDetailsByRegionForTransfer(clusterID, BranchCode);
    //    ddlBranch.DataSource = ds;
    //    ddlBranch.DataTextField = "Branch_Name";
    //    ddlBranch.DataValueField = "Branch_ID";
    //    ddlBranch.DataBind();
    //    ddlBranch.Items.Insert(0, new ListItem("Select", "0"));
    //}
    protected void BindRegion()
    {

        string HOLogins = Session["RCode"].ToString();
        if (HOLogins.StartsWith("BH", StringComparison.OrdinalIgnoreCase))
        {


            string CppHub = Session["RegionID"].ToString();

            ds = ISS.HUBWiseRegion(CppHub);
            ddlRegion.DataSource = ds;
            ddlRegion.DataTextField = "Cluster_ID";
            ddlRegion.DataValueField = "Cluster_ID";
            ddlRegion.DataBind();
            ddlRegion.Items.Insert(0, new ListItem("Select", "0"));
        }
        else
        {


            ds = ISS.RegionDetail();
            ddlRegion.DataSource = ds;
            ddlRegion.DataTextField = "Cluster_ID";
            ddlRegion.DataValueField = "Cluster_ID";
            ddlRegion.DataBind();
            ddlRegion.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    protected void BindBranch()
    {
        string[] loginType = { "D", "C" };

        string HOLogins = Session["RCode"].ToString();
        if (Session["loginType"].ToString() == "U" && HOLogins != "R000" && !HOLogins.StartsWith("BH", StringComparison.OrdinalIgnoreCase))
        {

            string clusterID = Session["RegionID"].ToString();
            ds = ISS.BranchDetailsByRegion(clusterID);
            ddlBranch.DataSource = ds;
            ddlBranch.DataTextField = "Branch_Name";
            ddlBranch.DataValueField = "Branch_ID";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("Select", "0"));
        }
        else if (loginType.Contains(Session["loginType"].ToString()))
        {
            string clusterID = Session["RegionID"].ToString();
            string userCode = Session["UserCode"].ToString();
            if (loginType.Contains(Session["loginType"].ToString()))
            {
                ds = ISS.BranchDetailsByDivisionCluster(userCode, clusterID);
                ddlBranch.DataSource = ds;
                ddlBranch.DataTextField = "Branch_Name";
                ddlBranch.DataValueField = "Branch_ID";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        else
        {
            string clusterID = ddlRegion.SelectedValue;
            ds = ISS.BranchDetailsByRegion(clusterID);
            ddlBranch.DataSource = ds;
            ddlBranch.DataTextField = "Branch_Name";
            ddlBranch.DataValueField = "Branch_ID";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("Select", "0"));
        }

    }
    protected void BindGrid()
    {
        //string RecBranchCode;
        //if (ddlBranch.SelectedValue == "0")
        //{
        //    RecBranchCode = "NULL";
        //}
        //else
        //{
        //    RecBranchCode = ddlBranch.SelectedValue;
        //}

        string RegionCode = ddlRegion.SelectedValue;
        if (string.IsNullOrEmpty(RegionCode))
        {
            RegionCode = "0";
        }
        string BranchCode = ddlBranch.SelectedValue;
        if (string.IsNullOrEmpty(BranchCode))
        {
            BranchCode = "0";
        }

        string RecBranchCode = Session["UserCode"].ToString();
        ds = ISS.usp_StockTransferDetails(RecBranchCode, RegionCode, BranchCode);
        gvStockTransfer.DataSource = ds;
        gvStockTransfer.DataBind();
    }

    //protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    BindGrid();
    //}

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