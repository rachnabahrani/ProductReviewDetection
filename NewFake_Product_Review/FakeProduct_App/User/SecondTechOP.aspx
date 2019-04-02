<%@ Page Title="" Language="C#" MasterPageFile="~/User/Site1.Master" AutoEventWireup="true" CodeBehind="SecondTechOP.aspx.cs" Inherits="FakeProduct_App.User.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <%-- <h3>POSITIVE REVIEW AVERAGE :
        <asp:Label ID="lblpos" runat="server" Text=""></asp:Label>
    </h3>--%>
    <br />
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div class="panel panel-default">
                <div class="panel-heading" role="tab" id="headingOne">
                    <h4 class="panel-title">
                        <a class="pa_italic" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                            <i class="fa fa-file-text-o fa-icon" aria-hidden="true"></i><%#Eval("UserName") %> --->   <%#Eval("Prediction") %> <span class="fa fa-angle-down fa-arrow" aria-hidden="true"></span><i class="fa fa-angle-up fa-arrow" aria-hidden="true"></i>
                        </a>
                    </h4>
                    <%--<asp:Label ID="Label1" runat="server" Text="gfgf"></asp:Label>--%>
                </div>

                <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                    <div class="panel-body">

                        <%#Eval("Review") %>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
   <%-- <h3>NEGATIVE REVIEW AVERAGE :
        <asp:Label ID="lblneg" runat="server" Text="Label"></asp:Label>
    </h3>--%>
    <br />
   <%-- <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>
            <div class="panel panel-default">
                <div class="panel-heading" role="tab" id="headingOne">
                    <h4 class="panel-title">
                        <a class="pa_italic" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                            <i class="fa fa-file-text-o fa-icon" aria-hidden="true"></i><%#Eval("UserName") %> <span class="fa fa-angle-down fa-arrow" aria-hidden="true"></span><i class="fa fa-angle-up fa-arrow" aria-hidden="true"></i>
                        </a>
                    </h4>
                   
                </div>

                <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                    <div class="panel-body">

                        <%#Eval("Review") %>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>--%>
</asp:Content>
