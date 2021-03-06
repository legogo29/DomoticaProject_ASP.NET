﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="house.aspx.cs" Inherits="DomoticaProject.house" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="DaHausScriptManager" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-xs-6 col-lg-3" id="field1" ondrop="drop(event)" ondragover="allowDrop(event)">
                    <div id="panel1" class="panel panel-default dingen" draggable="false" ondragstart="drag(event)">
                        <i class="fa fa-lightbulb-o" aria-hidden="true"></i>
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
                </div>

                <div class="col-xs-6 col-lg-3" id="field2" ondrop="drop(event)" ondragover="allowDrop(event)">
                    <div id="panel2" class="panel panel-default dingen" draggable="false" ondragstart="drag(event)">
                        <i class="fa fa-window-maximize" aria-hidden="true"></i>
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
                </div>

                <div class="col-xs-6 col-lg-3" id="field3" ondrop="drop(event)" ondragover="allowDrop(event)">
                    <div id="panel3" class="panel panel-default dingen" draggable="false" ondragstart="drag(event)">
                        <i class="fa fa-fire" aria-hidden="true"></i>
                        <h2>Heater</h2>
                        <ul>
                            <li>
                                <asp:TextBox ID="txt_heater" runat="server"></asp:TextBox>
                                <asp:Button ID="btn_sendHeater" runat="server" Text="Change" OnClick="btn_sendHeater_Click" />
                            </li>
                            <li>
                                <asp:RangeValidator runat="server" ErrorMessage="Geef een waarde tussen 12 en 35." ID="degreeValidator" ControlToValidate="txt_heater" MaximumValue="35" MinimumValue="12" Display="Dynamic" Type="String"></asp:RangeValidator>
                            </li>
                            <li>
                                <asp:RegularExpressionValidator ID="degreeRegexValidator" runat="server" ErrorMessage="Het getal is niet in het juiste formaat." ControlToValidate="txt_heater" ValidationExpression="^[0-9]+((\,)[0-9]*|(\.)[0-9]*)?$"></asp:RegularExpressionValidator>
                            </li>
                        </ul>
                    </div>
                </div>
                <asp:Label ID="connectionStatus" runat="server"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
