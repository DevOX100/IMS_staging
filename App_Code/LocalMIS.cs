using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;


public class LocalMIS : LocalConnection
{
    DataTable ds;
    SqlParameter[] param;
	public LocalMIS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   // public DataTable MMF_PreMidland(DateTime FromDate)
    //{
       // param = new SqlParameter[2];
       // param[0] = new SqlParameter("@FromDate", FromDate);
        //param[1] = new SqlParameter("@Todate", Todate);
       // return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_PreMidland", param).Tables[0];
    //}
    public DataTable MMF_PreMidland(DateTime FromDate)
 {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_PreMidland", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
       // cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }
    public DataTable MMF_SWMDisbursement(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_SWMDisbursement", con);
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
    public DataTable MMF_COD(DateTime FromDate, DateTime Todate, string BranchID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@Todate", Todate);
        param[2] = new SqlParameter("@BID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_COD", param).Tables[0];
    }
    public DataTable mmf_wplDisbursement(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_wplDisbursement", con);
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
    public DataTable mmf_DeathCasePayOut(DateTime FromDate, DateTime ToDate, int BranchID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@ToDate", ToDate);
        param[2] = new SqlParameter("@BID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_DeathCasePayOut", param).Tables[0];
    }
    public DataTable mmf_SunKingDisbursement(DateTime FromDate, DateTime Todate)
    {

        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_SunKingDisbursement", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
        //param = new SqlParameter[2];
        //param[0] = new SqlParameter("@FromDate", FromDate);
        //param[1] = new SqlParameter("@Todate", Todate);
        //return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_SunKingDisbursement", param).Tables[0];
    }
    
   
    public DataTable MMF_BIMA(DateTime FromDate, DateTime ToDate, int BranchID)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_BIMA", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 300;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@Todate", ToDate);
        cmd.Parameters.AddWithValue("@BID", BranchID);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }
   
    public DataTable MMF_ABPS(DateTime FromDate, DateTime ToDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_ABPS", con);
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
    public DataTable mmf_Mobility(DateTime FromDate, DateTime Todate)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@date", FromDate);
        param[1] = new SqlParameter("@date1", Todate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_Mobility", param).Tables[0];
    }
    //public DataTable MMF_CL(DateTime FromDate, DateTime Todate, string BranchID)
    //{
    //    param = new SqlParameter[3];
    //    param[0] = new SqlParameter("@FromDate", FromDate);
    //    param[1] = new SqlParameter("@Todate", Todate);
    //    param[2] = new SqlParameter("@BranchID", BranchID);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_CL", param).Tables[0];
    //}
    //public DataTable MMF_EQ(DateTime FromDate, DateTime Todate)
    //{
    //    param = new SqlParameter[2];
    //    param[0] = new SqlParameter("@FromDate", FromDate);
    //    param[1] = new SqlParameter("@Todate", Todate);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_EQ", param).Tables[0];
    //}
    public DataTable MMF_COL(DateTime FromDate, DateTime Todate)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@Todate", Todate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_COL", param).Tables[0];
    }
    
