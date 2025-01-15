using gsmClasses;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using gsmClasses;
using QiHe.CodeLib;
using DeveloperUtilz;
using Org.BouncyCastle.Tls.Crypto;
public partial class IssueStock : System.Web.UI.Page
{
    Inventory_System ISS = new Inventory_System();
    DataSet ds = new DataSet();
    Encryption ec = new Encryption();
    gsmFileFolders ff = new gsmFileFolders();
    duValidate dv = new duValidate();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bindproduct();


            secondDiv.Visible = false;
            box.Visible = false;
            CustID.Visible = false;
            LoanID.Visible = true;
            GroupID.Visible = false;
            CenterID.Visible = false;
        }
    }


    protected void Bindproduct()
    {
        ds = ISS.GetProductList(Session["UserCode"].ToString());
        ddlProduct.DataSource = ds;
        ddlProduct.DataTextField = "PM_Description1";
        ddlProduct.DataValueField = "PM_ItemCode1";
        ddlProduct.DataBind();
        ddlProduct.Items.Insert(0, new ListItem("Select", "0"));

    }
    protected void BindGrid()
    {
        string branchID = Session["UserCode"].ToString();
        string IS_CustID = txtSearch.Text;
        string LoanID = txtLoanID.Text;
        string CenterID = txtCenter.Text;
        string GrpCenterID = txtGrpCenter.Text;
        string GroupID = ddlGroup.SelectedValue;

        if (LoanID == "" || LoanID == null)
        {
            LoanID = "null";
        }

        if (IS_CustID == "" || IS_CustID == null)
        {
            IS_CustID = "null";
        }

        if (CenterID == "" || CenterID == null)
        {
            CenterID = "null";
        }

        if ((GroupID == "0" || GroupID == null) && (GrpCenterID == "" || GrpCenterID == null))
        {
            GroupID = "null";
        }

        if (GroupID != "null" || GrpCenterID != "")
        {
            CenterID = GrpCenterID;
        }

        // string BranchID = Session["UserCode"].ToString();

        DataSet ds = ISS.GetIssueStock(IS_CustID, LoanID, GroupID, CenterID, branchID)/* , Quantity);*/;

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvIssue.DataSource = ds;
            gvIssue.DataBind();
            gvIssue.Visible = true;

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Invalid!', 'Wrong ID!' );", true);
            gvIssue.Visible = false;

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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string IS_UserType = "NewUser";
        //string IS_CustID =txtCustomer.Text;
        string IS_CustID = dv.RandomPassword3(6);
        string IS_LoanID = dv.RandomPassword3(6);


        string IS_Name = txtName.Text;
        string IS_Product = ddlProduct.SelectedValue;
        string IS_Branch = Session["UserCode"].ToString();
        string IS_MobileNO = txtPhone.Text;
        string IS_SpouseName = txtSpouse.Text;
        string IS_InvoiceNO = txtInvoiceNO.Text;
        DateTime IS_WarrantyDate = Convert.ToDateTime(txtWarrantyDatee.Text);
        if (IS_WarrantyDate > DateTime.Now)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Error!', 'Kindly Enter Valid Date', 'error');", true);
            return;
        }

       else if (IS_WarrantyDate < DateTime.Now.AddDays(-7))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Error!', 'Date shouldn't be lesser than a week', 'error');", true);
            return;

        }
        int IS_Quantity = Convert.ToInt32(txtQuantity.Text);
        string IS_PaymentMode = ddlPaymentMode.SelectedItem.Text;
        string Is_ApplicationReceivedStage = ApplicationReceivedStage.SelectedItem.Text;
        int IS_Amount = Convert.ToInt32(textAmount.Text);
        string POD = " ";
        if (fupImage.HasFile)
        {
            if (ff.GetFileSizeWithExtention(fupImage.FileName, Convert.ToDouble(fupImage.FileBytes.LongLength), 1048576, "pdf"))
            {
                if (fupImage.FileBytes.LongLength <= 1048576)
                {
                    string Exten;
                    Exten = "." + ff.GetFileExtention(fupImage.FileName);
                    Guid obj = Guid.NewGuid();
                    POD = obj.ToString();
                    fupImage.SaveAs(Server.MapPath("~\\Upload\\PodBranch\\" + POD + ".pdf"));
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

        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Info!', 'Please Upload POD only in PDF!', 'info');", true);
            return;
        }

        try
        {


            ds = ISS.IssueStock(IS_CustID, IS_Name, IS_Product, IS_Branch, IS_SpouseName, IS_MobileNO, POD, IS_InvoiceNO, IS_Quantity, IS_UserType, IS_WarrantyDate, IS_LoanID, IS_PaymentMode, IS_Amount, Is_ApplicationReceivedStage);
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Product has been saved!', 'success');", true);
            cleardata();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Invalid!', '" + ex.Message.Replace("'", "\\'") + "', 'error');", true);
        }
    }

    protected void cleardata()
    {
        txtCustomer.Text = "";
        txtName.Text = "";
        ddlProduct.SelectedValue = "0";

        txtPhone.Text = "";
        txtSpouse.Text = "";
        txtInvoiceNO.Text = "";
        txtQuantity.Text = "";
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        cleardata();
    }

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    BindGrid();
    //}


    //private bool CustomerExists(string custID)
    //{

    //    string IS_CustID = txtSearch.Text;
    //    string LoanID = txtLoanID.Text;
    //    string CenterID = txtCenter.Text;
    //    string GrpCenterID = txtGrpCenter.Text;
    //    string GroupID = ddlGroup.SelectedValue;

    //    if (LoanID == "" || LoanID == null)
    //    {
    //        LoanID = "null";
    //    }

    //    if (IS_CustID == "" || IS_CustID == null)
    //    {
    //        IS_CustID = "null";
    //    }


    //    if (CenterID == "" || CenterID == null)
    //    {
    //        CenterID = "null";
    //    }

    //    if (GroupID == "" || GroupID == null || GrpCenterID == "" || GrpCenterID == null)
    //    {
    //        GroupID = "null";
    //    }

    //    if (GroupID != "" || GroupID != null || GrpCenterID != "" || GrpCenterID != null)
    //    {
    //        CenterID = GrpCenterID;
    //        GroupID = "null";
    //    }

    //    //string BranchID = Session["UserCode"].ToString();

    //    DataSet ds = ISS.GetIssueStock(IS_CustID, LoanID, GroupID, CenterID)/* , Quantity);*/;
    //    return ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0;
    //}
    private void ShowAllControls()
    {
        secondDiv.Visible = false;
        box.Visible = true;

        //SetVisibilityForControls(true);
    }

    private void HideAllControls()
    {
        secondDiv.Visible = true;
        box.Visible = false;



        //SetVisibilityForControls(false);
    }

    //private void SetVisibilityForControls(bool isVisible)
    //{
    //    foreach (Control control in box.Controls)
    //    {
    //        if (control is Label || control is TextBox || control is FileUpload || control is Button || control is RequiredFieldValidator || control is RadioButton)
    //        {
    //            control.Visible = isVisible;
    //        }
    //    }
    //}



    protected void gvIssue_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string POD = "";
        string IS_UserType = "FinPageUser";


        if (e.CommandName == "Submit")
        {

            int chkCount = 0;
            for (int i = 0; i < gvIssue.Rows.Count; i++)
            {
                if (((CheckBox)gvIssue.Rows[i].FindControl("chkAction")).Checked)
                {
                    chkCount++;
                }
            }

            if (chkCount == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('No One Checked!', 'Please Check at least one!', 'error');", true);
                return;
            }
            for (int i = 0; i < gvIssue.Rows.Count; i++)
            {

                if (((CheckBox)gvIssue.Rows[i].FindControl("chkAction")).Checked)
                {

                    //string ID = gvIssue.DataKeys[i]["Cust_ID"].ToString();
                    TextBox Quantity = ((TextBox)gvIssue.Rows[i].FindControl("txtGQuantity"));
                    Label CUSTID = ((Label)gvIssue.Rows[i].FindControl("lblCustID"));
                    Label Amount = ((Label)gvIssue.Rows[i].FindControl("lblUnitprice"));
                    Label FirstName = ((Label)gvIssue.Rows[i].FindControl("lblFirstName"));
                    //   Label ProID = ((Label)gvIssue.Rows[i].FindControl("lblProduct"));
                    DropDownList IMSProID = ((DropDownList)gvIssue.Rows[i].FindControl("Productddl"));
                    DropDownList ddlModeOfDisbursement = ((DropDownList)gvIssue.Rows[i].FindControl("ModeOfDisbursement"));
                    DropDownList ddlApplicationReceivedStage = ((DropDownList)gvIssue.Rows[i].FindControl("ApplicationReceivedStage"));
                    Label INVBranch = ((Label)gvIssue.Rows[i].FindControl("lblBranchID"));
                    Label MobileNumber = ((Label)gvIssue.Rows[i].FindControl("lblMobileNO"));
                    Label SpouseName = ((Label)gvIssue.Rows[i].FindControl("lblSpouseNAme"));
                    Label LoanId = ((Label)gvIssue.Rows[i].FindControl("lblLoanID"));
                    TextBox txtInvoice = ((TextBox)gvIssue.Rows[i].FindControl("txtInvoice"));
                    TextBox txtAmount = ((TextBox)gvIssue.Rows[i].FindControl("txtAmount"));

                    FileUpload fupImage = gvIssue.Rows[i].FindControl("fupid") as FileUpload;

                    TextBox WarrantyDate = ((TextBox)gvIssue.Rows[i].FindControl("txtWarrantyDate"));


                    if (ID == null || Quantity == null || FirstName == null || IMSProID == null || INVBranch == null || MobileNumber == null || SpouseName == null
                        || fupImage == null || WarrantyDate == null)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Error!', 'Not able to insert the data as data is missing!', 'error');", true);
                        return;
                    }
                    
                    string Invoice = txtInvoice.Text;
                    string custID = CUSTID.Text;
                    string fName = FirstName.Text;
                    // string ProductID= ProID.Text;
                    string IMSProductID = IMSProID.SelectedValue;
                    string Bnch = INVBranch.Text;
                    string Mnumber = MobileNumber.Text;
                    string Sname = SpouseName.Text;
                    string loanID = LoanId.Text;
                    //string IS_WarrantyDate = WarrantyDate.Text;
                    DateTime? IS_WarrantyDate;

                    if (WarrantyDate.Text == null || WarrantyDate.Text == "")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Incomplete Inputs', 'All Inputs are Required!', 'info');", true);
                        return;
                    }
                    else
                    {
                        IS_WarrantyDate = Convert.ToDateTime(WarrantyDate.Text);
                        if (IS_WarrantyDate > DateTime.Now)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Error!', 'Kindly Enter Valid Date', 'error');", true);
                            return;
                        }

                       else if (IS_WarrantyDate < DateTime.Now.AddDays(-7))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Error!', 'Date shouldn't be lesser than 7 days ', 'error');", true);
                            return;

                        }
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
                                POD = obj.ToString();
                                fupImage.SaveAs(Server.MapPath("~\\Upload\\PodBranch\\" + POD + ".pdf"));
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

                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Info!', 'Please Upload POD only in PDF!', 'info');", true);
                        return;
                    }
                    int Amount1 = Convert.ToInt32(txtAmount.Text);
                    int UnitPrice = Convert.ToInt32(Amount.Text);
                    int QTY = Convert.ToInt32(Quantity.Text);
                    try
                    {


                        ds = ISS.IssueStock(custID, fName, IMSProductID, Bnch, Sname, Mnumber, POD, Invoice, QTY, IS_UserType, IS_WarrantyDate, loanID, ddlModeOfDisbursement.SelectedItem.Text, Amount1, ddlApplicationReceivedStage.SelectedItem.Text);
                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Product has been Issued!', 'success');", true);
                        gvIssue.DataSource = null;
                        gvIssue.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Invalid!', '" + ex.Message.Replace("'", "\\'") + "', 'error');", true);
                    }

                }

            }
        }

        // BindGrid();


    }

    //protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string BranchID = Session["UserCode"].ToString();
        ds = ISS.usp_FinpageCustExistOrNot(txtSearch.Text, "null", "null", "null", BranchID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Not Exist!', 'No Data Has Been Found!' );", true);
            return;
        }
        else
        {
            BindGrid();
        }
    }


    protected void chkAction_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAction = sender as CheckBox;
        GridViewRow currentRow = chkAction.NamingContainer as GridViewRow;
        RequiredFieldValidator rfvQuantity = currentRow.FindControl("rfvQuanty") as RequiredFieldValidator;
        RequiredFieldValidator rfvFileUpload = currentRow.FindControl("rfvFileUpload") as RequiredFieldValidator;
        RequiredFieldValidator ProdDropDWN = currentRow.FindControl("ProdDropDWN") as RequiredFieldValidator;
        RequiredFieldValidator InvoiceValidator = currentRow.FindControl("InvoiceValidator") as RequiredFieldValidator;
        RequiredFieldValidator rfvWarrantydate = currentRow.FindControl("rfvWarrantydate") as RequiredFieldValidator;
        RequiredFieldValidator rfc2 = currentRow.FindControl("rfc2") as RequiredFieldValidator;
        RequiredFieldValidator RequiredFieldValidator4 = currentRow.FindControl("RequiredFieldValidator4") as RequiredFieldValidator;
        RequiredFieldValidator rfvAmount = currentRow.FindControl("rfvAmount") as RequiredFieldValidator;

        if (chkAction.Checked)
        {
            rfvFileUpload.Enabled = true;
            rfvQuantity.Enabled = true;
            ProdDropDWN.Enabled = true;
            InvoiceValidator.Enabled = true;
            rfvWarrantydate.Enabled = true;
            rfc2.Enabled = true;
            RequiredFieldValidator4.Enabled = true;
            rfvAmount.Enabled = true;
        }
        else
        {
            rfvFileUpload.Enabled = false;
            rfvQuantity.Enabled = false;
            ProdDropDWN.Enabled = false;
            InvoiceValidator.Enabled = false;
            rfvWarrantydate.Enabled = false;
            rfc2.Enabled = false;
            RequiredFieldValidator4.Enabled = false;
            rfvAmount.Enabled = false;
        }
    }


    protected void btnSubmitLoanID_Click(object sender, EventArgs e)
    {
        //string BranchID = Session["UserCode"].ToString();
        //ds = ISS.usp_FinpageCustExistOrNot("null", txtLoanID.Text, "null", "null", BranchID);
        //if (ds.Tables[0].Rows.Count == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Not Exist!', 'No Data Has Been Found!' );", true);
        //    return;
        //}
        //else
        //{
        //    BindGrid();
        //}
        BindGrid();
    }


    protected void rbloptionCustID_CheckedChanged(object sender, EventArgs e)
    {

        CustID.Visible = true;
        LoanID.Visible = false;
        txtSearch.Text = "";
        gvIssue.Visible = false;
        txtLoanID.Text = "";
        GroupID.Visible = false;
        ddlGroup.SelectedValue = "0";
        CenterID.Visible = false;
        txtCenter.Text = "";
    }

    protected void rbloptionLoanID_CheckedChanged(object sender, EventArgs e)
    {
        CustID.Visible = false;
        LoanID.Visible = true;
        txtLoanID.Text = "";
        gvIssue.Visible = false;
        txtSearch.Text = "";
        GroupID.Visible = false;
        ddlGroup.SelectedValue = "0";
        CenterID.Visible = false;
        txtCenter.Text = "";
    }


    protected void gvIssue_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Find the DropDownList in the current row
            DropDownList prdctddl = (DropDownList)e.Row.FindControl("Productddl");

            if (prdctddl != null)
            {
                DataSet dsProducts = ISS.GetProductList(Session["UserCode"].ToString());

                // Bind the data to the DropDownList
                prdctddl.DataSource = dsProducts;
                prdctddl.DataTextField = "PM_Description1"; // Change "product" to your actual column name for display text
                prdctddl.DataValueField = "PM_ItemCode1"; // Change "PM_ItemCode1" to your actual column name for value
                prdctddl.DataBind();

                // Optionally, add a default "Select" item at the first position
                prdctddl.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
    }

    protected void rblGroupID_CheckedChanged(object sender, EventArgs e)
    {
        CustID.Visible = false;
        LoanID.Visible = false;
        txtSearch.Text = "";
        gvIssue.Visible = false;
        txtLoanID.Text = "";
        GroupID.Visible = true;
        ddlGroup.SelectedValue = "0";
        CenterID.Visible = false;
        txtCenter.Text = "";
    }

    protected void rblCenterID_CheckedChanged(object sender, EventArgs e)
    {
        CustID.Visible = false;
        LoanID.Visible = false;
        txtSearch.Text = "";
        gvIssue.Visible = false;
        txtLoanID.Text = "";
        GroupID.Visible = false;
        ddlGroup.SelectedValue = "0";
        CenterID.Visible = true;
        txtCenter.Text = "";
    }

    protected void btnGroupID_Click(object sender, EventArgs e)
    {
        string BranchID = Session["UserCode"].ToString();
        ds = ISS.usp_FinpageCustExistOrNot("null", "null", ddlGroup.SelectedValue, txtGrpCenter.Text, BranchID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Not Exist!', 'No Data Has Been Found!' );", true);
            return;
        }
        else
        {
            BindGrid();
        }
    }

    protected void btnCenterID_Click(object sender, EventArgs e)
    {
        string BranchID = Session["UserCode"].ToString();
        ds = ISS.usp_FinpageCustExistOrNot("null", "null", "null", txtCenter.Text, BranchID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Not Exist!', 'No Data Has Been Found!' );", true);
            return;
        }
        else
        {
            BindGrid();
        }
    }
}

