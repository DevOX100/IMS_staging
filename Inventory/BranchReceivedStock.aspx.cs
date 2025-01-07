using DeveloperUtilz;
using gsmClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
public partial class Inventory_BranchReceivedStock : System.Web.UI.Page
{
    private DataSet ds = new DataSet();
    private Inventory_System ISS = new Inventory_System();
    gsmFileFolders ff = new gsmFileFolders();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPONumber();
            BindGrid();
        }
    }

    protected void BindPONumber()
    {
        string BranchID = Session["UserCode"].ToString();
        ds = ISS.usp_DistinctPONumberForBranchGRN(BranchID);


        DataTable dtFiltered = new DataTable();
        dtFiltered.Columns.Add("BIS_PONumber", typeof(string));
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            int approvedQuantity = row["BIS_stock_received_quantity"] != DBNull.Value
                                   ? Convert.ToInt32(row["BIS_stock_received_quantity"])
                                   : 0;
            int vendorSentQuantity = row["BIS_vendor_stock_quantity"] != DBNull.Value
                                     ? Convert.ToInt32(row["BIS_vendor_stock_quantity"])
                                     : 0;

            if (vendorSentQuantity != approvedQuantity)
            {
                dtFiltered.Rows.Add(row["BIS_PONumber"].ToString());
            }
            ddlPONUMBER.DataSource = dtFiltered;
            ddlPONUMBER.DataTextField = "BIS_PONumber";
            ddlPONUMBER.DataValueField = "BIS_PONumber";
            ddlPONUMBER.DataBind();

            ddlPONUMBER.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
        }


    }

    protected void gvBranchRecStock_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "View")
        {
            //string userCode = Session["UserCode"].ToString();
            string ID = (e.CommandArgument.ToString());
            if (ID != "")
            {
                ds = ISS.GetBIStockData_ForRM(ID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int ReqQuantity = Convert.ToInt32(ds.Tables[0].Rows[0]["BIS_Quantity"].ToString());
                    string InitiatorRemarks = (ds.Tables[0].Rows[0]["BIS_initiator_remarks"].ToString());
                    int ApprovedQuantity = Convert.ToInt32(ds.Tables[0].Rows[0]["BIS_approved_quantity"].ToString());

                    string ApprovedRemarks = (ds.Tables[0].Rows[0]["BIS_approved_remarks"]).ToString();
                    int CPPQuantity = Convert.ToInt32(ds.Tables[0].Rows[0]["BIS_CPP_approved_quantity"].ToString());
                    string CPPRemarks = (ds.Tables[0].Rows[0]["BIS_CPP_Approved_Remarks"].ToString());
                    DateTime RequestedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["BIS_insertDate"].ToString());
                    DateTime RMApproveDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["BIS_approve_date"].ToString());
                    DateTime CPPApproveDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["BIS_CPP_Approved_Date"].ToString());

                    lblRequestedQuantity.Text = ReqQuantity.ToString();
                    lblRequestorRemarks.Text = InitiatorRemarks.ToString();
                    lblStockAcceptance.Text = ApprovedQuantity.ToString();
                    lblAcceptorRemarks.Text = ApprovedRemarks.ToString();
                    lblCppQuantity.Text = CPPQuantity.ToString();
                    lblcppRemarks.Text = CPPRemarks.ToString();
                    lblRequestedDate.Text = RequestedDate.ToString();
                    lblRMApproveDate.Text = RMApproveDate.ToString();
                    lblCPPApproveDate.Text = CPPApproveDate.ToString();
                    divModel_InvoiceDetails.Visible = true;


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "open_Invoice", "setTimeout(function () {OpenNewPopUp('1','divModel_InvoiceDetails')}, 300);", true);
                    return;
                }
            }
        }

        if (e.CommandName == "Submit")
        {
            int chkCount = 0;
            for (int i = 0; i < gvBranchRecStock.Rows.Count; i++)
            {
                if (((CheckBox)gvBranchRecStock.Rows[i].FindControl("chkAction")).Checked)
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
                bool IsClosed = false;
                bool IsPartial = false;

                for (int i = 0; i < gvBranchRecStock.Rows.Count; i++)
                {
                    bool hasValidationError = false;
                    if (((CheckBox)gvBranchRecStock.Rows[i].FindControl("chkAction")).Checked)
                    {
                        CheckBox Approve = (CheckBox)gvBranchRecStock.Rows[i].FindControl("chkAction");
                        int ID = Convert.ToInt32(gvBranchRecStock.DataKeys[i]["BIS_ID"].ToString());
                        TextBox damageQuantity = ((TextBox)gvBranchRecStock.Rows[i].FindControl("txtDamageQuantity"));
                        TextBox dsRemarks = ((TextBox)gvBranchRecStock.Rows[i].FindControl("txtDamageRemarks"));
                        TextBox Quantity = ((TextBox)gvBranchRecStock.Rows[i].FindControl("txtQuantity"));
                        TextBox VRemarks = ((TextBox)gvBranchRecStock.Rows[i].FindControl("txtRemarks"));
                        Label PrdtCtID = ((Label)gvBranchRecStock.Rows[i].FindControl("lblProduct"));
                        Label VName = ((Label)gvBranchRecStock.Rows[i].FindControl("lblVMID"));
                        Label PrdctID = ((Label)gvBranchRecStock.Rows[i].FindControl("lblProductID"));
                        Label VendorSendQty = ((Label)gvBranchRecStock.Rows[i].FindControl("lblVSendQty"));
                        Label RecStock = ((Label)gvBranchRecStock.Rows[i].FindControl("RecStock"));
                        
                        if(RecStock.Text == null || RecStock.Text == "")
                        {
                            RecStock.Text = "0";
                        }

                        string stock_receivedBY = Session["UserCode"].ToString();
                        int stock_received_quantity = Convert.ToInt32(Quantity.Text);
                        string receiver_remarks = VRemarks.Text;
                        string ProductID = PrdctID.Text;
                        string VendorCode = VName.Text;
                        string BranchID = Session["UserCode"].ToString();
                        string DamageStockRemarks = dsRemarks.Text;
                        int VSendStck = Convert.ToInt32(VendorSendQty.Text);
                        int UserRecStock = Convert.ToInt32(RecStock.Text);
                        //int DamageQuantity = Convert.ToInt32(damageQuantity.Text);
                        if (stock_received_quantity > VSendStck || (stock_received_quantity + UserRecStock) > VSendStck)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Info!', 'You can not receive quantity more than vendor send stock', 'info');", true);
                            return;
                        }



                        int DamageQuantity = 0;

                        if (damageQuantity.Text == "null" || damageQuantity.Text == "")
                        {
                            DamageQuantity = 0;
                        }
                        else
                        {
                            DamageQuantity = Convert.ToInt32(damageQuantity.Text);
                        }


                        if (VSendStck == UserRecStock)
                        {
                          
                            IsClosed = true;
                           
                        }
                        else
                        {
                            IsPartial = true;
                        }

                        List<string> uploadedFileNames = new List<string>();
                        FileUpload fupImage = gvBranchRecStock.Rows[i].FindControl("fupid") as FileUpload;
                        string POD = " ";
                        string filePath = " ";
                        if (fupImage.HasFiles)
                        {
                            foreach (HttpPostedFile uploadedFile in fupImage.PostedFiles)
                            {
                                if (ff.GetFileSizeWithExtention(uploadedFile.FileName, Convert.ToDouble(uploadedFile.ContentLength), 1048576, "pdf"))
                                {
                                    if (uploadedFile.ContentLength <= 1048576)
                                    {
                                        string Exten = "." + Path.GetExtension(uploadedFile.FileName);
                                        Guid obj = Guid.NewGuid();  
                                      //  POD = "pdf1.pdf";
                                        filePath = Server.MapPath("~\\Upload\\PODBranch\\" + obj + Exten);
                                        uploadedFile.SaveAs(filePath);
                                        uploadedFileNames.Add(filePath);
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
                           
                            if (uploadedFileNames.Count >= 1)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "showLoading", "showLoading();", true);

                                string pdf = "";
                                if(uploadedFileNames.Count > 1)
                                {
                                    pdf = MergePDFs(uploadedFileNames);
                                    ISS.usp_ModifyBranchReceiveStock(stock_receivedBY, stock_received_quantity, receiver_remarks, ID, ProductID,
                                    VendorCode, BranchID, DamageStockRemarks, DamageQuantity, IsPartial, IsClosed, pdf);
                                    foreach (string file in uploadedFileNames)
                                    {
                                        if (file != pdf)
                                        {
                                            File.Delete(file);
                                        }
                                    }
                                }
                                else
                                {
                                    ISS.usp_ModifyBranchReceiveStock(stock_receivedBY, stock_received_quantity, receiver_remarks, ID, ProductID,
                                    VendorCode, BranchID, DamageStockRemarks, DamageQuantity, IsPartial, IsClosed, POD);

                                }

                                
                            }
                            

                        }
                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Submitted', 'success');", true);
                        BindGrid();
                    }
                }
            }

         

            BindPONumber();
           
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "hideLoading", "hideLoading();", true);
    }

    protected void ddlPONUMBER_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void BindGrid()
    {
      
        string PONumber = ddlPONUMBER.SelectedValue != "0" ? ddlPONUMBER.SelectedValue : "null";
        string branchCode = Session["UserCode"].ToString();
        ds = ISS.INV_BranchReceivedStock(PONumber, branchCode);
     gvBranchRecStock.DataSource = ds;
                gvBranchRecStock.DataBind();
       

    }


  

    protected void btnClose_Click(object sender, EventArgs e)
    {
        divModel_InvoiceDetails.Visible = false;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "open_Invoice", "setTimeout(function () {OpenNewPopUp('0','divModel_InvoiceDetails')}, 300);", true);
    }

    protected string MergePDFs(List<string> fileNames)
    {
        Guid obj = Guid.NewGuid();
        string outputFileName = obj.ToString() + ".pdf";
        string outputFilePath = Server.MapPath("~\\Upload\\PODBranch\\" + outputFileName);

        using (FileStream stream = new FileStream(outputFilePath, FileMode.Create))
        {
            Document document = new Document();
            PdfCopy pdf = new PdfCopy(document, stream);
            document.Open();

            foreach (string file in fileNames)
            {
                PdfReader reader = new PdfReader(file);
                int pageCount = reader.NumberOfPages;

                for (int i = 1; i <= pageCount; i++)
                {
                    PdfImportedPage page = pdf.GetImportedPage(reader, i);
                    pdf.AddPage(page);
                }

                reader.Close();
            }

            pdf.Close();
            document.Close();
        }
        return outputFileName;
    }

    protected void chkAction_CheckedChanged1(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.CheckBox chkAction = sender as System.Web.UI.WebControls.CheckBox;
        GridViewRow currentRow = chkAction.NamingContainer as GridViewRow;
        RequiredFieldValidator rfvQnty = gvBranchRecStock.Rows[currentRow.RowIndex].FindControl("rfvQnty") as RequiredFieldValidator;
        RequiredFieldValidator frvRmrks = gvBranchRecStock.Rows[currentRow.RowIndex].FindControl("frvRmrks") as RequiredFieldValidator;
        RequiredFieldValidator RequiredFieldValidator5 = gvBranchRecStock.Rows[currentRow.RowIndex].FindControl("RequiredFieldValidator5") as RequiredFieldValidator;

        if (chkAction.Checked)
        {
            rfvQnty.Enabled = true;
            frvRmrks.Enabled = true;
            RequiredFieldValidator5.Enabled = true;
        }
        else
        {
            rfvQnty.Enabled = false;
            frvRmrks.Enabled = false;
            RequiredFieldValidator5.Enabled = false;
        }
        
    }

    protected void gvBranchRecStock_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            //Label Remaining = (Label)e.Row.FindControl("lblremains");
            //Label Damaged = (Label)e.Row.FindControl("RemainingSsock");
            //string Damages=Damaged.Text;


            //if (!string.IsNullOrEmpty(Damaged.Text) || Damages== " ")
            //{
            //    Remaining.Visible = false;
            //}
            //else
            //{
            //    Remaining.Visible = true;
            //    Damaged.Visible = false;

            //}
            }
        }

    protected void txtDamageQuantity_TextChanged(object sender, EventArgs e)
    {
        //TextBox textBox = (TextBox)sender;

        //GridViewRow row = (GridViewRow)textBox.NamingContainer;
        //Label sendstock = (Label)row.FindControl("lblVendorSendQty");
        ////Label rec = (Label)row.FindControl("lblApprQuantity");
        //TextBox quantity = (TextBox)row.FindControl("txtQuantity");
        //TextBox DamagedQuantity = (TextBox)row.FindControl("txtDamageQuantity");
        //int qty = 0;
        //if (quantity.Text == null || quantity.Text == "")
        //{
        //    qty = 0;
        //}
        //else
        //{
        //    qty = Convert.ToInt32(quantity.Text);
        //}
        //if (!string.IsNullOrEmpty(sendstock.Text))
        //{
    
        //    string remains = sendstock.Text;
        //    string total =quantity.Text;


        //    if (Convert.ToInt32(total) > Convert.ToInt32(remains))
        //    {
        //        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Error!', 'Please Enter less than or equal to remaining Quantity!', 'info');", true);
        //        quantity.Text = remains.ToString();
        //    }
        //}
       
    }

    protected void txtQuantity_TextChanged(object sender, EventArgs e)
    {
    }
}
