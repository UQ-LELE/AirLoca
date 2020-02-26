<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestRandomItem.aspx.cs" Inherits="AirLoca.TestRandomItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListView1" runat="server">
        <ItemTemplate>
            <asp:Image ID="Image1" runat="server" src='<%#Eval("Photo") %>' />
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
