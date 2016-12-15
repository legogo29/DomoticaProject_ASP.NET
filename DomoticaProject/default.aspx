<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DomoticaProject._default" %>
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
            Temprature: <span id="temp"></span>&#176;C<br />
            Humidity: <span id="hum"></span>%<br />
        </p>
        </div>
        <script>
            loadTH();
            function loadTH() {
                loadDoc("1", setTemp);
                //loadDoc("0", setSlider);
            }
            function loadDoc(url, cFunction) {
                var xhttp = new XMLHttpRequest();
                xhttp.onreadystatechange = function () {
                    if (this.readyState == 4 && this.status == 200) {
                        cFunction(this);
                    }
                }
                xhttp.open("GET", "api/values/" + url, true);
                xhttp.setRequestHeader('Accept', 'application/json; charset=utf-8');
                xhttp.send();
            }
            function setTemp(xhttp) {
                var items = xhttp.responseText.replace(/"/g, '').split("+"); //regex to remove the " on the front and end of the string
                document.getElementById("temp").innerHTML = items[0];//.replace('"', '');//.replace('"', '');
                document.getElementById("hum").innerHTML = items[1];//.replace('"', '').replace('"', '');
                var value = [false, false, false];
                if (items[2] >> 2 == 1) value[0] = true;
                if (items[2] >> 1 & 1 == 1) value[1] = true;
                if (items[2] & 1 == 1) value[2] = true;
                document.getElementById("ContentPlaceHolder1_SlideBoxPanel2_1").checked = value[0];
                document.getElementById("ContentPlaceHolder1_SlideBoxPanel2_2").checked = value[1];
                document.getElementById("ContentPlaceHolder1_SlideBoxPanel2_3").checked = value[2];
            }
            setInterval(loadTH, 1000);
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
