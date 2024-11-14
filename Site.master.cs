using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Security;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    DataSet ds = new DataSet();
    Billing_System BS = new Billing_System();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            if (Session["UserCode"] == null)
            {
                Response.Redirect("/");

            }

            if ((Session["UserCode"] == null))
            {

                LinkButton1.Text = "Login";

            }
            else
            {

                int roleName = Convert.ToInt32(Session["RoleID"]);
                string UserName = Session["UserName"].ToString();
                string UserCode = Session["UserCode"].ToString();
                int ID = Convert.ToInt32(Session["EmployeeID"]);
                //    ds = BS.GetBranchByID(Convert.ToInt32(Session["BranchID"]));
                DataSet ds1 = BS.LastLoginDate(UserCode);
                //    string BranchName = ds.Tables[0].Rows[0]["BranchName"].ToString();
                string LastLoginDate = ds1.Tables[0].Rows[0]["InsertDate"].ToString();
                Label1.Text = "WELCOME" + "  :          " + UserName + " (" + UserCode + ")";
                //  Label2.Text = BranchName.ToUpper();
                //Label2.Font.Bold = true;
                Label3.Text = "Last Login : " + LastLoginDate;
                Label2.Font.Italic = true;
                Label2.ForeColor = System.Drawing.Color.White;
                Label1.Font.Bold = true;
                Label1.Font.Italic = true;
                LinkButton1.Text = "LogOut";

                if (Session["dataTable"] == null)
                {
                    Session["dataTable"] = BS.SelectMenu(roleName, UserCode).Tables[0];
                    DataTable table = new DataTable();
                    table = (DataTable)Session["dataTable"];
                    GetMenuData(table);
                }
                else
                {
                    DataTable table = new DataTable();
                    table = (DataTable)Session["dataTable"];
                    GetMenuData(table);
                }
            }
        }

    }
public string GetIP()
    {
        string VisitorsIPAddr = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (VisitorsIPAddr != null || VisitorsIPAddr != String.Empty)
        {
            VisitorsIPAddr = Request.ServerVariables["REMOTE_ADDR"];
        }
        return VisitorsIPAddr;

    }
    private void CookiesClear()
    {
        try
        {

            Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
            Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now;
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            Session.RemoveAll(); Session.Abandon();
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", Guid.NewGuid().ToString()));
        }
        catch { }
    }
    private void AddChildItems(DataTable table, MenuItem menuItem)
    {
        DataView viewItem = new DataView(table);
        viewItem.RowFilter = "MenuParentID=" + menuItem.Value;
        foreach (DataRowView childView in viewItem)
        {
            MenuItem childItem = new MenuItem(childView["MenuName"].ToString(), childView["MenuID"].ToString());
            childItem.NavigateUrl = childView["MenuUrl"].ToString();
            menuItem.ChildItems.Add(childItem);
            AddChildItems(table, childItem);
        }
    }

    private void GetMenuData(DataTable table)
    {

        DataView view = new DataView(table);
        view.RowFilter = "MenuParentID is NULL";
        foreach (DataRowView row in view)
        {
            MenuItem menuItem = new MenuItem(row["MenuName"].ToString(), row["MenuID"].ToString());
            menuItem.NavigateUrl = row["MenuUrl"].ToString();
            if (menuItem.NavigateUrl == "" || menuItem.NavigateUrl == "#")
            {
            menuItem.Selectable = false;}
            menuBar.Items.Add(menuItem);
            AddChildItems(table, menuItem);
        }
    }
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (LinkButton1.Text == "LogIn")
        {
             Response.Redirect("/");
        }
        else
        {
            Session.Abandon();
            Session.Clear();
            Response.Cookies.Clear();
            CookiesClear();
            Cache.Remove("dataTable");
            Response.Redirect("~/Account/Login.aspx");
           // Response.Redirect("/");
        }
    }

   
}