    public DataTable mmf_DCase(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_DCases", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@Date", FromDate);
       // cmd.Parameters.AddWithValue("@BID", BranchID);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }
    public DataTable MMF_CANCEL(DateTime FromDate, DateTime Todate)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@Todate", Todate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_CANCEL", param).Tables[0];
    }
    public DataTable mmf_ILS(DateTime FromDate, DateTime Todate, int BranchID)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_ILS", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@Todate", Todate);
        cmd.Parameters.AddWithValue("@BranchID", BranchID);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }
    public DataTable mmf_CLSR(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_CLSR", con);
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
    //public DataTable MMF_VINFO(DateTime FromDate)
    //{
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("MMF_VINFO", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandTimeout = 500;
    //    cmd.Parameters.AddWithValue("@Date", FromDate);
    //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adapter.Fill(dt);
    //    con.Close();
    //    return dt;


    //}

    public DataTable MMF_MVINFO(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_MVINFO", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 3600;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }
    public DataTable MMF_EMIS(DateTime FromDate, DateTime Todate)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@fromdate ", FromDate);
        param[1] = new SqlParameter("@Todate ", Todate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_EMIS", param).Tables[0];
    }



    public DataTable MMF_ARREAR_SMS(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_ARREAR_SMS", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@TDATE", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }

   
    public DataTable MMF_MEL_PEN(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_MEL_PEN", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }



    public DataTable MMF_DVSC(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_DVSC", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 3600;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }



    public DataTable MMF_LBDNew(DateTime FromDate, DateTime Todate)
    {
        con.Open();
         SqlCommand cmd = new SqlCommand("mmf_LBDWithoutNominee", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.CommandTimeout = 4800;
        cmd.Parameters.AddWithValue("@date", FromDate);
         cmd.Parameters.AddWithValue("@date1", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
         adapter.Fill(dt);
         con.Close();
         return dt;
   }


  

 public DataTable mmf_Loanstage_SA(DateTime FromDate, DateTime Todate)
     {
         con.Open();
         SqlCommand cmd = new SqlCommand("mmf_Loanstage_SA", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.CommandTimeout = 4800;
         cmd.Parameters.AddWithValue("@date", FromDate);
        cmd.Parameters.AddWithValue("@date1", Todate);
         SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
         con.Close();
        return dt;
     }

    public DataTable mmf_LoanStage(int StageID, int BranchID)
     {
        con.Open();
         SqlCommand cmd = new SqlCommand("mmf_LoanStage", con);
        cmd.CommandType = CommandType.StoredProcedure;
         cmd.CommandTimeout = 800;
         cmd.Parameters.AddWithValue("@StageID", StageID);
          cmd.Parameters.AddWithValue("@BranchID", BranchID);
         SqlDataAdapter adapter = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
         adapter.Fill(dt);
       con.Close();
        return dt;

     }


 //public DataTable mmf_CDis(DateTime FromDate, DateTime Todate)
 //   {
 //       con.Open();
 //       SqlCommand cmd = new SqlCommand("mmf_CDis", con);
 //       cmd.CommandType = CommandType.StoredProcedure;
 //       cmd.CommandTimeout = 500;
 //       cmd.Parameters.AddWithValue("@FromDate", FromDate);
 //       cmd.Parameters.AddWithValue("@Todate", Todate);
 //       SqlDataAdapter adapter = new SqlDataAdapter(cmd);
 //       DataTable dt = new DataTable();
 //       adapter.Fill(dt);
 //       con.Close();
 //       return dt;


 //   }

   //  public DataTable MMF_EQ(DateTime FromDate, DateTime Todate)
   //{
   //      con.Open();
   //      SqlCommand cmd = new SqlCommand("MMF_EQ", con);
   //       cmd.CommandType = CommandType.StoredProcedure;
   //     cmd.CommandTimeout = 500;
   //      cmd.Parameters.AddWithValue("@FromDate", FromDate);
   //     cmd.Parameters.AddWithValue("@Todate", Todate);
   //      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
   //      DataTable dt = new DataTable();
   //     adapter.Fill(dt);
   //      con.Close();
   //      return dt;

   //  }
     
     //public DataTable MMF_CPPDIS(DateTime dtFrom, DateTime dtTo)
     //  {
     //     param = new SqlParameter[2];
     //     param[0] = new SqlParameter("@FromDate", dtFrom);
     //    param[1] = new SqlParameter("@ToDate", dtTo);
     //     return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_CPPDIS", param).Tables[0];
     // }

 


//public DataTable mmf_mfimocollection(DateTime FromDate, DateTime Todate)
//      {
//        con.Open();
//        SqlCommand cmd = new SqlCommand("mmf_mfimocollection", con);
//         cmd.CommandType = CommandType.StoredProcedure;
//         cmd.CommandTimeout = 800;
//        cmd.Parameters.AddWithValue("@Fromdate", FromDate);
//         cmd.Parameters.AddWithValue("@Todate", Todate);
//         SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//         DataTable dt = new DataTable();
//         adapter.Fill(dt);
//         con.Close();
//         return dt;
//    }
   public DataTable mmf_dormant(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_dormant", con);
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


public DataTable MMF_APP_CPP(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_APP_CPP", con);
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

   public DataTable MMF_VINFO(DateTime FromDate)
     {
         con.Open();
         SqlCommand cmd = new SqlCommand("MMF_VINFO", con);
          cmd.CommandType = CommandType.StoredProcedure;
         cmd.CommandTimeout = 3600;
         cmd.Parameters.AddWithValue("@Date", FromDate);
        // cmd.Parameters.AddWithValue("@BID", BranchID);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
         adapter.Fill(dt);
        con.Close();
         return dt;

 }


public DataTable MMF_LOS_ENROLLMENT(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_LOS_ENROLLMENT", con);
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

public DataTable mmf_Collection_insurance(DateTime FromDate, DateTime Todate)
      {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_Collection_insurance", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@Fromdate", FromDate);
         cmd.Parameters.AddWithValue("@Todate", Todate);
         SqlDataAdapter adapter = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
         adapter.Fill(dt);
         con.Close();
         return dt;
    }
 
public DataTable MMF_MORATORIUM_KOTAK(DateTime FromDate, DateTime Todate)
      {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_MORATORIUM_KOTAK", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@Fromdate", FromDate);
         cmd.Parameters.AddWithValue("@Todate", Todate);
         SqlDataAdapter adapter = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
         adapter.Fill(dt);
         con.Close();
         return dt;
    }


  public DataTable MMF_Member_Basic_info(DateTime FromDate)
     {
         con.Open();
         SqlCommand cmd = new SqlCommand("MMF_Member_Basic_info", con);
          cmd.CommandType = CommandType.StoredProcedure;
         cmd.CommandTimeout = 3600;
         cmd.Parameters.AddWithValue("@Date", FromDate);
        // cmd.Parameters.AddWithValue("@BID", BranchID);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
         adapter.Fill(dt);
        con.Close();
         return dt;

 }



   public DataTable MMF_SameDay_OD(DateTime FromDate)
     {
         con.Open();
         SqlCommand cmd = new SqlCommand("MMF_SameDay_OD", con);
          cmd.CommandType = CommandType.StoredProcedure;
         cmd.CommandTimeout = 3600;
         cmd.Parameters.AddWithValue("@Date", FromDate);
        // cmd.Parameters.AddWithValue("@BID", BranchID);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
         adapter.Fill(dt);
        con.Close();
         return dt;

 }

public DataTable MMF_MORATORIUM_KOTAK_2(DateTime FromDate, DateTime Todate)
      {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_MORATORIUM_KOTAK_2", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@Fromdate", FromDate);
         cmd.Parameters.AddWithValue("@Todate", Todate);
         SqlDataAdapter adapter = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
         adapter.Fill(dt);
         con.Close();
         return dt;
    }



    //public DataTable MMF_Hospicash_Intimation(DateTime FromDate)
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



public DataTable MMF_IVR_Aditya_Birla(DateTime FromDate, DateTime Todate)
      {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_IVR_Aditya_Birla", con);
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





    public DataTable MMF_OS_MEL(DateTime FromDate)
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
    

public DataTable MMF_Emp_Creation(DateTime FromDate, DateTime Todate)
      {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_Emp_Creation", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@Date", FromDate);
         cmd.Parameters.AddWithValue("@Todate", Todate);
         SqlDataAdapter adapter = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
         adapter.Fill(dt);
         con.Close();
         return dt;
    }

public DataTable MMF_IVR_ICICI_Lombard(DateTime FromDate, DateTime Todate)
      {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_IVR_ICICI_Lombard", con);
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

 
  
  public DataTable MMF_INS_rescheudling(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_INS_rescheudling", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@FromDate", FromDate); cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }

    //public DataTable mmf_CollectionDetail(DateTime FromDate, DateTime Todate)
    //{
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("mmf_CollectionDetail", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandTimeout = 400;
    //    cmd.Parameters.AddWithValue("@FromDate", FromDate);
    //    cmd.Parameters.AddWithValue("@Todate", Todate);
    //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adapter.Fill(dt);
    //    con.Close();
    //    return dt;
    //}

    // 35 to 37 

    public DataTable MMF_MELC(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_MELC", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

}