using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MISLogin
/// </summary>
public class MISLogin : db
{
    DataSet ds;
    SqlParameter[] param;
    public string AccountPassword { get; set; }
    public string UAEmployeeID { get; set; }

    public DataSet LoginLoginWithUserNameAndPassword()
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@UAEmployeeID", UAEmployeeID);
        param[1] = new SqlParameter("@AccountPassword", AccountPassword);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MIS_LoginLoginWithUserNameAndPassword", param);
    }


    // 15-11-2021 RADHIKA // 

    public DataSet CheckUserExistsOrNot(string UAEmployeeID, string Mobile, string Email)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@UAEmployeeID", UAEmployeeID);
        param[1] = new SqlParameter("@Mobile", Mobile);
        param[2] = new SqlParameter("@Email", Email);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_CheckUserExistsOrNot", param);
        return ds;
    }

    public DataSet ChangePassword()
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@UAEmployeeID", UAEmployeeID);
        param[1] = new SqlParameter("@AccountPassword  ", AccountPassword);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ChangePassword", param);
        return ds;
    }

    public DataSet ModifyUserAccountOTPData(string MobileOTP, string EmailOTP, bool IsOTPSent, string EmployeeID)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@MobileOTP", MobileOTP);
        param[1] = new SqlParameter("@EmailOTP", EmailOTP);
        param[2] = new SqlParameter("@IsOTPSent", IsOTPSent);
        param[3] = new SqlParameter("@EmployeeID", EmployeeID);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyUserAccountOTPData", param);
        return ds;
    }

    public DataSet CheckOTP(string EmployeeID, string UA_Email, string EmailOTP, string UA_Mobile, string MobileOTP)
    {
        param = new SqlParameter[5];
        param[0] = new SqlParameter("@EmployeeID", EmployeeID);
        param[1] = new SqlParameter("@UA_Email", UA_Email);
        param[2] = new SqlParameter("@EmailOTP", EmailOTP);
        param[3] = new SqlParameter("@UA_Mobile", UA_Mobile);
        param[4] = new SqlParameter("@MobileOTP", MobileOTP);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_CheckOTP", param);
        return ds;
    }


    public DataSet UserLoginTrackDetails(string IP, string HostName, string Country, string State, string City, string Loc, string Postal, string BrowserDetails, 
        string UserAccountID, string EmployeeId, string DeviceIP, string MACIP)
    {
        param = new SqlParameter[12];
        param[0] = new SqlParameter("@IP", IP);
        param[1] = new SqlParameter("@HostName", HostName);
        param[2] = new SqlParameter("@Country", Country);
        param[3] = new SqlParameter("@State", State);
        param[4] = new SqlParameter("@City", City);
        param[5] = new SqlParameter("@Loc", Loc);
        param[6] = new SqlParameter("@Postal", Postal);
        param[7] = new SqlParameter("@BrowserDetails", BrowserDetails);
        param[8] = new SqlParameter("@UserAccountID", UserAccountID);
        param[9] = new SqlParameter("@EmployeeId", EmployeeId);
        param[10] = new SqlParameter("@DeviceIP", DeviceIP);
        param[11] = new SqlParameter("@MACIP", MACIP);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_UserLoginTrackDetails", param);
        return ds;
    }

    public DataSet ModifyMobileAttemptation(int MobileOTPAttemptation, string EmpID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@MobileOTPAttemptation", MobileOTPAttemptation);
        param[1] = new SqlParameter("@EmpID", EmpID);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyMobileAttemptation", param);
        return ds;
    }

    public DataSet ModifyEmailAttemptation(int EmailOTPAttemptation, string EmpID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@EmailOTPAttemptation", EmailOTPAttemptation);
        param[1] = new SqlParameter("@EmpID", EmpID);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyEmailAttemptation", param);
        return ds;
    }

    public DataSet GetOTPAttemptations(string EmpID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@EmpID", EmpID);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetOTPAttemptations", param);
        return ds;
    }

    public DataSet InsertUserOTPLog(int EmailOTPAttempt, int MobileOTPAttempt, string EmpID, string InsertDate)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@EmailOTPAttempt", EmailOTPAttempt);
        param[1] = new SqlParameter("@MobileOTPAttempt", MobileOTPAttempt);
        param[2] = new SqlParameter("@EmpID", EmpID);
        param[3] = new SqlParameter("@InsertDate", InsertDate);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_InsertUserOTPLog", param);
        return ds;
    }


    public DataSet InsertUserReportTrackDetails(string EmpID, int ReportID, string Error, string IP)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@EmpID", EmpID);
        param[1] = new SqlParameter("@ReportID", ReportID);
        param[2] = new SqlParameter("@Error", Error);
        param[3] = new SqlParameter("@IP", IP);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_InsertUserReportTrackDetails", param);
        return ds;
    }

    public DataSet CheckUserLoginDetails(string UAEmployeeID, string IP)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@UAEmployeeID", UAEmployeeID);
        param[1] = new SqlParameter("@IP", IP);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_CheckUserLoginDetails", param);
        return ds;
    }

    public DataSet dummyproc()
    {
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_dummyproc");
        return ds;
    }
}