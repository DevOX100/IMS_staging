using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Inventory_viewPO : System.Web.UI.Page
{

    DataSet ds = new DataSet();
    Inventory_System ISS = new Inventory_System();
    Encryption ec = new Encryption();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
            //BindGridBranchWise();
            BindOrderStatus();
            //BindOrder();
          
            BindBranch();
            //BindVendor();
            BindPONumber();
            string[] LoginType = { "U", "D", "C" };

            string HOLogins = Session["RCode"].ToString();
            if (LoginType.Contains(Session["loginType"].ToString()) && HOLogins!="R000" && !HOLogins.StartsWith("BH",StringComparison.OrdinalIgnoreCase))
            {
                ddlPONUMBER.Visible = false;
            }

            string loginType = Session["loginType"] != null ? Session["loginType"].ToString() : string.Empty;


            string script = "<script type=\"text/javascript\">";

            if (loginType == "B")
            {
                script += "document.getElementById('" + ddlBranch.ClientID + "').style.display = 'none';";
                script += "document.getElementById('" + ddlVendor.ClientID + "').style.display = 'none';";

                ddlBranch.Visible = false;
                ddlVendor.Visible = false;

            }

            if (loginType == "V")
            {
                ddlBranch.Visible = false;
               
                h5PONumber.Visible = false;
                    ddlVendor.Visible = false;
                    ddlStatus.Visible = false;
                script += "document.getElementById('" + ddlPONUMBER.ClientID + "').style.display = 'none';";
                script += "document.getElementById('" + h5PONumber.ClientID + "').style.display = 'none';";
                script += "document.getElementById('" + ddlVendor.ClientID + "').style.display = 'none';";
                script += "document.getElementById('" + ddlBranch.ClientID + "').style.display = 'none';";
                script += "document.getElementById('" + ddlStatus.ClientID + "').style.display = 'none';";

            }

            script += "</script>";


            ClientScript.RegisterStartupScript(this.GetType(), "HideDropdowns", script);
        }
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
                    //DateTime RequestedDate = Convert.ToDateTime((ds.Tables[0].Rows[0]["BIS_insertDate"].ToString()));
                    //DateTime RMApproveDate = Convert.ToDateTime((ds.Tables[0].Rows[0]["BIS_approve_date"].ToString()));
                    //DateTime CPPApproveDate = Convert.ToDateTime((ds.Tables[0].Rows[0]["BIS_CPP_Approved_Date"].ToString()));
                    int HOQuantity = Convert.ToInt32(ds.Tables[0].Rows[0]["BIS_HO_approved_quantity"]);
                    string HORemarks = (ds.Tables[0].Rows[0]["BIS_HO_Approved_Remarks"].ToString());
                    string HODate = (ds.Tables[0].Rows[0]["BIS_POGeneratedOn"].ToString());
                   
                    string requestedDateString = ds.Tables[0].Rows[0]["BIS_insertDate"].ToString();
                    string rmApproveDateString = ds.Tables[0].Rows[0]["BIS_approve_date"].ToString();
                    string cppApproveDateString = ds.Tables[0].Rows[0]["BIS_CPP_Approved_Date"].ToString();

                    lblRequestedQuantity.Text = ReqQuantity.ToString();
                    lblRequestorRemarks.Text = InitiatorRemarks.ToString();
                    lblStockAcceptance.Text = ApprovedQuantity.ToString();
                    lblAcceptorRemarks.Text = ApprovedRemarks.ToString();
                    lblCppQuantity.Text = CPPQuantity.ToString();
                    lblcppRemarks.Text = CPPRemarks.ToString();
                    lblRequestedDate.Text = requestedDateString.ToString();
                    lblRMApproveDate.Text = rmApproveDateString.ToString();
                    lblCPPApproveDate.Text = cppApproveDateString.ToString();
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
            string PONumber = (e.CommandArgument.ToString());
            if (ID != "")
            {
                Response.Redirect(string.Format("POForm.aspx?PONumber={0}", HttpUtility.UrlEncode(ec.Encrypt(PONumber))));
            }
        }

        try
        {
            if (e.CommandName == "VIEWPOD")
            {
                string index = (e.CommandArgument.ToString());
                if (index != "")
                {

                    if (index != "")
                    {
                        string FileName = Server.MapPath("~/Upload/PODImageVendor/" + index + ".pdf");
                        var webClient = new WebClient();
                        byte[] pdfBytes = webClient.DownloadData(FileName);

                        string embed = "<object data=\"data:application/pdf;base64, {0}\" type=\"application/pdf\" width=\"100%\" height=\"500px\">";
                        embed += "<embed src=\"data:application/pdf;base64, {0}\" type=\"application/pdf\" />";
                        embed += "</object>";

                        lvPDF.Text = string.Format(embed, Convert.ToBase64String(pdfBytes));
                        Div_View_PDF.Visible = true;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "open_Invoice", "setTimeout(function () {OpenNewPopUp('1','Div_View_PDF')}, 300);", true);
                    }
                }


            }
        }
        catch (Exception ex)
        {
            ex.ToString();
            return;
        }





    }


    protected void BindGrid()
    {
        string BranchCode = Session["UserCode"].ToString();
        if (Session["loginType"].ToString() == "V")
        {
            ds = ISS.Vendorpo(Session["UserCode"].ToString());
        }

        else
        {

            string PONumber = ddlPONUMBER.SelectedValue;
            if (PONumber == "" || PONumber == "0")
            {
                PONumber = "null";
            }
            ds = ISS.poDetails(PONumber, BranchCode);
        }
        gvApproval.DataSource = ds;
        gvApproval.DataBind();
    }

    protected void BindPONumber()
    {
        //string VendorID = ddlVendor.SelectedValue;
        if (Session["loginType"].ToString() == "V")
        {
            ds = ISS.usp_DistinctPONumberForVendor(Session["UserCode"].ToString());
        }
        else
        {
            if(Session["loginType"].ToString() == "U")
            {
                if (ddlBranch.SelectedValue == "" || ddlBranch.SelectedValue == "0")
                {
                    string branchID = "0";
                    ds = ISS.DistinctviewPONumber(branchID);
                }
                else
                {
                    string branchID = ddlBranch.SelectedValue;
                    ds = ISS.DistinctviewPONumber(branchID);
                  
                }
              
            }
            else
            {
                string branchID = Session["UserCode"].ToString();
                ds = ISS.DistinctviewPONumber(branchID);
            }
            
        }

        ddlPONUMBER.DataSource = ds;
        ddlPONUMBER.DataTextField = "BIS_PONumber";
        ddlPONUMBER.DataValueField = "BIS_PONumber";
        ddlPONUMBER.DataBind();
        ddlPONUMBER.Items.Insert(0, new ListItem("All PO", "0"));

        //else
        //{
        //    ds = ISS.DistinctPONumber();
        //}
        //ddlPONUMBER.DataSource = ds;
        //ddlPONUMBER.DataTextField = "BIS_PONumber";
        //ddlPONUMBER.DataValueField = "BIS_PONumber";
        //ddlPONUMBER.DataBind();
        //ddlPONUMBER.Items.Insert(0, new ListItem("All PO", "0"));
    }
    protected void BindVendor()
    {
        string branchID = ddlBranch.SelectedValue;
        ds = ISS.INV_DistinctVendor(branchID);
        ddlVendor.DataSource = ds;
        ddlVendor.DataTextField = "VM_Name";
        ddlVendor.DataValueField = "BIS_vendorID";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, new ListItem("Select Vendor", "0"));

    }
    protected void BindVendorWise()
    {
        string branchID = ddlBranch.SelectedValue;
        string vendorID = ddlVendor.SelectedValue;
        gvApproval.DataSource = ISS.GetVendorWisePoDetails(branchID, vendorID);
        gvApproval.DataBind();

    }
    protected void BindOrderStatus()
    {
        if ( ddlBranch.SelectedValue != "")
        {
            string branch = ddlBranch.SelectedValue;
            ds = ISS.SelectOrderStatus(branch);
            ddlStatus.DataSource = ds;
            ddlStatus.DataTextField = "BIS_status";
            ddlStatus.DataValueField = "BIS_status";
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem("Select status", "0"));
        }
        else if (Session["loginType"].ToString()=="B") {
            string branch = Session["UserCode"].ToString();
            ds = ISS.SelectOrderStatus(branch);
            ddlStatus.DataSource = ds;
            ddlStatus.DataTextField = "BIS_status";
            ddlStatus.DataValueField = "BIS_status";
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem("Select status", "0"));
        }
        else
        {
            string branch ="0";
            ds = ISS.SelectOrderStatus(branch);
            ddlStatus.DataSource = ds;
            ddlStatus.DataTextField = "BIS_status";
            ddlStatus.DataValueField = "BIS_status";
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem("Select status", "0"));
        }
      
    }
    protected void BindBranch()
    {
        string[] loginType = { "D", "C" };
        if (loginType.Contains(Session["loginType"].ToString()))
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
            string BranchCode;
            string HOLogins = Session["RCode"].ToString();
            if (HOLogins == "R000")
            {
                BranchCode = Session["UserCode"].ToString();
            }
            else
            {
                BranchCode = Session["RegionID"].ToString();
            }

            ds = ISS.BranchDetails(BranchCode);
            ddlBranch.DataSource = ds;
            ddlBranch.DataTextField = "Branch_Name";
            ddlBranch.DataValueField = "Branch_ID";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("Select Branch", "0"));
        }
    }
   
    protected void BindOrder()
    {
        string HOLogins;
        string branchCode;
        if (Session["loginType"].ToString() == "B")
        {
            ddlBranch.Visible = false;
            ddlVendor.Visible = false;
             branchCode = Session["UserCode"].ToString();
             HOLogins = Session["UserCode"].ToString();
        }
        else
        {
            ddlBranch.Visible = true;
            ddlVendor.Visible = true;
            branchCode=ddlBranch.SelectedValue;
            HOLogins = Session["UserCode"].ToString();
        }
         
        string status = ddlStatus.SelectedValue;
        ds = ISS.BindOrderStatus(status, branchCode, HOLogins);
        gvApproval.DataSource = ds;
        gvApproval.DataBind();
    }
    protected void BindPOWise()
    {
        if (Session["loginType"].ToString() == "B")
        {
            ddlBranch.Visible = false;
            ddlVendor.Visible = false;
            string PONumber = ddlPONUMBER.SelectedValue;
            string BranchCode = Session["UserCode"].ToString();

            ds = ISS.poDetails(PONumber, BranchCode);

            gvApproval.DataSource = ds;
            gvApproval.DataBind();

        }
        else
        {
            ddlBranch.Visible = true;
            ddlVendor.Visible = true;


            string PONumber = ddlPONUMBER.SelectedValue;
            string BranchCode = Session["UserCode"].ToString();

            ds = ISS.poDetails(PONumber, BranchCode);

            gvApproval.DataSource = ds;
            gvApproval.DataBind();

        }
    }


    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPONumber();
        if (ddlVendor.SelectedValue != "Null")
        {
            BindVendorWise();
        }
    }

    protected void btnClosed_Click(object sender, EventArgs e)
    {
        Div_View_PDF.Visible = false;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "open_Invoice", "setTimeout(function () {OpenNewPopUp('0','Div_View_PDF')}, 300);", true);
    }

    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindVendor();

        if (ddlBranch.SelectedValue != "0")
        {
            BindOrderStatus();
            BindVendorWise();
            BindPONumber();
        }

        else
        {
            BindGrid();
       
        }
        BindOrderStatus();
    }

    protected void ddlPONUMBER_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPONUMBER.SelectedValue != "Null")
        {
            BindPOWise();
        }
        else
        {
            BindOrder();
        }
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindOrder();
       

    }
}