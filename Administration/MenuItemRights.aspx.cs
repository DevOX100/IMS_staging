using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web;

public partial class Administration_MenuItemRights : System.Web.UI.Page
{
   // MISReport ms = new MISReport();
    DataSet ds = new DataSet();
    Billing_System bs = new Billing_System();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRole();
            BindMenu();
            BindMenu();
            BindDepartment();
            if(Request.QueryString != null)
            {
                string TempKey = Request.QueryString["TempKey"];
                if(TempKey != null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
                }
                else
                {

                }
                
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

    private void BindRole()
    {
        ddlRoleName.DataSource = bs.SelectRole();
        ddlRoleName.DataTextField = "RoleName";
        ddlRoleName.DataValueField = "RoleID";
        ddlRoleName.DataBind();
        ddlRoleName.Items.Insert(0, new ListItem("-Select-", "0"));
    }
    static public void DisplayAJAXMessage(Control page, string msg)
    {
        string myScript = String.Format("alert('{0}');", msg);

        ScriptManager.RegisterStartupScript(page, page.GetType(),
          "MyScript", myScript, true);
    }
    protected void btnSaveMenu_Click(object sender, EventArgs e)
    {
        bool success = false;
        foreach (ListItem list in listMenuItem.Items)
        {
            if (list.Selected)
            {
                bs.AssignMenuByRole(Convert.ToInt32(list.Value), Convert.ToInt32(ddlRoleName.SelectedValue),
                    Convert.ToInt32(ddlMenuType.SelectedValue), ddlUser.SelectedValue);
                success = true;
            }
        }
        if (success)
        {
            LoadMenuItems();
            BindGvByRoleMenuID();
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Menu(s) has been assigned.', 'success');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Child Menu Not Selected!', 'Kindly Choose Child Menu From List.', 'error');", true);
        }
    }


    protected void ddlMenuType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadMenuItems();
        BindGvByRoleMenuID();
    }

    private void BindGvByRoleMenuID()
    {
        int RoleID = Convert.ToInt32(ddlRoleName.SelectedValue);
        int ParentMenuItemId = Convert.ToInt32(ddlMenuType.SelectedValue);
        ds = bs.SelectMenuByMenuRole(RoleID, ParentMenuItemId, ddlUser.SelectedValue);
        gvMenuItems.DataSource = ds;
        gvMenuItems.DataBind();
       // gvMenuItems.Visible = true;
        //lblChildMenu.Visible = true;
    }
    protected void LoadMenuItems()
    {
        int ParentMenuItemId = Convert.ToInt32(ddlMenuType.SelectedValue);
        ds = bs.SelectMenuByParentID(ParentMenuItemId);
        if (ds.Tables[0].Rows.Count > 0)
        {
            listMenuItem.DataSource = ds;
            listMenuItem.DataTextField = "MenuName";
            listMenuItem.DataValueField = "MenuID";
            listMenuItem.DataBind();            
            lblChildMenu.Visible = true;
            listMenuItem.Visible = true;
        }
        else
        {
            lblChildMenu.Visible = false;
            listMenuItem.Visible = false;
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Not Found!', 'Child Menu Not Found.', 'error');", true);
        }
        
     
        
    }
    private void BindMenu()
    {
        ddlMenuType.DataSource = bs.SelectMenuByID();
        ddlMenuType.DataTextField = "MenuName";
        ddlMenuType.DataValueField = "MenuID";
        ddlMenuType.DataBind();
        ddlMenuType.Items.Insert(0, new ListItem("-Select-", "0"));
    }
    protected void ddlRoleName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlRoleName.SelectedValue == "0")
        {
            ddlUser.Enabled = false;
            ddlUser.SelectedValue = "0";
        }
        else
        {
            BindUser();
            BindMenu();
            listMenuItem.DataSource = null;
            listMenuItem.DataBind();
            gvMenuItems.DataSource = null;
            gvMenuItems.DataBind();
            ddlUser.Enabled = true;
        }
       

    }
    protected void gvMenuItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="Remove")
        {
            int RoleMenuID = Convert.ToInt32(e.CommandArgument);
            bs.RemoveRoleMenu(RoleMenuID, ddlUser.SelectedValue);
            BindGvByRoleMenuID();
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Assigned Permission Deleted.', 'success');", true);
            // DisplayAJAXMessage(gvMenuItems, "Assigned Permission Deleted");
        }
    }

    protected void btnSaveFeature_Click(object sender, EventArgs e)
    {
        Settings st = new Settings();
        st.AddRole(txtFeature.Text,DateTime.Now);
        BindRole();
        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Role has been created.', 'success');", true);
        txtFeature.Text = null;
        divModel_AddRole.Visible = false;
    }

    protected void btnAddRole_Click(object sender, EventArgs e)
    {
        divModel_AddRole.Visible = true;
        txtFeature.Focus();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        divModel_AddRole.Visible = false;
    }

    protected void BindDepartment()
    {
        ds = bs.GetDepartmentListByUser(Session["UserCode"].ToString());
        ddlDepartment.DataSource = ds;
        ddlDepartment.DataTextField = "Department_Name";
        ddlDepartment.DataValueField = "Department_ID";
        ddlDepartment.DataBind();
        ddlDepartment.Items.Insert(0, new ListItem("-Select-", "0"));
    }

    protected void BindUser()
    {
        ds = bs.GetUserDetailByRoleID(Convert.ToInt32(ddlRoleName.SelectedValue), Convert.ToInt32(ddlDepartment.SelectedValue));
        ddlUser.DataSource = ds;
        ddlUser.DataTextField = "Name";
        ddlUser.DataValueField = "UserCode";
        ddlUser.DataBind();
        ddlUser.Items.Insert(0, new ListItem("Select User", "0"));
    }

    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlDepartment.SelectedValue == "0")
        {
            ddlRoleName.Enabled = false;
            ddlRoleName.SelectedValue = "0";
        }
        else
        {
            ddlRoleName.Enabled = true;
            ddlRoleName.SelectedValue = "0";
        }
        
    }

    protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUser.SelectedValue == "0")
        {
            ddlMenuType.Enabled = false;
            ddlMenuType.SelectedValue = "0";
        }
        else
        {
            ddlMenuType.Enabled = true;
            ddlMenuType.SelectedValue = "0";
        }
    }
}