<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="supplierMaster.aspx.cs" Inherits="Master_supplierMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
       <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Create Supplier
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form-control ">
                    <div class="row">
                        <div class="col-6">
                            <label for="lblVcode" class="col-form-label bold">Vendor Code : <span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtVCode" runat="server" CssClass="form-control" MaxLength="10" TextMode="SingleLine" placeholder="Enter the Vendor Code" ValidationGroup="ABC"></asp:TextBox>
                             <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtVCode" FilterType="Numbers" ValidChars="0123456789" />
                            <asp:RequiredFieldValidator ID="rfc1" runat="server" ControlToValidate="txtVCode" ErrorMessage="Kindly Enter Vendor Code" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-6">
                            <label for="lblVname1" class="col-form-label bold">Vendor Name : <span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtVName" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the Vendor Name" ValidationGroup="ABC"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfc2" runat="server" ControlToValidate="txtVName" ErrorMessage="Kindly Enter Vendor Name" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>

                    </div>


                    <div class="row">
                        <div class="col-6">
                            <label for="lblVAdd1" class="col-form-label bold">Address 1 : <span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the Address 1" ValidationGroup="ABC"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAddress1" ErrorMessage="Kindly Enter Address 1" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-6">
                            <label for="lblVAddr2" class="col-form-label bold">Address 2 : <span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtAdd2" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the Address 2" ValidationGroup="ABC"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAdd2" ErrorMessage="Kindly Enter Address 2" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>

                    </div>


                    <div class="row">
                        <div class="col-6">
                            <label for="lblPincode" class="col-form-label bold">Pincode : <span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtPincode" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the PinCode" ValidationGroup="ABC"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPincode" ErrorMessage="Kindly Enter PinCode" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-6">
                            <label for="lblCity" class="col-form-label bold">City : <span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the City" ValidationGroup="ABC"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCity" ErrorMessage="Kindly Enter City" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>

                    </div>


                    <div class="row">
                        <div class="col-6">
                            <label for="lblState" class="col-form-label bold">State : <span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtState" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the State" ValidationGroup="ABC"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtState" ErrorMessage="Kindly Enter State" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-6">
                            <label for="lblCountry" class="col-form-label bold">Country : <span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the Country" ValidationGroup="ABC"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCountry" ErrorMessage="Kindly Enter Country" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>

                    </div>


                    <div class="row">
                        <div class="col-6">
                            <label for="lblPhone" class="col-form-label bold">Phone : <span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" TextMode="SingleLine" MaxLength="10" placeholder="Enter the Phone" ValidationGroup="ABC"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPhone" ErrorMessage="Kindly Enter Phone" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-6">
                            <label for="lblEmail" class="col-form-label bold">Email : <span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtEMail" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the Email" ValidationGroup="ABC"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmail" ErrorMessage="Kindly Enter Email" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>

                    </div>


                    <div class="row">
                        <div class="col-6">
                            <label for="lblPAN" class="col-form-label bold">PAN : <span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtPAN" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the PAN" ValidationGroup="ABC"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPAN" ErrorMessage="Kindly Enter PAN" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-6">
                            <label for="lblGST" class="col-form-label bold">GST : <span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtGST" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the GST" ValidationGroup="ABC"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtGST" ErrorMessage="Kindly Enter GST" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>

                    </div>


                    <div class="row">
                        <div class="col-6">
                            <label for="lblOther1" class="col-form-label bold">Other 1:</label>
                            <asp:TextBox ID="txtOther1" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the Other 1" ValidationGroup="ABC"></asp:TextBox>

                        </div>

                        <div class="col-6">
                            <label for="lblOther2" class="col-form-label bold">Other 2:</label>
                            <asp:TextBox ID="txtOther2" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the Other 2" ValidationGroup="ABC"></asp:TextBox>
                        </div>

                    </div>


                    <div class="row">
                        <div class="col-6">
                            <label for="lblOther3" class="col-form-label bold">Other 3:</label>
                            <asp:TextBox ID="txtOther3" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the Other 3" ValidationGroup="ABC"></asp:TextBox>
                        </div>

                        <div class="col-6">
                            <label for="lblOther4" class="col-form-label bold">Other 4:</label>
                            <asp:TextBox ID="txtOther4" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter the Other 4" ValidationGroup="ABC"></asp:TextBox>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-6">
                            <label for="lblOther3" class="col-form-label bold">Is Active:</label>
                            <asp:CheckBox ID="cbActive" runat="server" CssClass="form-control" Text="IsActive" />
                        </div>

                    </div>

                    <br />
                    <div class="row">
                        <div class="form-group">
                            <div class="row text-center">
                                <div class="col-12">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn text-white" BackColor="#3a4f63" UseSubmitBehavior="false" OnClick="btnSubmit_Click" ValidationGroup="ABC" />
                                    <asp:Button ID="btnClear" runat="server" Text="Reset" CssClass="btn text-white" BackColor="red" OnClick="btnClear_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </blockquote>
        </div>
    </div>

</asp:Content>

