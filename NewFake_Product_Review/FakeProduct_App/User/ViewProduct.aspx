<%@ Page Title="" Language="C#" MasterPageFile="~/User/Site1.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="FakeProduct_App.User.WebForm3" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .Star {
            background-image: url(/Images/Star.gif);
            height: 17px;
            width: 17px;
        }

        .WaitingStar {
            background-image: url(/Images/WaitingStar.gif);
            height: 17px;
            width: 17px;
        }

        .FilledStar {
            background-image: url(/Images/FilledStar.gif);
            height: 17px;
            width: 17px;
        }

        .fancy-green .ajax__tab_header {
            background: url(green_bg_Tab.gif) repeat-x;
            cursor: pointer;
        }

        .fancy-green .ajax__tab_hover .ajax__tab_outer, .fancy-green .ajax__tab_active .ajax__tab_outer {
            background: url(green_left_Tab.gif) no-repeat left top;
        }

        .fancy-green .ajax__tab_hover .ajax__tab_inner, .fancy-green .ajax__tab_active .ajax__tab_inner {
            background: url(green_right_Tab.gif) no-repeat right top;
        }

        .fancy .ajax__tab_header {
            font-size: 13px;
            font-weight: bold;
            color: #000;
            font-family: sans-serif;
        }

            .fancy .ajax__tab_active .ajax__tab_outer, .fancy .ajax__tab_header .ajax__tab_outer, .fancy .ajax__tab_hover .ajax__tab_outer {
                height: 46px;
            }

            .fancy .ajax__tab_active .ajax__tab_inner, .fancy .ajax__tab_header .ajax__tab_inner, .fancy .ajax__tab_hover .ajax__tab_inner {
                height: 46px;
                margin-left: 16px; /* offset the width of the left image */
            }

            .fancy .ajax__tab_active .ajax__tab_tab, .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_header .ajax__tab_tab {
                margin: 16px 16px 0px 0px;
            }

        .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_active .ajax__tab_tab {
            color: #fff;
        }

        .fancy .ajax__tab_body {
            font-family: Arial;
            font-size: 10pt;
            border-top: 0;
            border: 1px solid #999999;
            padding: 8px;
            background-color: #ffffff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <ol class="breadcrumb breadcrumb1">
            <li><a href="index.aspx">Home</a></li>
            <li class="active">Single Page</li>
        </ol>
        <div class="clearfix"></div>
    </div>
    <!-- //breadcrumbs -->
    <!-- products -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="products">
        <div class="container">
            <div class="single-page">
                <div class="single-page-row" id="detail-21">
                    <div class="col-md-6 single-top-left">
                        <div class="flexslider">
                            <ul class="slides">
                                <li data-thumb="images/s1.jpg">
                                    <div class="thumb-image detail_images">
                                        <img src='<%=product.img %>' data-imagezoom="true" class="img-responsive" alt="">
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-md-6 single-top-right">
                        <h3 class="item_name"><%=product.name %></h3>
                        <p>Processing Time: Item will be shipped out within 2-3 working days. </p>
                        <div class="single-rating">
                            <ul>
                                <%-- <cc1:Rating ID="Rating1" AutoPostBack="true" runat="server"
                                    StarCssClass="Star" WaitingStarCssClass="WaitingStar" EmptyStarCssClass="Star"
                                    FilledStarCssClass="FilledStar" CurrentRating="0">
                                    <li><a href="#">Add your review</a></li>
                                </cc1:Rating>--%>
                            </ul>

                        </div>
                        <div class="single-price">
                            <ul>
                                <li>&#8377;<%=product.price %></li>
                                <li><del>&#8377;<%=product.price %></del></li>
                                <%--  <li><span class="w3off"><%=product.discount %></span></li>--%>
                                <li>Ends on: June,5th</li>
                                <li><a href="#"><i class="fa fa-gift" aria-hidden="true"></i>Coupon</a></li>
                            </ul>
                        </div>
                        <p class="single-price-text"><%=product.description %> </p>
                        <%--  <asp:Button ID="btnAddToCart" class="w3ls-cart" runat="server" Text="Add to cart" CausesValidation="false" OnClick="btnAddToCart_Click" />--%>
                    </div>
                    <div class="clearfix"></div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Button ID="btnFirstTechnique" runat="server" Text="First Technique" OnClick="btnFirstTechnique_Click1" BackColor="#66CCFF" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSecondTechnique" runat="server" Text="Second Technique" OnClick="btnSecondTechnique_Click1" BackColor="#66CCFF" />

                        </div>
                    </div>
                    <br />
                    <div style="margin-left: 100px;">
                        <asp:Button ID="btnCompare" runat="server" Text="Compare" OnClick="btnCompare_Click" BackColor="#66CCFF" />
                    </div>
                    <%-- <div class="recommend">
                        <h3 class="w3ls-title">Information </h3>
                        <div><%=product.information %></div>
                    </div>--%>
                </div>
            </div>

            <asp:Repeater ID="Repeater1" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
                <ItemTemplate>
                    <div class="panel panel-default">
                        <div class="panel-heading" role="tab" id="headingOne">
                            <h4 class="panel-title">
                                <a class="pa_italic" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                    <i class="fa fa-file-text-o fa-icon" aria-hidden="true"></i><%#Eval("UserName") %>  <span class="fa fa-angle-down fa-arrow" aria-hidden="true"></span><i class="fa fa-angle-up fa-arrow" aria-hidden="true"></i>
                                </a>
                            </h4>
                            <%-- <asp:Label ID="lblPrediction" <%#Eval("Prediction") %> runat="server" Text=""></asp:Label>--%>
                        </div>
                        <%--  <ajax:Rating ID="Rating2"  runat="server"
                    StarCssClass="Star" WaitingStarCssClass="WaitingStar" EmptyStarCssClass="Star"
                    FilledStarCssClass="FilledStar"   CurrentRating='<%#Eval("Rating") %>'>
                </ajax:Rating>--%>
                        <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                            <div class="panel-body">

                                <%#Eval("Review") %>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <div class="contact">
                <div class="container">
                    <div class="contact-form-row">
                        <h3 class="w3ls-title w3ls-title1">Submit your Review Here</h3>
                        <div class="col-md-12 contact-left">
                            Ratings
                    <ajax:Rating ID="Rating2" AutoPostBack="true" runat="server"
                        StarCssClass="Star" WaitingStarCssClass="WaitingStar" EmptyStarCssClass="Star"
                        FilledStarCssClass="FilledStar" CurrentRating="0">
                    </ajax:Rating>
                            <br />
                            <textarea id="txtReview" placeholder="Review" runat="server"></textarea>
                            <asp:Button ID="btnSumbit" runat="server" Text="Submit" OnClick="btnSumbit_Click" />
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
