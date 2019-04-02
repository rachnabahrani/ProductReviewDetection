<%@ Page Title="" Language="C#" MasterPageFile="~/User/Site1.Master" AutoEventWireup="true" CodeBehind="DefaultReviews.aspx.cs" Inherits="FakeProduct_App.User.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <ol class="breadcrumb breadcrumb1">
            <li><a href="index.aspx">Home</a></li>
            <li class="active">Single Page</li>
        </ol>
        <div class="clearfix"></div>
    </div>
    <div class="products">
        <div class="container">
            <div class="collpse tabs">
                <h3 class="w3ls-title">Reviews</h3>
                <div class="panel-group collpse" id="accordion" role="tablist" aria-multiselectable="true">
                    <div class="panel panel-default">
                        <div class="panel-heading" role="tab" id="headingOne">
                            <h4 class="panel-title">
                                <a class="pa_italic" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                    <i class="fa fa-file-text-o fa-icon" aria-hidden="true"></i><span class="fa fa-angle-down fa-arrow" aria-hidden="true"></span><i class="fa fa-angle-up fa-arrow" aria-hidden="true"></i>
                                </a>
                            </h4>
                        </div>
                        <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                            <div class="panel-body">
                                <asp:Label ID="lblReview" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnLike" runat="server" Text="Like" class="w3ls-cart w3ls-cart-like" OnClick="btnLike_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnDislike" runat="server" Text="Dislike" class="w3ls-cart w3ls-cart-like" OnClick="btnDislike_Click" />
        </div>
    </div>
</asp:Content>
