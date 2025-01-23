<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="COtransfer.aspx.cs" Inherits="COProcess_COtransfer" %>

<asp:Content ID="content" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Transer Users
        </div>
        <div class="card-body">
            <div class="form-control">

                <blockquote class="blockquote mb-0">
                    <div class="form-control">


                        <div class="row">
                            <div class="col-8" style="margin-bottom: 20px">
                                <label for="lblUCode" class="col-form-label bold">Enter User Code:</label>
                                <asp:TextBox ID="txtUCode" runat="server" CssClass="form-control" placeholder="Enter User Code"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvInvoiceNum" runat="server" ControlToValidate="txtUCode"
                                    ForeColor="red" ErrorMessage="User Code is required" Display="Dynamic"
                                    ValidationGroup="SearchVGroup"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-2" style="margin-top: 37px">
                                <label for="lblID" class="col-form-label bold" id="sd" runat="server" visible="false">Invoice No. : </label>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn text-white" BackColor="#3a4f63" ValidationGroup="SearchVGroup" OnClick="btnSearch_Click" />
                                &nbsp;
                                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-danger" Visible="true" OnClick="btnReset_Click" />

                            </div>

                        </div>
                    </div>
                </blockquote>


            </div>
            <br />

            <div class="row">
                <div class="col">

                    <asp:GridView ID="gvUsers" runat="server" CssClass="table table-bordered table-hover"
                        AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" ShowFooter="true" Width="100%"
                        Align="Center" OnRowCommand="gvUsers_RowCommand" OnRowDataBound="gvUsers_RowDataBound" DataKeyNames="ID">

                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="CLUSTER_ID" HeaderText="Region" />
                            <asp:BoundField DataField="Branch" HeaderText="Branch" />
                            <asp:BoundField DataField="UserCode" HeaderText="Emp. Code" />
                            <asp:BoundField DataField="UserName" HeaderText="Emp. Name" />
                            <asp:BoundField DataField="RoleName" HeaderText="Role" />
                            <asp:BoundField DataField="Mobile" HeaderText=" Contact No." />
                            <asp:BoundField DataField="Email" HeaderText="Email ID" />
                            <%--                         <asp:BoundField DataField="Branch" HeaderText="Branch" />--%>
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:TemplateField HeaderText="select Region/Branch">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlRegion" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" AutoPostBack="true" runat="server"  CssClass="form-control border border-dark" >
                                    </asp:DropDownList>
                                    <br />
                                    <asp:DropDownList ID="ddlBranch" runat="server" Enabled="true" CssClass="form-control border border-dark" AutoPostBack="true">
                                    </asp:DropDownList><br />
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkModify" runat="server" class="btn btn-danger bg-white text-danger" CommandName="ChangeStatus" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm (&quot;Are you sure want to Change this?? &quot;)">Update</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                          <%--  <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5px">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAction" runat="server" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="lnkApprove" ForeColor="White" runat="server" CssClass="btn btn-sm btn-success" ValidationGroup="Vendor" CommandName="Submit" CommandArgument='<%# Eval("ID") %>'>Approved</asp:LinkButton>
                                </FooterTemplate>
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
                </div>
            </div>
        </div>

    </div>
</asp:Content>
