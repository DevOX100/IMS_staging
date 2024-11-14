<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BranchMaster.aspx.cs" Inherits="Master_BranchMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">


    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Create Branch
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form-control ">
                            <div class="row">
                                <div class="col-6">
                                    <label for="lblBranchCode" class="col-form-label bold">Branch Code: <span style="color: red;" validationgroup="ABC">*</span></label>
                                    <asp:TextBox ID="txtBranchCode" runat="server" CssClass="form-control" MaxLength="5" TextMode="SingleLine" AutoPostBack="true" OnTextChanged="txtBranchCode_TextChanged" placeholder="Enter the branch code" ValidationGroup="ABC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfc3" runat="server" ControlToValidate="txtBranchCode"
                                        ErrorMessage="Kindly enter branch code" ForeColor="red" ToolTip="Branch COde is required"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-6">
                                    <label for="lblBranchName" class="col-form-label bold">Branch Name: <span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtBranchName" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the branch name" ValidationGroup="ABC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfc4" runat="server" ControlToValidate="txtBranchName"
                                        ErrorMessage="Kindly enter branch name" ForeColor="red" ToolTip="Branch Name is required"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                           
                            <div class="row">

                                <div class="col-6">
                                    <label for="lblRegion" class="col-form-label bold">Region <span style="color: red;">*</span></label>
                                    <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control" AutoPostBack="true"
                                        ValidationGroup="ABC">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rvf1" runat="server" ControlToValidate="ddlRegion"
                                        ErrorMessage="Kindly select the region" ForeColor="red" ToolTip="Region is required"
                                        Display="Dynamic" InitialValue="0" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-6">
                                    <label for="lblRegion" class="col-form-label bold">Address <span style="color: red;">*</span></label>
                                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="Enter the branch Address" ValidationGroup="ABC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAddress"
                                        ErrorMessage="Kindly enter the Address" ForeColor="red" ToolTip="Address is required"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                            <br />
                            <div class="row">
                                <div class="form-group">
                                    <div class="row text-center">
                                        <div class="col-12">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn text-white" BackColor="#3a4f63" OnClick="btnSubmit_Click" ValidationGroup="ABC" />
                                            <asp:Button ID="btnClear" runat="server" Text="Reset" CssClass="btn text-white" BackColor="red" OnClick="btnClear_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            </div>
                        <!-- ValidationGroup="" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" OnTextChanged="txtDateOfInvoice_TextChanged"-->
                
            </blockquote>
        </div>
        <br />

        <div class="row">
            <div class="col">
                <asp:Panel runat="server" frameborder="0" ScrollBars="Both" Align="Center">
                    <asp:GridView ID="BranchGrid" runat="server" CssClass="table table-bordered table-hover"
                        AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" ShowFooter="true" Width="100%" OnRowCommand="BranchGrid_RowCommand">

                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="SrNo" HeaderText="Sr. No." />
                            <asp:BoundField DataField="BranchCode" HeaderText="Branch Code" />
                            <asp:BoundField DataField="BranchName" HeaderText="Branch Name" />
                            <%--<asp:BoundField DataField="Hierarchy_Type" HeaderText="Hierarchy Type" />--%>
                            <asp:BoundField DataField="IsActive" HeaderText="IsActive" />
                            <asp:BoundField DataField="R_Name" HeaderText="Region Code" />

                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkModify" runat="server" class="btn btn-danger bg-white text-danger" CommandName="ChangeStatus" CommandArgument='<%# Eval("BranchID") %>' Text='<%# Eval("Visible") %>' OnClientClick="return confirm (&quot;Are you sure want to Change this?? &quot;)"></asp:LinkButton>

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
</asp:Content>

