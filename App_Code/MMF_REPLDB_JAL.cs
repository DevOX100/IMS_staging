using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MMF_REPLDB_JAL
/// </summary>
public class MMF_REPLDB_JAL : MMF_REPLDB_JAL_CONFIG
{
    DataTable ds;
    SqlParameter[] param;

    public DataTable mmf_inspro(DateTime FromDate) //Product Mapping Detail Live
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_inspro", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }

    //public DataTable mmf_DCase(DateTime FromDate, int BranchID) //Current DeathCase T-15
    //{
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("mmf_DCases", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandTimeout = 800;
    //    cmd.Parameters.AddWithValue("@Date", FromDate);
    //    cmd.Parameters.AddWithValue("@BID", BranchID);
    //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adapter.Fill(dt);
    //    con.Close();
    //    return dt;

    //}

    //public DataTable MMF_Hospicash_Intimation(DateTime FromDate) //Hospicash Info Report T-15
    //{
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("MMF_Hospicash_Intimation", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandTimeout = 3600;
    //    cmd.Parameters.AddWithValue("@Date", FromDate);
    //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adapter.Fill(dt);
    //    con.Close();
    //    return dt;
    //}

    public DataTable mmf_dintimation(DateTime AsDate) //Death Initmation Detail Live
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_dintimation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@AsDate", AsDate);

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }

    //public DataTable mmf_DeathCasePayOut(DateTime FromDate, DateTime ToDate, int BranchID) //DeathCase PayOut Details Live
    //{
    //    param = new SqlParameter[3];
    //    param[0] = new SqlParameter("@FromDate", FromDate);
    //    param[1] = new SqlParameter("@ToDate", ToDate);
    //    param[2] = new SqlParameter("@BID", BranchID);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_DeathCasePayOut", param).Tables[0];
    //}

   

   


    public DataTable MMF_DEnd(DateTime FromDate, DateTime ToDate) //Day End
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_DEnd", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@FromDate", FromDate); cmd.Parameters.AddWithValue("@ToDate", ToDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }

    //public DataTable mmf_Collection_Deletion_Rpt(DateTime FromDate, DateTime Todate) //Collection Deletion Report Live
    //{
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("mmf_Collection_Deletion_Rpt", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandTimeout = 500;
    //    cmd.Parameters.AddWithValue("@FromDate", FromDate);
    //    cmd.Parameters.AddWithValue("@Todate", Todate);
    //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adapter.Fill(dt);
    //    con.Close();
    //    return dt;
    //}

    //public DataTable mmf_Disb_Deletion_Rpt(DateTime FromDate, DateTime Todate) //Disbursement Deletion Report Live
    //{
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("mmf_Disb_Deletion_Rpt", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandTimeout = 500;
    //    cmd.Parameters.AddWithValue("@FromDate", FromDate);
    //    cmd.Parameters.AddWithValue("@Todate", Todate);
    //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adapter.Fill(dt);
    //    con.Close();
    //    return dt;
    //}

    public DataTable MMF_Arrear_Rpt_MEL(DateTime FromDate) /////MEL Arrear Report T-15
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_Arrear_Rpt_MEL", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 3600;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }


    public DataTable MMF_OS_MEL(DateTime FromDate) ///////MEL Loan Outstanding T-15
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_OS_MEL", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 3600;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }

    public DataTable rpt_MEL_demandvscollection(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("rpt_MEL_demandvscollection", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@FromDate", FromDate); cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }

    public DataTable MMF_FinalDisbursemnt(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_FinalDisbursemnt", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@FromDate", FromDate); cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }

   

    public DataTable TrailBranches(DateTime SDate, DateTime EDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_TrailBranches", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@SDate", SDate);
        cmd.Parameters.AddWithValue("@EDate", EDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable TrailBalance(bool IncludeHierarchy, DateTime SDate, DateTime EDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_TrailBalance", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@IncludeHierarchy", IncludeHierarchy);
        cmd.Parameters.AddWithValue("@SDate", SDate);
        cmd.Parameters.AddWithValue("@EDate", EDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
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

}