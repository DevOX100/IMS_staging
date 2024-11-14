using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Dummy
/// </summary>
public class Dummy
{
    protected SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Jdatabaseconnect"].ConnectionString);

  
}