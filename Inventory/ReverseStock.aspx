<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReverseStock.aspx.cs" Inherits="ReverseStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .my-gridview th, .my-gridview td {
            padding: 10px;
        }

        .my-gridview th {
            font-size: 16px;
        }

        .my-gridview td {
            font-size: 15px;
        }

        .my-gridview .label {
            font-size: 14px;
        }

        .form {
            display: flex;
            justify-content: center;
            align-items: center;
            gap: 20px;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f0f0f0;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .my-gridview {
            margin-top: 20px;
        }

        .form label {
            display: flex;
            align-items: center;
            cursor: pointer;
            font-size: 16px;
        }



            .form label input[type="radio"] {
                margin-right: 10px;
                cursor: pointer;
            }

            .form label span {
                color: #333;
            }

            .form label:hover {
                background-color: #e0e0e0;
            }
    </style>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Reverse  stock 
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">


                <hr />

                <div class="row">

                    <div class="form">
                        <label>
                            <asp:RadioButton ID="rbloptionCustID" runat="server" GroupName="option" AutoPostBack="true" OnCheckedChanged="rbloptionCustID_CheckedChanged" />
                            <span>Customer ID</span>
                        </label>
                        <label>
                            <asp:RadioButton ID="rbloptionLoanID" runat="server" Checked="true" GroupName="option" AutoPostBack="true" OnCheckedChanged="rbloptionLoanID_CheckedChanged" />
                            <span>Loan ID</span>
                        </label>
                    </div>
                    <br />

                    <div class="col-12">
                        <div class="col-6" id="CustID" runat="server">
                            <label id="lblSearch" class="col-form-label font-weight-bold">Search Customer ID :</label>
                            <div class="form-control">
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control border border-dark" placeholder="Search By Customer ID" ValidationGroup="Cust"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCust" runat="server" ControlToValidate="txtSearch" ErrorMessage="Kindly Enter Customer ID" ForeColor="red"
                                    Display="Dynamic" ValidationGroup="Cust"></asp:RequiredFieldValidator>
                                <br />
                                <asp:Button ID="btnSearch" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="Cust" OnClick="btnSearch_Click" />
                            </div>
                        </div>



                        <div class="col-6" id="LoanID" runat="server">
                            <label id="blLoan" class="col-form-label font-weight-bold">Search Loan ID :</label>
                            <div class="form-control">
                                <asp:TextBox ID="txtLoanID" runat="server" CssClass="form-control border border-dark" placeholder="Search By Loan ID" ValidationGroup="Loann"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLoanID" runat="server" ControlToValidate="txtLoanID" ErrorMessage="Kindly Enter Loan ID" ForeColor="red"
                                    Display="Dynamic" ValidationGroup="Loann"></asp:RequiredFieldValidator>
                                <br />
                                <asp:Button ID="btnSubmitLoanID" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="Loann" OnClick="btnSubmitLoanID_Click" />

                            </div>
                        </div>
                    </div>


                    <div class="col-12">
                        <asp:GridView ID="gvReverse" runat="server" CssClass="table table-bordered table-hover my-gridview"
                            AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" ShowFooter="true" Width="100%"
                            DataKeyNames="Issued_ID" OnRowCommand="gvReverse_RowCommand">

                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>

                                <asp:TemplateField HeaderText="Customer ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustID" runat="server" Text='<%#Eval("IS_CustID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("IS_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Product">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProduct" runat="server" Text='<%# Eval("PRODUCT_ID") %>'></asp:Label>
                                        <asp:Label ID="lblProductID" runat="server" Visible="false" Text='<%# Eval("IS_Product") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Branch ">
                                    <ItemTemplate>

                                        <asp:Label ID="lblBranch" runat="server" Text='<%# Eval("BRANCH_NAME") %>'></asp:Label>
                                        <asp:Label ID="lblBranchID" Visible="false" runat="server" Text='<%# Eval("IS_Branch") %>'></asp:Label>


                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Mobile Number">
                                    <ItemTemplate>

                                        <asp:Label ID="lblMobileNO" runat="server" Text='<%# Eval("IS_MobileNO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Invoice No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSpouseNAme" runat="server" Text='<%# Eval("IS_InvoiceNO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Loan ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLoanID" runat="server" Text='<%# Eval("IS_LoanID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Issued Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIssuedQty" runat="server" Enabled="true" Text='<%#Eval("IS_Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Reverse Quantity">
                                    <ItemTemplate>

                                        <asp:TextBox ID="txtGQuantity" runat="server" CssClass="form-control border border-dark" Text="1" Width="180px" ValidationGroup="ABC"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvQuanty" Enabled="false" runat="server" ControlToValidate="txtGQuantity" Font-Size="small"
                                            ForeColor="red" ErrorMessage="Quantity is required." Display="Dynamic" ValidationGroup="ABC" Font-Bold="true"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5px">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkAction" runat="server" AutoPostBack="true" />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="lnkApprove" ForeColor="White" runat="server" CssClass="btn btn-sm btn-success" ValidationGroup="ABC" CommandName="Submit" CommandArgument='<%# Eval("Issued_ID") %>'>Reversed </asp:LinkButton>
                                        </ContentTemplate>
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
                    </div>
                </div>
            </blockquote>
        </div>
    </div>
</asp:Content>

