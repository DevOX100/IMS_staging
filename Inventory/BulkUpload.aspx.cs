using gsmClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inventory_BulkUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void rbReverse_CheckedChanged(object sender, EventArgs e)
    {
        
    }

    protected void rbIssue_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void btnFormat_Click(object sender, EventArgs e)
    {
        try
        {

            string FileName = Server.MapPath("~/Upload/Format/" + "ReverseFormat.xls");
            Guid id = Guid.NewGuid();
            string ClientFileName = id.ToString() + ".xls";
            gsmWeb2ClientUtils gwc = new gsmWeb2ClientUtils();
            gwc.FileDownload2Client(FileName, ClientFileName, false);
        }

        catch (Exception ex)
        {
            ex.ToString();
            return;
        }
    }


    public DataTable UploadData()
    {

        DataTable dt = new DataTable();
        dt.Columns.Add("CustID", Type.GetType("System.String"));
        dt.Columns.Add("LoanID", Type.GetType("System.String"));
        dt.Columns.Add("ProductID", Type.GetType("System.String"));
        dt.Columns.Add("BranchID", Type.GetType("System.String"));
        dt.Columns.Add("ReverseQuantity", Type.GetType("System.Int"));
        return dt;
    }

    protected void btnUploadExcel_Click(object sender, EventArgs e)
    {
        Guid guid = Guid.NewGuid();
        if (fpBulkUpload.HasFile)
        {

            string FilePath = Server.MapPath("~/Upload/Temp/" + guid.ToString() + ".xls");
            fpBulkUpload.SaveAs(FilePath);
            DataTable dt = ExcelLibrary.DataSetHelper.CreateDataSet(FilePath).Tables[0];
            //   File.Delete(FilePath);
            gvBulk.DataSource = dt;
            gvBulk.DataBind();
            gvBulk.BackColor = System.Drawing.Color.Azure;
            //  DisplayAJAXMessage(this, "Upload Successfully");
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
            
            gvBulk.DataSource = null;
            gvBulk.DataBind();
           // ClientScript.RegisterClientScriptBlock(this.GetType(), "hwa", "alert('Data has been inserted successfully!')", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Data has been inserted successfully!', 'success');", true);
        }
    }
}