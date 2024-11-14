using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;

/// <summary>
/// Summary description for MISReport
/// </summary>
public class MISReport:db
{
    DataSet ds;
    SqlParameter[] param;
    public string AccountName { get; set; }
    public string AccountPassword { get; set; }
    public string UAEmployeeID { get; set; }
    public int UARoleID { get; set; }
    public int UA_BranchID { get; set; }
    public string LogIPAddress { get; set; }
    public string LogHostName { get; set; }
    public MISReport()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet LoginUpdates()
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@LogIPAddress", LogIPAddress);
        param[1] = new SqlParameter("@LogHostName", LogHostName);
        param[2] = new SqlParameter("@UAEmployeeID", UAEmployeeID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "LoginUpdates", param);
    }
    //public DataSet mmf_Collection(DateTime FromDate, DateTime ToDate)
    //{
    //    param = new SqlParameter[2];
    //    param[0] = new SqlParameter("@FromDate", FromDate);
    //    param[1] = new SqlParameter("@ToDate", ToDate); 
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_Collection", param);
    //}
    //public DataSet mmf_Projection(DateTime FromDate, DateTime ToDate)
    //{
    //    param = new SqlParameter[2];
    //    param[0] = new SqlParameter("@FromDate", FromDate);
    //    param[1] = new SqlParameter("@ToDate", ToDate);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_Projection", param);
    //}
    public DataSet rc_TrialBalance1(string FBranchID, string TBranchID, DateTime FromDate, DateTime ToDate, int BankID=19)
    {
        param = new SqlParameter[5];
        param[0] = new SqlParameter("@FromRegionID", FBranchID);
        param[1] = new SqlParameter("@ToRegionID", TBranchID);
        param[2] = new SqlParameter("@FromDate", FromDate);
        param[3] = new SqlParameter("@ToDate", ToDate);
        param[4] = new SqlParameter("@BankID", BankID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "rc_TrialBalance1", param);
    }
    public DataTable mmf_CollectionDetail(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_CollectionDetail", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 400;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }
    public DataSet BranchDetails()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select OurBranchID,BranchName from t_SystemBranchSetting");
    }
    public DataSet ChangePasswordPush()
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@UAEmployeeID", UAEmployeeID);
        param[1] = new SqlParameter("@AccountPassword  ", AccountPassword);
        ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "update m_UserAccount set UA_Password=@AccountPassword,UA_PasswordUpdateDate = GETDATE() where UA_EmployeeID=@UAEmployeeID", param);
        return ds;
    }
    //public DataSet mmf_ProjectionGeneration(DateTime FromDate)
    //{
    //    param = new SqlParameter[1];
    //    param[0] = new SqlParameter("@date", FromDate);
    //   return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_ProjectionGeneration", param);
    //}
    //public DataSet mmf_CollectionEfficiency(DateTime FromDate)
    //{
    //    param = new SqlParameter[1];
    //    param[0] = new SqlParameter("@From", FromDate);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_CollectionEfficiency", param);
    //}
    //public DataSet mmf_LBD(DateTime FromDate, DateTime ToDate)
    //{
    //    param = new SqlParameter[2];
    //    param[0] = new SqlParameter("@FromDate", FromDate);
    //    param[1] = new SqlParameter("@ToDate", ToDate);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_LBD", param);
    //}
    //public DataSet mmf_Disbursment(DateTime FromDate, DateTime ToDate)
    //{
    //    param = new SqlParameter[2];
    //    param[0] = new SqlParameter("@FromDate", FromDate);
    //    param[1] = new SqlParameter("@ToDate", ToDate);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_Disbursment", param);
    //}
    //public DataSet mmf_CashlessCredit(DateTime FromDate)
    //{
    //    param = new SqlParameter[1];
    //    param[0] = new SqlParameter("@FromDate", FromDate);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_CashlessCredit", param);
    //}
    //public DataSet mmf_MISDisbursment(DateTime FromDate)
    //{
    //    param = new SqlParameter[1];
    //    param[0] = new SqlParameter("@date", FromDate);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_MISDisbursment", param);
    //}
    //public DataSet mmf_BranchWiseCollectionEfficiency(DateTime FromDate)
    //{
    //    param = new SqlParameter[1];
    //    param[0] = new SqlParameter("@From", FromDate);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_BranchWiseCollectionEfficiency", param);
    //}

    public DataSet RegisterWithUserNameAndPassword(string AccountName, string UAEmployeeID, string AccountPassword, int UARoleID, int UA_BranchID, string Mobile, string Email)
    {
        param = new SqlParameter[7];
        param[0] = new SqlParameter("@AccountName", AccountName);
        param[2] = new SqlParameter("@UAEmployeeID", UAEmployeeID);
        param[1] = new SqlParameter("@AccountPassword", AccountPassword);
        param[3] = new SqlParameter("@UARoleID", UARoleID);
        param[4] = new SqlParameter("@UA_BranchID", UA_BranchID);
        param[5] = new SqlParameter("@Mobile", Mobile);
        param[6] = new SqlParameter("@Email", Email);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "RegisterWithUserNameAndPassword", param);
    }

    public DataSet SelectMenu(int roleName)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@RoleID", roleName);
        //param[0] = new SqlParameter("@MenuItemID", MenuItemID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_MenuItemByRole", param);
    }
   
    public DataSet SelectReportItemRole(int roleName)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@RoleID", roleName);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_SelectReportItemRole", param);
    }
   
    
    public DataSet SelectUserID()
    {
        //param = new SqlParameter[1];
        //param[0] = new SqlParameter("@MenuParentID", );
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "SELECT * FROM m_UserAccount INNER JOIN mmf_Role ON UA_RoleID=RoleID where UA_IsActive=1");
    }
    public DataSet SelectUserEmpCode()
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UAEmployeeID", UAEmployeeID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "SELECT UserAccountID,UserAccountName,UA_EmployeeID,UA_InsertDate ,RoleName,(CASE UA_IsActive WHEN 0 THEN 'Active' else 'Deactive' end ) as Visible FROM m_UserAccount INNER JOIN mmf_Role ON UA_RoleID=RoleID where UA_EmployeeID=@UAEmployeeID", param);
    }
    public DataSet SelectUser()
    {
        //param = new SqlParameter[1];
        //param[0] = new SqlParameter("@MenuParentID", );
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "SELECT UserAccountID,UserAccountName,UA_EmployeeID,UA_InsertDate ,RoleName,(CASE UA_IsActive WHEN 0 THEN 'Active' else 'Deactive' end ) as Visible FROM m_UserAccount INNER JOIN mmf_Role ON UA_RoleID=RoleID order by UserAccountName,Visible");
    }
    public DataSet SelectUniqueUser()
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UA_EmployeeID", UAEmployeeID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select UA_EmployeeID from m_UserAccount where UA_EmployeeID=@UA_EmployeeID", param);
    }
    

    public DataSet SelectRoleForAdmin()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from mmf_role  order by RoleName");
    }

    public DataSet SelectReport()
    {
        //param = new SqlParameter[1];
        //param[0] = new SqlParameter("@MenuParentID", );
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from MasterReport order by ReportName");
    }
    public DataSet AssignReportByRole(int ReportNumber, int RoleID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@ReportNumber", ReportNumber);
        param[1] = new SqlParameter("@RoleID", RoleID);
       
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_ReportAssignInsert", param);
    }
   
   
    public DataSet DeleteAssignPermissionReport(int ReportAssignID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@ReportAssignID", ReportAssignID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "delete from AssignReport where ReportAssignID=@ReportAssignID", param);
    }
    public DataSet DeleteUserDetail(int UserAccountID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserAccountID", UserAccountID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "update m_UserAccount set UA_IsActive=CASE UA_IsActive WHEN 0 THEN 1 ELSE 0 END where UserAccountID=@UserAccountID", param);
    }
    public DataSet KitByBranchID(int AllocatedToBranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select KitSerialNo from MasterKit where AllocatedToBranchID=@AllocatedToBranchID", param);
    }
    //public DataSet GetBranchByID(int BranchID)
    //{
    //    param = new SqlParameter[1];
    //    param[0] = new SqlParameter("@BranchID", BranchID);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "SELECT Branch ", param);
    //}
    //public DataSet ReportDetail()
    //{
    //    param = new SqlParameter[0];
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from m_MIS_Report");
    //}
    //public DataSet ReportDateWise(DateTime dtFrom ,DateTime dtTo)
    //{
    //    param = new SqlParameter[2];
    //    param[0] = new SqlParameter("@dtFrom", dtFrom);
    //    param[1] = new SqlParameter("@dtTo", dtTo);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "", param);
    //}
    public void DisplayAJAXMessage(Control page, string msg)
    {
        string myScript = String.Format("alert('{0}');", msg);

        ScriptManager.RegisterStartupScript(page, page.GetType(),
          "MyScript", myScript, true);
    }

    public DataSet InsertUserReportTrackData(string EmpID, int ReportID, string Error)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@EmpID", EmpID);
        param[1] = new SqlParameter("@ReportID", ReportID);
        param[2] = new SqlParameter("@Error", Error);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_InsertUserReportTrackData", param);
    }

    public DataSet Employees_GetAddress(string EmployeeId)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@EmployeeId", EmployeeId);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Employees_GetAddress", param);
    }

    public DataSet CheckExistingMobileData(string Mobile)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mobile", Mobile);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_CheckExistingMobileData", param);
    }

    public DataSet CheckExistingEmailData(string Email)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@Email", Email);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_CheckExistingEmailData", param);
    }
}