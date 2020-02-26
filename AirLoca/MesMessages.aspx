<%@ Page Title="" Language="C#" MasterPageFile="~/BackOffice.Master" AutoEventWireup="true" CodeBehind="MesMessages.aspx.cs" Inherits="AirLoca.MesMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="flex-container box justify-content-between">
                <div class="m-1">
                    <h4>
                        <label>Boîte de réception :</label></h4>
                    <hr />
                    <asp:ListView ID="lvwSujet" runat="server" OnItemDataBound="lvwSujet_ItemDataBound">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtSujet" CssClass="list-group-item list-group-item-action" runat="server" OnClick="lbtSujet_Click"><%#Eval("NomHebergement")%> - <%#Eval("PrenomContact")%></asp:LinkButton>
                        </ItemTemplate>
                    </asp:ListView>
                </div>

                <div class="small-container message">

<%--                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
                    <div>
                        <asp:ListView ID="lvwTitre" runat="server" OnItemDataBound="lvwTitre_ItemDataBound">
                            <ItemTemplate>
                                <asp:Literal ID="ltrTitre" runat="server"></asp:Literal>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>

                    <div style="height: 580px; overflow-y: auto">
                        <asp:ListView ID="lvwMessage" runat="server" OnItemDataBound="lvwMessage_ItemDataBound">
                            <ItemTemplate>
                                <asp:Literal ID="ltrMessage" runat="server"></asp:Literal>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

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
                    <asp:Button ID="btnSend" runat="server" Text="Envoyer" class="btn btn-success ml-auto" OnClick="btnSend_Click" />
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        function sendModal(idContact, idHebergement) {
            $('#<%=this.sendContact.ClientID%>').val(idContact);
            $('#<%=this.sendHebergement.ClientID%>').val(idHebergement);

        }
    </script>

</asp:Content>
