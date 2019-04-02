<%@ Page Title="" Language="C#" MasterPageFile="~/User/Site1.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="FakeProduct_App.User.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="products">
        <div class="container">
            <div class="col-md-12 product-w3ls-right">
                <!-- breadcrumbs -->
                <ol class="breadcrumb breadcrumb1">
                    <li><a href="index.html">Home</a></li>
                    <li class="active">Products</li>
                </ol>
                <div class="clearfix"></div>
                <!-- //breadcrumbs -->
                <div class="product-top">
                    <h4>Electronics</h4>
                    <ul>
                        <li class="dropdown head-dpdn">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Filter By<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="#">Low price</a></li>
                                <li><a href="#">High price</a></li>
                                <li><a href="#">Latest</a></li>
                                <li><a href="#">Popular</a></li>
                            </ul>
                        </li>
                        <li class="dropdown head-dpdn">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Brands<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="#">Samsung</a></li>
                                <li><a href="#">LG</a></li>
                                <li><a href="#">Sony</a></li>
                                <li><a href="#">Other</a></li>
                            </ul>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="products-row">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="col-md-3 product-grids">
                                <div class="agile-products">
                                    <div class="new-tag">
                                        <h6>10<br>
                                            Off</h6>
                                    </div>
                                    <a href='ViewProduct.aspx?productId=<%#Eval("productId") %>'>
                                        <img src='<%#Eval("img") %>' class="img-responsive" alt="img"></a>
                                    <div class="agile-product-text">
                                        <h5><a href='ViewProduct.aspx?productId=<%#Eval("productId") %>'><%#Eval("name") %></a></h5>
                                        <h6><del>&#8377;<%#Eval("Price") %></del> &#8377;<%#Eval("Price") %></h6>

                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <div class="clearfix"></div>
                </div>
                <!-- add-products -->
                <div class="w3ls-add-grids w3agile-add-products">
                    <a href="#">
                        <h4>TOP 10 TRENDS FOR YOU FLAT <span>20%</span> OFF</h4>
                        <h6>Shop now <i class="fa fa-arrow-circle-right" aria-hidden="true"></i></h6>
                    </a>
                </div>
                <!-- //add-products -->
            </div>

            <div class="clearfix"></div>
            <!-- recommendations -->
            
            <!-- //recommendations -->
        </div>
    </div>
</asp:Content>
