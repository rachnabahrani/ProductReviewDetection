<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="AddReview.aspx.cs" Inherits="FakeProduct_App.Admin.WebForm8" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .Star {
            background-image: url(/images/Star.gif);
            height: 17px;
            width: 17px;
        }

        .WaitingStar {
            background-image: url(/images/WaitingStar.gif);
            height: 17px;
            width: 17px;
        }

        .FilledStar {
            background-image: url(/images/FilledStar.gif);
            height: 17px;
            width: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1>Add Review
        <small>Control panel</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="index.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Add Review</li>
        </ol>
    </section>
    <section class="content">
        <!-- Small boxes (Stat box) -->
        <div class="row">
            <div class="col-md-6">
                <!-- general form elements -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Add Review</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <div class="box-body">
                        <div class="form-group">
                            <label for="exampleInputEmail1">Select Product</label>
                            <asp:DropDownList ID="ddlProduct" DataValueField="productId" DataTextField="name" class="form-control" runat="server" required></asp:DropDownList>
                        </div>
                        <%--<div class="form-group">
                            <label for="exampleInputEmail1">Select Site</label>
                            <asp:DropDownList ID="ddlSite" DataValueField="siteId" DataTextField="siteName" class="form-control" runat="server" required></asp:DropDownList>
                        </div>--%>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Review</label>
                            <asp:TextBox ID="txtReview" class="form-control" TextMode="MultiLine" placeholder="Product Name" runat="server" required></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Rating</label>
                            <cc1:Rating ID="Rating1" AutoPostBack="true" runat="server"
                                StarCssClass="Star" WaitingStarCssClass="WaitingStar" EmptyStarCssClass="Star"
                                FilledStarCssClass="FilledStar" CurrentRating="0">
                            </cc1:Rating>
                        </div>
                    </div>
                    <!-- /.box-body -->
                    <div class="box-footer">
                        <asp:Button ID="btnSave" class="btn btn-primary" runat="server" OnClick="btnSave_Click" Text="Submit" />
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
