<%@ Page
    Title="DownloadCV"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="DownloadCV.aspx.cs"
    MasterPageFile="~/Site.Master"
    Inherits="PortFolio.CurriculumGenerator.DownloadCV" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html>
    <head>
        <meta name="viewport" content="width=device-width, initial-scale=1">

        <!-- Css -->
        <link rel="stylesheet" href="Assets/css/main.css">

        <!-- Fontawesome -->
        <script src="Assets/vendor/fontawesome-free-6.2.0-web/js/brands.js"></script>
        <script defer src="Assets/vendor/fontawesome-free-6.2.0-web/js/solid.js"></script>
        <script defer src="Assets/vendor/fontawesome-free-6.2.0-web/js/fontawesome.min.js"></script>
    </head>
    <body>
        <div class="container">
            <div class="header">
                <div class="row">
                    <p class="riga-img" style="top: 15px;"></p>
                    <p class="riga-img" style="top: 30px;"></p>
                    <p class="riga-img" style="top: 45px;"></p>
                    <div class="column left column-img text-center"
                        style="background-color: #eef2f5;">

                        <!-- Immagine personale -->
                        <img
                            style="filter: saturate(0.5);"
                            src="C:\ProgettiPersonali\PortFolio\PortFolio\lib\Images\profile_picture.jpg"
                            width="200"
                            height="auto"
                            class="img-personale" />
                    </div>
                    <div class="column right text-white"
                        style="background-color: #2e4a53;">
                        <!-- Nome e cognome -->
                        <h1 style="font-size: 50px; margin-bottom: 0; margin-top: 3px;">{{Nome}}
                        </h1>
                        <h1 style="font-size: 50px;">{{Cognome}}
                        </h1>
                        <hr style="border-bottom: 1px solid white">
                        <!-- Professione -->
                        <h2 class="m-auto">{{Professione}}</h2>
                        <hr style="border-bottom: 1px solid white">
                        <p>
                            <strong>Età:</strong> {{Eta}} ||
                        <strong>Nazionalità:</strong> {{Nazionalita}} ||
                        <strong>Lingua:</strong> {{Lingua}}
                        </p>
                    </div>
                </div>
            </div>
            <div class="contenuto">
                <div class="row text-secondary">
                    <div class="column left" style="background-color: #eef2f5;">
                        <!-- Contatti -->

                        <div>
                            <h2 style="margin-top: 0;">CONTATTI</h2>
                            <!-- Telefono -->
                            <div class="row">
                                <div class="column w-10 p-0">
                                    <i class="fa-solid fa-phone"></i>
                                </div>
                                <div class="column w-90 p-0">
                                    <h3 class="m-0">Telefono</h3>
                                    <p class="sub">
                                        <a href="tel:{{Telefono}}" class="link">{{Telefono}}
                                        </a>
                                    </p>
                                </div>
                            </div>
                            <!-- Email -->
                            <div class="row">
                                <div class="column w-10 p-0">
                                    <i class="fa-solid fa-envelope"></i>
                                </div>
                                <div class="column w-90 p-0">
                                    <h3 class="m-0">Email</h3>
                                    <p class="sub">
                                        <a href="mailto:{{Email}}" class="link">{{Email}}
                                        </a>
                                    </p>
                                </div>
                            </div>
                            <!-- Indirizzo -->
                            <div class="row">
                                <div class="column w-10 p-0">
                                    <i class="fa-solid fa-map-location-dot"></i>
                                </div>
                                <div class="column w-90 p-0">
                                    <h3 class="m-0">Indirizzo</h3>
                                    <p style="margin: 2px;">{{Indirizzo}}</p>
                                    <p style="margin: 2px;">Via Picena 18, 62020 (MC)</p>
                                </div>
                            </div>
                            <!-- Sito web -->
                            <div class="row">
                                <div class="column w-10 p-0">
                                    <i class="fa-solid fa-earth-europe"></i>
                                </div>
                                <div class="column w-90 p-0">
                                    <h3 class="m-0">Sito web</h3>
                                    <p class="sub">
                                        <a href="{{SitoWeb}}" class="link">{{SitoWeb}}
                                        </a>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <!-- Percorso di studi -->
                        <div>
                            <h2>PERCORSO DI STUDI</h2>
                            <!-- Percorso 1 -->
                            <div class="row border-left">
                                <div class="column w-10 p-0">
                                    <i class="fa-solid fa-arrow-right-long"></i>
                                </div>
                                <div class="column w-90 p-0">
                                    <h3 class="m-0">{{Percorso1}}</h3>
                                    <p class="sub">{{PercorsoLuogo1}}</p>
                                </div>
                            </div>
                            <!-- Percorso 2 -->
                            <div class="row border-left">
                                <div class="column w-10 p-0">
                                    <i class="fa-solid fa-arrow-right-long"></i>
                                </div>
                                <div class="column w-90 p-0">
                                    <h3 class="m-0">{{Percorso2}}</h3>
                                    <p class="sub">{{PercorsoLuogo2}}</p>
                                </div>
                            </div>
                        </div>
                        <!-- Skills -->
                        <div>
                            <h2>SKILLS</h2>
                            <!-- Skill 1 -->
                            <div class="row border-left">
                                <div class="column w-10 p-0">
                                    <i class="fa-solid fa-arrow-right-long"></i>
                                </div>
                                <div class="column w-90 p-0">
                                    <h3 class="m-0">{{Skill-1}}</h3>
                                </div>
                            </div>
                            <!-- Skill 2 -->
                            <div class="row border-left">
                                <div class="column w-10 p-0">
                                    <i class="fa-solid fa-arrow-right-long"></i>
                                </div>
                                <div class="column w-90 p-0">
                                    <h3 class="m-0">{{Skill-2}}</h3>
                                </div>
                            </div>
                            <!-- Skill 3 -->
                            <div class="row border-left">
                                <div class="column w-10 p-0">
                                    <i class="fa-solid fa-arrow-right-long"></i>
                                </div>
                                <div class="column w-90 p-0">
                                    <h3 class="m-0">{{Skill-3}}</h3>
                                </div>
                            </div>
                            <!-- Skill 4 -->
                            <div class="row border-left">
                                <div class="column w-10 p-0">
                                    <i class="fa-solid fa-arrow-right-long"></i>
                                </div>
                                <div class="column w-90 p-0">
                                    <h3 class="m-0">{{Skill-4}}</h3>
                                </div>
                            </div>
                            <!-- Skill 5 -->
                            <div class="row border-left">
                                <div class="column w-10 p-0">
                                    <i class="fa-solid fa-arrow-right-long"></i>
                                </div>
                                <div class="column w-90 p-0">
                                    <h3 class="m-0">{{Skill-5}}</h3>
                                </div>
                            </div>
                            <!-- Skill 6 -->
                            <div class="row border-left">
                                <div class="column w-10 p-0">
                                    <i class="fa-solid fa-arrow-right-long"></i>
                                </div>
                                <div class="column w-90 p-0">
                                    <h3 class="m-0">{{Skill-6}}</h3>
                                </div>
                            </div>
                            <!-- Skill 7 -->
                            <div class="row border-left">
                                <div class="column w-10 p-0">
                                    <i class="fa-solid fa-arrow-right-long"></i>
                                </div>
                                <div class="column w-90 p-0">
                                    <h3 class="m-0">{{Skill-7}}</h3>
                                </div>
                            </div>
                            <!-- Skill 8 -->
                            <div class="row border-left">
                                <div class="column w-10 p-0">
                                    <i class="fa-solid fa-arrow-right-long"></i>
                                </div>
                                <div class="column w-90 p-0">
                                    <h3 class="m-0">{{Skill-8}}</h3>
                                </div>
                            </div>
                            <!-- Skill 9 -->
                            <div class="row border-left">
                                <div class="column w-10 p-0">
                                    <i class="fa-solid fa-arrow-right-long"></i>
                                </div>
                                <div class="column w-90 p-0">
                                    <h3 class="m-0">{{Skill-9}}</h3>
                                </div>
                            </div>
                            <!-- Skill 10 -->
                            <div class="row border-left">
                                <div class="column w-10 p-0">
                                    <i class="fa-solid fa-arrow-right-long"></i>
                                </div>
                                <div class="column w-90 p-0">
                                    <h3 class="m-0">{{Skill-10}}</h3>
                                </div>
                            </div>
                            <!-- Skill 11 -->
                            <div class="row border-left">
                                <div class="column w-10 p-0">
                                    <i class="fa-solid fa-arrow-right-long"></i>
                                </div>
                                <div class="column w-90 p-0">
                                    <h3 class="m-0">{{Skill-11}}</h3>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- COLONNA DESTRA-->
                    <div class="column right" style="background-color: #ffff;">
                        <!-- Profilp -->
                        <div>
                            <h2 class="m-0">PROFILO</h2>
                            <p class="text-justify">
                                {{Profilo}}
                            </p>
                        </div>
                        <!-- Esperienza lavorativa -->
                        <div>
                            <h2>ESPERIENZA LAVORATIVA</h2>
                            <div class="row">
                                <div class="column w-75 p-0">
                                    <h3 class="m-0 ">{{Professione}}</h3>
                                </div>
                                <div class="column w-25 p-0 text-right">
                                    {{Inizio}}
                                </div>
                            </div>
                            <div class="row">
                                <div class="column w-75 p-0">
                                    <h3 class="m-0">{{Azienda}}</h3>
                                </div>
                                <div class="column w-25 p-0 text-right">
                                    {{Fine}}
                                </div>
                            </div>
                            <p class="text-justify">
                                {{Descrizione}}
                            </p>
                        </div>
                        <!-- Progetti personali -->
                        <div>
                            <h2>PROGETTI PERSONALI</h2>
                            <!-- Progetto 1 -->
                            <div class="border-bottom">
                                <div class="row">
                                    <div class="column w-60 p-0">
                                        <h3 class="m-0 ">{{Progetto1}}</h3>
                                    </div>
                                    <div class="column w-40 p-0 text-right">
                                        {{ProgettoLinguaggio1}}
                                    </div>
                                </div>
                            </div>
                            <!-- Progetto 2 -->
                            <div class="border-bottom sub">
                                <div class="row">
                                    <div class="column w-60 p-0">
                                        <h3 class="m-0 ">{{Progetto2}}</h3>
                                    </div>
                                    <div class="column w-40 p-0 text-right">
                                        {{ProgettoLinguaggio2}}
                                    </div>
                                </div>
                            </div>
                            <!-- Progetto 3 -->
                            <div class="border-bottom sub">
                                <div class="row">
                                    <div class="column w-60 p-0">
                                        <h3 class="m-0 ">{{Progetto3}}</h3>
                                    </div>
                                    <div class="column w-40 p-0 text-right">
                                        {{ProgettoLinguaggio3}}
                                    </div>
                                </div>
                            </div>
                            <!-- Progetto 4 -->
                            <div class="border-bottom sub">
                                <div class="row">
                                    <div class="column w-60 p-0">
                                        <h3 class="m-0 ">{{Progetto4}}</h3>
                                    </div>
                                    <div class="column w-40 p-0 text-right">
                                        {{ProgettoLinguaggio4}}
                                    </div>
                                </div>
                            </div>
                            <!-- Progetto 5 -->
                            <div class="border-bottom sub">
                                <div class="row">
                                    <div class="column w-60 p-0">
                                        <h3 class="m-0 ">{{Progetto5}}</h3>
                                    </div>
                                    <div class="column w-40 p-0 text-right">
                                        {{ProgettoLinguaggio5}}
                                    </div>
                                </div>
                            </div>
                            <!-- Progetto 6 -->
                            <div class="border-bottom sub">
                                <div class="row">
                                    <div class="column w-60 p-0">
                                        <h3 class="m-0 ">{{Progetto6}}</h3>
                                    </div>
                                    <div class="column w-40 p-0 text-right">
                                        {{ProgettoLinguaggio6}}
                                    </div>
                                </div>
                            </div>
                        </div>
                        <p class="footer text-right">
                            Curriculum generato in Html/Css<br>
                            Per approfondimenti consiglio la visione del mio 
                        <a class="link" href="https://www.dariscappelletti.com">sito/curriculum</a>. 
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </body>
    </html>
</asp:Content>
