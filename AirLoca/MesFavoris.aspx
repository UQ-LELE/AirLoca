<%@ Page Title="" Language="C#" MasterPageFile="~/BackOffice.Master" AutoEventWireup="true" CodeBehind="MesFavoris.aspx.cs" Inherits="AirLoca.MesFavoris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



        <div class="row">
            <asp:ListView ID="lvwFavoris" runat="server">
                <ItemTemplate>
                 
                        <div class="col-sm-6 col-lg-3 py-2">
                            <div class="card">
                                <img class="card-img-top img-fluid" src="<%#Eval("Photo") %>" alt="Card image cap">
                                <div class="card-body">
                                    <asp:LinkButton ID="lbtNom" runat="server" ForeColor="#141823" OnClick="lbtNom_Click" CommandArgument='<%#Eval("IdHebergement") %>'>
                                <h6 class="card-title"><strong><%#Eval("Nom") %></strong></h6>
                                    </asp:LinkButton>
<%--                                    <p class="card-text"><%#Eval("Description") %></p>--%>
                                   <hr />
                                        <div class="btn-group">
                                            <asp:Button ID="btnReserver" runat="server" Text="Réserver" CssClass="btn btn-danger" OnClick="btnReserver_Click" CommandArgument='<%#Eval("IdHebergement") %>' />
                                            <asp:LinkButton ID="lbtSupprimer" runat="server" CommandArgument='<%#Eval("IdHebergement") %>' OnClick="lbtSupprimer_Click" CssClass="btn btn-outline-danger"><span class="far fa-trash-alt"></span></asp:LinkButton>
                                        </div>
                                   
                                </div>
                            </div>
                        </div>
                
                </ItemTemplate>
            </asp:ListView>
        </div>




    <%--    <div class="box mb-3">
        <h3>Mes Favoris</h3>
        <hr />
        <asp:ListView ID="lvwFavoris" runat="server">
            <ItemTemplate>

                <div class=" flex-container align-items-center ">
                    <div class="flex-item">

                        <div class="d-flex flex-row justify-content-between flex-wrap mb-2">
                            <div>
                                <asp:LinkButton ID="lbtNom" runat="server" ForeColor="#141823" OnClick="lbtNom_Click" CommandArgument='<%#Eval("IdHebergement") %>'>
                                <h4><strong><%#Eval("Nom") %></strong></h4>
                                </asp:LinkButton>
                            </div>

                        </div>
                        <hr />
                        <div class="mb-2 py-2 text-justify"><%#Eval("Description") %></div>
                        <hr />
                        <div class="d-flex flex-row justify-content-between flex-wrap pb-3">
                            <div class="btn-group">
                                <asp:Button ID="btnReserver" runat="server" Text="Réserver" CssClass="btn btn-danger" OnClick="btnReserver_Click" CommandArgument='<%#Eval("IdHebergement") %>' />
                                <asp:LinkButton ID="lbtSupprimer" runat="server" CommandArgument='<%#Eval("IdHebergement") %>' OnClick="lbtSupprimer_Click" CssClass="btn btn-outline-danger"><span class="far fa-trash-alt"></span></asp:LinkButton>
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
            </ItemTemplate>

        </asp:ListView>
    </div>--%>
</asp:Content>

