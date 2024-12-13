<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="VendorCPPEscalations.aspx.cs" Inherits="CPPEscalations_VendorCPPEscalations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">


    <script type="text/javascript">
        function SelectAllCheckboxes(chkAll) {
            var grid = document.getElementById('<%= GVEscalations.ClientID%>');
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    inputs[i].checked = chkAll.checked;
                }
            }
        }

    </script>
    <script type="text/javascript">
        function SelectAllCheckboxes(chkAll) {
            var grid = document.getElementById('<%= GVConfirmEscalation.ClientID%>');
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
            Vendor Escalation Proccess
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">

                <div class="form-control border border-dark ">
                    <div class="row">
                        <div class="col-6">
                            <label id="Region" class="col-form-label bold">Region :</label>
                            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control border border-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-6">
                            <label id="lblBranch" class="col-form-label bold">Branch:</label>
                            <asp:DropDownList ID="ddlBranch" CssClass="form-control border border-dark" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <br />
                    <hr />
                </div>
                <div class="row">
                    <div class="col-12">


                        <asp:GridView ID="GVEscalations" runat="server" CssClass="table table-bordered table-hover"
                            AutoGenerateColumns="False" GridLines="None" Font-Size="Medium" ForeColor="#333333" ShowFooter="true" Width="100%"
                            DataKeyNames="Em_IssueID" OnRowCommand="GVEscalations_RowCommand" OnRowDataBound="GVEscalations_RowDataBound">

                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>

                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5px">

                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkAction" runat="server" AutoPostBack="true" OnCheckedChanged="chkAction_CheckedChanged" />
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Branch">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranchID" runat="server" Text='<%#Eval("EM_DamageProduct_ReceivedBY")%>'></asp:Label>



                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomerID" runat="server" Text='<%#Eval("em_CustID")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("EM_Name")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Spouse Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSpouseName" runat="server" Text='<%#Eval("EM_SpouseName")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Product Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductType" runat="server" Text='<%#Eval("EM_Damage_Product_Type")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Product">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("EM_Damage_Product_Name")%>'></asp:Label>
                                        <asp:Label ID="lblProduct" Visible="false" runat="server" Text='<%#Eval("EM_ProductID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Complaint">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductComplaint" runat="server" Text='<%#Eval("EM_Damage_ProductComplaint")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Complaint Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblComplaintDate" runat="server" Text='<%#Eval("EM_Damage_ProductComplaint_date")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("EM_Damage_stock_Quantity")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Confirmation">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkApprove" Style="background-color: green; text-decoration: none;" ForeColor="White" AutoPostBack="true" runat="server" CssClass="form-control border border-dark"
                                            ValidationGroup="ABC" CommandName="Submit" CommandArgument='<%# Eval("Em_IssueID") %>'>Confirm</asp:LinkButton>
                                        <br />
                                        <asp:LinkButton ID="LinkButton1" Style="margin-top: 20px; background-color: green; text-decoration: none;" AutoPostBack="true" ForeColor="White" runat="server" CssClass="form-control border border-dark"
                                            ValidationGroup="ABC" CommandName="delete" CommandArgument='<%# Eval("Em_IssueID") %>'>Reject</asp:LinkButton>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks/Expected Closure Date/Complaint">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlComplaintsbyVendor" Style="margin-top: 10px" AutoPostBack="true" runat="server" CssClass="form-control border border-dark" OnSelectedIndexChanged="ddlComplaintsbyVendor_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text="Kindly Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="OTP Shared by Branch side"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Physically Damage"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Out of Warranty"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Connectivity Issue With Branch"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="Escalating to Technician"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvComplaint" Enabled="false" runat="server" ControlToValidate="ddlComplaintsbyVendor" ErrorMessage="Kindly select" ForeColor="red"
                                            Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:TextBox ID="txtUpperRemarks" runat="server" CssClass="form-control border border-dark" placeholder="Enter Remarks" Width="180px" ValidationGroup="ABC"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvUpperRemarks" Enabled="false" runat="server" ControlToValidate="txtUpperRemarks" ErrorMessage="Kindly provide Remarks" ForeColor="red"
                                            Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>


                                        <asp:TextBox ID="txtExpectedClosureDate" Style="margin-top: 10px" runat="server" CssClass="form-control border border-dark" placeholder="Enter Warranty Date" TextMode="Date" Width="180px" ValidationGroup="ABC"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvWarrantydate" Enabled="false" runat="server" ControlToValidate="txtExpectedClosureDate" Font-Size="small"
                                            ForeColor="red" ErrorMessage="Expected CLosure date is required date is required." Display="Dynamic" ValidationGroup="ABC" Font-Bold="true"></asp:RequiredFieldValidator>

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
                <br />
                <hr />
                <div class="row">
                    <div class="col-12">
                        <asp:GridView ID="GVConfirmEscalation" runat="server" CssClass="table table-bordered table-hover"
                            AutoGenerateColumns="False" GridLines="None" Font-Size="Medium" ForeColor="#333333" ShowFooter="true" Width="100%"
                            DataKeyNames="Em_IssueID" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">

                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>


                                <asp:TemplateField HeaderText="Branch">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranchID" runat="server" Text='<%#Eval("EM_DamageProduct_ReceivedBY")%>'></asp:Label>
                                        <asp:Label ID="lblStatus" Visible="false" runat="server" Text='<%#Eval("EM_Status")%>'></asp:Label>
                                        <asp:Label ID="lblTechVisit" Visible="false" runat="server" Text='<%#Eval("EM_TechnicianVisit")%>'></asp:Label>
                                        <asp:Label ID="lblClosureType" Visible="false" runat="server" Text='<%#Eval("EM_VendorclosureType")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomerID" runat="server" Text='<%#Eval("em_CustID")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("EM_Name")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Spouse Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSpouseName" runat="server" Text='<%#Eval("EM_SpouseName")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Product Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductType" runat="server" Text='<%#Eval("EM_Damage_Product_Type")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Product">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("EM_Damage_Product_Name")%>'></asp:Label>
                                        <asp:Label ID="lblProduct" Visible="false" runat="server" Text='<%#Eval("EM_ProductID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Complaint">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductComplaint" runat="server" Text='<%#Eval("EM_Damage_ProductComplaint")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Complaint Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblComplaintDate" runat="server" Text='<%#Eval("EM_Damage_ProductComplaint_date")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("EM_Damage_stock_Quantity")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Technician Visit">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlTechVisit" runat="server" AutoPostBack="true" CssClass="form-control border border-dark" ValidationGroup="ABC">
                                            <asp:ListItem Value="0" Text="Select">
                                            </asp:ListItem>
                                            <asp:ListItem Value="1" Text="Yes">
                                            </asp:ListItem>
                                            <asp:ListItem Value="2" Text="No">
                                            </asp:ListItem>

                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvTechVisit" Enabled="false" runat="server" ControlToValidate="ddlTechVisit" ErrorMessage="Kindly select" ForeColor="red"
                                            Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" CssClass="form-control border border-dark" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" ValidationGroup="ABC">
                                            <asp:ListItem Value="0" Text="Select">
                                            </asp:ListItem>
                                            <asp:ListItem Value="1" Text="Open">
                                            </asp:ListItem>
                                            <asp:ListItem Value="2" Text="Closed">
                                            </asp:ListItem>
                                            <asp:ListItem Value="3" Text="Pending">
                                            </asp:ListItem>
                                            <asp:ListItem Value="4" Text="In process">
                                            </asp:ListItem>

                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvStatus" Enabled="false" runat="server" ControlToValidate="ddlStatus" ErrorMessage="Kindly select" ForeColor="red"
                                            Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:DropDownList ID="ddlCLosure" runat="server" AutoPostBack="true" CssClass="form-control border border-dark" ValidationGroup="ABC">
                                            <asp:ListItem Value="0" Text="Select Closure Type">
                                            </asp:ListItem>
                                            <asp:ListItem Value="1" Text="Repaired">
                                            </asp:ListItem>
                                            <asp:ListItem Value="2" Text="Replaced">
                                            </asp:ListItem>

                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvCLosure" Enabled="false" runat="server" ControlToValidate="ddlCLosure" ErrorMessage="Kindly select" ForeColor="red"
                                            Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRemarks" AutoPostBack="true" runat="server" CssClass="form-control border border-dark" placeholder="Enter Remarks" Width="180px" ValidationGroup="ABC"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvRemarks" Enabled="false" runat="server" ControlToValidate="txtRemarks" ErrorMessage="Kindly provide Remarks" ForeColor="red"
                                            Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5px">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblSelectALL" runat="server" Text="Select All"></asp:Label>
                                        <asp:CheckBox ID="chkSelectAll" runat="server" onclick="SelectAllCheckboxes(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkAction" runat="server" AutoPostBack="true" OnCheckedChanged="chkAction_CheckedChanged1" />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="lnkApprove" ForeColor="White" AutoPostBack="true" runat="server" CssClass="btn btn-sm btn-success"
                                            ValidationGroup="ABC" CommandName="Submit" CommandArgument='<%# Eval("Em_IssueID") %>'>Approve</asp:LinkButton>


                                    </FooterTemplate>
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
