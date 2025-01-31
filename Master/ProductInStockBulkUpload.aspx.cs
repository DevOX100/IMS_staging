﻿using gsmClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;

public partial class Master_ProductInStockBulkUpload : System.Web.UI.Page
{
    Inventory_System ISS = new Inventory_System();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }

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
            string FileName = Server.MapPath("~/Upload/Format/" + "ProductINStock.xls");
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

ScriptManager.RegisterStartupScript(this, GetType(), "hideLoading", "hideLoading();", true);
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
                //int rowindex = Convert.ToInt32(e.CommandArgument);
                //if(rowindex == -1)
                //{
                //    rowindex = 0;
                //}
                //GridViewRow row = gvBulk.Rows[rowindex];
                //CheckBox chkReport = (CheckBox)row.FindControl("chkReport");
                //List<int> rowsToRemove = new List<int>();

                for (int i = 0; i < gvBulk.Rows.Count; i++)
                {
                    if (((CheckBox)gvBulk.Rows[i].FindControl("chkReport")).Checked)
                    {
                       
                        try
                        {
                            CheckBox Approve = ((CheckBox)gvBulk.Rows[i].FindControl("chkReport"));
                            string chk=Approve.Text;
                            Label branch = (Label)gvBulk.Rows[i].FindControl("lblBranchID");
                            Label Product = (Label)gvBulk.Rows[i].FindControl("lblProductID");
                            //Label StockStatus = (Label)gvBulk.Rows[i].FindControl("lblStockStatus");
                            //Label InsertBY = (Label)gvBulk.Rows[i].FindControl("lblInsertBY");
                            Label Quantity = (Label)gvBulk.Rows[i].FindControl("lblQuantity");

                            string BranchID = branch.Text;
                            string productID = Product.Text;
                            //string Stock = StockStatus.Text;
                            string InsertBy = Session["UserCode"].ToString();
                            int qty = Convert.ToInt32(Quantity.Text);
                            string Remarks = "Bulk Insertion";
                            ds = ISS.insertProductStock(BranchID, productID, InsertBy, qty, Remarks);
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Product is added in the product list!', 'success');", true);
                            Approve.Checked = false;
                            gvBulk.Rows[i].Visible = false;
                        }
                        catch (Exception ex) {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Invalid!', 'Wrong Data Has Been Found!' );", true);
                        }



                    }
                }


                       ScriptManager.RegisterStartupScript(this, GetType(), "hideLoading", "hideLoading();", true);
   Button btnSave = (Button)gvBulk.FooterRow.FindControl("btnSave");
   btnSave.Visible = false;


                //foreach (int rowIndex in rowsToRemove.OrderByDescending(x => x))
                //{
                //    gvBulk.Rows[rowIndex].Visible = false;
                //    chkReport.Checked = false;


                //}
               // if (gvBulk.Rows.Count == 0)
               // {
                 //   gvBulk.Visible = false;
               // }
            }
        }
    }

    protected void chkReport_CheckedChanged(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.CheckBox chkReport = sender as System.Web.UI.WebControls.CheckBox;
        GridViewRow currentRow = chkReport.NamingContainer as GridViewRow;
       
    }
}