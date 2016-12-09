﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="house.aspx.cs" Inherits="DomoticaProject.house" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="DaHausScriptManager" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="dingen">
                <h2>Lamps</h2>
                <ul>
                    <li>
                        <label class="switch">
                            <asp:CheckBox ID="lamp0" runat="server" AutoPostBack="true" OnCheckedChanged="LampCheckedChanged" />
                            <span class="slider round"></span>
                        </label>
                    </li>
                    <li>
                        <label class="switch">
                            <asp:CheckBox ID="lamp1" runat="server" AutoPostBack="true" OnCheckedChanged="LampCheckedChanged" />
                            <span class="slider round"></span>
                        </label>
                    </li>
                    <li>
                        <label class="switch">
                            <asp:CheckBox ID="lamp2" runat="server" AutoPostBack="true" OnCheckedChanged="LampCheckedChanged" />
                            <span class="slider round"></span>
                        </label>
                    </li>
                    <li>
                        <label class="switch">
                            <asp:CheckBox ID="lamp3" runat="server" AutoPostBack="true" OnCheckedChanged="LampCheckedChanged" />
                            <span class="slider round"></span>
                        </label>
                    </li>
                    <li>
                        <label class="switch">
                            <asp:CheckBox ID="lamp4" runat="server" AutoPostBack="true" OnCheckedChanged="LampCheckedChanged" />
                            <span class="slider round"></span>
                        </label>
                    </li>
                </ul>
            </div>

            <div class="dingen">
                <h2>Windows</h2>
                <ul>
                    <li>
                        <label class="switch">
                            <asp:CheckBox ID="window0" runat="server" AutoPostBack="true" OnCheckedChanged="WindowCheckedChanged" />
                            <span id="window0span" runat="server" class="slider round"></span>
                        </label>
                    </li>
                    <li>
                        <label class="switch">
                            <asp:CheckBox ID="window1" runat="server" AutoPostBack="true" OnCheckedChanged="WindowCheckedChanged" />
                            <span id="window1span" runat="server" class="slider round"></span>
                        </label>
                    </li>
                </ul>
            </div>

            <div class="dingen">
                <h2>Heater</h2>
                <ul>
                    <li>
                        <asp:TextBox ID="txt_heater" runat="server"></asp:TextBox>
                        <asp:Button ID="btn_sendHeater" runat="server" Text="Change" OnClick="btn_sendHeater_Click" />
                    </li>
                    <li>
                        <asp:RangeValidator runat="server" ErrorMessage="Geef een waarde tussen 12 en 35." ID="degreeValidator" ControlToValidate="txt_heater" MaximumValue="35" MinimumValue="12" Display="Dynamic"></asp:RangeValidator>
                    </li>
                </ul>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
