<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Paiement.aspx.cs" Inherits="AirLoca.Paiement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>


    <script type="text/javascript" src="https://cdn.jsdelivr.net/jquery/latest/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/momentjs/latest/moment.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css" />

    <div class="d-flex justify-content-between">

        <div class="box mr-1">
            <h4>
                <label>Votre réservation :</label>
            </h4>
            <hr />
            <asp:ListView ID="lvwHebergement" runat="server">
                <ItemTemplate>
                    <div class="d-flex justify-content-between align-items-center">
                        <div class="flex-item">

                            <div class="d-flex flex-row justify-content-between flex-wrap mb-2">
                                <div>
                                    <h4><strong><%#Eval("Nom") %></strong></h4>
                                </div>
                            </div>
                            <div class="d-flex flex-row justify-content-between flex-wrap mb-2">
                                <p><span class="fas fa-home"></span>&nbsp;&nbsp;<%#Eval("Type")%></p>
                                <p><span class="fas fa-map-marker-alt"></span>&nbsp;&nbsp;<%#Eval("Adresse.Ville")%> (<%#Eval("Adresse.CodePostal")%>)</p>
                            </div>

                            <div class="mb-2 py-2 text-justify"><%#Eval("Description") %></div>

                        </div>
                        <hr />
                        <div class="flex-image pl-3">
                            <a href='<%#Eval("Photo") %>' data-lightbox="image-1" data-title='<%#Eval("Nom") %>'>
                                <asp:Image ID="Image1" runat="server" src='<%#Eval("Photo") %>' CssClass="img-fluid myImg" /></a>
                        </div>

                    </div>

                </ItemTemplate>
            </asp:ListView>
        </div>

        <div class="box d-flex flex-column align-content-between">
            <div>
                <h5>
                    <asp:Label ID="lblPrixBase" runat="server"></asp:Label>
                </h5>
                <hr />
            </div>

            <div class="d-flex justify-content-between">
                <div>
                    <span class="product-rating">4.2</span><span>/5</span>
                </div>
                <div class="stars">
                    <i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i>
                </div>

            </div>
            <div>
                <p>15 commentaires</p>
                <hr />

            </div>
            <h5>
                <label>Dates :</label>
            </h5>
            <div class="form-group">
                <input type="text" name="datefilter" value="" class="form-control" />
            </div>
            <h5>
                <label>Voyageurs :</label>
            </h5>
            <asp:DropDownList ID="ddlVoyageur" runat="server" CssClass="form-control">
                <asp:ListItem>
                    
                </asp:ListItem>
            </asp:DropDownList>
            <hr />
            <div class="form-group">
                <button type="button" class="btn btn-danger d-block" data-toggle="modal" data-target="#paiementModal" data-id='<%# Eval("IdHebergement")%>'>Paiement</button>
            </div>
        </div>
    </div>

    <!--Modal paiement-->
    <div class="modal fade" id="paiementModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <article>
                    <div class="card p-3">
                        <h4>
                            <label>Prix total :</label></h4>
                        <asp:Label ID="lblPrixTotalM" runat="server"></asp:Label>
                        <hr />
                        <ul class="nav bg-light nav-pills rounded nav-fill mb-3" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link active" data-toggle="pill" href="#nav-tab-card">
                                    <span class="fa fa-credit-card"></span>CB</a></li>
                            <li class="nav-item">
                                <a class="nav-link" data-toggle="pill" href="#nav-tab-paypal">
                                    <span class="fab fa-paypal"></span>Paypal</a></li>
                            <li class="nav-item">
                                <a class="nav-link" data-toggle="pill" href="#nav-tab-bank">
                                    <span class="fa fa-university"></span>Chèque</a></li>
                        </ul>

                        <div class="tab-content">
                            <div class="tab-pane fade show active" id="nav-tab-card">
                                <div class="form-group">
                                    <label for="username">Titulaire de la carte</label>
                                    <input type="text" class="form-control" name="username" placeholder="" required="">
                                </div>

                                <div class="form-group">
                                    <label for="cardNumber">Numero de la carte</label>
                                    <div class="input-group">
                                        <input type="text" class="form-control" name="cardNumber" placeholder="">
                                        <div class="input-group-append">
                                            <span class="input-group-text text-muted">
                                                <i class="fab fa-cc-visa"></i><i class="fab fa-cc-amex"></i>
                                                <i class="fab fa-cc-mastercard"></i>
                                            </span>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-sm-8">
                                        <div class="form-group">
                                            <label><span class="hidden-xs">Expiration</span> </label>
                                            <div class="input-group">
                                                <input type="number" class="form-control" placeholder="Mois" name="">
                                                <input type="number" class="form-control" placeholder="Année" name="">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label data-toggle="tooltip" title="" data-original-title="3 digits code on back side of the card">CVV <i class="fa fa-question-circle"></i></label>
                                            <input type="number" class="form-control" required="">
                                        </div>
                                    </div>
                                </div>
                                <div class="d-flex justify-content-between">
                                    <div>
                                        <button type="button" class="btn btn-primary" data-dismiss="modal">Retour</button>
                                    </div>
                                    <div>
                                        <asp:Button ID="btnReserver" runat="server" Text="Payer" class="btn btn-danger" OnClick="btnReserver_Click" />
                                    </div>

                                </div>
                            </div>

                            <!-- tab-pane.// -->
                            <div class="tab-pane fade" id="nav-tab-paypal">
                                <p>Payez vos achats sans saisir vos coordonnées bancaires</p>
                                <p>
                                    <button type="button" class="btn btn-primary"><i class="fab fa-paypal"></i>Se connecter à mon compte Paypal </button>
                                </p>
                                <p>
                                    <strong>Note:</strong> Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
