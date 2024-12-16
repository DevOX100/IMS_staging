<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ViewComplaints.aspx.cs" Inherits="CPPEscalations_ViewComplaints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

    <style type="text/css">
   

 .my-gridview th {
     font-size: 16px;
 }

 .my-gridview td {
     font-size: 15px;
 }

 .my-gridview .label {
     font-size: 14px;
 }
 .modal-body {
    max-height: 400px;
    overflow-y: auto;
}




    </style>
    <!-- Add jQuery -->
    <!-- Add Bootstrap JS -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
<%--    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />--%>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63; ">
            View Complaints
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">

                <div class="form-control">
                    <div class="row">
                        <div class="col-3">
                            <label id="Region" runat="server" class="col-form-label bold">Region :</label>
                            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control border border-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-3">
                            <label id="lblBranch" runat="server" class="col-form-label bold">Branch:</label>
                            <asp:DropDownList ID="ddlBranch" CssClass="form-control border border-dark" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-3" style="position: absolute; right: 20px">
                            <label id="Status" class="col-form-label bold">Status :</label>
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control border border-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <br />

                    <br />

                    <br />
                    <hr />
                    <div class="row">
                        <div class="col">
                            <asp:Panel runat="server" frameborder="0" ScrollBars="Both" Align="Center">

                                <asp:GridView ID="GVViewEscalationns" runat="server" CssClass="table table-bordered table-hover my-gridview"
                                    AutoGenerateColumns="False" GridLines="None" Font-Size="Medium" ForeColor="#333333"
                                    ShowFooter="true" Width="100%"   OnRowCommand="GVViewEscalationns_RowCommand" OnRowDataBound="GVViewEscalationns_RowDataBound" >

                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>

                                        <asp:TemplateField HeaderText="Branch">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBranch" runat="server" Text='<%#Eval("Branch")%>'></asp:Label>
                                                <asp:Label ID="lblEMIssueID" Visible="false" runat="server" Text='<%#Eval("Em_IssueID")%>'></asp:Label>
                                                <asp:Label ID="lblComplaintconf" Visible="false"   runat="server" Text='<%#Eval("EM_BranchComplaint_Confirmation")%>'></asp:Label>
                                                <asp:Label ID="lblproductDelivery" Visible="false" runat="server" Text='<%#Eval("EM_BranchProduct_delivery")%>'></asp:Label>
                                                <asp:Label ID="lblIsVendorClosure" Visible="false" runat="server" Text='<%#Eval("EM_isVendorClosedComplaint")%>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Customer ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCustID" runat="server" Text='<%#Eval("EM_CustID")%>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Customer Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("EM_Name")%>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Spouse Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSpouseName" runat="server" Text='<%#Eval("EM_SpouseName")%>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile Number">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("EM_MobileNO")%>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("EM_Damage_stock_Quantity")%>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderText="Product">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("EM_Damage_Product_Name")%>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Product Complaint">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductComplaint" runat="server" Text='<%#Eval("EM_Damage_ProductComplaint")%>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("EM_Status")%>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="HO Confirmation">
         <ItemTemplate>
             <asp:Label ID="lblCOmplaintbyHO" runat="server" Text='<%#Eval("EM_ProductComplaintbyHO")%>'></asp:Label>

         </ItemTemplate>
     </asp:TemplateField>               <asp:TemplateField HeaderText="Vendor Confirmation">
         <ItemTemplate>
             <asp:Label ID="lblCOmplaintbyVendor" runat="server" Text='<%#Eval("Em_VendorConfirmationValue")%>'></asp:Label>

         </ItemTemplate>
     </asp:TemplateField>

                                       <%-- <asp:TemplateField HeaderText="Technician Visit">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltechnicianVisit" runat="server" Text='<%#Eval("EM_TechnicianVisit")%>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Vendor Closure Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVendorCLosureType" runat="server" Text='<%#Eval("EM_VendorclosureType")%>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>--%>


                                        <%--<asp:TemplateField HeaderText="Vendor Remarks">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVendorRemarks" runat="server" Text='<%#Eval("EM_VendorRemarks")%>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatusDate" runat="server" Text='<%#Eval("StatusDate")%>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="View Details" HeaderStyle-Width="5px">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="linkView" runat="server" CommandName="View" CommandArgument='<%# Eval("Em_IssueID") %>'>Details</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Branch Action" HeaderStyle-Width="5px">
                                            <ItemTemplate>
                                            
                                                <asp:DropDownList ID="ddlCLosure" Width="150px" runat="server" AutoPostBack="true" CssClass="form-control border border-dark" OnSelectedIndexChanged="ddlCLosure_SelectedIndexChanged" ValidationGroup="ABC">
                                                    <asp:ListItem Value="0" Text="Select Closure Type">
                                                    </asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Complaint resolved ">
                                                    </asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Complaint Not resolved">
                                                    </asp:ListItem>

                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvCLosure" Enabled="false" runat="server" ControlToValidate="ddlCLosure" ErrorMessage="Kindly select" ForeColor="red"
                                                    Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:DropDownList ID="ddlStatus"  Width="150px" runat="server" AutoPostBack="true" CssClass="form-control border border-dark"  ValidationGroup="ABC">
                                                    <asp:ListItem Value="0" Text="Select Delivery">
                                                    </asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Product Delivered ">
                                                    </asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Product Not Delivered">
                                                    </asp:ListItem>
                                                   

                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvStatus" Enabled="false" runat="server" ControlToValidate="ddlStatus" ErrorMessage="Kindly select" ForeColor="red"
                                                    Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
                                                <br />
                                                  <asp:TextBox ID="txtRemarks" AutoPostBack="true" runat="server" CssClass="form-control border border-dark" placeholder="Enter Remarks" Width="180px" ValidationGroup="ABC"></asp:TextBox>
  <asp:RequiredFieldValidator ID="rfvRemarks" Enabled="false" runat="server" ControlToValidate="txtRemarks" ErrorMessage="Kindly provide Remarks" ForeColor="red"
      Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action" >

                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAction" runat="server" AutoPostBack="true" OnCheckedChanged="chkAction_CheckedChanged" />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:LinkButton ID="lnkApprove" ForeColor="White" AutoPostBack="true" runat="server" CssClass="btn btn-sm btn-success"
                                                    ValidationGroup="ABC" CommandName="Submit" CommandArgument='<%# Eval("Em_IssueID") %>'>Submit</asp:LinkButton>

                                            </FooterTemplate>
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
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </blockquote>
        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="divModel_InvoiceDetails" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Details</h5>

                </div>
                <div class="modal-body">
                    <p>
                        <strong>Product Type:</strong>
                        <asp:Label ID="lblProductType" runat="server"></asp:Label>
                    </p>
                         <p>
         <strong>Product Complaint Date:</strong>
         <asp:Label ID="lblComplaint" runat="server"></asp:Label>
     </p>
                    <p>
                        <strong>Is stock available in branch:</strong>
                        <asp:Label ID="lblAvailableStock" runat="server"></asp:Label>
                    </p>
                    <p>
                        <strong>HO Remarks:</strong>
                        <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                    </p>
               
                    <p>
                        <strong>HO Escalation Date:</strong>
                        <asp:Label ID="lblEscalation" runat="server"></asp:Label>
                    </p>
                    <p>
                        <strong>Vendor confirm Date:</strong>
                        <asp:Label ID="lblVendorConfirmDate" runat="server"></asp:Label>
                    </p>
                      <p>
      <strong>Vendor Expected closure Date:</strong>
      <asp:Label ID="lblexpectedClosure" runat="server"></asp:Label>
  </p>           <p>
      <strong>Vendor Remarks:</strong>
      <asp:Label ID="lblVendorRemarks" runat="server"></asp:Label>
  </p>
                    <p>
                        <strong>vendor reject Date:</strong>
                        <asp:Label ID="lblEM_VendorRejectDate" runat="server"></asp:Label>
                    </p>
                    <p>
                        <strong>vendor Status Wise Date:</strong>
                        <asp:Label ID="lblEM_VendorStatusDate" runat="server"></asp:Label>
                    </p> 
                    <p>
                        <strong>Technician Visit:</strong>
                        <asp:Label ID="lblEM_VendorTechVisit" runat="server"></asp:Label>
                    </p>
                    <p>
                        <strong>Vendor Closure Type:</strong>
                        <asp:Label ID="lblEM_VendorClosure" runat="server"></asp:Label>
                    </p> 
                    <p>
                        <strong>Branch Confiramtion:</strong>
                        <asp:Label ID="lblEM_Confirmation" runat="server"></asp:Label>
                    </p>
                      <p>
      <strong>Branch Confiramtion Remarks :</strong>
      <asp:Label ID="lblConfirmationRemarks" runat="server"></asp:Label>
  </p>
                        <p>
        <strong>Confirmation Date:</strong>
        <asp:Label ID="lblEM_ConfirmationDate" runat="server"></asp:Label>
    </p>  
                    <p>
                        <strong>Stock Handover:</strong>
                        <asp:Label ID="lblEM_ProductDelivery" runat="server"></asp:Label>
                    </p> 
                
                    <p>
                        <strong>Delivery Date:</strong>
                        <asp:Label ID="lblEM_ProductDeliveryDate" runat="server"></asp:Label>
                    </p>
                </div>
                <div class="modal-footer">
                    <p>Click anywhere on the screen to close this</p>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
