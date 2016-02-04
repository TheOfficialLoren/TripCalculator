<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TripCalculator.UI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Trip Caclulator</h2>
            <asp:Label runat="server" ID="lblError" ForeColor="red"/>
        </div>
    </div>

</asp:Content>
