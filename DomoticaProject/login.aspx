﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DomoticaProject.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID = "debug"  runat = "server"> </asp:Label>
    <div class="row">
    <div class="col-xs-12 col-lg-4 col-lg-offset-4" id="field1" ondrop="drop(event)" ondragover="allowDrop(event)">
    <div id="panellogin" class="panel panel-default" draggable="false" ondragstart="drag(event)">
        <div class="panel-body">
            <h2>Log in</h2>
            <div class="form-group">
                <label for="UserName">User Name (email adres):</label>
                <asp:TextBox runat="server" ID="UserName" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ValidationGroup="login_field" ToolTip="User Name is required." ID="UserNameRequired">*</asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="Password">Password:</label>
                <asp:TextBox runat="server" TextMode="Password" ID="Password" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ValidationGroup="login_field" ToolTip="Password is required." ID="PasswordRequired">*</asp:RequiredFieldValidator>
            </div>
            <div class="">
                <a href="register.aspx">Nog geen account?</a>
            </div>
            <div>
                <asp:Literal runat="server" ID="FailureText" EnableViewState="False"></asp:Literal>
            </div>
            <div>
                <asp:Button runat="server" CommandName="Login" Text="Log In" ValidationGroup="login_field" ID="LoginButton" OnClick="LoginButton_Click" CssClass="btn btn-default"></asp:Button>
            </div>
        </div>
    </div>
    </div><!--/.col-xs-6.col-lg-4-->
</div><!--/row-->
</asp:Content>
