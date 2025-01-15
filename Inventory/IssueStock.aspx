<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="IssueStock.aspx.cs" Inherits="IssueStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
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

        /*below is the code which made the grid perfect and controlled the overflow*/
        .my-gridview {
            border-collapse: collapse;
            width: 100%;
        }

            .my-gridview th, .my-gridview td {
                text-align: left;
                padding: 15px;
            }

            .my-gridview th {
                background-color: #5D7B9D;
                color: white;
            }

            .my-gridview tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            .my-gridview tr:hover {
                background-color: #ddd;
            }
    </style>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="card">
        <div class="card-header bold h4 text-white" style="background-color: #3a4f63">
            Issue stock 
        </div>
        <div class="card-body">
            <blockquote class="blockquote mb-0">
                <div class="form">
                    <label>
                        <asp:RadioButton ID="RadioButton" runat="server" GroupName="customer" AutoPostBack="true" OnCheckedChanged="RadioButton_CheckedChanged" />
                        <span>New Customer</span>
                    </label>
                    <label>
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="customer" AutoPostBack="true" OnCheckedChanged="RadioButton2_CheckedChanged" />
                        <span>Existing Customer</span>
                    </label>
                </div>
                <div class="form-control border border-dark" id="box" runat="server" visible="false">

                    <asp:UpdatePanel ID="Updatephoto" runat="server">
                        <ContentTemplate>

                            <div class="row">
                                <div class="col-6" id="ddlcst" runat="server" visible="false">
                                    <label id="lblCustomer" class="col-form-label bold">Customer ID : <span style="color: red;">*</span></label>
                                    <asp:TextBox ID="txtCustomer" Visible="false" runat="server" CssClass="form-control border border-dark" MaxLength="10" TextMode="SingleLine" placeholder="Enter the Customer ID" ValidationGroup="ABC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfc1" runat="server" ControlToValidate="txtCustomer" ErrorMessage="Kindly enter Customer ID" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-6" runat="server">
                                    <label for="Product" class="col-form-label bold">Product : <span style="color: red">*</span></label>
                                    <asp:DropDownList ID="ddlProduct" runat="server" Enabled="true" CssClass="form-control border border-dark" ValidationGroup="ABC">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="DropDWN" runat="server" ControlToValidate="ddlProduct" ErrorMessage="Kindly select anything" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-6" runat="server">
                                    <label for="payment" class="col-form-label bold">Mode Of Disbursement: <span style="color: red">*</span></label>
                                    <asp:DropDownList ID="ddlPaymentMode" runat="server" Enabled="true" CssClass="form-control border border-dark" ValidationGroup="ABC">
                                        <asp:ListItem Text="Select Mode Of Disbursement" Value="0" />
                                        <asp:ListItem Text="Loan" Value="1" />
                                        <asp:ListItem Text="QR Code" Value="2" />
                                        <asp:ListItem Text="Cash" Value="3" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPaymentMode" ErrorMessage="Kindly select Mode Of Disbursement:" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-6" runat="server">
                                    <label for="Application" class="col-form-label bold">Application Received Stage : <span style="color: red">*</span></label>
                                    <asp:DropDownList ID="ApplicationReceivedStage" CssClass="form-control border border-dark" runat="server" ValidationGroup="ABC">
                                        <asp:ListItem Text="Select Application Received Stage" Value="0" />
                                        <asp:ListItem Text="GFM/GRT" Value="1" />
                                        <asp:ListItem Text="Disbursement of Business loan" Value="2" />
                                        <asp:ListItem Text="Centre meeting" Value="3" />


                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ApplicationReceivedStage" ErrorMessage="Kindly select Application Received Stage" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>

                            </div>

                            <div class="row">

                                <div class="col-6">
                                    <label id="lblName" class="col-form-label bold">Name : <span style="color: red;">*</span></label>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control border border-dark" MaxLength="10" TextMode="SingleLine" placeholder="Enter the Name" ValidationGroup="ABC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfc2" runat="server" ControlToValidate="txtName" ErrorMessage="Kindly enter Name" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>



                                <div class="col-6">
                                    <label id="lblImg" class="col-form-label bold">POD : <span style="color: red;">*</span></label>
                                    <asp:FileUpload ID="fupImage" runat="server" CssClass="form-control border border-dark" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="fupImage" ErrorMessage="Kindly upload the Image" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-6">
                                    <label id="lblSpouse" class="col-form-label bold">Spouse Name : <span style="color: red;">*</span></label>
                                    <asp:TextBox ID="txtSpouse" runat="server" CssClass="form-control border border-dark" MaxLength="10" TextMode="SingleLine" placeholder="Enter the Spouse name" ValidationGroup="ABC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSpouse" ErrorMessage="Kindly Enter Spouse Name" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-6">
                                    <label id="lblPhone" class="col-form-label bold">Phone : <span style="color: red;">*</span></label>
                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control border border-dark" MaxLength="10" TextMode="SingleLine" placeholder="Enter the Phone" ValidationGroup="ABC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PhoneValid" runat="server" ControlToValidate="txtPhone" ErrorMessage="Kindly Enter Phone" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-6">
                                    <label id="lblInvoiceNO" class="col-form-label bold">Invoice No :</label>
                                    <asp:TextBox ID="txtInvoiceNO" runat="server" CssClass="form-control border border-dark" TextMode="SingleLine" placeholder="Enter the Invoice NO" ValidationGroup="ABC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="InvoiceValid" runat="server" ControlToValidate="txtInvoiceNO" ErrorMessage="Kindly Enter Invoice Number" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-6">
                                    <label id="lblQuantity" class="col-form-label bold">Quantity :</label>
                                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control border border-dark" ReadOnly="true" Text="1" TextMode="SingleLine" placeholder="Enter the Quantity" ValidationGroup="ABC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Qvalid" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Kindly Enter Quantity" ForeColor="red"
                                        Display="Dynamic" ValidationGroup="ABC"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6">
                                    <label id="warnty" class="col-form-label bold">Handover Date :</label>
                                    <asp:TextBox ID="txtWarrantyDatee" runat="server" CssClass="form-control border border-dark"
                                        placeholder="Enter Warranty Date" TextMode="Date" ValidationGroup="ABC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvWarrantydatee" Enabled="false" runat="server" ControlToValidate="txtWarrantyDatee" Font-Size="small"
                                        ForeColor="red" ErrorMessage="Invoice number is required." Display="Dynamic" ValidationGroup="ABC" Font-Bold="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-6">
                                    <label id="PayAmounr" class="col-form-label bold">Enter Amount :</label>
                                    <asp:TextBox ID="textAmount" runat="server" CssClass="form-control border border-dark"
                                        placeholder="Enter Amount" TextMode="SingleLine" ValidationGroup="ABC"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Enabled="false" runat="server" ControlToValidate="textAmount" Font-Size="small"
                                        ForeColor="red" ErrorMessage="Amount is Required." Display="Dynamic" ValidationGroup="ABC" Font-Bold="true"></asp:RequiredFieldValidator>
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

                <hr />

                <div class="row" id="secondDiv" runat="server">

                    <div class="form">
                        <label>
                            <asp:RadioButton ID="rbloptionCustID" runat="server" GroupName="option" AutoPostBack="true" OnCheckedChanged="rbloptionCustID_CheckedChanged" />
                            <span>Customer ID</span>
                        </label>
                        <label>
                            <asp:RadioButton ID="rbloptionLoanID" runat="server" Checked="true" GroupName="option" AutoPostBack="true" OnCheckedChanged="rbloptionLoanID_CheckedChanged" />
                            <span>Loan ID</span>
                        </label>
                        <label>
                            <asp:RadioButton ID="rblCenterID" runat="server" GroupName="option" AutoPostBack="true" OnCheckedChanged="rblCenterID_CheckedChanged" />
                            <span>Center ID</span>
                        </label>

                        <label>
                            <asp:RadioButton ID="rblGroupID" runat="server" GroupName="option" AutoPostBack="true" OnCheckedChanged="rblGroupID_CheckedChanged" />
                            <span>Group ID</span>
                        </label>
                    </div>
                    <br />

                    <div class="col-12">
                        <div class="col-6" id="CustID" runat="server">
                            <label id="lblSearch" class="col-form-label font-weight-bold">Search Customer ID :</label>
                            <div class="form-control">
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control border border-dark" placeholder="Search By Customer ID" ValidationGroup="Cust"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCust" runat="server" ControlToValidate="txtSearch" ErrorMessage="Kindly Enter Customer ID" ForeColor="red"
                                    Display="Dynamic" ValidationGroup="Cust"></asp:RequiredFieldValidator>
                                <br />
                                <asp:Button ID="btnSearch" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="Cust" OnClick="btnSearch_Click" />
                            </div>
                        </div>



                        <div class="col-6" id="LoanID" runat="server">
                            <label id="blLoan" class="col-form-label font-weight-bold">Search Loan ID :</label>
                            <div class="form-control">
                                <asp:TextBox ID="txtLoanID" runat="server" CssClass="form-control border border-dark" placeholder="Search By Loan ID" ValidationGroup="Loann"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLoanID" runat="server" ControlToValidate="txtLoanID" ErrorMessage="Kindly Enter Loan ID" ForeColor="red"
                                    Display="Dynamic" ValidationGroup="Loann"></asp:RequiredFieldValidator>
                                <br />
                                <asp:Button ID="btnSubmitLoanID" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="Loann" OnClick="btnSubmitLoanID_Click" />

                            </div>
                        </div>


                        <div class="col-6" id="CenterID" runat="server">
                            <label id="cntr" class="col-form-label font-weight-bold">Search Center ID :</label>
                            <div class="form-control">
                                <asp:TextBox ID="txtCenter" runat="server" CssClass="form-control border border-dark" placeholder="Search By Center ID" ValidationGroup="Center"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCenter" runat="server" ControlToValidate="txtCenter" ErrorMessage="Kindly Enter Center ID" ForeColor="red"
                                    Display="Dynamic" ValidationGroup="Center"></asp:RequiredFieldValidator>
                                <br />
                                <asp:Button ID="btnCenterID" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="Center" OnClick="btnCenterID_Click" />
                            </div>
                        </div>


                        <div class="col-6" id="GroupID" runat="server">
                            <label id="grp" class="col-form-label font-weight-bold">Search Group ID :</label>
                            <div class="form-control">
                                <asp:TextBox ID="txtGrpCenter" runat="server" CssClass="form-control border border-dark" placeholder="Search By Center ID" ValidationGroup="Group"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvGrp" runat="server" ControlToValidate="txtGrpCenter" ErrorMessage="Kindly Enter Group ID" ForeColor="red"
                                    Display="Dynamic" ValidationGroup="Group"></asp:RequiredFieldValidator>
                                <br />
                                <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control" ValidationGroup="Group">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="G1">G1</asp:ListItem>
                                    <asp:ListItem Value="G2">G2</asp:ListItem>
                                </asp:DropDownList>

                                <asp:RequiredFieldValidator ID="rfvGroup" runat="server" ControlToValidate="ddlGroup" ErrorMessage="Kindly Choose Group ID" ForeColor="red"
                                    Display="Dynamic" ValidationGroup="Group" InitialValue="0"></asp:RequiredFieldValidator>
                                <br />
                                <asp:Button ID="btnGroupID" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="Group" OnClick="btnGroupID_Click" />

                            </div>
                        </div>

                    </div>







                    <div class="col-12">
                        <div style="overflow-x: auto; white-space: nowrap;">

                            <asp:GridView ID="gvIssue" runat="server" CssClass="table table-bordered table-hover my-gridview"
                                AutoGenerateColumns="False" GridLines="None" ForeColor="#333333" ShowFooter="true" Width="100%"
                                DataKeyNames="IS_CustID" OnRowCommand="gvIssue_RowCommand" OnRowDataBound="gvIssue_RowDataBound">

                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>

                                    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5px">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkAction" runat="server" OnCheckedChanged="chkAction_CheckedChanged" AutoPostBack="true" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:UpdatePanel ID="UpdatePO" runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="lnkApprove" ForeColor="White" runat="server"  CssClass="btn btn-sm btn-success" ValidationGroup="ABC" CommandName="Submit" CommandArgument='<%# Eval("CUST_ID") %>'>Approved</asp:LinkButton>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="lnkApprove" />
                                                    <%--<asp:AsyncPostBackTrigger ControlID="VendorApproval" EventName="RowCommand" />--%>
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>

                                            <asp:TextBox ID="txtGQuantity" runat="server" CssClass="form-control border border-dark" ReadOnly="true" Text="1" Width="180px" ValidationGroup="ABC"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvQuanty" Enabled="false" runat="server" ControlToValidate="txtGQuantity" Font-Size="small"
                                                ForeColor="red" ErrorMessage="Quantity is required." Display="Dynamic" ValidationGroup="ABC" Font-Bold="true"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:FileUpload ID="fupid" runat="server" CssClass="form-control border border-dark" />
                                            <asp:RequiredFieldValidator ID="rfvFileUpload" Enabled="false" runat="server" ControlToValidate="fupid" Font-Size="small"
                                                ForeColor="red" ErrorMessage="File is required." Display="Dynamic" ValidationGroup="ABC" Font-Bold="true"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product / Inovice Number / Handover Date">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="Productddl" runat="server" CssClass="form-control border border-dark" ValidationGroup="ABC">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="ProdDropDWN" runat="server" ControlToValidate="Productddl" ErrorMessage="Kindly select Product" Font-Bold="true" Font-Size="small" ForeColor="red"
                                                Display="Dynamic" ValidationGroup="ABC" Enabled="false" InitialValue="0"></asp:RequiredFieldValidator>

                                            <br />
                                            <asp:TextBox ID="txtInvoice" runat="server" CssClass="form-control border border-dark" placeholder="Enter Invoice Number" Width="180px" ValidationGroup="ABC"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtInvoice" FilterType="Numbers" ValidChars="0123456789" />
                                            <asp:RequiredFieldValidator ID="InvoiceValidator" Enabled="false" runat="server" ControlToValidate="txtInvoice" Font-Size="small"
                                                ForeColor="red" ErrorMessage="Invoice number is required." Display="Dynamic" ValidationGroup="ABC" Font-Bold="true"></asp:RequiredFieldValidator>

                                            <br />
                                            <asp:TextBox ID="txtWarrantyDate" runat="server" CssClass="form-control border border-dark" placeholder="Enter Warranty Date" TextMode="Date" Width="180px" ValidationGroup="ABC"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvWarrantydate" Enabled="false" runat="server" ControlToValidate="txtWarrantyDate" Font-Size="small"
                                                ForeColor="red" ErrorMessage="Invoice Warranty date is required." Display="Dynamic" ValidationGroup="ABC" Font-Bold="true"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mode of disbursement/Application Received Stage">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ModeOfDisbursement" CssClass="form-control border border-dark" runat="server" ValidationGroup="ABC">
                                                <asp:ListItem Text="Select Mode Of Disbursement" Value="0" />
                                                <asp:ListItem Text="Loan" Value="1" />
                                                <asp:ListItem Text="QR Code" Value="2" />
                                                <asp:ListItem Text="Cash" Value="3" />


                                            </asp:DropDownList> 
                                            <asp:RequiredFieldValidator ID="rfc2" Enabled="false"  runat="server" ControlToValidate="ModeOfDisbursement" ErrorMessage="Kindly Select Mode of Disbursement" ForeColor="red"
                                                Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:DropDownList ID="ApplicationReceivedStage" CssClass="form-control border border-dark" runat="server" ValidationGroup="ABC">
                                                <asp:ListItem Text="Select Application Received Stage" Value="0" />
                                                <asp:ListItem Text="GFM/GRT" Value="1" />
                                                <asp:ListItem Text="Disbursement of Business loan" Value="2" />
                                                <asp:ListItem Text="Centre meeting" Value="3" />


                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Enabled="false"  runat="server" ControlToValidate="ApplicationReceivedStage" ErrorMessage="Kindly Select Application Received Stage" ForeColor="red"
                                                Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>


                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtAmount" runat="server" Width="180" CssClass="form-control border border-dark"
                                                placeholder="Enter Amount" TextMode="SingleLine" ValidationGroup="ABC"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvAmount" Enabled="false" runat="server" ControlToValidate="txtAmount" Font-Size="small"
                                                ForeColor="red" ErrorMessage="Amount is Required." Display="Dynamic" ValidationGroup="ABC" Font-Bold="true"></asp:RequiredFieldValidator>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Customer ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustID" runat="server" Text='<%#Eval("IS_CustID") %>'></asp:Label>
                                            <asp:Label ID="lblUnitprice" Visible="false" runat="server" Text='<%#Eval("PM_UnitPrice") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FIRST_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Product">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProduct" runat="server" Text='<%# Eval("PRODUCT_ID") %>'></asp:Label>
                                            <asp:Label ID="lblProductID" runat="server" Visible="false" Text='<%# Eval("PM_ItemCode1") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Branch ">
                                        <ItemTemplate>

                                            <asp:Label ID="lblBranch" runat="server" Text='<%# Eval("Branch") %>'></asp:Label>
                                            <asp:Label ID="lblBranchID" Visible="false" runat="server" Text='<%# Eval("BRANCH_ID") %>'></asp:Label>


                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Mobile Number">
                                        <ItemTemplate>

                                            <asp:Label ID="lblMobileNO" runat="server" Text='<%# Eval("MOBILE_NUMBER") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Spouse Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSpouseNAme" runat="server" Text='<%# Eval("SPOUSE_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Loan ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLoanID" runat="server" Text='<%# Eval("LOAN_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="CENTER ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCenterID" runat="server" Text='<%# Eval("CENTER_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Group ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGroupID" runat="server" Text='<%# Eval("center_group_code") %>'></asp:Label>
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
                </div>
            </blockquote>
        </div>
    </div>
</asp:Content>

