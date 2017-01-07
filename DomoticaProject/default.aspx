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
            setInterval(loadTH, 1000);
            loadTH();
            function loadTH() {
                loadDoc("1", setTemp);
            }
            function setTemp(xhttp) {
                checkbox = [document.getElementById("SlideBoxPanel2_1"), document.getElementById("SlideBoxPanel2_2"), document.getElementById("SlideBoxPanel2_3")]; //this is a global variable

                var items = xhttp.responseText.replace(/"/g, '').split("+"); //regex to remove the " on the front and end of the string
                document.getElementById("temp").innerHTML = items[0];
                document.getElementById("hum").innerHTML = items[1];
                if (items[2] >> 2 == 1) checkbox[0].checked;
                if (items[2] >> 1 & 1 == 1) checkbox[1].checked;
                if (items[2] & 1 == 1) checkbox[2].checked;
            }

            function sendSwitches() {
                //var checkbox = [document.getElementById("SlideBoxPanel2_1"), document.getElementById("SlideBoxPanel2_2"), document.getElementById("SlideBoxPanel2_3")];
                var lampByte = 0; // 00000000
                if (checkbox[0].checked) lampByte |= 1 << 2; // 00000100
                if (checkbox[1].checked) lampByte |= 1 << 1; // 00000010
                if (checkbox[2].checked) lampByte |= 1 << 0; // 00000001
                loadDoc("1?lamp=" + lampByte); // JS doesnt care about amount of arguments given, not given == null
            }
        </script>
    </div>
    </div><!--/.col-xs-6.col-lg-4-->
    <div class="col-xs-6 col-lg-4" id="field2" ondrop="drop(event)" ondragover="allowDrop(event)">
    <div id="panel2" class="panel panel-default" draggable="false" ondragstart="drag(event)">
        <div class="panel-body">
        <h2>Heading 2</h2>
        <label class="switch">
            <input id="SlideBoxPanel2_1" type="checkbox" onclick="sendSwitches()" />
            <span class="slider"></span>
        </label>
        <label class="switch">
            <input id="SlideBoxPanel2_2" type="checkbox" onclick="sendSwitches()" />
            <span class="slider"></span>
        </label>
        <label class="switch">
            <input id="SlideBoxPanel2_3" type="checkbox" onclick="sendSwitches()" />
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
