<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="PoForm.aspx.cs" Inherits="Inventory_PoForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Purchase Order</title>
    <style>
        .grid-spacing .form-control th,
        .grid-spacing .form-control td {
            padding: 8px;
        }

        .grid-spacing .form-control tr {
            margin-bottom: 8px;
        }

        .form-control[readonly] {
            background-color: #f5f5f5;
            cursor: not-allowed;
            resize: none;
        }

        body {
            font-family: Arial, sans-serif;
            background-color: #f8f9fa;
            margin: 0;
            padding: 0;
        }

        .container {
            max-width: 1200px;
            margin: 20px auto;
            padding: 0px 30px 20px 30px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 0 50px rgba(0, 0, 0, 0.3);
        }

        .card-header {
            background-color: #3a4f63;
            color: white;
            text-align: center;
            padding: 10px 0;
            margin-bottom: 20px;
        }

        .card-header1 {
            background-color: #ceebe8;
            color: black;
            text-align: center;
            font-size: large;
            padding: 5px 0;
            margin-bottom: 20px;
        }

        .bold {
            font-weight: bold;
        }

        .form-control {
            width: 100%;
            margin-bottom: 20px;
        }

        #row {
            display: flex;
            justify-content: space-between;
            padding: 0 30px;
        }

            #row > #div1, #div2 {
                line-height: 1.8rem;
                margin: 0 10px;
                padding: 20px;
            }

        /*  #BranchAddress #addDiv1 {
            display: flex;
         
        }*/



        .col-7 {
            position: absolute;
            right: 11%;
            line-height: 1.8rem;
            flex: 0 0 50%;
        }

        .col-8 {
            float: right;
            margin-right: 50px;
        }

        .grid-spacing {
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 50px;
        }

        #FG {
            border: 2px solid black;
            padding: 10px;
        }

        #form-group {
            line-height: 3rem;
        }

        #lblAuthorizedSignatory, #lblCompany {
            line-height: 5rem;
        }

        #lblTotalAmount {
            float: right;
        }

        /* .spacing {
            display: flex;
            justify-content: center;
            align-items: center;
        }*/

        .spacing {
            display: flex;
            justify-content: space-between; /* Ensure VendorAddress and BranchAddress are spaced evenly */
            margin-bottom: 30px; /* Add some margin if needed */
        }

            .spacing > div {
                height: 200px; /* Increase height for better visual balance */
                width: 45%; /* Adjust width to fit the container */
                padding: 20px;
                background-color: #ffffff;
                border-radius: 10px;
                box-shadow: 0 0 20px rgba(0, 0, 0, 0.3);
                /*display: flex;
                flex-direction: column;*/ /* Align content vertically */
                justify-content: space-between; /* Ensure content is spaced out */
            }

        /*     #sVendorAddress > #ContactNumber{
            display: flex;
        }*/

        #BranchAddress {
            display: flex;
            flex-direction: column;
            justify-content: space-between; /* Ensure GST Number is at the bottom */
        }

            #BranchAddress .gst-container {
                margin-top: auto; /* Push GST Number to the bottom */
            }


        /* Ensure footer takes full width and no margin */
        #footer {
            display: flex;
            justify-content: space-between;
            margin-top: 30px; /* Add margin if needed for spacing */
        }

        /* Set display and alignment for left-side and right-side containers */
        .spacing1 {
            display: flex;
            justify-content: space-between;
            width: 100%;
            height: 250px;
        }


        .left-side {
            width: 45%;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.3);
        }

        #lblName, #lblSign, #lblCompany, #lblbrachName, #lblBrnachSign {
            text-align: left;
            line-height: 3rem;
        }


        .right-side {
            width: 45%;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.3);
            text-align: left;
            position: relative;
        }

        /*.right-side  {
    position: absolute;
    bottom: 10px;
    left: 10px;
}*/
        .date-time {
            display: flex;
            position: absolute;
            bottom: 10px;
            right: 10px;
            justify-content: space-between;
            width: calc(100% - 20px);
        }

            .date-time > * {
                margin-left: 20px;
            }

                .date-time > *:last-child {
                    margin-right: 200px;
                }

        #form1 {
            height: 100vh;
        }

        #logoImage {
            width: 200px;
            height: 200px;
            padding: 0;
            margin: 0px 0px -50px 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnBack" runat="server" CssClass="card-header bold" Font-Bold="true" Text="Back To PO" OnClick="btnBack_Click" />
        <asp:Panel ID="panel1" runat="server">

            <div class="container">
                <asp:Label runat="server" ID="lblPoNum" CssClass="col-form-label bold" Visible="false"></asp:Label>
              <%--  <asp:Image ID="logoImage" runat="server" ImageUrl="~/images/Midland.png" AlternateText="Logo Alt Text" />--%>

                <h1 class="card-header bold">Purchase Order</h1>
                <div class="spacing">
                    <div id="SVendorAddress">
                        <asp:Label runat="server" ID="lblVendorAddress" CssClass="col-form-label bold" Text="Name and Address of Supplier:" />
                        <asp:Literal ID="VendorAddress" runat="server"></asp:Literal><br />
                        <br />
                        <asp:Label runat="server" ID="lblContact" CssClass="col-form-label bold" Text="Contact No:" />
                        <asp:Literal ID="ContactNumber" runat="server"></asp:Literal><br />
                        <br />
                        <asp:Label runat="server" ID="lblContactName" CssClass="col-form-label bold" Text="Contact Person name:" />
                        <asp:Literal ID="ContactName" runat="server"></asp:Literal><br />
                        <br />
                        <asp:Label runat="server" ID="lblGST" CssClass="col-form-label bold" Text="GST NO:" />
                        <asp:Literal ID="GST" runat="server"></asp:Literal><br />
                    </div>
                    <div id="BranchAddress">
                        <asp:Label runat="server" ID="lbllBranchAddress" CssClass="col-form-label bold" Text="Delivery Address" />
                        <asp:Literal ID="DelieveryAddress" runat="server"></asp:Literal>
                        <br />
                        <asp:Label runat="server" ID="lblcontactperson1" CssClass="col-form-label bold" Text="Contact Person 1:" />
                        <asp:Literal ID="Contactperson1" runat="server"></asp:Literal><br />
                        <asp:Label runat="server" ID="lblcontactpersonNumber" CssClass="col-form-label bold" Text="Contact no:" />
                        <asp:Literal ID="contactpersonNumber" runat="server" ></asp:Literal><br />

                        <asp:Label runat="server" ID="lblContactPerson2" CssClass="col-form-label bold" Text="Contact person 2 : " />
                        <asp:Literal ID="ContactPerson2" runat="server" ></asp:Literal><br />
                        <asp:Label runat="server" ID="lblcontactpersonNumber2" CssClass="col-form-label bold" Text="Contact No. 2:" />
                        <asp:Literal ID="contactpersonNumber2" runat="server" ></asp:Literal><br />

                        <!-- Add a container for GST Number -->
                        <div class="gst-container">
                            <asp:Label runat="server" ID="lblgstNO" CssClass="col-form-label bold" Text="GST Number:" />
                            <asp:Literal ID="GSTNO" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <h1 class="card-header1 bold">PO Details</h1>
                    <div id="row">
                        <div id="div1">
                            <asp:Label runat="server" ID="lblpoDate" CssClass="col-form-label bold" Text="PO Generated Date:" />
                            <asp:Literal ID="poDateValue" runat="server" /><br />
                            <asp:Label runat="server" ID="lblpoAmount" CssClass="col-form-label bold" Text="PO Amount:" />
                            <asp:Literal ID="PO_Amount" runat="server" /><br />


                        </div>
                        <div id="div2">
                            <asp:Label runat="server" ID="lblpoNumber" CssClass="col-form-label bold" Text="PO Number:"></asp:Label>
                            <asp:Literal ID="PONumber" runat="server"></asp:Literal>/<br />

                            <asp:Label runat="server" ID="lbldeliveryDate" CssClass="col-form-label bold" Text="Expected Delivery Date:" />
                            <asp:Literal ID="PO_Delivery_Date" runat="server"></asp:Literal><br />
                        </div>
                    </div>
                </div>
                <div class="grid-spacing">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="form-control">
                        <Columns>
                            <asp:BoundField DataField="itemCode" HeaderText="Item Code" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="price" HeaderText="Rate" />
                            <asp:BoundField DataField="total_amount" HeaderText="Total Amount" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="FG" class="form-group">
                    <div class="col-8">
                        <asp:Literal ID="lblTotalAmount" runat="server" Text="RS"></asp:Literal><br />
                    </div>
                    <asp:Label runat="server" ID="lblTotal" CssClass="bold" Text="Total:"></asp:Label>


                </div>
                <div id="form-group" class="form-group">
                    <div>
                        <asp:Label runat="server" ID="Label1" CssClass="bold" Text="PO Amount:" />
                        <asp:Literal ID="litPOAmount" runat="server" /><br />
                    </div>

                    <div>
                        <asp:Label runat="server" ID="lblTermsAndConditions" CssClass="bold" Text="Terms and Conditions While receiving PO:" /><br />
                        <%--<asp:Literal ID="txtTermsAndConditions" runat="server" /><br />--%>
                        <asp:TextBox ID="txtTermsAndConditions" runat="server" TextMode="MultiLine" Rows="15" CssClass="form-control" ReadOnly="true"></asp:TextBox><br />
                        <%--<asp:Label runat="server" ID="lblAuthorizedSignatory" CssClass="bold" Text="Authorized Signatory" /><br />
                        <asp:Label runat="server" ID="lblCompany" CssClass="bold" Text="Midland Microfin Ltd" /><br />--%>
                    </div>
                </div>

                <div id="footer">
                    <div class="spacing1">
                        <div class="left-side">
                            <asp:Label runat="server" ID="lblAuthorizedSignatory" CssClass="bold" Text="REQUIRED SUPPLIER’S SIGNATURE:" /><br />
                            <asp:Label runat="server" ID="lblName" CssClass="bold" Text="Name:" /><br />
                            <asp:Label runat="server" ID="lblSign" CssClass="bold" Text="Sign:" />
                        </div>

                        <div class="right-side">
                            <asp:Label runat="server" ID="lblCompany" CssClass="bold" Text="REQUIRED RECEIVER’S SIGNATURE:" /><br />
                            <asp:Label runat="server" ID="lblbrachName" CssClass="bold" Text="Name:" /><br />
                            <asp:Label runat="server" ID="lblBrnachSign" CssClass="bold" Text="Sign:" />
                            <div class="date-time">
                                <asp:Label runat="server" ID="lblDate" CssClass="bold" Text="Date:" /><br />
                                <asp:Label runat="server" ID="lblTime" CssClass="bold" Text="Time:" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </asp:Panel>
    </form>
    <script>
        window.onload = function () {
            window.print();
        };
    </script>
</body>
</html>
