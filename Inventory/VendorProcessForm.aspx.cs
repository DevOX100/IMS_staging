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

public partial class Inventory_VendorProcessForm : System.Web.UI.Page
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
        ds = ISS.INV_VendorProcessData(VendorCode);
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

            for (int i = 0; i < VendorApproval.Rows.Count; i++)
            {
                CheckBox chkAction = VendorApproval.Rows[i].FindControl("chkAction") as CheckBox;

                if (chkAction != null && chkAction.Checked)
                {
                    checkedCount++;

                    int ID = Convert.ToInt32(VendorApproval.DataKeys[i]["BIS_ID"]);
                    DropDownList Status = VendorApproval.Rows[i].FindControl("ddlStatus") as DropDownList;

                    string VendorStatus = Status.SelectedValue;


                    ISS.INV_ModifyVendorStatusData(ID, VendorStatus);/*, filePath);*/
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
        }
    }




    protected void VendorApproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtRemarks = (TextBox)e.Row.FindControl("txtRemarks");
            Label lblbisid = (Label)e.Row.FindControl("lblbisid");
            DropDownList Status = (DropDownList)e.Row.FindControl("ddlStatus");
            if (txtRemarks != null)
            {
                txtRemarks.Text = "Approved";
            }

            DataSet ds1 = new DataSet();
            ds1 = ISS.VendorStatus(Convert.ToInt32(lblbisid.Text));
            int OrderNo = Convert.ToInt32(ds1.Tables[0].Rows[0]["OP_ID"].ToString());
            if (ds1 != null && OrderNo < 4)
            {
                
                if(OrderNo == 0)
                {
                    ds = ISS.INV_orderprocess();
                    Status.DataSource = ds;
                    Status.DataTextField = "OP_Status";
                    Status.DataValueField = "OP_ID";
                    Status.DataBind();
                    Status.Items.Insert(0, new ListItem("Select", "0"));
                }
                else
                {
                    ds = ISS.INV_orderprocess();
                    Status.DataSource = ds;
                    Status.DataTextField = "OP_Status";
                    Status.DataValueField = "OP_ID";
                    Status.SelectedValue = OrderNo.ToString();
                    Status.DataBind();
                }
               
                
            }
            else
            {
                ds = ISS.INV_orderprocess();
                Status.DataSource = ds;
                Status.DataTextField = "OP_Status";
                Status.DataValueField = "OP_ID";
                Status.DataBind();
                Status.Items.Insert(0, new ListItem("Select", "0"));
            }
           

         
        }
    }
}
