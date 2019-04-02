<%@ Page Title="" Language="C#" MasterPageFile="~/User/Site1.Master" AutoEventWireup="true" CodeBehind="CompareGraph.aspx.cs" Inherits="FakeProduct_App.User.WebForm7" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="text-align: center">
        <h2>Compare Graph of 1st Technique Output & 2nd Technique Output</h2>
    </div>
    <br />
    <%--<div>
        <h3>1st Technique Output Average = 
            <asp:Label ID="lbl1st" runat="server" Text=""></asp:Label></h3>
        <br />
        <h3>2st Technique Output Average =
            <asp:Label ID="lbl2nd" runat="server" Text="Label"></asp:Label></h3>
    </div>--%>

    <div style="margin-left: 700px; height: 512px;">
        <asp:Chart ID="Chart1" runat="server" Height="449px" Width="523px">
            <Series>
                <asp:Series Name="Series1" IsValueShownAsLabel="true"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
</asp:Content>
