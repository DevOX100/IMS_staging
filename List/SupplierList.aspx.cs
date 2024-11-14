using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class List_SupplierList : System.Web.UI.Page
{

    Inventory_System ISS = new Inventory_System();
    Encryption ec = new Encryption();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    protected void BindGrid()
    {
        gvVendor.DataSource = ISS.GetVendorList();
        gvVendor.DataBind();
    }

    protected void gvVendor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditData")
        {
            string VendorID = e.CommandArgument.ToString();
            Response.Redirect(string.Format("/Master/supplierMaster.aspx?VendorID={0}", HttpUtility.UrlEncode(ec.Encrypt(VendorID))));
        }
    }
}