using DocumentFormat.OpenXml.Drawing.Charts;
using gsmClasses;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_ProductMaster : System.Web.UI.Page
{

    Inventory_System ISS = new Inventory_System();
    DataSet ds = new DataSet();
    Encryption ec = new Encryption();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindVendor();
            string ProductID = Request.QueryString["ProductID"];
            if (ProductID == null)
            {
                lnk_ImageDwnld.Visible = false;
                btnClear.Enabled = true;
                txtItemCode1.ReadOnly = false;
            }
            else
            {
                lblItemCode1.Text = ec.Decrypt(HttpUtility.UrlDecode(ProductID));
                ds = ISS.mmf_GetProductDataForModification(lblItemCode1.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtItemCode1.Text = ds.Tables[0].Rows[0]["PM_ItemCode2"].ToString();
                    txtItemCode2.Text = ds.Tables[0].Rows[0]["PM_ItemCode3"].ToString();
                    txtDescription1.Text = ds.Tables[0].Rows[0]["PM_Description1"].ToString();
                    txtDescription2.Text = ds.Tables[0].Rows[0]["PM_Description2"].ToString();
                    ddlProdctCategory.SelectedValue = ds.Tables[0].Rows[0]["PM_Category"].ToString();
                    txtBrand.Text = ds.Tables[0].Rows[0]["PM_Brand"].ToString();
                    txtMRPPrice.Text = ds.Tables[0].Rows[0]["PM_MRPPrice"].ToString();
                    ddlUnitOFMeasurement.SelectedValue = ds.Tables[0].Rows[0]["PM_UnitOfMeasurement"].ToString();
                    txtUnitPrice.Text = ds.Tables[0].Rows[0]["PM_UnitPrice"].ToString();
                    txtOther1.Text = ds.Tables[0].Rows[0]["PM_Other1"].ToString();
                    txtOther2.Text = ds.Tables[0].Rows[0]["PM_Other2"].ToString();
                    txtOther3.Text = ds.Tables[0].Rows[0]["PM_Other3"].ToString();
                    txtOther4.Text = ds.Tables[0].Rows[0]["PM_Other4"].ToString();
                    txtWarrantyDate.Text = ds.Tables[0].Rows[0]["PM_WarrantyExpiration"].ToString();
                    ddlVendor.SelectedValue = ds.Tables[0].Rows[0]["PM_VendorID"].ToString();
                    cbActive.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["PM_IsActive"].ToString());
                    ViewState["ProductImage"] = ds.Tables[0].Rows[0]["PM_Image"].ToString();
                    RequiredFieldValidator5.Enabled = false;
                    lnk_ImageDwnld.Visible = true;
                    btnClear.Enabled = false;
                    txtItemCode1.ReadOnly = true;

                }
            }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        cleardata();
    }

    protected void cleardata()
    {
        txtItemCode1.Text = "";
        txtItemCode2.Text = "";
        txtDescription1.Text = "";
        txtDescription2.Text = "";
        ddlProdctCategory.SelectedValue = "0";
        txtBrand.Text = "";
        txtMRPPrice.Text = "";
        ddlUnitOFMeasurement.SelectedValue = "0";
        txtUnitPrice.Text = "";
        txtOther1.Text = "";
        txtOther2.Text = "";
        txtOther3.Text = "";
        txtOther4.Text = "";
        ddlVendor.SelectedValue = "0";
        txtWarrantyDate.Text = "";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int PM_ItemCode1 = 0;
        if (lblItemCode1.Text == null || lblItemCode1.Text == "")
        {
            PM_ItemCode1 = 0;
        }
        else
        {
            PM_ItemCode1 = Convert.ToInt32(lblItemCode1.Text);
        }
           
        string PM_ItemCode2 = txtItemCode1.Text;
        string PM_ItemCode3 = txtItemCode2.Text;
        string PM_Description1 = txtDescription1.Text;
        string PM_Description2 = txtDescription2.Text;
        string PM_Category = ddlProdctCategory.SelectedValue;
        string PM_Brand = txtBrand.Text;
        string PM_UnitPrice = txtUnitPrice.Text;
        string PM_MRPPrice = txtMRPPrice.Text;
        string PM_UnitOfMeasurement = ddlUnitOFMeasurement.SelectedValue;
        string PM_Image = "";
        if (fupImage.HasFile)
        {
            PM_Image = Guid.NewGuid().ToString();
           // PM_Image = Path.GetFileName(fupImage.PostedFile.FileName);
            fupImage.SaveAs(Server.MapPath("~/Upload/ProductImage/" + PM_Image));
        }

        else
        {
            PM_Image = ViewState["ProductImage"].ToString();
        }

        string PM_Other1 = txtOther1.Text;
        string PM_Other2 = txtOther2.Text;
        string PM_Other3 = txtOther3.Text;
        string PM_Other4 = txtOther4.Text;
        string InsertUserAccountID = Session["UserName"].ToString();
        string ModifyUserAccountID = Session["UserName"].ToString();
        bool PM_IsActive = cbActive.Checked;
        string VendorID = ddlVendor.SelectedValue;
        DateTime WarrantyDate = Convert.ToDateTime(txtWarrantyDate.Text);

        ds = ISS.InsertProductMaster(PM_ItemCode1, PM_ItemCode2, PM_Description1, PM_Description2, PM_Category, PM_Brand, PM_UnitPrice, PM_MRPPrice, PM_UnitOfMeasurement,
            PM_Image, PM_Other1, PM_Other2, PM_Other3, PM_Other4, InsertUserAccountID, ModifyUserAccountID, PM_IsActive, VendorID, PM_ItemCode3, WarrantyDate);
        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Product has been saved!', 'success');", true);
        cleardata();
        Response.Redirect(string.Format("/List/ProductList.aspx"));
    }

    protected void lnk_ImageDwnld_Click(object sender, EventArgs e)
    {
        try
        {

            string index = ViewState["ProductImage"].ToString();
            if (index != "")
            {
                string FileName = Server.MapPath("~/Upload/ProductImage/" + index);
                string ClientFileName = index + ".jpg";
                gsmWeb2ClientUtils gwc = new gsmWeb2ClientUtils();
                gwc.FileDownload2Client(FileName, ClientFileName, false);
            }

        }
        catch (Exception ex)
        {
            ex.ToString();
            return;
        }
    }

    protected void txtItemCode1_TextChanged(object sender, EventArgs e)
    {
        string ProductID = txtItemCode1.Text;
        ds = ISS.usp_checkproductidexistornot(ProductID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Already Exist!', 'This Product already Exist, Kindly Try with new ID!', 'info');", true);
            txtItemCode1.Text = "";
            return;
        }
    }


    protected void BindVendor()
    {
        ds = ISS.VendorList();
        ddlVendor.DataSource = ds;
        ddlVendor.DataTextField = "VM_Name";
        ddlVendor.DataValueField = "VM_ID";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, new ListItem("Select", "0"));
    }
}