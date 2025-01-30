using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class COProcess_COStockReceivingConfirmation : System.Web.UI.Page
{

    private DataSet ds = new DataSet();
    private Inventory_System ISS = new Inventory_System();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindGrid();
        }

    }

    protected void BindGrid()
    {
        string COID = Session["UserCode"].ToString();
        ds = ISS.GetProductMappingWithCODetails(COID);
        gvCORecStock.DataSource = ds;
        gvCORecStock.DataBind();
    }

    protected void gvCORecStock_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Submit")
        {
            int chkCount = 0;
            for (int i = 0; i < gvCORecStock.Rows.Count; i++)
            {
                if (((CheckBox)gvCORecStock.Rows[i].FindControl("chkAction")).Checked)
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
                for (int i = 0; i < gvCORecStock.Rows.Count; i++)
                {
                    if (((CheckBox)gvCORecStock.Rows[i].FindControl("chkAction")).Checked)
                    {
                        CheckBox Approve = (CheckBox)gvCORecStock.Rows[i].FindControl("chkAction");
                        int ID = Convert.ToInt32(gvCORecStock.DataKeys[i]["PMC_ID"].ToString());
                        TextBox CORecQuantity = ((TextBox)gvCORecStock.Rows[i].FindControl("txtRecQuantity"));
                        TextBox VRemarks = ((TextBox)gvCORecStock.Rows[i].FindControl("txtRecRemarks"));
                        Label BranchSendQty = ((Label)gvCORecStock.Rows[i].FindControl("lblBQty"));
                        Label BranchID = ((Label)gvCORecStock.Rows[i].FindControl("lblBranchID"));
                        Label ProductID = ((Label)gvCORecStock.Rows[i].FindControl("lblProductID"));


                        if (CORecQuantity.Text == null || CORecQuantity.Text == "")
                        {
                            CORecQuantity.Text = "0";
                        }

                        string CRecBy = Session["UserCode"].ToString();
                        int CRecQuantity = Convert.ToInt32(CORecQuantity.Text);
                        string Remarks = VRemarks.Text;
                        int BSendQty = Convert.ToInt32(BranchSendQty.Text);
                        string branch_id = BranchID.Text;
                        int product_id = Convert.ToInt32(ProductID.Text);


                        if (CRecQuantity > BSendQty)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Info!', 'You can not receive quantity more than Branch Mapped stock', 'info');", true);
                            return;
                        }
                        else
                        {
                            ISS.ProductMappingWithCO(ID, CRecQuantity, CRecBy, Remarks, branch_id, product_id);
                        }
                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Submitted', 'success');", true);
                      
                    }
                }

                BindGrid();
            }

        }
    }

    protected void chkAction_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAction = sender as CheckBox;
        GridViewRow currentRow = chkAction.NamingContainer as GridViewRow;
        RequiredFieldValidator rfvQnty = gvCORecStock.Rows[currentRow.RowIndex].FindControl("rfvQnty") as RequiredFieldValidator;
        RequiredFieldValidator frvRmrks = gvCORecStock.Rows[currentRow.RowIndex].FindControl("frvRmrks") as RequiredFieldValidator;

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
}