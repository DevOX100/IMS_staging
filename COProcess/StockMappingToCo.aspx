<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StockMappingToCo.aspx.cs" Inherits="COProcess_StockMappingToCo" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="HeadContent">
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
<asp:Content ID="content2" runat="server" ContentPlaceHolderID="MainContent">

    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Stock Allocation to CO
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">

                <div class="form-control" id="box" runat="server">


                    <div class="row">
                        <div class="col-6">
                            <label id="lblProductType" class="col-form-label bold">Product: <span style="color: red">*</span></label>
                            <asp:DropDownList ID="ddlProductType" CssClass="form-control border border-dark" runat="server" AutoPostBack="True" ValidationGroup="ABC">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfc1" runat="server" ControlToValidate="ddlProductType" ErrorMessage="Kindly Select" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-6">
                            <label for="CO" class="col-form-label bold">CO : <span style="color: red">*</span></label>
                            <asp:ListBox ID="lstCenterOfficer" runat="server" SelectionMode="Multiple" CssClass="form-control border border-dark custom-listbox" AutoPostBack="true"  ValidationGroup="ABC" OnSelectedIndexChanged="lstCenterOfficer_SelectedIndexChanged"></asp:ListBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="lstCenterOfficer" ErrorMessage="Kindly Select one or more COs" ForeColor="red" Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>

                            <label id="lblCOs" runat="server" class="col-form-label bold mt-2">Selected Center Officers:</label>
                            <asp:Label ID="lblCO" runat="server" CssClass="form-control border border-dark"></asp:Label>
                        </div>

                    </div>

                    <div class="row">


                        <div class="col-6">
                            <label id="lblQuantity" class="col-form-label bold">Quantity : <span style="color: red;">*</span></label>
                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" placeholder="Enter the Quantiy" ValidationGroup="ABC"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Kindly enter Quantity" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%-- <div class="row">

                      <div class="col-6">
                          <label id="lblRemarks" class="col-form-label bold">Remarks : <span style="color: red;">*</span></label>
                          <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" placeholder="Enter the Remarks" ValidationGroup="ABC"></asp:TextBox>
                         
                      </div>
                  </div>--%>
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


                    <asp:GridView ID="GvStockAllocation" runat="server" CssClass="table table-bordered table-hover my-gridview"
                        AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" ShowFooter="true" Width="100%">

                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>

                            <asp:TemplateField HeaderText="CO ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblCO" runat="server" Text='<%#Eval("username") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Product">
                                <ItemTemplate>
                                    <asp:Label ID="lblProduct" runat="server" Text='<%#Eval("PM_Description1") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Allocated by">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("MappedBY") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Allocation Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%#Eval("PMC_MappedDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <%-- <asp:TemplateField HeaderText="Stock Allocated Quantity">
                              <ItemTemplate>
                                  <asp:Label ID="lblDPRemarks" runat="server" Text='<%# Eval("PMC_MappedDate") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                            --%>
                            <asp:TemplateField HeaderText="Stock Allocated quantity to CO">
                                <ItemTemplate>
                                    <asp:Label ID="lblStockAllocation" runat="server" Text='<%# Eval("PMC_BQuantity") %>'></asp:Label>
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
