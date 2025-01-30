using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class COProcess_COStockReturnedConfirmation : System.Web.UI.Page
{

    private DataSet ds = new DataSet();
    private Inventory_System ISS = new Inventory_System();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    protected void BindGrid()
    {
        string COID = Session["UserCode"].ToString();
        ds = ISS.returnProductByCO(COID);
        gvCORetStock.DataSource = ds;
        gvCORetStock.DataBind();
    }

    protected void chkAction_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAction = sender as CheckBox;
        GridViewRow currentRow = chkAction.NamingContainer as GridViewRow;
        RequiredFieldValidator rfvQnty = gvCORetStock.Rows[currentRow.RowIndex].FindControl("rfvQnty") as RequiredFieldValidator;
        RequiredFieldValidator frvRmrks = gvCORetStock.Rows[currentRow.RowIndex].FindControl("frvRmrks") as RequiredFieldValidator;

        if (chkAction.Checked)
        {
            rfvQnty.Enabled = true;
            frvRmrks.Enabled = true;
        }
        else
        {
            rfvQnty.Enabled = false;
            frvRmrks.Enabled = false;
        }
    }

    protected void gvCORetStock_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Submit")
        {
            int chkCount = 0;
            for (int i = 0; i < gvCORetStock.Rows.Count; i++)
            {
                if (((CheckBox)gvCORetStock.Rows[i].FindControl("chkAction")).Checked)
                {
                    chkCount++;
                }
            }

            if (chkCount == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('No One Checked!', 'Please choose at least one!', 'error');", true);
                return;
            }
            else
            {
                for (int i = 0; i < gvCORetStock.Rows.Count; i++)
                {
                    if (((CheckBox)gvCORetStock.Rows[i].FindControl("chkAction")).Checked)
                    {
                        CheckBox Approve = (CheckBox)gvCORetStock.Rows[i].FindControl("chkAction");
                        int ID = Convert.ToInt32(gvCORetStock.DataKeys[i]["product_In_StockID"].ToString());
                        TextBox CORetQuantity = ((TextBox)gvCORetStock.Rows[i].FindControl("txtRetQuantity"));
                        TextBox CORetRemarks = ((TextBox)gvCORetStock.Rows[i].FindControl("txtRetRemarks"));
                        Label AvailbStock = ((Label)gvCORetStock.Rows[i].FindControl("lblavailablestock"));
                        Label BranchID = ((Label)gvCORetStock.Rows[i].FindControl("lblBranchID"));
                        Label ProductID = ((Label)gvCORetStock.Rows[i].FindControl("lblProductID"));

                        if (CORetQuantity.Text == null || CORetQuantity.Text == "")
                        {
                            CORetQuantity.Text = "0";
                        }

                        string ReturnBy = Session["UserCode"].ToString();
                        int ReturnStock = Convert.ToInt32(CORetQuantity.Text);
                        string ReturnRemarks = CORetRemarks.Text;
                        int AvailableStock = Convert.ToInt32(AvailbStock.Text);
                        string branch_id = BranchID.Text;
                        int product_id = Convert.ToInt32(ProductID.Text);


                        if (ReturnStock > AvailableStock)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Info!', 'You can not Return Stock more than Available stock', 'info');", true);
                            return;
                        }
                        else
                        {
                            ISS.ModifyProductStockByCO(ID, ReturnStock, ReturnRemarks, ReturnBy, branch_id, product_id);
                        }

                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Submitted', 'success');", true);

                    }
                }

                BindGrid();
            }

        }
    }
}