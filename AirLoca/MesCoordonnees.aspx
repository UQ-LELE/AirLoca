<%@ Page Title="" Language="C#" MasterPageFile="~/BackOffice.Master" AutoEventWireup="true" CodeBehind="MesCoordonnees.aspx.cs" Inherits="AirLoca.MesCoordonnees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <article class="box">
                <nav class="navbar-expand-md ">
                    <ul class="nav nav-tabs bg-light mb-3" role="tablist">

                        <li class="nav-item">
                            <a class="nav-link <%=TabCoordonnees%>" data-toggle="pill" href="#nav-tab-coordonnees">Mes Coordonnees</a></li>

                        <li class="nav-item">
                            <a class="nav-link  <%=TabLogin%>" data-toggle="pill" href="#nav-tab-login">Mes Identifiants</a></li>
                    </ul>
                </nav>

                <div class="tab-content">

                    <!-- tab-pane coordonnees.// -->
                    <div class="tab-pane fade show <%=TabCoordonnees%> " id="nav-tab-coordonnees">
                        <fieldset id="fieldsetCoord" runat="server" disabled>
                            <h4>
                                <label>
                                    Informations personnelles :
                                </label>
                            </h4>
                            <hr />
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label>Prénom :</label>
                                    <asp:TextBox ID="txtPrenom" runat="server" class="form-control" type="text"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-6">
                                    <label>Nom :</label>
                                    <asp:TextBox ID="txtNom" runat="server" class="form-control" type="text"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label>Email :</label>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text" id="basic-addon1">@</span>
                                        </div>
                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" type="text" TextMode="Email"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group col-md-6">
                                    <label>Téléphone :</label>
                                    <asp:TextBox ID="txtTelephone" runat="server" class="form-control" type="text" TextMode="Phone"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-2">
                                    <label>Numéro :</label>
                                    <asp:TextBox ID="txtNumero" runat="server" class="form-control" type="text" TextMode="Number"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-10">
                                    <label>Voie :</label>
                                    <asp:TextBox ID="txtVoie" runat="server" class="form-control" type="text"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-8">
                                    <label>Ville :</label>
                                    <asp:TextBox ID="txtVille" runat="server" class="form-control" type="text"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-4">
                                    <label>Code Postal :</label>
                                    <asp:TextBox ID="txtCodePostal" runat="server" class="form-control" type="text"></asp:TextBox>
                                </div>
                            </div>
                        </fieldset>

                        <div class="form-group d-flex justify-content-end px-2">
                            <asp:Button ID="btnModifyCoord" runat="server" Text="Modifier" class="btn btn-primary" OnClick="btnModifyCoord_Click" Visible="true" Enabled="true" />
                            <asp:Button ID="btnValidateCoord" runat="server" Text="Valider" class="btn btn-success" OnClick="btnValidateCoord_Click" Visible="false" />
                        </div>
                    </div>


                    <!-- tab-pane login.// -->
                    <div class="tab-pane fade show <%=TabLogin %>" id="nav-tab-login">
                        <div class="justify-content-center mb-3">
                            <fieldset id="fieldsetLogin" runat="server" disabled>
                                <label>
                                    <h4>Modifier mot de passe :</h4>
                                </label>
                                <hr />

                                <div class="d-flex justify-content-center">
                                    <div class="d-flex flex-column" style="max-width: 400px">
                                        <div class="form-group">
                                            <label>Mot de passe :</label>

                                            <asp:TextBox ID="txtPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPassword" ErrorMessage="Veuillez saisir votre mot de passe" ValidationGroup="Modificate" Display="None"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="form-group">
                                            <label>Nouveau mot de passe :</label>

                                            <asp:TextBox ID="txtPassword3" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword3" ErrorMessage="Veuillez saisir un nouveau mot de passe" ValidationGroup="Modificate" Display="None"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Confirmez votre nouveau mot de passe :</label>

                                            <asp:TextBox ID="txtPassword2" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPassword2" ErrorMessage="Veuillez confirmer votre nouveau mot de passe" ValidationGroup="Modificate" Display="None"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtPassword2" ControlToCompare="txtPassword3" ErrorMessage="Mot de passe différent" ValidationGroup="Modificate"></asp:CompareValidator>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                            <div class="form-group d-flex justify-content-end px-2">
                                <asp:Button ID="btnModifyPass" runat="server" Text="Modifier" class="btn btn-primary" OnClick="btnModifyPass_Click1" Visible="true" />
                                <asp:Button ID="btnValidatePass" runat="server" Text="Valider" class="btn btn-success" OnClick="btnValidatePass_Click1" Visible="false" />
                            </div>
                        </div>
                    </div>
                    <!-- tab-content .// -->
                </div>
                <!-- card-body.// -->
            </article>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
