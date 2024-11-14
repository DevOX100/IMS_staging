using System;
using System.Data;
using System.Web.Security;
using System.Web;
using System.Web.UI;

public partial class ChangePassword : Page
{
    Billing_System bs = new Billing_System();
    DataSet ds = new DataSet();
    Encryption ec = new Encryption();
   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Session["RoleID"]) == 1)
            {
                AdminEmplCode.Visible = true;
                CurrentEmployee.Enabled = true;
                ChangeEmplCode.Visible = true;
                ChangeEmployee.Enabled = true;
                CurrentEmployee.Text = Session["UserCode"].ToString();
            }
            else
            {
                ChangeEmplCode.Visible = true;
                AdminEmplCode.Visible = false;
                ChangeEmployee.Enabled = false;
                ChangeEmployee.Text = Session["UserCode"].ToString();
            }
            
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

    protected void ChangePasswordButton_Click(object sender, EventArgs e)
    {
        string UserCode = ChangeEmployee.Text;
        string AccountPassword = NewPassword.Text;
        ds = bs.ChangePassword(UserCode, AccountPassword);

        if (Convert.ToInt32(Session["RoleID"]) == 1)
        {
            if (ChangeEmployee.Text == "10000")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Oopss!', 'Not Rights to change the Admin password!', 'warning');", true);
                //return;
            }
            else
            {
                UserCode = ChangeEmployee.Text;
                //mc.AccountPassword = ec.Encrypt(NewPassword.Text.Trim()).ToString();
                var Password = ConfirmNewPassword.Text.Trim();
                AccountPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(NewPassword.Text.Trim(), "SHA1").ToString();
                bs.ChangePassword(AccountPassword,UserCode);
                ChangeEmployee.Text = null;
                NewPassword.Text = null;
                CurrentPasswordRequired.Text = null;
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Password has been changed!', 'success');", true);
            }

        }
        else
        {
            UserCode = ChangeEmployee.Text;
            //  mc.AccountPassword = ec.Encrypt(NewPassword.Text.Trim()).ToString();
            AccountPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(NewPassword.Text.Trim(), "SHA1").ToString();
            var Password = ConfirmNewPassword.Text.Trim();
            bs.ChangePassword(AccountPassword,UserCode);
            ChangeEmployee.Text = null;
            NewPassword.Text = null;
            CurrentPasswordRequired.Text = null;
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Password has been changed!', 'success');", true);
            Session.Abandon();
            Session.Clear();
            Response.Cookies.Clear();
            CookiesClear();
            Cache.Remove("dataTable");
            Response.Redirect("/QuickBill/Account/Login.aspx");
        }

    }
    protected void CancelPushButton_Click(object sender, EventArgs e)
    {
        
        ChangeEmployee.Text = null;
        NewPassword.Text = null;
        CurrentPasswordRequired.Text = null;
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
}
