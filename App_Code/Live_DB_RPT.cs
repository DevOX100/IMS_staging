using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Live_DB_RPT
/// </summary>
public class Live_DB_RPT: Live_DB_RPT_Config
{

    DataTable ds;
    SqlParameter[] param;


    public DataTable mmf_LBD_credit(DateTime FromDate) //LBD credit live
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_LBD_credit", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        //cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable mmfLBDCreditNew(DateTime FromDate, DateTime ToDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_mmfLBDCreditNew", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@Fromdate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable MMF_EQ(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_EQ", con);
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

    public DataTable MMF_Disbursement_verification_report(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_Disbursement_verification_report", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@Fromdate", FromDate);
        //cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }


    public DataTable mmf_Cashless_CollectionDetail(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_Cashless_CollectionDetail", con);
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

    public DataTable mmf_DailySMS(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_DailySMS", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable MMF_TAB_LOGIN(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_TAB_LOGIN", con);
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

    public DataTable MMF_ODCollection_Audit(DateTime FromDate, DateTime ToDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_MMF_ODCollection_Audit", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@fromdate", FromDate);
        cmd.Parameters.AddWithValue("@todate", ToDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable LoanClosedReport_Audit(DateTime FromDate, DateTime ToDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_LoanClosedReport_Audit", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable Payment_reversal_audit(DateTime FromDate, DateTime ToDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_Payment_reversal_audit", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable mmf_TAT_Monitoring(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_TAT_Monitoring", con);
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

    public DataTable MMF_Cattle_Insurance(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_Cattle_Insurance", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@date", FromDate);
        cmd.Parameters.AddWithValue("@date1", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable MMF_Aditya_Birla_Hospicash(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_Aditya_Birla_Hospicash", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@date", FromDate);
        cmd.Parameters.AddWithValue("@date1", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable MMF_ICIC_Lomard_Hospicash(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_ICIC_Lomard_Hospicash", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@date", FromDate);
        cmd.Parameters.AddWithValue("@date1", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable MMF_INS(DateTime FromDate, DateTime ToDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_INS", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@date", FromDate);
        cmd.Parameters.AddWithValue("@date1", ToDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable MMF_IMPSUPLOAD(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_IMPSUPLOAD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }

    public DataTable mmf_CashlessFinalDisbursement(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_CashlessFinalDisbursement", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }

    public DataTable mmf_CollectionDetail(DateTime FromDate, DateTime Todate) //Collection Details
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


    public DataTable mmf_DVC(DateTime FromDate, DateTime Todate) //Demand VS Collection Live
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_DVC", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 36000;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }

    public DataTable MMF_MSME_NEFT(DateTime FromDate, DateTime Todate, string BranchID, string Flag)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@Todate", Todate);
        param[2] = new SqlParameter("@BranchID", BranchID);
        param[3] = new SqlParameter("@MLSI_Flag", Flag);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_MSME_NEFT", param).Tables[0];
    }

    public DataSet mmf_CBData(string LoanID)
    {
        DataSet dss = new DataSet();
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@LoanID", LoanID);
        return dss = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_mmf_CBData", param);
    }

    public DataTable CICData_Address_new_Daily()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_CICData_Address_new_Daily", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable CICData_Account_new_Daily()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_CICData_Account_new_Daily", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable CICData_Member_New_Daily()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_CICData_Member_New_Daily", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable MiscFinalDisbAccounts(DateTime FromDate, DateTime Todate) //Demand VS Collection Live
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_MiscFinalDisbAccounts", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 36000;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }
}