<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreerCompte.aspx.cs" Inherits="AirLoca.CreerCompte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<%--    <div class="d-flex justify-content-between flex-wrap">--%>


            <div class="box" >
                <h4>
                    <label>
                        1. Informations personnelles          
                    </label>
                </h4>
                <hr />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Create" CssClass="alert alert-danger" />


                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label>Prénom :</label>

                        <asp:TextBox ID="txtPrenom" class="form-control" runat="server" type="text" placeholder="Prénom"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrenom" ErrorMessage="Veuillez saisir votre Prénom" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-6">
                        <label>Nom :</label>

                        <asp:TextBox ID="txtNom" class="form-control" runat="server" type="text" placeholder="Nom"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNom" ErrorMessage="Veuillez saisir votre Nom" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label>Email :</label>
                        <div class="input-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text" id="basic-addon1">@</span>
                            </div>
                            <asp:TextBox ID="txtEmail" class="form-control" runat="server" type="text" placeholder="Email" TextMode="Email"></asp:TextBox>
                        </div>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Format de l'email invalide" ControlToValidate="txtEmail" Display="None" ValidationGroup="Create" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Veuillez saisir votre Email" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-6">
                        <label>Téléphone :</label>

                        <asp:TextBox ID="txtTelephone" class="form-control" runat="server" type="text" placeholder="Telephone" TextMode="Phone"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTelephone" ErrorMessage="Veuillez saisir votre Téléphone" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-2">
                        <label>Numéro :</label>
                        <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server" type="text" placeholder="Numéro"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtNumero" ErrorMessage="Veuillez saisir le numéro de voie" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group col-md-10">
                        <label>Voie :</label>

                        <asp:TextBox ID="txtVoie" class="form-control" runat="server" type="text" placeholder="Voie"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtVoie" ErrorMessage="Veuillez saisir le nom de la voie" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-8">
                        <label>Ville :</label>

                        <asp:TextBox ID="txtVille" class="form-control" runat="server" type="text" placeholder="Ville"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtVille" ErrorMessage="Veuillez saisir votre Ville" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-4">
                        <label>Code Postal :</label>
                        <asp:TextBox ID="txtCodePostal" runat="server" class="form-control" placeholder="Code Postal"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCodePostal" ErrorMessage="Veuillez saisir votre Code Postal" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                    </div>
                </div>

            </div>

            <div class="box justify-content-center">
                <h4>
                    <label>
                        2. Créez vos identifiants
                    </label>
                </h4>
                <hr />
                <div class="form-group">
                    <label>Login :</label>
                    <asp:TextBox ID="txtLogin" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtLogin" ErrorMessage="Veuillez saisir un Login" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label>Mot de passe :</label>

                    <asp:TextBox ID="txtPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPassword" ErrorMessage="Veuillez saisir un Mot de Passe" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label>Confirmez mot de passe :</label>

                    <asp:TextBox ID="txtPassword2" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPassword2" ErrorMessage="Veuillez confirmer votre Mot de Passe" ValidationGroup="Create" Display="None"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtPassword2" ControlToCompare="txtPassword" ErrorMessage="Mot de passe différent" ValidationGroup="Create"></asp:CompareValidator>
                </div>

                <div class="form-row justify-content-center px-2">
                    <asp:Button ID="btnCreate" runat="server" CssClass="btn btn-success " Text="Créer mon compte" ValidationGroup="Create" OnClick="btnCreate_Click" />
                </div>

            </div>
<%--    </div>--%>

</asp:Content>
