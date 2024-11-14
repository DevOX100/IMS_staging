<%@ Page Title="Menu Rights" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MenuItemRights.aspx.cs" Inherits="Administration_MenuItemRights" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link rel="stylesheet" href="http://yui.yahooapis.com/pure/0.6.0/pure-min.css" />
    <script type="text/javascript">
        function FinalClicking(sender, args) {
            args.set_cancel(!window.confirm("Do you really want to delete selected item(s)?"));
        }

        function successalert() {
            swal({
                title: "User Role Changed!!",
                text: "Please Re-Assign Correct Menu to User.",
                type: "success",
                showConfirmButton: true
            });
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color:#3a4f63">
            Assign Menu Permission
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form-control">

                     <div class="row">
                        <div class="col-6">
                                    <label for="lblDepartment" class="col-form-label bold">Department : </label>
                                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control" ValidationGroup="AddInvoiceValidationGroup" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ControlToValidate="ddlDepartment" ErrorMessage="Please Select Department" ForeColor="red" ToolTip="Departments is required" ValidationGroup="AddInvoiceValidationGroup" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>

                         <div class="col-6">
                            <label for="lblRole" class="col-form-label bold">Role Name : </label>
                            <asp:DropDownList ID="ddlRoleName" runat="server" Enabled="false" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlRoleName_SelectedIndexChanged"></asp:DropDownList>
                            <asp:Button ID="btnAddRole" runat="server" CssClass="btn btn-sm text-white" BackColor="#3a4f63" OnClick="btnAddRole_Click" Text="Add Role"></asp:Button>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" CssClass="failureNotification"
                                ValidationGroup="Save" ControlToValidate="ddlRoleName" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>
                         </div>

                    <div class="row">
                       
                          <div class="col-6">
                            <label for="lblMenu" class="col-form-label bold">User Name :</label>
                            <asp:DropDownList ID="ddlUser" runat="server" CssClass="form-control" Enabled="false" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" CssClass="failureNotification"
                                ValidationGroup="Save" ControlToValidate="ddlUser" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-6">
                            <label for="lblMenu" class="col-form-label bold">Parent Menu :</label>
                            <asp:DropDownList ID="ddlMenuType" runat="server" Enabled="false" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlMenuType_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" CssClass="failureNotification"
                                ValidationGroup="Save" ControlToValidate="ddlMenuType" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <hr />

                    <div class="row">
                        <div class="col-6">
                              <label for="lblUserName" class="col-form-label bold" id="lblChildMenu" runat="server" visible="false">Choose Child Menu : </label>
                            <asp:CheckBoxList ID="listMenuItem" CssClass="form-control" runat="server" RepeatDirection="Vertical"></asp:CheckBoxList>
                        </div>
                        <div class="col-6">
                            <asp:GridView ID="gvMenuItems" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="gvMenuItems_RowCommand"
                                CssClass="table table-hover table-bordered table-condensed" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="MenuItemCode" HeaderText="Menu Code"></asp:BoundField>
                                    <asp:BoundField DataField="MenuName" HeaderText="Menu Item Name"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Remove">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkDelete" runat="server" CommandName="Remove" CommandArgument='<%# Eval("RoleMenuID") %>' Text="Remove" OnClientClick="return confirm (&quot;Are you sure want to Remove this?? &quot;)"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <EditRowStyle BackColor="#999999" />

                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#3a4f63" Font-Bold="True" ForeColor="White" />
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
                    <div class="row text-center p-1">
                        <div class="col-12">
                            <asp:Button ID="btnSaveMenu" runat="server" CssClass="btn text-white" BackColor="#3a4f63" OnClick="btnSaveMenu_Click" Text="Save Menu" ValidationGroup="Save"></asp:Button>
                        </div>
                    </div>
                </div>
            </blockquote>
        </div>
    </div>

    <br />
    <div id="divModel_AddRole" runat="server" visible="false" class="card col-5">


        <div class="card-header bold h4 text-white" style="background-color:#3a4f63">
            Add Role
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form-control">
                    <div class="row">
                        <div class="col-12">
                            <label for="lblRoleName" class="col-form-label bold">Role Name : </label>
                            <asp:TextBox ID="txtFeature" runat="server" CssClass="form-control" placeholder="Enter Role Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RoleName" runat="server" ControlToValidate="txtFeature"
                                ErrorMessage="Role Name is Required." ForeColor="red" ToolTip="Role Name is required."
                                ValidationGroup="RegisterUserValidationGroup" Display="Dynamic"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-12">
                            <asp:Button ID="btnSaveFeature" runat="server" CssClass="btn text-white" BackColor="#3a4f63" Text="Submit" ValidationGroup="RegisterUserValidationGroup" OnClick="btnSaveFeature_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </blockquote>
        </div>

    </div>
</asp:Content>

