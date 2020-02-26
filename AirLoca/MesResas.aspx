<%@ Page Title="" Language="C#" MasterPageFile="~/BackOffice.Master" AutoEventWireup="true" CodeBehind="MesResas.aspx.cs" Inherits="AirLoca.MesResas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <article class="box">
                <nav class="navbar-expand-md ">
                    <ul class="nav nav-tabs bg-light mb-3" role="tablist">

                        <li class="nav-item">
                            <a class="nav-link <%=TabReservation %>" data-toggle="pill" href="#nav-tab-reservation">Mes Réservations</a></li>

                        <li class="nav-item">
                            <a class="nav-link  <%=TabHistoResa %>" data-toggle="pill" href="#nav-tab-Historique">Historique</a></li>
                    </ul>
                </nav>

                <div class="tab-content">
                    <!-- tab-pane reservation.// -->
                    <div class="tab-pane fade show <%=TabReservation %>" id="nav-tab-reservation">

                        <div id="NoResa" runat="server" visible="false">
                            <h5>
                                <label>Pas de réservation à venir</label></h5>
                            <hr />
                            <p>Agitationibus summum sub collis vestium ponentes effigiatae ut expandentes perflabiles altioribus animalium longiores vestium vestium et vestium longiores quas nimia quas quas fimbriae ambitioso species ut ponderibus agitationibus cingulis ut.</p>
                            <hr />
                            <a href="ListHebergement.aspx" class="btn btn-primary" role="button" />Chercher un hébergement</a>
                        </div>

                        <div id="WithResa" runat="server" visible="false">
                            <h4>
                                <label>Vos réservations à venir : </label>
                            </h4>
                            <hr />
                            <asp:ListView ID="lvwReservation" runat="server" OnItemDataBound="lvwReservation_ItemDataBound">
                                <ItemTemplate>
                                    <div class="simpleBox mb-3">
                                        <div class=" flex-container align-items-center ">
                                            <div class="flex-item">

                                                <div class="d-flex flex-row justify-content-between flex-wrap mb-2">
                                                    <div>
                                                        <h4><strong><%#Eval("Nom") %></strong></h4>
                                                    </div>
                                                </div>
                                                <hr />
                                                <div class="mb-2 py-2 text-justify"><%#Eval("Description") %></div>
                                                <div class="d-flex flex-column flex-wrap">
                                                    <div>
                                                        <p><span class="fas fa-home"></span><strong>&nbsp;&nbsp;Type d'hébergement :&nbsp;&nbsp;</strong><%#Eval("Type")%></p>
                                                    </div>
                                                    <div>
                                                        <p><span class="fas fa-map-marker-alt"></span><strong>&nbsp;&nbsp;Localisation :&nbsp;&nbsp;</strong><%#Eval("Adresse.Numero")%> <%#Eval("Adresse.Voie")%>,  <%#Eval("Adresse.Ville")%> (<%#Eval("Adresse.CodePostal")%>)</p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="flex-image pl-3">
                                                <a href='<%#Eval("Photo") %>' data-lightbox="image-1" data-title='<%#Eval("Nom") %>'>
                                                    <asp:Image ID="Image1" runat="server" src='<%#Eval("Photo") %>' CssClass="img-fluid myImg" /></a>
                                            </div>
                                        </div>
                                        <hr />
                                        <div class="d-flex flex-row justify-content-between">
                                            <div class="d-flex flex-column align-content-between">
                                                <div>
                                                    <p><strong>Date d'arrivée :&nbsp;&nbsp;</strong><%#String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"),"{0:d MMM yyyy}",Eval("Reservation.DateDebut"))%></p>
                                                </div>
                                                <div>
                                                    <p><strong>Date de départ :&nbsp;&nbsp;</strong><%#String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"),"{0:d MMM yyyy}",Eval("Reservation.DateFin"))%></p>
                                                </div>
                                            </div>
                                            <div class="d-flex flex-column align-content-between">
                                                <div>
                                                    <p><strong>Prix Total :&nbsp;&nbsp;</strong><%#Eval("Reservation.PrixTotal") %> € TTC</p>
                                                </div>
                                                <div>
                                                    <p><strong>prix par nuit :&nbsp;&nbsp;</strong><%#Eval("PrixDeBase") %> € TTC</p>
                                                </div>
                                            </div>
                                        </div>
                                        <hr />
                                        <div class="d-flex flex-row justify-content-between flex-wrap pb-3">
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#Message" onclick='sendModal(<%#Eval("IdClient") %>,<%#Eval("IdHebergement") %> )'><span class="far fa-envelope"></span>&nbsp;&nbsp;Contacter</button>
                                                <asp:LinkButton ID="lbtFavorisResa" runat="server" CommandArgument='<%#Eval("IdHebergement")%>' OnClick="lbtFavorisResa_Click" CssClass="btn btn-outline-warning" Enabled="true"><span class="far fa-heart"></span></asp:LinkButton>
                                            </div>

                                            <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#AnnulerResa" onclick='openModal(<%#Eval("Reservation.IdReservation") %>)'>Annuler</button>
                                        </div>

                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </div>

                    <!-- tab-pane HistoResa.// -->
                    <div class="tab-pane fade show <%=TabHistoResa %>" id="nav-tab-Historique">
                        <h4>
                            <label>Retrouvez l'historique de vos réservations : </label>
                        </h4>
                        <hr />
                        <asp:ListView ID="lvwHistoResa" runat="server">
                            <ItemTemplate>
                                <div class="simpleBox mb-3">
                                    <div class=" flex-container align-items-center ">
                                        <div class="flex-item">

                                            <div class="d-flex flex-row justify-content-between flex-wrap mb-2">
                                                <div>
                                                    <h4><strong><%#Eval("Nom") %></strong></h4>
                                                </div>
                                            </div>
                                            <hr />
                                            <div class="mb-2 py-2 text-justify"><%#Eval("Description") %></div>
                                            <div class="d-flex flex-column flex-wrap">
                                                <div>
                                                    <p><span class="fas fa-home"></span><strong>&nbsp;&nbsp;Type d'hébergement :&nbsp;&nbsp;</strong><%#Eval("Type")%></p>
                                                </div>
                                                <div>
                                                    <p><span class="fas fa-map-marker-alt"></span><strong>&nbsp;&nbsp;Localisation :&nbsp;&nbsp;</strong><%#Eval("Adresse.Numero")%> <%#Eval("Adresse.Voie")%>,  <%#Eval("Adresse.Ville")%> (<%#Eval("Adresse.CodePostal")%>)</p>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="flex-image pl-3">
                                            <a href='<%#Eval("Photo") %>' data-lightbox="image-1" data-title='<%#Eval("Nom") %>'>
                                                <asp:Image ID="Image1" runat="server" src='<%#Eval("Photo") %>' CssClass="img-fluid myImg" /></a>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="d-flex flex-row justify-content-between">
                                        <div class="d-flex flex-column align-content-between">
                                            <div>
                                                <p><strong>Date d'arrivée :&nbsp;&nbsp;</strong><%#String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"),"{0:ddd d MMM}",Eval("Reservation.DateDebut"))%></p>
                                            </div>
                                            <div>
                                                <p><strong>Date de départ :&nbsp;&nbsp;</strong><%#String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"),"{0:ddd d MMM}",Eval("Reservation.DateFin"))%></p>
                                            </div>
                                        </div>
                                        <div class="d-flex flex-column align-content-between">
                                            <div>
                                                <p><strong>Prix Total :&nbsp;&nbsp;</strong><%#Eval("Reservation.PrixTotal") %> € TTC</p>
                                            </div>
                                            <div>
                                                <p><strong>prix par nuit :&nbsp;&nbsp;</strong><%#Eval("PrixDeBase") %> € TTC</p>
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="d-flex flex-row justify-content-between flex-wrap pb-3">
                                        <div class="btn-group">
                                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#Message" onclick='sendModal(<%#Eval("IdHebergement") %>)'><span class="far fa-envelope"></span>&nbsp;&nbsp;Contacter</button>
                                            <asp:LinkButton ID="lbtFavorisResa" runat="server" CommandArgument='<%#Eval("IdHebergement")%>' OnClick="lbtFavorisResa_Click" CssClass="btn btn-outline-warning" Enabled="true"><span class="far fa-heart"></span></asp:LinkButton>
                                        </div>

                                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#Avis" onclick='commentModal(<%#Eval("IdHebergement") %>)'><span class="far fa-comment-alt"></span>&nbsp;&nbsp;Avis</button>

                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                    <!-- tab-content .// -->
                </div>
                <!-- card-body.// -->
            </article>

            <!-- Modal cancel Resa-->
            <div class="modal fade" id="AnnulerResa" tabindex="-1" role="dialog" aria-labelledby="Annuler ma réservetion" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="ModalLongTitle">Annulation de votre réservation :</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            Voulez-vous annuler cette réservation ?
                        </div>
                        <div class="modal-footer">
                            <asp:HiddenField ID="cancelModal" runat="server" Value="" />
                            <asp:Button ID="btnOkAnnulerResa" runat="server" Text="Confirmer" class="btn btn-danger" OnClick="btnOkAnnulerResa_Click1" />
                            <button type="button" class="btn btn-primary" data-dismiss="modal">Retour</button>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Modal Messagerie -->
            <div class="modal fade" id="Message" tabindex="-1" role="dialog" aria-labelledby="Contacter le propriétaire" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h3 class="modal-title" id="LongTitle"><strong>Message :</strong></h3>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <asp:TextBox ID="txtMessage" runat="server" class="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:HiddenField ID="sendContact" runat="server" Value="" />
                            <asp:HiddenField ID="sendHebergement" runat="server" Value="" />
                            <button type="button" class="btn btn-primary" data-dismiss="modal">Retour</button>
                            <asp:Button ID="btnEnvoyer" runat="server" Text="Envoyer" class="btn btn-success ml-auto" OnClick="btnEnvoyer_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <!-- Modal Avis -->
            <div class="modal fade" id="Avis" tabindex="-1" role="dialog" aria-labelledby="Donnez votre avis" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h3 class="modal-title" id="Title"><strong>Donnez votre avis :</strong></h3>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <asp:TextBox ID="txtAvis" runat="server" class="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox>
                            </div>
                            <hr />
                            <input id="rating-system" type="number" class="rating" min="1" max="5" step="1">
                        </div>
                        <div class="modal-footer">
                            <asp:HiddenField ID="sendClient" runat="server" Value="" />
                            <asp:HiddenField ID="sendIdHeb" runat="server" Value="" />
                            <button type="button" class="btn btn-primary" data-dismiss="modal">Retour</button>
                            <asp:Button ID="btnAvis" runat="server" Text="Commenter" class="btn btn-success ml-auto" OnClick="btnAvis_Click" />
                        </div>
                    </div>
                </div>
            </div>



            <script type="text/javascript">
                function openModal(idReservation) {
                    $('#<%=this.cancelModal.ClientID%>').val(idReservation);
                }

                function sendModal(idContact, idHebergement) {
                    $('#<%=this.sendContact.ClientID%>').val(idContact);
                    $('#<%=this.sendHebergement.ClientID%>').val(idHebergement);

                }

                function commentModal(idHebergement) {
                    $('#<%=this.sendIdHeb.ClientID%>').val(idHebergement);

                }

            </script>

        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="Scripts/lightbox.js"></script>
</asp:Content>
