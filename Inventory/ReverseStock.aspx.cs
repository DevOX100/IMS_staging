using gsmClasses;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using gsmClasses;
using QiHe.CodeLib;
using DeveloperUtilz;
using Org.BouncyCastle.Tls.Crypto;
public partial class ReverseStock : System.Web.UI.Page
{
    Inventory_System ISS = new Inventory_System();
    DataSet ds = new DataSet();
    Encryption ec = new Encryption();
    gsmFileFolders ff=  new gsmFileFolders();
    duValidate dv = new duValidate();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustID.Visible = false;
            LoanID.Visible = true;  
        }
    }

    protected void BindGrid()
    {
        string CustID = txtSearch.Text;
        string LoanID = txtLoanID.Text;

        if(LoanID == "" || LoanID == null)
        {
            LoanID = "null";
        }

        if (CustID == "" || CustID == null)
        {
            CustID = "null";
        }


        DataSet ds = ISS.ReverseStockDetails(Session["UserCode"].ToString(), CustID, LoanID);
        
        if (ds == null )
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Invalid!', 'No Data Has Been Found!' );", true);
        }
         if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvReverse.DataSource = ds;
            gvReverse.DataBind();
            gvReverse.Visible = true;
           
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Invalid!', 'No Data Has Been Found!' );", true);
            gvReverse.Visible = false;

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void gvReverse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Submit")
        {

            int chkCount = 0;
            for (int i = 0; i < gvReverse.Rows.Count; i++)
            {
                if (((CheckBox)gvReverse.Rows[i].FindControl("chkAction")).Checked)
                {
                    chkCount++;
                }
            }

            if (chkCount == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('No One Checked!', 'Please Check at least one!', 'error');", true);
                return;
            }
            for (int i = 0; i < gvReverse.Rows.Count; i++)
            {

                if (((CheckBox)gvReverse.Rows[i].FindControl("chkAction")).Checked)
                {
                    int IssueID = Convert.ToInt32(gvReverse.DataKeys[i]["Issued_ID"].ToString());
                    TextBox Quantity = ((TextBox)gvReverse.Rows[i].FindControl("txtGQuantity"));
                    Label CUSTID = ((Label)gvReverse.Rows[i].FindControl("lblCustID"));
                    Label FirstName = ((Label)gvReverse.Rows[i].FindControl("lblFirstName"));
                    Label lblProductID = ((Label)gvReverse.Rows[i].FindControl("lblProductID"));
                    Label INVBranch = ((Label)gvReverse.Rows[i].FindControl("lblBranchID"));
                    Label MobileNumber = ((Label)gvReverse.Rows[i].FindControl("lblMobileNO"));
                    Label SpouseName = ((Label)gvReverse.Rows[i].FindControl("lblSpouseNAme"));
                    Label LoanId = ((Label)gvReverse.Rows[i].FindControl("lblLoanID"));
                    Label IssuedQty = ((Label)gvReverse.Rows[i].FindControl("lblIssuedQty"));

                    TextBox WarrantyDate = ((TextBox)gvReverse.Rows[i].FindControl("txtWarrantyDate"));

                    if(Quantity.Text != IssuedQty.Text)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('info!', 'Reversed Quantity should be equal to Issued Quantity', 'warning');", true);
                        return;
                    }

                    string custID=CUSTID.Text;
                    string fName= FirstName.Text;
                    string IMSProductID= lblProductID.Text;
                    string Bnch= INVBranch.Text;
                    string Mnumber= MobileNumber.Text;
                    string Sname = SpouseName.Text;
                    string loanID= LoanId.Text;
                    int QTY = Convert.ToInt32(Quantity.Text);

                    ISS.ReverseStock(IssueID, IMSProductID, Bnch, QTY, Session["UserCode"].ToString());
                }
            }
        }

        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Done!', 'Submitted', 'success');", true);
        BindGrid();


    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }


    protected void btnSubmitLoanID_Click(object sender, EventArgs e)
    {
       BindGrid();
    }
    

    protected void rbloptionCustID_CheckedChanged(object sender, EventArgs e)
    {

        CustID.Visible = true;
        LoanID.Visible = false;
        txtSearch.Text = "";
        gvReverse.Visible = false;
        txtLoanID.Text = "";
    }

    protected void rbloptionLoanID_CheckedChanged(object sender, EventArgs e)
    {
        CustID.Visible = false;
        LoanID.Visible = true;
        txtLoanID.Text = "";
        gvReverse.Visible = false;
        txtSearch.Text = "";
    }


    protected void gvReverse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Find the DropDownList in the current row
            DropDownList prdctddl = (DropDownList)e.Row.FindControl("Productddl");

            if (prdctddl != null)
            {
                // Call your method to get the data for the DropDownList
                DataSet dsProducts = ISS.INV_distinctProduct();

                // Bind the data to the DropDownList
                prdctddl.DataSource = dsProducts;
                prdctddl.DataTextField = "product"; // Change "product" to your actual column name for display text
                prdctddl.DataValueField = "PM_ItemCode1"; // Change "PM_ItemCode1" to your actual column name for value
                prdctddl.DataBind();

                // Optionally, add a default "Select" item at the first position
                prdctddl.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
    }

    protected void rblGroupID_CheckedChanged(object sender, EventArgs e)
    {
        CustID.Visible = false;
        LoanID.Visible = false;
        txtSearch.Text = "";
        gvReverse.Visible = false;
        txtLoanID.Text = "";
    }

    protected void rblCenterID_CheckedChanged(object sender, EventArgs e)
    {
        CustID.Visible = false;
        LoanID.Visible = false;
        txtSearch.Text = "";
        gvReverse.Visible = false;
        txtLoanID.Text = "";
    }
}

