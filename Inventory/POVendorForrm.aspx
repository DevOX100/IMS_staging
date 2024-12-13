<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="POVendorForrm.aspx.cs" Inherits="Inventory_POVendorForrm" %>

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
                 var checkboxes = document.querySelectorAll("#<%= VendorApproval.ClientID %> input[type='checkbox']");
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

                            <asp:Panel runat="server" frameborder="0" ScrollBars="Both" Align="Center">




                                <asp:GridView ID="VendorApproval" runat="server" CssClass="table table-bordered table-hover"
                                    AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" ShowFooter="true" Width="100%"
                                    OnRowCommand="VendorApproval_RowCommand" DataKeyNames="BIS_ID" OnRowDataBound="VendorApproval_RowDataBound">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>




                                        <asp:TemplateField HeaderText="Branch">
                                            <ItemTemplate>
                                                <asp:Label ID="lblbisid" runat="server" Text='<%#Eval("BIS_ID") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblBranchID" runat="server" Text='<%#Eval("BRANCH_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Product/Category">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductID" runat="server" Text='<%#Eval("BIS_productID") %>' Font-Bold="true"></asp:Label><br />
                                                <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("PM_Category") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Requested Quantity">
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
                                        <asp:TemplateField HeaderText="Sent Quantity">
                                            <ItemTemplate>
                                               <asp:Label runat="server" ID="lblVendorSendstock"  Text='<%#Eval("BIS_vendor_stock_quantity") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--            <asp:TemplateField HeaderText="Expected Delivery Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDeliveryDate" runat="server" Text='<%#Eval("Delivery_Date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="Dispatched Quantity / Expected Delivery Date">
                                            <ItemTemplate>
                                                
                                                <asp:TextBox ID="txtQuantity" runat="server" AutoPostBack="true" OnTextChanged="txtQuantity_TextChanged" CssClass="form-control border border-dark" MaxLength="3" Text='<%#Eval("BIS_HO_approved_quantity") %>' Width="180px"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtQuantity" FilterType="Numbers" ValidChars="0123456789" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Font-Bold="true" Enabled="false" ControlToValidate="txtQuantity" Font-Size="small" ForeColor="red" ErrorMessage="Quantity is required."
                                                    Display="Dynamic" ValidationGroup="Vendor"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:TextBox ID="txtTentativeDelDate" runat="server" CssClass="form-control border border-dark" placeholder="Enter Tentative Delivery Date" TextMode="date" Width="180px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvTentDelDate" runat="server" Font-Bold="true" Enabled="false" ControlToValidate="txtTentativeDelDate" Font-Size="small" ForeColor="red" ErrorMessage="Tentative Delivery Date is required."
                                                    Display="Dynamic" ValidationGroup="Vendor"></asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Remarks / Attachment">
                                            <ItemTemplate>

                                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control border border-dark" placeholder="Enter Remarks" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ers" runat="server" Enabled="false" Font-Bold="true" ControlToValidate="txtRemarks" Font-Size="small" ForeColor="red" ErrorMessage="Remarks is required."
                                                    Display="Dynamic" ValidationGroup="Vendor"></asp:RequiredFieldValidator>
                                                <br />

                                                <asp:FileUpload ID="fupid" runat="server" CssClass="form-control border border-dark" Width="220px" />
                                                <asp:RequiredFieldValidator ID="rfvFileupload" runat="server" Enabled="false" Font-Bold="true" ControlToValidate="fupid" Font-Size="small" ForeColor="red" ErrorMessage="Attatchment is required."
                                                    Display="Dynamic" ValidationGroup="Vendor"></asp:RequiredFieldValidator>

                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control border border-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlStatus" runat="server" Enabled="false" Font-Bold="true" ControlToValidate="ddlStatus" Font-Size="small" ForeColor="red" ErrorMessage="Status is required."
                                                    Display="Dynamic" ValidationGroup="Vendor" InitialValue="0"></asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5px">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAction" runat="server" AutoPostBack="true" OnCheckedChanged="chkAction_CheckedChanged" />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:UpdatePanel ID="UpdatePO" runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="lnkApprove" ForeColor="White" runat="server" OnClientClick="showLoading();" CssClass="btn btn-sm btn-success" ValidationGroup="Vendor" CommandName="Submit" CommandArgument='<%# Eval("BIS_ID") %>'>Submit</asp:LinkButton>

                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="lnkApprove" />
                                                        <%--<asp:AsyncPostBackTrigger ControlID="VendorApproval" EventName="RowCommand" />--%>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--      <asp:TemplateField HeaderText="PO">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDownload" runat="server" CommandName="Download" CommandArgument='<%# Eval("PO_number") %>'>View </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
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