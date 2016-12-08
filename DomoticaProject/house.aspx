<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="house.aspx.cs" Inherits="DomoticaProject.house" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Lamps</h2>
        <ul>
            <li>
                <label>Lamp 0</label>
                <label class="switch">
                    <asp:CheckBox ID="lamp0" runat="server" />
                    <span class="slider round"></span>
                </label>
            </li>
            <li>
                <label>Lamp 1</label>
                <label class="switch">
                    <input id="lamp1" runat="server" type="checkbox" />
                    <span class="slider round"></span>
                </label>
            </li>
            <li>
                <label>Lamp 2</label>
                <label class="switch">
                    <input id="lamp2" runat="server" type="checkbox" />
                    <span class="slider round"></span>
                </label>
            </li>
            <li>
                <label>Lamp 3</label>
                <label class="switch">
                    <input id="lamp3" runat="server" type="checkbox" />
                    <span class="slider round"></span>
                </label>
            </li>
            <li>
                <label>Lamp 4</label>
                <label class="switch">
                    <input id="lamp4" runat="server" type="checkbox" />
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
                    <input id="window0" runat="server" type="checkbox" />
                    <span id="window0span" runat="server" class="slider round"></span>
                </label>
            </li>
            <li>
                <label>Window 1</label>
                <label class="switch">
                    <input id="window1" runat="server" type="checkbox" />
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
                <label runat="server" id="heater"></label>
            </li>
        </ul>
    </div>
</asp:Content>
