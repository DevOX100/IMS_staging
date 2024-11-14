using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;




/// <summary>
/// Summary description for MMFReport
/// </summary>
public class HRMS_LIVE:HRMSLIVE
{
    DataTable ds;
    SqlParameter[] param;
     
    public  HRMS_LIVE()
	{
		//
		// TODO: Add constructor logic here
		//
	}
 
   
 public DataTable MMF_Master_Database_HRM(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_Master_Database_HRM", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1800;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }

public DataTable MMF_HR_Joining_rpt(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_HR_Joining_rpt", con);
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

public DataTable MMF_HR_EMPLOYEE_OFFER_TRACKER(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_HR_EMPLOYEE_OFFER_TRACKER", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1800;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }

public DataTable MMF_HR_Active_EMP_List(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_HR_Active_EMP_List", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1800;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }


public DataTable mmf_HRMS_INSURANCE(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_HRMS_INSURANCE", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1800;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }
public DataTable mmf_Hrm_INsurance_2(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_Hrm_INsurance_2", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1800;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }


}