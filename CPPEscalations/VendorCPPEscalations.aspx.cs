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
        int chkCount = 0;
        if (e.CommandName == "Submit")
        {


            for (int i = 0; i < GVEscalations.Rows.Count; i++)
            {
                if (((CheckBox)GVEscalations.Rows[i].FindControl("chkAction")).Checked)
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
                for (int i = 0; i < GVEscalations.Rows.Count; i++)
                {



                    if (((CheckBox)GVEscalations.Rows[i].FindControl("chkAction")).Checked)
                    {
                        CheckBox Approve = ((CheckBox)GVEscalations.Rows[i].FindControl("chkAction"));
                        int ID = Convert.ToInt32(GVEscalations.DataKeys[i]["Em_IssueID"].ToString());

                        TextBox Remarks = ((TextBox)GVEscalations.Rows[i].FindControl("txtUpperRemarks"));
                        string finalRemarks = Remarks.Text;

                        string EM_ActionTakenBY = Session["UserCode"].ToString();
                        TextBox ExpectedClosureDate = ((TextBox)GVEscalations.Rows[i].FindControl("txtExpectedClosureDate"));
                        DateTime? IS_ClosureDate;
                        DropDownList Complaints = ((DropDownList)GVEscalations.Rows[i].FindControl("ddlComplaintsbyVendor"));
                        string ComplaintsbyVendor = Complaints.SelectedItem.Text;
                        if (ExpectedClosureDate == null || ExpectedClosureDate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Error!', 'eneter the expected closure date', 'Invalid');", true);

                        }
                        else
                        {
                            if (Complaints.SelectedValue == "5")
                            {
                                IS_ClosureDate = Convert.ToDateTime(ExpectedClosureDate.Text);
                                ISS.INV_CPPVendorConfirmation(ID, EM_ActionTakenBY, finalRemarks, (DateTime)IS_ClosureDate, ComplaintsbyVendor);

                                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Submitted', 'success');", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Invalid!', '${ComplaintsbyVendor}', 'Kindly check Valid Reason');", true);
                                return;

                            }



                        }


                    }

                }
            }
            BindGrid2();
            BindGrid();


        }


        else
        {

            for (int i = 0; i < GVEscalations.Rows.Count; i++)
            {
                if (((CheckBox)GVEscalations.Rows[i].FindControl("chkAction")).Checked)
                {
                    chkCount++;
                }
            }

            if (chkCount == 0)
            {
                //// Replace ScriptManager.RegisterStartupScript with this line for page refresh:
                //Response.Redirect(Request.Url.AbsoluteUri);
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('No One Checked!', 'Please choose at least one!', 'error');", true);
                return;

               
            }
            else
            {
                for (int i = 0; i < GVEscalations.Rows.Count; i++)
                {


                    if (((CheckBox)GVEscalations.Rows[i].FindControl("chkAction")).Checked)
                    {

                        int ID = Convert.ToInt32(GVEscalations.DataKeys[i]["Em_IssueID"]);
                        TextBox Remarks = ((TextBox)GVEscalations.Rows[i].FindControl("txtUpperRemarks"));
                        string VendorRemarks = Remarks.Text;
                        string RejectedBY = Session["UserCode"].ToString();
                        DropDownList Complaints = ((DropDownList)GVEscalations.Rows[i].FindControl("ddlComplaintsbyVendor"));
                        string ComplaintsbyVendor = Complaints.SelectedItem.Text;

                        if (Complaints.SelectedValue == "5")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Please select!', 'Valid Reason!', 'error');", true);
                            return;
                        }
                        else
                        {
                            ISS.INV_Reject_Escalation("", "Name", "DamageProduct_ReceivedBY", "SpouseName", "MobileNO", 1, "ProductType", "Damage_Product_Name",
       "Damage_ProductComplaint", Convert.ToDateTime("01/01/1900"), "AvailableStockInBranch", "ComplaintsbyHO", VendorRemarks,
       RejectedBY, ID, "loanID", "productID", ComplaintsbyVendor);
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Submitted', 'Rejected');", true);
                            BindGrid();
                        }

                    }
                }

                // Show delete success message and refresh grid
                Response.Redirect(Request.Url.AbsoluteUri);
                //  BindGridBranchWise(); // Refresh your grid after deletion
            }
        }

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