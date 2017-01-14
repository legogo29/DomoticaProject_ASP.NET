<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="settings.aspx.cs" Inherits="DomoticaProject.settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Settings</h1>
    <div class="form-group">
        <label>style</label>
        <asp:DropDownList ID="DDL_basestyle" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_basestyle_SelectedIndexChanged" CssClass="form-control">
            <asp:ListItem Text="Bootstrap" Selected="True" />
            <asp:ListItem Text="Max" />
            <asp:ListItem Text="Tim" />
            <asp:ListItem Text="Paper" />
            <asp:ListItem Text="Superhero" />
            <asp:ListItem Text="Darkly" />
            <asp:ListItem Text="Flatly" />
        </asp:DropDownList>
    </div><div class="form-group">
        <label>Bar Color</label>
        <div class="radio">
          <label>
            <input type="radio" name="optionsRadios" id="navRadios1" value="option1" onclick="setCookie('navCookie', '0'); readcookie();" />
            <nav class="navbar navbar-default" style="margin-bottom:0px;">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <p class="navbar-brand" style="margin:0px -15px;">Project Domotica</p>
                    </div>
                </div>
            </nav>
          </label>
        </div>
        <div class="radio">
          <label>
            <input type="radio" name="optionsRadios" id="navRadios2" value="option2" onclick="setCookie('navCookie', '1'); readcookie();">
            <nav class="navbar navbar-inverse" style="margin-bottom:0px;">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <p class="navbar-brand" style="margin:0px -15px;">Project Domotica</p>
                    </div>
                </div>
            </nav>
          </label>
        </div>
    </div>
    <script>
        function setCookie(cname, cvalue) {
            var d = new Date();
            d.setTime(d.getTime() + (31536000000)); // one year
            var expires = "expires=" + d.toUTCString();
            document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
        }
    </script>
</asp:Content>
