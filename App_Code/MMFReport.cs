﻿using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;




/// <summary>
/// Summary description for MMFReport
/// </summary>
public class MMFReport:MMFDatabaseConnection
{
    DataTable ds;
    SqlParameter[] param;
    public DataTable mmf_CashlessCredit(DateTime FromDate)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@FromDate", FromDate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_CashlessBooking", param).Tables[0];
    }
 
   
    //public DataTable MMF_FinalDisbursemnt(DateTime FromDate, DateTime Todate)
    //{
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("MMF_FinalDisbursemnt", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandTimeout = 500;
    //    cmd.Parameters.AddWithValue("@FromDate", FromDate); cmd.Parameters.AddWithValue("@Todate", Todate);
    //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adapter.Fill(dt);
    //    con.Close();
    //    return dt;

    //}
    public DataTable MMF_MDIS(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_MDIS", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@FromDate", FromDate); cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }



    public DataTable MMF_ILD(DateTime FromDate, DateTime Todate, int BranchID)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_ILD", con);
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
    
  
   
  
   
    //public DataTable mmf_CenterDetails(DateTime FromDate)
    //{
    //    param = new SqlParameter[1];
    //    param[0] = new SqlParameter("@FromDate", FromDate);
     
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_CenterDetails", param).Tables[0];
    //}
    
    
   // public DataTable mmf_CDis(DateTime FromDate, DateTime Todate)
   // {
       // con.Open();
       // SqlCommand cmd = new SqlCommand("mmf_CDis", con);
      //  cmd.CommandType = CommandType.StoredProcedure;
       // cmd.CommandTimeout = 500;
       // cmd.Parameters.AddWithValue("@FromDate", FromDate);
       // cmd.Parameters.AddWithValue("@Todate", Todate);
       // SqlDataAdapter adapter = new SqlDataAdapter(cmd);
       // DataTable dt = new DataTable();
       // adapter.Fill(dt);
       // con.Close();
       // return dt;


    //}
    
    public DataTable mmf_LADashboard(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_LADashboard", con);
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
    public DataTable mmf_Get(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_Get", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        cmd.Parameters.AddWithValue("@Date1", Todate);
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
   

    public DataTable MMF_CANCEL(DateTime FromDate, DateTime Todate)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@Todate", Todate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_CANCEL", param).Tables[0];
    }
    public DataTable MMF_APPCANCEL(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_APPCANCEL", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 400;
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
        //return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_CANCEL", param).Tables[0];
    }
    public DataTable MMF_APRCANCEL(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_APRCANCEL", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 400;
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
        //return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_CANCEL", param).Tables[0];
    }
    public DataTable mmf_SFD(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_SFD", con);
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
    //public DataTable mmf_OS(DateTime FromDate)
    //{
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("MMF_OS", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandTimeout = 500;
    //    cmd.Parameters.AddWithValue("@Date", FromDate);

    //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adapter.Fill(dt);
    //    con.Close();
    //    return dt;

    //}

    public DataTable mmf_OS(DateTime FromDate)
    {

        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_OS", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@Date", FromDate);

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
        //param = new SqlParameter[1];
        //param[0] = new SqlParameter("@Date", FromDate);
        //return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_OS", param).Tables[0];
    }




   // public DataTable mmf_dormant(DateTime FromDate, DateTime Todate)
   // {
       // con.Open();
       // SqlCommand cmd = new SqlCommand("mmf_dormant", con);
       // cmd.CommandType = CommandType.StoredProcedure;
       // cmd.CommandTimeout = 800;
       // cmd.Parameters.AddWithValue("@FromDate", FromDate);
       // cmd.Parameters.AddWithValue("@Todate", Todate);
       // SqlDataAdapter adapter = new SqlDataAdapter(cmd);
       // DataTable dt = new DataTable();
       // adapter.Fill(dt);
        //con.Close();
        //return dt;

   // }
    
    

          
    public DataTable mmf_KotakUpload(DateTime FromDate, DateTime Todate)
    {
        //param = new SqlParameter[2];
        //param[0] = new SqlParameter("@FromDate", FromDate);
        //param[1] = new SqlParameter("@Todate", Todate);
        //return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_KotakUpload", param).Tables[0];

        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_KotakUpload", con);
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
    public DataTable mmf_employeeDetail(DateTime FromDate, DateTime Todate)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@Todate", Todate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_employeeDetail", param).Tables[0];
    }
    public DataTable mmf_RblBulkFormat(DateTime FromDate, DateTime Todate)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@Todate", Todate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_RblBulkFormat", param).Tables[0];
    }
    
    //public DataTable MMF_UPDATELBD(DateTime FromDate)
    //{
    //    param = new SqlParameter[1];
    //    param[0] = new SqlParameter("@FromDate", FromDate);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_UPDATELBD", param);

    //}
    //public DataTable MMF_LBDNew(DateTime FromDate, DateTime Todate)
     //{
        // con.Open();
        // SqlCommand cmd = new SqlCommand("mmf_LBDWithoutNominee", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        // cmd.CommandTimeout = 4800;
       //cmd.Parameters.AddWithValue("@date", FromDate);
        // cmd.Parameters.AddWithValue("@date1", Todate);
       //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        // DataTable dt = new DataTable();
        //adapter.Fill(dt);
       //con.Close();
       //  return dt;
    // }
    public DataTable mmf_LBDCallCenter(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_LBDCallCenter", con);
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
    public DataTable mmf_OutstandingAsOnDate(DateTime FromDate)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@date", FromDate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_OutstandingAsOnDate", param).Tables[0];

    }
    public DataTable mmf_ICICI(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_ICICI", con);
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
  
    
   
    public DataTable mmf_ILS(DateTime FromDate, DateTime Todate, int BranchID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@Todate", Todate);
        param[2] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_ILS", param).Tables[0];
    }
    public DataTable mmf_CashlessAfterDisbursement(DateTime FromDate, DateTime Todate, string BranchID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@Todate", Todate);
        param[2] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_CashlessAfterDisbursement", param).Tables[0];
    }
   
    
    public DataTable MMF_KYC(DateTime FromDate, DateTime Todate, string BranchID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@Todate", Todate);
        param[2] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_KYC", param).Tables[0];
    }
    public DataTable mmf_CashlessWithClientID(DateTime FromDate)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@FromDate", FromDate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_CashlessWithClientID", param).Tables[0];
    }
    //public DataTable mmf_LoanStage(int StageID, int BranchID)
     //{
       // con.Open();
         //SqlCommand cmd = new SqlCommand("mmf_LoanStage", con);
         //cmd.CommandType = CommandType.StoredProcedure;
         //cmd.CommandTimeout = 800;
         //cmd.Parameters.AddWithValue("@StageID", StageID);
        //cmd.Parameters.AddWithValue("@BranchID", BranchID);
         //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
       // DataTable dt = new DataTable();
         //adapter.Fill(dt);
        //con.Close();
         //return dt;

     //}
      public DataTable mmf_LoanStage(int StageID)
      {
         param = new SqlParameter[1];
         param[0] = new SqlParameter("@StageID", StageID);
         return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_LoanStage", param).Tables[0];
     }
    public DataTable mmf_UploadPrepaidCardDetail(DateTime FromDate, DateTime Todate)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@date", FromDate);
        param[1] = new SqlParameter("@date1", Todate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_UploadPrepaidCardDetail", param).Tables[0];
    }
   
   
    public DataTable mmf_ICICIPrepaidCards(DateTime FromDate, DateTime ToDate)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@ToDate", ToDate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_ICICIPrepaidCards", param).Tables[0];
    }

    public DataTable MMF_NAREA(DateTime dtFrom, DateTime dtTo)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@FromDate", dtFrom);
        param[1] = new SqlParameter("@ToDate", dtTo);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_NAREA", param).Tables[0];
    }

    
    public DataTable mmf_RBLPrepaidCards(DateTime FromDate, DateTime ToDate)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@date", FromDate);
        param[1] = new SqlParameter("@date1", ToDate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_RBLPrepaidCards", param).Tables[0];
    }
    public DataTable mmf_CPPSan(DateTime FromDate, DateTime ToDate)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@ToDate", ToDate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_CPPSan", param).Tables[0];
    }

    public DataTable MMF_LBDCPP(DateTime dtFrom)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@date", dtFrom);
 
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_LBDCPP", param).Tables[0];
    }

    public DataTable MMF_EUV(DateTime dtFrom, DateTime dtTo)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@date", dtFrom);
        param[1] = new SqlParameter("@date1", dtTo);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_EUV", param).Tables[0];
    }

     // public DataTable MMF_CPPDIS(DateTime dtFrom, DateTime dtTo)
       //{
         // param = new SqlParameter[2];
       //param[0] = new SqlParameter("@FromDate", dtFrom);
        // param[1] = new SqlParameter("@ToDate", dtTo);
         // return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_CPPDIS", param).Tables[0];
     // }

    // public DataTable mmf_DVC(DateTime dtFrom, DateTime dtTo)
   // {
    //    param = new SqlParameter[2];
    //    param[0] = new SqlParameter("@FromDate", dtFrom);
     //   param[1] = new SqlParameter("@ToDate", dtTo);
     //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_DVC", param).Tables[0];
    //}

     //public DataTable MMF_EQ(DateTime FromDate, DateTime Todate)
   //{
         //con.Open();
         //SqlCommand cmd = new SqlCommand("MMF_EQ", con);
         // cmd.CommandType = CommandType.StoredProcedure;
        //cmd.CommandTimeout = 500;
        // cmd.Parameters.AddWithValue("@FromDate", FromDate);
        //cmd.Parameters.AddWithValue("@Todate", Todate);
         //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        // DataTable dt = new DataTable();
        //adapter.Fill(dt);
         //con.Close();
         //return dt;

     //}


    //public DataTable MMF_B(int keyword, string searchkeyword)
    //{
    //    param = new SqlParameter[2];
    //    param[0] = new SqlParameter("@keyword", keyword);
    //    param[1] = new SqlParameter("@searchkeyword", searchkeyword);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_B", param).Tables[0];
    //}
    public DataTable MMF_B(int keyword, string searchkeyword)
    {

        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_B", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@keyword", keyword);
        cmd.Parameters.AddWithValue("@searchkeyword", searchkeyword);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
       
    }
    public DataTable mmf_PrepaidCardDetail(DateTime FromDate, DateTime Todate)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@date", FromDate);
        param[1] = new SqlParameter("@date1", Todate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_PrepaidCardDetail", param).Tables[0];
    }
   
    public DataTable GetBranchByID(string BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from mast_branch_info where MBRI_Code=@BranchID", param).Tables[0];
    }

    public DataTable MMF_ECode_CollectionTxnFromToDate(DateTime From_Date, DateTime To_Date, string Ecode)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@From_Date", From_Date);
        param[1] = new SqlParameter("@To_Date", To_Date);
        param[2] = new SqlParameter("@ECode", Ecode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_ECode_CollectionTxnFromToDate", param).Tables[0];
    }

    public DataTable MMF_ECode_CollectionTxnAsOnDate( string Ecode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@ECode", Ecode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_ECode_CollectionTxnAsOnDate", param).Tables[0];
    }
    
 public DataTable MMF_OverallCollectionTxnSummary(DateTime From_Date, DateTime To_Date)
    {
        

        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_OverallCollectionTxnSummary", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@From_Date", From_Date);
        cmd.Parameters.AddWithValue("@To_Date", To_Date);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

    
         public DataTable MMF_MUDRA_DIS(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_MUDRA_DIS", con);
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
    public DataTable MMF_EDD(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_EDD", con);
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


    public DataTable MMF_SMS(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_SMS", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

 


    public DataTable MMF_NACH(DateTime AsOnDate)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@date", AsOnDate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_NACH", param).Tables[0];
    }


 
 
    //public DataTable MMF_MELC(DateTime FromDate, DateTime Todate)
    //{
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("MMF_MELC", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandTimeout = 500;
    //    cmd.Parameters.AddWithValue("@FromDate", FromDate);
    //    cmd.Parameters.AddWithValue("@ToDate", Todate);
    //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adapter.Fill(dt);
    //    con.Close();
    //    return dt;
    //}

    public DataTable MMF_MSME_NACH(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_MSME_NACH", con);
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

    public DataTable MMF_MSME_SNACH(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_MSME_SNACH", con);
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
    public DataTable MMF_COI(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_COI", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@date", FromDate);
        cmd.Parameters.AddWithValue("@date1", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }
    public DataTable MMF_IMPS(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_IMPS", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 4800;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }
   // public DataTable MMF_DVSC(DateTime FromDate, DateTime Todate)
   // {
    //    con.Open();
     //   SqlCommand cmd = new SqlCommand("MMF_DVSC", con);
     //   cmd.CommandType = CommandType.StoredProcedure;
     //   cmd.CommandTimeout = 3600;
     //   cmd.Parameters.AddWithValue("@FromDate", FromDate);
      //  cmd.Parameters.AddWithValue("@Todate", Todate);
      //  SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      //  DataTable dt = new DataTable();
      //  adapter.Fill(dt);
      //  con.Close();
      //  return dt;
  //  }

    public DataTable MMF_PAUT(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_PAUT", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

    //public DataTable MMF_VINFO(DateTime FromDate)
    // {
        //con.Open();
         //SqlCommand cmd = new SqlCommand("MMF_VINFO", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.CommandTimeout = 3600;
       // cmd.Parameters.AddWithValue("@Date", FromDate);
       // SqlDataAdapter adapter = new SqlDataAdapter(cmd);
       // DataTable dt = new DataTable();
       // adapter.Fill(dt);
       // con.Close();
       // return dt;


   // }

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
   // public DataTable mmf_Loanstage_SA(DateTime FromDate, DateTime Todate)
     //{
        //con.Open();
        //SqlCommand cmd = new SqlCommand("mmf_Loanstage_SA", con);
         //cmd.CommandType = CommandType.StoredProcedure;
         //cmd.CommandTimeout = 4800;
        //cmd.Parameters.AddWithValue("@date", FromDate);
        //cmd.Parameters.AddWithValue("@date1", Todate);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
         //adapter.Fill(dt);
        //con.Close();
        //return dt;
     //}
    
    public DataTable MMF_IDMUPLOAD(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_IDMUPLOAD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }

    public DataTable mmf_mfimocollection(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_mfimocollection", con);
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

    public DataTable MMF_EUVRPT(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_EUVRPT", con);
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

public DataTable MMF_PDISTRACKER(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_PDISTRACKER", con);
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
 

 // public DataTable MMF_Arrear_rpt(DateTime FromDate)
   // {
        //con.Open();
        //SqlCommand cmd = new SqlCommand("MMF_Arrear_rpt", con);
        //cmd.CommandType = CommandType.StoredProcedure;
       // cmd.CommandTimeout = 3600;
        //cmd.Parameters.AddWithValue("@Date", FromDate);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //adapter.Fill(dt);
        //con.Close();
        //return dt;


    //}

 public DataTable MMF_NPA_rpt(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_NPA_rpt", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 3600;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }

 //public DataTable MMF_OS_MIS(DateTime FromDate)
    //{
        //con.Open();
        //SqlCommand cmd = new SqlCommand("MMF_OS_MIS", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.CommandTimeout = 3600;
        //cmd.Parameters.AddWithValue("@Date", FromDate);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //adapter.Fill(dt);
        //con.Close();
        //return dt;


    //}


 public DataTable MMF_APPSWINITHI(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_APPSWINITHI", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 400;
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
        //return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_CANCEL", param).Tables[0];
    }
 
    //public DataTable MMF_MEL_PEN(DateTime FromDate)
    //{
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("MMF_MEL_PEN", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandTimeout = 3600;
    //    cmd.Parameters.AddWithValue("@Date", FromDate);
    //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adapter.Fill(dt);
    //    con.Close();
    //    return dt;


    //}


//public DataTable MMF_VINFO(DateTime FromDate, DateTime Todate, string BranchID)
    //{
        //param = new SqlParameter[3];
       // param[0] = new SqlParameter("@Date", FromDate);
        //param[1] = new SqlParameter("@Todate", Todate);
       // param[2] = new SqlParameter("@BranchID", BranchID);
       // return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_VINFO", param).Tables[0];
    //}


 public DataTable MMF_SWANITHI_NACH(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_SWANITHI_NACH", con);
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



  


public DataTable mmf_current_schedule(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_current_schedule", con);
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


public DataTable mmf_Parter_IVR(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_Parter_IVR", con);
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

public DataTable mmf_Parter_Posting(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_Parter_Posting", con);
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


public DataTable MMF_MFIMO_LOGIN(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_MFIMO_LOGIN", con);
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


public DataTable MMF_Mudra_figures (DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_Mudra_figures ", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        //cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }

public DataTable mmf_LBD_Branch_summary (DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_LBD_Branch_summary", con);
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

public DataTable mmf_smrath_smridhi_SMS(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_smrath_smridhi_SMS", con);
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


public DataTable MMF_Current_Arrear_Status_rpt(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_Current_Arrear_Status_rpt", con);
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
public DataTable mmf_Late_CollectionDetail(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_Late_CollectionDetail", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        //cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
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

 //public DataTable MMF_MSME_NEFT(DateTime FromDate, DateTime Todate)
   // {
        //con.Open();
        //SqlCommand cmd = new SqlCommand("MMF_MSME_NEFT", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.CommandTimeout = 500;
        //cmd.Parameters.AddWithValue("@FromDate", FromDate);
        //cmd.Parameters.AddWithValue("@Todate", Todate);
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //adapter.Fill(dt);
        //con.Close();
        //return dt;
    //}

     

public DataTable Demand_vs_coll_matured_loan(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Demand_vs_coll_matured_loan", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 500;
        cmd.Parameters.AddWithValue("@FromDate", FromDate); cmd.Parameters.AddWithValue("@Todate", Todate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }
 
   

    public DataTable mmf_CDis(DateTime FromDate, DateTime Todate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_CDis", con);
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

   


    //public DataTable MMF_DVSC(DateTime FromDate, DateTime Todate)
    //{
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("MMF_DVSC", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandTimeout = 3600;
    //    cmd.Parameters.AddWithValue("@FromDate", FromDate);
    //    cmd.Parameters.AddWithValue("@Todate", Todate);
    //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adapter.Fill(dt);
    //    con.Close();
    //    return dt;
    //}

    public DataTable MMF_CL(DateTime FromDate, DateTime Todate, string BranchID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@Todate", Todate);
        param[2] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_CL", param).Tables[0];
    }

    public DataTable MMF_CPPDIS(DateTime dtFrom, DateTime dtTo)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@FromDate", dtFrom);
        param[1] = new SqlParameter("@ToDate", dtTo);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_CPPDIS", param).Tables[0];
    }

    public DataSet mmf_Arreardetail()
    {
        DataSet dss = new DataSet();
        return dss = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_Arreardetail");
    }

    public DataSet mmf_LoanOS()
    {
        DataSet dss = new DataSet();
        return dss = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_LoanOS");
    }

    public DataSet mmf_GOCollectSOANew()
    {
        DataSet dss = new DataSet();
        return dss = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_GOCollectSOANew");
    }

    public DataSet mmf_MMLCollectionEfficiency()
    {
        DataSet dss = new DataSet();
        return dss = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_MMLCollectionEfficiency");
    }

   

    public DataTable rpt_RMU_demandvscollection(DateTime FromDate)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("rpt_RMU_demandvscollection", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 3600;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;


    }



 
    //public DataTable mmf_mfimocollection(DateTime FromDate, DateTime Todate)
    //{
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("mmf_mfimocollection", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandTimeout = 800;
    //    cmd.Parameters.AddWithValue("@Fromdate", FromDate);
    //    cmd.Parameters.AddWithValue("@Todate", Todate);
    //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adapter.Fill(dt);
    //    con.Close();
    //    return dt;
    //}

   

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


    //////////////////////////// Later on 


    public DataTable mmf_Collection_Deletion_Rpt(DateTime FromDate, DateTime Todate) //Collection Deletion Report Live
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_Collection_Deletion_Rpt", con);
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

    public DataTable mmf_Disb_Deletion_Rpt(DateTime FromDate, DateTime Todate) //Disbursement Deletion Report Live
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_Disb_Deletion_Rpt", con);
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

    public DataTable mmf_DeathCasePayOut(DateTime FromDate, DateTime ToDate, int BranchID) //DeathCase PayOut Details Live
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@FromDate", FromDate);
        param[1] = new SqlParameter("@ToDate", ToDate);
        param[2] = new SqlParameter("@BID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_DeathCasePayOut", param).Tables[0];
    }


    public DataTable mmf_DCase(DateTime FromDate, int BranchID) //Current DeathCase T-15
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("mmf_DCases", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 800;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        cmd.Parameters.AddWithValue("@BID", BranchID);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;

    }

    public DataTable MMF_Hospicash_Intimation(DateTime FromDate) //Hospicash Info Report T-15
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("MMF_Hospicash_Intimation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 3600;
        cmd.Parameters.AddWithValue("@Date", FromDate);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }
}