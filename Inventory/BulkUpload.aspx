<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BulkUpload.aspx.cs" Inherits="Inventory_BulkUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Bulk Upload 
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form">
                    <label>
                        <asp:RadioButton ID="rbReverse" runat="server" GroupName="customer" AutoPostBack="true" Checked="true" OnCheckedChanged="rbReverse_CheckedChanged" />
                        <span>Reverse</span>
                    </label>
                    <label>
                        <asp:RadioButton ID="rbIssue" runat="server" GroupName="customer" AutoPostBack="true" OnCheckedChanged="rbIssue_CheckedChanged" />
                        <span>Issue</span>
                    </label>
                </div>

                <br />

                <div class="row">
                    <div class="col-4">
                        <asp:FileUpload ID="fpBulkUpload" runat="server" CssClass="form-control" />

                    </div>

                    <div class="col-1">
                        <asp:Button ID="btnUploadExcel" runat="server" Text="Upload" CssClass="btn btn-primary" BackColor="#3a4f63" OnClick="btnUploadExcel_Click" />
                    </div>

                    <div class="col-2">
                        <asp:UpdatePanel ID="Update" runat="server">

                            <ContentTemplate>



                                <asp:Button ID="btnFormat" runat="server" Text="Download Format" CssClass="btn btn-warning" OnClick="btnFormat_Click" />


                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnUploadExcel" />
                                <asp:PostBackTrigger ControlID="btnFormat" />
                                <%--        <asp:PostBackTrigger ControlID="btnDwnldData" />--%>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>

            </blockquote>
        </div>
    </div>

    <div>
        <asp:GridView ID="gvBulk" runat="server" AutoGenerateColumns="False" CellPadding="4"
            CssClass="table table-bordered table-hover" OnRowCommand="gvBulk_RowCommand" ForeColor="#333333"
            GridLines="None" ShowFooter="True" Width="100%">
            <EditRowStyle BackColor="#7C6F57" />
            <EmptyDataTemplate>
                <h3>No record found!!</h3>
            </EmptyDataTemplate>
            <AlternatingRowStyle BackColor="White" />
            <Columns>

                <asp:TemplateField HeaderText="CustID">
                    <ItemTemplate>
                        <asp:Label ID="lblCustID" runat="server" Text='<%#Eval("CustID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Loan ID">
                    <ItemTemplate>
                        <asp:Label ID="lblLoanID" runat="server" Text='<%#Eval("LoanID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product ID">
                    <ItemTemplate>
                        <asp:Label ID="lblProductID" runat="server" Text='<%#Eval("ProductID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Branch ID">
                    <ItemTemplate>
                        <asp:Label ID="lblBranchID" runat="server" Text='<%#Eval("BranchID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="lblReverseQuantity" runat="server" Text='<%#Eval("ReverseQuantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkReport" runat="server" Checked="true" Enabled="false" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="btnSave" runat="server" CausesValidation="false" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Report" CssClass="btn btn-danger" Text="Save" ValidationGroup="a" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </div>
</asp:Content>

