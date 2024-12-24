<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="VendorProcessForm.aspx.cs" Inherits="Inventory_VendorProcessForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Order Process
        </div>

        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form-control border border-dark">
                    <div class="row">
                        <div class="col">

                            <asp:Panel runat="server" frameborder="0" ScrollBars="Both" Align="Center">




                                <asp:GridView ID="VendorApproval" runat="server" CssClass="table table-bordered table-hover"
                                    AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" ShowFooter="true" Width="100%"
                                    OnRowCommand="VendorApproval_RowCommand" DataKeyNames="BIS_ID" OnRowDataBound="VendorApproval_RowDataBound">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>

                                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5px">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAction" runat="server" />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                        <asp:LinkButton ID="lnkApprove" ForeColor="White" runat="server" CssClass="btn btn-sm btn-success" ValidationGroup="Vendor" CommandName="Submit" CommandArgument='<%# Eval("BIS_ID") %>'>Approved</asp:LinkButton>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                  <asp:Label ID="lblbisid" runat="server" Text='<%#Eval("BIS_ID") %>' Visible="false"></asp:Label>
                                              <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control border border-dark">
                                    
                                              </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Branch">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBranchID" runat="server" Text='<%#Eval("BRANCH_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Product/Category">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductID" runat="server" Text='<%#Eval("BIS_productID") %>' Font-Bold="true"></asp:Label><br />
                                                <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("PM_Category") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApprQuantity" runat="server" Text='<%#Eval("BIS_HO_approved_quantity") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Price">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnitPrice" runat="server" Text='<%#Eval("PM_UnitPrice") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PO Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPOAmount" runat="server" Text='<%#Eval("po_amount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PO Number">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPoNumber" runat="server" Text='<%#Eval("PO_number") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Initiate Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDeliveryDate" runat="server" Text='<%#Eval("BIS_HODApprovalDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PO">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDownload" runat="server" CommandName="Download" CommandArgument='<%# Eval("PO_number") %>'>View </asp:LinkButton>
                                            </ItemTemplate>
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
