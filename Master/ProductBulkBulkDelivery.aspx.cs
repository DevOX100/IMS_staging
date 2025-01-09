using gsmClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;

public partial class Master_ProductBulkBulkDelivery : System.Web.UI.Page
{
    Inventory_System ISS = new Inventory_System();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Initialization logic
        }
    }

    private string FileContentType(string FileExtension)
    {
        switch (FileExtension.ToLower())
        {
            case ".xls":
                return "application/vnd.ms-excel";
            case ".xlsx":
                return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            default:
                return "application/octet-stream";
        }
    }

    protected void btnFormat_Click(object sender, EventArgs e)
    {
        string VendorCode = Session["UserCode"].ToString();
        dt = ISS.FormatVendorDelivery(VendorCode);
        string FileName = "BulkDelivery";

        if (dt.Rows.Count > 0)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                string FullFileName = FileName + ".xlsx";

                if (dt.Rows.Count > 10000)
                {
                    int sheetCount = 0;
                    foreach (DataTable chunk in SplitDataTable(dt, 10000))
                    {
                        sheetCount++;
                        wb.Worksheets.Add(chunk, "Sheet" + sheetCount);
                    }
                }
                else
                {
                    wb.Worksheets.Add(dt, "Sheet1");
                }

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = FileContentType(".xlsx");
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

    protected void btnUploadExcel_Click(object sender, EventArgs e)
    {
        Guid guid = Guid.NewGuid();

        if (fpBulkUpload.HasFile)
        {
            string FilePath = Server.MapPath("~/Upload/BulkVendor/" + guid.ToString() + Path.GetExtension(fpBulkUpload.FileName));
            fpBulkUpload.SaveAs(FilePath);

            DataTable uploadedData = ReadExcelData(FilePath);
            if (uploadedData.Rows.Count > 0)
            {
                gvBulk.DataSource = uploadedData;
                gvBulk.DataBind();
                gvBulk.BackColor = System.Drawing.Color.Azure;
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "Swal.fire('Upload Successful', '', 'success');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "Swal.fire('No Data Found', '', 'warning');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "Swal.fire('No File Selected', '', 'error');", true);
        }

        ScriptManager.RegisterStartupScript(this, GetType(), "hideLoading", "hideLoading();", true);
    }

    private DataTable ReadExcelData(string filePath)
    {
        DataTable dt = new DataTable();

        using (XLWorkbook workbook = new XLWorkbook(filePath))
        {
            IXLWorksheet worksheet = workbook.Worksheets.Worksheet(1);

            foreach (IXLRow row in worksheet.RowsUsed())
            {
                if (dt.Columns.Count == 0)
                {
                    foreach (IXLCell cell in row.CellsUsed())
                    {
                        dt.Columns.Add(cell.Value.ToString());
                    }
                }
                else
                {
                    dt.Rows.Add();
                    int cellIndex = 0;
                    foreach (IXLCell cell in row.CellsUsed())
                    {
                        dt.Rows[dt.Rows.Count - 1][cellIndex++] = cell.Value;
                    }
                }
            }
        }

        return dt;
    }

    private IEnumerable<DataTable> SplitDataTable(DataTable original, int chunkSize)
    {
        for (int i = 0; i < original.Rows.Count; i += chunkSize)
        {
            DataTable chunk = original.Clone(); // Clone structure
            for (int j = i; j < i + chunkSize && j < original.Rows.Count; j++)
            {
                chunk.ImportRow(original.Rows[j]);
            }
            yield return chunk;
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

            for (int i = 0; i < gvBulk.Rows.Count; i++)
            {
                if (((CheckBox)gvBulk.Rows[i].FindControl("chkReport")).Checked)
                {
                    try
                    {
                        CheckBox Approve = ((CheckBox)gvBulk.Rows[i].FindControl("chkReport"));
                        Label BIS_ID = (Label)gvBulk.Rows[i].FindControl("lblID");
                        Label enterQuantity = (Label)gvBulk.Rows[i].FindControl("lblEnterQuantity");
                        Label tentativeDelivery = (Label)gvBulk.Rows[i].FindControl("lblTentativeDeliveryDate");
                        Label Remarks = (Label)gvBulk.Rows[i].FindControl("lblRemarks");

                        int id = Convert.ToInt32(BIS_ID.Text);
                        string VendorUserID = Session["UserCode"].ToString();
                        string remarks = Remarks.Text;
                        int quantity = Convert.ToInt32(enterQuantity.Text);
                        DateTime deliveryDate = Convert.ToDateTime(tentativeDelivery.Text);

                        ISS.INV_BulkVendorData(remarks, id, VendorUserID, "Send to Branch", quantity, "", deliveryDate, "6");

                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Product is added to the product list!', 'success');", true);
                        Approve.Checked = false;
                        gvBulk.Rows[i].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Invalid!', 'Error processing data: " + ex.Message + "', 'error');", true);
                    }
                }
            }
        }
    }
}
