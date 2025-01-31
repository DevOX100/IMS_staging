﻿<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductBulkBulkDelivery.aspx.cs" Inherits="Master_ProductBulkBulkDelivery" %>

<asp:Content ContentPlaceHolderID="HeadContent" ID="Content" runat="server">

    <style>
        .card {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        /* Loading Screen Styling */
        #loadingScreen {
            position: fixed;
            width: 100%;
            height: 100%;
            top: 0;
            left: 0;
            background: rgba(255, 255, 255, 0.8);
            z-index: 1000;
            display: none;
            justify-content: center;
            align-items: center;
        }

        .spinner {
            border: 4px solid rgba(0, 0, 0, 0.1);
            border-left-color: #3a4f63;
            border-radius: 50%;
            width: 40px;
            height: 40px;
            animation: spin 1s linear infinite;
        }

        @keyframes spin {
            to {
                transform: rotate(360deg);
            }
        }
    </style>

    <script type="text/javascript">
        function SelectAllCheckboxes(chkAll) {
            var grid = document.getElementById('<%= gvBulk.ClientID %>');
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    inputs[i].checked = chkAll.checked;
                }
            }
        }

        function showLoading() {
            document.getElementById("loadingScreen").style.display = "flex";
        }

        function hideLoading() {
            document.getElementById("loadingScreen").style.display = "none";
            var checkboxes = document.querySelectorAll("#<%= gvBulk.ClientID %> input[type='checkbox']");
            checkboxes.forEach(function (checkbox) {
                checkbox.checked = false;
            });
        }
    </script>

</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" ID="Content2" runat="server">
    <div id="loadingScreen">
        <div class="spinner"></div>
    </div>
    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Deliver Bulk Stock 
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">


                <div class="row">
                    <div class="col-4">
                        <asp:FileUpload ID="fpBulkUpload" runat="server" CssClass="form-control" />

                    </div>

                    <div class="col-1">
                        <asp:Button ID="btnUploadExcel" runat="server" Text="Upload" CssClass="btn btn-primary" BackColor="#3a4f63" OnClick="btnUploadExcel_Click" />
                    </div>

                    <div class="col-2">
                        <asp:UpdatePanel ID="Update" runat="server">

                            <ContentTemplate>



                                <asp:Button ID="btnFormat" runat="server" Text="Download Format" CssClass="btn btn-warning" OnClick="btnFormat_Click" />


                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnUploadExcel" />
                                <asp:PostBackTrigger ControlID="btnFormat" />
                                <%--        <asp:PostBackTrigger ControlID="btnDwnldData" />--%>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>

            </blockquote>
        </div>
    </div>
    <div>
        <asp:GridView ID="gvBulk" runat="server" AutoGenerateColumns="False" CellPadding="4"
            CssClass="table table-bordered table-hover" OnRowCommand="gvBulk_RowCommand" ForeColor="#333333"
            GridLines="None" ShowFooter="True" Width="100%">
            <EditRowStyle BackColor="#7C6F57" />
            <EmptyDataTemplate>
                <h3>No record found!!</h3>
            </EmptyDataTemplate>
            <AlternatingRowStyle BackColor="White" />
            <Columns>

                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("BIS_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Branch ID">
                    <ItemTemplate>
                        <asp:Label ID="lblBranchID" runat="server" Text='<%#Eval("Branch") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product">
                    <ItemTemplate>
                        <asp:Label ID="lblProductID" runat="server" Text='<%#Eval("Product") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Requested Quantity">
                    <ItemTemplate>
                        <asp:Label ID="lblRequestedQuantity" runat="server" Text='<%#Eval("Requested_Quantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("price") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PO Amount">
                    <ItemTemplate>
                        <asp:Label ID="lblPOAmount" runat="server" Text='<%#Eval("PO_Amount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PO Number">
                    <ItemTemplate>
                        <asp:Label ID="lblPONumber" runat="server" Text='<%#Eval("PO_Number") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sent Qunatity">
                    <ItemTemplate>
                        <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Sent_Qunatity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Enter Quantity">
                    <ItemTemplate>
                        <asp:Label ID="lblENterQuantity" runat="server" Text='<%#Eval("Enter_Quantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Enter tentative Delivery Date">
                    <ItemTemplate>
                        <asp:Label ID="lblTentativeDeliveryDate" runat="server" Text='<%#Eval("Enter_tentative_Delivery_Date") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">

                    <HeaderTemplate>
                        <asp:Label ID="lblSelectALL" runat="server" Text="Select All"></asp:Label>
                        <asp:CheckBox ID="chkSelectAll" runat="server" onclick="SelectAllCheckboxes(this);" />

                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:CheckBox ID="chkReport" runat="server" AutoPostBack="true"  />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="btnSave" runat="server" OnClientClick="showLoading();" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Report" CssClass="btn btn-danger" Text="Save" ValidationGroup="a" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </div>
</asp:Content>
