using gsmClasses;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using QiHe.CodeLib;
using DocumentFormat.OpenXml.Bibliography;
using System.Windows.Controls;
using CheckBox = System.Web.UI.WebControls.CheckBox;
using Label = System.Web.UI.WebControls.Label;
using TextBox = System.Web.UI.WebControls.TextBox;
using iTextSharp.text.pdf.codec;
using System.ComponentModel;


public partial class Inventory_DamagedProduct : System.Web.UI.Page
{
    Inventory_System ISS = new Inventory_System();
    DataSet ds = new DataSet();

    gsmFileFolders ff = new gsmFileFolders();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


        }

    }

    protected void BindGrid()
    {
        string IS_CustID = txtSearch.Text;
        string userCode = Session["UserCode"].ToString();

        DataSet ds = ISS.GetDamagedStock(IS_CustID);

        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Invalid!', 'Customer ID is wrong or no data found!');", true);
            return;
        }
        foreach (GridViewRow row in gvDamageproduct.Rows)
        {
            string creationDateText = ((Label)row.FindControl("lblcreationDate")).Text;
            string warrantyDateText = ((Label)row.FindControl("lblWarrantyDate")).Text;
            DateTime creationDate;
            DateTime warrantyDate;
            bool isCreationDateValid = DateTime.TryParse(creationDateText, out creationDate);
            bool isWarrantyDateValid = DateTime.TryParse(warrantyDateText, out warrantyDate);
            
            //if (!string.IsNullOrEmpty(creationDateText) && !string.IsNullOrEmpty(warrantyDateText))
            //{

            //    if (creationDate >= warrantyDate)
            //    {
            //        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Invalid!', 'Warranty of the product has expired for this customer');", true);
            //    }
               
            //}

        }
        gvDamageproduct.DataSource = ds;
        gvDamageproduct.DataBind();
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
        ScriptManager.RegisterStartupScript(this, GetType(), "hideLoading", "hideLoading();", true);
    }

    protected void gvDamageproduct_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlComplaintType = (DropDownList)e.Row.FindControl("ddlComplaintType");
            DropDownList ddlProductType = (DropDownList)e.Row.FindControl("ddlProductType");
            DropDownList ddlProductName = (DropDownList)e.Row.FindControl("ddlProductName");

            Label productID = (Label)e.Row.FindControl("lblProductID");
            Label lblproductType = (Label)e.Row.FindControl("lblproductType");
            Label lblProductname = (Label)e.Row.FindControl("lblProName");


            if (string.IsNullOrEmpty(productID.Text))
            {
                lblproductType.Visible = false;
                lblProductname.Visible = false;

                ddlProductName.Visible = true;
                ddlProductType.Visible = true;
                if (ddlProductType != null)
                {
                    ddlProductType.SelectedIndexChanged -= ddlProductType_SelectedIndexChanged;
                    ddlProductType.SelectedIndexChanged += ddlProductType_SelectedIndexChanged;

                    DataSet dsProductType = ISS.DamageProductType();
                    ddlProductType.DataSource = dsProductType;
                    ddlProductType.DataTextField = "Pc_Product_Type";
                    ddlProductType.DataValueField = "Pc_Product_Type";
                    ddlProductType.DataBind();
                    ddlProductType.Items.Insert(0, new ListItem("Select", "0"));
                }

                if (ddlProductName != null)
                {
                    ddlProductName.SelectedIndexChanged -= ddlProductName_SelectedIndexChanged;
                    ddlProductName.SelectedIndexChanged += ddlProductName_SelectedIndexChanged;
                    ddlProductName.Items.Clear();
                    ddlProductName.Items.Insert(0, new ListItem("Select", "0"));
                }

                if (ddlComplaintType != null)
                {
                    ddlComplaintType.Items.Clear();
                    ddlComplaintType.Items.Insert(0, new ListItem("Select", "0"));
                }
                if (ddlComplaintType != null && ddlProductType != null)
                {

                    string productType = ddlProductType.SelectedValue;
                    string productName = ddlProductName.SelectedValue;

                    DataSet ds = ISS.ProductComplaintType(productType, productName);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        ddlComplaintType.DataSource = ds.Tables[0];
                        ddlComplaintType.DataTextField = "PC_ComplaintTypes";
                        ddlComplaintType.DataValueField = "PC_ComplaintTypes";
                        ddlComplaintType.DataBind();
                        ddlComplaintType.Items.Insert(0, new ListItem("Select", "0"));
                    }
                }
            }
            else
            {
                lblproductType.Visible = true;
                lblProductname.Visible = true;
                ddlProductName.Visible = false;
                ddlProductType.Visible = false;

                if (ddlComplaintType != null && !string.IsNullOrEmpty(productID.Text))
                {
                    string ProID = productID.Text;
                    DataSet dsComplaint = ISS.ComplaintBindAsPerProduct(ProID);

                    if (dsComplaint != null && dsComplaint.Tables.Count > 0)
                    {
                        ddlComplaintType.DataSource = dsComplaint.Tables[0];
                        ddlComplaintType.DataTextField = "PC_ComplaintTypes";
                        ddlComplaintType.DataValueField = "PM_ItemCode1";
                        ddlComplaintType.DataBind();
                        ddlComplaintType.Items.Insert(0, new ListItem("Select", "0"));
                    }
                }
            }
        }
    }


    protected void ddlProductType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlProductType = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlProductType.NamingContainer;
        DropDownList ddlProductName = (DropDownList)row.FindControl("ddlProductName");

        if (ddlProductName != null)
        {
            string productType = ddlProductType.SelectedValue;
            DataSet ds = ISS.DamageProductName(productType);

            if (ds != null && ds.Tables.Count > 0)
            {
                ddlProductName.DataSource = ds.Tables[0];
                ddlProductName.DataTextField = "PC_Product_Name";
                ddlProductName.DataValueField = "PC_ProductID";
                ddlProductName.DataBind();
                ddlProductName.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
    }

    protected void ddlProductName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlProductName = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlProductName.NamingContainer;
        DropDownList ddlComplaintType = (DropDownList)row.FindControl("ddlComplaintType");
        DropDownList ddlProductType = (DropDownList)row.FindControl("ddlProductType");
        Label product = (Label)row.FindControl("lblProductID");

        if (product != null)
        {
            string ProductId = ((Label)row.FindControl("lblProductID")).Text;
            DataSet ds = ISS.ComplaintBindAsPerProduct(ProductId);



            if (ds != null && ds.Tables.Count > 0)
            {
                ddlComplaintType.DataSource = ds.Tables[0];
                ddlComplaintType.DataTextField = "PC_ComplaintTypes";
                ddlComplaintType.DataValueField = "PM_ItemCode1";
                ddlComplaintType.DataBind();
                ddlComplaintType.Items.Insert(0, new ListItem("Select", "0"));
            }
        }


        if (ddlComplaintType != null && ddlProductType != null)
        {
            string productType = ddlProductType.SelectedValue;
            string productName = ddlProductName.SelectedValue;

            DataSet ds = ISS.ProductComplaintType(productType, productName);
            if (ds != null && ds.Tables.Count > 0)
            {
                ddlComplaintType.DataSource = ds.Tables[0];
                ddlComplaintType.DataTextField = "PC_ComplaintTypes";
                ddlComplaintType.DataValueField = "PC_ComplaintTypes";
                ddlComplaintType.DataBind();
                ddlComplaintType.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
    }
    protected void gvDamageproduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Submit")
        {
            int chkCount = 0;
            for (int i = 0; i < gvDamageproduct.Rows.Count; i++)
            {
                CheckBox chkAction = (CheckBox)gvDamageproduct.Rows[i].FindControl("chkAction");


                if (chkAction != null && chkAction.Checked)
                {
                    chkCount++;


                    string validationGroup = "ABC" + i;
                    Page.Validate(validationGroup);


                    if (!Page.IsValid)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert",
                            "swal('Validation Failed!', 'Please fill all required fields.', 'error');", true);
                        return;
                    }
                }
            }

            if (chkCount == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('No One Checked!', 'Please choose at least one!', 'error');", true);
                return;
            }
            else
            {
                for (int i = 0; i < gvDamageproduct.Rows.Count; i++)
                {
                    if (((CheckBox)gvDamageproduct.Rows[i].FindControl("chkAction")).Checked)
                    {
                        try
                        {

                            DropDownList ddlComplaintType = (DropDownList)gvDamageproduct.Rows[i].FindControl("ddlComplaintType");
                            DropDownList ddlProductType = (DropDownList)gvDamageproduct.Rows[i].FindControl("ddlProductType");
                            DropDownList ddlProductName = (DropDownList)gvDamageproduct.Rows[i].FindControl("ddlProductName");
                            DropDownList ddlStockCheck = (DropDownList)gvDamageproduct.Rows[i].FindControl("ddlStockCheck");
                            Label product = (Label)gvDamageproduct.Rows[i].FindControl("lblProduct");
                            Label productID = (Label)gvDamageproduct.Rows[i].FindControl("lblProductID");
                            Label ProductType = (Label)gvDamageproduct.Rows[i].FindControl("lblproductType");
                            string complaint = ddlComplaintType.SelectedItem.Text;
                            string ProdID = ddlProductName.SelectedValue;



                            CheckBox Approve = (CheckBox)gvDamageproduct.Rows[i].FindControl("chkAction");
                            string ID = gvDamageproduct.DataKeys[i]["IS_CustID"].ToString();
                            Label loanID = (Label)gvDamageproduct.Rows[i].FindControl("lblLoanID");

                            Label IS_Name = (Label)gvDamageproduct.Rows[i].FindControl("lblFirstName");
                            Label IS_Branch = (Label)gvDamageproduct.Rows[i].FindControl("lblBranchID");
                            Label IS_SpouseName = (Label)gvDamageproduct.Rows[i].FindControl("lblSpouseNAme");
                            Label IS_MobileNO = (Label)gvDamageproduct.Rows[i].FindControl("lblMobileNO");
                            Label Is_CustID = (Label)gvDamageproduct.Rows[i].FindControl("lblCustID");
                            TextBox DamagedQty = (TextBox)gvDamageproduct.Rows[i].FindControl("txtGQuantity");
                            string DamageApprovedBY = Session["UserCode"].ToString();
                            int RequestQty = Convert.ToInt32(DamagedQty.Text);
                            FileUpload fupImage = (FileUpload)gvDamageproduct.Rows[i].FindControl("fupid");
                            string LoanID = loanID.Text;
                            string DamagedImage = " ";
                            string name = IS_Name.Text;
                            string branch = IS_Branch.Text;
                            string spouseName = IS_SpouseName.Text;
                            string CustID = Is_CustID.Text;
                            string mobile = IS_MobileNO.Text;
                            string creationDateText = ((Label)gvDamageproduct.Rows[i].FindControl("lblcreationDate")).Text;
                            string warrantyDateText = ((Label)gvDamageproduct.Rows[i].FindControl("lblWarrantyDate")).Text;
                            DateTime creationDate;
                            DateTime warrantyDate;
                            if (fupImage.HasFile)
                            {
                                if (ff.GetFileSizeWithExtention(fupImage.FileName, Convert.ToDouble(fupImage.FileBytes.LongLength), 1048576, "jpg"))
                                {
                                    if (fupImage.FileBytes.LongLength <= 1048576)
                                    {
                                        string Exten = "." + ff.GetFileExtention(fupImage.FileName);
                                        Guid obj = Guid.NewGuid();
                                        DamagedImage = obj.ToString();
                                        fupImage.SaveAs(Server.MapPath("~\\Upload\\DamagedProduct\\" + DamagedImage + ".jpg"));
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Limit Exceed!', 'Please Upload Less than or Equal to 1 MB!', 'info');", true);
                                        return;
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Only JPG Format!', 'Please Upload only in JPG format!', 'info');", true);
                                    return;
                                }
                            }
                            string brnachAvailable = ddlStockCheck.SelectedItem.Text;
                            bool isCreationDateValid = DateTime.TryParse(creationDateText, out creationDate);
                            bool isWarrantyDateValid = DateTime.TryParse(warrantyDateText, out warrantyDate);
                            string productType1 = ddlProductType.SelectedValue;
                            string productType;
                            string productName;
                            if (ddlProductName.SelectedItem == null || ddlProductName.SelectedValue == "0")
                            {
                                Label proName = (Label)gvDamageproduct.Rows[i].FindControl("lblProName");
                                productName = proName.Text;
                            }
                            else
                            {
                                productName = ddlProductName.SelectedItem.Text;
                            }
                            if (string.IsNullOrEmpty(productType1))
                            {
                                productType = ProductType.Text;

                            }
                            else
                            {
                                productType = ddlProductType.SelectedItem.Text;
                            }
                            //if (isCreationDateValid && isWarrantyDateValid)
                            //{

                            //    bool isConditionMet = creationDate <= warrantyDate;

                            //    if (isConditionMet)
                            //    {

                                    ISS.insertDamageStock(DamageApprovedBY, RequestQty, complaint, productType, productName, DamagedImage, LoanID
                                    , name, branch, spouseName, mobile, CustID, ProdID, brnachAvailable);
                                    ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Damaged product details have been saved!', 'success');", true);
                                    BindGrid();
                                //}
                                //else
                                //{
                                //    DamagedQty.Enabled = false;

                                //    BindGrid();
                                //    ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Invalid!', 'Warranty of the Poduct has expired! for this customer' );", true);

                                //}


                            //}
                            //else
                            //{

                            //    ISS.insertDamageStock(DamageApprovedBY, RequestQty, complaint, productType, productName, DamagedImage, LoanID
                            //    , name, branch, spouseName, mobile, CustID, ProdID, brnachAvailable);
                            //    ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Damaged product details have been saved!', 'success');", true);
                            //    BindGrid();
                            //}


                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", string.Format("swal('Invalid!', 'Customer ID {ID} is already given the damaged stock!');", ID), true);
                        }
                    }
                }
            }

        }
    }

    protected void chkAction_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAction = sender as CheckBox;
        GridViewRow currentRow = chkAction.NamingContainer as GridViewRow;
        RequiredFieldValidator Quantity = currentRow.FindControl("rfvQuantity") as RequiredFieldValidator;
        RequiredFieldValidator ProductType = currentRow.FindControl("rfvProductType") as RequiredFieldValidator;
        RequiredFieldValidator rfvFileupload = currentRow.FindControl("rfvFileupload") as RequiredFieldValidator;
        RequiredFieldValidator ProductName = currentRow.FindControl("rfvProductName") as RequiredFieldValidator;
        RequiredFieldValidator ComplaintType = currentRow.FindControl("rfvComplaintType") as RequiredFieldValidator;
        RequiredFieldValidator CheckStatus = currentRow.FindControl("rfvCheckStatus") as RequiredFieldValidator;

        if (chkAction.Checked && chkAction.Checked == true)
        {
            Quantity.Enabled = true;
            ProductType.Enabled = true;
            rfvFileupload.Enabled = true;
            ProductName.Enabled = true;
            ComplaintType.Enabled = true;
            CheckStatus.Enabled = true;
        }
        else
        {
            Quantity.Enabled = false;
            ProductType.Enabled = false;
            rfvFileupload.Enabled = false;
            ProductName.Enabled = false;
            ComplaintType.Enabled = false;
            CheckStatus.Enabled = false;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string POD = " ";
        // Find the FileUpload control directly by its ID
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
                    fupImage.SaveAs(Server.MapPath("~\\Upload\\ProductImage\\" + POD + ".pdf"));
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
    }
}