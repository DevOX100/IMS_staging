<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CPPEscalationsHO.aspx.cs" Inherits="CPPEscalations_CPPEscalationsHO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function SelectAllCheckboxes(chkAll) {
            var grid = document.getElementById('<%= GVEscalations.ClientID%>');
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox" && inputs[i].id.indexOf("chkSelectAll") == -1) {
                    inputs[i].checked = chkAll.checked;
                }
            }
        }
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
    <style>
    


    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            HO Escalation Process
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form-control border border-dark">
                    <div class="row">
                        <div class="col-6">
                            <label id="Region" class="col-form-label bold">Region :</label>
                            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control border border-dark"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-6">
                            <label id="lblBranch" class="col-form-label bold">Branch:</label>
                            <asp:DropDownList ID="ddlBranch" CssClass="form-control border border-dark"
                                runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <hr />
                </div>
            </blockquote>

            <asp:GridView ID="GVEscalations" runat="server"
                CssClass="table table-bordered table-hover"
                AutoGenerateColumns="False"
                GridLines="None"
                Font-Size="Medium"
                ForeColor="#333333"
                ShowFooter="true"
                Width="100%"
                DataKeyNames="Issued_ID"
                OnRowCommand="GVEscalations_RowCommand"
                OnRowDataBound="GVEscalations_RowDataBound">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5px">
                        <HeaderTemplate>
                            <asp:Label ID="lblSelectALL" runat="server" Text="Select All"></asp:Label>
                            <asp:CheckBox ID="chkSelectAll" runat="server" onclick="SelectAllCheckboxes(this);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkAction" runat="server" AutoPostBack="true"
                                OnCheckedChanged="chkAction_CheckedChanged" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="lnkApprove"
                                ForeColor="White"
                                runat="server"
                                CssClass="btn btn-sm btn-success"
                                ValidationGroup="ABC"
                                CommandName="Submit">Approve</asp:LinkButton>

                            <asp:LinkButton ID="lnkReject"
                                Style="margin-top: 20px"
                                ForeColor="White"
                                runat="server"
                                CssClass="btn btn-sm btn-danger"
                                ValidationGroup="ABC"
                                CommandName="Reject">Reject</asp:LinkButton>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Customer ID">
                        <ItemTemplate>
                            <asp:Label ID="lblCustID" runat="server" Text='<%#Eval("IS_CustID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Customer Name">
                        <ItemTemplate>
                            <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("IS_Name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Loan ID">
                        <ItemTemplate>
                            <asp:Label ID="lblLoandID" runat="server" Text='<%#Eval("IS_LoanID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Spouse Name">
                        <ItemTemplate>
                            <asp:Label ID="lblSpouseName" runat="server" Text='<%#Eval("IS_SpouseName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Mobile Number">
                        <ItemTemplate>
                            <asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("IS_MobileNO")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Branch">
                        <ItemTemplate>
                            <asp:Label ID="lblBranchID" runat="server" Text='<%#Eval("Is_DamageProduct_ReceivedBY")%>'></asp:Label>
                            <asp:Label ID="lblBrnach" Visible="false" runat="server" Text='<%#Eval("IS_Branch") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("IS_Damage_stock_Quantity")%>'></asp:Label>
                            <asp:Label ID="CppQuantity" Visible="false" runat="server" Text='<%#Eval("IS_Damage_stock_Quantity")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Product Type">
                        <ItemTemplate>
                            <asp:Label ID="lblProductType" runat="server" Text='<%#Eval("IS_Damage_Product_Type")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Product">
                        <ItemTemplate>
                            <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("IS_Damage_Product_Name")%>'></asp:Label>
                            <asp:Label ID="lblProduct" Visible="false" runat="server" Text='<%#Eval("IS_Product")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Product Complaint">
                        <ItemTemplate>
                            <asp:Label ID="lblProductComplaint" runat="server" Text='<%#Eval("IS_Damage_ProductComplaint")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Product Complaint Date">
                        <ItemTemplate>
                            <asp:Label ID="lblComplaintDate" runat="server" Text='<%#Eval("IS_Damage_ProductComplaint_date")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Product Availability in Branch">
                        <ItemTemplate>
                            <asp:Label ID="AvailabilityInBranch" runat="server" Text='<%#Eval("IS_AvailableStockInBranch")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product Warranty Date">
                        <ItemTemplate>
                            <asp:Label ID="WarrantyDate" runat="server" Text='<%#Eval("IS_WarrantyDate")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product Handover Date">
                        <ItemTemplate>
                            <asp:Label ID="HandoverDate" runat="server" Text='<%#Eval("HandoverDate")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="View Damage Image">
                        <ItemTemplate>
                            <asp:UpdatePanel ID="UpdateAtt" runat="server">

                                <ContentTemplate>
                                    <asp:LinkButton ID="lnkDamagedImage" runat="server" CommandName="VIEWDamagedImage" CommandArgument='<%# Eval("IS_Damage_Image") %>'>View</asp:LinkButton>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="lnkDamagedImage" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlComplaintsbyHO" runat="server" CssClass="form-control border border-dark">
                                <asp:ListItem Value="0" Text="Kindly Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Physical damage"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Out of warranty"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Water Damage product"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Product is not Available"></asp:ListItem>
                                <asp:ListItem Value="5" Text="Escalating to vendor"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvComplaintType"
                                Enabled="false"
                                runat="server"
                                ControlToValidate="ddlComplaintsbyHO"
                                ErrorMessage="Kindly select the Complaint"
                                ForeColor="red"
                                Display="Dynamic"
                                ValidationGroup="ABC"
                                InitialValue="0"></asp:RequiredFieldValidator>
                            <br />
                            <asp:TextBox ID="txtRemarks"
                                CssClass="form-control border border-dark"
                                runat="server"
                                placeholder="Enter Remarks"
                                Width="100px"
                                ValidationGroup="validation"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRemarks"
                                Enabled="false"
                                runat="server"
                                ControlToValidate="txtRemarks"
                                ErrorMessage="Remarks Required"
                                ForeColor="red"
                                Display="Dynamic"
                                ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
        </div>
    </div>
    <div id="Div_View_Image" runat="server" visible="false" class="modal fade" role="dialog" clientidmode="static">
        <div class="modal-dialog-scrollable" role="document">
            <!-- Modal content-->
            <div class="modal-content">

                <div class="modal-header">
                    <h5 class="modal-title fw-bold" id="lblModalInvoiceDetailss">Image Attatchment : </h5>
                    <a href="#" style="text-decoration: none" aria-hidden="true" data-dismiss="modal" aria-label="Close">
                        <i class="fa fa-times fa-2x alert-danger" aria-hidden="true"></i>
                    </a>
                </div>

                <div class="modal-body">
                    <asp:Literal ID="lvImage" runat="server" />
                </div>

                <div class="modal-footer">
                    <asp:Button ID="btnClosed" class="btn btn-danger" runat="server" Text="Close" OnClick="btnClosed_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
