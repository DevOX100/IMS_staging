using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Web.UI;
using System.Collections.Generic;

/// <summary>
/// Summary description for Kit
/// </summary>
public class Kit:db
{
    DataSet ds;
    DataTable dt;
    SqlParameter[] param;
    public DataSet UploadMemberDetails(DataTable dt, int KitIssuedInsertUserID, int KitIssuedInsertRoleID)
    {
        //con.Open();
        //SqlCommand cmd = new SqlCommand("UploadMemberDetails", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //SqlParameter tvpParam = cmd.Parameters.AddWithValue("@dt", dt);
        //tvpParam.SqlDbType = SqlDbType.Structured;
        // con.Close();
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@dt", dt);
        param[1] = new SqlParameter("@KitIssuedInsertUserID", KitIssuedInsertUserID);
        param[2] = new SqlParameter("@KitIssuedInsertRoleID", KitIssuedInsertRoleID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UploadMemberDetails", param);
    }
public DataSet DeleteUploadMemberAfterAssign(string KitSerialNo, int UserID, string EntityID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@KitSerialNo", KitSerialNo);
        param[1] = new SqlParameter("@KitUpdateInsertUserID", UserID);
        param[2] = new SqlParameter("@EntityID", EntityID);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "DeleteUploadMember", param);
    }
    public DataSet KitAddStock(string KitSerialNo,string Refno, int CompanyDetailID, DateTime ReceiptDate, string ReceiptNo, int roleId, int UserAccountID, int BranchID, int AllocatedToBranchID)
    {
        param = new SqlParameter[9];
        param[0] = new SqlParameter("@KitSerialNo",KitSerialNo );
        param[1] = new SqlParameter("@CompanyDetailID", CompanyDetailID);
        param[2] = new SqlParameter("@Refno", Refno);
        param[3] = new SqlParameter("@ReceiptDate", ReceiptDate);
        param[4] = new SqlParameter("@ReceiptNo", ReceiptNo);
        param[5] = new SqlParameter("@RoleId", roleId);
        param[6] = new SqlParameter("@UserAccountID", UserAccountID);
        param[7] = new SqlParameter("@BranchID", BranchID);
        param[8] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "KitAddStock", param);
    }
  public DataSet Stock(int StockCompanyDetailID, int AllocatedToBranchID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@StockCompanyDetailID", StockCompanyDetailID);
        param[1] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Stock", param);
    }
    public DataSet KitAllocateToBranch(int AllocatedToBranchID, int AllocatedInsertUserID, int AllocatedInsertRoleID, string KitID)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);      
        param[1] = new SqlParameter("@AllocatedInsertUserID", AllocatedInsertUserID);
        param[2] = new SqlParameter("@AllocatedInsertRoleID", AllocatedInsertRoleID);
        param[3] = new SqlParameter("@KitSerialNo", KitID);
        //  param[5] = new SqlParameter("@UserAccountID", UserAccountID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "KitAllocateToBranch", param);
    }
    public DataSet KitIssuedToMember(string KitIssuedToMemberID, int KitIssuedInsertUserID, int KitIssuedInsertRoleID, string KitSerialNo,string KitMemberIDPK)
    {
        param = new SqlParameter[5];
        param[0] = new SqlParameter("@KitIssuedToMemberID", KitIssuedToMemberID);
        param[1] = new SqlParameter("@KitIssuedInsertUserID", KitIssuedInsertUserID);
        param[2] = new SqlParameter("@KitIssuedInsertRoleID", KitIssuedInsertRoleID);
        param[3] = new SqlParameter("@KitSerialNo", KitSerialNo);
        param[4] = new SqlParameter("@KitMemberIDPK", KitMemberIDPK);
        //param[5] = new SqlParameter("@KitMemberName", KitMemberName);
        //param[6] = new SqlParameter("@KitMemberSpouseName", KitMemberSpouseName);
        //  param[5] = new SqlParameter("@UserAccountID", UserAccountID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "KitIssuedToMember", param);
    }
    public DataSet KitReIssuedToMember(int KitIssuedInsertUserID, int KitIssuedInsertRoleID, string KitSerialNo, string KitIssuedToMemberID,string Remark,string GroupID,string CenterID,DateTime DisbursementDate)
    {
        param = new SqlParameter[8];
        param[0] = new SqlParameter("@KitIssuedInsertUserID", KitIssuedInsertUserID);
        param[1] = new SqlParameter("@KitIssuedInsertRoleID", KitIssuedInsertRoleID);
        param[2] = new SqlParameter("@KitSerialNo", KitSerialNo);
        param[3] = new SqlParameter("@KitIssuedToMemberID",KitIssuedToMemberID);
        param[4] = new SqlParameter("@KitRemark", Remark);
        param[5] = new SqlParameter("@GroupID", GroupID);
        param[6] = new SqlParameter("@CenterID", CenterID);
        param[7] = new SqlParameter("@DisbursementDate", DisbursementDate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "KitReIssuedToMember", param);
    }   
    public DataSet KitViewDetailInHO()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from dbo.MasterKit WHERE  KitStatus LIKE 'Disable' AND KitState LIKE 'Inactive'");
    }
     public DataSet KitIssueMemberDetail(int AllocatedToBranchID,int SupplierID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        param[1] = new SqlParameter("@SupplierID", SupplierID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select  * from dbo.MasterKit WHERE  KitStatus LIKE 'Enable' AND	KitState LIKE 'Inactive' AND AllocatedToBranchID=@AllocatedToBranchID and  StockCompanyDetailID=@SupplierID  ORDER BY StockReceiptDate, KitSerialNo ASC", param);
    }
    public DataSet KitViewIssueMemberDetail(int AllocatedToBranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from dbo.MasterKit inner join MemberDetailUpload on kitNo=KitSerialNo  WHERE  KitStatus LIKE 'Enable' AND	KitState LIKE 'active' AND AllocatedToBranchID=@AllocatedToBranchID", param);
    }
    public DataSet KitWrongIssuedMember(int AllocatedToBranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from dbo.MasterKit inner join MemberDetailUpload on kitNo=KitSerialNo AND EntityId=KitIssuedToMemberID WHERE  KitStatus LIKE 'Enable' AND	KitState LIKE 'Active' AND AllocatedToBranchID=@AllocatedToBranchID and KitStage !=5 and Is_IssuedToMember=0 ORDER BY KitSerialNo", param);
    }
    public DataSet KitIssuedMemberWithoutCancel(int AllocatedToBranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from dbo.MasterKit inner join MemberDetailUpload on kitNo=KitSerialNo AND EntityId=KitIssuedToMemberID WHERE  KitStatus LIKE 'Enable' AND	KitState LIKE 'Active' AND AllocatedToBranchID=@AllocatedToBranchID and KitStage !=5 and Is_IssuedToMember=0 and Remark is null   ORDER BY CentreID,	GroupID", param);
    }
    public DataSet KitIssuedMemberWithoutCancelFilter(int AllocatedToBranchID, DateTime DisbursementDate, int StockCompanyDetailID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        param[1] = new SqlParameter("@DisbursementDate", DisbursementDate);
        param[2] = new SqlParameter("@StockCompanyDetailID", StockCompanyDetailID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from dbo.MasterKit inner join MemberDetailUpload on kitNo=KitSerialNo AND EntityId=KitIssuedToMemberID WHERE  KitStatus LIKE 'Enable' AND	KitState LIKE 'Active' AND AllocatedToBranchID=@AllocatedToBranchID and KitStage !=5 and Is_IssuedToMember=0 and Remark is null and convert(date,DisbusementDate)=@DisbursementDate  and StockCompanyDetailID=@StockCompanyDetailID ORDER BY KitSerialNo", param);
    }
    public DataSet KitWrongIssuedMemberDetail(int AllocatedToBranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from dbo.MasterKit inner join MemberDetailUpload on kitNo=KitSerialNo AND EntityId=KitIssuedToMemberID  WHERE  KitStatus LIKE 'Enable' AND	KitState LIKE 'Active' AND AllocatedToBranchID=@AllocatedToBranchID and KitStage !=5 and Is_IssuedToMember=0   ORDER BY KitSerialNo", param);
    }
    public DataSet KitIssuedMemberDetail(int AllocatedToBranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from dbo.MasterKit WHERE  KitStatus LIKE 'Enable' AND	KitState LIKE 'Active' AND AllocatedToBranchID=@AllocatedToBranchID",param);
    }
    public DataSet KitReIssuedMemberDetail()
    {
       
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from dbo.MasterKit WHERE  KitStatus LIKE 'Enable' AND	KitState LIKE 'Active' AND  KitStage=5", param);
    }
    public DataSet KitCompleteMemberDetail(int AllocatedToBranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from dbo.MasterKit WHERE  KitStatus LIKE 'Enable' AND	KitState LIKE 'Locked' AND AllocatedToBranchID=CASE @AllocatedToBranchID WHEN 0 THEN AllocatedToBranchID ELSE @AllocatedToBranchID END ORDER BY KitSerialNo " , param);
    }
    public DataSet KitFinalMemberDetail(int AllocatedToBranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from dbo.MasterKit WHERE  KitStatus LIKE 'Disable' AND KitState LIKE 'Locked' AND AllocatedToBranchID=CASE @AllocatedToBranchID WHEN 0 THEN AllocatedToBranchID ELSE @AllocatedToBranchID END",param);
    }
    public DataSet BranchViewByCode()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "SELECT BranchID +' / '+ BranchName as Branch,BranchID  FROM mmf_BranchSetting WHERE  IsActive=1 AND BranchID!='0000' ");
    }
    public DataSet BranchViewDetail()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "SELECT BranchID +' / '+ BranchName as Branch,BranchID,BranchName  FROM mmf_BranchSetting WHERE  IsActive=1 order by BranchName ");	
    }
    public DataSet KitAvailableByBranch(int AllocatedToBranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "KitAvailableByBranch",param);
    }
    public DataSet KitAvailableByBranchFilterDateWise(int AllocatedToBranchID,DateTime DisbursementDate,int StockCompanyDetailID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        param[1] = new SqlParameter("@DisbursementDate", DisbursementDate);
        param[2] = new SqlParameter("@StockCompanyDetailID", StockCompanyDetailID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "KitAvailableByBranchFilterDateWise", param);
    }
    public DataSet KitUpload(int AllocatedToBranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "  SELECT EntityId+ ' / '+	FirstName + ' / ' + SpouseName as EntityIdDetail,MemberID,businessId,EntityId,FirstName,SpouseName,CentreID,	GroupID,	DisbusementDate ,ModeOfDisbursement FROM MemberDetailUpload WHERE BranchID=@AllocatedToBranchID AND kitNo IS NULL ORDER BY DisbusementDate,CentreID,	GroupID desc", param);
    }
    public DataSet KitLoanCompleted(DataTable dt, int KitMemberLockedInsertUserID, int KitMemberLockedInsertRoleID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@dt", dt);
        param[1] = new SqlParameter("@KitMemberLockedInsertUserID", KitMemberLockedInsertUserID);
        param[2] = new SqlParameter("@KitMemberLockedInsertRoleID", KitMemberLockedInsertRoleID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "KitLoanCompleted", param);
    }
    public DataSet KitDamaged(string KitSerialNo, int KitMemberDamagedInsertUserID, int KitMemberDamagedInsertRoleID, string FinalKitRemark)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@KitSerialNo", KitSerialNo);
        param[1] = new SqlParameter("@KitMemberDamagedInsertUserID", KitMemberDamagedInsertUserID);
        param[2] = new SqlParameter("@KitMemberDamagedInsertRoleID", KitMemberDamagedInsertRoleID);
        param[3] = new SqlParameter("@FinalKitRemark", FinalKitRemark);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "KitDamaged", param);    
    }
    public DataSet KitPullBack(string KitSerialNo, string FinalKitRemark)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@KitSerialNo", KitSerialNo);
        param[1] = new SqlParameter("@FinalKitRemark", FinalKitRemark);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "update dbo.MasterKit set FinalKitRemark = @FinalKitRemark where KitSerialNo = @KitSerialNo AND KitStage IN (3,4)", param);
    }
    public DataSet KitSearch(string KitSerialNo,int BranchID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@KitSerialNo", KitSerialNo); param[1] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "KitSearch", param);
    }
    public DataSet KitSearchMember(string MEMBER)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@MEMBER", MEMBER);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "KitSearchMember", param);
    }
    public DataSet test()
    {
        param = new SqlParameter[0];
        //param[0] = new SqlParameter("@KitSerialNo", KitSerialNo);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select KitSerialNo,KitIssuedToMemberID from MasterKit where KitStage=3");
    }
    public DataSet KitMemberDeatilUpdate(string KitSerialNo,int UserID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@KitSerialNo", KitSerialNo);
        param[1] = new SqlParameter("@KitUpdateInsertUserID", UserID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "KitMemberDeatilUpdate", param);
    }
    public DataSet KitCountIHO()
    {
        //param = new SqlParameter[1];
        //param[0] = new SqlParameter("@KitSerialNo", KitSerialNo);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "SELECT * FROM vw_Count");
    }
    public DataSet KitCountByBranchID(int AllocatedToBranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, " select COUNT(AllocatedToBranchID) as [Issued],COUNT(KitIssuedToMemberID) [Assigned To Member],Count(Is_IssuedInsertDate) [Issued To Member], Available=(COUNT(AllocatedToBranchID)-COUNT(KitIssuedToMemberID)),COUNT(KitMemberLockedInsertUserID) as [Completed Kit],[Active Kit]=(COUNT(Is_IssuedInsertDate)-COUNT(KitMemberLockedInsertUserID)), COUNT(KitMemberDamagedInsertUserID) as [Damaged Kit]  from dbo.MasterKit where AllocatedToBranchID=@AllocatedToBranchID", param);
    }
      public DataSet Kit_Reports(DateTime  FromDate, DateTime  ToDate, int ReportType,int AllocatedToBranchID,int StockSupplierID)
    {
        param = new SqlParameter[5];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@ToDate", ToDate);
        param[2] = new SqlParameter("@ReportType", ReportType);
        param[3] = new SqlParameter("@AllocatedToBranchID", @AllocatedToBranchID);
        param[4] = new SqlParameter("@StockCompanyDetailID", @StockSupplierID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "KitReportDetail", param);
    }
    public DataSet KitSuppilerWiseDetail(DateTime FromDate, DateTime ToDate, int StockCompanyDetailID, int AllocatedToBranchID)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@ToDate", ToDate);
        param[2] = new SqlParameter("@StockCompanyDetailID", StockCompanyDetailID);
        param[3] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "KitSuppilerWiseDetail", param);
    }
    public DataSet Kit_ReportsAllocatedToMember(DateTime FromDate, DateTime ToDate)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@ToDate", ToDate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from MasterKit where KitIssuedInsertedDate between @FromDate and @ToDate", param);
    }
    public DataSet Kit_ReportsComplete(DateTime FromDate, DateTime ToDate)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@ToDate", ToDate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from MasterKit where KitMemberLockedInsertDate between @FromDate and @ToDate", param);
    }
    public DataSet KitSwitchToNextBranch(int AllocatedToBranchID, int AllocatedInsertUserID, int AllocatedInsertRoleID, string KitSerialNo)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        param[1] = new SqlParameter("@AllocatedInsertUserID", AllocatedInsertUserID);
        param[2] = new SqlParameter("@AllocatedInsertRoleID", AllocatedInsertRoleID);
        param[3] = new SqlParameter("@KitSerialNo", KitSerialNo);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "KitSwitchToNextBranch", param);
    }
    public DataSet IsIssued(string KitSerialNo,int KitIssuedUserID, string Remark,string AdhaarCardURL, string ApplicationFormUrl, string AdhaarCardURLActual, string ApplicationFormUrlActual)
    {
        param = new SqlParameter[7];
        param[0] = new SqlParameter("@KitSerialNo", KitSerialNo);
        param[1] = new SqlParameter("@KitIssuedUserID", KitIssuedUserID);
        param[2] = new SqlParameter("@Remark", Remark);
        param[3] = new SqlParameter("@AdhaarCardURL", AdhaarCardURL);
        param[4] = new SqlParameter("@ApplicationFormUrl", ApplicationFormUrl);
        param[5] = new SqlParameter("@AdhaarCardURLActual", AdhaarCardURLActual);
        param[6] = new SqlParameter("@ApplicationFormUrlActual", ApplicationFormUrlActual);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "FinalIssuedToMember", param);
    }
    public DataSet IsCancelDisbursement(string kitNo, string Remark)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@kitNo", kitNo);
        param[1] = new SqlParameter("@Remark", Remark);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "update MemberDetailUpload set Remark=@Remark where kitNo=@kitNo", param);
    }
    public DataSet KitIssuedMemberDetailByBranch(int AllocatedToBranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from dbo.MasterKit inner join MemberDetailUpload  on kitNo=KitSerialNo AND EntityId=KitIssuedToMemberID  WHERE  KitStatus LIKE 'Enable' AND	KitState LIKE 'Active' AND AllocatedToBranchID=@AllocatedToBranchID and KitStage !=5 and is_IssuedToMember=1  ORDER BY KitSerialNo", param);
    }
    public DataSet UploadMemberDetail(DataTable dt)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@dt", dt);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UploadMemberDetail", param);
    }
    public DataSet Upload_MemberDetail(DataTable dt,int MemberDetailInsertUserID,int MemberDetailInsertRoleID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@dt", dt);
        param[1] = new SqlParameter("@MemberDetailInsertUserID", MemberDetailInsertUserID);
        param[2] = new SqlParameter("@MemberDetailInsertRoleID", MemberDetailInsertRoleID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Upload_MemberDetail", param);
    }
    public DataSet GETUploadMemberDetail()
    {
        
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from MemberDetailUpload WHERE kitNo IS NULL ORDER BY CentreID,GroupID");
    }
    public DataSet GETUploadMemberDetailUnique(DataTable dt)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@dt", dt);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UploadMemberHighLightReUsedKit",param);
    }
    public DataSet GETUploadMemberDetailFilter(DateTime DisbusementDate,int BranchID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@DisbusementDate", DisbusementDate);
        param[1] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from MemberDetailUpload WHERE kitNo IS NULL and DisbusementDate=@DisbusementDate and BranchID=@BranchID ORDER BY CentreID,GroupID", param);
    }
     public DataSet DeleteUploadMember( string EntityID, string MemberID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@EntityID", EntityID);
        param[1] = new SqlParameter("@MemberID", MemberID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "delete from MemberDetailUpload WHERE EntityID=@EntityID and MemberID=@MemberID", param);
    }
    public DataSet GraphAvailableCards(int BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GraphAvailable", param);
    }
    public DataTable LINQResultToDataTable<T>(IEnumerable<T> Linqlist)
    {
        DataTable dt = new DataTable();


        PropertyInfo[] columns = null;

        if (Linqlist == null) return dt;

        foreach (T Record in Linqlist)
        {

            if (columns == null)
            {
                columns = ((Type)Record.GetType()).GetProperties();
                foreach (PropertyInfo GetProperty in columns)
                {
                    Type colType = GetProperty.PropertyType;

                    if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()== typeof(Nullable<>)))
                    {
                        colType = colType.GetGenericArguments()[0];
                    }

                    dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
                }
            }

            DataRow dr = dt.NewRow();

            foreach (PropertyInfo pinfo in columns)
            {
                dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                (Record, null);
            }

            dt.Rows.Add(dr);
        }
        return dt;
    }
    public DataSet CheckDuplicateKits(DataTable dt)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@dt", dt);
       
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "CheckDuplicateKits", param);
    }
    public DataSet kitSerailUpload(DataTable dt, int CompanyDetailID, DateTime ReceiptDate, string ReceiptNo, int roleId, int UserAccountID)
    {
        param = new SqlParameter[6];
        param[0] = new SqlParameter("@dt", dt);
        param[1] = new SqlParameter("@ReceiptDate", ReceiptDate); param[2] = new SqlParameter("@CompanyDetailID", CompanyDetailID);
        param[3] = new SqlParameter("@ReceiptNo", ReceiptNo);
        param[4] = new SqlParameter("@RoleId", roleId);
        param[5] = new SqlParameter("@UserAccountID", UserAccountID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "UploadKits", param);
    }
    public DataSet DamagedKits(int BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "SELECT KitSerialNo [Old Kit],	Refno,KitIssuedToMemberID [Entity],KitMemberName [Member Name],	KitMemberSpouseName [SpouseName],FinalKitRemark [Remark],AllocatedToBranchID [Branch Code],CASE  WHEN KitMemberDamagedInsertDate IS NULL THEN 'PullBack' else 'Damaged' end AS [Status],Is_IssuedInsertDate [Issued Date],KitMemberDamagedInsertDate [Damaged Date] FROM MasterKit WHERE FinalKitRemark is not null and AllocatedToBranchID=CASE @BranchID WHEN 0 THEN AllocatedToBranchID ELSE @BranchID END order by  KitSerialNo", param);
    }
    public DataSet GropuWiseMember(int BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "SELECT COUNT(EntityId) [NoOfMember],BranchID,CentreID,	GroupID,DisbusementDate FROM [dbo].[MemberDetailUpload] WHERE  CONVERT(int, BranchID)= @BranchID  AND kitNo IS NOT NULL   GROUP BY BranchID,CentreID,	GroupID,DisbusementDate", param);
    }
    public DataSet DeleteGropuWiseMember(int BranchID, string GroupID, string CentreID, DateTime date)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@BranchID", BranchID);
        param[1] = new SqlParameter("@GroupID", GroupID);
        param[2] = new SqlParameter("@CentreID", CentreID);
        param[3] = new SqlParameter("@date", date);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "DELETE FROM [MemberDetailUpload] WHERE BranchID=@BranchID AND	CentreID=@CentreID	AND GroupID=@GroupID AND DisbusementDate=@date", param);
    }
    public DataSet KitNotFinalIssued(string KitSerialNo, int KitIssuedUserID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@KitSerialNo", KitSerialNo);
        param[1] = new SqlParameter("@KitIssuedUserID", KitIssuedUserID);
       // param[2] = new SqlParameter("@KitMemberLockedInsertRoleID", KitMemberLockedInsertRoleID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "NotFinalIssuedToMember", param);
    }
   public DataSet Available()
    {
        param = new SqlParameter[0];
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select KitSerialNo,BranchName AS Branch,SupplierName,StockReceiptDate,KitIssuedToMemberID from dbo.MasterKit INNER JOIN mmf_BranchSetting (nolock)  on BranchID=AllocatedToBranchID INNER JOIN mmf_CompanyDetail  on CompanyID=StockCompanyDetailID  where  KitMemberDamagedInsertUserID IS NULL AND KitMemberLockedInsertDate IS NULL order by StockReceiptDate", param);
    }
 public DataSet AvailableGraph()
    {
        param = new SqlParameter[0];
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select KitSerialNo,BranchName AS Branch,BranchID,SupplierName,KitIssuedToMemberID [MemberID],KitMemberName [Member Name], KitMemberSpouseName [Spouse],KitIssuedInsertedDate [Assigned] from dbo.MasterKit INNER JOIN mmf_BranchSetting (nolock)  on BranchID=AllocatedToBranchID INNER JOIN mmf_CompanyDetail  on CompanyID=StockCompanyDetailID  where  KitMemberDamagedInsertUserID IS NULL AND Is_IssuedInsertDate IS NULL", param);
    }
public DataSet GraphAvailableSupplierWise(int BranchID,int StockCompanyDetailID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@BranchID", BranchID);
        param[1] = new SqlParameter("@StockCompanyDetailID", StockCompanyDetailID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GraphAvailableSupplierWise", param);
    }
 public DataSet CheckDuplicateKitsHightlight(DataTable dt)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@dt", dt);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "CheckDuplicateKitsHightlight", param);
    }

    public DataSet sp_BindCallDispositionFileName()
    {
        param = new SqlParameter[0];
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "sp_BindCallDispositionFileName", param);
    }
    public DataTable WEB_CALL_DISP(string cols, string query, int FIle)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@cols", cols);
        param[1] = new SqlParameter("@query", query);
        param[2] = new SqlParameter("@FIle", FIle);
        return dt = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "WEB_CALL_DISP", param).Tables[0];
    }


public DataTable  mmf_tms_detailed(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_tms_detailed", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

public DataTable  mmf_tms_summarry(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_tms_summarry", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }




}