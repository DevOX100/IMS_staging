using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MMF_REPLDB_JAL_CONFIG
/// </summary>
public class MMF_REPLDB_JAL_CONFIG
{
    protected SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MMFREPLJAL"].ConnectionString);

    protected void OpenConnection()
    {
        if (con.State == ConnectionState.Closed)
            con.Open();
    }
    protected void CloseConnection()
    {
        if (con.State == ConnectionState.Open)
            con.Close();
    }


    public static string Connection()
    {
        string s = string.Empty;
        s = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        return s;
    }
}