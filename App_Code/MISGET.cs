using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;


public class MISGET: db
{
    DataSet ds;
    SqlParameter[] param;
    public MISGET()
    {
    }
    public DataSet MIS_GETTrackerEntry(DataTable dt, String GetInsertUserID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@dt", dt);
        param[1] = new SqlParameter("@GetInsertUserID", GetInsertUserID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MIS_GETTrackerEntry", param);
    }
    public DataSet ViewGETTrackerEntryByBranch(int BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "SELECT GetaDate,RegionName,DivisionName,ClusterName,BranchID,COName,COID,TypeofGet,BatchNo,CentreName,CentreID,TypeofCentre,GroupNo,TypeofGroup,GetDoneBy,ProductApplied,AppliedAmount,DisbursementDate,GroupCordinatorName,GroupCordinatorContactNo,StatusofGetEntry FROM MISGetTrackerDB where BranchID=@BranchID", param);
    }
    public DataSet ViewGETTrackerEntry(int GetInsertUserID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@GetInsertUserID", GetInsertUserID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "SELECT GetaDate,RegionName,DivisionName,ClusterName,BranchID,COName,COID,TypeofGet,BatchNo,CentreName,CentreID,TypeofCentre,GroupNo,TypeofGroup,GetDoneBy,ProductApplied,AppliedAmount,DisbursementDate,GroupCordinatorName,GroupCordinatorContactNo,StatusofGetEntry FROM MISGetTrackerDB where convert(int,GetInsertUserID)=@GetInsertUserID", param);
    }
    public DataSet ReportGETTrackerEntry(DateTime FromDate, DateTime ToDate,int ReportType)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@ToDate", ToDate);
        param[2] = new SqlParameter("@ReportType", ReportType);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "ReportGETTrackerEntry", param);
    }
    
}