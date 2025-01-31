﻿using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Drawing;
using System.IO;
using DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml.Bibliography;
using GemBox.Document.Tracking;



public class Inventory_System : db
{
    DataSet ds;
    SqlParameter[] param;
    public string BranchCode { get; set; }
    public string Password { get; set; }
    public string UserCode { get; set; }


    public DataSet InsertProductMaster(int PM_ItemCode1, string PM_ItemCode2, string PM_Description1, string PM_Description2, string PM_Category, string PM_Brand, string PM_UnitPrice,
 string PM_MRPPrice, string PM_UnitOfMeasurement, string PM_Image, string PM_Other1, string PM_Other2, string PM_Other3, string PM_Other4, string InsertUserAccountID,
 string ModifyUserAccountID, bool PM_IsActive, string VendorID, string PM_ItemCode3, DateTime PM_WarrantyExpiration)
    {
        param = new SqlParameter[20];
        param[0] = new SqlParameter("@PM_ItemCode1", PM_ItemCode1);
        param[1] = new SqlParameter("@PM_ItemCode2", PM_ItemCode2);
        param[2] = new SqlParameter("@PM_Description1", PM_Description1);
        param[3] = new SqlParameter("@PM_Description2", PM_Description2);
        param[4] = new SqlParameter("@PM_Category", PM_Category);
        param[5] = new SqlParameter("@PM_Brand", PM_Brand);
        param[6] = new SqlParameter("@PM_UnitPrice", PM_UnitPrice);
        param[7] = new SqlParameter("@PM_MRPPrice", PM_MRPPrice);
        param[8] = new SqlParameter("@PM_UnitOfMeasurement", PM_UnitOfMeasurement);
        param[9] = new SqlParameter("@PM_Image", PM_Image);
        param[10] = new SqlParameter("@PM_Other1", PM_Other1);
        param[11] = new SqlParameter("@PM_Other2", PM_Other2);
        param[12] = new SqlParameter("@PM_Other3", PM_Other3);
        param[13] = new SqlParameter("@PM_Other4", PM_Other4);
        param[14] = new SqlParameter("@InsertUserAccountID", InsertUserAccountID);
        param[15] = new SqlParameter("@ModifyUserAccountID", ModifyUserAccountID);
        param[16] = new SqlParameter("@PM_IsActive", PM_IsActive);
        param[17] = new SqlParameter("@VendorID", VendorID);
        param[18] = new SqlParameter("@PM_ItemCode3", PM_ItemCode3);
        param[19] = new SqlParameter("@PM_WarrantyExpiration", PM_WarrantyExpiration);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "InsertProductMaster", param);
        return ds;
    }

    public DataSet GetProductList(string BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetProductList", param);
        return ds;
    }

    public DataSet mmf_GetProductDataForModification(string ProductID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@ProductID", ProductID);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_GetProductDataForModification", param);
        return ds;
    }

    public DataSet usp_checkproductidexistornot(string ProductID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@ProductID", ProductID);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_checkproductidexistornot", param);
        return ds;
    }


    public DataSet BranchExistOrNot(string BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_BranchExistOrNot", param);
    }


    public DataSet InsertVendorData(string VM_Name, string VM_Address1, string VM_Address2, string VM_Pincode, string VM_City, string VM_State,
       string VM_Country, string VM_Phone, string VM_Email, string VM_PAN, string VM_GST, string VM_Other1, string VM_Other2, string VM_Other3, string VM_Other4,
       string InsertBy,string ModifyUserAccountID, bool VM_IsActive, int VM_VendorCode)
    {
        param = new SqlParameter[19];
        param[0] = new SqlParameter("@VM_Name", VM_Name);
        param[1] = new SqlParameter("@VM_Address1", VM_Address1);
        param[2] = new SqlParameter("@VM_Address2", VM_Address2);
        param[3] = new SqlParameter("@VM_Pincode", VM_Pincode);
        param[4] = new SqlParameter("@VM_City", VM_City);
        param[5] = new SqlParameter("@VM_State", VM_State);
        param[6] = new SqlParameter("@VM_Country", VM_Country);
        param[7] = new SqlParameter("@VM_Phone", VM_Phone);
        param[8] = new SqlParameter("@VM_Email", VM_Email);
        param[9] = new SqlParameter("@VM_PAN", VM_PAN);
        param[10] = new SqlParameter("@VM_GST", VM_GST);
        param[11] = new SqlParameter("@VM_Other1", VM_Other1);
        param[12] = new SqlParameter("@VM_Other2", VM_Other2);
        param[13] = new SqlParameter("@VM_Other3", VM_Other3);
        param[14] = new SqlParameter("@VM_Other4", VM_Other4);
        param[15] = new SqlParameter("@InsertBy", InsertBy);
        param[16] = new SqlParameter("@ModifyUserAccountID", ModifyUserAccountID);
        param[17] = new SqlParameter("@VM_IsActive", VM_IsActive);
        param[18] = new SqlParameter("@VM_VendorCode", VM_VendorCode);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "MMF_InsertVendorData", param);
        return ds;
    }

    public DataSet GetVendorListForPO(string BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetVendorListForPO", param);
        return ds;
    }

    public DataSet GetVendorList()
    {
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetVendorList");
        return ds;
    }

    public DataSet mmf_GetVendorDataForModification(int VendorCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@VendorCode", VendorCode);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_GetVendorDataForModification", param);
        return ds;
    }

    public DataSet usp_GetVendorDetails()
    {
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetVendorDetails");
        return ds;
    }

    public DataSet SelectUserDetails()
    {
        param = new SqlParameter[0];
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_SelectUserDetails", param);
    }

    public DataSet SelectUserDetailsbyUserCode(string UserCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserCode", UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_SelectUserDetailsbyUserCode", param);
    }

    public DataSet ModifyUserDetails(string UserAccountID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserAccountID", UserAccountID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyUserDetails", param);
    }

    public DataSet GetRegionDetails()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetRegionDetails");
    }
    public DataSet GetBranchDetailsbyRCode(string RCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@RCode", RCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetBranchDetailsbyRCode", param);
    }
    public DataSet GetDepartmentListByUser(string UserCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserCode", UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetDepartmentListByUser", param);
    }

    public DataSet SelectRole()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from mmf_role order by RoleName");
    }
    public DataSet SelectRoleForAdmin()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select * from mmf_role  order by RoleName");
    }
    public DataSet SelectUniqueUser()
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserCode", UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select UserCode from UserLogin where UserCode=@UserCode", param);
    }
    public DataSet CheckExistingMobileData(string Mobile)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mobile", Mobile);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select Mobile from UserLogin where Mobile=@Mobile", param);
    }
    public DataSet CheckExistingEmailData(string Email)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@Email", Email);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "select Email from UserLogin where Email=@Email", param);
    }
    public DataSet CreateUserLogin(string UserName, string UserCode, string Password, string BCode, int RoleID, string Email,
     string Mobile, string RCode, int Dpmt, string loginType)
    {
        param = new SqlParameter[10];
        param[0] = new SqlParameter("@UserName", UserName);
        param[1] = new SqlParameter("@UserCode", UserCode);
        param[2] = new SqlParameter("@Password", Password);
        param[3] = new SqlParameter("@BCode", BCode);
        param[4] = new SqlParameter("@RoleID", RoleID);
        param[5] = new SqlParameter("@Email", Email);
        param[6] = new SqlParameter("@Mobile", Mobile);
        param[7] = new SqlParameter("@RCode", RCode);
        param[8] = new SqlParameter("@DepID", Dpmt);
        param[9] = new SqlParameter("@loginType", loginType);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_CreateUserLogin", param);
    }
    public DataSet SelectMenuByMenuRole(int roleName, int MenuItemID, string UserCode)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@RoleID", roleName);
        param[1] = new SqlParameter("@MenuItemID", MenuItemID);
        param[2] = new SqlParameter("@UserCode", UserCode);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_MenuByMenuRole", param);
    }
    public DataSet AssignMenuByRole(int RoleMenuItemID, int RoleID, int ParentID, string UserCode)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@RoleMenuItemID", RoleMenuItemID);
        param[1] = new SqlParameter("@RoleID", RoleID);
        param[2] = new SqlParameter("@ParentID", ParentID);
        param[3] = new SqlParameter("@UserCode", UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_RoleMenuItemInsert", param);
    }
    public DataSet SelectMenuByParentID(int MenuParentID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@MenuParentID", MenuParentID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "SELECT MenuID, MenuName,MenuItemCode FROM mmf_MenuItemTable where MenuParentID=@MenuParentID and MenuIsActive = 1 order by MenuName", param);
    }
    public DataSet RemoveRoleMenu(int RoleMenuID, string UserCode)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@RoleMenuID", RoleMenuID);
        param[1] = new SqlParameter("@UserCode", UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_RemoveRoleMenu", param);
    }

    public DataSet GetUserDetailByRoleID(int RoleID, int DepID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@RoleID", RoleID);
        param[1] = new SqlParameter("@DepID", DepID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetUserDetailByRoleID", param);
    }
    public DataSet SelectMenuByID()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_SelectMenuByID");
    }


    public DataSet GetProductListByProductID(string ProductID, string Branch_id)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@ProductID", ProductID);
        param[1] = new SqlParameter("@Branch_id", Branch_id);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetProductListByProductID", param);
    }

    public DataSet insertBranchInitiateStock(string BIS_branchID, int BIS_productID, string BIS_insertBY, decimal BIS_Quantity, string BIS_Initiator_remarks)
    {
        param = new SqlParameter[5];
        param[0] = new SqlParameter("@BIS_branchID", BIS_branchID);
        param[1] = new SqlParameter("@BIS_productID", BIS_productID);
        param[2] = new SqlParameter("@BIS_insertBY", BIS_insertBY);
        param[3] = new SqlParameter("@BIS_Quantity", BIS_Quantity);
        param[4] = new SqlParameter("@BIS_Initiator_remarks", BIS_Initiator_remarks);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "insertBranchInitiateStock", param);
    }

    public DataSet GetBranchInitiateStock(string ProductID, string Branch_id)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@ProductID", ProductID);
        param[1] = new SqlParameter("@Branch_id", Branch_id);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetBranchInitiateStock", param);
    }

    public DataSet usp_deleteBranch_Initiate_Stock(int ID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@ID", ID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_deleteBranch_Initiate_Stock", param);
    }

    public DataSet confirmBranchInitiateStock(int ID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@ID", ID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "confirmBranchInitiateStock", param);
    }

    public DataSet GetProductDataForHO(string BranchID, string VID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@BranchID", BranchID);
        param[1] = new SqlParameter("@VID", VID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetProductDataForHO", param);
    }

    public DataSet VendorByProductID(string ProductID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@ProductID", ProductID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_VendorByProductID", param);
    }

    public DataSet usp_GetBranchStockData_ForHO(string BranchID, string RegionID)
 {
     param = new SqlParameter[2];
     param[0] = new SqlParameter("@BranchID", BranchID);
     param[1] = new SqlParameter("@RegionID", RegionID);
     return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetBranchStockData_ForHO", param);
 }

    public DataSet usp_GetRegionStockData_ForHO(string RegionID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@RegionID", RegionID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetRegionStockData_ForHO", param);
    }
    public DataSet HOApprovalForStock(string ApprovedBY, decimal approvedquantity, string ApprovalRemarks, int ID)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@ApprovedBY", ApprovedBY);
        param[1] = new SqlParameter("@approvedquantity", approvedquantity);
        param[2] = new SqlParameter("@ApprovalRemarks", ApprovalRemarks);
        param[3] = new SqlParameter("@ID", ID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_HOApprovalForStock", param);
    }

    public DataSet GetHOApprovalStock(string ProductID, int VendorID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@ProductID", ProductID);
        param[1] = new SqlParameter("@VendorID", VendorID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetHOApprovalStock", param);
    }

    public DataSet BranchList()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_BranchList");
    }


    public DataSet usp_GetBranchStockForPOGenerate(string BranchID, int VendorID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@BranchID", BranchID);
        param[1] = new SqlParameter("@VendorID", VendorID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetBranchStockForPOGenerate", param);
    }

    //public DataSet usp_deleteBranch_Initiate_Stock(int ID)
    //{
    //    param = new SqlParameter[1];
    //    param[0] = new SqlParameter("@ID", ID);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_deleteBranch_Initiate_Stock", param);
    //}

    //public DataSet confirmBranchInitiateStock(int ID)
    //{
    //    param = new SqlParameter[1];
    //    param[0] = new SqlParameter("@ID", ID);
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "confirmBranchInitiateStock", param);
    //}

    public DataSet insertPurchaseOrderDetails(decimal PO_amount, string PO_vendorCode, string PO_branchID,
     DateTime PO_Date, int Bis_ID, string UNIT, string POGeneratedBy, int BISHOApprovedQuantity, string BISHOApprovedRemarks)  /*   DateTime PO_Delivery_Date,*/

    {
        param = new SqlParameter[9];
        param[0] = new SqlParameter("@PO_amount", PO_amount);
        param[1] = new SqlParameter("@PO_vendorCode", PO_vendorCode);
        param[2] = new SqlParameter("@PO_branchID", PO_branchID);
        param[3] = new SqlParameter("@PO_Date", PO_Date);
        param[4] = new SqlParameter("@Bis_ID", Bis_ID);
        param[5] = new SqlParameter("@UNIT", UNIT);
        param[6] = new SqlParameter("@POGeneratedBy", POGeneratedBy);
        param[7] = new SqlParameter("@BISHOApprovedQuantity", BISHOApprovedQuantity);
        param[8] = new SqlParameter("@BISHOApprovedRemarks", BISHOApprovedRemarks);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "insertPurchaseOrderDetails", param);
    }

    public DataSet INV_GetRegionStockData_ForRM(string RegionID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@RegionID", RegionID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_GetRegionStockData_ForRM", param);
    }
    public DataSet INV_GetBranchWiseStockData_ForRM(string BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_GetBranchWiseStockData_ForRM", param);
    }
    public DataSet GetBIStockData_ForRM(string BISID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@BISID", BISID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_GetBIStockData_ForRM", param);
    }


    //public DataSet POApprovalDetails( string PONumber, DateTime FromDate, DateTime TODate)
    //{
    //    SqlParameter[] param = new SqlParameter[3];
    //    param[0] = new SqlParameter("@PONumber", PONumber);
    //    param[1] = new SqlParameter("@FromDate", SqlDbType.Date);
    //    param[1].Value = FromDate;
    //    param[2] = new SqlParameter("@TODate", SqlDbType.Date);
    //    param[2].Value = TODate;

    //    return SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_POApprovalDetails", param);
    //}
    public DataSet INV_POApprovalDetails(string BranchID, int VendorID)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@BranchID", BranchID);
        param[1] = new SqlParameter("@VendorID", VendorID);
        return SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_POApprovalDetails", param);
    }


    public DataSet POApprovalDetailsWise(string PONumber)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@PONumber", PONumber);


        return SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_BindPOApprovalDetailsWise", param);
    }

    //public DataSet DistinctPONumber()
    //{
    //    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_DistinctPONumber");
    //}
    public DataSet DateWisePOApprovalDetails(DateTime FromDate, DateTime TODate)
    { 
        SqlParameter[] param= new SqlParameter[2];
        param[0] = new SqlParameter("@FromDate", SqlDbType.Date);
        param[0].Value = FromDate;
        param[1] = new SqlParameter("@TODate", SqlDbType.Date);
        param[1].Value = TODate;
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "mmf_DateWisePOApprovalDetails", param);
    }
    public DataSet DistinctPONumber()
    {

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_DateWiseDistinctPONumber");
    }
    public DataSet poDetails(string PO_Number, string BranchCode)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@PO_number", PO_Number);
        param[1] = new SqlParameter("@BranchCode", BranchCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_poDetails", param);
    }
    public DataSet POAddresses(string PO_Number)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@PO_Number", PO_Number);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_POAddresses", param);
    }

    public DataSet usp_HODApprovalForStock(string HODRemarks, int ID, string HODApprovalID, string BisVendorID)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@HODRemarks", HODRemarks);
        param[1] = new SqlParameter("@ID", ID);
        param[2] = new SqlParameter("@HODApprovalID", HODApprovalID);
        param[3] = new SqlParameter("@BisVendorID", BisVendorID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_HODApprovalForStock", param);
    }

    public DataSet VendorPO(string vendorCode)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@vendorCode", vendorCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_POVendor", param);
    }

    public DataSet INV_ModifyVendorStatusData(int ID, string VendorStatus)/*, string filePath )*/
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@ID", ID);
        param[1] = new SqlParameter("@VendorStatus", VendorStatus);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_ModifyVendorStatusData", param);
    }

    public DataSet INV_BranchReceivedStock(string PONumber, string branchCode)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@PONumber", PONumber);
        param[1] = new SqlParameter("@branchCode", branchCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_BranchReceivedStock", param);
    }

    public DataSet usp_DistinctPONumberForBranchGRN(string BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_DistinctPONumberForBranchGRN", param);
    }

    public DataSet usp_ModifyBranchReceiveStock(string stock_receivedBY, int stock_received_quantity,
      string receiver_remarks, int ID, string ProductID, string VendorCode, string BranchID, string DamageStockRemarks, int DamageQuantity, bool IsPartial,
      bool IsClosed, string BIS_BranchPOD,string BIS_DamageReceiveStockValue)
    {
        param = new SqlParameter[13];
        param[0] = new SqlParameter("@stock_receivedBY", stock_receivedBY);
        param[1] = new SqlParameter("@stock_received_quantity", stock_received_quantity);
        param[2] = new SqlParameter("@receiver_remarks", receiver_remarks);
        param[3] = new SqlParameter("@ID", ID);
        param[4] = new SqlParameter("@ProductID", ProductID);
        param[5] = new SqlParameter("@VendorCode", VendorCode);
        param[6] = new SqlParameter("@BranchID", BranchID);
        param[7] = new SqlParameter("@DamageStockRemarks", DamageStockRemarks);
        param[8] = new SqlParameter("@DamageQuantity", DamageQuantity);
        param[9] = new SqlParameter("@IsPartial", IsPartial);
        param[10] = new SqlParameter("@IsClosed", IsClosed);
        param[11] = new SqlParameter("@BIS_BranchPOD", BIS_BranchPOD);
        param[12] = new SqlParameter("@BIS_DamageReceiveStockValue", BIS_DamageReceiveStockValue);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyBranchReceiveStock", param);
    }

    public DataSet usp_DistinctPONumberForViewPO()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_DistinctPONumberForViewPO");
    }

    public DataSet usp_DistinctPONumberForVendor(string VendorCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@VendorCode", VendorCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_DistinctPONumberForVendor", param);
    }

    public DataSet RegionDetail()
    {
        
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_RegionDetails");

    }

    public DataSet RegionWiseGridForHOD(string regionID)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@regionID", regionID);

        return SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "RegionWiseGridForHOD", param);
    }
    public DataSet BranchDetailsByRegion(string clusterID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@clusterID", clusterID);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_BranchDetailsByRegion", param);
    }   
   
    public DataSet Vendorpo(string vendorCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@VendorCode", vendorCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_Vendorpo", param);
    }
    public DataSet BranchDetails(string BranchCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchCode", BranchCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_BranchDetails", param);
    }
    public DataSet GetBranchWisePoDetails(string BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_GetBranchWisePoDetails", param);
    }
    public DataSet INV_poDetailsByBranch(string branchID, string poNumber)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@branchID", branchID);
        param[1] = new SqlParameter("@PoNumber", poNumber);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "poDetailsByBranch", param);
    }
    public DataSet INV_DistinctPONumber(string VendorID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@VendorID", VendorID);
       
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_DistinctPONumber", param);
    }
    public DataSet INV_DistinctVendor(string branchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@branchID", branchID);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_DistinctVendor", param);
    }
    public DataSet GetVendorWisePoDetails(string branchID, string vendorID)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@branchID", branchID);
        param[1] = new SqlParameter("@vendorID", vendorID);
       
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_GetVendorWisePoDetails", param);
    }

    public DataSet INV_distinctProduct()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_distinctProduct");
    }
    public DataSet GetIssueStock(string IS_CustID, string LoanID, string GroupID, string CenterID, string BranchID)
    {
        param = new SqlParameter[5];
        param[0] = new SqlParameter("@IS_CustID", IS_CustID);
        param[1] = new SqlParameter("@LoanID", LoanID);
        param[2] = new SqlParameter("@GroupID", GroupID);
        param[3] = new SqlParameter("@CenterID", CenterID);
        param[4] = new SqlParameter("@BranchID", BranchID);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_GetIssueStock", param);
        return ds;
    }
     public DataSet IssueStock(string IS_CustID, string IS_Name, string IS_Product, string IS_Branch, string IS_SpouseName, string IS_MobileNO, string POD, string IS_InvoiceNO,
   int IS_Quantity, string IS_UserType, DateTime? HandoverDate, string IS_LoanID, string IS_PaymentMode, int IS_Amount,string IS_ApplicationReceivedStage,string UserCode)
 {
     param = new SqlParameter[16];
     param[0] = new SqlParameter("@IS_CustID", IS_CustID);
     param[1] = new SqlParameter("@IS_Name", IS_Name);
     param[2] = new SqlParameter("@IS_Product", IS_Product);
     param[3] = new SqlParameter("@IS_Branch", IS_Branch);
     param[4] = new SqlParameter("@IS_SpouseName", IS_SpouseName);
     param[5] = new SqlParameter("@IS_MobileNO", IS_MobileNO);
     param[6] = new SqlParameter("@POD", POD);
     param[7] = new SqlParameter("@IS_InvoiceNO", IS_InvoiceNO);
     param[8] = new SqlParameter("@IS_Quantity", IS_Quantity);
     param[9] = new SqlParameter("@IS_UserType", IS_UserType);
     param[10] = new SqlParameter("@HandoverDate", HandoverDate);
     param[11] = new SqlParameter("@IS_LoanID", IS_LoanID);
     param[12] = new SqlParameter("@IS_PaymentMode", IS_PaymentMode);
     param[13] = new SqlParameter("@IS_Amount", IS_Amount);
     //param[14] = new SqlParameter("@IS_ModeOfDisburseMent", IS_ModeOfDisburseMent);
     param[14] = new SqlParameter("@IS_ApplicationReceivedStage", IS_ApplicationReceivedStage);
     param[15] = new SqlParameter("@UserCode", UserCode);
     try
     {

         return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_IssueStock", param);
     }
     catch (SqlException ex)
     {
         throw new Exception("Please check the Data as: " + ex.Message);
     }

 }
    public DataSet INV_UpdateIssueStock(int IS_CustID, int Quantity)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@IS_CustID", IS_CustID);
        param[1] = new SqlParameter("@Quantity", Quantity);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_UpdateIssueStock", param);
        return ds;
    }

    public DataSet INV_ModifyVendorData(string Remarks, int ID, string VendorUSerID, string vendor_stock_status, int vendor_stock_quantity, string filePath, 
        DateTime Tentative_Delivery_Date, string BIS_VendorStatus)
    {
        param = new SqlParameter[8];
        param[0] = new SqlParameter("@Remarks", Remarks);
        param[1] = new SqlParameter("@ID", ID);
        param[2] = new SqlParameter("@VendorUSerID", VendorUSerID);
        param[3] = new SqlParameter("@vendor_stock_status", vendor_stock_status);
        param[4] = new SqlParameter("@vendor_stock_quantity", vendor_stock_quantity);
        param[5] = new SqlParameter("@VendorImage", filePath);
        param[6] = new SqlParameter("@Tentative_Delivery_Date", Tentative_Delivery_Date);
        param[7] = new SqlParameter("@BIS_VendorStatus", BIS_VendorStatus);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_ModifyVendorData", param);
    }

    public DataSet INV_VendorProcessData(string vendorCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@vendorCode", vendorCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_VendorProcessData", param);
    }

    public DataSet VendorList()
    {
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_VendorList");
        return ds;
    }
    public DataSet usp_CheckPOCount(string PONumb)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@PONumb", PONumb);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_CheckPOCount", param);
    }

    public DataSet INV_orderprocess()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_orderprocess");
    }

    public DataSet INV_Finalorderprocess()
    {
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_Finalorderprocess");
    }
    public DataSet usp_FinpageCustExistOrNot(string CustID, string LoanID, string GroupID, string CenterID, string BranchID)
    {
        param = new SqlParameter[5];
        param[0] = new SqlParameter("@CustID", CustID);
        param[1] = new SqlParameter("@LoanID", LoanID);
        param[2] = new SqlParameter("@GroupID", GroupID);
        param[3] = new SqlParameter("@CenterID", CenterID);
        param[4] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_FinpageCustExistOrNot", param);
    }

     public DataSet CPPGetRegionStockData(string RegionID, string CPPHUB)
 {
     param = new SqlParameter[2];
     param[0] = new SqlParameter("@RegionID", RegionID);
     param[1] = new SqlParameter("@CPPHUB", CPPHUB);
     return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_CPPGetRegionStockData_", param);
 }

 public DataSet HUBWiseRegion(string HUBWiSE)
 {
     param = new SqlParameter[1];
     param[0] = new SqlParameter("@HUBWiSE", HUBWiSE);
     return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_RegionDetails", param);

 }
    public DataSet CPPBranchDetails(string clusterID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@clusterID", clusterID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_CPPBranchDetails", param);
    }
    public DataSet CPPHOApprovalForStock(string ApprovedBY, int approvedquantity, string ApprovalRemarks, int ID)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@ApprovedBY", ApprovedBY);
        param[1] = new SqlParameter("@approvedquantity", approvedquantity);
        param[2] = new SqlParameter("@ApprovalRemarks", ApprovalRemarks);
        param[3] = new SqlParameter("@ID", ID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_CPPHOApprovalForStock", param);
    }
    public DataSet CPPGetBranchStockData_ForHO(string BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_CPPGetBranchStockData_ForHO", param);
    }

    public DataSet ReverseStockDetails(string BranchID, string CustID, string LoanID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@BranchID", BranchID);
        param[1] = new SqlParameter("@CustID", CustID);
        param[2] = new SqlParameter("@LoanID", LoanID);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ReverseStockDetails", param);
        return ds;
    }

    public DataSet ReverseStock(int IssuedID, string Product, string Branch, int Quantity, string ReversedBy)
    {
        param = new SqlParameter[5];
        param[0] = new SqlParameter("@IssuedID", IssuedID);
        param[1] = new SqlParameter("@Product", Product);
        param[2] = new SqlParameter("@Branch", Branch);
        param[3] = new SqlParameter("@Quantity", Quantity);
        param[4] = new SqlParameter("@ReversedBy", ReversedBy);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_ReverseStock", param);
        return ds;
    }

    public DataSet DamageProductType()
    {

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_DamageProductType");
    }
    public DataSet DamageProductName(string ProductType)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@ProductType", ProductType);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_DamageProductName", param);
    }
    public DataSet ProductComplaintType(string ProductType, string ProductName)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@ProductType", ProductType);
        param[1] = new SqlParameter("@ProductName", ProductName);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_ComplaintTypes", param);
    }
    public DataSet DamageProducts(string DP_Product_Type, string DP_Product_Name, string DP_Complaint_Types, int DP_Damaged_Quantity, string DP_DamageProduct_Image, string DP_Branch, string DP_Region, string DP_Remarks, int productID)
    {
        param = new SqlParameter[9];
        param[0] = new SqlParameter("@DP_Product_Type", DP_Product_Type);
        param[1] = new SqlParameter("@DP_Product_Name", DP_Product_Name);
        param[2] = new SqlParameter("@DP_Complaint_Types", DP_Complaint_Types);
        param[3] = new SqlParameter("@DP_Damaged_Quantity", DP_Damaged_Quantity);
        param[4] = new SqlParameter("@DP_DamageProduct_Image", DP_DamageProduct_Image);
        param[5] = new SqlParameter("@DP_Branch", DP_Branch);
        param[6] = new SqlParameter("@DP_Region", DP_Region);
        param[7] = new SqlParameter("@DP_Remarks", DP_Remarks);
        param[8] = new SqlParameter("@productID", productID);
      
try
{

    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_DamageProducts", param);
}
catch (SqlException ex)
{
    throw new Exception(ex.Message);
}
    }
    public DataSet DamageProductsGrid(string UserCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserCode", UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_DamageProductsGrid", param);
    }

    public DataSet adjustProductName(string ProductType)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@ProductType", ProductType);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_adjustProductName", param);
    }

    public DataSet AdjustComplaintTypes(string ProductType, string ProductName)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@ProductType", ProductType);
        param[1] = new SqlParameter("@ProductName", ProductName);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_AdjustComplaintTypes", param);
    }
    public DataSet DashboardInvoiceCount(string UserCode, string Region, string productID,string branchid,string RegionName)
    {
        param = new SqlParameter[5];
        param[0] = new SqlParameter("@UserCode", UserCode);
        param[1] = new SqlParameter("@RegionID", Region);
        param[2] = new SqlParameter("@productID", productID);
        param[3] = new SqlParameter("@branchid", branchid);
        param[4] = new SqlParameter("@RegionName", RegionName);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_DashboardInvoiceCount", param);
    }

    public DataSet VendorStatus(int ID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@ID", ID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_VendorStatus", param);
    }

    public DataSet ModifyStatusOfVendor(int BISID, string Status, string BIS_VendorStatus, string BIS_vendor_remarks)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@BISID", BISID);
        param[1] = new SqlParameter("@Status", Status);
        param[2] = new SqlParameter("@BIS_VendorStatus", BIS_VendorStatus);
        param[3] = new SqlParameter("@BIS_vendor_remarks", BIS_vendor_remarks);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyStatusOfVendor", param);
    }

    public DataSet DistinctviewPONumber(string branchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@branchID", branchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_DistinctviewPONumber", param);
    }
    public DataSet ComplaintBindAsPerProduct(string ProductId)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@ProductId", ProductId);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ComplaintBindAsPerProduct", param);
    }

    public DataSet CPPGetBranchStockData_(string BranchID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_CPPGetBranchStockData_", param);
    }
    public DataSet SelectOrderStatus(string branch)
 {
     param = new SqlParameter[1];
     param[0] = new SqlParameter("@branch", branch);
     return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_SelectOrderStatus", param);
 }
