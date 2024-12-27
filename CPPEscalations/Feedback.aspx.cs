using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using System.Web.UI;

public partial class CPPEscalations_Feedback : System.Web.UI.Page
{
    private static Inventory_System ISS = new Inventory_System();
    private static DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static List<Product> GetBranchProducts(string branchId)
    {
        // Fetch products mapped to the branch ID from the database
        List<Product> products = GetProductsByBranch(branchId);
        return products;
    }

    public static List<Product> GetProductsByBranch(string branchId)
    {
        // Assuming GetProductList returns a DataSet
        DataSet ds = ISS.GetProductList(branchId);  // Example method returning a DataSet
        List<Product> products = new List<Product>();

        if (ds.Tables.Count > 0) // Check if the DataSet contains tables
        {
            // Assuming the first table in the DataSet contains the products
            DataTable productTable = ds.Tables[0];

            // Use the Select method on the DataTable to filter or process rows
            foreach (DataRow row in productTable.Select())
            {
   
                Product product = new Product
                {
                    Name = row["PM_Description1"].ToString(),   // Adjust column names based on your DataTable structure
                    Code = row["PM_ItemCode1"].ToString()    // Adjust column names based on your DataTable structure
                };
                products.Add(product);
            }
        }

        return products;
    }

    public class StockDetail
    {
        public string ProductCode { get; set; }
        public int StockIms { get; set; }
        public int StockPhysical { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Code { get; set; } // Assuming there is a 'Code' field for each product
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Collect Employee and Branch details
        string employeeId = txtEmployeeId.Text;
        string employeeName = txtEmployeeName.Text;
        string designation = txtDesignation.Text;
        string branchName = txtBranchName.Text;
        string branchId = txtBranchId.Text;
        string date = txtDate.Text;
        string damageStock = txtDamageStock.Text;
        string feedback = txtFeedback.Text;

        // Convert date to DateTime
        DateTime srDate;
        if (!DateTime.TryParse(date, out srDate))
        {
            ShowMessage("Invalid date format", "error");
            return;
        }

        // Convert damageStock to int
        int totalDamagedUnits;
        if (!int.TryParse(damageStock, out totalDamagedUnits))
        {
            ShowMessage("Invalid damage stock value", "error");
            return;
        }

        bool isSuccessful = true;  // Flag to track if all data is processed successfully
        DataSet result;
        // Process stock data
        foreach (var key in Request.Form.AllKeys)
        {
            if (key.StartsWith("stock_ims_"))
            {
                string productCode = key.Replace("stock_ims_", "");
                string productNameKey = string.Format("product_name_{0}", productCode);
                string stockPhysicalKey = "stock_physical_" + productCode;

                string productName = Request.Form[productNameKey];
                string stockIMS = Request.Form[key];
                string stockPhysical = Request.Form[stockPhysicalKey];
                string UserCode=Session["UserCode"].ToString();
                // Convert stock values to integers
                int stockIMSValue = 0, stockPhysicalValue = 0;
                if (!int.TryParse(stockIMS, out stockIMSValue) || !int.TryParse(stockPhysical, out stockPhysicalValue))
                {
                    ShowMessage("Invalid stock values for product: " + productName, "error");
                    isSuccessful = false;
                    break;  // Exit the loop if there's an error
                }

                // Call the database method to save this product's data
                 result = ISS.insertReconciliationData(
                    employeeId,
                    employeeName,
                    designation,
                    branchId,
                    branchName,
                    srDate,
                    productName,
                    productCode,
                    stockIMSValue,
                    stockPhysicalValue,
                    totalDamagedUnits,
                    feedback,
                    UserCode
                );
                isSuccessful = true;

            }
        }
    
        // Show success message if all data is processed successfully
        if (isSuccessful)
        {
            ShowMessage("Data submitted successfully", "success");
           
        }
    }

    // Helper method to show messages
    private void ShowMessage(string message, string messageType)
    {
        string script = "alert('" + message + "'); window.location.reload();"; // Default script with reload

        if (messageType == "success")
        {
            script = "alert('" + message + "'); window.location.reload();"; // Success message with reload
        }
        else if (messageType == "error")
        {
            script = "alert('" + message + "');"; // Error message (no reload for errors)
        }

        ScriptManager.RegisterStartupScript(this, GetType(), "Alert", script, true);
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);

    }
}
