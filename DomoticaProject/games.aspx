<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="games.aspx.cs" Inherits="DomoticaProject.games1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class = "container">
        <div class = "row">
            <div class = "col-xs-6" style = "border-right: 1px solid black;">
                <a href = "swaggybird.aspx">
                    <img src ="/images/swaggy_bird_logo.png" />
                </a> 
                    <asp:Label ID = "sb_label" runat = "server"> </asp:Label>

		         <div>
        
                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="email" DataSourceID="AccessDataSource1" CssClass="table" GridLines ="Both" BorderStyle="Solid">
                 <Columns>
                     <asp:BoundField DataField="email" HeaderText="email" InsertVisible="False" ReadOnly="True" SortExpression="email" />
                     <asp:BoundField DataField="score" HeaderText="score" SortExpression="score" />
                 </Columns>
                        <HeaderStyle BorderStyle="Solid" CssClass="table" />
                        <RowStyle BorderStyle="Solid" CssClass="table" />
                   </asp:GridView>
                <br />
                    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/pd_database.accdb" SelectCommand="SELECT TOP 10 [score], [email] FROM [speelt] WHERE [spel_id ]= 1 ORDER BY [score] DESC; "></asp:AccessDataSource>
        
                </div>    


            </div>

            <div class = "col-xs-6">
                <a href = "minesweeper.aspx">
                    <img src ="/images/minesweeper_logo.png" />
                </a>
                <br />
                <br />
                <br />
                    <asp:Label ID = "ms_label" runat = "server">  </asp:Label>

		         <div>
        
                    <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="email" DataSourceID="AccessDataSource2" CssClass ="table" GridLines ="Both" BorderStyle= "Solid">
                 <Columns>
                     <asp:BoundField DataField="email" HeaderText="email" InsertVisible="False" ReadOnly="True" SortExpression="email" />
                     <asp:BoundField DataField="score" HeaderText="score" SortExpression="score" />
                 </Columns>
                        <HeaderStyle BorderStyle="Solid" CssClass="table" />
                        <RowStyle BorderStyle="Solid" CssClass="table" />
                   </asp:GridView>
                <br />
                    <asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~/App_Data/pd_database.accdb" SelectCommand="SELECT TOP 10 [score], [email] FROM [speelt] WHERE [spel_id ]= 2 ORDER BY [score] ASC; "></asp:AccessDataSource>
        
                </div>    
              

            </div>
        </div>
    </div>



</asp:Content>
