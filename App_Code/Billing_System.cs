﻿
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Billing_System
/// </summary>
public class Billing_System : db
{
    DataSet ds;
    SqlParameter[] param;
    public string BranchCode { get; set; }
    public string Password { get; set; }
    public string UserCode { get; set; }


    public DataSet GetLoginDetails(string UserName, string Password)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@UserCode", UserName);
        param[1] = new SqlParameter("@Password", Password);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetLoginDetails", param);
        return ds;
    }


    public DataSet GetBranchByID(int BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetBranchByID", param);
        return ds;
    }

    public DataSet SelectRole()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from mmf_role order by RoleName");
    }

    public DataSet SelectRoleForAdmin()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from mmf_role  order by RoleName");
    }

    public DataSet SelectMenu(int roleName, string UserCode)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@RoleID", roleName);
        param[1] = new SqlParameter("@UserCode", UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_MenuItemByRole", param);
    }


    public DataSet AssignMenuByRole(int RoleMenuItemID, int RoleID, int ParentID, string UserCode)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@RoleMenuItemID", RoleMenuItemID);
        param[1] = new SqlParameter("@RoleID", RoleID);
        param[2] = new SqlParameter("@ParentID", ParentID);
        param[3] = new SqlParameter("@UserCode", UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_RoleMenuItemInsert", param);
    }

    public DataSet SelectMenuByMenuRole(int roleName, int MenuItemID, string UserCode)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@RoleID", roleName);
        param[1] = new SqlParameter("@MenuItemID", MenuItemID);
        param[2] = new SqlParameter("@UserCode", UserCode);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_MenuByMenuRole", param);
    }

    public DataSet SelectMenuByParentID(int MenuParentID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@MenuParentID", MenuParentID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "SELECT MenuID, MenuName,MenuItemCode FROM mmf_MenuItemTable where MenuParentID=@MenuParentID and MenuIsActive = 1 order by MenuName", param);
    }
    public DataSet SelectMenuByID()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_SelectMenuByID");
    }

    public DataSet RemoveRoleMenu(int RoleMenuID, string UserCode)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@RoleMenuID", RoleMenuID);
        param[1] = new SqlParameter("@UserCode", UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_RemoveRoleMenu", param);
    }

    public DataSet GetMastPaymentTracker(int DepID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@DepID", DepID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetMastPaymentTracker", param);
    }

    public DataSet SelectInvoiceTracker(string InvoiceNO, int DepID, string Type, DateTime? FromDate, DateTime? ToDate)
    {
        param = new SqlParameter[5];
        param[0] = new SqlParameter("@InvoiceNO", InvoiceNO);
        param[1] = new SqlParameter("@DepID", DepID);
        param[2] = new SqlParameter("@Type", Type);
        param[3] = new SqlParameter("@FromDate", FromDate);
        param[4] = new SqlParameter("@ToDate", ToDate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetMastPaymentTrackerByInvoiceNo", param);
    }


    public DataSet InsertMastPaymentTrackerData(DateTime DateOfInvoice, DateTime DateofSubmission, string InvoiceNumber, decimal InvoiceAmtExcludeGST,
             decimal GSTAmt, decimal InvoiceAmt, DateTime PaymentDueDate, bool IsAmtPaidOwn,
             string PaidEmpCode, string PaidEmpName, string InvoiceAttatchment, string VendorName, DateTime? BillingCycleFrom,
             DateTime? BillingCycleTo, string Frequency, int InsertUserAccountID, bool ISGST, int PT_Department, string PT_NatureOfExpenses,
             string PT_ReasonofInvoice, string PT_Remarks, string PT_ApprovalID, string PT_RegionCode, string PT_BranchCode, string PT_GSTPct, int? PT_HSN)
    {
        param = new SqlParameter[26];
        param[0] = new SqlParameter("@DateOfInvoice", DateOfInvoice);
        param[1] = new SqlParameter("@DateofSubmission", DateofSubmission);
        param[2] = new SqlParameter("@InvoiceNumber", InvoiceNumber);
        param[3] = new SqlParameter("@InvoiceAmtExcludeGST", InvoiceAmtExcludeGST);
        param[4] = new SqlParameter("@GSTAmt", GSTAmt);
        param[5] = new SqlParameter("@InvoiceAmt", InvoiceAmt);
        param[6] = new SqlParameter("@PaymentDueDate", PaymentDueDate);
        //param[7] = new SqlParameter("@DateOfPayment", DateOfPayment);
        //param[8] = new SqlParameter("@UTRDetails", UTRDetails);
        param[7] = new SqlParameter("@IsAmtPaidOwn", IsAmtPaidOwn);
        param[8] = new SqlParameter("@PaidEmpCode", PaidEmpCode);
        param[9] = new SqlParameter("@PaidEmpName", PaidEmpName);
        param[10] = new SqlParameter("@InvoiceAttatchment", InvoiceAttatchment);
        param[11] = new SqlParameter("@VendorName", VendorName);
        param[12] = new SqlParameter("@BillingCycleFrom", BillingCycleFrom);
        param[13] = new SqlParameter("@BillingCycleTo", BillingCycleTo);
        param[14] = new SqlParameter("@Frequency", Frequency);
        param[15] = new SqlParameter("@InsertUserAccountID", InsertUserAccountID);
        param[16] = new SqlParameter("@ISGST", ISGST);
        param[17] = new SqlParameter("@PT_Department", PT_Department);
        param[18] = new SqlParameter("@PT_NatureOfExpenses", PT_NatureOfExpenses);
        param[19] = new SqlParameter("@PT_ReasonofInvoice", PT_ReasonofInvoice);
        param[20] = new SqlParameter("@PT_Remarks", PT_Remarks);
        param[21] = new SqlParameter("@PT_ApprovalID", PT_ApprovalID);
        param[22] = new SqlParameter("@PT_RegionCode", PT_RegionCode);
        param[23] = new SqlParameter("@PT_BranchCode", PT_BranchCode);
        param[24] = new SqlParameter("@PT_GSTPct", PT_GSTPct);
        param[25] = new SqlParameter("@PT_HSN", PT_HSN);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_InsertMastPaymentTrackerData", param);
    }

    public DataSet BranchViewDetail()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "SELECT BranchID,BranchName  FROM Branch_Master WHERE  IsActive=1 order by BranchName ");
    }
    public DataSet ChangePassword(string AccountPassword, string UserCode)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@AccountPassword ", AccountPassword);
        param[1] = new SqlParameter("@UserCode", UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ChangePassword", param);
    }

    public DataSet CreateUserLogin(string UserName, string UserCode, string Password, string BCode, int RoleID, string Email,
        string Mobile, string RCode, int Dpmt)
    {
        param = new SqlParameter[9];
        param[0] = new SqlParameter("@UserName", UserName);
        param[1] = new SqlParameter("@UserCode", UserCode);
        param[2] = new SqlParameter("@Password", Password);
        param[3] = new SqlParameter("@BCode", BCode);
        param[4] = new SqlParameter("@RoleID", RoleID);
        param[5] = new SqlParameter("@Email", Email);
        param[6] = new SqlParameter("@Mobile", Mobile);
        param[7] = new SqlParameter("@RCode", RCode);
        param[8] = new SqlParameter("@DepID", Dpmt);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_CreateUserLogin", param);
    }

    public DataSet SelectUniqueUser()
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserCode", UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select UserCode from UserLogin where UserCode=@UserCode", param);
    }

    public DataSet Modify_Mast_Payment_Tracker_ISP_Data(DateTime DateofPayment, string UTR, int ID, int PaymentUserAccountID, DateTime TransactionDate, string TransactionRemarks)
    {
        param = new SqlParameter[6];
        param[0] = new SqlParameter("@DateofPayment", DateofPayment);
        param[1] = new SqlParameter("@UTR", UTR);
        param[2] = new SqlParameter("@ID", ID);
        param[3] = new SqlParameter("@PaymentUserAccountID", PaymentUserAccountID);
        param[4] = new SqlParameter("@TransDate", TransactionDate);
        param[5] = new SqlParameter("@Transaction", TransactionRemarks);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_Modify_Mast_Payment_Tracker_ISP_Data", param);
    }

    public DataSet CheckExistingMobileData(string Mobile)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mobile", Mobile);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select Mobile from UserLogin where Mobile=@Mobile", param);
    }

    public DataSet CheckExistingEmailData(string Email)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@Email", Email);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select Email from UserLogin where Email=@Email", param);
    }

    public DataSet GetMastPaymentAccounts(string Type, int DepID, DateTime? FromDate, DateTime? ToDate)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@Type", Type);
        param[1] = new SqlParameter("@DepID", DepID);
        param[2] = new SqlParameter("@FromDate", FromDate);
        param[3] = new SqlParameter("@ToDate", ToDate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetMastPaymentAccounts", param);
    }

    public DataSet CheckExistsInvoiceNo(string InvoiceNo, DateTime? DateOfInvoice, string VendorName)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@InvoiceNo", InvoiceNo);
        param[1] = new SqlParameter("@DateOfInvoice", DateOfInvoice);
        param[2] = new SqlParameter("@VendorName", VendorName);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_CheckExistsInvoiceNo", param);
    }

    public DataSet SelectUserDetails()
    {
        param = new SqlParameter[0];
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_SelectUserDetails", param);
    }

    public DataSet ModifyUserDetails(string UserAccountID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserAccountID", UserAccountID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyUserDetails", param);
    }

    public DataSet SelectUserDetailsbyUserCode(string UserCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserCode", UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_SelectUserDetailsbyUserCode", param);
    }

    public DataSet DashboardCount(string UserCode, int DepID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@UserCode", UserCode);
        param[1] = new SqlParameter("@DepID", DepID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_DashboardCount", param);
    }

    public DataSet DashboardInvoiceCount(string UserCode, int DepID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@UserCode", UserCode);
        param[1] = new SqlParameter("@DepID", DepID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_DashboardInvoiceCount", param);
    }
    //public DataSet GetDepartmentList()
    //{
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetDepartmentList");
    //}

    public DataSet GetVendorlist()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetVendorlist");
    }

    public DataSet GetApprovalMaster(int DepID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@DepID", DepID);
        //param[1] = new SqlParameter("@Month", Month);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetApprovalMaster", param);
    }

    public DataSet ModifyApprovalDetails(bool PT_IsApproved, string PT_IsApprovedby, int PT_ID, string ApprovedRemarks)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@PT_IsApproved", PT_IsApproved);
        param[1] = new SqlParameter("@PT_IsApprovedby", PT_IsApprovedby);
        param[2] = new SqlParameter("@PT_ID", PT_ID);
        param[3] = new SqlParameter("@ApprovedRemarks", ApprovedRemarks);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyApprovalDetails", param);
    }

    public DataSet GetMastPaymentDetailsByID(string ID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@ID", ID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetMastPaymentDetailsByID", param);
    }

    public DataSet GetMastPaymentForApproval(string ApprovalID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@ApprovalID", ApprovalID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetMastPaymentForApproval", param);
    }

    public DataSet ModifyApprovalMasterData(decimal MinLimit, decimal MaxLimit, int ID, DateTime FromDate, DateTime ToDate, bool IsActive)
    {
        param = new SqlParameter[6];
        param[0] = new SqlParameter("@MinLimit", MinLimit);
        param[1] = new SqlParameter("@MaxLimit", MaxLimit);
        param[2] = new SqlParameter("@ID", ID);
        param[3] = new SqlParameter("@FromDate", FromDate);
        param[4] = new SqlParameter("@ToDate", ToDate);
        param[5] = new SqlParameter("@IsActive", IsActive);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyApprovalMasterData", param);
    }

    public DataSet GetRegionDetailsbyUserCode(string UserCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserCode", UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetRegionDetailsbyUserCode", param);
    }

    public DataSet GetRegionDetails()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetRegionDetails");
    }

    public DataSet GetBranchDetailsbyRCode(string RCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@RCode", RCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetBranchDetailsbyRCode", param);
    }

    public DataSet ApprovalFlowForAll(DateTime FROMDATE, DateTime TODATE, string EMPCODE, string Region, decimal EnterAmount, int DepID)
    {
        param = new SqlParameter[6];
        param[0] = new SqlParameter("@FROMDATE", FROMDATE);
        param[1] = new SqlParameter("@TODATE", TODATE);
        param[2] = new SqlParameter("@EMPCODE", EMPCODE);
        param[3] = new SqlParameter("@Region", Region);
        param[4] = new SqlParameter("@EnterAmount", EnterAmount);
        param[5] = new SqlParameter("@DepID", DepID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ApprovalFlowForAll", param);
    }

    public DataSet GetEmpCodeByRCode(string RCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@RCode", RCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetEmpCodeByRCode", param);
    }

    public DataSet GetDepartmentListByUser(string UserCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserCode", UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetDepartmentListByUser", param);
    }

    public DataSet GetUserDetailByRoleID(int RoleID, int DepID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@RoleID", RoleID);
        param[1] = new SqlParameter("@DepID", DepID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetUserDetailByRoleID", param);
    }

    public DataSet GetUserForwardMail(int depID, string LoginUserID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@depID", depID);
        param[1] = new SqlParameter("@LoginUserID", LoginUserID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetUserForwardMail", param);
    }

    public DataSet ModifyForwardpprovalData(string ApprovalID, string Remarks, int ID, string ForwardedBy)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@FwdApprovalID", ApprovalID);
        param[1] = new SqlParameter("@FwdRemarks", Remarks);
        param[2] = new SqlParameter("@ID", ID);
        param[3] = new SqlParameter("@ForwardedBy", ForwardedBy);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyForwardpprovalData ", param);
    }

    public DataSet GetMastPaymentForForwardApproval(string ApprovalID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@ApprovalID", ApprovalID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetMastPaymentForForwardApproval", param);
    }

    public DataSet GetUserDetails()
    {
        param = new SqlParameter[0];
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetUserDetails", param);
    }

    public DataSet GetUserDetailsForEdit(int ID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@ID", ID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetUserDetailsForEdit", param);
    }

    public DataSet ModifyUserLoginData(string Department, string Role, string ModifyBy, int ID)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@Department", Department);
        param[1] = new SqlParameter("@Role", Role);
        param[2] = new SqlParameter("@ModifyBy", ModifyBy);
        param[3] = new SqlParameter("@ID", ID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyUserLoginData ", param);
    }

    public DataSet GetEmployeeNamebyEmpCode(string UserName)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserName", UserName);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetEmployeeNamebyEmpCode", param);
    }

    public DataSet GetUserEmailForForwardInvoice(string UserCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserCode", UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetUserEmailForForwardInvoice", param);
    }

    public DataSet InsertLoginData(string IP, string BrowserDetails, string UserAccountID, string EmployeeID, string MACIP)
    {
        param = new SqlParameter[5];
        param[0] = new SqlParameter("@IP", IP);
        param[1] = new SqlParameter("@BrowserDetails", BrowserDetails);
        param[2] = new SqlParameter("@UserAccountID", UserAccountID);
        param[3] = new SqlParameter("@EmployeeID", EmployeeID);
        param[4] = new SqlParameter("@MACIP", MACIP);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_InsertLoginData", param);
    }

    public DataSet LastLoginDate(string EmployeeID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@EmployeeID", EmployeeID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_LastLoginDate", param);
    }

    ////////// Made by Rohit////////////
    ///
    public DataSet GetVendorDetails(int DepID, string UserID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@DepID", DepID);
        param[1] = new SqlParameter("@LoginID", UserID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetVendorDetails", param);
    }

    public DataSet CreateVendorMaster(string DepID, string VendorType, string VName, string Address, string AccountNo, string IFSCCode,
        string BankName, string Remarks, string Email, string MobileNo, string GSTNO, string PanNo, string AltMobile, string AltEmail, string MSME, string TurnOverOfLastYear,
        string InvoicingApplicability, string TDSChargeability, string HSNCode, string HSNDetails, string WhetherVendorhasFiledPast2yearsITR,
        string FrequencyOfFilingGSTReturn, int InsertUserAccountID, string Annexure, string AllDocumentInOnePdf, string V_IsGST)
    {
        param = new SqlParameter[26];
        param[0] = new SqlParameter("@DepID", DepID);
        param[1] = new SqlParameter("@VendorType", VendorType);
        param[2] = new SqlParameter("@Name", VName);
        param[3] = new SqlParameter("@Address", Address);
        param[4] = new SqlParameter("@AccountNo", AccountNo);
        param[5] = new SqlParameter("@IFSCCode", IFSCCode);
        param[6] = new SqlParameter("@BankName", BankName);
        param[7] = new SqlParameter("@Remarks", Remarks);
        param[8] = new SqlParameter("@Email", Email);
        param[9] = new SqlParameter("@MobileNo", MobileNo);
        param[10] = new SqlParameter("@GSTNO", GSTNO);
        param[11] = new SqlParameter("@PanNo", PanNo);
        param[12] = new SqlParameter("@AltMobile", AltMobile);
        param[13] = new SqlParameter("@AltEmail", AltEmail);
        param[14] = new SqlParameter("@MSMERegNo", MSME);
        param[15] = new SqlParameter("@TurnOverOfLastYear", TurnOverOfLastYear);
        param[16] = new SqlParameter("@InvoicingApplicability", InvoicingApplicability);
        param[17] = new SqlParameter("@TDSChargeability", TDSChargeability);
        param[18] = new SqlParameter("@HSNCode", HSNCode);
        param[19] = new SqlParameter("@HSNDetails", HSNDetails);
        param[20] = new SqlParameter("@WhetherVendorhasFiledPast2yearsITR", WhetherVendorhasFiledPast2yearsITR);
        param[21] = new SqlParameter("@FrequencyOfFilingGSTReturn", FrequencyOfFilingGSTReturn);
        param[22] = new SqlParameter("@InsertUserAccountID", InsertUserAccountID);
        param[23] = new SqlParameter("@Annexure", Annexure);
        param[24] = new SqlParameter("@AllDocumentInOnePdf", AllDocumentInOnePdf);
        param[25] = new SqlParameter("@V_IsGST", V_IsGST);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_CreateVendorMaster", param);
    }

    public DataSet GetVendorMaxID(int InsertUserAccountID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@InsertUserAccountID", InsertUserAccountID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetVendorMaxID", param);
    }


    ///Baljinder Pages /////////
    ///

    public DataSet SendBackInvoiceEdit(int PT_ID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@PT_ID", PT_ID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_SendBackInvoiceEdit", param);
    }

    public DataSet GetSendBackForReCheck(string SendBackTo)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@SendBackTo", SendBackTo);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetSendBackForReCheck", param);
    }

    public DataSet UpdateMastPaymentTrackerData(decimal InvoiceAmtExcludeGST,
            decimal GSTAmt, decimal InvoiceAmt, DateTime PaymentDueDate, bool IsAmtPaidOwn,
            string PaidEmpCode, string PaidEmpName, string InvoiceAttatchment, DateTime? BillingCycleFrom,
            DateTime? BillingCycleTo, string Frequency, int InsertUserAccountID, bool ISGST, string PT_NatureOfExpenses,
            string PT_ReasonofInvoice, string PT_Remarks, string PT_ApprovalID, string PT_GSTPct, string PT_RectificationRemarks, 
            string InvoiceNumber, int PT_ModifyByID, int ID, int? PT_HSN)
    {
        param = new SqlParameter[23];
        param[0] = new SqlParameter("@InvoiceAmtExcludeGST", InvoiceAmtExcludeGST);
        param[1] = new SqlParameter("@GSTAmt", GSTAmt);
        param[2] = new SqlParameter("@InvoiceAmt", InvoiceAmt);
        param[3] = new SqlParameter("@PaymentDueDate", PaymentDueDate);
        param[4] = new SqlParameter("@IsAmtPaidOwn", IsAmtPaidOwn);
        param[5] = new SqlParameter("@PaidEmpCode", PaidEmpCode);
        param[6] = new SqlParameter("@PaidEmpName", PaidEmpName);
        param[7] = new SqlParameter("@InvoiceAttatchment", InvoiceAttatchment);
        param[8] = new SqlParameter("@BillingCycleFrom", BillingCycleFrom);
        param[9] = new SqlParameter("@BillingCycleTo", BillingCycleTo);
        param[10] = new SqlParameter("@Frequency", Frequency);
        param[11] = new SqlParameter("@InsertUserAccountID", InsertUserAccountID);
        param[12] = new SqlParameter("@ISGST", ISGST);
        param[13] = new SqlParameter("@PT_NatureOfExpenses", PT_NatureOfExpenses);
        param[14] = new SqlParameter("@PT_ReasonofInvoice", PT_ReasonofInvoice);
        param[15] = new SqlParameter("@PT_Remarks", PT_Remarks);
        param[16] = new SqlParameter("@PT_ApprovalID", PT_ApprovalID);
        param[17] = new SqlParameter("@PT_GSTPct", PT_GSTPct);
        param[18] = new SqlParameter("@PT_RectificationRemarks", PT_RectificationRemarks);
        param[19] = new SqlParameter("@InvoiceNumber", InvoiceNumber);
        param[20] = new SqlParameter("@PT_ModifyByID", PT_ModifyByID);
        param[21] = new SqlParameter("@ID", ID);
        param[22] = new SqlParameter("@PT_HSN", PT_HSN);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_UpdateMastPaymentTrackerData", param);
    }

    public DataSet GetApprovalDetailsForInvoiceEdit(string ApprovalCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@ApprovalCode", ApprovalCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetApprovalDetailsForInvoiceEdit", param);
    }

    public DataSet GetVendorBankDetails(string VID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@VID", VID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetVendorBankDetails", param);
    }

    public DataSet GetVendorlist(string DepID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@DepID", DepID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetVendorlist", param);
    }

    public DataSet ModifySendBackData(string SendBackBy, string SendBackTo, string SendBackRemarks, int ID)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@SendBackBy", SendBackBy);
        param[1] = new SqlParameter("@SendBackTo", SendBackTo);
        param[2] = new SqlParameter("@SendBackRemarks", SendBackRemarks);
        param[3] = new SqlParameter("@ID", ID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifySendBackData ", param);
    }

    public DataSet DashboardCardData(int DepID, string Type, string UserCode)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@DepID", DepID);
        param[1] = new SqlParameter("@Type", Type);
        param[2] = new SqlParameter("@UserCode", UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_DashboardCardData", param);
    }

    public DataSet GetMastPaymentForConfirmation(string ConfirmUserID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@ConfirmUserID", ConfirmUserID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetMastPaymentForConfirmation", param);
    }

    public DataSet ModifySendConfirmationData(string SendToForConfirmation, string SendByConfirmation, int ID, string VerifiedByUserAccountID, string VerificationRemarks)
    {
        param = new SqlParameter[5];
        param[0] = new SqlParameter("@SendToForConfirmation", SendToForConfirmation);
        param[1] = new SqlParameter("@SendByConfirmation", SendByConfirmation);
        param[2] = new SqlParameter("@ID", ID);
        param[3] = new SqlParameter("@VerifiedByUserAccountID", VerifiedByUserAccountID);
        param[4] = new SqlParameter("@VerificationRemarks", VerificationRemarks);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifySendConfirmationData ", param);
    }

    public DataSet ModifyVerificationDetails(bool IsVerified, string VerifiedByUserAccountID, string VerificationRemark, decimal TDSAmt, decimal AmtAfterTDS, int ID)
    {
        param = new SqlParameter[6];
        param[0] = new SqlParameter("@IsVerified", IsVerified);
        param[1] = new SqlParameter("@VerifiedByUserAccountID", VerifiedByUserAccountID);
        param[2] = new SqlParameter("@VerificationRemark", VerificationRemark);
        param[3] = new SqlParameter("@TDSAmt", TDSAmt);
        param[4] = new SqlParameter("@AmtAfterTDS", AmtAfterTDS);
        param[5] = new SqlParameter("@ID", ID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyVerificationDetails", param);
    }

    //public DataSet ModifyVerificationDetails(bool IsVerified, string VerifiedByUserAccountID, String VerificationRemark, int ID)
    //{
    //    param = new SqlParameter[4];
    //    param[0] = new SqlParameter("@IsVerified", IsVerified);
    //    param[1] = new SqlParameter("@VerifiedByUserAccountID", VerifiedByUserAccountID);
    //    param[2] = new SqlParameter("@VerificationRemark", VerificationRemark);
    //    param[3] = new SqlParameter("@ID", ID);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyVerificationDetails", param);
    //}

    public DataSet GetMastPaymentForVerify(string Type, int DepID, DateTime? FromDate, DateTime? ToDate)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@Type", Type);
        param[1] = new SqlParameter("@DepID", DepID);
        param[2] = new SqlParameter("@FromDate", FromDate);
        param[3] = new SqlParameter("@ToDate", ToDate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetMastPaymentForVerify", param);
    }

    //public DataSet ModifyConfirmation(bool IsConfirm, string ConfirmationByAccountID, int PT_ID, string ConfirmationRemarks)
    //{
    //    param = new SqlParameter[4];
    //    param[0] = new SqlParameter("@IsConfirm", IsConfirm);
    //    param[1] = new SqlParameter("@ConfirmationByAccountID", ConfirmationByAccountID);
    //    param[2] = new SqlParameter("@PT_ID", PT_ID);
    //    param[3] = new SqlParameter("@ConfirmationRemarks", ConfirmationRemarks);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyConfirmation", param);
    //}


    public DataSet InsertFundStatusByUTRData(string LoanID, DateTime? DisbursementDate, DateTime? DateOfInitiate, string UTRNo, string CreditDate,
        string PaymentStatus, string FundStatus, string ReasonOfHoldFund, string BranchID, string InsertUserAccountID)
    {
        DataSet dss = new DataSet();
        param = new SqlParameter[10];
        param[0] = new SqlParameter("@LoanID", LoanID);
        param[1] = new SqlParameter("@DisbursementDate", DisbursementDate);
        param[2] = new SqlParameter("@DateOfInitiate", DateOfInitiate);
        param[3] = new SqlParameter("@UTRNo", UTRNo);
        param[4] = new SqlParameter("@CreditDate", CreditDate);
        param[5] = new SqlParameter("@PaymentStatus", PaymentStatus);
        param[6] = new SqlParameter("@FundStatus", FundStatus);
        param[7] = new SqlParameter("@ReasonOfHoldFund", ReasonOfHoldFund);
        param[8] = new SqlParameter("@BranchID", BranchID);
        param[9] = new SqlParameter("@InsertUserAccountID", InsertUserAccountID);
        return dss = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_InsertFundStatusByUTRData", param);
    }

    public DataSet BulkUploadUTR(DateTime FromDate, DateTime ToDate)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@ToDate", ToDate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_BulkUploadUTR", param);
    }


    public DataSet ModifyRecommendSend(string RecommendationSendBy, string RecommendationSendTo, string RecommendRemarks,
            int PT_ID, string PT_IsApproved, string PT_IsApprovedby, string ApprovedRemarks, string IsRecommended)
    {
        param = new SqlParameter[8];
        param[0] = new SqlParameter("@RecommendationSendBy", RecommendationSendBy);
        param[1] = new SqlParameter("@RecommendationSendTo", RecommendationSendTo);
        param[2] = new SqlParameter("@RecommendRemarks", RecommendRemarks);
        param[3] = new SqlParameter("@PT_ID", PT_ID);
        param[4] = new SqlParameter("@PT_IsApproved", PT_IsApproved);
        param[5] = new SqlParameter("@PT_IsApprovedby", PT_IsApprovedby);
        param[6] = new SqlParameter("@ApprovedRemarks", ApprovedRemarks);
        param[7] = new SqlParameter("@IsRecommended", IsRecommended);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyRecommendSend ", param);
    }

    public DataSet ApprovalFlow(DateTime FROMDATE, DateTime TODATE, string EMPCODE, string Region, decimal EnterAmount, int DepID)
    {
        param = new SqlParameter[6];
        param[0] = new SqlParameter("@FROMDATE", FROMDATE);
        param[1] = new SqlParameter("@TODATE", TODATE);
        param[2] = new SqlParameter("@EMPCODE", EMPCODE);
        param[3] = new SqlParameter("@Region", Region);
        param[4] = new SqlParameter("@EnterAmount", EnterAmount);
        param[5] = new SqlParameter("@DepID", DepID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ApprovalFlow", param);
    }

    public DataSet GetMastPaymentForConfirmationRecommend(string RecommendUserID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@RecommendUserID", RecommendUserID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetMastPaymentForConfirmationRecommend", param);
    }

    public DataSet ModifyVendorStatus(string Type, int VendorID, string V_RejectReason)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@Type", Type);
        param[1] = new SqlParameter("@VendorID", VendorID);
        param[2] = new SqlParameter("@V_RejectReason", V_RejectReason);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyVendorStatus", param);
    }

    public DataSet GetVendorTrackDetails(int DepID, string UserID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@DepID", DepID);
        param[1] = new SqlParameter("@LoginID", UserID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetVendorTrackDetails ", param);
    }

    public DataSet VerificationExportData(int IsVerified)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@IsVerified", IsVerified);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_VerificationExportData", param);
    }

    public DataSet ModifyRecommendSendFinal(string FinalRecommendationSendBy, string FinalRecommendationSendTo, string FinalRecommendRemarks,
             string ConfirmationByAccountID, string ConfirmationRemarks, int IsFinalRecommended, int PT_ID)

    {
        param = new SqlParameter[8];
        param[0] = new SqlParameter("@FinalRecommendationSendBy", FinalRecommendationSendBy);
        param[1] = new SqlParameter("@FinalRecommendationSendTo", FinalRecommendationSendTo);
        param[2] = new SqlParameter("@FinalRecommendRemarks", FinalRecommendRemarks);
        param[4] = new SqlParameter("@ConfirmationByAccountID", ConfirmationByAccountID);
        param[5] = new SqlParameter("@ConfirmationRemarks", ConfirmationRemarks);
        param[6] = new SqlParameter("@IsFinalRecommended", IsFinalRecommended);
        param[7] = new SqlParameter("@PT_ID", PT_ID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyRecommendSendFinal ", param);
    }


    public DataSet GetMastPaymentForFinalConfirmationRecommend(string FinalRecommendUserID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@FinalRecommendUserID", FinalRecommendUserID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetMastPaymentForFinalConfirmationRecommend", param);
    }

    public DataSet ModifyConfirmationFinal(bool IsFinalConfirm, string FinalConfirmationByAccountID, int PT_ID, string FinalConfirmationRemarks)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@IsFinalConfirm", IsFinalConfirm);
        param[1] = new SqlParameter("@FinalConfirmationByAccountID", FinalConfirmationByAccountID);
        param[2] = new SqlParameter("@PT_ID", PT_ID);
        param[3] = new SqlParameter("@FinalConfirmationRemarks", FinalConfirmationRemarks);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyConfirmationFinal", param);
    }

    public DataSet ModifyHoldData(string HoldBy, string HoldRemarks, int ID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@HoldBy", HoldBy);
        param[1] = new SqlParameter("@HoldRemarks", HoldRemarks);
        param[2] = new SqlParameter("@ID", ID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyHoldData ", param);
    }

    public DataSet GetMastVerificatioForHold(string CreatorID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@CreatorID", CreatorID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetMastVerificatioForHold", param);
    }

    public DataSet ModifyHold_SendForVerificationAgainByCreator(string CreatorRemarksForVerify, int ID, string File)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@CreatorRemarksForVerify", CreatorRemarksForVerify);
        param[1] = new SqlParameter("@ID", ID);
        param[2] = new SqlParameter("@File", File);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyHold_SendForVerificationAgainByCreator", param);
    }

    public DataSet GetMastVerificatioForHoldView(int DepID) // need to update
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@DepID", DepID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetMastVerificatioForHoldView", param);
    }

    public DataSet usp_TrackStatusFilter(string UserCode, int DeptID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@UserCode", UserCode);
        param[1] = new SqlParameter("@DeptID", DeptID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_TrackStatusFilter", param);
    }

    //Ishan Procedures
    public DataSet mmf_GetEmailByDepartmentID(int DepID) 
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@DeptID", DepID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_GetEmailByDepartmentID", param);
    }

    public DataSet InsertBranchData(string BranchCode, string BranchName, string CLUSTER_ID, string CLUSTER_NAME, string Address)
    {
        param = new SqlParameter[5];
        param[0] = new SqlParameter("@BranchCode", BranchCode);
        param[1] = new SqlParameter("@BranchName", BranchName);
        param[2] = new SqlParameter("@CLUSTER_ID", CLUSTER_ID);
        param[3] = new SqlParameter("@CLUSTER_NAME", CLUSTER_NAME);
        param[4] = new SqlParameter("@Address", Address);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_InsertBranchMasterData", param);
    }
    public DataSet RegionDetails()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "RegionData");
    }
    public DataSet GetBranchDetails()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmfGetBranchDetails");
    }

    public DataSet ModifyBranchData(string BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_ModifyBranchData", param);
    }

}