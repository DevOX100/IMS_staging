using gsmClasses;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inventory_StockTransfer : System.Web.UI.Page
{

    Inventory_System ISS = new Inventory_System();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindBranch();
            BindProductType();
        }
    }

    protected void BindBranch()
    {
        string clusterID = Session["RegionId"].ToString();
        string BranchCode = Session["UserCode"].ToString();
        ds = ISS.usp_BranchDetailsByRegionForTransfer(clusterID, BranchCode);
        ddlBranch.DataSource = ds;
        ddlBranch.DataTextField = "Branch_Name";
        ddlBranch.DataValueField = "Branch_ID";
        ddlBranch.DataBind();
        ddlBranch.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void BindProductType()
    {
        DataSet ds = ISS.DamageProductType();
        if (ds != null && ds.Tables.Count > 0)
        {
            ddlProductType.DataSource = ds.Tables[0];
            ddlProductType.DataTextField = "Pc_Product_Type";
            ddlProductType.DataValueField = "Pc_Product_Type";
            ddlProductType.DataBind();
            ddlProductType.Items.Insert(0, new ListItem("Select", "0"));
        }
    }

    protected void BindProductName()
    {
        string ProductType = ddlProductType.SelectedValue;
        DataSet ds = ISS.adjustProductName(ProductType);
        if (ds != null && ds.Tables.Count > 0)
        {
            ddlProductName.DataSource = ds.Tables[0];
            ddlProductName.DataTextField = "PC_Product_Name";
            ddlProductName.DataValueField = "PC_ProductID";
            ddlProductName.DataBind();
            ddlProductName.Items.Insert(0, new ListItem("Select", "0"));
        }
    }

    protected void ddlProductType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindProductName();
    }

    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {

        string FBranch = Session["UserCode"].ToString();
        string TBranch = ddlBranch.SelectedValue;
        string ProductID = ddlProductName.SelectedValue;
        ds = ISS.usp_AvailableStockOfBranch(FBranch, TBranch, ProductID);
        if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0)
        {
            //lblFromBranchAvlblStock.InnerText = "Available " + (ds.Tables[0].Rows[0]["BRANCH_NAME"]).ToString() + " Stock :";
            //lblToBranchAvlblStock.InnerText = "Available " + (ds.Tables[1].Rows[0]["BRANCH_NAME"]).ToString() + " Stock :";

            lblFromBranchAvlblStock.InnerText = "From Branch Available Stock :";
            lblToBranchAvlblStock.InnerText = "To Branch Available Stock :";

            txtFromBranchAvlblStock.Text = (ds.Tables[0].Rows[0]["available_stock"]).ToString();

            if(ds.Tables[1].Rows.Count == 0)
            {
                txtToBranchAvlblStock.Text = "0";
            }
            else
            {
                txtToBranchAvlblStock.Text = (ds.Tables[1].Rows[0]["available_stock"]).ToString();
            }


            txtFromBranchAvlblStock.Visible = true;
            txtToBranchAvlblStock.Visible = true;
            lblFromBranchAvlblStock.Visible = true;
            lblToBranchAvlblStock.Visible = true;
        }

        else
        {
            txtFromBranchAvlblStock.Text = "0";
            txtToBranchAvlblStock.Text = "0";
            txtFromBranchAvlblStock.Visible = true;
            txtToBranchAvlblStock.Visible = true;
            lblFromBranchAvlblStock.Visible = true;
            lblToBranchAvlblStock.Visible = true;
        }
        
    }

    protected void Clear()
    {
        ddlBranch.SelectedValue = "0";
        ddlProductType.SelectedValue = "0";
        ddlProductName.SelectedValue = "0";
        txtQuantity.Text = "";
        txtRemarks.Text = "";
        txtFromBranchAvlblStock.Visible = false;
        txtToBranchAvlblStock.Visible = false;
        lblFromBranchAvlblStock.Visible = false;
        lblToBranchAvlblStock.Visible = false;
    }

   protected void btnSubmit_Click(object sender, EventArgs e)
  {

      string ST_ProductID = ddlProductName.SelectedValue;
      string ST_FromBranch = Session["UserCode"].ToString();
      string ST_ToBranch = ddlBranch.SelectedValue;
      string ST_SendQuantity = txtQuantity.Text;
      string ST_Remarks = txtRemarks.Text;
      string InsertBy = Session["UserCode"].ToString();
   
      try
      {
          ds = ISS.usp_InsertStockTransfer(ST_ProductID, ST_FromBranch, ST_ToBranch, ST_SendQuantity, ST_Remarks, InsertBy);
          ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Stock has been transferred successfully', 'success');", true);
          Clear();
      }
      catch (Exception ex)
      {
          ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Invalid!', '" + ex.Message.Replace("'", "\\'") + "', 'error');", true);
      }
  }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
}