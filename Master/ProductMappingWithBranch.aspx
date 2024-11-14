<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductMappingWithBranch.aspx.cs" Inherits="Master_ProductMappingWithBranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
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

        #EMP {
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

            #EMP label {
                display: flex;
                align-items: center;
                cursor: pointer;
                font-size: 12px;
            }
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" ID="Content2" runat="server">
    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Product Mapping With Branch 
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form">
                    <label>
                        <asp:RadioButton ID="RadioButton" runat="server" GroupName="customer" AutoPostBack="true" OnCheckedChanged="RadioButton_CheckedChanged" />
                        <span>Product Mapping</span>
                    </label>
                    <label>
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="customer" AutoPostBack="true" OnCheckedChanged="RadioButton2_CheckedChanged" />
                        <span>Existing Mapped Products</span>
                    </label>
                </div>
        <%--        <br />--%>
                <div id="FirstDiv" runat="server">
                    <div class="row">
                        <div class="col-6">
                            <asp:FileUpload ID="fpBulkUpload" runat="server" CssClass="form-control" />

                        </div>

                        <div class="col-1">
                            <asp:Button ID="btnUploadExcel" runat="server" Text="Upload" CssClass="btn btn-primary" BackColor="#3a4f63" OnClick="btnUploadExcel_Click" />
                        </div>

                        <div class="col-5">
                            <asp:UpdatePanel ID="Update" runat="server">

                                <ContentTemplate>
                              <asp:Button ID="btnFormat" runat="server" Text="Download Format" CssClass="btn btn-warning" OnClick="btnFormat_Click" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnUploadExcel" />
                                    <asp:PostBackTrigger ControlID="btnFormat" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

                <div id="EMP" runat="server">
                    <div class="row">
                        <div class="col-6">
                            <label for="Region" class="col-form-label bold">Region :</label>
                            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control border border-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-6">
                            <label id="lblBranch" class="col-form-label bold">Branch:</label>
                            <asp:DropDownList ID="ddlBranch" CssClass="form-control border border-dark" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
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

                <asp:TemplateField HeaderText="Branch ID">
                    <ItemTemplate>
                        <asp:Label ID="lblBranchID" runat="server" Text='<%#Eval("branchid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Product ID">
                    <ItemTemplate>
                        <asp:Label ID="lblProductID" runat="server" Text='<%#Eval("productid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>



                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkReport" runat="server"/>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="btnSave" runat="server" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Report" CssClass="btn btn-danger" Text="Save" ValidationGroup="a" />
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


    <div>

        <asp:GridView ID="gvIssue" runat="server" CssClass="table table-bordered table-hover my-gridview"
            AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" Width="100%" OnRowCommand="gvIssue_RowCommand">

            <AlternatingRowStyle BackColor="White" />
            <Columns>

                <asp:TemplateField HeaderText="Branch ID">
                    <ItemTemplate>
                        <asp:Label ID="lblBranchID" runat="server" Text='<%#Eval("branchid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Product ID">
                    <ItemTemplate>
                        <asp:Label ID="lblProductID1" runat="server" Text='<%#Eval("productid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mapped On">
                    <ItemTemplate>
                        <asp:Label ID="lblProductID2" runat="server" Text='<%#Eval("insertdate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mapped By">
                    <ItemTemplate>
                        <asp:Label ID="lblProductID3" runat="server" Text='<%#Eval("insertby") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                   <asp:TemplateField  HeaderText="Action">
                      <ItemTemplate>
                          <asp:LinkButton ID="LinkDelete" runat="server" CommandName="chage" CommandArgument='<%# Eval("PMWB_ID") %>'  Text='<%# Eval("Visible") %>'  OnClientClick="return confirm (&quot;Are you sure want to Change this?? &quot;)"></asp:LinkButton>
                      </ItemTemplate>
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
