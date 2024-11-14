using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class List_ProductList : System.Web.UI.Page
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
         gvProduct.DataSource = ISS.GetProductList(Session["UserCode"].ToString());
 gvProduct.DataBind();
    }
    protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditData")
        {
            string ProductID = e.CommandArgument.ToString();
            Response.Redirect(string.Format("/Master/ProductMaster.aspx?ProductID={0}",HttpUtility.UrlEncode(ec.Encrypt(ProductID))));
        }
    }
}