using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1 : DatabaseConnection
{
    DataSet ds;
    SqlParameter[] param;
	public Class1()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet rc_TrialBalance1(string FBranchID, string TBranchID, DateTime FromDate, DateTime ToDate, int BankID = 19)
    {
        param = new SqlParameter[5];
        param[0] = new SqlParameter("@FromRegionID", FBranchID);
        param[1] = new SqlParameter("@ToRegionID", TBranchID);
        param[2] = new SqlParameter("@FromDate", FromDate);
        param[3] = new SqlParameter("@ToDate", ToDate);
        param[4] = new SqlParameter("@BankID", BankID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "rc_TrialBalance1", param);
    }
}