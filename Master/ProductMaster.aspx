<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductMaster.aspx.cs" Inherits="Master_ProductMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Create Product
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form-control ">

                    <asp:UpdatePanel ID="Update1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-6">
                                    <label for="lblIC1" class="col-form-label bold">Item Code 1: <span style="color: red;">*</span></label>
                                   <asp:Label ID="lblItemCode1" runat="server" CssClass="col-form-label"></asp:Label>
                                    <asp:TextBox ID="txtItemCode1" runat="server" CssClass="form-control" MaxLength="10" TextMode="SingleLine" AutoPostBack="true" placeholder="Enter the Item code 1" ValidationGroup="ABC" OnTextChanged="txtItemCode1_TextChanged"></asp:TextBox>
                                 
                                    <asp:RequiredFieldValidator ID="rfc1" runat="server" ControlToValidate="txtItemCode1" ErrorMessage="Kindly enter Item code 1" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-6">
                                    <label for="lblITC2" class="col-form-label bold">Item Code 2: <span style="color: red;">*</span></label>
                                    <asp:TextBox ID="txtItemCode2" runat="server" CssClass="form-control" MaxLength="10" TextMode="SingleLine" placeholder="Enter the Item code 2" ValidationGroup="ABC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfc2" runat="server" ControlToValidate="txtItemCode2" ErrorMessage="Kindly enter Item code 2" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-6">
                                    <label for="lblDes1" class="col-form-label bold">Description 1: <span style="color: red;">*</span></label>
                                    <asp:TextBox ID="txtDescription1" runat="server" CssClass="form-control" MaxLength="10" TextMode="MultiLine" placeholder="Enter the Description 1" ValidationGroup="ABC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="txtDescription1" ErrorMessage="Kindly enter Description 1" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-6">
                                    <label for="lblDes2" class="col-form-label bold">Description 2: <span style="color: red;">*</span></label>
                                    <asp:TextBox ID="txtDescription2" runat="server" CssClass="form-control" MaxLength="10" TextMode="MultiLine" placeholder="Enter the Description 2" ValidationGroup="ABC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv4" runat="server" ControlToValidate="txtDescription2" ErrorMessage="Kindly enter Description 2" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-6">
                                    <label for="lblUMeas" class="col-form-label bold">Category : <span style="color: red;">*</span></label>
                                    <asp:DropDownList ID="ddlProdctCategory" runat="server" Enabled="true" CssClass="form-control" ValidationGroup="ABC">
                                        <asp:ListItem Value="0">-Select-</asp:ListItem>
                                        <asp:ListItem>Mobiles & Tablets</asp:ListItem>
                                        <asp:ListItem>TV</asp:ListItem>
                                        <asp:ListItem>Home Appliances</asp:ListItem>
                                        <asp:ListItem>Electronics</asp:ListItem>
                                        <asp:ListItem>Kitchen Appliances</asp:ListItem>
                                        <asp:ListItem>Furniture</asp:ListItem>
                                        <asp:ListItem>Solar Products</asp:ListItem>
                                        <asp:ListItem>Computer & Accessories</asp:ListItem>
                                        <asp:ListItem>Office Products</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlProdctCategory" ErrorMessage="Kindly choose Product Category" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-6">
                                    <label for="lblBrand" class="col-form-label bold">Brand : <span style="color: red;">*</span></label>
                                    <asp:TextBox ID="txtBrand" runat="server" CssClass="form-control" MaxLength="100" TextMode="SingleLine" placeholder="Enter the Brand Name" ValidationGroup="ABC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv5" runat="server" ControlToValidate="txtBrand" ErrorMessage="Kindly enter Brand Name" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-6">
                                    <label for="lblUnitPrice" class="col-form-label bold">Unit Price : <span style="color: red;">*</span></label>
                                    <asp:TextBox ID="txtUnitPrice" runat="server" TextMode="Number" CssClass="form-control" Placeholder="Enter Unit Price" MaxLength="7" ValidationGroup="ABC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUnitPrice" ErrorMessage="Kindly enter Unit Price" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-6">
                                    <label for="lblMRPPrice" class="col-form-label bold">MRP Price: <span style="color: red;">*</span></label>
                                    <asp:TextBox ID="txtMRPPrice" runat="server" TextMode="Number" CssClass="form-control" Placeholder="Enter MRP Price" MaxLength="7" ValidationGroup="ABC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv6" runat="server" ControlToValidate="txtMRPPrice" ErrorMessage="Kindly enter MRP Price" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>

                            </div>


                            <div class="row">
                                <div class="col-6">
                                    <label for="lblUMeas" class="col-form-label bold">Unit of Measurement : <span style="color: red;">*</span></label>
                                    <asp:DropDownList ID="ddlUnitOFMeasurement" runat="server" Enabled="true" CssClass="form-control" ValidationGroup="ABC">
                                        <asp:ListItem Value="0">-Select-</asp:ListItem>
                                        <asp:ListItem>Pcs.</asp:ListItem>
                                        <asp:ListItem>No.</asp:ListItem>
                                        <asp:ListItem>Dozen</asp:ListItem>
                                        <asp:ListItem>Box</asp:ListItem>
                                        <asp:ListItem>Lot</asp:ListItem>
                                        <asp:ListItem>Ltr</asp:ListItem>
                                        <asp:ListItem>Mtr</asp:ListItem>
                                        <asp:ListItem>KG</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlUnitOFMeasurement" ErrorMessage="Kindly enter Unit of Measurement" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>



                                <div class="col-4">
                                    <label for="lblImg" class="col-form-label bold">Image : <span style="color: red;">*</span></label>
                                    <asp:FileUpload ID="fupImage" runat="server" CssClass="form-control" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="fupImage" ErrorMessage="Kindly upload the Image" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-2">
                                    <br />

                                    <asp:LinkButton ID="lnk_ImageDwnld" runat="server" OnClick="lnk_ImageDwnld_Click">Download Product Image</asp:LinkButton>


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
                                    <label ID="lblDate" class="col-form-label bold">Warranty End Date : <span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtWarrantyDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtWarrantyDate" ErrorMessage="Kindly choose warranty expiring date"
                                        ForeColor="red" Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-6">
                                    <label for="lblVendor" class="col-form-label bold">Vendor : <span style="color: red;">*</span></label>
                                    <asp:DropDownList ID="ddlVendor" runat="server" Enabled="true" CssClass="form-control" ValidationGroup="ABC">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlVendor" ErrorMessage="Kindly choose vendor" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
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
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnSubmit" />
                            <asp:PostBackTrigger ControlID="lnk_ImageDwnld" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </blockquote>
        </div>
    </div>
</asp:Content>

