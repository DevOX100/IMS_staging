<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Inv_Report.aspx.cs" Inherits="Inventory_Inv_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Inventory Reports
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form-control border border-dark ">
                    <div class="row">
                        <div class="col-12">
                            <label for="Product" class="col-form-label bold">Reports : <span style="color: red">*</span></label>
                            <asp:DropDownList ID="ddlReport" runat="server" Enabled="true" CssClass="form-control border border-dark" ValidationGroup="ABC"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlReport_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlReport" ErrorMessage="Kindly choose Product" ForeColor="red"
                                Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <br />

                    <div class="row">
                        <div class="col-6" runat="server" id="divFromDate" visible="false">
                            <label for="Product" class="col-form-label bold">From Date : <span style="color: red">*</span></label>
                            <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-6" runat="server" id="divToDate" visible="false">
                            <label for="Product" class="col-form-label bold">To Date : <span style="color: red">*</span></label>
                            <asp:TextBox ID="txtToDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        </div>


                    </div>

                    <div class="row">
                        <div class="col-12" runat="server" id="divSubmit" style="margin-top: 40px">
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Export Report" Visible="false" CssClass="btn text-white" BackColor="#3a4f63"
                                        OnClick="btnSubmit_Click" ValidationGroup="ABC" />
                                    <asp:Button ID="Download" runat="server" Text="Download Report" Visible="false" CssClass="btn text-white" BackColor="#3a4f63"
                                        OnClick="Download_Click" ValidationGroup="ABC" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnSubmit" />
                                    <asp:PostBackTrigger ControlID="Download" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                </div>
            </blockquote>
        </div>
    </div>


</asp:Content>

