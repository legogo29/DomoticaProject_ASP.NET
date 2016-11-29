<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DomoticaProject._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
    <div class="col-xs-6 col-lg-4" id="field1" ondrop="drop(event)" ondragover="allowDrop(event)">
    <div id="panel1" class="panel panel-default" draggable="true" ondragstart="drag(event)">
        <div class="panel-body">
        <h2>Heading 1</h2>
        <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
        </div>
    </div>
    </div><!--/.col-xs-6.col-lg-4-->
    <div class="col-xs-6 col-lg-4" id="field2" ondrop="drop(event)" ondragover="allowDrop(event)">
    <div id="panel2" class="panel panel-default" draggable="true" ondragstart="drag(event)">
        <div class="panel-body">
        <h2>Heading 2</h2>
        <label class="switch">
            <input type="checkbox">
            <div class="slider"></div>
        </label>
        </div>
    </div>
    </div><!--/.col-xs-6.col-lg-4-->
    <div class="col-xs-6 col-lg-4" id="field3" ondrop="drop(event)" ondragover="allowDrop(event)">
    <div id="panel3" class="panel panel-default" draggable="true" ondragstart="drag(event)">
        <div class="panel-body">
        <h2>Heading 3</h2>
        <h3><img src="resources/OS_Logo.png"/> Open source web platform</h3>
        </div>
    </div>
    </div><!--/.col-xs-6.col-lg-4-->
    <div class="col-xs-6 col-lg-4" id="field4" ondrop="drop(event)" ondragover="allowDrop(event)">
    <div id="panel4" class="panel panel-default" draggable="true" ondragstart="drag(event)">
        <div class="panel-body">
        <h2>Heading 4</h2>
        <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
        </div>
    </div>
    </div><!--/.col-xs-6.col-lg-4-->
    <div class="col-xs-6 col-lg-4" id="field5" ondrop="drop(event)" ondragover="allowDrop(event)">
    <div id="panel5" class="panel panel-default" draggable="true" ondragstart="drag(event)">
        <div class="panel-body">
        <h2>Heading 5</h2>
        <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
        </div>
    </div>
    </div><!--/.col-xs-6.col-lg-4-->
    <div class="col-xs-6 col-lg-4" id="field6" ondrop="drop(event)" ondragover="allowDrop(event)">
    <div id="panel6" class="panel panel-default" draggable="true" ondragstart="drag(event)">
        <div class="panel-body">
        <h2>Heading 6</h2>
        <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
        </div>
    </div>
    </div><!--/.col-xs-6.col-lg-4-->
</div><!--/row-->
</asp:Content>
