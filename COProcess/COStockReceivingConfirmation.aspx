<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="COStockReceivingConfirmation.aspx.cs" Inherits="COProcess_COStockReceivingConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            CO Stock Receiving Confirmation
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">

                <div class="row">
                    <div class="col-12">
                        <asp:GridView ID="gvCORecStock" runat="server" CssClass="table table-bordered table-hover"
                            AutoGenerateColumns="False" GridLines="None" Font-Size="Medium" ForeColor="#333333" ShowFooter="True" Width="100%"
                            DataKeyNames="PMC_ID" OnRowCommand="gvCORecStock_RowCommand" CellPadding="4">

                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Branch">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranch" runat="server" Text='<%#Eval("branch")%>' Font-Bold="true"></asp:Label>
                                        <asp:Label ID="lblBranchID" runat="server" Text='<%#Eval("PMC_BranchID")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Product">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProduct" runat="server" Text='<%#Eval("PMC_ProductID")%>'></asp:Label>
                                        <asp:Label ID="lblProductID" runat="server" Text='<%#Eval("PM_ItemCode1")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Branch Mapped Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBQty" runat="server" Text='<%#Eval("PMC_BQuantity")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Mapped On / By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMappedOn" runat="server" Text='<%#Eval("PMC_MappedDate")%>'></asp:Label>
                                        <br />
                                        <asp:Label ID="lblMappedby" runat="server" Text='<%#Eval("PMC_MappedBy")%>' Font-Bold="true"></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("PMC_BRemarks")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Received Quantity /Remarks">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRecQuantity" runat="server" CssClass="form-control border border-dark" MaxLength="3" placeholder="Received Quantity" Width="180px" ValidationGroup="Branch"></asp:TextBox>

                                        <asp:RequiredFieldValidator ID="rfvQnty" runat="server" Enabled="false" Font-Bold="true" ControlToValidate="txtRecQuantity" Font-Size="small" ForeColor="red" ErrorMessage="Quantity is required."
                                            Display="Dynamic" ValidationGroup="AXV"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:TextBox ID="txtRecRemarks" runat="server" CssClass="form-control border border-dark" placeholder="Enter Remarks" Width="180px" TextMode="MultiLine" ValidationGroup="Branch"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="frvRmrks" runat="server" Enabled="false" Font-Bold="true" ControlToValidate="txtRecRemarks" Font-Size="small" ForeColor="red" ErrorMessage="Remarks is required."
                                            Display="Dynamic" ValidationGroup="AXV"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>




                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5px">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkAction" runat="server" AutoPostBack="true" OnCheckedChanged="chkAction_CheckedChanged" />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:UpdatePanel ID="UpdatePO" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="lnkApprove" ForeColor="White" runat="server" CssClass="btn btn-sm btn-success"
                                                    ValidationGroup="AXV" CommandName="Submit" CommandArgument='<%# Eval("PMC_ID") %>'>Submit</asp:LinkButton>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="lnkApprove" />
                                            </Triggers>
                                        </asp:UpdatePanel>
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

