<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReceivedStockTransfer.aspx.cs" Inherits="Inventory_ReceivedStockTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Received Transfer Stock
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">

                <div class="form-control" id="box" runat="server">

                    <div class="col-6">
                        <label for="Branch" class="col-form-label bold">Select Branch : <span style="color: red"></span></label>
                        <asp:DropDownList ID="ddlBranch" runat="server" Enabled="true" CssClass="form-control border border-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                </div>

                <hr />

                <div class="col-12">


                    <asp:GridView ID="gvStockTransfer" runat="server" CssClass="table table-bordered table-hover my-gridview"
                        AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" ShowFooter="True" Width="100%" DataKeyNames="ST_ID" Font-Size="Medium"
                        OnRowCommand="gvStockTransfer_RowCommand" CellPadding="4">

                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Branch">
                                <ItemTemplate>
                                     <asp:Label ID="lblSTFromBranch" Visible="false" runat="server" Text='<%#Eval("ST_FromBranch") %>'></asp:Label>
                                    <asp:Label ID="lblBranch" runat="server" Text='<%#Eval("Branch") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Product">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductID" runat="server" Text='<%#Eval("ST_ProductID") %>'></asp:Label>
                                    <asp:Label ID="lblProduct" runat="server" Text='<%#Eval("Product") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sent Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblSendQty" Visible="false" runat="server" Text='<%#Eval("ST_SendQuantity") %>'></asp:Label>
                                    <asp:TextBox ID="lblsQty" Enabled="false" runat="server" CssClass="form-control border border-dark" Text='<%#Eval("ST_SendQuantity") %>' Width="180px" MaxLength="3" ValidationGroup="BISS"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("ST_Remarks") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Stock Sent Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblSentDate" runat="server" Text='<%# Eval("InsertDate") %>'></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Received Quantity">
                                <ItemTemplate>


                                    <asp:TextBox ID="txtRecQuantity" runat="server" CssClass="form-control border border-dark" placeholder="Enter Quantity" Width="180px" MaxLength="3" ValidationGroup="BISS"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtRecQuantity" FilterType="Numbers" ValidChars="0123456789" />
                                    <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtRecQuantity" Font-Size="small" Font-Bold="true"
                                        ForeColor="red" Enabled="false" ErrorMessage="Quantity is required." Display="Dynamic" ValidationGroup="XYZ"></asp:RequiredFieldValidator>

                                   <%-- <asp:CompareValidator
                                        ID="cvConfirmPassword"
                                        runat="server"
                                        ControlToValidate="txtRecQuantity"
                                        ControlToCompare="lblsQty"
                                        Operator="LessThanEqual"
                                        ErrorMessage="Received Quantity must be Less than or equal to sent Quantity."
                                        ForeColor="Red"
                                        Font-Bold="true"
                                        Display="Dynamic" />--%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control border border-dark" placeholder="Enter Remarks" Width="180px" TextMode="MultiLine" ValidationGroup="BISS"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvRemarks" runat="server" ControlToValidate="txtRemarks" Font-Size="small" Font-Bold="true"
                                        ForeColor="red" Enabled="false" ErrorMessage="Remarks is required." Display="Dynamic" ValidationGroup="XYZ"></asp:RequiredFieldValidator>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5px">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAction" runat="server" AutoPostBack="true" OnCheckedChanged="chkAction_CheckedChanged" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="lnkApprove" ForeColor="White" runat="server" CssClass="btn btn-sm btn-success"
                                        ValidationGroup="XYZ" CommandName="Submit" CommandArgument='<%# Eval("ST_ID") %>'>Submit</asp:LinkButton>
                                </FooterTemplate>

                                <HeaderStyle Width="5px"></HeaderStyle>
                            </asp:TemplateField>

                        </Columns>

                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />

                    </asp:GridView>
                </div>


            </blockquote>
        </div>
    </div>
</asp:Content>

