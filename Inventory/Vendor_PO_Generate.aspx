<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Vendor_PO_Generate.aspx.cs" Inherits="Inventory_Vendor_PO_Generate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">


    <script type="text/javascript">
        function SelectAllCheckboxes(chkAll) {
            var grid = document.getElementById('<%= gvPOGenerate.ClientID%>');
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    inputs[i].checked = chkAll.checked;
                }
            }
        }

    </script>


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
            PO Generation
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">

                <div class="form-control border border-dark ">
                    <div class="row">
                        <div class="col-3">
                            <label for="Region" class="col-form-label bold">Region : <span style="color: red">*</span></label>
                            <asp:DropDownList ID="ddlRegion" runat="server" Enabled="true" CssClass="form-control border border-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-3">
                            <label for="Branch" class="col-form-label bold">Branch : <span style="color: red">*</span></label>
                            <asp:DropDownList ID="ddlBranch" runat="server" Enabled="true" CssClass="form-control border border-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlBranch" ErrorMessage="Kindly choose Branch"
                                ForeColor="red" Display="Dynamic" ValidationGroup="XCV" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-3">
                            <label for="Vendor" class="col-form-label bold">Vendor : <span style="color: red">*</span></label>
                            <asp:DropDownList ID="ddlVendorID" runat="server" Enabled="true" CssClass="form-control border border-dark">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlVendorID" ErrorMessage="Kindly choose Vendor"
                                ForeColor="red" Display="Dynamic" ValidationGroup="XCV" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>

                        <%-- <div class="col-3">
                            <label for="Branch" class="col-form-label bold">PO Delivery Date : <span style="color: red">*</span></label>
                            <asp:TextBox ID="txtpoDelDate" runat="server" TextMode="Date" CssClass="form-control border border-dark"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpoDelDate" ErrorMessage="Kindly choose PO Delivery Date"
                                ForeColor="red" Display="Dynamic" ValidationGroup="XCV"></asp:RequiredFieldValidator>
                        </div>--%>

                        <div class="col-2" style="margin-top: 40px">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="XCV" />
                        </div>
                    </div>

                    <br />
                    <hr />
                </div>

                <div class="row">
                    <div class="col-12">




                        <asp:GridView ID="gvPOGenerate" runat="server" CssClass="table table-bordered table-hover"
                            AutoGenerateColumns="False" GridLines="None" Font-Size="Medium" ForeColor="#333333" ShowFooter="true" Width="100%"
                            DataKeyNames="BIS_id" OnRowCommand="gvPOGenerate_RowCommand" OnRowDataBound="gvPOGenerate_RowDataBound">

                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>

                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5px">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblSelectALL" runat="server" Text="Select All"></asp:Label>
                                        <asp:CheckBox ID="chkSelectAll" runat="server" onclick="SelectAllCheckboxes(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkAction" runat="server" />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="lnkApprove" ForeColor="White" runat="server" CssClass="btn btn-sm btn-success"
                                            ValidationGroup="validation" CommandName="Submit" CommandArgument='<%# Eval("BIS_id") %>'>PO Generate</asp:LinkButton>

<asp:LinkButton ID="LinkButton1" style="margin-top: 20px" ForeColor="White" runat="server" CssClass="btn btn-sm btn-success"
ValidationGroup="HOAPR" CommandName="delete" CommandArgument='<%# Eval("BIS_id") %>'>Delete</asp:LinkButton>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <%--                                <asp:TemplateField HeaderText="BIS ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBISID" runat="server" Text='<%#Eval("BIS_ID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>



                                <asp:TemplateField HeaderText="Branch Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranchID" runat="server" Text='<%#Eval("BIS_branchID")%>'></asp:Label>
                                        <asp:Label ID="lblBranch" Visible="false" runat="server" Text='<%#Eval("branchID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Vendor Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVendorName" runat="server" Text='<%#Eval("VM_Name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--       <asp:BoundField DataField="BIS_insertDate" HeaderText="Branch Request Date" />--%>
                                <%-- <asp:BoundField DataField="PM_ItemCode2" HeaderText="Product" />--%>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDes1" runat="server" Text='<%#Eval("PM_Description1")%>'></asp:Label>
                                        <%--  <br />
                                        <asp:Label ID="lblDes2" runat="server" Text='<%#Eval("PM_Description2")%>'></asp:Label>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--<asp:TemplateField HeaderText="Requested Stock/Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRequestedQuantity" runat="server" Text='<%#Eval("BIS_Quantity")%>' Font-Bold="true"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblRequestorRemarks" runat="server" Text='<%#Eval("BIS_initiator_remarks")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="RM Stock Acceptance/Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStockAcceptance" runat="server" Text='<%#Eval("BIS_approved_quantity")%>' Font-Bold="true"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblAcceptorRemarks" runat="server" Text='<%#Eval("BIS_approved_remarks")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CPP(RO) Quantity/Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCppQuantity" runat="server" Font-Bold="true" Text='<%#Eval("BIS_CPP_approved_quantity") %>'></asp:Label>
                                        <br />
                                        <asp:Label ID="lblcppRemarks" runat="server" Text='<%#Eval("BIS_CPP_Approved_Remarks") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>


                              <asp:TemplateField HeaderText="Final Quantity/Remarks">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQuantity" runat="server" AutoPostBack="true" CssClass="form-control border border-dark" placeholder="Enter Quantity" MaxLength="3" Width="180px" ValidationGroup="validation" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox>
                                         <asp:Label ID="CppQuantity" runat="server" Visible="false" Font-Bold="true" Text='<%#Eval("BIS_CPP_approved_quantity") %>'></asp:Label>
                                        <br />
                                        <asp:TextBox ID="txtRemarks" CssClass="form-control border border-dark" runat="server" placeholder="Enter Remarks" Width="180px" ValidationGroup="validation"></asp:TextBox>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Unit Price">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnitPrice" runat="server" Text='<%#Eval("PM_UnitPrice")%>'></asp:Label>
                                           <asp:Label ID="lblPreviousFinalQuantity" runat="server" Visible="false" Font-Bold="true" Text='<%#Eval("BIS_CPP_approved_quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="PO Amount" HeaderStyle-Width="5px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPOAmt" runat="server" Text='<%#Eval("POAmount")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblSumPOAmt" runat="server"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Unit Of Product" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductUnit" runat="server" Text='<%#Eval("PM_UnitOfMeasurement")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                              <asp:TemplateField HeaderText="View Details" HeaderStyle-Width="5px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkView" runat="server" CommandName="View" CommandArgument='<%# Eval("BIS_id") %>'>Details</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>                        </Columns>

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

