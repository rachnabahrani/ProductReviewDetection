<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FakeProduct_App.User.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
     <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Smart Bazaar Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
SmartPhone Compatible web template, free WebDesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!-- Custom Theme files -->
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="css/animate.min.css" rel="stylesheet" type="text/css" media="all" />
    <!-- animation -->
    <link href="css/menu.css" rel="stylesheet" type="text/css" media="all" />
    <!-- menu style -->
    <!-- //Custom Theme files -->
    <!-- font-awesome icons -->
    <link href="css/font-awesome.css" rel="stylesheet" />
    <!-- //font-awesome icons -->
    <!-- js -->
    <script src="js/jquery-2.2.3.min.js"></script>
    <script src="js/jquery-scrolltofixed-min.js" type="text/javascript"></script>
    <!-- fixed nav js -->
    <script>
        $(document).ready(function () {

            // Dock the header to the top of the window when scrolled past the banner. This is the default behaviour.

            $('.header-two').scrollToFixed();
            // previous summary up the page.

            var summaries = $('.summary');
            summaries.each(function (i) {
                var summary = $(summaries[i]);
                var next = summaries[i + 1];

                summary.scrollToFixed({
                    marginTop: $('.header-two').outerHeight(true) + 10,
                    zIndex: 999
                });
            });
        });
    </script>
    <!-- //js -->
    <!-- web-fonts -->
    <link href="fonts/Roboto.css" rel='stylesheet' type='text/css' />
    <link href="fonts/Lovers.css" rel='stylesheet' type='text/css' />
    <link href="fonts/Offside.css" rel='stylesheet' type='text/css' />
    <link href="fonts/Tangerine.css" rel='stylesheet' type='text/css' />
    <!-- web-fonts -->
    <!-- start-smooth-scrolling -->
    <script type="text/javascript" src="js/move-top.js"></script>
    <script type="text/javascript" src="js/easing.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $(".scroll").click(function (event) {
                event.preventDefault();
                $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
            });
        });
    </script>
    <!-- //end-smooth-scrolling -->
    <!-- smooth-scrolling-of-move-up -->
    <script type="text/javascript">
        $(document).ready(function () {

            var defaults = {
                containerID: 'toTop', // fading element id
                containerHoverID: 'toTopHover', // fading element hover id
                scrollSpeed: 1200,
                easingType: 'linear'
            };

            $().UItoTop({ easingType: 'easeOutQuart' });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div class="container">
                <h3 class="w3ls-title w3ls-title1">Create your account</h3>
                <div class="login-body">
                    <asp:TextBox ID="txtUsername" class="user" name="email" placeholder="Username" ForeColor="Red"  runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUsername" ForeColor="Red"  runat="server" ErrorMessage="UserName Required"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtPassword" type="password" name="password" class="lock" placeholder="Password" ForeColor="Red" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPassword" ForeColor="Red"  runat="server" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtName" class="user" placeholder="Full Name" ForeColor="Red" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtName" ForeColor="Red"  runat="server" ErrorMessage="Name Required"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtEmail" class="user" placeholder="Email Id" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$" ForeColor="Red" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtEmail" runat="server" ForeColor="Red"  ErrorMessage="Email Required"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtContact" class="user" placeholder="Contact Number" pattern="[0-9]{10}" ForeColor="Red" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtContact" ForeColor="Red"  runat="server" ErrorMessage="Contact No Required"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtAddress" class="user" placeholder="Address" ForeColor="Red" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtAddress" ForeColor="Red"  runat="server" ErrorMessage="Address Required"></asp:RequiredFieldValidator>
                    <asp:Button ID="btnRegister" runat="server" Text="Submit" OnClick="btnRegister_Click" />
                </div>

               <%-- <div class="login-page-bottom social-icons">
                    <h5>Recover your social account</h5>
                    <ul>
                        <li><a href="#" class="fa fa-facebook icon facebook"></a></li>
                        <li><a href="#" class="fa fa-twitter icon twitter"></a></li>
                        <li><a href="#" class="fa fa-google-plus icon googleplus"></a></li>
                        <li><a href="#" class="fa fa-dribbble icon dribbble"></a></li>
                        <li><a href="#" class="fa fa-rss icon rss"></a></li>
                    </ul>
                </div>--%>
            </div>
        </div>
    </form>
</body>
</html>
