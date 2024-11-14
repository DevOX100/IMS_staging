using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Security;

public partial class Account_Login : System.Web.UI.Page
{
    Billing_System bs = new Billing_System();
    DataSet ds = new DataSet();
    Encryption ec = new Encryption();
    OTP otp = new OTP();
    TrackIP tip = new TrackIP();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CookiesClear();
            txtUserName.Focus();
        }
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

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        string UserName = txtUserName.Text;
        string Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "SHA1").ToString();
        //string Password = txtPassword.Text;
        ds = bs.GetLoginDetails(UserName, Password);

        if (ds.Tables[0].Rows.Count > 0)
        {
            string x = (ds.Tables[0].Rows[0]["UserCode"]).ToString();
            string EmpName = (ds.Tables[0].Rows[0]["UserName"]).ToString();
            string BranchID = (ds.Tables[0].Rows[0]["Bcode"]).ToString();
            string RegionCode = (ds.Tables[0].Rows[0]["RCode"]).ToString();
            string loginType = (ds.Tables[0].Rows[0]["loginType"]).ToString();
            int RoleID = Convert.ToInt32((ds.Tables[0].Rows[0]["RoleID"]).ToString());
            int DepID = Convert.ToInt32((ds.Tables[0].Rows[0]["DepID"]).ToString());
            string RegionID = (ds.Tables[0].Rows[0]["R_Name"]).ToString();
            Session["UserCode"] = x.ToString();
            Session["UserName"] = EmpName;
            Session["BranchID"] = BranchID;
            Session["RoleID"] = RoleID;
            Session["RCode"] = RegionCode;
            Session["DepID"] = DepID;
            Session["loginType"] = loginType;
            Session["RegionID"] = RegionID;
            HttpBrowserCapabilities capability = Request.Browser;
            string BrowserName = capability.Browser + capability.Version + "/" + capability.Platform;
            string IP = tip.GetIp();
            string MACIP = tip.GetMacAddress();

            if (RoleID == 3)
            {
                bs.InsertLoginData(IP, BrowserName, EmpName, x.ToString(), MACIP);
                Response.Redirect("~/Account/Home.aspx");
            }
           else
            {
                bs.InsertLoginData(IP, BrowserName, EmpName, x.ToString(), MACIP);
                Response.Redirect("~/Account/Home.aspx");
            }

        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Invalid Credentials, Kindly Check.', 'error');", true);
        }
    }



}