public DataSet BindOrderStatus(string Status , string BranchCode, string HOLogins)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@Status", Status);
        param[1] = new SqlParameter("@BranchCode", BranchCode);
        param[2] = new SqlParameter("@HOLogins", HOLogins);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_BindOrderStatus", param);
    }

    public DataSet BranchWiseGridForHOD(string branchID)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@branchID", branchID);

        return SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_BranchWiseGridForHOD", param);
    }
    public DataSet GetVendorListForHOD(string BranchID) /*int VendorID*/
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@BranchID", BranchID);
        //param[1] = new SqlParameter("@VendorID", VendorID);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_GetVendorListForHOD", param);
        return ds;
    }

    public DataSet GetDamagedStock(string IS_CustID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@IS_CustID", IS_CustID);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_GetDamagedStock", param);
        return ds;
    }

    public DataSet insertDamageStock(string Is_DamageProduct_ReceivedBY, int IS_Damage_stock_Quantity, string IS_Damage_ProductComplaint, string IS_Damage_Product_Type,
 string IS_Damage_Product_Name, string IS_Damage_Image, string Loan_ID, string IS_Name, string IS_Branch, string IS_SpouseName,
 string IS_MobileNO, string Is_CustID, string IS_Product, string IS_AvailableStockInBranch)
    {
        param = new SqlParameter[14];
        param[0] = new SqlParameter("@Is_DamageProduct_ReceivedBY", Is_DamageProduct_ReceivedBY);
        param[1] = new SqlParameter("@IS_Damage_stock_Quantity", IS_Damage_stock_Quantity);
        param[2] = new SqlParameter("@IS_Damage_ProductComplaint", IS_Damage_ProductComplaint);
        param[3] = new SqlParameter("@IS_Damage_Product_Type", IS_Damage_Product_Type);
        param[4] = new SqlParameter("@IS_Damage_Product_Name", IS_Damage_Product_Name);
        param[5] = new SqlParameter("@IS_Damage_Image", IS_Damage_Image);
        param[6] = new SqlParameter("@Loan_ID", Loan_ID);
        param[7] = new SqlParameter("@IS_Name", IS_Name);
        param[8] = new SqlParameter("@IS_Branch", IS_Branch);
        param[9] = new SqlParameter("@IS_SpouseName", IS_SpouseName);
        param[10] = new SqlParameter("@IS_MobileNO", IS_MobileNO);
        param[11] = new SqlParameter("@Is_CustID", Is_CustID);
        param[12] = new SqlParameter("@IS_ProductID", IS_Product);
        param[13] = new SqlParameter("@IS_AvailableStockInBranch", IS_AvailableStockInBranch);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_insertDamageStock", param);
    }

    public DataSet RegionWiseCount(string UserCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserCode", UserCode);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "test_RegionWiseCount", param);
    }

    public DataSet BranchWiseCount(string UserCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserCode", UserCode);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_BranchWiseCount", param);
    }

    public DataSet usp_BranchDetailsByRegionForTransfer(string clusterID, string BranchCode)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@clusterID", clusterID);
        param[1] = new SqlParameter("@BranchCode", BranchCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_BranchDetailsByRegionForTransfer", param);
    }

    public DataSet usp_AvailableStockOfBranch(string FBranch, string TBranch, string ProductID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@FBranch", FBranch);
        param[1] = new SqlParameter("@TBranch", TBranch);
        param[2] = new SqlParameter("@ProductID", ProductID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_AvailableStockOfBranch", param);
    }

   public DataSet usp_InsertStockTransfer(string ST_ProductID, string ST_FromBranch, string ST_ToBranch, string ST_SendQuantity, string ST_Remarks, string InsertBy)
 {
     param = new SqlParameter[6];
     param[0] = new SqlParameter("@ST_ProductID", ST_ProductID);
     param[1] = new SqlParameter("@ST_FromBranch", ST_FromBranch);
     param[2] = new SqlParameter("@ST_ToBranch", ST_ToBranch);
     param[3] = new SqlParameter("@ST_SendQuantity", ST_SendQuantity);
     param[4] = new SqlParameter("@ST_Remarks", ST_Remarks);
     param[5] = new SqlParameter("@InsertBy", InsertBy);
     try
     {

         return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_InsertStockTransfer", param);
     }
     catch (SqlException ex)
     {
         throw new Exception("Please check the Data as: " + ex.Message);
     }
 }

    public DataSet usp_RecStockTransferDetails(string RecBranchCode, string SentBranchCode)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@RecBranchCode", RecBranchCode);
        param[1] = new SqlParameter("@SentBranchCode", SentBranchCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_RecStockTransferDetails", param);
    }

    public DataSet usp_ModifyRecTransfer(string ReceivedBy, string ReceivedRemarks, int? ReceivedQuantity, int? ReverseQuantity, int STID, string product_id, string SentBy)
    {
        param = new SqlParameter[7];
        param[0] = new SqlParameter("@ReceivedBy", ReceivedBy);
        param[1] = new SqlParameter("@ReceivedRemarks", ReceivedRemarks);
        param[2] = new SqlParameter("@ReceivedQuantity", ReceivedQuantity);
        param[3] = new SqlParameter("@ReverseQuantity", ReverseQuantity);
        param[4] = new SqlParameter("@STID", STID);
        param[5] = new SqlParameter("@product_id", product_id);
        param[6] = new SqlParameter("@SentBy", SentBy);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyRecTransfer", param);
    }

    public DataSet usp_StockTransferDetails(string RecBranchCode, string RegionID, string branchID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@RecBranchCode", RecBranchCode);
        param[1] = new SqlParameter("@RegionID", RegionID);
        param[2] = new SqlParameter("@branchID", branchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_StockTransferDetails", param);
    }

    public DataSet DateWiseCount(DateTime from, DateTime to)
    {
        param = new SqlParameter[2];

        param[0] = new SqlParameter("@from", SqlDbType.DateTime);
        param[0] = new SqlParameter("@from", from);
        param[1] = new SqlParameter("@to", SqlDbType.DateTime);
        param[1] = new SqlParameter("@to", to);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "test_DateWiseCoun", param);
    }
    public DataSet RegionWiseCount(string UserCode, string branchID, string vendorLogin,string productID)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@UserCode", UserCode);
        param[1] = new SqlParameter("@branchID", branchID);
        param[2] = new SqlParameter("@vendorLogin", vendorLogin);
        param[3] = new SqlParameter("@productID", productID);
        //param[2] = new SqlParameter("@from", SqlDbType.DateTime);
        //param[2] = new SqlParameter("@from", from);
        //param[3] = new SqlParameter("@to", SqlDbType.DateTime);
        //param[3] = new SqlParameter("@to", to);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "test_RegionWiseCount", param);
    }
    public DataSet BindvendorStatus(int UserCode,  string branchID, string regionID, string product)
    {
        param = new SqlParameter[4];

        param[0] = new SqlParameter("@UserCode", UserCode);
        param[1] = new SqlParameter("@branchID", branchID);
        param[2] = new SqlParameter("@regionID", regionID);
        param[3] = new SqlParameter("@product", product);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "vendorProductsCharts", param);
    }
    public DataSet DashboardCount(string UserCode, string regionID, string branchID, string product)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@UserCode", UserCode);
        param[1] = new SqlParameter("@regionID", regionID);
        param[2] = new SqlParameter("@branchID", branchID);
        param[3] = new SqlParameter("@product", product);


        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_DashboardCount", param);
    }
   public DataTable IssueStockReport(DateTime FromDate, DateTime ToDate, string BranchID, string LoginType)
{
    con.Open();
    SqlCommand cmd = new SqlCommand("usp_IssueStockReport", con);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.CommandTimeout = 800;
    cmd.Parameters.AddWithValue("@Fromdate", FromDate);
    cmd.Parameters.AddWithValue("@ToDate", ToDate);
    cmd.Parameters.AddWithValue("@BranchID", BranchID);
    cmd.Parameters.AddWithValue("@LoginType", LoginType);
    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    DataTable dt = new DataTable();
    adapter.Fill(dt);
    con.Close();
    return dt;
}

