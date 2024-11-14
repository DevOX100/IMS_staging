using iTextSharp.text.pdf.codec;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_supplierMaster : System.Web.UI.Page
{

    DataSet ds = new DataSet();
    Inventory_System ISS = new Inventory_System();
    Encryption ec = new Encryption();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string VendorID = Request.QueryString["VendorID"];

            if (VendorID == null)
            {
                btnClear.Enabled = true;
                txtVCode.ReadOnly = false;
                cbActive.Checked = true;
            }
            else
            {
                txtVCode.Text = ec.Decrypt(HttpUtility.UrlDecode(VendorID));
                ds = ISS.mmf_GetVendorDataForModification(Convert.ToInt32(txtVCode.Text));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtVCode.Text = ds.Tables[0].Rows[0]["VM_VendorCode"].ToString();
                    txtVName.Text = ds.Tables[0].Rows[0]["VM_Name"].ToString();
                    txtAddress1.Text = ds.Tables[0].Rows[0]["VM_Address1"].ToString();
                    txtAdd2.Text = ds.Tables[0].Rows[0]["VM_Address2"].ToString();
                    txtPincode.Text = ds.Tables[0].Rows[0]["VM_Pincode"].ToString();
                    txtCity.Text = ds.Tables[0].Rows[0]["VM_City"].ToString();
                    txtState.Text = ds.Tables[0].Rows[0]["VM_State"].ToString();
                    txtCountry.Text = ds.Tables[0].Rows[0]["VM_Country"].ToString();
                    txtPhone.Text = ds.Tables[0].Rows[0]["VM_Phone"].ToString();
                    txtEMail.Text = ds.Tables[0].Rows[0]["VM_Email"].ToString();
                    txtPAN.Text = ds.Tables[0].Rows[0]["VM_PAN"].ToString();
                    txtGST.Text = ds.Tables[0].Rows[0]["VM_GST"].ToString();
                    txtOther1.Text = ds.Tables[0].Rows[0]["VM_Other1"].ToString();
                    txtOther2.Text = ds.Tables[0].Rows[0]["VM_Other2"].ToString();
                    txtOther3.Text = ds.Tables[0].Rows[0]["VM_Other3"].ToString();
                    txtOther4.Text = ds.Tables[0].Rows[0]["VM_Other4"].ToString();
                    cbActive.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["VM_IsActive"].ToString());
                    btnClear.Enabled = false;
                    txtVCode.ReadOnly = true;
                }
            }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Cleardata();
    }

    protected void Cleardata()
    {
        txtVCode.Text = string.Empty;
        txtVName.Text = string.Empty;
        txtAddress1.Text = string.Empty;
        txtAdd2.Text = string.Empty;
        txtPincode.Text = string.Empty;
        txtCity.Text = string.Empty;
        txtCountry.Text = string.Empty;
        txtState.Text = string.Empty;
        txtPhone.Text = string.Empty;
        txtEMail.Text = string.Empty;
        txtPAN.Text = string.Empty;
        txtGST.Text = string.Empty;
        txtOther1.Text = string.Empty;
        txtOther2.Text = string.Empty;
        txtOther3.Text = string.Empty;
        txtOther4.Text = string.Empty;
        cbActive.Checked = false;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string VM_Name = txtVName.Text;
        string VM_Address1 = txtAddress1.Text;
        string VM_Address2 = txtAdd2.Text;
        string VM_Pincode = txtPincode.Text;
        string VM_City = txtCity.Text;
        string VM_State = txtState.Text;
        string VM_Country = txtCountry.Text;
        string VM_Phone = txtPhone.Text;
        string VM_Email = txtEMail.Text;
        string VM_PAN = txtPAN.Text;
        string VM_GST = txtGST.Text;
        string VM_Other1 = txtOther1.Text;
        string VM_Other2 = txtOther2.Text;
        string VM_Other3 = txtOther3.Text;
        string VM_Other4 = txtOther4.Text;
        string InsertBy = Session["UserName"].ToString();
        string ModifyUserAccountID = Session["UserName"].ToString();
        bool VM_IsActive = Convert.ToBoolean(cbActive.Checked);
        int VM_VendorCode = Convert.ToInt32(txtVCode.Text);



        ds = ISS.InsertVendorData(VM_Name, VM_Address1, VM_Address2, VM_Pincode, VM_City, VM_State, VM_Country, VM_Phone, VM_Email, VM_PAN, VM_GST, VM_Other1, VM_Other2,
            VM_Other3, VM_Other4, InsertBy, ModifyUserAccountID, VM_IsActive, VM_VendorCode);
        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Vendor has been saved!', 'success');", true);
        Cleardata();
        Response.Redirect(string.Format("/List/SupplierList.aspx"));
    }
}