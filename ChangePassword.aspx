<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        #panel, #flip {
            padding: 1px;
            margin-top: 5px;
            margin-bottom: 5px;
            margin-left: 300px;
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
        $(document).ready(function () {
            $("#flip").click(function () {
                $("#panel").slideToggle("slow");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="card col-6">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            CHANGE PASSWORD
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form-control">
                    <div class="row" id="AdminEmplCode" runat="server" visible="false">
                        <div class="col-12">
                            <label for="lblEmpCode" class="col-form-label bold">Employee Code (Admin) : </label>
                            <asp:TextBox ID="CurrentEmployee" runat="server" CssClass="form-control" Placeholder="Enter Employee Code" ReadOnly="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentEmployee"
                                ForeColor="red" ErrorMessage="Employee Code is required." Display="Dynamic" ToolTip="Employee Code is required."
                                ValidationGroup="ChangeUserPasswordValidationGroup"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row" id="ChangeEmplCode" runat="server" visible="false">
                        <div class="col-12">
                            <label for="lblEmpCode" class="col-form-label bold">Employee Code (User):</label>
                            <asp:TextBox ID="ChangeEmployee" runat="server" CssClass="form-control" Placeholder="Enter Employee Code"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ChangeEmployee"
                                ForeColor="red" ErrorMessage="Employee Code is required." Display="Dynamic" ToolTip="Employee Code is required."
                                ValidationGroup="ChangeUserPasswordValidationGroup"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-12">
                            <label for="lblEmpCode" class="col-form-label bold">New Password : </label>
                            <asp:TextBox ID="NewPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Enter New Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                ForeColor="red" ErrorMessage="New Password is required." ToolTip="New Password is required." Display="Dynamic"
                                ValidationGroup="ChangeUserPasswordValidationGroup"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegPassword" ControlToValidate="NewPassword" runat="server"
                                ValidationExpression="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" ErrorMessage="Invalid! Check password instructions!"
                                Display="Dynamic" ValidationGroup="ChangeUserPasswordValidationGroup" ForeColor="red"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-12">
                            <label for="lblEmpCode" class="col-form-label bold">Confirm New Password : </label>
                            <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Enter Confirm New Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                ForeColor="red" Display="Dynamic" ErrorMessage="Confirm New Password is required."
                                ToolTip="Confirm New Password is required." ValidationGroup="ChangeUserPasswordValidationGroup"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                ForeColor="red" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry."
                                ValidationGroup="ChangeUserPasswordValidationGroup"></asp:CompareValidator>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
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
                    </div>
                    <br />
                    <div class="row text-center">
                        <div class="col-12">
                            <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" Text="Change Password" CssClass="btn text-white" BackColor="#3a4f63"
                                ValidationGroup="ChangeUserPasswordValidationGroup" OnClick="ChangePasswordButton_Click" />
                            <asp:Button ID="CancelPushButton" CssClass="btn btn-danger" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" OnClick="CancelPushButton_Click" />
                        </div>
                    </div>
                </div>
            </blockquote>
        </div>
    </div>
</asp:Content>
