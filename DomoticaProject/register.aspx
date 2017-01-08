<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="DomoticaProject.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div>
    
        <asp:Label ID="label_voornaam" runat="server" Text="Voornaam"></asp:Label>
        <asp:TextBox ID="input_voornaam" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="label_achternaam" runat="server" Text="Achternaam"></asp:Label>
        <asp:TextBox ID="input_achternaam" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="label_email" runat="server" Text="E-mail"></asp:Label>
        <asp:TextBox ID="input_email" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="input_email" ErrorMessage="Geef een geldige email, alstublieft" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,63})+)$"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="label_wachtwoord" runat="server" Text="Wachtwoord"></asp:Label>
        <input id="input_password" type="password" runat="server"/><br />
        <asp:Label ID="label_displayname" runat="server" Text="Display name"></asp:Label>
        <asp:TextBox ID="input_displayname" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="button" runat="server" Text="Verstuur" OnClick="button_Click"  />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>

</asp:Content>
