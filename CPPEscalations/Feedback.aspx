<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="CPPEscalations_Feedback" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeadContent">
    <script>
        function fetchBranchProducts() {
            const branchId = document.getElementById('<%= txtBranchId.ClientID %>').value;
            if (branchId) {
                fetch(`Feedback.aspx/GetBranchProducts`, {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify({ branchId })
                })
                    .then(response => response.json())
                    .then(data => {
                        populateStockTable(data.d); // Assuming the response is in `data.d`
                    })
                    .catch(error => console.error("Error fetching products:", error));
            }
        }

        function populateStockTable(products) {
            const tableBody = document.querySelector("#stockTable tbody");
            tableBody.innerHTML = ""; // Clear existing rows

            products.forEach(product => {
                const row = document.createElement("tr");
                row.innerHTML = `
                <td>${product.Name}</td>
                <input type="hidden" name="product_name_${product.Code}" value="${product.Name}" />
                <td><input type="number" class="form-control" placeholder="0" required data-product="${product.Code}" name="stock_ims_${product.Code}" /></td>
                <td><input type="number" class="form-control" placeholder="0" required data-product="${product.Code}" name="stock_physical_${product.Code}" /></td>
            `;
                tableBody.appendChild(row);
            });
        }


    </script>

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center mb-4">Stock Reconciliation Form</h2>
        <form id="stockEntryForm">
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="employeeId" class="form-label">Employee ID</label>
                    <asp:TextBox ID="txtEmployeeId" runat="server" CssClass="form-control" placeholder="Enter Employee ID" ValidationGroup="ABC" />
                    <asp:RequiredFieldValidator ID="rfc1" runat="server" ControlToValidate="txtEmployeeId" ErrorMessage="Kindly enter" ForeColor="red"
                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label for="employeeName" class="form-label">Employee Name</label>
                    <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control" placeholder="Enter Employee Name" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmployeeName" ErrorMessage="Kindly enter" ForeColor="red"
                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="designation" class="form-label">Designation</label>
                    <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control" placeholder="Enter Designation" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDesignation" ErrorMessage="Kindly enter" ForeColor="red"
                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6">
                    <label for="branchName" class="form-label">Branch Name</label>
                    <asp:TextBox ID="txtBranchName" runat="server" CssClass="form-control" placeholder="Enter Branch Name" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBranchName" ErrorMessage="Kindly enter" ForeColor="red"
                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="branchId" class="form-label">Branch ID</label>
                    <asp:TextBox ID="txtBranchId" runat="server" CssClass="form-control" placeholder="Enter Branch ID" oninput="fetchBranchProducts()" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBranchId" ErrorMessage="Kindly enter" ForeColor="red"
                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                </div>


                <div class="col-md-6">
                    <label for="date" class="form-label">Date</label>
                    <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDate" ErrorMessage="Kindly enter" ForeColor="red"
                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-12">
                    <label class="form-label">Stock Details</label>
                    <div class="table-responsive">
                        <table class="table table-bordered" id="stockTable">
                            <thead class="table-light">
                                <tr>
                                    <th>Item</th>
                                    <th>Stock as per IMS Dashboard</th>
                                    <th>Physical Stock in Branch</th>
                                </tr>
                            </thead>
                            <tbody>
                                <!-- Dynamic rows will be inserted here -->
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="DamageStock" class="form-label">Total Damage Stock</label>
                    <asp:TextBox ID="txtDamageStock" runat="server" CssClass="form-control" placeholder="Enter Damage Stock" TextMode="Number" />
                </div>

                <div class="col-md-6">
                    <label for="Feedback" class="form-label">Any other Feedback</label>
                    <asp:TextBox ID="txtFeedback" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Enter your feedback here" />
                </div>
            </div>

            <div class="text-center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="ABC" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-secondary" OnClick="btnClear_Click" />
            </div>
        </form>
    </div>
</asp:Content>

