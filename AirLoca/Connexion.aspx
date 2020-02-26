<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Connexion.aspx.cs" Inherits="AirLoca.Connexion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div class="flex-container">
                <fieldset>
                    <div class="box small-container justify-content-center">
                        <h4>
                            <label>Accès Client : </label>
                        </h4>
                        <hr />
                        <div class="form-group">
                            <label>Login :</label>

                            <asp:TextBox ID="txtLogin" class="form-control" placeholder="Votre identifiant" runat="server" type="text"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Saisir un identifiant" ControlToValidate="txtLogin" ValidationGroup="login" Display="none"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label>Mot de passe :</label>

                            <asp:TextBox ID="txtPassword" class="form-control " placeholder="Votre mot de passe" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPassword" runat="server" ErrorMessage="Mot de passe Obligatoire" ValidationGroup="login" Display="none"></asp:RequiredFieldValidator>
                        </div>

                        <div class="d-flex justify-content-center pb-4">
                            <asp:LinkButton ID="LinkButton2" runat="server">Identifiant ou Mot de passe oublié</asp:LinkButton>
                        </div>
                        <div>
                            <asp:ValidationSummary runat="server" ID="ValidationSummary1" DisplayMode="BulletList" ShowMessageBox="False" ShowSummary="True" CssClass="alert alert-danger" ValidationGroup="login" />
                            <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>
                        </div>

                        <div class="form-row">
                            <div class="form-group px-2">
                                <asp:Button ID="btnConnexion" runat="server" Text="Se connceter" class="btn btn-success" OnClick="btnConnexion_Click" ValidationGroup="login" />

                            </div>
                            <div class="form-group px-2">
                                <asp:Button ID="btnNew" runat="server" Text="Creer un compte" class="btn btn-primary" OnClick="btnNew_Click" />
                            </div>
                        </div>

                    </div>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
