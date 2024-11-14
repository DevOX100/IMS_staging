using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_BranchMaster : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    Billing_System bs = new Billing_System();
    Inventory_System ISS = new Inventory_System();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRegion();
            BindGrid();
        }
    }

    protected void BindRegion()
    {
        ds = bs.RegionDetails();
        ddlRegion.DataSource = ds;
        ddlRegion.DataTextField = "R_Name";
        ddlRegion.DataValueField = "R_Code";
        ddlRegion.DataBind();
        ddlRegion.Items.Insert(0, new ListItem("Select", "0"));

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        cleardata();
    }
    private void cleardata()
    {
        txtBranchCode.Text = "";
        txtBranchName.Text = "";
        ddlRegion.SelectedValue = "0";
    }
    protected void btnSubmit_Click(object sender,EventArgs e)
    {
        string branchcode = txtBranchCode.Text;
        string branchname  = txtBranchName.Text;
        string CLUSTER_ID = ddlRegion.SelectedValue;
        string CLUSTER_NAME = ddlRegion.SelectedItem.Text;
        string Address = txtAddress.Text;

        bs.InsertBranchData(branchcode,branchname, CLUSTER_ID, CLUSTER_NAME, Address);
        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Saved!', 'Your details have been saved successfully.', 'success');", true);
        BindGrid();
        cleardata();

    }
    protected void BindGrid()
    {
        BranchGrid.DataSource = bs.GetBranchDetails();
        BranchGrid.DataBind();
    }


    protected void BranchGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ChangeStatus")
        {
            string BranchID = e.CommandArgument.ToString();
            bs.ModifyBranchData(BranchID);
           // BindGrid();
        }
    }

    protected void txtBranchCode_TextChanged(object sender, EventArgs e)
    {
        string BranchID = txtBranchCode.Text;
        ds = ISS.BranchExistOrNot(BranchID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Already Exist!', 'This Branch already Exist, Kindly Try with new Branch!', 'info');", true);
            txtBranchCode.Text = "";
            return;
        }
    }
}
