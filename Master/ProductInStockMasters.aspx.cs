﻿using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_ProductInStockMasters : System.Web.UI.Page
{
    Inventory_System ISS = new Inventory_System();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRegion();
            BindGrid();
            lblSelectedBranch.Visible = false;
            lblSelectedBranches.Visible = false;


        }
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

        lstBranch.DataSource = ds;
        lstBranch.DataTextField = "Branch_Name";
        lstBranch.DataValueField = "Branch_ID";
        lstBranch.DataBind();

    }

    protected void BindProduct()
    {
        string branchID = Session["UserCode"].ToString();
        ds = ISS.GetProductList(branchID);
        ddlProductType.DataSource = ds;
        ddlProductType.DataTextField = "Products";
        ddlProductType.DataValueField = "PM_ItemCode1";
        ddlProductType.DataBind();
        ddlProductType.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBranch();
        BindProduct();
    }
    protected void BindGrid()
    {
        string branchID = ddlRegion.SelectedValue;
        string productID = ddlProductType.SelectedValue;
        ds = ISS.BindProducts(branchID, productID);
        GVProductInStock.DataSource = ds;
        GVProductInStock.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string productType = ddlProductType.SelectedValue;
        string userCode = Session["UserCode"].ToString();
        int quantity = Convert.ToInt32(txtQuantity.Text);
        string Remarks = txtRemarks.Text;
        if (string.IsNullOrEmpty(Remarks))
        {
            Remarks = "Null";
        }
        
        var selectedBranches = lstBranch.Items.Cast<ListItem>()
                               .Where(item => item.Selected)
                               .Select(item => item.Value)
                               .ToList();

       
        foreach (var branchID in selectedBranches)
        {
            ds = ISS.insertProductStock(branchID, productType, userCode, quantity, Remarks);
        }

        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Product is added in the product list!', 'success');", true);

        BindGrid();
        clearData();
    }

    protected void clearData()
    {
        ddlProductType.SelectedIndex = 0;
       
        txtQuantity.Text = string.Empty;
    
        ddlRegion.SelectedIndex = 0;
        lstBranch.ClearSelection();
        lblSelectedBranches.Text = string.Empty;

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clearData();
    }

    protected void lstBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblSelectedBranch.Visible = true;
        lblSelectedBranches.Visible = true;
        var selectedItems = lstBranch.Items.Cast<ListItem>()
            .Where(item => item.Selected)
            .Select(item => item.Text);

        lblSelectedBranches.Text = string.Join(", ", selectedItems);
    }
}