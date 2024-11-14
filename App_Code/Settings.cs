using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;

/// <summary>
/// Summary description for Settings
/// </summary>
public class Settings:db
{
    DataTable dt;
    DataSet ds;
    SqlParameter[] param;
    public DataTable GetCity(int CityStateID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@CityStateID", CityStateID);
        return dt=SqlHelper.ExecuteDataset(con,CommandType.Text,"select * from dbo.CityDB where CityStateID=@CityStateID",param).Tables[0];
    }
    public DataTable GetState()
    {
        return dt = SqlHelper.ExecuteDataset(con, CommandType.Text, "select StateID,StateName from StateDB").Tables[0];
    }
    public DataSet AddCity(int State, string City,int EmpID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@State", State);
        param[1] = new SqlParameter("@City", City);
        param[2] = new SqlParameter("@EmpID", EmpID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "insert into CityDB (CityStateID,CityName,InsertDate,InsertUserID) values(@State,@City,getdate(),@EmpID)", param);
    }
public DataSet GetRegion()
    {
        param = new SqlParameter[0];
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "SELECT *  FROM hierarchy where Is_Active = 1");
    }
    public DataSet AddState(int CountryID, string StateID, int EmpID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@Country", CountryID);
        param[1] = new SqlParameter("@StateName", StateID);
        param[2] = new SqlParameter("@EmpID", EmpID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "insert into StateDB (Country,StateName,InsertDate,InsertUserID) values(@Country,@StateName,getdate(),@EmpID)", param);
    }
  public DataSet mmf_AddBranchSetting(int BranchID, string BranchName, int RegionID, string Address1, string BranchCode)
    {
        param = new SqlParameter[5];
        param[0] = new SqlParameter("@BranchCode", BranchID );
        param[1] = new SqlParameter("@BranchName",BranchName );
        param[2] = new SqlParameter("@RegionID", RegionID);
        param[3] = new SqlParameter("@Address1",Address1 );
        param[4] = new SqlParameter("@BranchID", BranchCode);
       return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "INSERT INTO dbo.mmf_BranchSetting (BranchID, BranchName,RegionID, Address1) VALUES  (@BranchID,@BranchName,@RegionID,@Address1)", param);
    }
    public DataSet mmf_UpdateBranchSetting(int BranchID, string BranchName, int RegionID, string Address1, string BranchCode)
    {
        param = new SqlParameter[5];
        param[0] = new SqlParameter("@BranchCode", BranchID);
        param[1] = new SqlParameter("@BranchName", BranchName);
        param[2] = new SqlParameter("@RegionID", RegionID);
        param[3] = new SqlParameter("@Address1", Address1);
        param[4] = new SqlParameter("@BranchID", BranchCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "update dbo.mmf_BranchSetting  set BranchName= @BranchName, RegionID=@RegionID, Address1=@Address1,BranchID=@BranchID where BranchID=@BranchID", param);
    }
    public DataSet GetMaxBranch()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, " select isnull(MAX(BranchID),0)+1 as BranchID from dbo.mmf_BranchSetting");
    }
   public DataSet BindBranch()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select dbo.RegionName(RegionID) RegionID,BranchID,BranchName,Address1,BranchCode from dbo.mmf_BranchSetting WHERE IsActive=1 order by BranchName");
    }
    public DataSet GetAllBranch()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "SELECT BranchID +' / '+ BranchName as Branch,BranchID,UPPER(BranchName)  AS BranchName FROM mmf_BranchSetting WHERE  IsActive=1  order by BranchName");
    }
    public DataSet GetBranchByID(int BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from dbo.mmf_BranchSetting WHERE BranchID = @BranchID ORDER BY BranchName", param);
    }

    public DataSet EditBranchByCode(int BranchCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchCode", BranchCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from dbo.mmf_BranchSetting WHERE BranchCode = @BranchCode ORDER BY BranchName", param);
    }

    public DataSet RemoveBranchByCode(int BranchCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchCode", BranchCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "delete from dbo.mmf_BranchSetting WHERE BranchCode = @BranchCode", param);
    }

    public DataSet mmf_AddBranchSetting(int BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, " select * from dbo.mmf_BranchSetting where BranchID=@BranchID", param);
    }
    public DataSet mmf_AddCompanySetting(int CompanyID, string SupplierName, string CompanyName, string Address1, string CompanyCode, int CityID, int State, int CountryID, string ZipCode, string Phone1, string Mobile, string Fax, string EMailID, string CityName, string StateName, string CountryName)
    {
        param = new SqlParameter[16];
        param[0] = new SqlParameter("@CompanyID", CompanyID);
        param[1] = new SqlParameter("@SupplierName", SupplierName);
        param[2] = new SqlParameter("@CompanyName", CompanyName);
        param[3] = new SqlParameter("@Address1", Address1);
        param[4] = new SqlParameter("@CompanyCode", CompanyCode);
        param[5] = new SqlParameter("@CityID", CityID);
        param[6] = new SqlParameter("@StateID", State);
        param[7] = new SqlParameter("@CountryID", CountryID);
        param[8] = new SqlParameter("@ZipCode", ZipCode);
        param[9] = new SqlParameter("@Phone1", Phone1);
        param[10] = new SqlParameter("@Mobile", Mobile);
        param[11] = new SqlParameter("@Fax", Fax);
        param[12] = new SqlParameter("@EMailID", EMailID);
        param[13] = new SqlParameter("@CityName", CityName);
        param[14] = new SqlParameter("@StateName", StateName);
        param[15] = new SqlParameter("@CountryName", CountryName);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_AddCompanySetting", param);
    }
    public DataSet GetMaxCompany()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select isnull(MAX(CompanyID),0)+1 as CompanyID from dbo.mmf_CompanyDetail");
    }
    public DataSet GetAllCompany()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from dbo.mmf_CompanyDetail where Is_Active=1");
    }
    public DataSet GetCompanyByID(int CompanyID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@CompanyID", CompanyID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from dbo.mmf_CompanyDetail where CompanyID=@CompanyID", param);
    }
    public DataSet KitByBranchID(int AllocatedToBranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@AllocatedToBranchID", AllocatedToBranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select KitSerialNo from MasterKit where  KitStatus='Enable' AND	KitState='Inactive' AND AllocatedToBranchID=@AllocatedToBranchID order by KitSerialNo", param);
    }
    public DataTable Pivot(DataTable dt)
    {

        DataTable dtConvert = new DataTable();

        for (int i = 0; i <= dt.Rows.Count; i++)
        {

            dtConvert.Columns.Add("Kit Record" + Convert.ToString(i));

        }

        for (int i = 0; i < dt.Columns.Count; i++)
        {

            dtConvert.Rows.Add();   

            dtConvert.Rows[i][0] = dt.Columns[i].ColumnName;

            for (int j = 0; j < dt.Rows.Count; j++)
            {

                dtConvert.Rows[i][j + 1] = dt.Rows[j][i];

            }

        }

        return dtConvert;

    }
     public void DisplayAJAXMessage(Control page, string msg)
    {
        string myScript = String.Format("alert('{0}');", msg);

        ScriptManager.RegisterStartupScript(page, page.GetType(),
          "MyScript", myScript, true);
    }
    public DataSet AddRole(string Role, DateTime InsertDate)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@Role", Role);
        param[1] = new SqlParameter("@InsertDate", InsertDate);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "insert into mmf_Role  (RoleName,RoleInsertDate)values (@Role,@InsertDate)", param);
    }

    public DataSet GetCityListByState(int StateID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@StateID", StateID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetCityListByState", param);
    }
    public DataSet DeleteCityData(int CityID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@CityID", CityID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_DeleteCityData", param);
    }

    public DataSet GetStateListByCountry()
    {
        param = new SqlParameter[0];
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetStateListByCountry", param);
    }

    public DataSet DeleteStateData(int StateID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@StateID", StateID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_DeleteStateData", param);
    }

    public DataSet SelectUniqueBranch(int BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select BranchID from mmf_BranchSetting where BranchID=@BranchID", param);
    }

    public DataSet SelectUniqueSupplierCode(string CompanyCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@CompanyCode", CompanyCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select CompanyCode from mmf_CompanyDetail where CompanyCode=@CompanyCode", param);
    }
    public DataSet DeleteCompanyByID(int CompanyID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@CompanyID", CompanyID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "delete from dbo.mmf_CompanyDetail where CompanyID=@CompanyID", param);
    }
    public DataSet SelectUniqueCityName(string CityName, int StateID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@CityName", CityName);
        param[1] = new SqlParameter("@StateID", StateID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select CityName from CityDB where CityName=@CityName and CityStateID = @StateID", param);
    }

    public DataSet SelectUniqueStateName(string StateName, int CountryID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@StateName", StateName);
        param[1] = new SqlParameter("@CountryID", CountryID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select StateName from StateDB where StateName=@StateName and Country = @CountryID", param);
    }
}