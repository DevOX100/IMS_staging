﻿using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Master_ProductMappingWithBranch : System.Web.UI.Page
{
    Inventory_System ISS = new Inventory_System();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRegion();
            FirstDiv.Visible = false;
            EMP.Visible = false;
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

        ddlBranch.DataSource = ds;
        ddlBranch.DataTextField = "Branch_Name";
        ddlBranch.DataValueField = "Branch_ID";
        ddlBranch.DataBind();
        ddlBranch.Items.Insert(0, new ListItem("Select", "0"));

    }
    protected void BindGrid()
    {
        string RegionID = ddlRegion.SelectedValue;
        string BranchID = ddlBranch.SelectedValue;
        ds = ISS.ProductBranchMapping(RegionID, BranchID);
        gvIssue.DataSource = ds;
        gvIssue.DataBind();
    }
    private void ShowAllControls()
    {
        EMP.Visible = false;
        FirstDiv.Visible = true;
        gvIssue.Visible = false;
        gvBulk.Visible = true;

    }

    private void HideAllControls()
    {
        EMP.Visible = true;
        FirstDiv.Visible = false;
        gvBulk.Visible = false;
        gvIssue.Visible = true;

        //SetVisibilityForControls(false);
    }

    private string FileContentTypeHeader(string FileExtension)
    {
        string FiletypeHeader = "";
        switch (FileExtension.ToLower())
        {
            case ".xls":
                FiletypeHeader = "application/vnd.ms-excel";
                break;

            default:
                FiletypeHeader = "application/octet-stream";
                break;
        }
        return FiletypeHeader;
    }
    private string FileContentTypeContent(string FileExtension)
    {
        string FiletypeHeader = "";
        switch (FileExtension.ToLower())
        {
            case ".xls":
                FiletypeHeader = "application/vnd.ms-excel";
                break;

            default:
                FiletypeHeader = "application/octet-stream";
                break;
        }
        return FiletypeHeader;
    }
    protected void btnFormat_Click(object sender, EventArgs e)
    {

        try
        {
            bool DeleteAfterDownload = false;
            string FileName = Server.MapPath("~/Upload/Format/" + "ProductMapping.xls");
            Guid id = Guid.NewGuid();
            string ClientFileName = id.ToString() + ".xls";
            ClientFileName = Regex.Replace(ClientFileName, "\\s", "");
            string fileExtention = Path.GetExtension(FileName).ToLower();
            FileInfo fileInfo = new FileInfo(FileName);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + ClientFileName);
            HttpContext.Current.Response.AddHeader("Content-Type", FileContentTypeHeader(fileExtention));
            HttpContext.Current.Response.ContentType = FileContentTypeContent(fileExtention);
            HttpContext.Current.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            HttpContext.Current.Response.WriteFile(fileInfo.FullName);
            HttpContext.Current.Response.Flush();

        }

        catch (Exception ex)
        {
            ex.ToString();
            return;
        }
    }

    protected void btnUploadExcel_Click(object sender, EventArgs e)
    {
        Guid guid = Guid.NewGuid();
        if (fpBulkUpload.HasFile)
        {

            string FilePath = Server.MapPath("~/Upload/Temp/" + guid.ToString() + ".xls");
            fpBulkUpload.SaveAs(FilePath);
            DataTable dt = ExcelLibrary.DataSetHelper.CreateDataSet(FilePath).Tables[0];
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "Swal.fire('Upload Successfully', '', 'success');", true);
            gvBulk.DataSource = dt;
            gvBulk.DataBind();
            gvBulk.BackColor = System.Drawing.Color.Azure;


        }
        else
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "hwa", "alert('No Record Available')", true);
        }

    }

    protected void gvBulk_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Report")
        {
            int checkCount = 0;
            for (int i = 0; i < gvBulk.Rows.Count; i++)
            {
                if (((CheckBox)gvBulk.Rows[i].FindControl("chkReport")).Checked)
                {

                    checkCount++;
                }

            }
            if (checkCount == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('No One Checked!', 'Please choose at least one!', 'error');", true);
                return;
            }
            else
            {
                for (int i = 0; i < gvBulk.Rows.Count; i++)
                {
                    if (((CheckBox)gvBulk.Rows[i].FindControl("chkReport")).Checked)
                    {

                        try
                        {
                            CheckBox Approve = ((CheckBox)gvBulk.Rows[i].FindControl("chkReport"));
                            string chk = Approve.Text;
                            Label branch = (Label)gvBulk.Rows[i].FindControl("lblBranchID");
                            Label Product = (Label)gvBulk.Rows[i].FindControl("lblProductID");

                            string BranchID = branch.Text;
                            string productID = Product.Text;
                            string InsertBy = Session["UserCode"].ToString();


                            ds = ISS.InsertproductMapping(BranchID, productID, InsertBy);




                            Approve.Checked = false;
                            gvBulk.Rows[i].Visible = false;
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Invalid!', '" + ex.Message.Replace("'", "\\'") + "', 'error');", true);
                        }




                    }
                }

                if (gvBulk.Rows.Count == 0)
                {
                    gvBulk.Visible = false;
                }
            }
        }
    }

    protected void RadioButton_CheckedChanged(object sender, EventArgs e)
    {
        ShowAllControls();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {

        HideAllControls();
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

    protected void gvIssue_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "change")
        {
            int ID = Convert.ToInt32(e.CommandArgument);
            ISS.ModifyProductMappingData(ID);
            BindGrid();
        }
    }
}