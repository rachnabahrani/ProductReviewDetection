<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="FakeProduct_App.Admin.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1>Add Product
        <small>Control panel</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="index.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Add Product</li>
        </ol>
    </section>
    <section class="content">
        <!-- Small boxes (Stat box) -->
        <div class="row">
            <div class="col-md-6">
                <!-- general form elements -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Add Product</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->

                    <div class="box-body">
                        <div class="form-group">
                            <label for="exampleInputEmail1">Select Category</label>
                            <asp:DropDownList ID="ddlCategory" class="form-control" DataValueField="categoryId" DataTextField="category" runat="server"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Product Name</label>
                            <asp:TextBox ID="txtName" class="form-control" placeholder="Product Name" runat="server" required></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Product Description</label>
                            <asp:TextBox ID="txtDescription" class="form-control" placeholder="Description" TextMode="MultiLine" runat="server" required></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Product Price</label>
                            <asp:TextBox ID="txtPrice" class="form-control" placeholder="Product Price" runat="server" required></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Select Image</label>
                            <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:Image ID="Image1" runat="server" Height="100" Width="100" />
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
