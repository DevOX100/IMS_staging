using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.html;
using System.Drawing;
using Control = System.Web.UI.Control;

public partial class Inventory_PoForm : System.Web.UI.Page
{
    Inventory_System ISS = new Inventory_System();
    DataSet ds = new DataSet();
    Encryption ec = new Encryption();
    protected void Page_Load(object sender, EventArgs e)
    {
       if(! IsPostBack)
        {
            string PoNumber = Request.QueryString["PONumber"];
            lblPoNum.Text = ec.Decrypt(HttpUtility.UrlDecode(PoNumber));
            BindGrid(lblPoNum.Text);


            GSTNO.Text = "03AAGCS6186A1ZL";
            //HoAddress.Text = "The Axis, BMC Chowk\r\nJalandhar, Punjab-144001\r\n";
            lblTotalAmount.Text = GetTotalAmount() + " Rs/-"; 
            PO_Amount.Text = GetTotalAmount() + " Rs/-";



            txtTermsAndConditions.Text = "- Ensure that the product box is packed with outer tape intact or not physically damaged.\r\n\n" +

                "- Ensure packaging is neither wet nor inappropriate condition.\r\n" +
                "- Verify the quantity mentioned on the POD (Proof of Delivery) while receiving the product.\r\n\n" +
                "- If the number of boxes received doesn't match the number on the POD, note the actual quantity received with a sign and stamp.\r\n\n" +
                "- Make a video while opening the sealed box. If all units are accurate, delete the video. If any unit is missing, share\r\n\n" +
                "  the video with cpp.helpdesk@midlandmicrofin.com.  Moreover, unboxing of Cartons or products should be done\r\n\n" +
                "  under CCTV coverage.";
                                        
        }
    }

