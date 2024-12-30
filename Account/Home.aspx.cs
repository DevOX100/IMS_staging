using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using DataTable = System.Data.DataTable;
using Org.BouncyCastle.Pqc.Crypto.Lms;




public partial class Account_Home : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    Inventory_System ISS = new Inventory_System();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string HOLogins= Session["RCode"].ToString();
            string Division = Session["Division"].ToString();
            string Cluster = Session["Cluster"].ToString();
            string[] loginType = { "U", "D", "C" };

            //string[] HOLogins = { "10000", "01479", "01823", "09917", "08000" };
            //string[] CppHUBWise = { "15020", "12307", "15704", "18269", "18891" };
            //string UserCode = Session["UserCode"].ToString();
            if (loginType.Contains(Session["loginType"].ToString()) && HOLogins!="R000" && !HOLogins.StartsWith("BH",StringComparison.OrdinalIgnoreCase))
            {
                BindBranch();
                Region.Visible = false;
            }
          
            else
            {
                Region.Visible = true;
            }
            
            if (Session["loginType"].ToString() == "B")
            {
                ddlBranch.Visible = false;
                ddlRegion.Visible = false;
                lblBranch.Visible = false;
                lblRegion.Visible = false;
              

            }
            else
            {
                ddlBranch.Visible = true;
                ddlRegion.Visible = true;
                lblBranch.Visible = true;
                lblRegion.Visible = true;
            }
            Data();
            BindRegion();
            if (Session["loginType"].ToString() == "V")
            {

                Div2.Visible = false;
                css.Visible = false;
                VendorDataChart();
            }
            else
            {
                Div1.Visible = false;



                DataChart();

            }

            
        }



    }
    protected void BindRegion()
    {
        
        string HOLogins = Session["RCode"].ToString();
        if (HOLogins.StartsWith("BH", StringComparison.OrdinalIgnoreCase) )
        {
       

            string CppHub = Session["RegionID"].ToString();
      
            ds = ISS.HUBWiseRegion(CppHub);
            ddlRegion.DataSource = ds;
            ddlRegion.DataTextField = "Cluster_ID";
            ddlRegion.DataValueField = "Cluster_ID";
            ddlRegion.DataBind();
            ddlRegion.Items.Insert(0, new ListItem("Select", "0"));
        }
        else
        {
        

            ds = ISS.RegionDetail();
            ddlRegion.DataSource = ds;
            ddlRegion.DataTextField = "Cluster_ID";
            ddlRegion.DataValueField = "Cluster_ID";
            ddlRegion.DataBind();
            ddlRegion.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    
    protected void BindBranch()
    {
        string[] loginType = { "D", "C" };
       
        string HOLogins = Session["RCode"].ToString();
        if (Session["loginType"].ToString() == "U" && HOLogins != "R000" && !HOLogins.StartsWith("BH", StringComparison.OrdinalIgnoreCase))
        {
           
            string clusterID = Session["RegionID"].ToString();
            ds = ISS.BranchDetailsByRegion(clusterID);
            ddlBranch.DataSource = ds;
            ddlBranch.DataTextField = "Branch_Name";
            ddlBranch.DataValueField = "Branch_ID";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("Select", "0"));
        }
        else if (loginType.Contains(Session["loginType"].ToString()))
        {
            string clusterID = Session["RegionID"].ToString();
            string userCode = Session["UserCode"].ToString();
            if (loginType.Contains(Session["loginType"].ToString()))
            {
                ds = ISS.BranchDetailsByDivisionCluster(userCode, clusterID);
                ddlBranch.DataSource = ds;
                ddlBranch.DataTextField = "Branch_Name";
                ddlBranch.DataValueField = "Branch_ID";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        else
        {
            string clusterID = ddlRegion.SelectedValue;
            ds = ISS.BranchDetailsByRegion(clusterID);
            ddlBranch.DataSource = ds;
            ddlBranch.DataTextField = "Branch_Name";
            ddlBranch.DataValueField = "Branch_ID";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("Select", "0"));
        }
        
    }
  
    protected void RegionWiseBind()
    {
        string vendorLogin=null;
      
        string userCode;
        string HOLogins = Session["RCode"].ToString();
        if (Session["loginType"].ToString() == "U" && HOLogins != "R000" && !HOLogins.StartsWith("BH", StringComparison.OrdinalIgnoreCase))
        {
            userCode = Session["RegionID"].ToString();
        }
        else
        {
           
            userCode = ddlRegion.SelectedValue;
        }
             
        string branchID = ddlBranch.SelectedValue;
        if (string.IsNullOrEmpty(branchID))
        {
            branchID = "0";
        }
        if (Session["loginType"].ToString() == "V")
        {
            vendorLogin = Session["UserCode"].ToString();
            ds = ISS.RegionWiseCount(userCode, branchID, vendorLogin);
            if (ds.Tables[0].Rows.Count > 0)
            {

                string Total = (ds.Tables[0].Rows[0]["Total"]).ToString();
                string OutStock = (ds.Tables[1].Rows[0]["Out Stock"]).ToString();
                string stockAdjustment = (ds.Tables[2].Rows[0]["Stock Adjustment"]).ToString();
                string AvailableStock= (ds.Tables[3].Rows[0]["Available Order"]).ToString();
                string MTD = (ds.Tables[4].Rows[0]["MTD"]).ToString();
                string FTD = (ds.Tables[5].Rows[0]["FTD"]).ToString();
                string CustomerComplaints = (ds.Tables[6].Rows[0]["Customer Return Stock"]).ToString();
                string Pending = (ds.Tables[7].Rows[0]["Pending Order"]).ToString();
                string Delivered = (ds.Tables[8].Rows[0]["Delivered Order"]).ToString();
                string DamagedStockByVendor = (ds.Tables[9].Rows[0]["Damaged Stock by Vendor"]).ToString();
                string CppEscalation = (ds.Tables[10].Rows[0]["CPP Escalation"]).ToString();



                lblTotal.Text = Total.ToString();
                lblPaid.Text = OutStock.ToString();
                lblStockAdjustment.Text = stockAdjustment.ToString();
                lblPending.Text = AvailableStock.ToString();
                lblMonthTillDate.Text = MTD.ToString();
                lblForTheDay.Text = FTD.ToString();
                lblCustomerComplaints.Text = CustomerComplaints.ToString();
                lblNotDelivered.Text = Pending.ToString();
                lblDeliveredStocks.Text = Delivered.ToString();
                lblDamagedStockByVendor.Text = DamagedStockByVendor.ToString();
                lblCPPEscalation.Text = CppEscalation.ToString();
            }
            VendorDataChart();
        }
        else
        {

            ds = ISS.RegionWiseCount(userCode, branchID, vendorLogin);


            if (ds.Tables[0].Rows.Count > 0)
            {

                string Total = (ds.Tables[0].Rows[0]["Total"]).ToString();
                string OutStock = (ds.Tables[1].Rows[0]["Out Stock"]).ToString();
                string StockTransfer = (ds.Tables[2].Rows[0]["Stock Transfer"]).ToString();
                string StockAdjustment = (ds.Tables[3].Rows[0]["Stock Adjustment"]).ToString();
                string AvailableStock = (ds.Tables[4].Rows[0]["Available Stock"]).ToString();
                string MTD = (ds.Tables[5].Rows[0]["MTD"]).ToString();
                string FTD = (ds.Tables[6].Rows[0]["FTD"]).ToString();
                string CustomerComplaints = (ds.Tables[7].Rows[0]["Customer Return Stock"]).ToString();
                string Pending = (ds.Tables[8].Rows[0]["Pending Order"]).ToString();
                string Delivered = (ds.Tables[9].Rows[0]["Delivered Order"]).ToString();
                string DamagedStockByVendor = (ds.Tables[10].Rows[0]["Damaged Stock by Vendor"]).ToString();
                string CppEscalation = (ds.Tables[11].Rows[0]["CPP Escalation"]).ToString();


                lblTotal.Text = Total.ToString();
                lblPaid.Text = OutStock.ToString();
                lblStockTransfer.Text = StockTransfer.ToString();
                lblStockAdjustment.Text = StockAdjustment.ToString();
                lblPending.Text = AvailableStock.ToString();
                lblMonthTillDate.Text = MTD.ToString();
                lblForTheDay.Text = FTD.ToString();
                lblCustomerComplaints.Text = CustomerComplaints.ToString();
                lblNotDelivered.Text = Pending.ToString();
                lblDeliveredStocks.Text = Delivered.ToString();
                lblDamagedStockByVendor.Text = DamagedStockByVendor.ToString();
                lblCPPEscalation.Text = CppEscalation.ToString();
            }
        }
        
    }
    protected void VendorDataChart()
    {
        int UerCode = Convert.ToInt32(Session["UserCode"].ToString());
        string RegionID=ddlRegion.SelectedValue;
        string BranchID=ddlBranch.SelectedValue;
        if (string.IsNullOrEmpty(BranchID))
        {
            BranchID = "0";
        }
        if (string.IsNullOrEmpty(RegionID))
        {
            RegionID = "0";
        }
        ds = ISS.BindvendorStatus(UerCode,  BranchID, RegionID);
        DataTable ChartData = ds.Tables[0];
        var quantity = new Dictionary<string, int>();
        var status = new Dictionary<string, int>();

        if (ChartData.Rows.Count == 0)
        {

            Chart2.Series["Status"].Points.Clear();
            return;
        }
        foreach (DataRow row in ChartData.Rows)
        {
            string StatusName = row["Status"].ToString();

            int qty = row["quantity"] != DBNull.Value ? Convert.ToInt32(row["quantity"]) : 0;
            quantity[StatusName]=qty;
           
        }
        var AllStatus = quantity.Keys.ToArray();
        var availableQuantities = AllStatus.Select(pn => quantity.ContainsKey(pn) ? quantity[pn] : 0).ToArray();
        Chart2.Series["Status"].Points.Clear();


        Chart2.Series["Status"].Points.DataBindXY(AllStatus, availableQuantities);
 
        Chart2.Series["Status"].Color = Color.Green;


        Chart2.Series["Status"].IsValueShownAsLabel = true;


        Chart2.Series["Status"].LabelForeColor = Color.Black;


        //Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = 0; 
        Chart2.ChartAreas["ChartArea2"].AxisX.Interval = 1;

        Chart2.ChartAreas["ChartArea2"].AxisX.LineDashStyle = ChartDashStyle.Solid;
        Chart2.ChartAreas["ChartArea2"].AxisX.LineWidth = 1;
        Chart2.ChartAreas["ChartArea2"].AxisX.LabelStyle.Font = new Font("Arial", 10f, FontStyle.Regular);



        Chart2.ChartAreas["ChartArea2"].AxisX.MajorGrid.Enabled = false;
        Chart2.ChartAreas["ChartArea2"].AxisY.MajorGrid.Enabled = false;

        Chart2.Legends["Default"].Enabled = true;

        Chart2.Width = new Unit(1500);

    }
    protected void DataChart()
    {
        string HOLogins = Session["RCode"].ToString();
        string regionID = ddlRegion.SelectedValue;
        string branchID = ddlBranch.SelectedValue;
        if (string.IsNullOrEmpty(branchID))
        {
            branchID = "0";
        }
        if (string.IsNullOrEmpty(regionID))
        {
            regionID = "0";
        }
        string UserCode = Session["UserCode"].ToString();
        string[] loginType = { "D", "C" ,"U"};
        if (loginType.Contains(Session["loginType"].ToString())  && HOLogins != "R000" && !HOLogins.StartsWith("BH", StringComparison.OrdinalIgnoreCase))
        {
            regionID = Session["RegionID"].ToString();
        }
      
    

        ds = ISS.DashboardCount(UserCode, regionID, branchID);
        DataTable ChartData = ds.Tables[0];

        var availableData = new Dictionary<string, int>();
        var damagedData = new Dictionary<string, int>();

        if (ChartData.Rows.Count == 0)
        {
            Chart1.Series["Available Stock"].Points.Clear();
            Chart1.Series["Damaged Stock"].Points.Clear();
            return;
        }

        foreach (DataRow row in ChartData.Rows)
        {
            string productName = row["PC_ProductName"].ToString();

            string stockType = row["PC_Type"].ToString().Trim();

            if (stockType == "Available Stock")
            {
                int qty = row["PC_AvailableQty"] != DBNull.Value ? Convert.ToInt32(row["PC_AvailableQty"]) : 0;
                availableData[productName] = qty;
            }
            else if (stockType == "Damaged Stock")
            {
                int qty = row["PC_DamageQty"] != DBNull.Value ? Convert.ToInt32(row["PC_DamageQty"]) : 0;
                damagedData[productName] = qty;
            }
        }

        var productNames = availableData.Keys.Union(damagedData.Keys).ToArray();
        var availableQuantities = productNames.Select(pn => availableData.ContainsKey(pn) ? availableData[pn] : 0).ToArray();
        var damagedQuantities = productNames.Select(pn => damagedData.ContainsKey(pn) ? damagedData[pn] : 0).ToArray();

        Chart1.Series["Available Stock"].Points.Clear();
        //Chart1.Series["Damaged Stock"].Points.Clear();

        Chart1.Series["Available Stock"].Points.DataBindXY(productNames, availableQuantities);
        //Chart1.Series["Damaged Stock"].Points.DataBindXY(productNames, damagedQuantities);

        Chart1.Series["Available Stock"].Color = Color.Green;
        //Chart1.Series["Damaged Stock"].Color = Color.Red;

        Chart1.Series["Available Stock"].IsValueShownAsLabel = true;
        //Chart1.Series["Damaged Stock"].IsValueShownAsLabel = true;

        Chart1.Series["Available Stock"].LabelForeColor = Color.Black;
        //Chart1.Series["Damaged Stock"].LabelForeColor = Color.Black;

        //Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = 0; 
        Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
  
        Chart1.ChartAreas["ChartArea1"].AxisX.LineDashStyle = ChartDashStyle.Solid;
        Chart1.ChartAreas["ChartArea1"].AxisX.LineWidth = 1;
        Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("Arial", 10f, FontStyle.Regular);



        Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
        Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;

        Chart1.Legends["Default"].Enabled = true;

        Chart1.Width = new Unit(1500);

    }


    protected void Data()
    {
        if (Session["loginType"].ToString()=="V")
        {
            string UserCode = Session["UserCode"].ToString();
            string Region = Session["RCode"].ToString();
            ds = ISS.DashboardInvoiceCount(UserCode, Region);
            //ds = ISS.DashboardInvoiceCount(UserCode);
            if (ds.Tables[0].Rows.Count > 0)
            {

                string Total = (ds.Tables[0].Rows[0]["Total"]).ToString();
                string OutStock = (ds.Tables[1].Rows[0]["Out Stock"]).ToString();
                string stockAdjustment = (ds.Tables[2].Rows[0]["Stock Adjustment"]).ToString();
                string AvailableStock = (ds.Tables[3].Rows[0]["Available Order"]).ToString();
                string MTD = (ds.Tables[4].Rows[0]["MTD"]).ToString();
                string FTD = (ds.Tables[5].Rows[0]["FTD"]).ToString();
                string CustomerComplaints = (ds.Tables[6].Rows[0]["Customer Return Stock"]).ToString();
                string Pending = (ds.Tables[7].Rows[0]["Pending Order"]).ToString();
                string Delivered = (ds.Tables[8].Rows[0]["Delivered Order"]).ToString();
                string DamagedStockByVendor = (ds.Tables[9].Rows[0]["Damaged Stock by Vendor"]).ToString();
                string CppEscalation = (ds.Tables[10].Rows[0]["CPP Escalation"]).ToString();




                lblTotal.Text = Total.ToString();
                lblPaid.Text = OutStock.ToString();
                lblStockAdjustment.Text = stockAdjustment.ToString();
                lblPending.Text = AvailableStock.ToString();
                lblMonthTillDate.Text = MTD.ToString();
                lblForTheDay.Text = FTD.ToString();
                lblCustomerComplaints.Text = CustomerComplaints.ToString();
                lblNotDelivered.Text = Pending.ToString();
                lblDeliveredStocks.Text = Delivered.ToString();
                lblDamagedStockByVendor.Text = DamagedStockByVendor.ToString();
                lblCPPEscalation.Text = CppEscalation.ToString();

            }
        }
        else
        {
            string UserCode = Session["UserCode"].ToString();

            string Region = Session["RCode"].ToString();
            ds = ISS.DashboardInvoiceCount(UserCode, Region);
            //ds = ISS.DashboardInvoiceCount(UserCode);

            if (ds.Tables[0].Rows.Count > 0)
        {
                string Total = (ds.Tables[0].Rows[0]["Total"]).ToString();
                string OutStock = (ds.Tables[1].Rows[0]["Out Stock"]).ToString();
                string StockTransfer = (ds.Tables[2].Rows[0]["Stock Transfer"]).ToString();
                string StockAdjustment = (ds.Tables[3].Rows[0]["Stock Adjustment"]).ToString();
                string AvailableStock = (ds.Tables[4].Rows[0]["Available Stock"]).ToString();
                string MTD = (ds.Tables[5].Rows[0]["MTD"]).ToString();
                string FTD = (ds.Tables[6].Rows[0]["FTD"]).ToString();
                string CustomerComplaints = (ds.Tables[7].Rows[0]["Customer Return Stock"]).ToString();
                string Pending = (ds.Tables[8].Rows[0]["Pending Order"]).ToString();
                string Delivered = (ds.Tables[9].Rows[0]["Delivered Order"]).ToString();
                string DamagedStockByVendor = (ds.Tables[10].Rows[0]["Damaged Stock by Vendor"]).ToString();
                string CppEscalation = (ds.Tables[11].Rows[0]["CPP Escalation"]).ToString();


                lblTotal.Text = Total.ToString();
                lblPaid.Text = OutStock.ToString();
                lblStockTransfer.Text = StockTransfer.ToString();
                lblStockAdjustment.Text = StockAdjustment.ToString();
                lblPending.Text = AvailableStock.ToString();
                lblMonthTillDate.Text = MTD.ToString();
                lblForTheDay.Text = FTD.ToString();
                lblCustomerComplaints.Text = CustomerComplaints.ToString();
                lblNotDelivered.Text = Pending.ToString();
                lblDeliveredStocks.Text = Delivered.ToString();
                lblDamagedStockByVendor.Text = DamagedStockByVendor.ToString();
                lblCPPEscalation.Text = CppEscalation.ToString();
            }
        }

    }

   


    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBranch();
        if (ddlRegion.SelectedValue != "0")
        {
            RegionWiseBind();
            DataChart();
        }
        else
        {
            Data();
        }
    }

    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BranchWiseBind();
        RegionWiseBind();
        DataChart();
    }
}