<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DomoticaProject.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
    <div class="col-xs-12 col-lg-4 col-lg-offset-4" id="field1" ondrop="drop(event)" ondragover="allowDrop(event)">
    <div id="panellogin" class="panel panel-default" draggable="true" ondragstart="drag(event)">
        <div class="panel-body">
        <h2>Log in</h2>
        <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
        <form id="app-login">
        <fieldset>
        <legend>Login Details</legend>
        <div>
            <label for="user-name">Username:</label>
            <input name="user-name" type="email" placeholder="Your username is your email address" required autofocus>

        </div>
        <div>
            <label for="password">Password:</label>
            <input name="password" type="password" placeholder="6 digits, a combination of numbers and letters" required>
        </div>
        <div>
            <input name="login" type="submit" value="Login">
        </div>
        </fieldset>
        </form>
        </div>
    </div>
    </div><!--/.col-xs-6.col-lg-4-->
</div><!--/row-->
</asp:Content>
