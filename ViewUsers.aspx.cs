using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewUsers : System.Web.UI.Page
{
    Inventory_System ISS = new Inventory_System();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
        
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Context.Session != null)
        {
            if (Session.IsNewSession)
            {
                HttpCookie newSessionIdCookie = Request.Cookies["ASP.NET_SessionId"];
                if (newSessionIdCookie != null)
                {
                    string newSessionIdCookieValue = newSessionIdCookie.Value;
                    if (newSessionIdCookieValue != string.Empty)
                    {
                        // This means Session was timed Out and New Session was started
                        Response.Redirect("../Account/Login.aspx");
                    }
                }
            }
        }
    }

    protected void BindGrid()
    {
        gvUsers.DataSource = ISS.SelectUserDetails();
        gvUsers.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string UserCode = txtUCode.Text;
        gvUsers.DataSource = ISS.SelectUserDetailsbyUserCode(UserCode);
        gvUsers.DataBind();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        cleardata();
        BindGrid();
    }

    private void cleardata()
    {
        txtUCode.Text = "";
    }

    protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ChangeStatus")
        {
            string UserAccountID = e.CommandArgument.ToString();
            ISS.ModifyUserDetails(UserAccountID);
            BindGrid();
        }
    }
}