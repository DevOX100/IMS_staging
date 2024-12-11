<%@ Page Title="Log In" Language="C#" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head id="Head1" runat="server">
    <title>Midland Microfin Ltd</title>
    <link rel="icon" type="image/png" href="../images/invlogo.jpg" />
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
    <link href="../vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../fonts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../fonts/Linearicons-Free-v1.0.0/icon-font.min.css" rel="stylesheet" />
    <link href="../vendor/animate/animate.css" rel="stylesheet" />
    <link href="../vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" />
    <link href="../vendor/animsition/css/animsition.min.css" rel="stylesheet" />
    <link href="../vendor/select2/select2.min.css" rel="stylesheet" />
    <link href="../css/util.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.3.min.js"></script>


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

        $(function () {
            $("#toggle_Newpwd").click(function () {
                $(this).toggleClass("fa-eye fa-eye-slash");
                var type = $(this).hasClass("fa-eye-slash") ? "text" : "password";
                $("#txtNewPassword").attr("type", type);
            });
        });

        $(function () {
            $("#toggle_Confirmpwd").click(function () {
                $(this).toggleClass("fa-eye fa-eye-slash");
                var type = $(this).hasClass("fa-eye-slash") ? "text" : "password";
                $("#txtConfirmPassword").attr("type", type);
            });
        });


        $(document).ready(function () {
            $('#txtPassword').bind('cut copy paste', function (event) {
                event.preventDefault();
            });
        });


    </script>
</head>


<body style="background-color: #f7f7f7">
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <form class="login100-form validate-form" style="border: groove; border-color: #070907; box-shadow: rgba(0, 0, 0, 0.9) 0px 22px 70px 8px;" runat="server">
                    <div class="row" style="color: white">

                        <div class="col-12 login100-form-title p-b-30" style="font-weight: 700; border: groove; border-color: #070907; font-size: 1.5em; font-variant: small-caps; font-family: 'Segoe UI'">
                          <%--  <asp:Image ImageUrl="~/images/logo.jpg" Height="80px" Width="140px" runat="server" />
                          --%>  <br />
                            <h3 style="text-decoration: solid; color: #070907; margin-top:10px;">Inventory  Management System</h3>
                        </div>
                    </div>
                    <span class="login100-form-title p-b-23 p-t-10 text-#070907 bold">Login
                    </span>


                    <div class="wrap-input100 validate-input" data-validate="UserName is required">
                        <asp:TextBox ID="txtUserName" runat="server" Class="input100 has-val bold"></asp:TextBox>
                        <span class="focus-input100"></span>
                        <span class="label-input100">User ID</span>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUserName"
                            ForeColor="red" ToolTip="User Name is required."
                            ValidationGroup="LoginValidationGroup" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>


                    <div class="wrap-input100 validate-input" data-validate="Password is required" id="abc" runat="server">
                        <asp:TextBox ID="txtPassword" runat="server" Class="input100 has-val bold" TextMode="Password"></asp:TextBox>
                        <span class="focus-input100"></span>
                        <span class="label-input100">Password</span>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                            ForeColor="red" ToolTip="Password is required."
                            ValidationGroup="LoginValidationGroup" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>

                    <div class="container-login100-form-btn">
                        <asp:Button ID="LoginButton" class="login100-form-btn" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginValidationGroup" OnClick="LoginButton_Click" />
                        <div class="flex-sb-m w-full p-t-3 p-b-32">
                           <div>
                        <asp:LinkButton ID="FrogotPassword" runat="server" class="col-form-label bold " Style="margin-left: 320px; color:blue;">Forgot Password !</asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <%-- <div class="row">
                        <div class="flex-sb-m w-full p-t-10 ">
                            <div></div>
                            <div class="col d-flex justify-content-left">
                                <a href="../ForgotPassword.aspx" class="txt1" style="color:white; font-weight:bold">Forgot Password?
                                </a>
                            </div>
                        </div>
                    </div>
                 

                    <div class ="signup_link">
                        Not a member?<a href="D:\Invoice\Midland\Account\SignUp.aspx">&nbsp &nbsp SignUp</a>
                    </div>--%>
                </form>
              <%--  <div class="login100-more" style="background-image: url('../images/invoice-cash.jpg');">
                </div>--%>
            </div>

        </div>
    </div>


    <script type="text/javascript" src="../vendor/jquery/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="../vendor/animsition/js/animsition.min.js"></script>
    <script type="text/javascript" src="../vendor/bootstrap/js/popper.js"></script>
    <script type="text/javascript" src="../vendor/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../vendor/select2/select2.min.js"></script>
    <script type="text/javascript" src="../vendor/countdowntime/countdowntime.js"></script>
    <script type="text/javascript" src="../js/main.js"></script>
</body>
</html>

