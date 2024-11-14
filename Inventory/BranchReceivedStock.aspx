<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BranchReceivedStock.aspx.cs" Inherits="Inventory_BranchReceivedStock" %>

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
            Goods Received Note (GRN)
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">

                <div class="row">
                    <div class="col-12">
                        <label for="Product" class="col-form-label bold">PO Number :</label>
                        <asp:DropDownList ID="ddlPONUMBER" runat="server" AutoPostBack="true" CssClass="form-control border border-dark" OnSelectedIndexChanged="ddlPONUMBER_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <hr />

                <div class="row">
                    <div class="col-12">
                        <asp:GridView ID="gvBranchRecStock" runat="server" CssClass="table table-bordered table-hover"
                            AutoGenerateColumns="False" GridLines="None" Font-Size="Medium" ForeColor="#333333" ShowFooter="True" Width="100%"
                            DataKeyNames="BIS_ID" OnRowCommand="gvBranchRecStock_RowCommand" OnRowDataBound="gvBranchRecStock_RowDataBound" CellPadding="4">

                            <AlternatingRowStyle BackColor="White" />
                            <Columns>


                                <asp:TemplateField HeaderText="View Details" HeaderStyle-Width="5px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkView" runat="server" CommandName="View" CommandArgument='<%# Eval("BIS_id") %>'>Details</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="PO Number">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPONum" runat="server" Text='<%#Eval("PO_number")%>' Font-Bold="true"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Product">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProduct" runat="server" Text='<%#Eval("Product")%>'></asp:Label>
                                        <asp:Label ID="lblProductID" runat="server" Text='<%#Eval("ProductID")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Vendor Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVMID" runat="server" Text='<%#Eval("VM_ID")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblVendorName" runat="server" Text='<%#Eval("VM_Name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Initiator Details">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInitiator" runat="server" Text='<%#Eval("BIS_insertDate")%>'></asp:Label>
                                        <br />
                                        <asp:Label ID="lblReqQty" runat="server" Text='<%#Eval("BIS_Quantity")%>' Font-Bold="true"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblInitiatorRemarks" runat="server" Text='<%#Eval("BIS_initiator_remarks")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Approval Details">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApprove" runat="server" Text='<%#Eval("BIS_POGeneratedOn")%>'></asp:Label>
                                        <br />
                                        <asp:Label ID="lblApproveQty" runat="server" Text='<%#Eval("BIS_approved_quantity")%>' Font-Bold="true"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblApprovalRemarks" runat="server" Text='<%#Eval("BIS_HO_Approved_Remarks")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Dispatched Details">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVendor" runat="server" Text='<%#Eval("BIS_vendorDate")%>'></asp:Label>
                                        <br />
                                        <asp:Label ID="lblVendorSendQty" runat="server" Text='<%#Eval("vendor_stock_quantity")%>' Font-Bold="true"></asp:Label>
                                        <asp:Label ID="lblVSendQty" runat="server" Text='<%#Eval("BIS_vendor_stock_quantity")%>' Font-Bold="true" Visible="false"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblVendorRemarks" runat="server" Text='<%#Eval("BIS_vendor_remarks")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Damaged Stock/Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="RemainingSsock" runat="server" Text='<%#Eval("DamageQuantity")%>'></asp:Label><br />
                                        <asp:Label ID="Rremarks" runat="server" Text='<%#Eval("bis_damageStock_Remarks")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Received Stock/Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="RecStock" runat="server" Text='<%#Eval("BIS_stock_received_quantity")%>'></asp:Label><br />
                                        <asp:Label ID="RecRemarks" runat="server" Text='<%#Eval("BIS_receiver_remarks")%>'></asp:Label><br />

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remaining Stock">
                                    <ItemTemplate>
                                        <asp:Label ID="lblremains" runat="server" Text='<%#Eval("Remainings")%>'></asp:Label><br />
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderText="Damaged Stock/Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="RemainingSsock" runat="server" Text='<%#Eval("DamageQuantity")%>'></asp:Label><br />
                                        <asp:Label ID="Rremarks" runat="server" Text='<%#Eval("bis_damageStock_Remarks")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Received Stock/Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="RecStock" runat="server" Text='<%#Eval("BIS_stock_received_quantity")%>'></asp:Label><br />
                                        <asp:Label ID="RecRemarks" runat="server" Text='<%#Eval("BIS_receiver_remarks")%>'></asp:Label><br />

                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="Received Quantity /Remarks">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control border border-dark" MaxLength="3" placeholder="Received Quantity" Width="180px" ValidationGroup="Branch"></asp:TextBox>

                                        <asp:RequiredFieldValidator ID="rfvQnty" runat="server" Enabled="false" ControlToValidate="txtQuantity" Font-Size="small" ForeColor="red" ErrorMessage="Quantity is required."
                                            Display="Dynamic" ValidationGroup="AXV"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control border border-dark" placeholder="Enter Remarks" Width="180px" TextMode="MultiLine" ValidationGroup="Branch"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="frvRmrks" runat="server"  Enabled="false"  ControlToValidate="txtRemarks" Font-Size="small" ForeColor="red" ErrorMessage="Remarks is required."
                                            Display="Dynamic" ValidationGroup="AXV"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:FileUpload ID="fupid" runat="server" CssClass="form-control border border-dark" AllowMultiple="true" ValidationGroup="Branch" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5"  Enabled="false"  runat="server" Font-Size="small" ControlToValidate="fupid" ErrorMessage="Kindly upload the PDF" ForeColor="red"
                                            Display="Dynamic" ValidationGroup="AXV"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Damage Quantity/Remarks">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtDamageQuantity" runat="server" CssClass="form-control border border-dark" MaxLength="3" placeholder="Damaged Quantity" Width="180px" ></asp:TextBox><br />
                                        <br />
                                        <asp:TextBox ID="txtDamageRemarks" runat="server" CssClass="form-control border border-dark" placeholder="Enter Remarks" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5px">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkAction" runat="server" AutoPostBack="true" OnCheckedChanged="chkAction_CheckedChanged1" />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:UpdatePanel ID="UpdatePO" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="lnkApprove" ForeColor="White" runat="server" CssClass="btn btn-sm btn-success"
                                                    ValidationGroup="AXV" CommandName="Submit" CommandArgument='<%# Eval("BIS_ID") %>'>Submit</asp:LinkButton>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="lnkApprove" />
                                                <%--<asp:AsyncPostBackTrigger ControlID="VendorApproval" EventName="RowCommand" />--%>
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
                    </table>

                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnClose" class="btn btn-danger" runat="server" Text="Close" OnClick="btnClose_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

