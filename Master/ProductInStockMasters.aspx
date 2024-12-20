﻿<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductInStockMasters.aspx.cs" Inherits="Master_ProductInStockMasters" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <style>
        .my-gridview th, .my-gridview td {
            padding: 10px;
        }

        .my-gridview th {
            font-size: 16px;
        }

        .my-gridview td {
            font-size: 15px;
        }

        .my-gridview .label {
            font-size: 14px;
        }

        .form {
            display: flex;
            justify-content: center;
            align-items: center;
            gap: 20px;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f0f0f0;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .my-gridview {
            margin-top: 20px;
        }

        .form label {
            display: flex;
            align-items: center;
            cursor: pointer;
            font-size: 16px;
        }



            .form label input[type="radio"] {
                margin-right: 10px;
                cursor: pointer;
            }

            .form label span {
                color: #333;
            }

            .form label:hover {
                background-color: #e0e0e0;
            }

        .custom-listbox {
            height: 100px;
            transition: height 0.3s ease;
        }
        /*   .custom-listbox:hover{
 height: 100px; 
            }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">

    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Insert Stocks
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">

                <div class="form-control" id="box" runat="server">


                    <div class="row">
                        <div class="col-6">
                            <label for="Region" class="col-form-label bold">Region : <span style="color: red">*</span></label>
                            <asp:DropDownList ID="ddlRegion" runat="server" Enabled="true" CssClass="form-control border border-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-6">
                            <label for="Branch" class="col-form-label bold">Branch : <span style="color: red">*</span></label>
                            <asp:ListBox ID="lstBranch" runat="server" SelectionMode="Multiple" CssClass="form-control border border-dark custom-listbox" AutoPostBack="true" OnSelectedIndexChanged="lstBranch_SelectedIndexChanged"></asp:ListBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="lstBranch" ErrorMessage="Kindly choose Branch" ForeColor="red" Display="Dynamic" ValidationGroup="XCV" InitialValue="0"></asp:RequiredFieldValidator>

                            <label id="lblSelectedBranch" runat="server" class="col-form-label bold mt-2">Selected Branches:</label>
                            <asp:Label ID="lblSelectedBranches" runat="server" CssClass="form-control border border-dark"></asp:Label>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-6">
                            <label id="lblProductType" class="col-form-label bold">Product: <span style="color: red">*</span></label>
                            <asp:DropDownList ID="ddlProductType" CssClass="form-control border border-dark" runat="server" AutoPostBack="True" ValidationGroup="ABC">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfc1" runat="server" ControlToValidate="ddlProductType" ErrorMessage="Kindly Select" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>

                        <div class="col-6">
                            <label id="lblQuantity" class="col-form-label bold">Quantity : <span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" placeholder="Enter the Quantiy" ValidationGroup="ABC"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Kindly enter Quantity" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-6">
                            <label id="lblRemarks" class="col-form-label bold">Remarks : <span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" placeholder="Enter the Remarks" ValidationGroup="ABC"></asp:TextBox>
                           
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="form-group">
                            <div class="row text-center">
                                <div class="col-12">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn text-white" BackColor="#3a4f63" ValidationGroup="ABC" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="btnClear" runat="server" Text="Reset" CssClass="btn text-white" BackColor="red" OnClick="btnClear_Click" />
                                </div>
                            </div>
                        </div>
                    </div>


                </div>
                <div class="col-12">


                    <asp:GridView ID="GVProductInStock" runat="server" CssClass="table table-bordered table-hover my-gridview"
                        AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" ShowFooter="true" Width="100%">

                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Branch ">
                                <ItemTemplate>
                                    <asp:Label ID="lblRegion" runat="server" Text='<%#Eval("branch_id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Product">
                                <ItemTemplate>
                                    <asp:Label ID="lblbranch" runat="server" Text='<%#Eval("PM_Description2") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Inserted by">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustID" runat="server" Text='<%#Eval("insert_by") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Inserted Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("insert_date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Stock Inserted">
                                <ItemTemplate>
                                    <asp:Label ID="lblDPRemarks" runat="server" Text='<%# Eval("in_stock") %>'></asp:Label>
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
            </blockquote>
        </div>
    </div>


</asp:Content>
