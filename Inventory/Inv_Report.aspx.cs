using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using gsmClasses;
using iTextSharp.text.pdf.codec;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inventory_Inv_Report : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    Inventory_System ISS = new Inventory_System();
    gsmFileFolders ff = new gsmFileFolders();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindReports();
           
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DateTime dtFrom = Convert.ToDateTime(txtFromDate.Text);
        DateTime dtTo = Convert.ToDateTime(txtToDate.Text);
        string BranchID = Session["UserCode"].ToString();
        string LoginType = Session["loginType"].ToString();

        if (Convert.ToInt32(ddlReport.SelectedValue) == 1)
        {
            dt = ISS.IssueStockReport(dtFrom, dtTo, BranchID, LoginType);

        }

        if (Convert.ToInt32(ddlReport.SelectedValue) == 2)
        {
            dt = ISS.TransferStockReport(dtFrom, dtTo, BranchID, LoginType);

        }

        if (Convert.ToInt32(ddlReport.SelectedValue) == 3)
        {
            dt = ISS.AvailableStockReports(dtFrom, dtTo, BranchID, LoginType);

        }

        if (Convert.ToInt32(ddlReport.SelectedValue) == 4)
        {
            dt = ISS.IssueStockReverseReport(dtFrom, dtTo, BranchID, LoginType);

        }

        if (Convert.ToInt32(ddlReport.SelectedValue) == 5)
        {
            dt = ISS.ReportsOrder(dtFrom, dtTo, BranchID, LoginType);

        }

        if (Convert.ToInt32(ddlReport.SelectedValue) == 6)
        {
            dt = ISS.CPPEscalationReport(dtFrom, dtTo, BranchID, LoginType);
        }
        if (Convert.ToInt32(ddlReport.SelectedValue) == 7)
        {
            dt = ISS.stockAdjustment(dtFrom, dtTo, BranchID, LoginType);
        }
        string ToName = dtTo.ToShortDateString();
        string ReportName = ddlReport.SelectedItem.ToString();
        string FileName = ReportName.Trim() + " From " + dtFrom + " To " + ToName;
        if (dt.Rows.Count > 0)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {

                string FullFileName = FileName + ".xlsx";
                wb.Worksheets.Add(dt, "sheet");


                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=" + FullFileName);
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Oops!', 'No Record Available!', 'error');", true);
        }
    }

    protected void Download_Click(object sender, EventArgs e)
    {
        try
        {

            DateTime dtFrom = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtTo = Convert.ToDateTime(txtToDate.Text);
            string BranchID = Session["UserCode"].ToString();
            string LoginType = Session["loginType"].ToString();


            if (Convert.ToInt32(ddlReport.SelectedValue) == 1)
            {
                dt = ISS.IssueStockReport(dtFrom, dtTo, BranchID, LoginType);

            }
            else if (Convert.ToInt32(ddlReport.SelectedValue) == 6)
            {
                dt = ISS.CPPEscalationReport(dtFrom, dtTo, BranchID, LoginType);
            }
            if (Convert.ToInt32(ddlReport.SelectedValue) == 7)
            {
                dt = ISS.stockAdjustment(dtFrom, dtTo, BranchID, LoginType);
            }
            string ToName = dtTo.ToShortDateString();
            string FileName = ddlReport.SelectedItem.ToString() + " From " + dtFrom.ToShortDateString() + " To " + ToName;
            string[] ColName = new string[1];
            if (dt.Rows.Count > 0)
            {

                using (XLWorkbook wb = new XLWorkbook())
                {
                    IXLWorksheet worksheet = null;



                    if (Convert.ToInt32(ddlReport.SelectedValue) == 1)
                    {
                        worksheet = wb.Worksheets.Add("IssuedStock");
                        worksheet.Cell(1, 1).InsertTable(dt);
                        ColName[0] = "Image Code";
                    }
                    else if (Convert.ToInt32(ddlReport.SelectedValue) == 6)
                    {
                        worksheet = wb.Worksheets.Add("CPPEscalationReport");
                        worksheet.Cell(1, 1).InsertTable(dt);
                        ColName[0] = "Image Code";
                    }
                    else if (Convert.ToInt32(ddlReport.SelectedValue) == 7)
                    {
                        worksheet = wb.Worksheets.Add("Stock Adjustment");
                        worksheet.Cell(1, 1).InsertTable(dt);
                        ColName[0] = "Image Code";
                    }


                    int pdfColumnIndex = dt.Columns.Count + 1;
                    worksheet.Cell(1, pdfColumnIndex).Value = "File Links";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][ColName[0]] != DBNull.Value)
                        {
                            string podFileName = dt.Rows[i][ColName[0]].ToString();
                            string fileExtension = ".pdf";

                            string filePath = null;
                            string fileurl = "https://mmlappsprod.midlandmicrofin.co.in/Inventory_Live/Upload/";
                            string physicalFilePath = null;

                            if (Convert.ToInt32(ddlReport.SelectedValue) == 7 || Convert.ToInt32(ddlReport.SelectedValue) == 6)
                            {
                                fileExtension = ".jpg";
                                physicalFilePath = Server.MapPath("~/Upload/DamagedProduct/" + podFileName + fileExtension);
                                filePath = fileurl + "DamagedProduct/" + podFileName + fileExtension;
                            }
                            else
                            {
                                physicalFilePath = Server.MapPath("~/Upload/PodBranch/" + podFileName + fileExtension);
                                filePath = fileurl + "PodBranch/" + podFileName + fileExtension;
                            }

                            if (File.Exists(physicalFilePath))
                            {
                                var pdfLink = worksheet.Cell(i + 2, pdfColumnIndex);
                                pdfLink.Hyperlink = new XLHyperlink(filePath);
                                pdfLink.Value = "Open File";
                            }
                            else
                            {
                                worksheet.Cell(i + 2, pdfColumnIndex).Value = "No File available";
                            }
                        }
                        else
                        {
                            worksheet.Cell(i + 2, pdfColumnIndex).Value = "No POD";
                        }
                    }


                    string FullFileName = FileName + ".xlsx";
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + FullFileName);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        wb.SaveAs(memoryStream);
                        memoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Error: NO Record Found.');", true);
            }
        }
        catch (Exception ex)
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Error: " + ex.Message.Replace("'", "\\'") + "');", true);
        }
    }

    protected void ddlReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Search = ddlReport.SelectedValue.ToString();

        if (Search == "1" ||  Search == "6" || Search == "7")
        {
            divFromDate.Visible = true;
            divToDate.Visible = true;
            btnSubmit.Visible = false;
            Download.Visible = true;


        }
        else if(Search == "2" || Search == "3" || Search == "4" || Search == "5")
        {
            divFromDate.Visible = true;
            divToDate.Visible = true;
            btnSubmit.Visible = true;
            Download.Visible = false;
        }
    }

    protected void BindReports()
    {
        if(Session["loginType"].ToString() == "V")
        {
            ds = ISS.GETREPORTLIST();
            DataTable dt = ds.Tables[0];

            // Filter out reports you want to hide (e.g., ReportName "HiddenReport")
            string[] reportsToHide = { "Transfer Stock Report", "stock Adjustment", "Issue Stock Reverse Report" }; // Add report names to hide   
            foreach (string report in reportsToHide)
            {
                DataRow[] rows = dt.Select("ReportName = '" + report + "'");
                foreach (DataRow row in rows)
                {
                    dt.Rows.Remove(row);
                }
            }


            // Bind the filtered DataTable to the DropDownList
            ddlReport.DataSource = dt;
            ddlReport.DataTextField = "ReportName";
            ddlReport.DataValueField = "ReportNumber";
            ddlReport.DataBind();

            // Add the default "Select" item at the top
            ddlReport.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
        }
        else
        {
            //string branchID = Session["UserCode"].ToString();
            ds = ISS.GETREPORTLIST();
            ddlReport.DataSource = ds;
            ddlReport.DataTextField = "ReportName";
            ddlReport.DataValueField = "ReportNumber";
            ddlReport.DataBind();
            ddlReport.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
        }
   
    }
}