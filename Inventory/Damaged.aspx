<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Damaged.aspx.cs" Inherits="Inventory_Damaged" %>

<asp:Content ID="content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function OpenNewPopUp(val, id) {
            // alert('Entered as a ' + val);
            if (val == '1') {
                $('#' + id).show();
                setTimeout(function () {
                    $('#' + id).show();
                    $('#' + id).addClass('show');
                    $('body').css('overflow', 'hidden');
                    var elem = document.createElement('div');
                    elem.className = "modal-backdrop show";
                    //elem.style.cssText = "z-index:9999;";
                    document.body.appendChild(elem);
                }, 300);
            }
            else {
                $('#' + id).removeClass('show');
                $('div[class*="modal-backdrop"]').remove();
                setTimeout(function () {
                    $('#' + id).hide();
                    $('body').css('overflow', 'auto');
                }, 100);
            }
        }
    </script>
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
    </style>
</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Stock Adjustment
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">

                <div class="form-control" id="box" runat="server">

                    <asp:UpdatePanel ID="Updatephoto" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-6">
                                    <label id="lblRegion" for="Region" runat="server" class="col-form-label bold">Region : <span style="color: red">*</span></label>
                                    <asp:DropDownList ID="ddlRegion" runat="server" Enabled="true" CssClass="form-control border border-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-6">
                                    <label id="lblBranch" runat="server" for="Branch" class="col-form-label bold">Branch : <span style="color: red">*</span></label>
                                    <asp:DropDownList ID="ddlBranch" runat="server" Enabled="true" CssClass="form-control border border-dark" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlBranch" ErrorMessage="Kindly choose Branch"
                                        ForeColor="red" Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-6">
                                    <label id="lblProductType" class="col-form-label bold">Product Type : <span style="color: red">*</span></label>
                                    <asp:DropDownList ID="ddlProductType" CssClass="form-control border border-dark" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProductType_SelectedIndexChanged" ValidationGroup="ABC">
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

                                <%--   <div class="col-6">
                                    <label id="lblProductComplaint" class="col-form-label bold">Reason : <span style="color: red;">*</span></label>
                                    <asp:DropDownList ID="ddlComplaintType" CssClass="form-control border border-dark" runat="server" ValidationGroup="ABC">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfc2" runat="server" ControlToValidate="ddlComplaintType" ErrorMessage="Kindly Select Complaint" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>--%>

                                <div class="col-6">
                                    <label id="lblProductComplaint" class="col-form-label bold">Reason : <span style="color: red;">*</span></label>
                                    <asp:DropDownList ID="ddlComplaintType" CssClass="form-control border border-dark" runat="server" ValidationGroup="ABC">
                                        <asp:ListItem Text="Select Reason" Value="0" />
                                        <asp:ListItem Text="Missing  Unit" Value="1" />
                                        <asp:ListItem Text="Employee Purchase" Value="2" />
<asp:ListItem Text="Admin Use units" Value="3" />
<asp:ListItem Text="Adjustment by HO" Value="4" />

                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfc2" runat="server" ControlToValidate="ddlComplaintType" ErrorMessage="Kindly Select Complaint" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
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
                                    <label id="lblImage" class="col-form-label bold">Upload Attachment : <span style="color: red;">(only in JPG format) </span></label>
                                    <asp:FileUpload ID="fupImage" runat="server" CssClass="form-control" />

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
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn text-white" BackColor="#3a4f63" ValidationGroup="ABC" OnClick="btnSubmit_Click" />
                                            <asp:Button ID="btnClear" runat="server" Text="Reset" CssClass="btn text-white" BackColor="red" OnClick="btnClear_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnSubmit" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="col-12">


                    <asp:GridView ID="gvDamaged" runat="server" CssClass="table table-bordered table-hover my-gridview"
                        AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" ShowFooter="true" Width="100%"
                        OnRowCommand="gvDamaged_RowCommand">

                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Region">
                                <ItemTemplate>
                                    <asp:Label ID="lblRegion" runat="server" Text='<%#Eval("DP_Region") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Branch">
                                <ItemTemplate>
                                    <asp:Label ID="lblbranch" runat="server" Text='<%#Eval("DP_Branch") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustID" runat="server" Text='<%#Eval("DP_Product_Type") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Product Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("DP_Product_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Reason">
                                <ItemTemplate>
                                    <asp:Label ID="lblProduct" runat="server" Text='<%# Eval("DP_Complaint_Types") %>'></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Quantity ">
                                <ItemTemplate>

                                    <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("DP_Damaged_Quantity") %>'></asp:Label>



                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks  ">
                                <ItemTemplate>

                                    <asp:Label ID="lblDPRemarks" runat="server" Text='<%# Eval("DP_Remarks") %>'></asp:Label>



                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="View Damage Image">
                                <ItemTemplate>
                                    <asp:UpdatePanel ID="UpdateAtt" runat="server">

                                        <ContentTemplate>
                                            <asp:LinkButton ID="lnkDamagedImage" runat="server" CommandName="VIEWDamagedImage" CommandArgument='<%# Eval("DP_DamageProduct_Image") %>'>View</asp:LinkButton>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="lnkDamagedImage" />
                                        </Triggers>
                                    </asp:UpdatePanel>
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
    <div id="Div_View_Image" runat="server" visible="false" class="modal fade" role="dialog" clientidmode="static">
        <div class="modal-dialog-scrollable" role="document">
            <!-- Modal content-->
            <div class="modal-content">

                <div class="modal-header">
                    <h5 class="modal-title fw-bold" id="lblModalInvoiceDetailss">Image Attatchment : </h5>
                    <a href="#" style="text-decoration: none" aria-hidden="true" data-dismiss="modal" aria-label="Close">
                        <i class="fa fa-times fa-2x alert-danger" aria-hidden="true"></i>
                    </a>
                </div>

                <div class="modal-body">
                    <asp:Literal ID="lvImage" runat="server" />
                </div>

                <div class="modal-footer">
                    <asp:Button ID="btnClosed" class="btn btn-danger" runat="server" Text="Close" OnClick="btnClosed_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

