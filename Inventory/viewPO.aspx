<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="viewPO.aspx.cs" Inherits="Inventory_viewPO" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function SelectAllCheckboxes(chkAll) {
            var grid = document.getElementById('<%= gvApproval.ClientID%>');
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    inputs[i].checked = chkAll.checked;
                }
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

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

    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Purchase Order
        </div>

        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form-control">

                    <div class="row">
                        <div class="col-12">
                            <h5 id="h5PONumber" runat="server">Select The fields </h5>
                        </div>
                    </div>

                    <div class="row">




                        <div class="col-3">
                            <asp:DropDownList ID="ddlBranch" runat="server" Enabled="true" AutoPostBack="true" CssClass="form-control"
                                OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" EnableViewState="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-3">
                            <asp:DropDownList ID="ddlVendor" runat="server" Enabled="true" AutoPostBack="true" CssClass="form-control"
                                OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged" EnableViewState="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-3">
                            <asp:DropDownList ID="ddlStatus" runat="server" Enabled="true" AutoPostBack="true" CssClass="form-control"
                                OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-3">
                            <asp:DropDownList ID="ddlPONUMBER" runat="server" Enabled="true" AutoPostBack="true" CssClass="form-control"
                                OnSelectedIndexChanged="ddlPONUMBER_SelectedIndexChanged" EnableViewState="true">
                            </asp:DropDownList>
                        </div>

                    </div>
                    <hr />

                    <div class="row">
                        <div class="col">

                            <asp:Panel runat="server" frameborder="0" ScrollBars="Both" Align="Center">


                                <asp:GridView ID="gvApproval" runat="server" CssClass="table table-bordered table-hover"
                                    AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" ShowFooter="true" Width="100%"
                                    OnRowCommand="gvApproval_RowCommand">

                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="BIS_status" HeaderText="Status" ItemStyle-Font-Bold="true" />
                                        <%-- <asp:BoundField DataField="BIS_HODApprovalDate" HeaderText="HOD Acceptance Date" />--%>
                                        <asp:BoundField DataField="BranchDetails" HeaderText="Branch" />
                                        <asp:BoundField DataField="PM_Aggregator" HeaderText="Vendor Name" />
                                        <asp:BoundField DataField="product" HeaderText="Product" />

                                        <asp:BoundField DataField="PO_number" HeaderText="PO Number" />
                                        <asp:BoundField DataField="PODate" HeaderText="Order Date" />

                                        <asp:BoundField DataField="Quantity" HeaderText="Approved Stock" />
                                        <asp:BoundField DataField="price" HeaderText="Unit Price" />

                                        <asp:BoundField DataField="total_amount" HeaderText="PO Amount" />




                                        <asp:TemplateField HeaderText="PO">
                                            <ItemTemplate>

                                                <asp:LinkButton ID="lnkDownload" runat="server" CommandName="Download" CommandArgument='<%# Eval("PO_number") %>'>
                                                    View</asp:LinkButton>

                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Invoice">
                                            <ItemTemplate>
                                                <asp:UpdatePanel ID="UpdateAtt" runat="server">

                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="lnkVendorPOD" runat="server" CommandName="VIEWPOD" CommandArgument='<%# Eval("BIS_VendorImage") %>'>View Invoice</asp:LinkButton>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="lnkVendorPOD" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View Details" HeaderStyle-Width="5px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="linkView" runat="server" CommandName="View" CommandArgument='<%# Eval("bis_id") %>'>Details</asp:LinkButton>
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

        <div id="Div_View_PDF" runat="server" visible="false" class="modal fade" role="dialog" clientidmode="static">
            <div class="modal-dialog-scrollable" role="document">
                <!-- Modal content-->
                <div class="modal-content">

                    <div class="modal-header">
                        <h5 class="modal-title fw-bold" id="lblModalInvoiceDetailss">Invoice Attatchment : </h5>
                        <a href="#" style="text-decoration: none" aria-hidden="true" data-dismiss="modal" aria-label="Close">
                            <i class="fa fa-times fa-2x alert-danger" aria-hidden="true"></i>
                        </a>
                    </div>

                    <div class="modal-body">
                        <asp:Literal ID="lvPDF" runat="server" />
                    </div>

                    <div class="modal-footer">
                        <asp:Button ID="btnClosed" class="btn btn-danger" runat="server" Text="Close" OnClick="btnClosed_Click" />
                    </div>
                </div>
            </div>
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
