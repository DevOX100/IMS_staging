using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

/// <summary>
/// Summary description for db
/// </summary>
public class HRMSLIVE
{
    protected SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HRMSLIVE"].ConnectionString);

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