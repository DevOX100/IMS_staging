
using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Trainning
/// </summary>
public class Trainning:db
{
    DataTable dt;
    SqlParameter[] param;
    
    public DataTable GETTRAINNING_FEEDBACK(DateTime FromDate, DateTime ToDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("GETTRAINNING_FEEDBACK", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 300;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@Todate", ToDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }
}