public DataSet GETREPORTLIST()
{
    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GETREPORTLIST");
}

public DataSet BindProducts(string branchID, string productID)
{
    param = new SqlParameter[2];
    param[0] = new SqlParameter("@BranchID", branchID);
    param[1] = new SqlParameter("@ProductID", productID);

    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "BindProductList", param);
}
public DataSet insertProductStock(string branchID, string productID, string UserCode, int inStock,string Remarks)
{
    param = new SqlParameter[5];
    param[0] = new SqlParameter("@branchID", branchID);
    param[1] = new SqlParameter("@productID", productID);
    param[2] = new SqlParameter("@UserCode", UserCode);
    param[3] = new SqlParameter("@inStock", inStock);
    param[4] = new SqlParameter("@Remarks", Remarks);
    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_Product_In_Stock", param);
}

 public DataTable TransferStockReport(DateTime FromDate, DateTime ToDate, string BranchID, string LoginType)
 {
     con.Open();
     SqlCommand cmd = new SqlCommand("INV_TransferStockReport", con);
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.CommandTimeout = 800;
     cmd.Parameters.AddWithValue("@Fromdate", FromDate);
     cmd.Parameters.AddWithValue("@ToDate", ToDate);
     cmd.Parameters.AddWithValue("@BranchID", BranchID);
     cmd.Parameters.AddWithValue("@LoginType", LoginType);
     SqlDataAdapter adapter = new SqlDataAdapter(cmd);
     DataTable dt = new DataTable();
     adapter.Fill(dt);
     con.Close();
     return dt;
 }

 public DataTable AvailableStockReports(DateTime FromDate, DateTime ToDate, string BranchID, string LoginType)
 {
     con.Open();
     SqlCommand cmd = new SqlCommand("INV_AvailableStockReports", con);
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.CommandTimeout = 800;
     cmd.Parameters.AddWithValue("@Fromdate", FromDate);
     cmd.Parameters.AddWithValue("@ToDate", ToDate);
     cmd.Parameters.AddWithValue("@BranchID", BranchID);
     cmd.Parameters.AddWithValue("@LoginType", LoginType);
     SqlDataAdapter adapter = new SqlDataAdapter(cmd);
     DataTable dt = new DataTable();
     adapter.Fill(dt);
     con.Close();
     return dt;
 }

 public DataTable IssueStockReverseReport(DateTime FromDate, DateTime ToDate, string BranchID, string LoginType)
 {
     con.Open();
     SqlCommand cmd = new SqlCommand("INV_IssueStockReverseReport", con);
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.CommandTimeout = 800;
     cmd.Parameters.AddWithValue("@Fromdate", FromDate);
     cmd.Parameters.AddWithValue("@ToDate", ToDate);
     cmd.Parameters.AddWithValue("@BranchID", BranchID);
     cmd.Parameters.AddWithValue("@LoginType", LoginType);
     SqlDataAdapter adapter = new SqlDataAdapter(cmd);
     DataTable dt = new DataTable();
     adapter.Fill(dt);
     con.Close();
     return dt;
 }

 public DataTable ReportsOrder(DateTime FromDate, DateTime ToDate, string BranchID, string LoginType)
 {
     con.Open();
     SqlCommand cmd = new SqlCommand("INV_ReportsOrder", con);
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.CommandTimeout = 800;
     cmd.Parameters.AddWithValue("@Fromdate", FromDate);
     cmd.Parameters.AddWithValue("@ToDate", ToDate);
     cmd.Parameters.AddWithValue("@BranchID", BranchID);
     cmd.Parameters.AddWithValue("@LoginType", LoginType);
     SqlDataAdapter adapter = new SqlDataAdapter(cmd);
     DataTable dt = new DataTable();
     adapter.Fill(dt);
     con.Close();
     return dt;
 }

