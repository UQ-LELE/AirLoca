<%@ Page Title="" Language="C#" MasterPageFile="~/BackOffice.Master" AutoEventWireup="true" CodeBehind="MesReservation.aspx.cs" Inherits="AirLoca.MesReservation" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <article class="card">
                <div class="card-body p-5">

                    <ul class="nav bg-light nav-pills rounded nav-fill mb-3" role="tablist">
                        <li class="nav-item">
                            <a class="nav-link  <%=TabReservation %>" data-toggle="pill" href="#nav-tab-reservation">
                                <i class="fa fa-credit-card"></i>Mes réservations</a></li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="pill" href="#nav-tab-historique">
                                <i class="fab fa-paypal"></i>Historique</a></li>
                    </ul>

                    <div class="tab-content">
                        <!-- tab-Reservation.// -->

                        <div class="tab-pane fade show <%=TabReservation %>" id="nav-tab-reservation">
                            <div class="box">
                                <h4>
                                    <label>Mes réservation en cours :</label></h4>
                                <hr />
                                <div id="NoResa" runat="server" visible="false">
                                    <h5>Pas de réservation à venir</h5>
                                    <p>Agitationibus summum sub collis vestium ponentes effigiatae ut expandentes perflabiles altioribus animalium longiores vestium vestium et vestium longiores quas nimia quas quas fimbriae ambitioso species ut ponderibus agitationibus cingulis ut.</p>
                                </div>

                                <div id="WithResa" runat="server" visible="false">
                                    <asp:ListView ID="lvwReservation" runat="server">
                                        <ItemTemplate>
                                            <div class="simpleBox mb-3">

                                                <div class=" flex-container align-items-center ">
                                                    <div class="flex-item">

                                                        <div class="d-flex flex-row justify-content-between flex-wrap mb-2">
                                                            <div>
                                                                <asp:LinkButton ID="lbtNom" runat="server" ForeColor="#141823" CommandArgument='<%#Eval("IdHebergement") %>'>
                                                           <h4><strong><%#Eval("Nom") %></strong></h4>
                                                                </asp:LinkButton>
                                                            </div>
                                                        </div>
                                                        <hr />
                                                        <div class="mb-2 py-2 text-justify"><%#Eval("Description") %></div>
                                                        <hr />
                                                        <div class="d-flex flex-row justify-content-between flex-wrap pb-3">
                                                            <div class="btn-group">
                                                                <asp:Button ID="btnAnnulerResa" runat="server" Text="Annuler" CssClass="btn btn-danger" CommandArgument='<%#Eval("Reservation.IdReservation") %>' OnClick="btnAnnulerResa_Click" data-toggle="modal" data-target="#AnnulerResa" />
                                                                <asp:LinkButton ID="lbtFavorisResa" runat="server" CommandArgument='<%#Eval("IdHebergement") %>' OnClick="lbtFavorisResa_Click" CssClass="btn btn-outline-warning" Enabled="true"><span class="far fa-heart"></span></asp:LinkButton>
                                                            </div>
                                                            <h5><span class="badge badge-light"><%#Eval("Prix") %> € par nuit</span></h5>
                                                        </div>
                                                    </div>
                                                    <hr />
                                                    <div class="flex-image pl-3">

                                                        <a href='<%#Eval("Photo") %>' data-lightbox="image-1" data-title='<%#Eval("Nom") %>'>
                                                            <asp:Image ID="Image1" runat="server" src='<%#Eval("Photo") %>' CssClass="img-fluid myImg" /></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </div>
                            </div>
                        </div>
                        <!-- tab-Historique.// -->
                        <div class="tab-pane fade" id="nav-tab-historique">
                        </div>
                        <!-- tab-pane.// -->
                    </div>
                    <!-- tab-content .// -->
                </div>
                <!-- card-body.// -->
            </article>



        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
