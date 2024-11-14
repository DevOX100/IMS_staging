using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
   
    private const string SESSION_USERACCOUNT = "UserAccounts";
    public const string SESSION_SELECTED_ITEM = "SelectedItem";
    public int UserAccountId
    {
        get
        {
            int userId = 1;
            //if (User.Identity.IsAuthenticated && User.Identity.Name != "")
            //{
            //    userId = Convert.ToInt32(User.Identity.Name);
            //}
            return userId;
        }
    }

    //public abstract int MenuCode();
    //public static int MenuCodeTemp
    //{
    //    get;
    //    set;
    //}

    //public abstract string[] AccessRoles();
    //protected void OnInit(EventArgs e)
    //{
    //        }
}
