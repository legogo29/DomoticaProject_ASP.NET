<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="minesweeper.aspx.cs" Inherits="DomoticaProject.games" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
      <div id="MS" class="col-sm-6 col-lg-4">
        <canvas id="minesweeper" height="500px" style="border:1px solid #d3d3d3;">
          Your browser does not support the HTML5 canvas tag.</canvas>
      </div>
    </div>
    <script src="js/MineSweeper.js"></script>
</asp:Content>
