﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DomoticaProject._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
    <div class="col-xs-6 col-lg-4" id="field1" ondrop="drop(event)" ondragover="allowDrop(event)">
    <div id="panel1" class="panel panel-default" draggable="false" ondragstart="drag(event)">
        <div class="panel-body">
        <h2>Heading 1</h2>
        <p>
            Temprature: <span id="temprature"></span><br />
            Humidity: <span id="hum"></span><br />
        </p>
        </div>
        <script>
            function loadTemp() {
                var xhttp = new XMLHttpRequest();
                xhttp.onreadystatechange = function () {
                    if (this.readyState == 4 && this.status == 200) {
                        document.getElementById("temprature").innerHTML = this.responseText;
                    }
                }
                xhttp.open("GET", "api/values/1", true);
                xhttp.send();
            }
            setInterval(loadTemp, 1000);
            function loadHum() {
                var xhttp = new XMLHttpRequest();
                xhttp.onreadystatechange = function () {
                    if (this.readyState == 4 && this.status == 200) {
                        document.getElementById("hum").innerHTML = this.responseText;
                    }
                }
                xhttp.open("GET", "api/values/2", true);
                xhttp.send();
            }
            setInterval(loadHum, 1000);
        </script>
    </div>
    </div><!--/.col-xs-6.col-lg-4-->
    <div class="col-xs-6 col-lg-4" id="field2" ondrop="drop(event)" ondragover="allowDrop(event)">
    <div id="panel2" class="panel panel-default" draggable="false" ondragstart="drag(event)">
        <div class="panel-body">
        <h2>Heading 2</h2>
        <label class="switch">
            <asp:CheckBox ID="SlideBoxPanel2_1" runat="server" OnCheckedChanged="SlideBoxPanel2_CheckedChanged" AutoPostBack="True" />
            <span class="slider"></span>
        </label>
        <label class="switch">
            <asp:CheckBox ID="SlideBoxPanel2_2" runat="server" OnCheckedChanged="SlideBoxPanel2_CheckedChanged" AutoPostBack="True" />
            <span class="slider"></span>
        </label>
        <label class="switch">
            <asp:CheckBox ID="SlideBoxPanel2_3" runat="server" OnCheckedChanged="SlideBoxPanel2_CheckedChanged" AutoPostBack="True" />
            <span class="slider"></span>
        </label>
        </div>
    </div>
    </div><!--/.col-xs-6.col-lg-4-->
    <div class="col-xs-6 col-lg-4" id="field3" ondrop="drop(event)" ondragover="allowDrop(event)">
    <div id="panel3" class="panel panel-default" draggable="false" ondragstart="drag(event)">
        <div class="panel-body">
        <h2>Heading 3</h2>
        <h3><img src="resources/OS_Logo.png"/> Open source web platform</h3>
        </div>
    </div>
    </div><!--/.col-xs-6.col-lg-4-->
    <div class="col-xs-6 col-lg-4" id="field4" ondrop="drop(event)" ondragover="allowDrop(event)">
    <div id="panel4" class="panel panel-default" draggable="false" ondragstart="drag(event)">
        <div class="panel-body">
        <h2>Heading 4</h2>
        <asp:Label ID="Label_panel4" runat="server" Text=""></asp:Label>
        <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
        </div>
    </div>
    </div><!--/.col-xs-6.col-lg-4-->
    <div class="col-xs-6 col-lg-4" id="field5" ondrop="drop(event)" ondragover="allowDrop(event)">
    <div id="panel5" class="panel panel-default" draggable="false" ondragstart="drag(event)">
        <div class="panel-body">
        <h2>Heading 5</h2>
        <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
        </div>
    </div>
    </div><!--/.col-xs-6.col-lg-4-->
    <div class="col-xs-6 col-lg-4" id="field6" ondrop="drop(event)" ondragover="allowDrop(event)">
    <div id="panel6" class="panel panel-default" draggable="false" ondragstart="drag(event)">
        <div class="panel-body">
        <h2>Heading 6</h2>
        <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
        </div>
    </div>
    </div><!--/.col-xs-6.col-lg-4-->
</div><!--/row-->
</asp:Content>
