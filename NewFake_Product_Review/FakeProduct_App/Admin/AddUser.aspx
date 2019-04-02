<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="FakeProduct_App.Admin.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1>Add User
        <small>Control panel</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="index.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">View User</li>
        </ol>
    </section>
    <section class="content">
        <!-- Small boxes (Stat box) -->
        <div class="row">
            <div class="col-md-6">
                <!-- general form elements -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">View User</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->

                    <div class="box-body">
                        <div class="form-group">
                            <label for="exampleInputEmail1">Username</label>
                            <asp:TextBox ID="txtUsername" class="form-control" placeholder="Username" runat="server" required></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Password</label>
                            <asp:TextBox ID="txtPassword" TextMode="Password" class="form-control" placeholder="Password" runat="server" required></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Full Name</label>
                            <asp:TextBox ID="txtName" class="form-control" placeholder="Product Name" runat="server" required></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Email</label>
                            <asp:TextBox ID="txtEmail" type="email" class="form-control" placeholder="Email" runat="server" required></asp:TextBox>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter valid EmailID" CssClass="requiredFieldValidateStyle"
                                        ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Contact Number</label>
                            <asp:TextBox ID="txtContact" class="form-control" placeholder="Contact" pattern="[0-9]{10}" runat="server" required></asp:TextBox>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContact" ErrorMessage="Enter valid Contact No"
                                        CssClass="requiredFieldValidateStyle"
                                        ForeColor="Red" ValidationExpression="^([0-9\(\)\/\+ \-]*)$"></asp:RegularExpressionValidator>
                                    <asp:RegularExpressionValidator ID="revMobNo" runat="server" ErrorMessage="Invalid Contact Number."
                                        ValidationExpression="^([0-9]{10})$" ControlToValidate="txtContact" ValidationGroup="Validate"
                                        ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Address</label>
                            <asp:TextBox ID="txtAddress" class="form-control" placeholder="Address" runat="server" required></asp:TextBox>
                        </div>
                       <%-- <div class="form-group">
                            <label for="exampleInputEmail1">Select Status</label>
                            <asp:DropDownList ID="ddlStatus" class="form-control" runat="server">
                                <asp:ListItem Value="0">Block</asp:ListItem>
                                <asp:ListItem Value="1">Unblock</asp:ListItem>
                            </asp:DropDownList>
                        </div>--%>
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
