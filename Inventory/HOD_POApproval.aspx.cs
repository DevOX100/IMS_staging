﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.VariantTypes;


public partial class Inventory_HOD_POApproval : System.Web.UI.Page
{

    DataSet ds = new DataSet();
    Inventory_System ISS = new Inventory_System();
    Encryption ec = new Encryption();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindRegion();
            BindRegionWise();
            BindPONumber();
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
    protected void BindRegionWise()
    {
        string regionID = ddlRegion.SelectedValue;

        ds = ISS.RegionWiseGridForHOD(regionID);
        gvApproval.DataSource = ds;
        gvApproval.DataBind();

    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        divModel_InvoiceDetails.Visible = false;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "open_Invoice", "setTimeout(function () {OpenNewPopUp('0','divModel_InvoiceDetails')}, 300);", true);
    }
    protected void gvApproval_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            //string userCode = Session["UserCode"].ToString();
            string ID = (e.CommandArgument.ToString());
            if (ID != "")
            {
                ds = ISS.GetBIStockData_ForRM(ID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int ReqQuantity = Convert.ToInt32(ds.Tables[0].Rows[0]["BIS_Quantity"].ToString());
                    string InitiatorRemarks = (ds.Tables[0].Rows[0]["BIS_initiator_remarks"].ToString());
                    int ApprovedQuantity = Convert.ToInt32(ds.Tables[0].Rows[0]["BIS_approved_quantity"].ToString());

                    string ApprovedRemarks = (ds.Tables[0].Rows[0]["BIS_approved_remarks"]).ToString();
                    int CPPQuantity = Convert.ToInt32(ds.Tables[0].Rows[0]["BIS_CPP_approved_quantity"]);
                    string CPPRemarks = (ds.Tables[0].Rows[0]["BIS_CPP_Approved_Remarks"].ToString());
                    DateTime RequestedDate = Convert.ToDateTime((ds.Tables[0].Rows[0]["BIS_insertDate"].ToString()));
                    DateTime RMApproveDate = Convert.ToDateTime((ds.Tables[0].Rows[0]["BIS_approve_date"].ToString()));
                    DateTime CPPApproveDate = Convert.ToDateTime((ds.Tables[0].Rows[0]["BIS_CPP_Approved_Date"].ToString()));
                    int HOQuantity = Convert.ToInt32(ds.Tables[0].Rows[0]["BIS_HO_approved_quantity"]);
                    string HORemarks = (ds.Tables[0].Rows[0]["BIS_HO_Approved_Remarks"].ToString());
                    string HODate = (ds.Tables[0].Rows[0]["BIS_POGeneratedOn"].ToString());

                    lblRequestedQuantity.Text = ReqQuantity.ToString();
                    lblRequestorRemarks.Text = InitiatorRemarks.ToString();
                    lblStockAcceptance.Text = ApprovedQuantity.ToString();
                    lblAcceptorRemarks.Text = ApprovedRemarks.ToString();
                    lblCppQuantity.Text = CPPQuantity.ToString();
                    lblcppRemarks.Text = CPPRemarks.ToString();
                    lblRequestedDate.Text = RequestedDate.ToString();
                    lblRMApproveDate.Text = RMApproveDate.ToString();
                    lblCPPApproveDate.Text = CPPApproveDate.ToString();
                    lblHOAprQty.Text = HOQuantity.ToString();
                    lblHORemarks.Text = HORemarks.ToString();
                    lblHODate.Text = HODate.ToString();
                    divModel_InvoiceDetails.Visible = true;


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "open_Invoice", "setTimeout(function () {OpenNewPopUp('1','divModel_InvoiceDetails')}, 300);", true);
                    return;
                }
            }
        }

        if (e.CommandName == "Download")
        {
            string PONumber = e.CommandArgument.ToString();
            if (PONumber != "")
            {
                Response.Redirect(string.Format("POForm.aspx?PONumber={0}", HttpUtility.UrlEncode(ec.Encrypt(PONumber))));
            }
        }

        if (e.CommandName == "Submit")
        {
            HashSet<string> selectedPONumbers = new HashSet<string>();

            // Collect selected PO numbers
            for (int i = 0; i < gvApproval.Rows.Count; i++)
            {
                if (((CheckBox)gvApproval.Rows[i].FindControl("chkAction")).Checked)
                {
                    string poNumber = ((HiddenField)gvApproval.Rows[i].FindControl("hfPONumber")).Value;
                    selectedPONumbers.Add(poNumber);
                }
            }

            // Check if all similar PO numbers are selected
            foreach (var po in selectedPONumbers)
            {
                for (int i = 0; i < gvApproval.Rows.Count; i++)
                {
                    string poNumber = ((HiddenField)gvApproval.Rows[i].FindControl("hfPONumber")).Value;
                    if (poNumber == po && !((CheckBox)gvApproval.Rows[i].FindControl("chkAction")).Checked)
                    {
                        string script = string.Format("swal('Incomplete Selection!', 'All checkboxes for PO number {0} must be checked!', 'error');", po);
                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);
                        return;
                    }
                }
            }

            // If all required checkboxes are checked, process the submission
            for (int i = 0; i < gvApproval.Rows.Count; i++)
            {
                if (((CheckBox)gvApproval.Rows[i].FindControl("chkAction")).Checked)
                {
                    CheckBox Approve = ((CheckBox)gvApproval.Rows[i].FindControl("chkAction"));
                    int ID = Convert.ToInt32(gvApproval.DataKeys[i]["BIS_id"].ToString());
                    TextBox HODRemarksS = ((TextBox)gvApproval.Rows[i].FindControl("txtRemarks"));
                    Label VendorID = ((Label)gvApproval.Rows[i].FindControl("lblVendorID"));

                    string HODApprovalID = Session["UserCode"].ToString();
                    string HODRemarks = HODRemarksS.Text;
                    string BisVendorID = VendorID.Text;

                    ISS.usp_HODApprovalForStock(HODRemarks, ID, HODApprovalID, BisVendorID);
                }
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Submitted', 'success');", true);
            BindGrid();
            BindPONumber();
        }
    }

    //protected void gvApproval_RowCommand(object sender, GridViewCommandEventArgs e)
    //{

    //    if (e.CommandName == "Download")
    //    {
    //        string PONumber = (e.CommandArgument.ToString());
    //        if (ID != "")
    //        {
    //            Response.Redirect(string.Format("POForm.aspx?PONumber={0}", HttpUtility.UrlEncode(ec.Encrypt(PONumber))));
    //        }
    //    }

    //    if (e.CommandName == "Submit")
    //    {

    //        int chkCount = 0;
    //        for (int i = 0; i < gvApproval.Rows.Count; i++)
    //        {
    //            if (((CheckBox)gvApproval.Rows[i].FindControl("chkAction")).Checked)
    //            {
    //                chkCount++;
    //            }
    //        }

    //        if (chkCount == 0)
    //        {
    //            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('No One Checked!', 'Please choose at least one!', 'error');", true);
    //            return;
    //        }
    //        else
    //        {
    //            for (int i = 0; i < gvApproval.Rows.Count; i++)
    //            {

    //                if (((CheckBox)gvApproval.Rows[i].FindControl("chkAction")).Checked)
    //                {
    //                    CheckBox Approve = ((CheckBox)gvApproval.Rows[i].FindControl("chkAction"));
    //                    int ID = Convert.ToInt32(gvApproval.DataKeys[i]["BIS_id"].ToString());
    //                    TextBox HODRemarksS = ((TextBox)gvApproval.Rows[i].FindControl("txtRemarks"));

    //                    string HODApprovalID = Session["UserCode"].ToString();
    //                    string HODRemarks = HODRemarksS.Text;

    //                    ISS.usp_HODApprovalForStock(HODRemarks, ID, HODApprovalID);
    //                }

    //            }
    //        }
    //        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Submitted', 'success');", true);
    //        BindGrid();


    //    }
    //}

    protected void BindGrid()
    {
        foreach (GridViewRow row in gvApproval.Rows)
        {

            string BranchID = ddlBranch.SelectedValue;
            Label vendor = (Label)row.FindControl("lblVendorID");
            if (BranchID == null || BranchID == "")
            {
                BranchID = "0";
            }
            else
            {
                BranchID = ddlBranch.SelectedValue;
            }
            if (ddlVendorID.SelectedValue == "0" || ddlVendorID.SelectedValue == "Null" || ddlVendorID.SelectedValue == null || ddlVendorID.SelectedValue == "")
            {
                int VendorID = Convert.ToInt32(vendor.Text);
                DataSet ds = ISS.INV_POApprovalDetails(BranchID, VendorID);

                gvApproval.DataSource = ds;
                gvApproval.DataBind();

                if (gvApproval.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('No data found for the selected criteria.');", true);
                }
            }
            else
            {
                int VendorID = Convert.ToInt32(ddlVendorID.SelectedValue);
                DataSet ds = ISS.INV_POApprovalDetails(BranchID, VendorID);

                gvApproval.DataSource = ds;
                gvApproval.DataBind();

                if (gvApproval.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('No data found for the selected criteria.');", true);
                }
            }

            //string PONumber = ddlPONUMBER.SelectedValue;


            //if (PONumber == "" || PONumber == "0")
            //{
            //    PONumber = "null";
            //}

            //if (!DateTime.TryParse(txtFromDate.Text, out fromDate))
            //{
            //    fromDate = DateTime.MinValue;
            //}

            //if (!DateTime.TryParse(txtToDate.Text, out toDate))
            //{
            //    toDate = DateTime.MaxValue;
            //}

            //DataSet ds = ISS.POApprovalDetails(PONumber,fromDate, toDate);
        }
    }
    protected void BindPONumber()
    {
        //DateTime fromDate;
        //DateTime toDate;

        //if (!DateTime.TryParse(txtFromDate.Text, out fromDate))
        //{
        //    fromDate = DateTime.MinValue;
        //}

        //if (!DateTime.TryParse(txtToDate.Text, out toDate))
        //{
        //    toDate = DateTime.MaxValue;
        //}

        //DataSet ds = ISS.DistinctPONumber(fromDate, toDate);
        DataSet ds = ISS.DistinctPONumber();
        ddlPONUMBER.DataSource = ds;
        ddlPONUMBER.DataTextField = "BIS_PONumber";
        ddlPONUMBER.DataValueField = "BIS_PONumber";
        ddlPONUMBER.DataBind();

        ddlPONUMBER.Items.Insert(0, new ListItem("All PO", "0"));
    }
    protected void BindPOWise(string PoNumber)
    {
        DataSet ds = ISS.POApprovalDetailsWise(PoNumber);
        gvApproval.DataSource = ds;
        gvApproval.DataBind();
    }
    //protected void BindDate()
    //{
    //    DateTime FromDate;

    //    DateTime TODate;
    //    if (!DateTime.TryParse(txtFromDate.Text, out FromDate))
    //    {

    //        FromDate = DateTime.MinValue;
    //    }

    //    if (!DateTime.TryParse(txtToDate.Text, out TODate))
    //    {

    //        TODate = DateTime.MaxValue;
    //    }


    //    DataSet ds = ISS.DateWisePOApprovalDetails(FromDate, TODate);
    //    gvApproval.DataSource = ds;
    //    gvApproval.DataBind();

    //}

    protected void ddlPONUMBER_SelectedIndexChanged(object sender, EventArgs e)
    {
        string PoNumber = ddlPONUMBER.SelectedValue;

        if (PoNumber != "0")
        {
            BindPOWise(PoNumber);
        }
        else
        {
            BindGrid();
        }
    }

    protected void gvApproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        TextBox txtRemarks = (TextBox)e.Row.FindControl("txtRemarks");
        if (txtRemarks != null)
        {
            txtRemarks.Text = "Approved";
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //BindDate();
        BindPONumber();

        BindGrid();
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
    protected void BindBranchWise()
    {
        string branchID = ddlBranch.SelectedValue;
        ds = ISS.BranchWiseGridForHOD(branchID);
        gvApproval.DataSource = ds;
        gvApproval.DataBind();

    }
    protected void BindVendor()
    {
        string BranchID = ddlBranch.SelectedValue;
        ds = ISS.GetVendorListForHOD(BranchID);
        ddlVendorID.DataSource = ds;
        ddlVendorID.DataTextField = "VM_Name";
        ddlVendorID.DataValueField = "VM_ID";
        ddlVendorID.DataBind();
        ddlVendorID.Items.Insert(0, new ListItem("Select", "0"));
    }
    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBranch();
        BindRegionWise();
    }

    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindVendor();
        BindBranchWise();
    }
}