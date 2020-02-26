<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestGvwResponsive.aspx.cs" Inherits="AirLoca.TestGvwResponsive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <script type="text/javascript">
        /* Applied Responsive For Grid View using footable js*/
        $(function () {
            $('[id*=GridView1]').footable();
        });
    </script>

    <div class="box">
    <h3><span class="far fa-heart"></span> Mes Favoris</h3>
    <hr/>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        CssClass="footable" Style="max-width: 100%">
        <Columns>          
            <asp:BoundField DataField="Nom" HeaderText="Nom de la location" SortExpression="Nom"
                ItemStyle-Wrap="false" />
            <asp:BoundField DataField="Prix" HeaderText="Prix (€/nuit)" SortExpression="Prix" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
           <asp:TemplateField>
                <ItemTemplate>
                     <a href='<%#Eval("Photo") %>' data-lightbox="image-1" data-title='<%#Eval("Nom") %>'>
                            <asp:Image ID="Image1" runat="server" src='<%#Eval("Photo") %>' CssClass="img-fluid myImg" /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" Text="X" CssClass="btn btn-danger" CommandArgument='<%# Eval("IdHebergement") %>' CommandName='Supprimer' OnClick="btnDelete_Click1" Width="100%" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        </div>
</asp:Content>
