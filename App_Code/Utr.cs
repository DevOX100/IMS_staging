using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Utr
/// </summary>
public class Utr : db
{
    
    DataSet ds;
    SqlParameter[] param;
    public string BranchCode { get; set; }
    public string Password { get; set; }

    public DataSet GetBranchLoginDetails(string UserName, string Password)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@BranchCode", UserName);
        param[1] = new SqlParameter("@Password", Password);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetBranchLoginDetails", param);
        return ds;
    }
}