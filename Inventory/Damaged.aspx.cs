using gsmClasses;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using gsmClasses;
using QiHe.CodeLib;
using DocumentFormat.OpenXml.Bibliography;
using System.Windows.Controls;
using System.Net;
using System.IO;

public partial class Inventory_Damaged : System.Web.UI.Page
{
    Inventory_System ISS = new Inventory_System();
    DataSet ds = new DataSet();
    Encryption ec = new Encryption();
    gsmFileFolders ff = new gsmFileFolders();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
            BindProductType();
            BindRegion();
            BindBranch();
            if (Session["loginType"].ToString() == "B")
            {
                ddlRegion.Visible = false;
                lblRegion.Visible = false;
                ddlBranch.Visible = false;
                lblBranch.Visible = false;
            }
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
    public void BindGrid()
    {
        string UserCode = Session["UserCode"].ToString();
        ds = ISS.DamageProductsGrid(UserCode);
        gvDamaged.DataSource = ds;
        gvDamaged.DataBind();


    }
    protected void BindProductType()
    {
        DataSet ds = ISS.DamageProductType();
        if (ds != null && ds.Tables.Count > 0)
        {
            ddlProductType.DataSource = ds.Tables[0];
            ddlProductType.DataTextField = "Pc_Product_Type";
            ddlProductType.DataValueField = "Pc_Product_Type";
            ddlProductType.DataBind();
            ddlProductType.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    protected void BindProductName()
    {
        string ProductType = ddlProductType.SelectedValue;
        DataSet ds = ISS.adjustProductName(ProductType);
        if (ds != null && ds.Tables.Count > 0)
        {
            ddlProductName.DataSource = ds.Tables[0];
            ddlProductName.DataTextField = "PC_Product_Name";
            ddlProductName.DataValueField = "PC_ProductID";
            ddlProductName.DataBind();
            ddlProductName.Items.Insert(0, new ListItem("Select", "0"));
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string productType = ddlProductType.SelectedValue;
        string productName = ddlProductName.SelectedItem.Text;
        string productComplaint = ddlComplaintType.SelectedItem.Text;
        int quantity = Convert.ToInt32(txtQuantity.Text);
        string DP_Region = ddlRegion.SelectedValue;
        string DP_Branch = ddlBranch.SelectedValue;
        string DP_Remarks = txtRemarks.Text;
        string DamagedImage = " ";
        string productID = ddlProductName.SelectedValue;
        int product_ID = Convert.ToInt32(productID);

        if (fupImage.HasFile)
        {
            if (ff.GetFileSizeWithExtention(fupImage.FileName, Convert.ToDouble(fupImage.FileBytes.LongLength), 1048576, "jpg"))
            {
                if (fupImage.FileBytes.LongLength <= 1048576)
                {
                    string Exten;
                    Exten = "." + ff.GetFileExtention(fupImage.FileName);
                    Guid obj = Guid.NewGuid();
                    DamagedImage = obj.ToString();
                    fupImage.SaveAs(Server.MapPath("~\\Upload\\DamagedProduct\\" + DamagedImage + ".jpg"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Limit Exceed!', 'Please Upload Less than or Equal to 1 MB!', 'info');", true);
                    return;
                }
            }

            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Only PDF Format!', 'Please Upload  only in JPG!', 'info');", true);
                return;
            }

        }

        try
        {

            ds = ISS.DamageProducts(productType, productName, productComplaint, quantity, DamagedImage, DP_Branch, DP_Region, DP_Remarks, product_ID);
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Damaged product details has been saved!', 'success');", true);
            clearData();
            BindGrid();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Invalid!', '" + ex.Message.Replace("'", "\\'") + "', 'error');", true);
        }

    }
    protected void clearData()
    {
        ddlProductType.SelectedIndex = 0;
        ddlProductName.SelectedIndex = 0;
        ddlComplaintType.SelectedIndex = 0;
        txtQuantity.Text = string.Empty;
        txtRemarks.Text = string.Empty;
        ddlRegion.SelectedIndex = 0;
        ddlBranch.SelectedIndex = 0;

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clearData();
    }


    protected void ddlProductType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindProductName();
    }
    protected void btnClosed_Click(object sender, EventArgs e)
    {
        Div_View_Image.Visible = false;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "open_Invoice", "setTimeout(function () {OpenNewPopUp('0','Div_View_Image')}, 300);", true);
    }
    protected void gvDamaged_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VIEWDamagedImage")
        {
            string index = e.CommandArgument.ToString();
            if (!string.IsNullOrEmpty(index))
            {
                string filePath = Server.MapPath("~/Upload/DamagedProduct/" + index + ".jpg");


                if (File.Exists(filePath))
                {
                    var webClient = new WebClient();
                    byte[] jpgBytes = webClient.DownloadData(filePath);


                    string embed = "<object data=\"data:image/jpeg;base64, {0}\" type=\"image/jpeg\" width=\"100%\" height=\"500px\">";
                    embed += "<embed src=\"data:image/jpeg;base64, {0}\" type=\"image/jpeg\" />";
                    embed += "</object>";

                    lvImage.Text = string.Format(embed, Convert.ToBase64String(jpgBytes));
                    Div_View_Image.Visible = true;


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "open_Image", "setTimeout(function () {OpenNewPopUp('1','Div_View_Image')}, 300);", true);
                }
                else
                {

                    lvImage.Text = "Image file not found.";
                    Div_View_Image.Visible = true;
                }
            }
        }

    }

    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBranch();
    }
}