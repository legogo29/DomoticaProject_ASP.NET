<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="settings.aspx.cs" Inherits="DomoticaProject.settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Settings</h1>
    Style: 
    <asp:DropDownList ID="DDL_basestyle" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_basestyle_SelectedIndexChanged">
        <asp:ListItem Text="Bootstrap" Selected="True" />
        <asp:ListItem Text="Max"/>
        <asp:ListItem Text="Tim"/>
    </asp:DropDownList>
</asp:Content>
