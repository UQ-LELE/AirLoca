<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AirLoca._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="flex-container">
        <div class="box flex-container flex-column m-3">
            <h3>Prenez l'air et trouvez une location en France :</h3>
            <div class="form-group p-2">
                <label>Type d'hébergement :</label>

                <asp:DropDownList ID="ddlTypeHebergement" runat="server" CssClass="form-control" ValidationGroup="recherche">
                    <asp:ListItem Value="" Text="Type d'hebergement">Type d'hebergement</asp:ListItem>
                    <asp:ListItem Value="Appartement" Text="Appartement"></asp:ListItem>
                    <asp:ListItem Value="Cabane" Text="Cabane"></asp:ListItem>
                    <asp:ListItem Value="Chalet" Text="Chalet"></asp:ListItem>
                    <asp:ListItem Value="Chambre" Text="Chambre"></asp:ListItem>
                    <asp:ListItem Value="Gite" Text="Gite"></asp:ListItem>
                    <asp:ListItem Value="Loft" Text="Loft"></asp:ListItem>
                    <asp:ListItem Value="Maison" Text="Maison"></asp:ListItem>
                    <asp:ListItem Value="Studio" Text="Studio"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group p-2">
                <label>Département :</label>

                <asp:DropDownList ID="ddlDepartements" class="form-control" runat="server" AppendDataBoundItems="true" ValidationGroup="recherche">
                    <asp:ListItem Text="Departement" Value="" />
                </asp:DropDownList>
            </div>

            <div class="form-group px-2">
                <asp:Button ID="btnRechercher" runat="server" Text="Rechercher" CssClass="btn btn-danger pull-right" ValidationGroup="recherche" OnClick="btnRechercher_Click" />
            </div>

        </div>


        <div class="carroussel m-3">
            <div id="carousel" class="carousel slide" data-ride="carousel">
                <ol class='carousel-indicators'>
                    <li data-target="#carousel" data-slide-to="0" class="active"></li>
                    <li data-target="#carousel" data-slide-to="1"></li>
                    <li data-target="#carousel" data-slide-to="2"></li>
                </ol>

                <div class="carousel-inner">
                    <asp:Literal ID="ltrCarousel" runat="server"></asp:Literal>
                </div>


                <a class="carousel-control-prev" href="#carousel" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Précédent</span>
                </a>
                <a class="carousel-control-next" href="#carousel" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Suivant</span>
                </a>
            </div>
        </div>
    </div>

</asp:Content>
