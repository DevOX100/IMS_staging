<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ViewTransferStock.aspx.cs" Inherits="Inventory_ViewTransferStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">


    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Transfer Stock Details
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">

                <%--  <div class="form-control" id="box" runat="server">

                    <div class="col-6">
                        <label for="Branch" class="col-form-label bold">Select Branch : <span style="color: red"></span></label>
                        <asp:DropDownList ID="ddlBranch" runat="server" Enabled="true" CssClass="form-control border border-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                </div>

                <hr />--%>
                <div class="row">

                    <div id="Region" runat="server" class="col-3">
                        <label id="lblRegion" runat="server" class="col-form-label bold">Region : <span style="color: red">*</span></label>
                        <asp:DropDownList ID="ddlRegion" runat="server" Enabled="true" CssClass="form-control border border-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-3">
                        <label id="lblBranch" runat="server" class="col-form-label bold">Branch : <span style="color: red">*</span></label>
                        <asp:DropDownList ID="ddlBranch" runat="server" Enabled="true" CssClass="form-control border border-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                        </asp:DropDownList><br />
                        <br />
                    </div>

                </div>

                <div class="col-12">


                    <asp:GridView ID="gvStockTransfer" runat="server" CssClass="table table-bordered table-hover my-gridview"
                        AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" ShowFooter="True" Width="100%" Font-Size="Medium"
                        CellPadding="4">

                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>

                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" Font-Bold="true" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Product">
                                <ItemTemplate>
                                    <asp:Label ID="lblProduct" runat="server" Text='<%#Eval("Product") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sender Branch">
                                <ItemTemplate>
                                    <asp:Label ID="lblBranch" runat="server" Text='<%#Eval("Branch") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sender Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblSendQty" runat="server" Text='<%#Eval("ST_SendQuantity") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sender Remarks">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("ST_Remarks") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Stock Sent Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblSentDate" runat="server" Text='<%# Eval("InsertDate") %>'></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Stock Received Branch">
                                <ItemTemplate>
                                    <asp:Label ID="lblRecBranch" runat="server" Text='<%# Eval("RecBranch") %>'></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Stock Received Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblRecDate" runat="server" Text='<%# Eval("ReceivedDate") %>'></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Stock Received Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblrecQty" runat="server" Text='<%# Eval("ReceivedQuantity") %>'></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Stock Received Remarks">
                                <ItemTemplate>
                                    <asp:Label ID="lblRecRemarks" runat="server" Text='<%# Eval("ReceivedRemarks") %>'></asp:Label>

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
                </div>

            </blockquote>
        </div>
    </div>
</asp:Content>

