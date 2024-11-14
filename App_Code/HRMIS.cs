using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;


public class HRMIS: LocaldatabaseHRMSconnection
{
    DataTable ds;
    SqlParameter[] param;
	public HRMIS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    

 //public DataTable MMF_Master_Database_HRM(DateTime FromDate)
    //{
       // con.Open();
       // SqlCommand cmd = new SqlCommand("MMF_Master_Database_HRM", con);
       // cmd.CommandType = CommandType.StoredProcedure;
       // cmd.CommandTimeout = 1800;
       // cmd.Parameters.AddWithValue("@Date", FromDate);
       // SqlDataAdapter adapter = new SqlDataAdapter(cmd);
       // DataTable dt = new DataTable();
        //adapter.Fill(dt);
       // con.Close();
       // return dt;


    //}




//public DataTable MMF_HR_EMPLOYEE_OFFER_TRACKER(DateTime FromDate, DateTime Todate)
    // {
       // con.Open();
       // SqlCommand cmd = new SqlCommand("MMF_HR_EMPLOYEE_OFFER_TRACKER", con);
       // cmd.CommandType = CommandType.StoredProcedure;
        // cmd.CommandTimeout = 800;
        // cmd.Parameters.AddWithValue("@Fromdate", FromDate);
        // cmd.Parameters.AddWithValue("@Todate", Todate);
        // SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        // DataTable dt = new DataTable();
        // adapter.Fill(dt);
       // con.Close();
       // return dt;
    // }


//public DataTable MMF_HR_EMPLOYEE_OFFER_TRACKER(DateTime FromDate)
   // {
        //con.Open();
        //SqlCommand cmd = new SqlCommand("MMF_HR_EMPLOYEE_OFFER_TRACKER", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.CommandTimeout = 1800;
        //cmd.Parameters.AddWithValue("@Date", FromDate);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
       // DataTable dt = new DataTable();
        //adapter.Fill(dt);
        //con.Close();
        //return dt;


    //}



// public DataTable MMF_HR_Active_EMP_List(DateTime FromDate)
    // {
         //con.Open();
       //SqlCommand cmd = new SqlCommand("MMF_HR_Active_EMP_List", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.CommandTimeout = 1800;
         //cmd.Parameters.AddWithValue("@Date", FromDate);
         //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
         //DataTable dt = new DataTable();
        //adapter.Fill(dt);
        //con.Close();
        //return dt;


   // }



}