using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;




/// <summary>
/// Summary description for MMFReport
/// </summary>
public class MMF_RPD:MMFREPL
{
    DataTable ds;
    SqlParameter[] param;
     
    public  MMF_RPD()
	{
		//
		// TODO: Add constructor logic here
		//
	}
 
   
  
public DataTable mmf_Collection_Account(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_Collection_Account", con);
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

 public DataTable MMF_LOANID_OS(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_LOANID_OS", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }
 
public DataTable mmf_CenterDetails(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_CenterDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }




 public DataTable mml_MEl_demand(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mml_MEl_demand", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@FromDate", FromDate); cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }

 public DataTable MML_Arrear_Report_RPDB(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MML_Arrear_Report_RPDB", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 3600;
        cmd.Parameters.AddWithValue("@Date", FromDate); 
        //cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }

 public DataTable MMF_MSME_SNACH(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_MSME_SNACH", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@FromDate", FromDate); cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }


 public DataTable MMF_OS_MIS(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_OS_MIS", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 3600;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }
  

    public DataTable MMF_Arrear_rpt(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_Arrear_rpt", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 3600;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }


    //public DataTable rpt_RMU_demandvscollection(DateTime FromDate)
    //{
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("rpt_RMU_demandvscollection", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandTimeout = 3600;
    //    cmd.Parameters.AddWithValue("@FromDate", FromDate);
    //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adapter.Fill(dt);
    //    con.Close();
    //    return dt;


    //}


    public DataTable mmf_negativeemi(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_negativeemi", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@fromdate", FromDate); cmd.Parameters.AddWithValue("@todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }

    public DataTable mmf_gocollect(DateTime Date)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_gocollect", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 3600;
        cmd.Parameters.AddWithValue("@Date", Date);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }

    //public DataTable MMF_DEnd(DateTime FromDate, DateTime ToDate)
    //{
    //    con2.Open();
    //    SqlCommand cmd = new SqlCommand("MMF_DEnd", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandTimeout = 500;
    //    cmd.Parameters.AddWithValue("@FromDate", FromDate); cmd.Parameters.AddWithValue("@ToDate", ToDate);
    //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adapter.Fill(dt);
    //    con2.Close();
    //    return dt;

    //}

}