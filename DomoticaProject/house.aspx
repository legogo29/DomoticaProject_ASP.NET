<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="house.aspx.cs" Inherits="DomoticaProject.house" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    aaa
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Lampen</h2>
        <ul>
            <li>
                <label class="lampName">Lamp 0</label>
                <label class="switch">
                    <input type="checkbox" />
                    <div class="slider round"></div>
                </label>
            </li>
            <li>
                <label>Lamp 1</label>
                <label class="switch">
                    <input type="checkbox" />
                    <div class="slider round"></div>
                </label>
            </li>
            <li>
                <label>Lamp 2</label>
                <label class="switch">
                    <input type="checkbox" />
                    <div class="slider round"></div>
                </label>
            </li>
            <li>
                <label>Lamp 3</label>
                <label class="switch">
                    <input type="checkbox" />
                    <div class="slider round"></div>
                </label>
            </li>
            <li>
                <label>Lamp 4</label>
                <label class="switch">
                    <input type="checkbox" />
                    <div class="slider round"></div>
                </label>
            </li>
        </ul>
    </div>
</asp:Content>
