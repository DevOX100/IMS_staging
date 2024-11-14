<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StockTransfer.aspx.cs" Inherits="Inventory_StockTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
       <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Stock Transfer
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">

                <div class="form-control" id="box" runat="server">

                    <div class="row">
                        <div class="col-6">
                            <label id="lblProductType" class="col-form-label bold">Product Type : <span style="color: red">*</span></label>
                            <asp:DropDownList ID="ddlProductType" CssClass="form-control border border-dark" runat="server" AutoPostBack="True" ValidationGroup="ABC" OnSelectedIndexChanged="ddlProductType_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfc1" runat="server" ControlToValidate="ddlProductType" ErrorMessage="Kindly Select" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-6" runat="server">
                            <label id="lblProductName" class="col-form-label bold">Product Name : <span style="color: red">*</span></label>
                            <asp:DropDownList ID="ddlProductName" CssClass="form-control border border-dark" runat="server" ValidationGroup="ABC">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="DropDWN" runat="server" ControlToValidate="ddlProductName" ErrorMessage="Kindly select anything" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-6">
                            <label for="Branch" class="col-form-label bold">To Branch : <span style="color: red">*</span></label>
                            <asp:DropDownList ID="ddlBranch" runat="server" Enabled="true" CssClass="form-control border border-dark" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlBranch" ErrorMessage="Kindly choose Branch"
                                ForeColor="red" Display="Dynamic" ValidationGroup="XCV" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-3">
                            <label id="lblFromBranchAvlblStock" runat="server" class="col-form-label bold"><span style="color: red;"></span></label>
                            <asp:TextBox ID="txtFromBranchAvlblStock" Enabled="false" Visible="false" runat="server" CssClass="form-control" placeholder="From Branch Available Stock"></asp:TextBox>
                        </div>

                        <div class="col-3">
                            <label id="lblToBranchAvlblStock" runat="server" class="col-form-label bold"><span style="color: red;"></span></label>
                            <asp:TextBox ID="txtToBranchAvlblStock" Enabled="false" Visible="false" runat="server" CssClass="form-control" placeholder="To Branch Available Stock"></asp:TextBox>

                        </div>
                    </div>

                    <div class="row">

                        <div class="col-6">
                            <label id="lblQuantity" class="col-form-label bold">Quantity : <span style="color: red;">*</span></label>
                              <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtQuantity" FilterType="Numbers" ValidChars="0123456789" />
                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" placeholder="Enter the Quantiy" ValidationGroup="ABC"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Kindly enter Quantity" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>



                        <div class="col-6">
                            <label id="lblRemarks" class="col-form-label bold">Remarks: <span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control border border-dark" placeholder="Enter the Remarks" TextMode="MultiLine">

                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRemarks" runat="server" ControlToValidate="txtRemarks" Font-Size="small" ForeColor="red"
                                ErrorMessage="Remarks is required." Display="Dynamic" Enabled="false" ValidationGroup="ABC" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>

                    </div>

                    <br />

                    <div class="row">
                        <div class="form-group">
                            <div class="row text-center">
                                <div class="col-12">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn text-white" BackColor="#3a4f63" ValidationGroup="ABC" OnClick="btnSubmit_Click"/>
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

