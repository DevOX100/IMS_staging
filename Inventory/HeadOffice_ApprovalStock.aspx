<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HeadOffice_ApprovalStock.aspx.cs" Inherits="Inventory_HeadOffice_ApprovalStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <script type="text/javascript">
        function SelectAllCheckboxes(chkAll) {
            var grid = document.getElementById('<%= gvHOApproval.ClientID%>');
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

    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            RM Stock Verification
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">

                <div class="form-control border border-dark ">
                    <div class="row">

                        <%--                        <div class="col-6">
                            <label for="Region" class="col-form-label bold">Region : <span style="color: red">*</span></label>
                            <asp:DropDownList ID="ddlRegion" runat="server" Enabled="true" CssClass="form-control border border-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>--%>
                        <div class="col-6">
                            <label for="Branch" class="col-form-label bold">Branch : <span style="color: red">*</span></label>
                            <asp:DropDownList ID="ddlBranch" runat="server" Enabled="true" CssClass="form-control border border-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <br />

                </div>


                <hr />
                <div class="row">
                    <div class="col-12">




                        <asp:GridView ID="gvHOApproval" runat="server" CssClass="table table-bordered table-hover"
                            AutoGenerateColumns="False" GridLines="None" Font-Size="Medium" ForeColor="#333333" ShowFooter="true" Width="100%"
                            DataKeyNames="BIS_id" OnRowCommand="gvHOApproval_RowCommand" OnRowDataBound="gvHOApproval_RowDataBound">

                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>

                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5px">

                                    <HeaderTemplate>
                                        <asp:Label ID="lblSelectALL" runat="server" Text="Select All"></asp:Label>
                                        <asp:CheckBox ID="chkSelectAll" runat="server" onclick="SelectAllCheckboxes(this);" />

                                    </HeaderTemplate>


                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkAction" runat="server" AutoPostBack="true" OnCheckedChanged="chkAction_CheckedChanged" />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="lnkApprove" ForeColor="White" runat="server" CssClass="btn btn-sm btn-success"
                                            ValidationGroup="HOAPR" CommandName="Submit" CommandArgument='<%# Eval("BIS_id") %>'>Submit</asp:LinkButton>

                                         <asp:LinkButton ID="LinkButton1" style="margin-top: 20px" ForeColor="White" runat="server" CssClass="btn btn-sm btn-success"
ValidationGroup="HOAPR" CommandName="delete" CommandArgument='<%# Eval("BIS_id") %>'>Delete</asp:LinkButton>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="CLUSTER_ID" HeaderText="Region" />
                                <asp:BoundField DataField="BIS_branchID" HeaderText="Branch" />
                                <asp:BoundField DataField="VM_Name" HeaderText="Vendor Name" />
                                <%--<asp:BoundField DataField="PM_ItemCode2" HeaderText="Product" />--%>
                                <%--<asp:BoundField DataField="BIS_insertDate" HeaderText="Stock Request Date" />--%>

                                <asp:TemplateField HeaderText="Product">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDes1" runat="server" Text='<%#Eval("PM_Description1")%>'></asp:Label>
                                        (<asp:Label ID="lblDes2" runat="server" Text='<%#Eval("PM_ItemCode2")%>'></asp:Label>)
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--                           <asp:BoundField DataField="PM_Description1" HeaderText="Description 1" />
                                <asp:BoundField DataField="PM_Description2" HeaderText="Description 2" />--%>
                                <asp:BoundField DataField="out_stock" HeaderText="Handover Stock(Last 30 days)" />
                                <asp:BoundField DataField="available_stock" HeaderText="Available Stock" />

                                <asp:TemplateField HeaderText="Requested Stock/Date/Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReqQty" runat="server" Text='<%#Eval("BIS_Quantity")%>' Font-Bold="true"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblRequestDate" runat="server" Text='<%#Eval("BIS_insertDate")%>'></asp:Label>
                                        <br />
                                        <asp:Label ID="lblRequestorRemarks" runat="server" Text='<%#Eval("BIS_initiator_remarks")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="BIS_initiator_remarks" HeaderText="Initiator Remarks" />--%>


                                <%--                                <asp:TemplateField HeaderText="CPP Stock Acceptance/Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCPPApproveQuantity" runat="server" Text='<%#Eval("BIS_CPP_Approved_Quantity")%>' Font-Bold="true"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblCPPApproveRemarks" runat="server" Text='<%#Eval("BIS_CPP_Approved_Remarks")%>'></asp:Label>
                                        <br />
                                        <asp:Label ID="lblCPPApproveDate" runat="server" Text='<%#Eval("BIS_CPP_Approved_Date")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="Stock Acceptance">
                                    <ItemTemplate>
                                        </br>
                                        <asp:TextBox ID="txtQuantityHOAP" runat="server" CssClass="form-control border border-dark" Text='<%# Bind("BIS_Quantity") %>' Width="180px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtQuantityHOAP" FilterType="Numbers"
                                            ValidChars="0123456789" />
                                        <asp:RequiredFieldValidator ID="rfvQuantyHOAP" Enabled="false" runat="server" ControlToValidate="txtQuantityHOAP" Font-Size="small"
                                            ForeColor="red" ErrorMessage="Quantity is required." Display="Dynamic" ValidationGroup="HOAPR" Font-Bold="true"></asp:RequiredFieldValidator>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        </br>
                                        <asp:TextBox ID="txtRemarksHOAP" runat="server" CssClass="form-control border border-dark" Width="180px" TextMode="MultiLine">

                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvRemarksHOAP" runat="server" ControlToValidate="txtRemarksHOAP" Font-Size="small" ForeColor="red"
                                            ErrorMessage="Remarks is required." Display="Dynamic" Enabled="false" ValidationGroup="HOAPR" Font-Bold="true"></asp:RequiredFieldValidator>
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
            </blockquote>
        </div>
    </div>

</asp:Content>

