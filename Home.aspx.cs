using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    Kit kt = new Kit();
    Billing_System bs = new Billing_System();
    DataSet ds = new DataSet();
    Encryption ec = new Encryption();
    OTP otp = new OTP();
    Billing_System newUser = new Billing_System();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Session["UserEmployeeID"]) == 77777)
            {
                ddlRoleID.DataSource = bs.SelectRoleForAdmin();
            }
            else
            {
                ddlRoleID.DataSource = bs.SelectRole();
            }

            ddlRoleID.DataSource = bs.SelectRole();
            ddlRoleID.DataTextField = "RoleName";
            ddlRoleID.DataValueField = "RoleID";
            ddlRoleID.DataBind();
            ddlRoleID.Items.Insert(0, new ListItem("Select Role", "0"));
            BindRegion();
            BindDepartment();
        }

}
    protected void CreateUserButton_Click(object sender, EventArgs e)
    {
        string UserName = txtUserName.Text;
        string UserCode = txtEmpCode.Text;
        string Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "SHA1").ToString();
        string BCode = ddlBranch.SelectedValue;
        int RoleID = Convert.ToInt32(ddlRoleID.SelectedValue);
        string Email = txtEmail.Text;
        string Mobile = txtMobile.Text;
        string RCode = ddlRegion.SelectedValue;
        int Dpmt = Convert.ToInt32(ddlDepartment.SelectedValue);
        ds = newUser.CreateUserLogin(UserName, UserCode, Password, BCode, RoleID, Email, Mobile, RCode,Dpmt);
       // otp.SendEmailCredential(txtEmail.Text, txtEmpCode.Text, txtPassword.Text);

        cleardata();
        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);

    }

    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/Account/Login.aspx");
    //}
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

    protected void Reset_Click(object sender, EventArgs e)
    {
        cleardata();
    }
    private void cleardata()
    {
        txtEmpCode.Text = "";
        txtUserName.Text = "";
        txtMobile.Text = "";
        txtEmail.Text = "";
        txtPassword.Text = "";
        txtConfirmPassword.Text = "";
        ddlRoleID.SelectedValue = "0";
        ddlBranch.SelectedIndex = 0;
        ddlRegion.SelectedIndex = 0;
        ddlDepartment.SelectedValue = "0";
    }

    protected void txtEmpCode_TextChanged(object sender, EventArgs e)
    {
        bs.UserCode = txtEmpCode.Text.Trim();
        ds = bs.SelectUniqueUser();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Oops!', 'Employee Code Already Exists!', 'error');", true);
            txtUserName.Enabled = false;
            txtMobile.Enabled = false;
            txtEmail.Enabled = false;
            txtEmpCode.Text = null;
            return;
        }
        else
        {
            txtUserName.Enabled = true; txtUserName.Focus();
            txtMobile.Enabled = true;
            txtEmail.Enabled = true;
        }
    }

    protected void txtMobile_TextChanged(object sender, EventArgs e)
    {
        string Mobile = txtMobile.Text.Trim();
        ds = bs.CheckExistingMobileData(Mobile);
        if (ds.Tables[0].Rows.Count > 0)
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Oops!', 'Mobile Number Already Exists!', 'error');", true);
            txtEmail.Enabled = false;
            txtMobile.Text = null;
            return;
        }
        else
        {
            txtEmail.Enabled = true; txtEmail.Focus();

        }
    }

    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {
        string Email = txtEmail.Text.Trim();
        ds = bs.CheckExistingEmailData(Email);
        if (ds.Tables[0].Rows.Count > 0)
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Oops!', 'Email ID Already Exists!', 'error');", true);
            txtEmail.Text = null;
            return;
        }
        else
        {
            txtEmail.Enabled = true;
        }
    }

    protected void BindRegion()
    {
        ds = bs.GetRegionDetails();
        ddlRegion.DataSource = ds;
        ddlRegion.DataTextField = "R_Name";
        ddlRegion.DataValueField = "R_Code";
        ddlRegion.DataBind();
        ddlRegion.Items.Insert(0, new ListItem("Select Region", "0"));
    }

    protected void BindBranch()
    {
        string RCode = ddlRegion.SelectedValue;
        ds = bs.GetBranchDetailsbyRCode(RCode);
        ddlBranch.DataSource = ds;
        ddlBranch.DataTextField = "BranchName";
        ddlBranch.DataValueField = "BranchCode";
        ddlBranch.DataBind();
        ddlBranch.Items.Insert(0, new ListItem("Select Branch", "0"));
    }

    protected void BindDepartment()
    {
        ds = bs.GetDepartmentListByUser(Session["UserCode"].ToString());
        ddlDepartment.DataSource = ds;
        ddlDepartment.DataTextField = "Department_Name";
        ddlDepartment.DataValueField = "Department_ID";
        ddlDepartment.DataBind();
        ddlDepartment.Items.Insert(0, new ListItem("Select Department", "0"));
    }

    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBranch();
    }

   
}
