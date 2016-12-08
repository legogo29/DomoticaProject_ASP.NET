﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="house.aspx.cs" Inherits="DomoticaProject.house" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Lamps</h2>
        <ul>
            <li>
                <label>Lamp 0</label>
                <label class="switch">
                    <asp:CheckBox ID="lamp0" runat="server" AutoPostBack="true" OnCheckedChanged="LampCheckedChanged" />
                    <span class="slider round"></span>
                </label>
            </li>
            <li>
                <label>Lamp 1</label>
                <label class="switch">
                    <asp:CheckBox ID="lamp1" runat="server" AutoPostBack="true" OnCheckedChanged="LampCheckedChanged" />
                    <span class="slider round"></span>
                </label>
            </li>
            <li>
                <label>Lamp 2</label>
                <label class="switch">
                    <asp:CheckBox ID="lamp2" runat="server" AutoPostBack="true" OnCheckedChanged="LampCheckedChanged" />
                    <span class="slider round"></span>
                </label>
            </li>
            <li>
                <label>Lamp 3</label>
                <label class="switch">
                    <asp:CheckBox ID="lamp3" runat="server" AutoPostBack="true" OnCheckedChanged="LampCheckedChanged" />
                    <span class="slider round"></span>
                </label>
            </li>
            <li>
                <label>Lamp 4</label>
                <label class="switch">
                    <asp:CheckBox ID="lamp4" runat="server" AutoPostBack="true" OnCheckedChanged="LampCheckedChanged" />
                    <span class="slider round"></span>
                </label>
            </li>
        </ul>
    </div>

    <br />

    <div>
        <h2>Windows</h2>
        <ul>
            <li>
                <label>Window 0</label>
                <label class="switch">
                    <asp:CheckBox ID="window0" runat="server" AutoPostBack="true" OnCheckedChanged="WindowCheckedChanged" />
                    <span id="window0span" runat="server" class="slider round"></span>
                </label>
            </li>
            <li>
                <label>Window 1</label>
                <label class="switch">
                    <asp:CheckBox ID="window1" runat="server" AutoPostBack="true" OnCheckedChanged="WindowCheckedChanged" />
                    <span  id="window1span" runat="server" class="slider round"></span>
                </label>
            </li>
        </ul>
    </div>

    <br />

    <div>
        <h2>Heater</h2>
        <ul>
            <li>
                <label>Heater 0</label>
                <asp:TextBox ID="txt_heater" runat="server"></asp:TextBox>
                <asp:Button ID="btn_sendHeater" runat="server" Text="Button" OnClick="btn_sendHeater_Click" />
                <asp:RangeValidator runat="server" ErrorMessage="Geef een waarde tussen 12 en 35." ID="degreeValidator" ControlToValidate="txt_heater" MaximumValue="35" MinimumValue="12" Display="Dynamic"></asp:RangeValidator>
            </li>
        </ul>
    </div>
</asp:Content>
