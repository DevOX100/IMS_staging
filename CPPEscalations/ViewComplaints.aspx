<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ViewComplaints.aspx.cs" Inherits="CPPEscalations_ViewComplaints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            View Complaints
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">

                <div class="form-control border border-dark ">
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
                    <hr />
                </div>
            </blockquote>
            <asp:GridView ID="GVViewEscalationns" runat="server" CssClass="table table-bordered table-hover"
                AutoGenerateColumns="False" GridLines="None" Font-Size="Medium" ForeColor="#333333" ShowFooter="true" Width="100%">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>

                    <asp:TemplateField HeaderText="Custome ID">
                        <ItemTemplate>
                            <asp:Label ID="lblCustID" runat="server" Text='<%#Eval("Branch")%>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Custome ID">
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
                    <asp:TemplateField HeaderText="Product Type">
                        <ItemTemplate>
                            <asp:Label ID="lblProductType" runat="server" Text='<%#Eval("EM_Damage_Product_Type")%>'></asp:Label>

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
                    <asp:TemplateField HeaderText="Product Complaint Date">
                        <ItemTemplate>
                            <asp:Label ID="lblComplaintDate" runat="server" Text='<%#Eval("EM_Damage_ProductComplaint_date")%>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IS Product Available in Branch">
                        <ItemTemplate>
                            <asp:Label ID="AvailabilityInBranch" runat="server" Text='<%#Eval("EM_AvailableStockInBranch")%>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField> 
                  <asp:TemplateField HeaderText="HO Remarks">
                        <ItemTemplate>
                            <asp:Label ID="lblHoRemarks" runat="server" Text='<%#Eval("EM_Remarks")%>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("EM_Status")%>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Escalation Date">
                        <ItemTemplate>
                            <asp:Label ID="lblEscalationDate" runat="server" Text='<%#Eval("EM_EscalationDate")%>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField> 
                  
                    <asp:TemplateField HeaderText="Technician Visit">
                        <ItemTemplate>
                            <asp:Label ID="lbltechnicianVisit" runat="server" Text='<%#Eval("EM_TechnicianVisit")%>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Vendor Closure Type">
                        <ItemTemplate>
                            <asp:Label ID="lblVendorCLosureType" runat="server" Text='<%#Eval("EM_VendorclosureType")%>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vendor Rejection Date">
                        <ItemTemplate>
                            <asp:Label ID="lblVendorRejectDate" runat="server" Text='<%#Eval("EM_VendorRejectDate")%>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vendor Confirm Date">
                        <ItemTemplate>
                            <asp:Label ID="lblVendorConfirmation" runat="server" Text='<%#Eval("EM_VendorConfirmDate")%>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Vendor Remarks">
      <ItemTemplate>
          <asp:Label ID="lblVendorRemarks" runat="server" Text='<%#Eval("EM_VendorRemarks")%>'></asp:Label>

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
    </div>

</asp:Content>
