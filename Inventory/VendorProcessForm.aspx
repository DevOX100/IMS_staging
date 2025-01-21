<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="VendorProcessForm.aspx.cs" Inherits="Inventory_VendorProcessForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <script type="text/javascript">
        function OpenNewPopUp(val, id) {
            // alert('Entered as a ' + val);
            if (val == '1') {
                $('#' + id).show();
                setTimeout(function () {
                    $('#' + id).show();
                    $('#' + id).addClass('show');
                    $('body').css('overflow', 'hidden');
                    var elem = document.createElement('div');
                    elem.className = "modal-backdrop show";
                    //elem.style.cssText = "z-index:9999;";
                    document.body.appendChild(elem);
                }, 300);
            }
            else {
                $('#' + id).removeClass('show');
                $('div[class*="modal-backdrop"]').remove();
                setTimeout(function () {
                    $('#' + id).hide();
                    $('body').css('overflow', 'auto');
                }, 100);
            }
        }
    </script>
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
                                        <asp:TemplateField HeaderText="Cancel">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbcancel" runat="server" CommandName="StockCancel" Width="90px" OnClientClick="return confirm('Are you sure to Confirm this?')"
                                                    CommandArgument='<%#Eval("BIS_ID") %>' Height="33" CssClass="btn btn-success" ForeColor="White">Cancel</asp:LinkButton>


                                            </ItemTemplate>
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
                                        <asp:TemplateField HeaderText="View Details" HeaderStyle-Width="5px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="linkView" runat="server" CommandName="View" CommandArgument='<%# Eval("BIS_id") %>'>Details</asp:LinkButton>
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
    <div id="divModel_InvoiceDetails" runat="server" visible="false" class="modal fade" role="dialog" clientidmode="Static">
        <div class="modal-dialog" role="document">
            <!-- Modal content-->
            <div class="modal-content">

                <div class="modal-header">
                    <h5 class="modal-title fw-bold" id="lblModalInvoiceDetails">Details :</h5>
                    <a href="#" style="text-decoration: none" aria-hidden="true" data-dismiss="modal" aria-label="Close">
                        <i class="fa fa-times fa-2x alert-danger" aria-hidden="true"></i>
                    </a>
                </div>

                <div class="modal-body" style="overflow-y: auto; overflow-x: hidden; height: 450px;">
                    <table class="table table-bordered table-hover table-striped" style="margin-left: 20px; margin-right: 10px; margin-top: 10px; width: 400px">
                        <tr>
                            <td>
                                <b>Requested Stock</b>
                            </td>
                            <td>
                                <asp:Label ID="lblRequestedQuantity" runat="server" Text='<%#Eval("BIS_Quantity")%>' Font-Bold="true"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <b>Requestor Remarks</b>
                            </td>
                            <td>
                                <asp:Label ID="lblRequestorRemarks" runat="server" Text='<%#Eval("BIS_initiator_remarks")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Requested Date</b>
                            </td>
                            <td>
                                <asp:Label ID="lblRequestedDate" runat="server" Text='<%#Eval("BIS_insertDate")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>RM Stock Acceptance Quanity</b>
                            </td>
                            <td>
                                <asp:Label ID="lblStockAcceptance" runat="server" Text='<%#Eval("BIS_approved_quantity")%>' Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>RM Stock Acceptance Remarks</b>
                            </td>
                            <td>
                                <asp:Label ID="lblAcceptorRemarks" runat="server" Text='<%#Eval("BIS_approved_remarks")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>RM Stock Acceptance Date</b>
                            </td>
                            <td>
                                <asp:Label ID="lblRMApproveDate" runat="server" Text='<%#Eval("BIS_approve_date")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>CPP(RO) Approved Quantity</b>
                            </td>
                            <td>
                                <asp:Label ID="lblCppQuantity" runat="server" Font-Bold="true" Text='<%#Eval("BIS_CPP_approved_quantity") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>CPP(RO) Remarks</b>
                            </td>
                            <td>
                                <asp:Label ID="lblcppRemarks" runat="server" Text='<%#Eval("BIS_CPP_Approved_Remarks") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>CPP(RO) Approved Date</b>
                            </td>
                            <td>
                                <asp:Label ID="lblCPPApproveDate" runat="server" Text='<%#Eval("BIS_CPP_Approved_Date") %>'></asp:Label>
                            </td>
                        </tr>


                        <tr>
                            <td>
                                <b>HO Approved Quantity</b>
                            </td>
                            <td>
                                <asp:Label ID="lblHOAprQty" runat="server" Font-Bold="true" Text='<%#Eval("BIS_HO_approved_quantity") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>HO Remarks</b>
                            </td>
                            <td>
                                <asp:Label ID="lblHORemarks" runat="server" Text='<%#Eval("BIS_HO_Approved_Remarks") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>HO Approved Date</b>
                            </td>
                            <td>
                                <asp:Label ID="lblHODate" runat="server" Text='<%#Eval("BIS_POGeneratedOn") %>'></asp:Label>
                            </td>
                        </tr>
                    </table>

                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnClose" class="btn btn-danger" runat="server" Text="Close" OnClick="btnClose_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