public DataSet ProductBranchMapping(string RegionID, string BranchID)
{
    param = new SqlParameter[2];
    param[0] = new SqlParameter("@RegionID", RegionID);
    param[1] = new SqlParameter("@BranchID", BranchID);

    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_ProductBranchMapping", param);

}

  public DataSet InsertproductMapping(string branchID, string productID, string UserCode)
  {
      param = new SqlParameter[3];
      param[0] = new SqlParameter("@branchID", branchID);
      param[1] = new SqlParameter("@productID", productID);
      param[2] = new SqlParameter("@UserCode", UserCode);

      try
      {

          return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_ProductMapping", param);
      }
      catch (SqlException ex)
      {
          throw new Exception("Please check the Data as: " + ex.Message);
      }
  }

public DataTable CPPEscalationReport(DateTime FromDate, DateTime ToDate, string BranchID, string LoginType)
{
    con.Open();
    SqlCommand cmd = new SqlCommand("usp_CPPEscalationReport", con);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.CommandTimeout = 800;
    cmd.Parameters.AddWithValue("@Fromdate", FromDate);
    cmd.Parameters.AddWithValue("@ToDate", ToDate);
    cmd.Parameters.AddWithValue("@BranchID", BranchID);
    cmd.Parameters.AddWithValue("@LoginType", LoginType);
    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    DataTable dt = new DataTable();
    adapter.Fill(dt);
    con.Close();
    return dt;
}

 public DataSet ModifyProductMappingData(int ID)
{
    param = new SqlParameter[1];
    param[0] = new SqlParameter("@ID", ID);
    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyProductMappingData", param);

}

