using DeveloperUtilz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Inventory_Vendor_PO_Generate : System.Web.UI.Page
{

    public DataSet ds = new DataSet();
    Inventory_System ISS = new Inventory_System();
    duValidate dv = new duValidate();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // BindGrid();
            
            BindRegion();
          //  BindVendor();
        }
    }


    protected void BindGrid()
    {
        string BranchID = ddlBranch.SelectedValue;
        int VendorID = Convert.ToInt32(ddlVendorID.SelectedValue);
        ds = ISS.usp_GetBranchStockForPOGenerate(BranchID, VendorID);
        gvPOGenerate.DataSource = ds;
        gvPOGenerate.DataBind();

        if(ds.Tables[0].Rows.Count > 0)
        {
            int POAmount = 0;
            for (int i = 0; i < gvPOGenerate.Rows.Count; i++)
            {
                Label TotalPO = ((Label)gvPOGenerate.Rows[i].FindControl("lblPOAmt"));
                POAmount += Convert.ToInt32(TotalPO.Text);
            }


            Label TotalPOSum = gvPOGenerate.FooterRow.FindControl("lblSumPOAmt") as Label;
            TotalPOSum.Text = "" + POAmount;
        }
       
    }
    protected void BindGridRegionWise()
    {
        string RegionID = ddlRegion.SelectedValue;
        gvPOGenerate.DataSource = ISS.INV_GetRegionStockData_ForRM(RegionID);
        gvPOGenerate.DataBind();
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

    protected void GetBranchWiseStockData()
    {
        string BranchID = ddlBranch.SelectedValue;
        gvPOGenerate.DataSource = ISS.INV_GetBranchWiseStockData_ForRM(BranchID);
        gvPOGenerate.DataBind();
    }
    protected void gvPOGenerate_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    int CPPQuantity = Convert.ToInt32(ds.Tables[0].Rows[0]["BIS_CPP_approved_quantity"].ToString());
                    string CPPRemarks = (ds.Tables[0].Rows[0]["BIS_CPP_Approved_Remarks"].ToString());
                    DateTime RequestedDate =Convert.ToDateTime( (ds.Tables[0].Rows[0]["BIS_insertDate"].ToString()));
                    DateTime RMApproveDate = Convert.ToDateTime((ds.Tables[0].Rows[0]["BIS_approve_date"].ToString()));
                    DateTime CPPApproveDate = Convert.ToDateTime((ds.Tables[0].Rows[0]["BIS_CPP_Approved_Date"].ToString()));

                    lblRequestedQuantity.Text = ReqQuantity.ToString();
                    lblRequestorRemarks.Text = InitiatorRemarks.ToString();
                    lblStockAcceptance.Text = ApprovedQuantity.ToString();
                    lblAcceptorRemarks.Text = ApprovedRemarks.ToString();
                    lblCppQuantity.Text = CPPQuantity.ToString();
                    lblcppRemarks.Text = CPPRemarks.ToString();
                    lblRequestedDate.Text = RequestedDate.ToString();
                    lblRMApproveDate.Text = RMApproveDate.ToString();
                    lblCPPApproveDate.Text= CPPApproveDate.ToString();
                    divModel_InvoiceDetails.Visible = true;
                   
                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "open_Invoice", "setTimeout(function () {OpenNewPopUp('1','divModel_InvoiceDetails')}, 300);", true);
                    return;
                }
            }
        }

        if (e.CommandName == "Submit")
        {

            decimal SumPOAmount = 0;
            int chkCount = 0;
           // string RandomNum = dv.RandomPassword3(6);
           // string poNumber = "PO" + ddlBranch.SelectedValue.ToString() + "/" + "2024-25" + "/" + RandomNum;
            for (int i = 0; i < gvPOGenerate.Rows.Count; i++)
            {
                if (((CheckBox)gvPOGenerate.Rows[i].FindControl("chkAction")).Checked)
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
                for (int i = 0; i < gvPOGenerate.Rows.Count; i++)
                {



                    if (((CheckBox)gvPOGenerate.Rows[i].FindControl("chkAction")).Checked)
                    {
                        CheckBox Approve = ((CheckBox)gvPOGenerate.Rows[i].FindControl("chkAction"));
                        int ID = Convert.ToInt32(gvPOGenerate.DataKeys[i]["BIS_id"].ToString());
                        TextBox Quantity = ((TextBox)gvPOGenerate.Rows[i].FindControl("txtQuantity"));
                        TextBox Remarks = ((TextBox)gvPOGenerate.Rows[i].FindControl("txtRemarks"));
                        Label VName = ((Label)gvPOGenerate.Rows[i].FindControl("lblVendorName"));
                        Label PUnit = ((Label)gvPOGenerate.Rows[i].FindControl("lblProductUnit"));
                        Label TotalPO = ((Label)gvPOGenerate.Rows[i].FindControl("lblPOAmt"));
                        Label branchID = ((Label)gvPOGenerate.Rows[i].FindControl("lblBranch"));
                       // SumPOAmount += Convert.ToInt32(TotalPO.Text);

                        int finalQuantity=Convert.ToInt32(Quantity.Text);
                        string finalRemarks = Remarks.Text;
                        decimal PO_amount = Convert.ToDecimal(TotalPO.Text);
                        string PO_vendorCode = VName.Text;
                        string PO_branchID = branchID.Text;
                        string UNIT = PUnit.Text;
                        //DateTime PO_Delivery_Date  = Convert.ToDateTime(txtpoDelDate.Text);
                        DateTime PO_Date = Convert.ToDateTime(DateTime.Now);
                        string POGeneratedBy = Session["UserCode"].ToString();
                        ISS.insertPurchaseOrderDetails(PO_amount,/*PO_Delivery_Date,*/ PO_vendorCode, PO_branchID, PO_Date, ID, UNIT, POGeneratedBy, finalQuantity, finalRemarks);
                    }

                }
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Submitted', 'success');", true);
            BindGridRegionWise();
        }

       
 else
 {
     int chkCount = 0;
     for (int i = 0; i < gvPOGenerate.Rows.Count; i++)
     {
         if (((CheckBox)gvPOGenerate.Rows[i].FindControl("chkAction")).Checked)
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
         for (int i = 0; i < gvPOGenerate.Rows.Count; i++)
         {
             if (((CheckBox)gvPOGenerate.Rows[i].FindControl("chkAction")).Checked)
             {
                 int ID = Convert.ToInt32(gvPOGenerate.DataKeys[i]["BIS_id"]);
                 TextBox Approval_remarks = (TextBox)gvPOGenerate.Rows[i].FindControl("txtRemarks");
                 string RejectedRemarks = Approval_remarks.Text;
                 string RejectedBY = Session["UserCode"].ToString();
                 ISS.INV_BIS_Delete(ID, RejectedRemarks, RejectedBY);
             }
         }

         // Show delete success message and refresh grid
         Response.Redirect(Request.Url.AbsoluteUri);
       //  BindGridBranchWise(); // Refresh your grid after deletion
     }
 }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        divModel_InvoiceDetails.Visible = false;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "open_Invoice", "setTimeout(function () {OpenNewPopUp('0','divModel_InvoiceDetails')}, 300);", true);
    }
    protected void BindVendor()
    {
        string BranchID = ddlBranch.SelectedValue; 
        ds = ISS.GetVendorListForPO(BranchID);
        ddlVendorID.DataSource = ds;
        ddlVendorID.DataTextField = "VM_Name";
        ddlVendorID.DataValueField = "VM_ID";
        ddlVendorID.DataBind();
        ddlVendorID.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindVendor();
        GetBranchWiseStockData();
    }

    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBranch();
        BindGridRegionWise();

    }

    protected void txtQuantity_TextChanged(object sender, EventArgs e)
    {
        TextBox textBox = (TextBox)sender;  

        GridViewRow row = (GridViewRow)textBox.NamingContainer;

        if (row != null)
        {

            int rowIndex = row.RowIndex;  
            TextBox quantity = (TextBox)row.FindControl("txtQuantity");
            Label UnitPrice = (Label)row.FindControl("lblUnitPrice");
            Label FinalPOAmount = (Label)row.FindControl("lblPOAmt");
            Label PreviousPOAmount = (Label)row.FindControl("lblPOAmt");
            Label PreviousFinalStock = (Label)row.FindControl("lblPreviousFinalQuantity");

            if (quantity.Text == null || UnitPrice.Text == null || FinalPOAmount.Text == null 
                || quantity.Text == "" || UnitPrice.Text == "" || FinalPOAmount.Text == "")
            {
                int pFinalStock = Convert.ToInt32(PreviousFinalStock.Text);
                int UPrice = Convert.ToInt32(UnitPrice.Text);
                int PoAmount = pFinalStock * UPrice;
                PreviousPOAmount.Text = PoAmount.ToString();
                quantity.Text = PreviousFinalStock.Text;


            }
            else
            {
                int FinalValue = Convert.ToInt32(quantity.Text);
                int UPrice = Convert.ToInt32(UnitPrice.Text);
                int PoAmount = FinalValue * UPrice;
                FinalPOAmount.Text = PoAmount.ToString();
            }
        }
    }

    protected void gvPOGenerate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        TextBox txtRemarks = (TextBox)e.Row.FindControl("txtRemarks");
        TextBox txtQuantity = (TextBox)e.Row.FindControl("txtQuantity");
        Label CppQuantity = (Label)e.Row.FindControl("CppQuantity");

        if (txtRemarks != null)
        {
            txtRemarks.Text = "Approved";
        }

        if (txtQuantity != null)
        {
            txtQuantity.Text = CppQuantity.Text;
        }
    }
}