tempor incididunt ut labore et dolore magna aliqua.
                                </p>
                            </div>
                            <div class="tab-pane fade" id="nav-tab-bank">
                                <p>Bank accaunt details</p>
                                <dl class="param">
                                    <dt>BANK: </dt>
                                    <dd>THE WORLD BANK</dd>
                                </dl>
                                <dl class="param">
                                    <dt>Accaunt number: </dt>
                                    <dd>12345678912345</dd>
                                </dl>
                                <dl class="param">
                                    <dt>IBAN: </dt>
                                    <dd>123456789</dd>
                                </dl>
                                <p>
                                    <strong>Note:</strong> Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
tempor incididunt ut labore et dolore magna aliqua.
                                </p>
                            </div>
                            <!-- tab-pane.// -->
                        </div>
                        <!-- tab-content .// -->
                    </div>
                </article>
            </div>
        </div>
    </div>


    <script type="text/javascript">

        var today = new Date();

        var disabledArr = ["19/03/2020"];

        $(function () {

            $('input[name="datefilter"]').daterangepicker({
                "opens": "left",
                autoUpdateInput: false,
                "locale": {
                    "format": "DD/MM/YYYY",
                    "separator": " - ",
                    "applyLabel": "Selectionner",
                    "cancelLabel": "Retour",
                    "fromLabel": "From",
                    "toLabel": "To",
                    "customRangeLabel": "Custom",
                    "weekLabel": "S",
                    "daysOfWeek": [
                        "Dim",
                        "Lun",
                        "Mar",
                        "Mer",
                        "Jeu",
                        "Ven",
                        "Sam"
                    ],
                    "monthNames": [
                        "Janvier",
                        "Février",
                        "Mars",
                        "Avril",
                        "Mai",
                        "Juin",
                        "Juillet",
                        "Août",
                        "Septembre",
                        "Octobre",
                        "Novembre",
                        "Decembre"
                    ],
                    "firstDay": 1,
                },
                "minDate": today,
                isInvalidDate: function (arg) {
                    console.log(arg);

                    // Prepare the date comparision
                    var thisMonth = arg._d.getMonth() + 1;   // Months are 0 based
                    if (thisMonth < 10) {
                        thisMonth = "0" + thisMonth; // Leading 0
                    }
                    var thisDate = arg._d.getDate();
                    if (thisDate < 10) {
                        thisDate = "0" + thisDate; // Leading 0
                    }
                    var thisYear = arg._d.getYear() + 1900;   // Years are 1900 based

                    var thisCompare = thisDate + "/" +  thisMonth + "/" + thisYear;
                    console.log(thisCompare);

                    if ($.inArray(thisCompare, disabledArr) != -1) {
                        console.log("      ^--------- DATE FOUND HERE");
                        return arg._pf = { userInvalidated: true };
                    }
                }
            });

            $('input[name="datefilter"]').on('apply.daterangepicker', function (e, picker) {
                //$(this).val(picker.startDate.format('DD/MM/YYYY') + ' - ' + picker.endDate.format('DD/MM/YYYY'));
                // Get the selected bound dates.
                var startDate = picker.startDate.format('DD/MM/YYYY')
                var endDate = picker.endDate.format('DD/MM/YYYY')
                $(this).val(startDate + " - " + endDate);

                // Compare the dates again.
                var clearInput = false;
                for (i = 0; i < disabledArr.length; i++) {
                    if (startDate < disabledArr[i] && endDate > disabledArr[i]) {
                        $(this).val("Found a disabled Date in selection!");
                        clearInput = true;
                    }
                }

                // If a disabled date is in between the bounds, clear the range.
                if (clearInput) {

                    // To clear selected range (on the calendar).
                    $(this).data('daterangepicker').setStartDate(today);
                    $(this).data('daterangepicker').setEndDate(today);

                    // To clear input field and keep calendar opened.
                    $(this).val("").focus();
                    console.log("Cleared the input field...");

                    // Notify user!
                    $.notify({
                        // options
                        message: 'La période sélectionnée comporte des dates déjà reservées !'
                    }, {
                        // settings
                        type: 'danger'
                    });
                }
            });

            $('input[name="datefilter"]').on('cancel.daterangepicker', function (ev, picker) {
                $(this).val('');
            });

        });
    </script>

    <script src="Scripts/lightbox.js"></script>

</asp:Content>
