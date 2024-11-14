<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HOD_POApproval.aspx.cs" Inherits="Inventory_HOD_POApproval" %>

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
    <style type="text/css">
        .successColor {
            background-color: #1fa756;
            border: medium none;
            color: White;
        }

        .defaultColor {
            background-color: white;
            color: black;
        }
    </style>

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
            HOD Approval
        </div>

        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form-control">

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
                            <label class="col-form-label bold">From Date :</label>
                            <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>

                        </div>

                        <div class="col-3">
                            <label class="col-form-label bold">To Date :</label>
                            <asp:TextBox ID="txtToDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>

                        </div>
                        <div class="col-1" style="margin-top: 40px">
                            <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-success" BackColor="#3a4f63" OnClick="btnSearch_Click" />
                        </div>--%>


                        <div class="col-3">
                            <label class="col-form-label bold">Select PO : </label>

                            <asp:DropDownList ID="ddlPONUMBER" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlPONUMBER_SelectedIndexChanged">
                                <asp:ListItem Text="All PO" Value="0" />
                            </asp:DropDownList>

                        </div>
                    </div>
                    <hr />

                    <div class="row">
                        <div class="col">

                            <asp:Panel runat="server" frameborder="0" ScrollBars="Both" Align="Center">




                                <asp:GridView ID="gvApproval" runat="server" CssClass="table table-bordered table-hover"
                                    AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" ShowFooter="true" Width="100%"
                                    DataKeyNames="BIS_id" OnRowCommand="gvApproval_RowCommand" OnRowDataBound="gvApproval_RowDataBound">

                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>



                                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5px">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblSelectALL" runat="server" Text="Select All"></asp:Label>
                                                <asp:CheckBox ID="chkSelectAll" runat="server" onclick="SelectAllCheckboxes(this);" />

                                            </HeaderTemplate>
                                            <ItemTemplate>

                                                <asp:HiddenField ID="hfPONumber" runat="server" Value='<%# Eval("PO_number") %>' />

                                                <asp:CheckBox ID="chkAction" runat="server" />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:LinkButton ID="lnkApprove" ForeColor="White" runat="server" CssClass="btn btn-sm btn-success" ValidationGroup="validation" CommandName="Submit" CommandArgument='<%# Eval("BIS_ID") %>'>Approved</asp:LinkButton>
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Remarks">
                                            <ItemTemplate>
                                                </br>
           <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" Width="180px" TextMode="MultiLine" ValidationGroup="validation"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ers" runat="server" Enabled="false" ControlToValidate="txtRemarks" Font-Size="small" ForeColor="red" ErrorMessage="Remarks is required." Display="Dynamic" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>




                                        <asp:TemplateField HeaderText="Branch">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBranchID" Visible="false" runat="server" Text='<%#Eval("BRANCH_ID") %>'></asp:Label>
                                                <asp:Label ID="lblBranchName" runat="server" Text='<%#Eval("BRANCH_NAME") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Vendor">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVendorID" Visible="false" runat="server" Text='<%#Eval("VM_VendorCode") %>'></asp:Label>
                                                <asp:Label ID="lblVendorName" runat="server" Text='<%#Eval("PO_VendorCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product/Category">
                                            <ItemTemplate>
                                                <%-- <asp:Label ID="lblProductID" runat="server" Text='<%#Eval("BIS_productID") %>' Font-Bold="true"></asp:Label><br />--%>
                                                <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("PM_Category") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldescription1" runat="server" Text='<%#Eval("PM_Description1") %>'></asp:Label><br />

                                            </ItemTemplate>
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderText="Unit Price">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnitPrice" runat="server" Text='<%#Eval("PM_UnitPrice") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="po_amount" HeaderText="PO Amount" />
                                        <asp:BoundField DataField="PO_number" HeaderText="PO Number" />

                                        <asp:TemplateField HeaderText="Approval Details">
                                            <ItemTemplate>
                                              <%--  <asp:Label ID="lblApprove" runat="server" Text='<%#Eval("BIS_POGeneratedOn")%>'></asp:Label>
                                                <br />--%>
                                                <asp:Label ID="lblApproveQty" runat="server" Text='<%#Eval("BIS_HO_approved_quantity")%>' Font-Bold="true"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblApprovalRemarks" runat="server" Text='<%#Eval("BIS_HO_Approved_Remarks")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                        <%--                                        <asp:TemplateField HeaderText="MRP Price">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMRPPrice" runat="server" Text='<%#Eval("PM_MRPPrice") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <%-- <asp:TemplateField HeaderText="Delivery Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDeliveryDate" runat="server" Text='<%#Eval("Delivery_Date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="PO">
                                            <ItemTemplate>

                                                <asp:LinkButton ID="lnkDownload" runat="server" CommandName="Download" CommandArgument='<%# Eval("PO_number") %>'>View</asp:LinkButton>

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

