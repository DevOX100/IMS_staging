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
            BindGrid();
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

        string RecBranchCode = Session["UserCode"].ToString();
        ds = ISS.usp_StockTransferDetails(RecBranchCode);
        gvStockTransfer.DataSource = ds;
        gvStockTransfer.DataBind();
    }

    //protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    BindGrid();
    //}
}