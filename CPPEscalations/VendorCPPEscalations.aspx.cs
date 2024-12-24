using DocumentFormat.OpenXml.Bibliography;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CPPEscalations_VendorCPPEscalations : System.Web.UI.Page
{
    public DataSet ds = new DataSet();
    Inventory_System ISS = new Inventory_System();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
            BindRegion();
            BindGrid2();

        }

    }
    protected void BindGrid()
    {
        string RegionCode = ddlRegion.SelectedValue;
        string BranchID = ddlBranch.SelectedValue;
        if (string.IsNullOrEmpty(BranchID))
        {
            BranchID = "0";

        }
        if (string.IsNullOrEmpty(RegionCode))
        {
            RegionCode = "0";
        }

        string Usercode = Session["UserCode"].ToString();
        ds = ISS.INV_CPPEscalations(Usercode, RegionCode, BranchID);
        GVEscalations.DataSource = ds;
        GVEscalations.DataBind();

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


    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBranch();
        BindGrid();
        BindGrid2();
    }

    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
        BindGrid2();
    }




    protected void GVEscalations_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int chkCount = 0;

            // Count the number of selected checkboxes
            foreach (GridViewRow row in GVEscalations.Rows)
            {
                CheckBox chkAction = (CheckBox)row.FindControl("chkAction");
                if (chkAction != null && chkAction.Checked)
                {
                    chkCount++;
                }
            }

            if (chkCount == 0)
            {
                ShowAlert("No One Checked!", "Please choose at least one!", "error");
                return;
            }

            // Process each selected row
            foreach (GridViewRow row in GVEscalations.Rows)
            {
                CheckBox chkAction = (CheckBox)row.FindControl("chkAction");
                if (chkAction != null && chkAction.Checked)
                {
                    try
                    {
                        int id = Convert.ToInt32(GVEscalations.DataKeys[row.RowIndex]["Em_IssueID"].ToString());
                        TextBox remarksTextBox = (TextBox)row.FindControl("txtUpperRemarks");
                        string remarks = remarksTextBox != null ? remarksTextBox.Text : string.Empty;
                        string actionTakenBy = Session["UserCode"].ToString();

                        DropDownList complaintsDropdown = (DropDownList)row.FindControl("ddlComplaintsbyVendor");
                        string complaintsByVendor = complaintsDropdown != null && complaintsDropdown.SelectedItem != null
                            ? complaintsDropdown.SelectedItem.Text : string.Empty;
                        string selectedValue = complaintsDropdown != null ? complaintsDropdown.SelectedValue : string.Empty;

                        if (e.CommandName == "Submit")
                        {
                            if (selectedValue == "5")
                            {
                                TextBox closureDateTextBox = (TextBox)row.FindControl("txtExpectedClosureDate");
                                string closureDateText = closureDateTextBox != null ? closureDateTextBox.Text : string.Empty;
                                DateTime closureDate;

                                if (DateTime.TryParse(closureDateText, out closureDate))
                                {
                                    ISS.INV_CPPVendorConfirmation(id, actionTakenBy, remarks, closureDate, complaintsByVendor);
                                    ShowAlert("Done!", "Submitted", "success");
                                }
                                else
                                {
                                    ShowAlert("Error!", "Invalid Closure Date!", "error");
                                    return;
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Error!', 'Kindly select \"Escalating to Technician\" while approving the request', 'error');", true);
                                return;
                            }
                        }
                        else if (e.CommandName == "Reject")
                        {
                            if (selectedValue != "5")
                            {
                                ISS.INV_Reject_Escalation("", "Name", "DamageProduct_ReceivedBY", "SpouseName", "MobileNO", 1, "ProductType", "Damage_Product_Name",
                                    "Damage_ProductComplaint", Convert.ToDateTime("01/01/1900"), "AvailableStockInBranch", "ComplaintsbyHO", remarks,
                                    actionTakenBy, id, "loanID", "productID", complaintsByVendor);
                                ShowAlert("Done!", "Rejected", "success");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Error!', 'Kindly select \"Correct Complaint from the dropdown\" while Rejecting the request', 'error');", true);
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowAlert("Invalid!", ex.Message.Replace("'", "\\'"), "error");
                    }
                }
            }

            // Refresh the grid after processing
            BindGrid2();
            BindGrid();
        }
        catch (Exception ex)
        {
            ShowAlert("Error!", ex.Message.Replace("'", "\\'"), "error");
        }
    }

    // Helper method to show alerts using SweetAlert
    private void ShowAlert(string title, string message, string icon)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert",
            string.Format("swal('{0}', '{1}', '{2}');", title, message, icon), true);
    }

    protected void GVEscalations_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlComplaintsbyVendor = (DropDownList)e.Row.FindControl("ddlComplaintsbyVendor");
            TextBox txtExpectedClosureDate = (TextBox)e.Row.FindControl("txtExpectedClosureDate");
            if (ddlComplaintsbyVendor.SelectedValue != "5")
            {
                txtExpectedClosureDate.Enabled = false;

            }
        }

    }



    protected void chkAction_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAction = sender as CheckBox;
        GridViewRow currentRow = chkAction.NamingContainer as GridViewRow;
        RequiredFieldValidator Remarks = currentRow.FindControl("rfvUpperRemarks") as RequiredFieldValidator;
        RequiredFieldValidator rfvWarrantydate = currentRow.FindControl("rfvWarrantydate") as RequiredFieldValidator;
        RequiredFieldValidator rfvComplaint = currentRow.FindControl("rfvComplaint") as RequiredFieldValidator;



        if (chkAction.Checked && chkAction.Checked == true)
        {
            Remarks.Enabled = true;

            rfvComplaint.Enabled = true;
        }
        else
        {
            Remarks.Enabled = false;

            rfvComplaint.Enabled = false;
        }

    }
    protected void BindGrid2()
    {
        string RegionCode = ddlRegion.SelectedValue;
        string BranchID = ddlBranch.SelectedValue;
        if (string.IsNullOrEmpty(BranchID))
        {
            BranchID = "0";

        }
        if (string.IsNullOrEmpty(RegionCode))
        {
            RegionCode = "0";
        }


        string Usercode = Session["UserCode"].ToString();
        ds = ISS.INV_CPPVendorConfirmEscalations(Usercode, RegionCode, BranchID);
        GVConfirmEscalation.DataSource = ds;
        GVConfirmEscalation.DataBind();

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int chkCount = 0;
        if (e.CommandName == "Submit")
        {


            for (int i = 0; i < GVConfirmEscalation.Rows.Count; i++)
            {
                if (((CheckBox)GVConfirmEscalation.Rows[i].FindControl("chkAction")).Checked)
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
                for (int i = 0; i < GVConfirmEscalation.Rows.Count; i++)
                {



                    if (((CheckBox)GVConfirmEscalation.Rows[i].FindControl("chkAction")).Checked)
                    {
                        CheckBox Approve = ((CheckBox)GVConfirmEscalation.Rows[i].FindControl("chkAction"));
                        int ID = Convert.ToInt32(GVConfirmEscalation.DataKeys[i]["Em_IssueID"].ToString());

                        TextBox Remarks = ((TextBox)GVConfirmEscalation.Rows[i].FindControl("txtRemarks"));
                        Label ProductID = ((Label)GVConfirmEscalation.Rows[i].FindControl("lblProduct"));
                        DropDownList TechVisit = ((DropDownList)GVConfirmEscalation.Rows[i].FindControl("ddlTechVisit"));
                        DropDownList Status = ((DropDownList)GVConfirmEscalation.Rows[i].FindControl("ddlStatus"));
                        DropDownList Closure = ((DropDownList)GVConfirmEscalation.Rows[i].FindControl("ddlCLosure"));
                        string finalRemarks = Remarks.Text;
                        string productID = ProductID.Text;
                        string EM_ActionTakenBY = Session["UserCode"].ToString();
                        string TechVisitRemarks = TechVisit.SelectedItem.Text;
                        string StatusRemarks = Status.SelectedItem.Text;
                        string ClosureRemarks = Closure.SelectedItem.Text;

                        if (Closure.SelectedValue == "0")
                        {
                            ClosureRemarks = null;
                        }
                        if (Closure.Enabled == true && Closure.SelectedValue != "1" && Closure.SelectedValue != "2")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Error', 'Please select Closure Type from the dropdown', 'error');", true);
                            return;
                        }

                        else
                        {
                            if (string.IsNullOrEmpty(finalRemarks))
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Error', 'Please Enter Remarks', 'error');", true);
                                return;
                            }
                            else
                            {
                                ISS.INV_CPPVendorActioned(ID, EM_ActionTakenBY, finalRemarks, TechVisitRemarks, ClosureRemarks, StatusRemarks, productID);
                            }

                        }
                    }

                }
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Submitted', 'success');", true);
                BindGrid2();

            }


        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlTechVisit = (DropDownList)e.Row.FindControl("ddlTechVisit");
            DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
            DropDownList Closure = (DropDownList)e.Row.FindControl("ddlCLosure");
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            Label lblTechVisit = (Label)e.Row.FindControl("lblTechVisit");
            Label lblClosureType = (Label)e.Row.FindControl("lblClosureType");

            Closure.Enabled = false;
            if (lblClosureType != null && !string.IsNullOrEmpty(lblClosureType.Text))
            {
                // Select the item in ddlClosure matching lblComplaintConf.Text
                if (Closure.Items.FindByText(lblClosureType.Text) != null)
                {
                    Closure.SelectedValue = Closure.Items.FindByText(lblClosureType.Text).Value;

                }

            }

            if (lblStatus != null && !string.IsNullOrEmpty(lblStatus.Text))
            {
                if (ddlStatus != null)
                {
                    // Select the item in ddlStatus matching lblProductDelivery.Text
                    if (ddlStatus.Items.FindByText(lblStatus.Text) != null)
                    {
                        ddlStatus.SelectedValue = ddlStatus.Items.FindByText(lblStatus.Text).Value;

                    }
                }
            }
            if (lblTechVisit != null && !string.IsNullOrEmpty(lblTechVisit.Text))
            {
                if (ddlTechVisit != null)
                {
                    // Select the item in ddlStatus matching lblProductDelivery.Text
                    if (ddlTechVisit.Items.FindByText(lblTechVisit.Text) != null)
                    {
                        ddlTechVisit.SelectedValue = ddlTechVisit.Items.FindByText(lblTechVisit.Text).Value;

                    }
                }
            }



            // Retrieve last submitted values (replace with actual data source or ViewState)

        }
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {


        DropDownList ddlStatus = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlStatus.NamingContainer;
        DropDownList ddlClosure = (DropDownList)row.FindControl("ddlCLosure");

        if (ddlStatus.SelectedValue == "2")
        {
            ddlClosure.Enabled = true;
        }
        else
        {
            ddlClosure.Enabled = false;
            ddlClosure.SelectedValue = "0";
        }


    }

    protected void chkAction_CheckedChanged1(object sender, EventArgs e)
    {
        CheckBox chkAction = sender as CheckBox;
        GridViewRow currentRow = chkAction.NamingContainer as GridViewRow;
        RequiredFieldValidator remarks = currentRow.FindControl("rfvRemarks") as RequiredFieldValidator;


        RequiredFieldValidator TechVisit = currentRow.FindControl("rfvTechVisit") as RequiredFieldValidator;
        RequiredFieldValidator Status = currentRow.FindControl("rfvStatus") as RequiredFieldValidator;
        RequiredFieldValidator Closure = currentRow.FindControl("rfvCLosure") as RequiredFieldValidator;

        if (chkAction.Checked && chkAction.Checked == true)
        {
            remarks.Enabled = true;
            TechVisit.Enabled = true;
            Status.Enabled = true;


        }
        else
        {
            remarks.Enabled = false;
            TechVisit.Enabled = false;
            Status.Enabled = false;

        }
    }

    protected void ddlComplaintsbyVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlComplaintsbyVendor = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlComplaintsbyVendor.NamingContainer;
        TextBox txtExpectedClosureDate = (TextBox)row.FindControl("txtExpectedClosureDate");
        if (ddlComplaintsbyVendor.SelectedValue == "5")
        {
            txtExpectedClosureDate.Enabled = true;
        }
        else
        {
            txtExpectedClosureDate.Enabled = false;
        }
    }
}