public DataSet INV_BIS_Delete(int ID, string userCode, string Remarks)
{
    param = new SqlParameter[3];
    param[0] = new SqlParameter("@ID", ID);
    param[1] = new SqlParameter("@userCode", userCode);
    param[2] = new SqlParameter("@Remarks", Remarks);
    return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_BIS_Delete", param);
}

public DataTable stockAdjustment(DateTime FromDate, DateTime ToDate, string BranchID, string LoginType)
 {
     con.Open();
     SqlCommand cmd = new SqlCommand("stockAdjustment", con);
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.CommandTimeout = 800;
     cmd.Parameters.AddWithValue("@FromDate", FromDate);
     cmd.Parameters.AddWithValue("@ToDate", ToDate);
     cmd.Parameters.AddWithValue("@BranchID", BranchID);
     cmd.Parameters.AddWithValue("@LoginType", LoginType);
     SqlDataAdapter adapter = new SqlDataAdapter(cmd);
     DataTable dt = new DataTable();
     adapter.Fill(dt);
     con.Close();
     return dt;
 }
    public DataSet INV_CPPEscalations(string UserCode , string RegionCode, string BranchID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@UserCode", UserCode);
        param[1] = new SqlParameter("@RegionCode", RegionCode);
        param[2] = new SqlParameter("@branchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_CPPEscalations", param);
    }
    public DataSet INV_InsertEscalations(string EM_CustID
           , string EM_Name
           , string EM_DamageProduct_ReceivedBY
           , string EM_SpouseName
           , string EM_MobileNO
           , int EM_Damage_stock_Quantity
           , string EM_Damage_Product_Type
           , string EM_Damage_Product_Name
           , string EM_Damage_ProductComplaint
           , DateTime EM_Damage_ProductComplaint_date
           , string EM_AvailableStockInBranch
           , string EM_ProductComplaintbyHO
           , string EM_Remarks
           ,string EM_ActionTakenBY,
         int EM_IssueID, string EM_LoanID, string  Em_ProductID)
    {
        param = new SqlParameter[17];
        param[0] = new SqlParameter("@EM_CustID", EM_CustID);
        param[1] = new SqlParameter("@EM_Name", EM_Name);
        param[2] = new SqlParameter("@EM_DamageProduct_ReceivedBY", EM_DamageProduct_ReceivedBY);
        param[3] = new SqlParameter("@EM_SpouseName", EM_SpouseName);
        param[4] = new SqlParameter("@EM_MobileNO", EM_MobileNO);
        param[5] = new SqlParameter("@EM_Damage_stock_Quantity", EM_Damage_stock_Quantity);
        param[6] = new SqlParameter("@EM_Damage_Product_Type", EM_Damage_Product_Type);
        param[7] = new SqlParameter("@EM_Damage_Product_Name", EM_Damage_Product_Name);
        param[8] = new SqlParameter("@EM_Damage_ProductComplaint", EM_Damage_ProductComplaint);
        param[9] = new SqlParameter("@EM_Damage_ProductComplaint_date", EM_Damage_ProductComplaint_date);
        param[10] = new SqlParameter("@EM_AvailableStockInBranch", EM_AvailableStockInBranch);
        param[11] = new SqlParameter("@EM_ProductComplaintbyHO", EM_ProductComplaintbyHO);
        param[12] = new SqlParameter("@EM_Remarks", EM_Remarks);
        param[13] = new SqlParameter("@EM_ActionTakenBY", EM_ActionTakenBY);
        param[14] = new SqlParameter("@EM_IssueID", EM_IssueID);
        param[15] = new SqlParameter("@EM_LoanID", EM_LoanID);
        param[16] = new SqlParameter("@Em_ProductID", Em_ProductID);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_InsertEscalations", param);
    }
    public DataSet INV_Reject_Escalation(string EM_CustID
           , string EM_Name
           , string EM_DamageProduct_ReceivedBY
           , string EM_SpouseName
           , string EM_MobileNO
           , int EM_Damage_stock_Quantity
           , string EM_Damage_Product_Type
           , string EM_Damage_Product_Name
           , string EM_Damage_ProductComplaint
           , DateTime EM_Damage_ProductComplaint_date
           , string EM_AvailableStockInBranch
           , string EM_ProductComplaintbyHO
           , string EM_Remarks
           , string EM_ActionTakenBY,
         int EM_IssueID, string EM_LoanID, string Em_ProductID,
         string Em_VendorConfirmationValue)
    {
        param = new SqlParameter[18];
        param[0] = new SqlParameter("@EM_CustID", EM_CustID);
        param[1] = new SqlParameter("@EM_Name", EM_Name);
        param[2] = new SqlParameter("@EM_DamageProduct_ReceivedBY", EM_DamageProduct_ReceivedBY);
        param[3] = new SqlParameter("@EM_SpouseName", EM_SpouseName);
        param[4] = new SqlParameter("@EM_MobileNO", EM_MobileNO);
        param[5] = new SqlParameter("@EM_Damage_stock_Quantity", EM_Damage_stock_Quantity);
        param[6] = new SqlParameter("@EM_Damage_Product_Type", EM_Damage_Product_Type);
        param[7] = new SqlParameter("@EM_Damage_Product_Name", EM_Damage_Product_Name);
        param[8] = new SqlParameter("@EM_Damage_ProductComplaint", EM_Damage_ProductComplaint);
        param[9] = new SqlParameter("@EM_Damage_ProductComplaint_date", EM_Damage_ProductComplaint_date);
        param[10] = new SqlParameter("@EM_AvailableStockInBranch", EM_AvailableStockInBranch);
        param[11] = new SqlParameter("@EM_ProductComplaintbyHO", EM_ProductComplaintbyHO);
        param[12] = new SqlParameter("@EM_Remarks", EM_Remarks);
        param[13] = new SqlParameter("@EM_ActionTakenBY", EM_ActionTakenBY);
        param[14] = new SqlParameter("@EM_IssueID", EM_IssueID);
        param[15] = new SqlParameter("@EM_LoanID", EM_LoanID);
        param[16] = new SqlParameter("@Em_ProductID", Em_ProductID);
        param[17] = new SqlParameter("@Em_VendorConfirmationValue", Em_VendorConfirmationValue);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_Reject_Escalation", param);
    }  
    public DataSet INV_CPPVendorConfirmation(int IssueID, string ActionTakenBy, string EM_Remarks,  DateTime GetDate, string Em_VendorConfirmationValue)
    {
        param = new SqlParameter[5];
        param[0] = new SqlParameter("@EM_IssueID", IssueID);
        param[1] = new SqlParameter("@EM_ActionTakenBY", ActionTakenBy);
        param[2] = new SqlParameter("@EM_Remarks", EM_Remarks);
        param[3] = new SqlParameter("@GetDate", GetDate);
        param[4] = new SqlParameter("@Em_VendorConfirmationValue", Em_VendorConfirmationValue);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_CPPVendorConfirmation", param);
    }  
    public DataSet INV_CPPVendorConfirmEscalations(string UserCode, string RegionCode, string BranchID)
    {
        param = new SqlParameter[3];
        param[0] = new SqlParameter("@UserCode", UserCode);
        param[1] = new SqlParameter("@RegionCode", RegionCode);
        param[2] = new SqlParameter("@branchID", BranchID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_CPPVendorConfirmEscalations", param);
    }
    public DataSet INV_CPPVendorActioned(int IssueID, string ActionTakenBy, string EM_Remarks,string TechVisit,string closure,string Status,string productID)
    {
        param = new SqlParameter[7];
        param[0] = new SqlParameter("@EM_IssueID", IssueID);
        param[1] = new SqlParameter("@EM_ActionTakenBY", ActionTakenBy);
        param[2] = new SqlParameter("@EM_Remarks", EM_Remarks);
        param[3] = new SqlParameter("@TechVisit", TechVisit);
        param[4] = new SqlParameter("@closure", closure);
        param[5] = new SqlParameter("@Status", Status);
        param[6] = new SqlParameter("@productID", productID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_CPPVendorActioned", param);
    }
    public DataSet SelectStatus(string userCode,string Region)
    {
        param = new SqlParameter[2];
        param[0] = new SqlParameter("@userCode", userCode);
        param[1] = new SqlParameter("@Region", Region);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "SelectStatus", param);
    }  
    public DataSet ViewEscalation(string Region, string Branch, string Status, string userCode)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@Region", Region);
        param[1] = new SqlParameter("@Branch", Branch);
        param[2] = new SqlParameter("@Status", Status);
        param[3] = new SqlParameter("@userCode", userCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "ViewEscalation", param);
    }
    public DataSet ViewEscalationDetails(string IssueID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@IssuedID", IssueID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "ViewEscalationDetails", param);
    }  
    public DataSet insertBranchfeedback(string Closure, string status ,int IssueID, string EM_BranchConfirmationRemarks)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@Closure", Closure);
        param[1] = new SqlParameter("@status", status);
        param[2] = new SqlParameter("@IssuedID", IssueID);
        param[3] = new SqlParameter("@EM_BranchConfirmationRemarks", EM_BranchConfirmationRemarks);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "insertBranchfeedback", param);
    }
    public DataSet BranchDetailsByDivisionCluster( string UserCode, string ClusterID)
    {
        param = new SqlParameter[2];
     
        param[0] = new SqlParameter("@UserCode", UserCode);
        param[1] = new SqlParameter("@ClusterID", ClusterID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_BranchDetailsByDivisionCluster", param);
    }
    public DataSet insertReconciliationData(string EmployeeID ,
   string EmployeeName,
     string Designation,
       string BranchID,
      string BranchName,
    DateTime        SR_Date,
     string Product_Name,
      string ProductID,
       int     StockONIMSDashboard,
       int     PhysicalStockPresentInBranch,
        int    TotalDamagedUnits,
         string OtherFeedback,
         string UserCode)
    {
        param = new SqlParameter[13];
        param[0] = new SqlParameter("@EmployeeID", EmployeeID);
        param[1] = new SqlParameter("@EmployeeName", EmployeeName);
        param[2] = new SqlParameter("@Designation", Designation);
        param[3] = new SqlParameter("@BranchID", BranchID);
        param[4] = new SqlParameter("@BranchName", BranchName);
        param[5] = new SqlParameter("@SR_Date", SR_Date);
        param[6] = new SqlParameter("@Product_Name", Product_Name);
        param[7] = new SqlParameter("@ProductID", ProductID);
        param[8] = new SqlParameter("@StockONIMSDashboard", StockONIMSDashboard);
        param[9] = new SqlParameter("@PhysicalStockPresentInBranch", PhysicalStockPresentInBranch);
        param[10] = new SqlParameter("@TotalDamagedUnits", TotalDamagedUnits);
        param[11] = new SqlParameter("@OtherFeedback", OtherFeedback);
        param[12] = new SqlParameter("@UserCode", @UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "insertReconciliationData", param);
    }
    public DataTable FormatVendorDelivery( string vendorCode)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("INV_BulkOrderDelivery", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 800;   
        cmd.Parameters.AddWithValue("@vendorCode", vendorCode);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();
        return dt;
    }
    public DataSet INV_BulkVendorData(string Remarks, int ID, string VendorUSerID, string vendor_stock_status, int vendor_stock_quantity, string filePath,
        DateTime Tentative_Delivery_Date, string BIS_VendorStatus)
    {
        param = new SqlParameter[8];
        param[0] = new SqlParameter("@Remarks", Remarks);
        param[1] = new SqlParameter("@ID", ID);
        param[2] = new SqlParameter("@VendorUSerID", VendorUSerID);
        param[3] = new SqlParameter("@vendor_stock_status", vendor_stock_status);
        param[4] = new SqlParameter("@vendor_stock_quantity", vendor_stock_quantity);
        param[5] = new SqlParameter("@VendorImage", filePath);
        param[6] = new SqlParameter("@Tentative_Delivery_Date", Tentative_Delivery_Date);
        param[7] = new SqlParameter("@BIS_VendorStatus", BIS_VendorStatus);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_BulkVendorData", param);
    }
    public DataSet GetProductListforDashBoard(string UserCode, string loginType, string Region, string Division, string Cluster, string branch)
    {
        param = new SqlParameter[6];
        param[0] = new SqlParameter("@UserCode", UserCode);
        param[1] = new SqlParameter("@loginType", loginType);
        param[2] = new SqlParameter("@Region", Region);
        param[3] = new SqlParameter("@Division", Division);
        param[4] = new SqlParameter("@Cluster", Cluster);
        param[5] = new SqlParameter("@branch", branch);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetProductListforDashBoard", param);
    }
    public DataSet ProductMappingwithCOs(string ID)
    {
        param = new SqlParameter[1];

        param[0] = new SqlParameter("@ID", ID);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "ProductMappingwithCOs", param);
    }
    public DataSet INV_CenterOfficer(string ID)
    {
        param = new SqlParameter[1];

        param[0] = new SqlParameter("@BranchID", ID);

        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_CenterOfficer", param);
    }

    public DataSet INV_insertINProductMappingWIthCO(string PMC_COID, string PMC_ProductID, string PMC_BranchID, int PMC_BQuantity, string PMC_MappedBy)
    {
        param = new SqlParameter[6];

        param[0] = new SqlParameter("@PMC_COID", PMC_COID);
        param[1] = new SqlParameter("@PMC_ProductID", PMC_ProductID);
        param[2] = new SqlParameter("@PMC_BranchID", PMC_BranchID);
        param[3] = new SqlParameter("@PMC_BQuantity", PMC_BQuantity);

        param[4] = new SqlParameter("@PMC_MappedBy", PMC_MappedBy);
        try
        {

            return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_insertINProductMappingWIthCO", param);
        }
        catch (SqlException ex)
        {
            throw new Exception("Please check the Data as: " + ex.Message);
        }

        
    }
    public DataSet INV_TransferCO(string UserCode)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@UserCode", UserCode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_TransferCO", param);
    }
    public DataSet INV_ModifyCODetails(string UserAccountID, string RegionID, string branch, string usercode)
    {
        param = new SqlParameter[4];
        param[0] = new SqlParameter("@UserAccountID", UserAccountID);
        param[1] = new SqlParameter("@RegionID", RegionID);
        param[2] = new SqlParameter("@branch", branch);
        param[3] = new SqlParameter("@usercode", usercode);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "INV_ModifyCODetails", param);
    }
    public DataSet GetProductMappingWithCODetails(string COID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@COID", COID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetProductMappingWithCODetails", param);
    }

    public DataSet ProductMappingWithCO(int ID, int CRecQuantity, string CRecBy, string Remarks, string branch_id, int product_id)
    {
        param = new SqlParameter[6];
        param[0] = new SqlParameter("@ID", ID);
        param[1] = new SqlParameter("@CRecQuantity", CRecQuantity);
        param[2] = new SqlParameter("@CRecBy", CRecBy);
        param[3] = new SqlParameter("@Remarks", Remarks);
        param[4] = new SqlParameter("@branch_id", branch_id);
        param[5] = new SqlParameter("@product_id", product_id);
        ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ProductMappingWithCO", param);
        return ds;
    }
    public DataSet returnProductByCO(string COID)
    {
        param = new SqlParameter[1];
        param[0] = new SqlParameter("@COID", COID);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_returnProductByCO", param);
    }

    public DataSet ModifyProductStockByCO(int ID, int ReturnStock, string ReturnRemarks, string ReturnBy, string branch_id, int product_id)
    {
        param = new SqlParameter[6];
        param[0] = new SqlParameter("@ID", ID);
        param[1] = new SqlParameter("@ReturnStock", ReturnStock);
        param[2] = new SqlParameter("@ReturnRemarks", ReturnRemarks);
        param[3] = new SqlParameter("@ReturnBy", ReturnBy);
        param[4] = new SqlParameter("@branch_id", branch_id);
        param[5] = new SqlParameter("@product_id", product_id);
        return ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_ModifyProductStockByCO", param);
    }
}
