<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="COStockReturnedConfirmation.aspx.cs" Inherits="COProcess_COStockReturnedConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            CO Returned Stock
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">

                <div class="row">
                    <div class="col-12">
                        <asp:GridView ID="gvCORetStock" runat="server" CssClass="table table-bordered table-hover"
                            AutoGenerateColumns="False" GridLines="None" Font-Size="Medium" ForeColor="#333333" ShowFooter="True" Width="100%"
                            DataKeyNames="product_In_StockID" OnRowCommand="gvCORetStock_RowCommand" CellPadding="4">

                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Branch">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranch" runat="server" Text='<%#Eval("Branch")%>' Font-Bold="true"></asp:Label>
                                        <asp:Label ID="lblBranchID" runat="server" Text='<%#Eval("BRANCH_ID")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Product">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProduct" runat="server" Text='<%#Eval("PM_Description1")%>'></asp:Label>
                                        <asp:Label ID="lblProductID" runat="server" Text='<%#Eval("productid")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Center Officer">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCO" runat="server" Text='<%#Eval("CO")%>'></asp:Label>
                                        <asp:Label ID="lblCOID" runat="server" Text='<%#Eval("COID")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Total Stock">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInStock" runat="server" Text='<%#Eval("in_stock")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Out Stock">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOutStock" runat="server" Text='<%#Eval("out_stock")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Return Stock">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReturnStock" runat="server" Text='<%#Eval("Return_stock")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Available Stock">
                                    <ItemTemplate>
                                        <asp:Label ID="lblavailablestock" runat="server" Text='<%#Eval("available_stock")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Return Stock /Remarks">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRetQuantity" runat="server" CssClass="form-control border border-dark" MaxLength="3" placeholder="Return Stock" Width="180px" ValidationGroup="Branch"></asp:TextBox>

                                        <asp:RequiredFieldValidator ID="rfvQnty" runat="server" Enabled="false" Font-Bold="true" ControlToValidate="txtRetQuantity" Font-Size="small" ForeColor="red" ErrorMessage="Quantity is required."
                                            Display="Dynamic" ValidationGroup="AXV"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:TextBox ID="txtRetRemarks" runat="server" CssClass="form-control border border-dark" placeholder="Enter Return Remarks" Width="180px" TextMode="MultiLine" ValidationGroup="Branch"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="frvRmrks" runat="server" Enabled="false" Font-Bold="true" ControlToValidate="txtRetRemarks" Font-Size="small" ForeColor="red" ErrorMessage="Remarks is required."
                                            Display="Dynamic" ValidationGroup="AXV"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>




                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5px">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkAction" runat="server" AutoPostBack="true" OnCheckedChanged="chkAction_CheckedChanged" />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="lnkApprove" ForeColor="White" runat="server" CssClass="btn btn-sm btn-success"
                                            ValidationGroup="AXV" CommandName="Submit" CommandArgument='<%# Eval("product_In_StockID") %>'>Submit</asp:LinkButton>
                                    </FooterTemplate>

                                    <HeaderStyle Width="5px"></HeaderStyle>
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

