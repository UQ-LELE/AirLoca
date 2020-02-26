<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailHebergement.aspx.cs" Inherits="AirLoca.DetailHebergement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="box mb-3 p-4">
        <div class=" flex-container align-items-center ">
            <div class="flex-item">

                <div class="d-flex flex-row justify-content-between mb-2">
                    <div>
                        <h4><strong><%=detail.Nom %></strong></h4>
                    </div>
                    <div class="btn-group" style="max-height: 38px;">
                        <asp:Button ID="btnReserver" runat="server" Text="Réserver" CssClass="btn btn-danger" OnClick="btnReserver_Click1" />
                        <asp:LinkButton ID="lbtFavoris" runat="server" OnClick="lbtFavoris_Click" CssClass="btn btn-outline-warning"><span class="far fa-heart"></span></asp:LinkButton>
                    </div>
                </div>
                <hr />
                <div class="mb-2 py-2 text-justify"><%=detail.Description%></div>

                <hr />
                <div class="d-flex flex-row justify-content-between flex-wrap">
                    <div>
                        <p><span class="fas fa-map-marker-alt"></span><strong>&nbsp;&nbsp;Localisation :</strong>&nbsp;&nbsp;<%= detail.Adresse.Ville%> (<%= detail.Adresse.CodePostal%>)</p>
                        <p><span class="fas fa-home"></span><strong>&nbsp;&nbsp;Type d'hébergement :</strong>&nbsp;&nbsp;<%= detail.Type%></p>
                    </div>
                    <div>
                        <h4><span class="badge badge-light"><%=detail.PrixDeBase%> € / nuit</span></h4>
                    </div>
                </div>
            </div>
            <hr />
            <div class="flex-image pl-3">
                <a href='<%=detail.Photo%>' data-lightbox="image-1" data-title='<%=detail.Nom%>'>
                    <asp:Image ID="Image1" runat="server" CssClass="img-fluid myImg" /></a>
            </div>
        </div>

        <div id="NoAvis" runat="server" visible="false" class="ml-3">
            <hr />
            <h5>
                <label>
                    <strong>Commentaires</strong>
                </label>
            </h5>
            <p>Cet hébergement n'a aucun commentaire pour le moment.</p>
        </div>

        <div id="WithAvis" class="mt-3" runat="server" visible="false">
            <hr />
            <div class="d-flex justify-content-between">

                <h5>
                    <label>
                        <strong>Commentaires</strong> ()
                    </label>
                </h5>
                <div class="d-flex mr-5">
                    <h5><strong>Note :</strong></h5>
                    <div class="mx-2">
                        <span class="product-rating">4</span><span>/5</span>
                    </div>
                    <div class="stars">
                        <i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i>
                    </div>
                </div>
            </div>

            <asp:ListView ID="lvwCommentaire" runat="server">
                <ItemTemplate>
                    <hr />
                    <div>
                        <div class="mr-2">
                            <h6>
                                <label>
                                    <strong><%#Eval("Prenom")%> <%#Eval("Nom") %>.</strong><br />
                                    <%#String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"),"{0:MMMMMMM yyyy}",Eval("Date"))%></label></h6>
                        </div>
                        <div class="row mx-3">
                            <div class="col-10">
                                <p class="text-muted"><i><%#Eval("Commentaire") %></i></p>
                                <p class="text-muted ml-2"></p>
                            </div>
                            <div class="col-2">
                                <span class="product-rating"><%#Eval("Note") %></span><span>/5</span>
                                <div class="stars">
                                    <i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

    <script src="Scripts/lightbox.js"></script>
</asp:Content>
