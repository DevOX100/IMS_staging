using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using CheckBox = System.Web.UI.WebControls.CheckBox;
using Label = System.Web.UI.WebControls.Label;
using TextBox = System.Web.UI.WebControls.TextBox;


public partial class CPPEscalations_ViewComplaints : System.Web.UI.Page
{
    public DataSet ds = new DataSet();
    Inventory_System ISS = new Inventory_System();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["LoginType"].ToString() == "B")
            {
                ddlBranch.Visible = false;
                ddlRegion.Visible = false;
                lblBranch.Visible = false;
                Region.Visible = false;
            }
            else
            {
                GVViewEscalationns.Columns[13].Visible = false;
                GVViewEscalationns.Columns[14].Visible = false;

                ddlBranch.Visible = true;
                ddlRegion.Visible = true;
                lblBranch.Visible = true;
                Region.Visible = true;
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
        if (string.IsNullOrEmpty(region))
        {
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
        string userCode = Session["UserCode"].ToString();
        ds = ISS.ViewEscalation(region, branch, status, userCode);
        GVViewEscalationns.DataSource = ds;
        GVViewEscalationns.DataBind();



    }
    //private void RemoveLastGridColumn()
    //{
    //    int lastIndex = GVViewEscalationns.Columns.Count - 1; 
    //    if (lastIndex >= 0)
    //    {
    //        GVViewEscalationns.Columns.RemoveAt(lastIndex); 
    //    }
    //}
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
                lblEM_VendorTechVisit.Text = (issueDetails["EM_TechnicianVisit"] != DBNull.Value) ? issueDetails["EM_TechnicianVisit"].ToString() : "N/A";
                lblEM_VendorClosure.Text = (issueDetails["EM_VendorclosureType"] != DBNull.Value) ? issueDetails["EM_VendorclosureType"].ToString() : "N/A";
                lblEM_Confirmation.Text = (issueDetails["EM_BranchComplaint_Confirmation"] != DBNull.Value) ? issueDetails["EM_BranchComplaint_Confirmation"].ToString() : "N/A";
                lblEM_ProductDelivery.Text = (issueDetails["EM_BranchProduct_delivery"] != DBNull.Value) ? issueDetails["EM_BranchProduct_delivery"].ToString() : "N/A";
                lblEM_ConfirmationDate.Text = (issueDetails["EM_BranchConfirmation_Date"] != DBNull.Value) ? issueDetails["EM_BranchConfirmation_Date"].ToString() : "N/A";
                lblEM_ProductDeliveryDate.Text = (issueDetails["EM_BranchProduct_DeliveryDate"] != DBNull.Value) ? issueDetails["EM_BranchProduct_DeliveryDate"].ToString() : "N/A";
                lblexpectedClosure.Text= (issueDetails["EM_VendorExpectedClosureDate"] != DBNull.Value) ? issueDetails["EM_VendorExpectedClosureDate"].ToString() : "N/A";
                lblVendorRemarks.Text = (issueDetails["EM_VendorRemarks"] != DBNull.Value) ? issueDetails["EM_VendorRemarks"].ToString() : "N/A";
                lblConfirmationRemarks.Text = (issueDetails["EM_BranchConfirmationRemarks"] != DBNull.Value) ? issueDetails["EM_BranchConfirmationRemarks"].ToString() : "N/A";
                // Trigger the modal using ScriptManager
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#divModel_InvoiceDetails').modal('show');", true);
            }
            else
            {
                // Handle no data scenario
                ScriptManager.RegisterStartupScript(this, this.GetType(), "NoData", "alert('No details found for the selected issue.');", true);
            }
        }
        else
        {
            int chkCount = 0;
            for (int i = 0; i < GVViewEscalationns.Rows.Count; i++)
            {
                if (((CheckBox)GVViewEscalationns.Rows[i].FindControl("chkAction")).Checked)
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
                for (int i = 0; i < GVViewEscalationns.Rows.Count; i++)
                {
                    if (((CheckBox)GVViewEscalationns.Rows[i].FindControl("chkAction")).Checked)
                    {
                        Label lblEM_IssueID = ((Label)GVViewEscalationns.Rows[i].FindControl("lblEMIssueID"));

                        TextBox txtRemarks = ((TextBox)GVViewEscalationns.Rows[i].FindControl("txtRemarks"));
                        int ID = Convert.ToInt32(lblEM_IssueID.Text);
                        DropDownList ddlclosure = ((DropDownList)GVViewEscalationns.Rows[i].FindControl("ddlCLosure"));
                        DropDownList ddlstatus = ((DropDownList)GVViewEscalationns.Rows[i].FindControl("ddlStatus"));
                        string closure = ddlclosure.SelectedItem.Text;
                        string status = ddlstatus.SelectedItem.Text;
                        string remarks = txtRemarks.Text;
                        if (ddlclosure.SelectedValue == "0")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('No Closure Selected!', 'Please Provide your confirmation!', 'error');", true);
                            return;
                        }
                        else
                        {
                            //if(ddlstatus.SelectedValue =="1" && ddlclosure.SelectedValue == "0")
                            //{
                            //    ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('No Closure Selected!', 'Please choose a Status of delivery!', 'error');", true);
                            //    return;

                            //}
                            //else
                            //{
                            if (ddlstatus.SelectedValue == "0")
                            {
                                status = "No Value Provided";
                            }

                            ISS.insertBranchfeedback(closure, status, ID, remarks);
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Success!', 'Status Updated Successfully!', 'success');", true);
                            BindGrid();
                            //}
                        }



                    }
                }
            }
        }
    }



    //protected void btnClose_Click(object sender, EventArgs e)
    //{
    //    divModel_InvoiceDetails.Visible = false;
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "open_Invoice", "setTimeout(function () {OpenNewPopUp('0','divModel_InvoiceDetails')}, 300);", true);

    //}

    protected void chkAction_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAction = sender as CheckBox;
        GridViewRow currentRow = chkAction.NamingContainer as GridViewRow;
        RequiredFieldValidator remarks = currentRow.FindControl("rfvRemarks") as RequiredFieldValidator;



        RequiredFieldValidator Status = currentRow.FindControl("rfvStatus") as RequiredFieldValidator;
        RequiredFieldValidator Closure = currentRow.FindControl("rfvCLosure") as RequiredFieldValidator;

        if (chkAction.Checked && chkAction.Checked == true)
        {
            remarks.Enabled = true;
            Closure.Enabled = true;
      


        }
        else
        {
            remarks.Enabled = false;
            Closure.Enabled = false;
           

        }
    }


    protected void GVViewEscalationns_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Find controls within the current row
            DropDownList status = (DropDownList)e.Row.FindControl("ddlStatus");
            DropDownList closure = (DropDownList)e.Row.FindControl("ddlCLosure");
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            Label lblComplaintConf = (Label)e.Row.FindControl("lblComplaintconf");
            Label lblProductDelivery = (Label)e.Row.FindControl("lblproductDelivery");
            Label lblIsVendorClosure = (Label)e.Row.FindControl("lblIsVendorClosure");
           TextBox txtRemarks = (TextBox)e.Row.FindControl("txtRemarks");

            // Check if the "lblStatus" label exists and has a value
            if (lblStatus != null && lblStatus.Text == "Closed")
            {
                // Enable DropDownLists if the status is "Closed"
                if (status != null) status.Enabled = true;
                if (closure != null) closure.Enabled = true;
            }
            else
            {
                // Disable DropDownLists for other statuses
                if (status != null) status.Enabled = false;
                if (closure != null) closure.Enabled = false;
            }


            // Set selected values for DropDownLists based on labels
            if (lblComplaintConf != null && !string.IsNullOrEmpty(lblComplaintConf.Text))
            {
                if (closure != null)
                {
                    // Select the item in ddlClosure matching lblComplaintConf.Text
                    if (closure.Items.FindByText(lblComplaintConf.Text) != null)
                    {
                        closure.SelectedValue = closure.Items.FindByText(lblComplaintConf.Text).Value;

                        if (lblIsVendorClosure.Text == "1")
                        {
                            closure.Enabled = false;
                            txtRemarks.Enabled = false;
                        }
                        else
                        {
                            closure.Enabled = true;
                            txtRemarks.Enabled = true;
                        }
                    }
                }
            }

            if (lblProductDelivery != null && !string.IsNullOrEmpty(lblProductDelivery.Text))
            {
                if (status != null)
                {
                    // Select the item in ddlStatus matching lblProductDelivery.Text
                    if (status.Items.FindByText(lblProductDelivery.Text) != null)
                    {
                        status.SelectedValue = status.Items.FindByText(lblProductDelivery.Text).Value;
                        status.Enabled = false;
                    }
                }
            }

        }
    }

    protected void ddlCLosure_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlClosure = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlClosure.NamingContainer;
        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");

        if (ddlClosure.SelectedValue == "1")
        {
            ddlStatus.Enabled = true;
        }
        else
        {
            ddlStatus.Enabled = false;
            ddlStatus.SelectedValue = "0";
        }
    }


}