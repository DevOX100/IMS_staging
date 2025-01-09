using iTextSharp.text.pdf.codec;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using QiHe.CodeLib;
using gsmClasses;

public partial class Inventory_POVendorForrm : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    Inventory_System ISS = new Inventory_System();
    Encryption ec = new Encryption();
    gsmFileFolders ff = new gsmFileFolders();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();

        }

    }

    protected void BindGrid()
    {
        string VendorCode = Session["UserCode"].ToString();
        ds = ISS.VendorPO(VendorCode);
        VendorApproval.DataSource = ds;
        VendorApproval.DataBind();
    }

    protected void VendorApproval_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            string PONumber = e.CommandArgument.ToString();
            if (!string.IsNullOrEmpty(PONumber))
            {
                Response.Redirect(string.Format("POForm.aspx?PONumber={0}", HttpUtility.UrlEncode(ec.Encrypt(PONumber))));
            }
        }

        else if (e.CommandName == "Submit")
        {
            int checkedCount = 0;
            string VendorImage = "";
            DateTime Tentative_Delivery_Date;

            for (int i = 0; i < VendorApproval.Rows.Count; i++)
            {
                CheckBox chkAction = VendorApproval.Rows[i].FindControl("chkAction") as CheckBox;

                if (chkAction != null && chkAction.Checked)
                {
                    checkedCount++;

                    int ID = Convert.ToInt32(VendorApproval.DataKeys[i]["BIS_ID"]);
                    Label ApprovedQuantity = VendorApproval.Rows[i].FindControl("lblApprQuantity") as Label;
                    TextBox Quantity = VendorApproval.Rows[i].FindControl("txtQuantity") as TextBox;
                    TextBox VRemarks = VendorApproval.Rows[i].FindControl("txtRemarks") as TextBox;
                    TextBox Tentative_Delivery = VendorApproval.Rows[i].FindControl("txtTentativeDelDate") as TextBox;
                    FileUpload fupImage = VendorApproval.Rows[i].FindControl("fupid") as FileUpload;
                    DropDownList dropdownStatus = VendorApproval.Rows[i].FindControl("ddlStatus") as DropDownList;

                    string VendorUserID = Session["UserCode"].ToString();
                    int vendorStockQuantity = Convert.ToInt32(Quantity.Text);
                    string remarks = VRemarks.Text;
                    int approvedQty = Convert.ToInt32(ApprovedQuantity.Text);

                    if (Tentative_Delivery == null || Tentative_Delivery.Text == "")
                    {
                        Tentative_Delivery_Date = Convert.ToDateTime(DateTime.Now);
                    }
                    else
                    {
                        Tentative_Delivery_Date = Convert.ToDateTime(Tentative_Delivery.Text);
                    }

                    //         DateTime Tentative_Delivery_Date = Convert.ToDateTime(Tentative_Delivery.Text);
                    string ddlstatus = dropdownStatus.SelectedValue.ToString();
                   

                    if (approvedQty < vendorStockQuantity)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Info!', 'Do not enter quantity more than approved quantity.', 'info');", true);
                        return;
                    }


                    if (fupImage.HasFile)
                    {
                        if (ff.GetFileSizeWithExtention(fupImage.FileName, Convert.ToDouble(fupImage.FileBytes.LongLength), 1048576, "pdf"))
                        {
                            if (fupImage.FileBytes.LongLength <= 1048576)
                            {
                                string Exten;
                                Exten = "." + ff.GetFileExtention(fupImage.FileName);
                                Guid obj = Guid.NewGuid();
                                VendorImage = obj.ToString();
                                fupImage.SaveAs(Server.MapPath("~\\Upload\\PODImageVendor\\" + VendorImage + ".pdf"));
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Limit Exceed!', 'Please Upload Less than or Equal to 1 MB!', 'info');", true);
                                return;
                            }
                        }

                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Only PDF Format!', 'Please Upload Invoice only in PDF!', 'info');", true);
                            return;
                        }

                    }

                    if (ddlstatus == "4" || ddlstatus == "5")
                    {
                        ISS.ModifyStatusOfVendor(ID, ddlstatus, ddlstatus, remarks);
                    }
                    else
                    {

                        ISS.INV_ModifyVendorData(remarks, ID, VendorUserID, "Send to Branch", vendorStockQuantity, VendorImage, Tentative_Delivery_Date, dropdownStatus.SelectedValue);/*, filePath);*/
                    }


                }
            }

            if (checkedCount == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('No One Checked!', 'Please choose at least one!', 'error');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Submitted', 'success');", true);
                BindGrid();
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "hideLoading", "hideLoading();", true);
        }
    }

    protected void chkAction_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAction = sender as CheckBox;
        GridViewRow currentRow = chkAction.NamingContainer as GridViewRow;
        RequiredFieldValidator rfvRemarks = currentRow.FindControl("ers") as RequiredFieldValidator;
        RequiredFieldValidator rfvQuantity = currentRow.FindControl("RequiredFieldValidator1") as RequiredFieldValidator;
        RequiredFieldValidator rfvTentDelDate = currentRow.FindControl("rfvTentDelDate") as RequiredFieldValidator;
        RequiredFieldValidator rfvFileupload = currentRow.FindControl("rfvFileupload") as RequiredFieldValidator;
        RequiredFieldValidator rfvddlStatus = currentRow.FindControl("rfvddlStatus") as RequiredFieldValidator;
        GridViewRow row = (GridViewRow)chkAction.NamingContainer;
        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
        int selectedValue = Convert.ToInt32(ddlStatus.SelectedValue);


        if (selectedValue == 6)
        {
            rfvRemarks.Enabled = true;
            rfvQuantity.Enabled = true;
            rfvTentDelDate.Enabled = true;
            rfvFileupload.Enabled = true;
            rfvddlStatus.Enabled = true;
        }

        else if (selectedValue == 5 || selectedValue == 4)
        {
            rfvRemarks.Enabled = true;
            rfvQuantity.Enabled = false;
            rfvTentDelDate.Enabled = false;
            rfvFileupload.Enabled = false;
            rfvddlStatus.Enabled = false;
        }

        else
        {
            rfvRemarks.Enabled = false;
            rfvQuantity.Enabled = false;
            rfvTentDelDate.Enabled = false;
            rfvFileupload.Enabled = false;
            rfvddlStatus.Enabled = false;
        }
    }

    protected void VendorApproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtRemarks = (TextBox)e.Row.FindControl("txtQuantity");
            DropDownList Status = (DropDownList)e.Row.FindControl("ddlStatus");
            Label lblbisid = (Label)e.Row.FindControl("lblbisid");
            Label lblVendor = (Label)e.Row.FindControl("lblVendorSendstock");
            Label lblrequested = (Label)e.Row.FindControl("lblApprQuantity");
            int req = Convert.ToInt32(txtRemarks.Text);
            int vendor;
            if (string.IsNullOrEmpty(lblVendor.Text))
            {
                vendor = 0;


            }
            else
            {
                vendor = Convert.ToInt32(lblVendor.Text);
            }

            if (txtRemarks != null)
            {
                if (!string.IsNullOrEmpty(lblVendor.Text))
                {
                    txtRemarks.Text = (req - vendor).ToString();
                }


            }

            DataSet ds1 = new DataSet();
            ds1 = ISS.VendorStatus(Convert.ToInt32(lblbisid.Text));
            int OrderNo = Convert.ToInt32(ds1.Tables[0].Rows[0]["OP_ID"].ToString());

            if (ds1 != null && OrderNo > 3)
            {
                ds = ISS.INV_Finalorderprocess();
                Status.DataSource = ds;
                Status.DataTextField = "OP_Status";
                Status.DataValueField = "OP_ID";
                Status.SelectedValue = OrderNo.ToString();
                Status.DataBind();

            }
            else
            {
                ds = ISS.INV_Finalorderprocess();
                Status.DataSource = ds;
                Status.DataTextField = "OP_Status";
                Status.DataValueField = "OP_ID";
                Status.DataBind();
                Status.Items.Insert(0, new ListItem("Select", "0"));
            }


        }
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBox chkAction = sender as CheckBox;
        DropDownList ddlStatus = sender as DropDownList;
        GridViewRow currentRow = (GridViewRow)ddlStatus.NamingContainer;
        RequiredFieldValidator rfvRemarks = currentRow.FindControl("ers") as RequiredFieldValidator;
        RequiredFieldValidator rfvQuantity = currentRow.FindControl("RequiredFieldValidator1") as RequiredFieldValidator;
        RequiredFieldValidator rfvTentDelDate = currentRow.FindControl("rfvTentDelDate") as RequiredFieldValidator;
        RequiredFieldValidator rfvFileupload = currentRow.FindControl("rfvFileupload") as RequiredFieldValidator;
        RequiredFieldValidator rfvddlStatus = currentRow.FindControl("rfvddlStatus") as RequiredFieldValidator;

        string selectedValue = ddlStatus.SelectedValue;

        if (selectedValue == "6")
        {
            rfvRemarks.Enabled = true;
            rfvQuantity.Enabled = true;
            rfvTentDelDate.Enabled = true;
            rfvFileupload.Enabled = true;
            rfvddlStatus.Enabled = true;
            //  chkAction.Checked = true;
        }

        else if (selectedValue == "5" || selectedValue == "4")
        {
            rfvRemarks.Enabled = false;
            rfvQuantity.Enabled = false;
            rfvTentDelDate.Enabled = false;
            rfvFileupload.Enabled = false;
            rfvddlStatus.Enabled = false;
        }

    }

    protected void txtQuantity_TextChanged(object sender, EventArgs e)
    {
        TextBox textBox = (TextBox)sender;

        GridViewRow row = (GridViewRow)textBox.NamingContainer;
        Label sendstock = (Label)row.FindControl("lblVendorSendstock");
        Label rec = (Label)row.FindControl("lblApprQuantity");
        TextBox quantity = (TextBox)row.FindControl("txtQuantity");
        int qty = 0;
        if (quantity.Text == null || quantity.Text == "")
        {
            qty = 0;
        }
        else
        {
            qty = Convert.ToInt32(quantity.Text);
        }
        if (!string.IsNullOrEmpty(sendstock.Text))
        {
            int Rec = Convert.ToInt32(rec.Text);
            int remains = Convert.ToInt32(sendstock.Text);
            int total = Rec - remains;
            if (qty > total)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Error!', 'Please Enter less than or equal to remaining Quantity!', 'info');", true);
                quantity.Text = total.ToString();
            }
        }


    }
}