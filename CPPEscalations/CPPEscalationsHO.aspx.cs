using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CPPEscalations_CPPEscalationsHO : System.Web.UI.Page
{
    public DataSet ds = new DataSet();
    Inventory_System ISS = new Inventory_System();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRegion();
            BindGrid();
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
    }

    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void btnClosed_Click(object sender, EventArgs e)
    {
        Div_View_Image.Visible = false;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "open_Invoice", "setTimeout(function () {OpenNewPopUp('0','Div_View_Image')}, 300);", true);
    }
    protected void GVEscalations_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int chkCount = 0;
        bool hasError = false;
        if (e.CommandName == "VIEWDamagedImage")
        {
            string index = e.CommandArgument.ToString();
            if (!string.IsNullOrEmpty(index))
            {
                string filePath = Server.MapPath("~/Upload/DamagedProduct/" + index + ".jpg");


                if (File.Exists(filePath))
                {
                    var webClient = new WebClient();
                    byte[] jpgBytes = webClient.DownloadData(filePath);


                    string embed = "<object data=\"data:image/jpeg;base64, {0}\" type=\"image/jpeg\" width=\"100%\" height=\"500px\">";
                    embed += "<embed src=\"data:image/jpeg;base64, {0}\" type=\"image/jpeg\" />";
                    embed += "</object>";

                    lvImage.Text = string.Format(embed, Convert.ToBase64String(jpgBytes));
                    Div_View_Image.Visible = true;


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "open_Image", "setTimeout(function () {OpenNewPopUp('1','Div_View_Image')}, 300);", true);
                }
                else
                {

                    lvImage.Text = "Image file not found.";
                    Div_View_Image.Visible = true;
                }
            }
        }
        else
        {
            // Check if any rows are selected
            for (int i = 0; i < GVEscalations.Rows.Count; i++)
            {
                if (((CheckBox)GVEscalations.Rows[i].FindControl("chkAction")).Checked)
                {
                    chkCount++;
                }
            }

            // Validate selection
            if (chkCount == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('No One Checked!', 'Please choose at least one!', 'error');", true);
                return;
            }

            // Process selected rows
            for (int i = 0; i < GVEscalations.Rows.Count; i++)
            {
                CheckBox Approve = ((CheckBox)GVEscalations.Rows[i].FindControl("chkAction"));

                if (Approve.Checked)
                {
                    try
                    {
                        int ID = Convert.ToInt32(GVEscalations.DataKeys[i]["Issued_ID"].ToString());

                        TextBox Remarks = ((TextBox)GVEscalations.Rows[i].FindControl("txtRemarks"));
                        Label IS_CustID = ((Label)GVEscalations.Rows[i].FindControl("lblCustID"));
                        Label IS_Name = ((Label)GVEscalations.Rows[i].FindControl("lblCustomerName"));
                        Label IS_SpouseName = ((Label)GVEscalations.Rows[i].FindControl("lblSpouseName"));
                        Label IS_MobileNO = ((Label)GVEscalations.Rows[i].FindControl("lblMobileNo"));
                        Label Is_DamageProduct_ReceivedBY = ((Label)GVEscalations.Rows[i].FindControl("lblBrnach"));
                        Label IS_Damage_stock_Quantity = ((Label)GVEscalations.Rows[i].FindControl("lblQuantity"));
                        Label productType = ((Label)GVEscalations.Rows[i].FindControl("lblProductType"));
                        Label IS_Damage_Product_Name = ((Label)GVEscalations.Rows[i].FindControl("lblProductName"));
                        Label IS_Damage_ProductComplaint = ((Label)GVEscalations.Rows[i].FindControl("lblProductComplaint"));
                        Label IS_Damage_ProductComplaint_date = ((Label)GVEscalations.Rows[i].FindControl("lblComplaintDate"));
                        Label IS_AvailableStockInBranch = ((Label)GVEscalations.Rows[i].FindControl("AvailabilityInBranch"));
                        Label LoandID = ((Label)GVEscalations.Rows[i].FindControl("lblLoandID"));
                        Label ProductID = ((Label)GVEscalations.Rows[i].FindControl("lblProduct"));
                        DropDownList ddlComplaintsby = ((DropDownList)GVEscalations.Rows[i].FindControl("ddlComplaintsbyHO"));

                        string loanID = LoandID.Text;
                        string CustID = IS_CustID.Text;
                        string Name = IS_Name.Text;
                        string SpouseName = IS_SpouseName.Text;
                        string MobileNO = IS_MobileNO.Text;
                        string DamageProduct_ReceivedBY = Is_DamageProduct_ReceivedBY.Text;
                        int Quantity = Convert.ToInt32(IS_Damage_stock_Quantity.Text);
                        string ProductType = productType.Text;
                        string Damage_Product_Name = IS_Damage_Product_Name.Text;
                        string Damage_ProductComplaint = IS_Damage_ProductComplaint.Text;
                        DateTime Damage_ProductComplaint_date = Convert.ToDateTime(IS_Damage_ProductComplaint_date.Text);
                        string AvailableStockInBranch = IS_AvailableStockInBranch.Text;
                        string ComplaintsbyHO = ddlComplaintsby.SelectedItem.Text;
                        string finalRemarks = Remarks.Text;
                        string EM_ActionTakenBY = Session["UserCode"].ToString();
                        string productID = ProductID.Text;

                        // Determine action based on command name
                        if (e.CommandName == "Submit")
                        {
                            ISS.INV_InsertEscalations(CustID, Name, DamageProduct_ReceivedBY, SpouseName, MobileNO, Quantity, ProductType, Damage_Product_Name,
                                Damage_ProductComplaint, Damage_ProductComplaint_date, AvailableStockInBranch, ComplaintsbyHO, finalRemarks,
                                EM_ActionTakenBY, ID, loanID, productID);
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Submitted Successfully', 'success');", true);
                        }

                        else if (e.CommandName == "Reject")
                        {
                            ISS.INV_Reject_Escalation(CustID, Name, DamageProduct_ReceivedBY, SpouseName, MobileNO, Quantity, ProductType, Damage_Product_Name,
                                Damage_ProductComplaint, Damage_ProductComplaint_date, AvailableStockInBranch, ComplaintsbyHO, finalRemarks,
                                EM_ActionTakenBY, ID, loanID, productID,"");
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Submitted Successfully', 'success');", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        hasError = true;
                        // Log the error or handle it appropriately
                        ScriptManager.RegisterStartupScript(this, GetType(), "ErrorAlert",
          string.Format("swal('Error!', 'An error occurred while processing: {0}', 'error');", ex.Message), true);

                    }
                }
            }

            // Show success message and refresh grid
            //if (!hasError)
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Submitted Successfully', 'success');", true);
            //}

            // Rebind the grid to refresh data
            BindGrid();
        }
    }

    protected void GVEscalations_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtRemarks = (TextBox)e.Row.FindControl("txtRemarks");
            TextBox txtQuantity = (TextBox)e.Row.FindControl("txtQuantity");
            Label CppQuantity = (Label)e.Row.FindControl("CppQuantity");

            if (txtRemarks != null)
            {
                txtRemarks.Text = "Approved";
            }

            if (txtQuantity != null && CppQuantity != null)
            {
                txtQuantity.Text = CppQuantity.Text;
            }
        }
    }

    protected void chkAction_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAction = sender as CheckBox;
        GridViewRow currentRow = chkAction.NamingContainer as GridViewRow;

        RequiredFieldValidator ComplaintType = currentRow.FindControl("rfvComplaintType") as RequiredFieldValidator;

        if (ComplaintType != null)
        {
            ComplaintType.Enabled = chkAction.Checked;
        }
    }
}