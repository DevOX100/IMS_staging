<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BranchInitiateStock.aspx.cs" Inherits="Inventory_BranchInitiateStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Branch Initiate Stock
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form-control border border-dark ">
                    <div class="row">
                        <div class="col-6">
                            <label for="Product" class="col-form-label bold">Product : <span style="color: red">*</span></label>
                            <asp:DropDownList ID="ddlProduct" runat="server" Enabled="true" CssClass="form-control border border-dark" ValidationGroup="ABC">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlProduct" ErrorMessage="Kindly choose Product" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-6" style="margin-top: 40px">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn text-white" BackColor="#3a4f63"
                                OnClick="btnSubmit_Click" ValidationGroup="ABC" />
                        </div>
                    </div>

                   
                

                    <div class="row">
                        <div class="col-12">

    <hr />


                                              <asp:GridView ID="gvStockInitiate" runat="server" CssClass="table table-bordered table-hover"
                      AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" ShowFooter="true" Width="100%"
                      DataKeyNames="PM_ItemCode1" OnRowCommand="gvStockInitiate_RowCommand">

                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                      <Columns>

                          <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5px">
                              <ItemTemplate>
                                  <asp:CheckBox ID="chkAction" runat="server" />
                              </ItemTemplate>
                              <FooterTemplate>
                                  <asp:LinkButton ID="lnkApprove" ForeColor="White" runat="server" CssClass="btn btn-sm btn-success"
                                      ValidationGroup="BISS" CommandName="Submit" CommandArgument='<%# Eval("PM_ItemCode1") %>'>Submit</asp:LinkButton>
                              </FooterTemplate>
                          </asp:TemplateField>

                          <asp:TemplateField HeaderText="Product ID" Visible="false">
                              <ItemTemplate>
                                  <asp:Label ID="lblProductID" runat="server" Text='<%#Eval("PM_ItemCode1")%>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>

                          <asp:TemplateField HeaderText="Product In Stock" Visible="false">
                              <ItemTemplate>

                                  <asp:Label ID="lblProductInStock" runat="server" Text='<%#Eval("product_In_StockID")%>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>

                       <%--   <asp:BoundField DataField="PM_ItemCode2" HeaderText="Product" />--%>

                          <asp:TemplateField HeaderText="Product">
                              <ItemTemplate>
                                  <asp:Label ID="lblDes1" runat="server" Text='<%#Eval("PM_Description1")%>'></asp:Label>
                                  (<asp:Label ID="lblitemCode2" runat="server" Text='<%#Eval("PM_ItemCode2")%>'></asp:Label>)
                                 <%-- <br />
                                  <asp:Label ID="lblDes2" runat="server" Text='<%#Eval("PM_Description2")%>'></asp:Label>--%>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <%--                                    <asp:BoundField DataField="PM_Description1" HeaderText="Description 1" />
                          <asp:BoundField DataField="PM_Description2" HeaderText="Description 2" />--%>
                          <asp:BoundField DataField="PM_Category" HeaderText="Product Category" />
                          <asp:BoundField DataField="PM_Brand" HeaderText="Product Brand" />
                          <asp:BoundField DataField="PM_Aggregator" HeaderText="Aggregator" />
                          <%--<asp:BoundField DataField="SerialNO" HeaderText="Serial No" />--%>
                          <asp:BoundField DataField="out_stock" HeaderText="Handover Stock(Last 30 days)" />
                          <asp:BoundField DataField="available_stock" HeaderText="Available Stock" />
                          <%--<asp:BoundField DataField="Stock_status" HeaderText="Stock Status" />--%>


                          <asp:TemplateField HeaderText="Request New Stock (In figures)">
                              <ItemTemplate>
                                  </br>
<asp:TextBox ID="txtQuantityBIS" runat="server" CssClass="form-control border border-dark" placeholder="Enter Quantity" Width="180px" MaxLength="3" ValidationGroup="BISS"></asp:TextBox>
                                  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtQuantityBIS" FilterType="Numbers" ValidChars="0123456789" />
                                  <asp:RequiredFieldValidator ID="rfv11" runat="server" ControlToValidate="txtQuantityBIS" Font-Size="small" Font-Bold="true"
                                      ForeColor="red" ErrorMessage="Quantity is required." Display="Dynamic" ValidationGroup="BISS"></asp:RequiredFieldValidator>
                              </ItemTemplate>
                          </asp:TemplateField>

                          <asp:TemplateField HeaderText="Remarks">
                              <ItemTemplate>
                                  </br>
<asp:TextBox ID="txtRemarksBIS" runat="server" CssClass="form-control border border-dark" placeholder="Enter Remarks" Width="180px" TextMode="MultiLine" ValidationGroup="BISS"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="rfvv12" runat="server" ControlToValidate="txtRemarksBIS" Font-Size="small" Font-Bold="true"
                                      ForeColor="red" ErrorMessage="Remarks is required." Display="Dynamic" ValidationGroup="BISS"></asp:RequiredFieldValidator>
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
                    </div>


                    <div class="row">
                        <div class="col-12">




                            <asp:GridView ID="gv_BranchDelConf" runat="server" CssClass="table table-bordered table-hover"
                                AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" ShowFooter="true" Width="100%"
                                DataKeyNames="BIS_id" OnRowCommand="gv_BranchDelConf_RowCommand">

                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <%--<asp:BoundField DataField="Branch" HeaderText="Branch" />--%>
                                    <asp:BoundField DataField="ProductID" HeaderText="Product" />
                                    <%--<asp:BoundField DataField="BIS_status" HeaderText="Status" />--%>
                                    <asp:BoundField DataField="BIS_insertDate" HeaderText="Request Date" />
                                    <asp:BoundField DataField="BIS_Quantity" HeaderText="Requested Stock" />
                                    <asp:BoundField DataField="BIS_Initiator_remarks" HeaderText="Initiator Remarks" />

                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDelete" runat="server" CommandName="StockDelete" Width="90px" OnClientClick="return confirm('Are you sure to delete this?')"
                                                CommandArgument='<%#Eval("BIS_id") %>' Height="33" CssClass="btn btn-danger" ForeColor="White" Visible='<%#Convert.ToBoolean(Eval("is_Initiate"))%>'>Delete</asp:LinkButton>
                                            <%--<asp:Label ID="lblDeleted" runat="server" Text="Request Deleted" ForeColor="Red" Font-Bold="true" Visible='<%#Convert.ToBoolean(Eval("is_Status"))%>'></asp:Label>--%>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Confirm">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbConfirm" runat="server" CommandName="StockConfirm" Width="90px" OnClientClick="return confirm('Are you sure to Confirm this?')"
                                                CommandArgument='<%#Eval("BIS_id") %>' Height="33" CssClass="btn btn-success" ForeColor="White" Visible='<%#Convert.ToBoolean(Eval("is_Initiate"))%>'>Confirm</asp:LinkButton>
                                            <asp:Label ID="lblConfirmed" runat="server" Text="Request Confirmed"  ForeColor="Green" Font-Bold="true"  Visible='<%#Convert.ToBoolean(Eval("is_Status"))%>'></asp:Label>
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
                    </div>


                </div>
            </blockquote>
        </div>
    </div>
</asp:Content>

