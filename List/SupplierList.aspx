<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SupplierList.aspx.cs" Inherits="List_SupplierList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Product List
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form-control ">


                    <div class="row">
                        <div class="col">
                            <asp:Panel runat="server" frameborder="0" ScrollBars="Both" Align="Center">
                                <asp:GridView ID="gvVendor" runat="server" CssClass="table table-bordered table-hover"
                                    AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" ShowFooter="true" Width="100%" OnRowCommand="gvVendor_RowCommand">

                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="SrNo" HeaderText="Sr. No." />
                                        <asp:TemplateField HeaderText="Vendor">
                                            <ItemTemplate>
                                                <%#Eval("VM_VendorCode") %>
                                                <br />
                                                <%#Eval("VM_Name") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Address">
                                            <ItemTemplate>
                                                <%#Eval("VM_Address1") %>
                                                <br />
                                                <%#Eval("VM_Address2") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Pincode / City">
                                            <ItemTemplate>
                                                <%#Eval("VM_Pincode") %>
                                                <br />
                                                <%#Eval("VM_City") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="State / Country">
                                            <ItemTemplate>
                                                <%#Eval("VM_State") %>
                                                <br />
                                                <%#Eval("VM_Country") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Phone / Email">
                                            <ItemTemplate>
                                                <%#Eval("VM_Phone") %>
                                                <br />
                                                <%#Eval("VM_Email") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="PAN / GST">
                                            <ItemTemplate>
                                                <%#Eval("VM_PAN") %>
                                                <br />
                                                <%#Eval("VM_GST") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="VM_Other1" HeaderText="Other 1" />
                                        <asp:BoundField DataField="VM_Other2" HeaderText="Other 2" />
                                        <asp:BoundField DataField="VM_Other3" HeaderText="Other 3" />
                                        <asp:BoundField DataField="VM_Other4" HeaderText="Other 4" />
                                        <asp:BoundField DataField="IsActive" HeaderText="Is Active" />

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkModify" runat="server" class="btn btn-danger bg-white text-danger" CommandName="EditData" Text="Edit" CommandArgument='<%# Eval("VM_VendorCode") %>' OnClientClick="return confirm (&quot;Are you sure want to Change this?? &quot;)"></asp:LinkButton>

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

