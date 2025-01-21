<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Account_Home" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css" integrity="sha512-KfkfwYDsLkIlwQp6LFnl8zNdLGxu9YAA1QvwINks4PhcElQSvqcyVLLD9aMhXd13uQjoXtEKNosOWaZqXgel0g==" crossorigin="anonymous" referrerpolicy="no-referrer" />

    <%--bootstrap--%>
    <%--    <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous" type="text/javascript"></script>--%>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-Fy6S3B9q64WdZWQUiU+q4/2Lc9npb8tCaSX9FK7E8HnRr0Jz8D6OP9dO5Vg3Q9ct" crossorigin="anonymous" type="text/javascript"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous" type="text/javascript"></script>

    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous" type="text/javascript"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.min.js" integrity="sha384-+sLIOodYLS7CIrQpBjl+C7nPvqq+FbNUBDunl/OZv93DB7Ln/533i8e/mZXLi/P+" crossorigin="anonymous" type="text/javascript"></script>
    <%--    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>--%>
    <%--bootstrap--%>
    <style type="text/css">
        a {
            text-decoration: none;
        }

        body {
            margin: 0;
            padding: 0;
            overflow-x: hidden; /* Disable scrollbar */
        }

        /* Additional spacing and styling adjustments */
        .card-header, .card-body, .card-footer {
            padding: 1rem; /* Adjust padding for better alignment */
        }

        .cb-style {
            color: White;
            font-size: larger;
            font-family: 'Segoe UI Emoji';
            border-radius: 3em;
            text-align: center;
        }


        .card:hover {
            transform: scale(1.05);
            border-color: rgb(2,0,36);
            box-shadow: 0px 0px 10px 2px rgb(2,0,36);
            text-decoration: none;
            /*box-shadow: 0px 15px 26px rgba(0, 0, 0, 0.50);*/
        }

        .border-round1 {
            border-top-left-radius: 20px;
            border-top-right-radius: 20px;
            border-bottom-right-radius: 20px;
            border-bottom-left-radius: 20px;
        }

        .border-round2 {
            border-bottom-right-radius: 20px;
            border-bottom-left-radius: 20px;
        }

        .card-container {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            align-items: center;
            gap: 20px;
            padding: 10px;
            width: 100vw;
            height: 35vh;
            box-sizing: border-box;
            overflow: hidden;
        }


        .card {
            display: flex;
            justify-content: space-between;
            flex: 1 1 15rem;
            max-width: 15rem;
            height: 100%;
            border: ridge;
            border-color: transparent;
            background-color: #fff;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            transition: transform 0.2s, box-shadow 0.2s;
        }



        .card-header, .card-body, .card-footer {
            padding: 1rem;
        }

        .card-body {
            flex: 1;
        }

        .card-footer {
            text-align: center;
            font-size: 1rem;
        }

        .cb-style {
            color: White;
            font-size: larger;
            font-family: 'Segoe UI Emoji';
            border-radius: 3em;
            text-align: center;
        }

        .card:hover {
            transform: scale(1.05);
            border-color: rgb(2,0,36);
            box-shadow: 0px 0px 20px rgba(0, 0, 0, 0.2);
            text-decoration: none;
        }

        .border-round1 {
            border-radius: 20px;
        }

        .border-round2 {
            border-bottom-right-radius: 20px;
            border-bottom-left-radius: 20px;
        }

        .container {
            padding: 0;
            margin: 0;
            height: 100%;
            overflow: hidden
        }

        .limiter {
            /*  background: linear-gradient(0deg, rgba(0,0,0,1) 0%, rgba(247,247,247,1) 98%);*/
            background: linear-gradient(180deg, #A0C4FF 0%, #4B79A1 100%);
            margin: 0;
            height: 150vh;
            justify-items: center;
            align-items: center;
            text-align: center;
        }

        #mainGraph {
            justify-content: center;
            align-items: center;
            text-align: center;
            padding-right: 50px;
            /*            margin-top:100px;*/
        }
    </style>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

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

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="CardsDive" runat="server" class="limiter">
        <div class="flex-xxl-row mx-4 g-0 gap-0" style="margin: 0; height: auto;">
            <div class="col-12">
                <h2>Dashboard</h2>
                <hr />
            </div>
        </div>
        <div class="row">

            <div id="Region" runat="server" class="col-3">
                <label id="lblRegion" runat="server" class="col-form-label bold">Region : <span style="color: red">*</span></label>
                <asp:DropDownList ID="ddlRegion" runat="server" Enabled="true" CssClass="form-control border border-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="col-3">
                <label id="lblBranch" runat="server" class="col-form-label bold">Branch : <span style="color: red">*</span></label>
                <asp:DropDownList ID="ddlBranch" runat="server" Enabled="true" CssClass="form-control border border-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                </asp:DropDownList><br />
                <br />
            </div>
            <div class="col-3">
                <label for="Product" class="col-form-label bold">Product : <span style="color: red">*</span></label>
                <asp:DropDownList ID="ddlProduct" runat="server" Enabled="true" CssClass="form-control border border-dark" ValidationGroup="ABC" AutoPostBack="true" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvproduct" runat="server" ControlToValidate="ddlProduct" ErrorMessage="Kindly choose Product" ForeColor="red"
                    Display="Dynamic" ValidationGroup="ABC" InitialValue="0"></asp:RequiredFieldValidator>
            </div>
        </div>


        <br />
        <div id="Hidden1" runat="server">
        <div class="card-container">

            <div id="TS" runat="server" class="card border-round1 animationC1" style="background-color: #0a4a71">
                <div class="card-header cb-style" style="font-size: larger">
                    <h4 style="color: oldlace; font-weight: bold">Total Stock</h4>
                </div>
                <div class="card-body border-round2">
                    <div class="row">
                        <div class="col-6">
                            <i class="fa-solid fa-box fa-rotate-45 fa-3x" style="color: oldlace;"></i>
                        </div>
                        <div class="col-6">
                            <asp:Label runat="server" ID="lblTotal" Style="color: oldlace; font-size: 30Px;"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Label runat="server" ID="Label2" Style="color: oldlace; font-size: 14Px;">Total Stocks till now in the inventory</asp:Label>
                </div>
            </div>


            <div id="OS" runat="server" class="card border-round1 animationC2" style="background-color: #188162">
                <div class="card-header cb-style" style="font-size: larger">
                    <h4 style="color: oldlace; font-weight: bold">Out Stock</h4>
                </div>
                <div class="card-body border-round2">
                    <div class="row">
                        <div class="col-6">
                            <i class='fa-solid fa-truck-loading fa-3x' style="color: oldlace;"></i>
                            <!-- Updated icon -->
                        </div>
                        <div class="col-6">
                            <asp:Label runat="server" ID="lblPaid" Style="color: oldlace; font-size: 30Px;"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Label runat="server" ID="Label4" Style="color: oldlace; font-size: 14Px;">Stocks issued to customers till now in the inventory</asp:Label>
                </div>
            </div>

            <div id="Div2" runat="server" class="card border-round1 animationC1" style="background-color: #538ee5">
                <div class="card-header cb-style" style="font-size: larger">
                    <h4 style="color: oldlace; font-weight: bold">Stock Transfer</h4>
                </div>
                <div class="card-body border-round2">
                    <div class="row">
                        <div class="col-6">
                            <i class="fa-solid fa-box fa-rotate-45 fa-3x" style="color: oldlace;"></i>
                        </div>
                        <div class="col-6">
                            <asp:Label runat="server" ID="lblStockTransfer" Style="color: oldlace; font-size: 30Px;"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Label runat="server" ID="Label5" Style="color: oldlace; font-size: 14Px;">Stock Transfer till now in the inventory</asp:Label>
                </div>
            </div>

            <div id="Div3" runat="server" class="card border-round1 animationC1" style="background-color: #ff8026eb">
                <div class="card-header cb-style" style="font-size: larger">
                    <h4 style="color: oldlace; font-weight: bold">Stock Adjustment</h4>
                </div>
                <div class="card-body border-round2">
                    <div class="row">
                        <div class="col-6">
                            <i class="fa-solid fa-box fa-rotate-45 fa-3x" style="color: oldlace;"></i>
                        </div>
                        <div class="col-6">
                            <asp:Label runat="server" ID="lblStockAdjustment" Style="color: oldlace; font-size: 30Px;"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Label runat="server" ID="Label11" Style="color: oldlace; font-size: 14Px;">Stock Adjustment till now in the inventory</asp:Label>
                </div>
            </div>

            <div id="AS" runat="server" class="card border-round1 animationC3" style="background-color: #42ae5a">
                <div class="card-header cb-style" style="font-size: larger">
                    <h4 style="color: oldlace; font-weight: bold">Available Stock</h4>
                </div>
                <div class="card-body border-round2">
                    <div class="row">
                        <div class="col-6">
                            <i class="fa-solid fa-warehouse fa-3x" style="color: oldlace;"></i>
                        </div>
                        <div class="col-6">
                            <asp:Label runat="server" ID="lblPending" Style="color: oldlace; font-size: 30Px;"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Label runat="server" ID="Label6" Style="color: oldlace; font-size: 14Px;">Available stock in the branch till now in the inventory</asp:Label>
                </div>
            </div>



        </div>
        <div class="card-container">


            <div id="MTDhide" runat="server" class="card border-round1 animationC4" style="background-color: red">
                <div class="card-header cb-style" style="font-size: larger">
                    <h4 style="color: oldlace; font-weight: bold">MTD</h4>
                </div>
                <div class="card-body border-round2">
                    <div class="row">
                        <div class="col-6">
                            <i class="fa-solid fa-calendar-day fa-3x" style="color: oldlace;"></i>
                        </div>
                        <div class="col-6">
                            <asp:Label runat="server" ID="lblMonthTillDate" Style="color: oldlace; font-size: 30Px;"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Label runat="server" ID="Label8" Style="color: oldlace; font-size: 14Px;">Last 30 Days Issued Stocks</asp:Label>
                </div>
            </div>


            <div id="FTDhide" runat="server" class="card border-round1 animationC5" style="background-color: #e79505">
                <div class="card-header cb-style" style="font-size: larger">
                    <h4 style="color: oldlace; font-weight: bold">FTD</h4>
                </div>
                <div class="card-body border-round2">
                    <div class="row">
                        <div class="col-6">
                            <i class="fa-solid fa-calendar-day fa-3x" style="color: oldlace;"></i>
                        </div>
                        <div class="col-6">
                            <asp:Label runat="server" ID="lblForTheDay" Style="color: oldlace; font-size: 30Px;"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Label runat="server" ID="Label10" Style="color: oldlace; font-size: 14Px;">Today Issued Stocks</asp:Label>
                </div>
            </div>



            <div id="DivHandover" runat="server" class="card border-round1 animationC5" style="background-color: #f87226f0">
                <div class="card-header cb-style" style="font-size: larger">
                    <h4 style="color: oldlace; font-weight: bold">Customer Complaints</h4>
                </div>
                <div class="card-body border-round2">
                    <div class="row">
                        <div class="col-6">
                            <i class="fa-solid fa-tools fa-3x" style="color: oldlace;"></i>

                        </div>
                        <div class="col-6">
                            <asp:Label runat="server" ID="lblCustomerComplaints" Style="color: oldlace; font-size: 30Px;"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Label runat="server" ID="Label17" Style="color: oldlace; font-size: 14Px;">Complaints From Customers</asp:Label>
                </div>
            </div>

            <div id="DivAvailable" runat="server" class="card border-round1 animationC5" style="background-color: #42ae5a">
                <div class="card-header cb-style" style="font-size: larger">
                    <h4 style="color: oldlace; font-weight: bold">Not Delivered Stocks</h4>
                </div>
                <div class="card-body border-round2">
                    <div class="row">
                        <div class="col-6">
                            <i class="fa-solid fa-tools fa-3x" style="color: oldlace;"></i>

                        </div>
                        <div class="col-6">
                            <asp:Label runat="server" ID="lblNotDelivered" Style="color: oldlace; font-size: 30Px;"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Label runat="server" ID="Label19" Style="color: oldlace; font-size: 14Px;">Pending Stocks</asp:Label>
                </div>
            </div>
            <div id="Div4" runat="server" class="card border-round1 animationC5" style="background-color: #f87226f0">
                <div class="card-header cb-style" style="font-size: larger">
                    <h4 style="color: oldlace; font-weight: bold">Delivered Stocks</h4>
                </div>
                <div class="card-body border-round2">
                    <div class="row">
                        <div class="col-6">
                            <i class="fa-solid fa-tools fa-3x" style="color: oldlace;"></i>

                        </div>
                        <div class="col-6">
                            <asp:Label runat="server" ID="lblDeliveredStocks" Style="color: oldlace; font-size: 30Px;"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Label runat="server" ID="Label14" Style="color: oldlace; font-size: 14Px;">Delivered Stocks</asp:Label>
                </div>
            </div>

        </div>

        <div class="card-container">


            <div id="Div5" runat="server" class="card border-round1 animationC4" style="background-color: red">
                <div class="card-header cb-style" style="font-size: larger">
                    <h4 style="color: oldlace; font-weight: bold">Damaged Stock</h4>
                </div>
                <div class="card-body border-round2">
                    <div class="row">
                        <div class="col-6">
                            <i class="fa-solid fa-calendar-day fa-3x" style="color: oldlace;"></i>
                        </div>
                        <div class="col-6">
                            <asp:Label runat="server" ID="lblDamagedStockByVendor" Style="color: oldlace; font-size: 30Px;"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Label runat="server" ID="Label3" Style="color: oldlace; font-size: 14Px;">Damaged stock Received by Vendor</asp:Label>
                </div>
            </div>


            <div id="Div6" runat="server" class="card border-round1 animationC5" style="background-color: #e79505">
                <div class="card-header cb-style" style="font-size: larger">
                    <h4 style="color: oldlace; font-weight: bold">Cpp Escalation</h4>
                </div>
                <div class="card-body border-round2">
                    <div class="row">
                        <div class="col-6">
                            <i class="fa-solid fa-calendar-day fa-3x" style="color: oldlace;"></i>
                        </div>
                        <div class="col-6">
                            <asp:Label runat="server" ID="lblCPPEscalation" Style="color: oldlace; font-size: 30Px;"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Label runat="server" ID="Label9" Style="color: oldlace; font-size: 14Px;">Action Pending From vendor</asp:Label>
                </div>
            </div>





        </div> </div>
    <div class="card-container" id="CODashBoard">

      <div id="Div10" runat="server" class="card border-round1 animationC1" style="background-color: #0a4a71">
          <div class="card-header cb-style" style="font-size: larger">
              <h4 style="color: oldlace; font-weight: bold">CO Available Stock</h4>
          </div>
          <div class="card-body border-round2">
              <div class="row">
                  <div class="col-6">
                      <i class="fa-solid fa-box fa-rotate-45 fa-3x" style="color: oldlace;"></i>
                  </div>
                  <div class="col-6">
                      <asp:Label runat="server" ID="lblCoAvailableStock" Style="color: oldlace; font-size: 30Px;"></asp:Label>
                  </div>
              </div>
          </div>
          <div class="card-footer">
              <asp:Label runat="server" ID="Label7" Style="color: oldlace; font-size: 14Px;">CO Available stock in the inventory</asp:Label>
          </div>
      </div>


      <div id="Div11" runat="server" class="card border-round1 animationC2" style="background-color: #188162">
          <div class="card-header cb-style" style="font-size: larger">
              <h4 style="color: oldlace; font-weight: bold">Branch Available Stock</h4>
          </div>
          <div class="card-body border-round2">
              <div class="row">
                  <div class="col-6">
                      <i class='fa-solid fa-truck-loading fa-3x' style="color: oldlace;"></i>
                      <!-- Updated icon -->
                  </div>
                  <div class="col-6">
                      <asp:Label runat="server" ID="lblBranchAvailableStock" Style="color: oldlace; font-size: 30Px;"></asp:Label>
                  </div>
              </div>
          </div>
          <div class="card-footer">
              <asp:Label runat="server" ID="Label13" Style="color: oldlace; font-size: 14Px;">Branch Available stock </asp:Label>
          </div>
      </div>
  </div>
        </div>


    <%-- POPUP Code--%>
    <!-- Modal Popup1 Total -->
    <div id="mainGraph">
        <div id="css" runat="server" style="text-align: center;">
            <asp:Chart ID="Chart1" runat="server"
                BackColor="#000000"
                BackGradientStyle="Center"
                Height="500px"
                Palette="None"
                BorderlineColor="#400040"
                BorderlineWidth="2">
                <Titles>
                    <asp:Title Name="Items"
                        Text="Products Details(Date filter not applicable)"
                        Font="Arial, 16pt, style=Bold"
                        ForeColor="#000000" />
                </Titles>
                <Legends>
                    <asp:Legend Name="Default" Alignment="Center" Docking="Bottom" IsTextAutoFit="False" LegendStyle="Row" />
                </Legends>
                <Series>
                    <asp:Series Name="Available Stock"
                        ChartType="Column"
                        BorderWidth="2"
                        Color="#00FF00"
                        LabelForeColor="#FFFFFF"
                        IsValueShownAsLabel="True"
                        LabelFormat="{0} units"
                        Font="Arial, 10pt" />
                    <%-- <asp:Series Name="Damaged Stock"
                        ChartType="Column"
                        BorderWidth="2"
                        Color="#00FF00"
                        LabelForeColor="#FFFFFF"
                        IsValueShownAsLabel="True"
                        LabelFormat="{0} units"
                        Font="Arial, 10pt" />--%>
                </Series>

                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BorderWidth="0" />

                </ChartAreas>
            </asp:Chart>

        </div>
        <div id="Div1" runat="server" style="padding-right: 0px; text-align: center;">
            <asp:Chart ID="Chart2" runat="server"
                BackColor="#000000"
                BackGradientStyle="Center"
                Height="500px"
                Palette="None"
                BorderlineColor="#400040"
                BorderlineWidth="2">
                <Titles>
                    <asp:Title Name="Items"
                        Text="Handover Stock Status"
                        Font="Arial, 24pt, style=Bold"
                        ForeColor="#000000" />
                </Titles>
                <Legends>
                    <asp:Legend Name="Default" Alignment="Center" Docking="Bottom" IsTextAutoFit="False" LegendStyle="Row" />
                </Legends>
                <Series>
                    <asp:Series Name="Status"
                        ChartType="Column"
                        BorderWidth="2"
                        Color="#00FF00"
                        LabelForeColor="#FFFFFF"
                        IsValueShownAsLabel="True"
                        LabelFormat="{0} units"
                        Font="Arial, 10pt"
                        IsVisibleInLegend="false" />


                </Series>

                <ChartAreas>
                    <asp:ChartArea Name="ChartArea2" BorderWidth="0" />

                </ChartAreas>
            </asp:Chart>

        </div>

    </div>
</asp:Content>



