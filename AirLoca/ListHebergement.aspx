<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListHebergement.aspx.cs" Inherits="AirLoca.ListHebergement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="NotFound" class="d-flex justify-content-center" runat="server" visible="false">
        <div class="box small-container justify-content-center">
            <h1>
                <label><span class="fas fa-search" style="color: rgba(101, 199, 247, 0.9);"></span>&nbsp;&nbsp;Zut !</label></h1>
            <h4>Désolé, aucun résltutat trouvé pour un(e) <strong><%=typeHebergement %></strong> dans le département <strong><%=departement %></strong></h4>
        </div>
    </div>    
    
    <div id="Found" class="box mb-1 justify-content-center" runat="server" visible="false"> 
            <h4>
                <label><span class="fas fa-search" style="color: rgba(101, 199, 247, 0.9);"></span>&nbsp;&nbsp;Résultats pour <strong><%=typeHebergement %></strong> dans le département <strong><%=departement %></strong> :</label></h4>
    </div>

    <asp:ListView ID="lvwHebergement" runat="server" OnPagePropertiesChanging="lvwHebergement_PagePropertiesChanging" OnItemDataBound="LvwHebergement_ItemDataBound">
        <ItemTemplate>
            <div class="box mb-3">

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
                                <asp:LinkButton ID="lbtFavoris" runat="server" CommandArgument='<%#Eval("IdHebergement") %>' OnClick="lbtFavoris_Click" CssClass="btn btn-outline-warning" Enabled="true"><span class="far fa-heart"></span></asp:LinkButton>
                            </div>
                            <h4><span class="badge badge-light"><%#Eval("PrixDeBase") %> € / nuit</span></h4>
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


    <div class="pagenavi">
        <asp:DataPager ID="dtpHebergement" runat="server" PagedControlID="lvwHebergement" PageSize="10">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="btn btn-light" ShowLastPageButton="false" FirstPageText="&#171;" ShowNextPageButton="false" ShowFirstPageButton="true" ShowPreviousPageButton="False" />
                <asp:NumericPagerField ButtonType="Link" NextPreviousButtonCssClass="btn btn-light" NumericButtonCssClass="btn btn-light" CurrentPageLabelCssClass="btn btn-primary" ButtonCount="5" />
                <asp:NextPreviousPagerField ButtonType="Link" ButtonCssClass="btn btn-light" ShowLastPageButton="True" LastPageText="&#187;" ShowNextPageButton="false" ShowFirstPageButton="false" ShowPreviousPageButton="False" />
            </Fields>
        </asp:DataPager>
    </div>

    <script src="Scripts/lightbox.js"></script>

</asp:Content>
