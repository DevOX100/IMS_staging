<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="POVendorForrm.aspx.cs" Inherits="Inventory_DamagedProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <style>
        #loadingScreen {
            position: fixed;
            width: 100%;
            height: 100%;
            top: 0;
            left: 0;
            background: rgba(255, 255, 255, 0.8);
            z-index: 1000;
            display: none;
            justify-content: center;
            align-items: center;
        }

        .spinner {
            border: 4px solid rgba(0, 0, 0, 0.1);
            border-left-color: #3a4f63;
            border-radius: 50%;
            width: 40px;
            height: 40px;
            animation: spin 1s linear infinite;
        }

        @keyframes spin {
            to {
                transform: rotate(360deg);
            }
        }
    </style>
    <script type="text/javascript">

        function showLoading() {
            document.getElementById("loadingScreen").style.display = "flex";
        }

        function hideLoading() {
            document.getElementById("loadingScreen").style.display = "none";
            var checkboxes = document.querySelectorAll("#<%= gvDamageproduct.ClientID %> input[type='checkbox']");
            checkboxes.forEach(function (checkbox) {
                checkbox.checked = false;
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="loadingScreen">
        <div class="spinner"></div>
    </div>
    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Orders
        </div>

        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form-control border border-dark">
                    <div class="row">
                        <div class="col">
                            <div class="col-6">
                                <label id="lblSearch" class="col-form-label font-weight-bold">Search Customer :</label>
                                <div class="input-group">
                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="Search By Customer ID" ValidationGroup="ABC"></asp:TextBox>
                                    <div class="input-group-append">
                                        <asp:Button ID="btnSearch" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="ABC" OnClientClick="showLoading();" OnClick="btnSearch_Click" />
                                    </div>
                                </div>
                            </div>
                            <asp:Panel runat="server" frameborder="0" ScrollBars="Both" Align="Center">



                                <asp:GridView ID="gvDamageproduct" runat="server" CssClass="table table-bordered table-hover my-gridview"
                                    AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" ShowFooter="true" Width="100%"
                                    DataKeyNames="IS_CustID" OnRowDataBound="gvDamageproduct_RowDataBound" OnRowCommand="gvDamageproduct_RowCommand">

                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>



                                        <asp:TemplateField HeaderText="Customer ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCustID" runat="server" Text='<%#Eval("IS_CustID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FIRST_NAME") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProduct" runat="server" Text='<%# Eval("PRODUCT_ID") %>'></asp:Label><br />
                                                <asp:Label ID="lblProductID" Visible="false" runat="server" Text='<%# Eval("PM_ItemCode1") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Branch ">
                                            <ItemTemplate>

                                                <asp:Label ID="lblBranch" runat="server" Text='<%# Eval("Branch") %>'></asp:Label>
                                                <asp:Label ID="lblBranchID" Visible="false" runat="server" Text='<%# Eval("BRANCH_ID") %>'></asp:Label>


                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Mobile Number">
                                            <ItemTemplate>

                                                <asp:Label ID="lblMobileNO" runat="server" Text='<%# Eval("MOBILE_NUMBER") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Spouse Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSpouseNAme" runat="server" Text='<%# Eval("SPOUSE_NAME") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Loan ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLoanID" runat="server" Text='<%# Eval("LOAN_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Stock Handover Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcreationDate" runat="server" Text='<%# Eval("IS_CreationDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Stock Warranty Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWarrantyDate" runat="server" Text='<%# Eval("IS_WarrantyDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Enter Damaged Quantity">
                                            <ItemTemplate>

                                                <asp:TextBox ID="txtGQuantity" runat="server" CssClass="form-control" Text="1" ReadOnly="true" Width="180px" ValidationGroup="ABC"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvQuantity" Enabled="false" runat="server" ControlToValidate="txtGQuantity" Font-Size="small"
                                                    ForeColor="red" ErrorMessage="Quantity is required." Display="Dynamic" ValidationGroup="ABC" Font-Bold="true"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:FileUpload ID="fupid" runat="server" CssClass="form-control border border-dark" Width="220px" />
                                                <asp:RequiredFieldValidator ID="rfvFileupload" runat="server" Enabled="false" Font-Bold="true" ControlToValidate="fupid" Font-Size="small" ForeColor="red" ErrorMessage="Attatchment is required."
                                                    Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                                <br />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product Type">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlProductType" OnSelectedIndexChanged="ddlProductType_SelectedIndexChanged" CssClass="form-control border border-dark" runat="server" AutoPostBack="True" ValidationGroup="ABC">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvProductType" runat="server" ControlToValidate="ddlProductType" ErrorMessage="Kindly Select the Product Type" ForeColor="red"
                                                    Display="Dynamic" ValidationGroup="ABC" Enabled="false" InitialValue="0"></asp:RequiredFieldValidator>
                                                <asp:Label ID="lblproductType" runat="server" Text='<%# Eval("PC_Product_Type") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product Name">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlProductName" OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged" CssClass="form-control border border-dark" runat="server" AutoPostBack="True" ValidationGroup="ABC">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvProductName" Enabled="false" runat="server" ControlToValidate="ddlProductName" ErrorMessage="Kindly select the Product Name" ForeColor="red"
                                                    Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
                                                <asp:Label ID="lblProName" runat="server" Text='<%# Eval("PC_Product_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product Complaints">
                                            <ItemTemplate>

                                                <asp:DropDownList ID="ddlComplaintType" AutoPostBack="true" CssClass="form-control border border-dark" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvComplaintType" Enabled="false" runat="server" ControlToValidate="ddlComplaintType" ErrorMessage="Kindly select the Complaint" ForeColor="red"
                                                    Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
                                                <asp:Label ID="lblProID" runat="server" Visible="false" Text='<%# Eval("PC_ProductID") %>'></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Is Stock Available in Brnach">
                                            <ItemTemplate>

                                                <asp:DropDownList ID="ddlStockCheck" AutoPostBack="true" CssClass="form-control border border-dark" runat="server">
                                                    <asp:ListItem Value="0" Text="Select Field"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="No"></asp:ListItem>

                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvCheckStatus" Enabled="false" runat="server" ControlToValidate="ddlStockCheck" ErrorMessage="Kindly select" ForeColor="red"
                                                    Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5px">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAction" runat="server" AutoPostBack="true" OnCheckedChanged="chkAction_CheckedChanged" />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:UpdatePanel ID="UpdatePO" runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="lnkApprove" ForeColor="White" runat="server" CssClass="btn btn-sm btn-success" ValidationGroup="ABC" CommandName="Submit" CommandArgument='<%# Eval("IS_CustID") %>'>Submit</asp:LinkButton>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="lnkApprove" />
                                                        <%--<asp:AsyncPostBackTrigger ControlID="VendorApproval" EventName="RowCommand" />--%>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                    </Columns>

                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

                                </asp:GridView>

                            </asp:Panel>

                        </div>
                    </div>
                </div>
            </blockquote>
        </div>
    </div>
</asp:Content>
