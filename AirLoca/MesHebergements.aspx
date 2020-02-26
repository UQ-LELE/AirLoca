<%@ Page Title="" Language="C#" MasterPageFile="~/BackOffice.Master" AutoEventWireup="true" CodeBehind="MesHebergements.aspx.cs" Inherits="AirLoca.MesHebergements" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <article class="box">
                <nav class="navbar-expand-md ">
                    <ul class="nav nav-tabs bg-light mb-3" role="tablist">
                        <li class="nav-item">
                            <a class="nav-link <%=TabHebergement %>" data-toggle="pill" href="#nav-tab-hebergement">Mes hébergements</a></li>
                        <li class="nav-item">
                            <a class="nav-link  <%=TabLocation %>" data-toggle="pill" href="#nav-tab-location">Réservations de mes hébergements</a></li>
                        <li class="nav-item">
                            <a class="nav-link  <%=TabHistoLoca %>" data-toggle="pill" href="#nav-tab-histoloca">Historique</a></li>
                    </ul>
                </nav>

                <div class="tab-content">

                    <!-- tab-pane hebergement.// -->
                    <div class="tab-pane fade show <%=TabHebergement %>" id="nav-tab-hebergement">
                        <div class="justify-content-center mb-3">
                            <!--NotOwner-->
                            <div runat="server" id="NotOwner" visible="false">
                                <h4>
                                    <label>Devenez hébergeur en quelques clics : </label>
                                </h4>
                                <hr />
                                <p>Unde Rufinus ea tempestate praefectus praetorio ad discrimen trusus est ultimum. ire enim ipse compellebatur ad militem, quem exagitabat inopia simul et feritas, et alioqui coalito more in ordinarias dignitates asperum semper et saevum, ut satisfaceret atque monstraret, quam ob causam annonae convectio sit impedita.</p>
                                <hr />
                            </div>

                            <!--Owner-->
                            <div runat="server" id="Owner" visible="false">
                                <div class="d-flex justify-content-between">
                                    <div>
                                        <h4>
                                            <label>Gérer mes hébergements : </label>
                                        </h4>
                                    </div>
                                    <div>
                                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalAddLoc"><span class="fas fa-plus"></span>&nbsp;&nbsp;Ajouter un hébergement</button>
                                    </div>
                                </div>
                                <hr />

                                <!--OwnerNoLoc-->
                                <div id="NoLoc" runat="server" visible="false">
                                    <h4>
                                        <label>Votre liste d'hébergement est vide : </label>
                                    </h4>
                                    <hr />
                                    <p>Unde Rufinus ea tempestate praefectus praetorio ad discrimen trusus est ultimum. ire enim ipse compellebatur ad militem, quem exagitabat inopia simul et feritas, et alioqui coalito more in ordinarias dignitates asperum semper et saevum, ut satisfaceret atque monstraret, quam ob causam annonae convectio sit impedita.</p>
                                    <hr />
                                </div>

                                <!--OwnerWithLoc-->
                                <asp:ListView ID="lvwOwnerLoc" runat="server">
                                    <ItemTemplate>
                                        <div class="simpleBox mb-3">
                                            <div class=" flex-container align-items-center ">
                                                <div class="flex-item">
                                                    <div>
                                                        <h4><strong><%#Eval("Nom") %></strong></h4>
                                                    </div>
                                                    <hr />
                                                    <div class="mb-2 py-2 text-justify"><%#Eval("Description") %></div>
                                                    <hr />
                                                    <div class="d-flex flex-column flex-wrap">
                                                        <div>
                                                            <p><span class="fas fa-map-marker-alt"></span><strong>&nbsp;&nbsp;Localisation :&nbsp;&nbsp;</strong><%#Eval("Adresse.Numero")%> <%#Eval("Adresse.Voie")%>,  <%#Eval("Adresse.Ville")%> (<%#Eval("Adresse.CodePostal")%>)</p>
                                                        </div>
                                                        <div>
                                                            <p><span class="fas fa-home"></span><strong>&nbsp;&nbsp;Type d'hébergement :&nbsp;&nbsp;</strong><%#Eval("Type")%></p>
                                                        </div>
                                                        <div>
                                                            <p><strong>Prix :&nbsp;&nbsp;</strong><%#Eval("PrixDeBase") %> € par nuit </p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <hr />
                                                <div class="flex-image pl-3">
                                                    <a href='<%#Eval("Photo") %>' data-lightbox="image-1" data-title='<%#Eval("Nom") %>'>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Photo") %>' CssClass="img-fluid myImg" /></a>
                                                </div>
                                            </div>
                                            <hr />
                                            <div class="d-flex flex-row justify-content-between flex-wrap">
                                                <button type="button" class="btn btn-primary mx-3" data-toggle="collapse" data-target="#collapse<%#Eval("IdHebergement")%>" aria-expanded="false" aria-controls="collapseExample"><span class="far fa-edit"></span>&nbsp;&nbsp;Modifer</button>
                                                <button type="button" class="btn btn-danger mx-3" data-toggle="modal" data-target="#DeleteLoc">Supprimer</button>
                                            </div>

                                            <div class="collapse" id="collapse<%#Eval("IdHebergement")%>">
                                                <hr />
                                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Modify" CssClass="alert alert-danger" />
                                                <div class="form-group">
                                                    <label>Nom de votre hébergement :</label>
                                                    <asp:TextBox ID="txtNomLoca" runat="server" class="form-control" Text='<%#Eval("Nom")%>' ToolTip='<%#Eval("IdHebergement")%>'></asp:TextBox>
                                                    <%--                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNomLoca" ErrorMessage="Veuillez saisir un nom d'hébergement" ValidationGroup="Modify" Display="None"></asp:RequiredFieldValidator>--%>
                                                </div>

                                                <div class="form-row">
                                                    <div class="form-group col-md-2">
                                                        <label>Numero :</label>
                                                        <asp:TextBox ID="txtNumLoca" runat="server" class="form-control" Text='<%#Eval("Adresse.Numero")%>' ToolTip='<%#Eval("IdHebergement")%>' TextMode="Number"></asp:TextBox>
                                                        <%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNumLoca" ErrorMessage="Veuillez saisir un numero d'adresse" ValidationGroup="Modify" Display="None"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                    <div class="form-group col-md-10">
                                                        <label>Voie :</label>
                                                        <asp:TextBox ID="txtVoieLoca" runat="server" Text='<%#Eval("Adresse.Voie")%>' ToolTip='<%#Eval("IdHebergement")%>' class="form-control"></asp:TextBox>
                                                        <%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtVoieLoca" ErrorMessage="Veuillez saisir un nom de voie" ValidationGroup="Modify" Display="None"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>

                                                <div class="form-row">
                                                    <div class="form-group col-md-8">
                                                        <label>Ville :</label>
                                                        <asp:TextBox ID="txtVilleLoca" runat="server" Text='<%#Eval("Adresse.Ville")%>' ToolTip='<%#Eval("IdHebergement")%>' class="form-control"></asp:TextBox>
                                                        <%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtVilleLoca" ErrorMessage="Veuillez saisir un nom de ville" ValidationGroup="Modify" Display="None"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                    <div class="form-group col-md-4">
                                                        <label>Code Postal :</label>
                                                        <asp:TextBox ID="txtCPLoca" runat="server" Text='<%#Eval("Adresse.CodePostal")%>' ToolTip='<%#Eval("IdHebergement")%>' class="form-control"></asp:TextBox>
                                                        <%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCPLoca" ErrorMessage="Veuillez saisir un code Postal" ValidationGroup="Modify" Display="None"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>

                                                <div class="form-row">
                                                    <div class="form-group col-md-8">
                                                        <label>Type d'hébergement :</label>
                                                        <asp:DropDownList ID="ddlTypeLoca" runat="server" class="form-control" ToolTip='<%#Eval("IdHebergement")%>' SelectedValue='<%#Eval("Type")%>'>
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
                                                        <%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlTypeLoca" ErrorMessage="Veuillez choisir un type d'hébergement" ValidationGroup="Modify" Display="None"></asp:RequiredFieldValidator>--%>
                                                    </div>

                                                    <div class="form-group col-md-4">
                                                        <label>Prix par nuit :</label>
                                                        <asp:TextBox ID="txtPrixLoca" runat="server" class="form-control" ToolTip='<%#Eval("IdHebergement")%>' Text='<%#Eval("PrixDeBase")%>'></asp:TextBox>
                                                        <%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPrixLoca" ErrorMessage="Veuillez saisir un prix" ValidationGroup="Modify" Display="None"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <label>Description de votre hébergement :</label>
                                                    <asp:TextBox ID="txtDescriptionLoca" runat="server" Text='<%#Eval("Description")%>' ToolTip='<%#Eval("IdHebergement")%>' class="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox>
                                                    <%--                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtDescriptionLoca" ErrorMessage="Veuillez saisir une descritpion" ValidationGroup="Modify" Display="None"></asp:RequiredFieldValidator>--%>
                                                </div>

                                                <%--                                                <div class="form-group">
                                                    <label>Ajouter des photos :</label>
                                                    <asp:FileUpload ID="fupImage" AllowMultiple="true" runat="server" onchange="readURL(this);" Style="display: none;" />
                                                    <asp:LinkButton ID="lbtCharge" CssClass="btn btn-primary" runat="server">Charger une image...</asp:LinkButton>
                                                    <asp:TextBox ID="txtFileName" CssClass="form-control" runat="server" Style="max-width: 220px"></asp:TextBox>
                                                    <img id="imgBox" src="" style="max-width: 180px;" />
                                                </div>--%>

                                                <div class="form-group d-flex flex-row justify-content-end flex-wrap">
                                                    <asp:Button ID="BtnValidateLoc" runat="server" Text="Confirmer" class="btn btn-success btn-lg btn-block" CommandArgument='<%#Eval("IdHebergement") %>' OnClick="BtnValidateLoc_Click" />
                                                </div>

                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                            <hr />
                            <div class="d-flex justify-content-end">
                                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalAddLoc"><span class="fas fa-plus"></span>&nbsp;&nbsp;Ajouter un hébergement</button>
                            </div>
                        </div>
                    </div>

                    <!-- tab-pane Location.// -->
                    <div class="tab-pane fade show <%=TabLocation %>" id="nav-tab-location">
                        <!--NoLocResa-->
                        <div id="NoLocResa" runat="server" visible="false">
                            <h4>
                                <label>Aucun hébergement réservé actuellement: </label>
                            </h4>
                            <hr />
                            <p>Unde Rufinus ea tempestate praefectus praetorio ad discrimen trusus est ultimum. ire enim ipse compellebatur ad militem, quem exagitabat inopia simul et feritas, et alioqui coalito more in ordinarias dignitates asperum semper et saevum, ut satisfaceret atque monstraret, quam ob causam annonae convectio sit impedita.</p>
                            <hr />
                        </div>
                        <!--WithLocResa-->
                        <asp:ListView ID="lvwWithLocResa" runat="server">
                            <ItemTemplate>
                                
                            </ItemTemplate>
                        </asp:ListView>
                    </div>

                    <!-- tab-pane HistoLoca.// -->
                    <div class="tab-pane fade show <%=TabHistoLoca %>" id="nav-tab-histoloca">
                        <h4>
                            <label>Retrouvez l'historique de vos locations : </label>
                        </h4>
                        <hr />
                        <!--NoLocHisto-->
                        <div id="NoLocHisto" runat="server" visible="false">
                            <h4>
                                <label>Aucun historique : </label>
                            </h4>
                            <hr />
                            <p>Unde Rufinus ea tempestate praefectus praetorio ad discrimen trusus est ultimum. ire enim ipse compellebatur ad militem, quem exagitabat inopia simul et feritas, et alioqui coalito more in ordinarias dignitates asperum semper et saevum, ut satisfaceret atque monstraret, quam ob causam annonae convectio sit impedita.</p>
                            <hr />
                        </div>
                        <!--WithLocHisto-->
                        <asp:ListView ID="lvwWithLocHisto" runat="server">
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>

                </div>
            </article>
        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- Modal Add Loc-->
    <div class="modal fade" id="ModalAddLoc" tabindex="-1" role="dialog" aria-labelledby="Ajouter un hébergement" aria-hidden="true">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <article>
                    <div class="card p-2">
                        <div class="modal-header">
                            <h4 class="modal-title" id="exampleModalLongTitle"><strong>Informations sur l'hébergement :</strong></h4>
                        </div>
                        <div class="modal-body">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Create" CssClass="alert alert-danger" />

                            <div class="form-group">
                                <label>Nom de votre hébergement :</label>
                                <asp:TextBox ID="txtNomLoc" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtNomLoc" ErrorMessage="Veuillez saisir le nom de votre hébergement" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-2">
                                    <label>Numero :</label>
                                    <asp:TextBox ID="txtNumLoc" runat="server" class="form-control" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtNumLoc" ErrorMessage="Veuillez saisir un numéro de voie" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-md-10">
                                    <label>Voie :</label>
                                    <asp:TextBox ID="txtVoieLoc" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtVoieLoc" ErrorMessage="Veuillez saisir un nom de voie" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-8">
                                    <label>Ville :</label>
                                    <asp:TextBox ID="txtVilleLoc" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtVilleLoc" ErrorMessage="Veuillez saisir une ville" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-md-4">
                                    <label>Code Postal :</label>
                                    <asp:TextBox ID="txtCPLoc" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtVoieLoc" ErrorMessage="Veuillez saisir un code postal" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-8">
                                    <label>Type d'hébergement :</label>
                                    <asp:DropDownList ID="ddlTypeLoc" runat="server" class="form-control">
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtVoieLoc" ErrorMessage="Veuillez choisir un type d'hébergement" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group col-md-4">
                                    <label>Prix par nuit :</label>
                                    <asp:TextBox ID="txtPrixLoc" runat="server" class="form-control" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtPrixLoc" ErrorMessage="Veuillez saisir un prix" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>Description de votre hébergement :</label>
                                <asp:TextBox ID="txtDescriptionLoc" runat="server" class="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtDescriptionLoc" ErrorMessage="Veuillez saisir une description" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <label>Ajouter des photos :</label>
                                <asp:FileUpload ID="fupImage" AllowMultiple="true" runat="server" onchange="readURL(this);" Style="display: none;" />
                                <asp:LinkButton ID="lbtCharge" CssClass="btn btn-primary" runat="server">Charger une image...</asp:LinkButton>
                                <asp:TextBox ID="txtFileName" CssClass="form-control" runat="server" Style="max-width: 220px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtFileName" ErrorMessage="Veuillez choisir une photo" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                                <img id="imgBox" src="" style="max-width: 180px;" />
                            </div>

                        </div>
                        <div class="modal-footer">
                            <div class="form-row">
                                <div class="form-group px-2">
                                    <button type="button" class="btn btn-primary" data-dismiss="modal">Retour</button>
                                </div>
                                <div class="form-group px-2">
                                    <asp:Button ID="BtnAddLoc" runat="server" Text="Valider" class="btn btn-danger" ValidationGroup="Create" OnClick="BtnAddLoc_Click1" />
                                </div>
                            </div>
                        </div>

                    </div>
                </article>
            </div>
        </div>
    </div>

    <!-- Modal delete location-->
    <div class="modal fade" id="DeleteLoc" tabindex="-1" role="dialog" aria-labelledby="Supprimer ma location" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalLongTitle">Suppression d'hébergement :</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Voulez-vous supprimer cet hébergement de votre liste ?
                </div>
                <div class="modal-footer">
                    <asp:Button ID="BtnDeleteLoc" runat="server" Text="Supprimer" CssClass="btn btn-danger" OnClick="BtnDeleteLoc_Click1" CommandArgument='<%#Eval("IdHebergement") %>' />
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Retour</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal modifier Location-->
    <%--            <div class="modal fade" id="ModifyLoc" tabindex="-1" role="dialog" aria-labelledby="Modifier mon hébergement" aria-hidden="true">
                <div class="modal-dialog modal-xl" role="document">
                    <div class="modal-content">
                        <fieldset runat="server" id="fieldsetLoc" disabled>
                            <div class="card p-2">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="ModalLongTitre">Informations sur l'hébergement :</h5>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group">
                                        <label>Nom de votre hébergement :</label>
                                        <asp:TextBox ID="txtNomLoca" runat="server" class="form-control" Text='<%#Eval("Nom")%>'></asp:TextBox>
                                    </div>

                                    <div class="form-row">
                                        <div class="form-group col-md-2">
                                            <label>Numero :</label>
                                            <asp:TextBox ID="txtNumLoca" runat="server" class="form-control" Text='<%#Eval("Adresse.Numero")%>' TextMode="Number"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-10">
                                            <label>Voie :</label>
                                            <asp:TextBox ID="txtVoieLoca" runat="server" Text='<%#Eval("Adresse.Voie")%>' class="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-row">
                                        <div class="form-group col-md-8">
                                            <label>Ville :</label>
                                            <asp:TextBox ID="txtVilleLoca" runat="server" Text='<%#Eval("Adresse.Ville")%>' class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-4">
                                            <label>Code Postal :</label>
                                            <asp:TextBox ID="txtCPLoca" runat="server" Text='<%#Eval("Adresse.CodePostal")%>' class="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-row">
                                        <div class="form-group col-md-8">
                                            <label>Type d'hébergement :</label>
                                            <asp:DropDownList ID="ddlTypeLoca" runat="server" class="form-control" placeholder='<%#Eval("Type")%>'>
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

                                        <div class="form-group col-md-4">
                                            <label>Prix par nuit :</label>
                                            <asp:TextBox ID="txtPrixLoca" runat="server" class="form-control" Text='<%#Eval("PrixDeBase")%>' TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label>Description de votre hébergement :</label>
                                        <asp:TextBox ID="txtDescriptionLoca" runat="server" Text='<%#Eval("Description")%>' class="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <label>Ajouter des photos :</label>
                                    </div>

                                </div>
                            </div>

                        </fieldset>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-primary" data-dismiss="modal">Retour</button>
                            <asp:HiddenField ID="changeLoc" runat="server" />
                        </div>
                    </div>
                </div>
            </div>--%>



    <script src="Scripts/lightbox.js"></script>
    <script type="text/javascript">
<%--        function openModal(idHebergement) {
            $('#<%=this.changeLoc.ClientID%>').attr('value', idHebergement);
        }--%>

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgBox').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }

            document.getElementById('<%=txtFileName.ClientID%>').value = document.getElementById('<%=fupImage.ClientID%>').value;
        }
    </script>

    <script src="Scripts/lightbox.js"></script>

</asp:Content>