    /* protected DataTable GetDataFromDatabase()
     {

         DataTable dt = new DataTable();

         dt.Columns.Add("Item_Code", typeof(string));
         dt.Columns.Add("Description", typeof(string));
         dt.Columns.Add("Quantity", typeof(int));
         dt.Columns.Add("Unit", typeof(string));
         dt.Columns.Add("Rate", typeof(decimal));
         dt.Columns.Add("Total_Amount", typeof(decimal));


         dt.Rows.Add("TFDC", "Ally Tez Fan Décor", 200, "Pcs", 2275, 455000);
         dt.Rows.Add("TFP", "Ally Tez Fan Pro", 45, "Pcs", 1846, 83070);

         return dt;
     }
     protected DataTable headerGrid()
     {
         DataTable dt1 = new DataTable();
         dt1.Columns.Add("Address", typeof(string));
         dt1.Columns.Add("SupplierAddress", typeof(string));
         dt1.Columns.Add("DeliveryAddress", typeof(string));


         dt1.Rows.Add("Midland Microfin Ltd\r\nThe Axis, BMC Chowk\r\nJalandhar, Punjab-144001\r\n", "SKV Solutions PVT LTD\r\nSKV Solutions, Building No 2, First Floor, State Bank Colony, G.T Karnal Road, Derwala, Delhi-110009\r\n", "Branch Detail/Branch ID-\r\nBranch Address\r\n");

         return dt1;

      }*/
    protected void BindGrid(string PoNumber)
    {
        string Pnumber = PoNumber;
        string BranchCode = Session["UserCode"].ToString();
        ds = ISS.poDetails(Pnumber,BranchCode);

        GridView1.DataSource = ds;
        GridView1.DataBind();

        
        var poDetails = ISS.poDetails(Pnumber,BranchCode);

        if (poDetails != null && poDetails.Tables[0].Rows.Count > 0)
        {

            PONumber.Text = poDetails.Tables[0].Rows[0]["PO_number"].ToString();
            PO_Delivery_Date.Text = poDetails.Tables[0].Rows[0]["PO_Delivery_Date"].ToString();
            poDateValue.Text = poDetails.Tables[0].Rows[0]["PODate"].ToString();
   
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Invalid!', 'No Data Has Been Found!' );", true);
        }
        
        var PoAddresses = ISS.POAddresses(Pnumber);
        if (PoAddresses != null && poDetails.Tables[0].Rows.Count > 0) 
        {
            VendorAddress.Text = PoAddresses.Tables[0].Rows[0]["vendorAddress"].ToString();
            ContactNumber.Text = PoAddresses.Tables[0].Rows[0]["VM_Phone"].ToString();
            ContactName.Text = PoAddresses.Tables[0].Rows[0]["Name"].ToString();
            GST.Text = PoAddresses.Tables[0].Rows[0]["VM_GST"].ToString();
            DelieveryAddress.Text = PoAddresses.Tables[0].Rows[0]["delieveryAddress"].ToString();
            Contactperson1.Text = PoAddresses.Tables[0].Rows[0]["ContactPerson1"].ToString();
            contactpersonNumber.Text = PoAddresses.Tables[0].Rows[0]["ContactPerson1_number"].ToString();
            ContactPerson2.Text = PoAddresses.Tables[0].Rows[0]["ContactPerson2"].ToString();
            contactpersonNumber2.Text = PoAddresses.Tables[0].Rows[0]["ContactPerson2_Number"].ToString();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "swal('Invalid!', 'No Data Has Been Found!' );", true);
        }
    }

    protected string ConvertNumberToWords(decimal number)
    {
        string[] units = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        string[] teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        if (number == 0)
            return "Zero";

        string words = "";

        if (number < 0)
        {
            words = "Minus ";
            number = Math.Abs(number);
        }

        int integerPart = (int)number;
        int decimalPart = (int)((number - integerPart) * 100);

        if (integerPart > 0)
        {
            if (integerPart >= 10000000)
            {
                words += ConvertNumberToWords(integerPart / 10000000) + " Crore ";
                integerPart %= 10000000;
            }

            if (integerPart >= 100000)
            {
                words += ConvertNumberToWords(integerPart / 100000) + " Lakh ";
                integerPart %= 100000;
            }

            if (integerPart >= 1000)
            {
                words += ConvertNumberToWords(integerPart / 1000) + " Thousand ";
                integerPart %= 1000;
            }

            if (integerPart >= 100)
            {
                words += ConvertNumberToWords(integerPart / 100) + " Hundred ";
                integerPart %= 100;
            }

            if (integerPart > 0)
            {
                if (words != "")
                    words += "And ";

                if (integerPart < 10)
                    words += units[integerPart];
                else if (integerPart < 20)
                    words += teens[integerPart - 10];
                else
                {
                    words += tens[integerPart / 10];
                    if ((integerPart % 10) > 0)
                        words += "-" + units[integerPart % 10];
                }
            }
        }

        if (decimalPart > 0)
        {
            words += "And " + (decimalPart < 10 ? units[decimalPart] + " " : (decimalPart < 20 ? teens[decimalPart - 10] + " " : tens[decimalPart / 10] + (decimalPart % 10 > 0 ? "-" + units[decimalPart % 10] : ""))) + "Paise ";
        }

        return words.Trim();
    }

    protected string GetTotalAmount()
    {
        decimal totalAmount = 0;
        foreach (GridViewRow row in GridView1.Rows)
        {
            decimal amount;
            if (decimal.TryParse(row.Cells[4].Text, out amount))
            {
                totalAmount += amount;
            }
        }

       
        string amountInWords = ConvertNumberToWords(totalAmount);

       
        litPOAmount.Text = amountInWords + " Only/-";

        return totalAmount.ToString();
    }




    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Session["loginType"].ToString() == "U" && Session["UserCode"].ToString() != "01479")
        {
            Response.Redirect(string.Format("viewPO.aspx"));
        }

        if (Session["loginType"].ToString() == "U" && Session["UserCode"].ToString()=="01479" )
        {
            Response.Redirect(string.Format("HOD_POApproval.aspx"));
        }

        if (Session["loginType"].ToString() == "V")
        {
            Response.Redirect(string.Format("POVendorForrm.aspx"));
        }
        else
        {
            Response.Redirect(string.Format("viewPO.aspx"));
        }
    }
}