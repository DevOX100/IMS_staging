
using System;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DatabaseConnection
/// </summary> 
public class DatabaseConnection
{

    protected SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BRdatabaseconnection"].ConnectionString);

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