<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <style type="text/css">
        #panel, #flip {
            padding: 1px;
            margin-top: 5px;
            margin-bottom: 5px;
            margin-left: 450px;
            text-align: center;
            background-color: #3a4f63;
            border: solid 1px #c3c3c3;
            color: white;
        }

        #panel {
            padding: 5px;
            display: none;
            margin-left: 0px;
        }
    </style>
    <script type="text/javascript">
        function successalert() {
            swal({
                title: "User Created!",
                text: "Kindly check your Registered email for credentials.",
                type: "success",
                showConfirmButton: true
            });
        }

        $(document).ready(function () {
            $("#flip").click(function () {
                $("#panel").slideToggle("slow");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            NEW USER
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form-control">

                    <div class="row">

                        <div class="col-6">
                            <label for="lblRegion" class="col-form-label bold">Region</label>
                            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control" ValidationGroup="AddInvoiceValidationGroup" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="ddlRegion" ErrorMessage="Please Select Region" ForeColor="red" ToolTip="Region is required" ValidationGroup="AddInvoiceValidationGroup" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-6">
                            <label for="lblBranch" class="col-form-label bold">Branch  </label>
                            <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Branch is required." ToolTip="Branch is required." ForeColor="red"
                                ValidationGroup="RegisterUserValidationGroup" ControlToValidate="ddlBranch" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-6">
                            <label for="lblDepartment" class="col-form-label bold">Department </label>
                            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control" ValidationGroup="AddInvoiceValidationGroup" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ControlToValidate="ddlDepartment" ErrorMessage="Please Select Department" ForeColor="red" ToolTip="Departments is required" ValidationGroup="AddInvoiceValidationGroup" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-6">
                            <label for="lblRole" class="col-form-label bold">Role </label>
                            <asp:DropDownList ID="ddlRoleID" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Role is required." ToolTip="Role is required." ForeColor="red"
                                ValidationGroup="RegisterUserValidationGroup" ControlToValidate="ddlRoleID" InitialValue="0"></asp:RequiredFieldValidator>

                        </div>
                    </div>

                    <div class="row">
                        <div class="col-6">
                            <label for="lblEmpCode" class="col-form-label bold">Employee Code  </label>
                            <asp:TextBox ID="txtEmpCode" runat="server" CssClass="form-control" MaxLength="10" OnTextChanged="txtEmpCode_TextChanged" AutoPostBack="true" Placeholder="Enter Employee Code"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtEmpCode" FilterType="Numbers" ValidChars="0123456789" />
                            <asp:RequiredFieldValidator ID="EmpCodeRequired" runat="server" ControlToValidate="txtEmpCode"
                                ForeColor="red" ErrorMessage="Employee Code is Required." Display="Dynamic" ToolTip="Employee Code is required."
                                ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-6">
                            <label for="lblUserName" class="col-form-label bold">Employee Name  </label>
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" Placeholder="Enter EmployeeName" MaxLength="20"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUserName"
                                ErrorMessage="User Name is Required." ForeColor="red" ToolTip="User Name is required."
                                ValidationGroup="RegisterUserValidationGroup" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                    </div>

                    <div class="row">

                        <div class="col-6">
                            <label for="lblMobile" class="col-form-label bold">Mobile No.  </label>
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" Placeholder="Enter Mobile No." MaxLength="10" OnTextChanged="txtMobile_TextChanged" AutoPostBack="false"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtMobile" FilterType="Numbers" ValidChars="0123456789" />
                            <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobile" ErrorMessage="Mobile Number is Required" ForeColor="red" ToolTip="Mobile Number is required" ValidationGroup="RegisterUserValidationGroup" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rfvMob" runat="server" ControlToValidate="txtMobile" ErrorMessage="Invalid Mobile Number" ForeColor="red" ToolTip="Invaild Mobile Number" ValidationExpression="^[6-9][0-9]{9}$" ValidationGroup="RegisterUserValidationGroup" Display="Dynamic"></asp:RegularExpressionValidator>

                        </div>

                        <div class="col-6">
                            <label for="lblEmail" class="col-form-label bold">Email  </label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Enter Email" MaxLength="50" AutoPostBack="false" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ForeColor="red" ErrorMessage="Email is Required." Display="Dynamic" ToolTip="Employee Code is required." ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ForeColor="Red" ToolTip="Invalid Email Format" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup"></asp:RegularExpressionValidator>

                        </div>
                    </div>

                    <div class="row">

                        <div class="col-6">
                            <label for="lblPassword" class="col-form-label bold">Password  </label>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Enter Password" MaxLength="20"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                                ForeColor="red" ErrorMessage="Password is Required." ToolTip="Password is required." Display="Dynamic"
                                ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegPassword" ControlToValidate="txtPassword" runat="server"
                                ValidationExpression="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" ErrorMessage="Invalid! Check password instructions!"
                                Display="Dynamic" ValidationGroup="ChangePassword" ForeColor="red"></asp:RegularExpressionValidator>
                            <%--<asp:Button ID="btnPaswdInst" Name="btnPaswdInst" Style="margin-left: 450px" runat="server" Text="Password Instructions." CssClass="btn btn-sm btn-link" OnClick="btnPaswdInst_Click"/>--%>
                        </div>
                        <div class="col-6">
                            <label for="lblConPassword" class="col-form-label bold">Confirm Password  </label>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Enter Confirm Password" MaxLength="20"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtConfirmPassword" ForeColor="red" Display="Dynamic"
                                ErrorMessage="Confirm Password is Required." ID="ConfirmPasswordRequired" runat="server"
                                ToolTip="Confirm Password is Required." ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
                                ForeColor="red" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                ValidationGroup="RegisterUserValidationGroup">Password must be matched</asp:CompareValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-6">
                           <label for="lbltype" class="col-form-label bold">Login Type  </label>
                            <asp:DropDownList CssClass="form-control" ID="ddlLoginType" runat="server">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Branch Login" Value="B"></asp:ListItem>
                                <asp:ListItem Text="User Login" Value="U"></asp:ListItem>
                                <asp:ListItem Text="Division" Value="D"></asp:ListItem>
                                <asp:ListItem Text="Cluster" Value="C"></asp:ListItem>
                            </asp:DropDownList>

                            <asp:RequiredFieldValidator ControlToValidate="ddlLoginType" ForeColor="red" Display="Dynamic"
                                ErrorMessage="Confirm Password is Required." ID="RequiredFieldValidator3" runat="server" InitialValue="0"
                                ToolTip="Confirm Password is Required." ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                        </div>


                    </div>

                    <div class="row">
                        <div class="col-4"></div>
                        <div class="col-8">
                            <div id="flip">Password Instruction.</div>

                            <div class="form-control" id="panel">
                                <ul style="color: white; text-align: justify">
                                    <li>A password should be alphanumeric.</li>
                                    <li>First letter of the password should be capital.</li>
                                    <li>Password must contain a special character (@,$,!,&,etc).</li>
                                    <li>Password length must be greater than 8 characters.</li>
                                    <li>One of the most important that the password fields should not be empty.</li>
                                </ul>
                            </div>
                        </div>
                        <%--<div class="col-4"></div>--%>
                    </div>

                    <div class="form-group p-2">
                        <div class="row text-center">
                            <div class="col-12">
                                <asp:Button ID="CreateUserButton" runat="server" Text="Submit" CssClass="btn text-white" BackColor="#3a4f63" ValidationGroup="RegisterUserValidationGroup" OnClick="CreateUserButton_Click" />
                                <asp:Button ID="Reset" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="Reset_Click" Visible="true" />
                            </div>
                        </div>
                    </div>
                </div>
            </blockquote>
        </div>
    </div>

</asp:Content>



