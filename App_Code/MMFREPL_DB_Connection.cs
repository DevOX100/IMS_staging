using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

/// <summary>
/// Summary description for db
/// </summary>
public class MMFREPL
{
    protected SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MMFREPL"].ConnectionString);
    protected SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["MMFREPL52"].ConnectionString);

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

    protected void OpenConnection2()
    {
        if (con2.State == ConnectionState.Closed)
            con2.Open();
    }
    protected void CloseConnection2()
    {
        if (con2.State == ConnectionState.Open)
            con2.Close();
    }


    public static string Connection()
    {
        string s = string.Empty;
        s = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        return s;
    }

}