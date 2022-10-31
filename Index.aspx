<%@ Page
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Index.aspx.cs"
    MasterPageFile="~/Site.Master"
    Inherits="PortFolio.CurriculumGenerator.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div>
            <h1>Generatore curriculum</h1>
            <h2>Tool per la generazione automatica di un curriculum con un template preimpostato.</h2>
        </div>

        <div class="accordion" id="accordionFormCurriculum">
            <!-- Anagrafica -->
            <div class="accordion-item">
                <h2 class="accordion-header" id="headAnagrafica">
                    <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#divAnagrafica" aria-expanded="true" aria-controls="divAnagrafica">
                        Anagrafica
                    </button>
                </h2>
                <div id="divAnagrafica" class="accordion-collapse collapse show" aria-labelledby="headAnagrafica" data-bs-parent="#accordionFormCurriculum">
                    <div class="accordion-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div>
                                    <label for="txtNome" class="form-label">Nome</label>
                                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="txtCognome" class="form-label">Cognome</label>
                                <asp:TextBox ID="txtCognome" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-6">
                                <label for="txtEta" class="form-label">Età</label>
                                <asp:TextBox ID="txtEta" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-6">
                                <label for="txtNazionalita" class="form-label">Nazionalità</label>
                                <asp:TextBox ID="txtNazionalita" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-6">
                                <label for="txtLingue" class="form-label">Lingue</label>
                                <asp:TextBox ID="txtLingue" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Contatti -->
            <div class="accordion-item">
                <h2 class="accordion-header" id="headContatti">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#divContatti" aria-expanded="false" aria-controls="divContatti">
                        Contatti
                    </button>
                </h2>
                <div id="divContatti" class="accordion-collapse collapse" aria-labelledby="headContatti" data-bs-parent="#accordionFormCurriculum">
                    <div class="accordion-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div>
                                    <label for="txtTelefono" class="form-label">Telefono</label>
                                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div>
                                    <label for="txtEmail" class="form-label">Email</label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div>
                                    <label for="txtIndirizzo" class="form-label">Indirizzo</label>
                                    <asp:TextBox ID="txtIndirizzo" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div>
                                    <label for="txtSitoWeb" class="form-label">Sito web</label>
                                    <asp:TextBox ID="txtSitoWeb" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Percorso di studi -->
            <div class="accordion-item">
                <h2 class="accordion-header" id="headPercorsoDiStudi">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#divPercorsoDiStudi" aria-expanded="false" aria-controls="divPercorsoDiStudi">
                        Percorso di studi
                    </button>
                </h2>
                <div id="divPercorsoDiStudi" class="accordion-collapse collapse" aria-labelledby="headPercorsoDiStudi" data-bs-parent="#accordionFormCurriculum">
                    <div class="accordion-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div>
                                    <label for="txtPercorso1" class="form-label">Titolo di studio</label>
                                    <asp:TextBox ID="txtPercorso1" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div>
                                    <label for="txtPercorsoLuogo1" class="form-label">Luogo</label>
                                    <asp:TextBox ID="txtPercorsoLuogo1" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div>
                                    <label for="txtPercorso2" class="form-label">Titolo di studio</label>
                                    <asp:TextBox ID="txtPercorso2" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div>
                                    <label for="txtPercorsoLuogo2" class="form-label">Luogo</label>
                                    <asp:TextBox ID="txtPercorsoLuogo2" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Skills -->
            <div class="accordion-item">
                <h2 class="accordion-header" id="headSkills">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#divSkills" aria-expanded="false" aria-controls="divSkills">
                        Skills
                    </button>
                </h2>
                <div id="divSkills" class="accordion-collapse collapse" aria-labelledby="headSkills" data-bs-parent="#accordionFormCurriculum">
                    <div class="accordion-body">
                        <div>
                            <label for="txtSkills" class="form-label">Skills</label>
                            <asp:TextBox ID="txtSkills" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- Profilo -->
            <div class="accordion-item">
                <h2 class="accordion-header" id="headProfilo">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#divProfilo" aria-expanded="false" aria-controls="divProfilo">
                        Profilo
                    </button>
                </h2>
                <div id="divProfilo" class="accordion-collapse collapse" aria-labelledby="headProfilo" data-bs-parent="#accordionFormCurriculum">
                    <div class="accordion-body">
                        <div>
                            <label for="txtProfilo" class="form-label">Profilo</label>
                            <asp:TextBox ID="txtProfilo" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- Esperienza lavorativa -->
            <div class="accordion-item">
                <h2 class="accordion-header" id="headEsperienzaLavorativa">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#divEsperienzaLavorativa" aria-expanded="false" aria-controls="divEsperienzaLavorativa">
                        Esperienza lavorativa
                    </button>
                </h2>
                <div id="divEsperienzaLavorativa" class="accordion-collapse collapse" aria-labelledby="headEsperienzaLavorativa" data-bs-parent="#accordionFormCurriculum">
                    <div class="accordion-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div>
                                    <label for="txtProfessione" class="form-label">Professione</label>
                                    <asp:TextBox ID="txtProfessione" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div>
                                    <label for="txtAzienda" class="form-label">Azienda</label>
                                    <asp:TextBox ID="txtAzienda" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div>
                                    <label for="txtDataInizio" class="form-label">Data inizio</label>
                                    <asp:TextBox ID="txtDataInizio" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div>
                                    <label for="txtDataFine" class="form-label">Data fine</label>
                                    <asp:TextBox ID="txtDataFine" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div>
                                    <label for="txtDescrizione" class="form-label">Descrizione</label>
                                    <asp:TextBox ID="txtDescrizione" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Progetti personali -->
            <div class="accordion-item">
                <h2 class="accordion-header" id="headProgettiPersonali">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#divProgettiPersonali" aria-expanded="false" aria-controls="divProgettiPersonali">
                        Progetti personali
                    </button>
                </h2>
                <div id="divProgettiPersonali" class="accordion-collapse collapse" aria-labelledby="headProgettiPersonali" data-bs-parent="#accordionFormCurriculum">
                    <div class="accordion-body">
                        <div class="row">
                            <!-- 1 -->
                            <div class="col-md-6">
                                <div>
                                    <label for="txtProgetto1" class="form-label">Progetto</label>
                                    <asp:TextBox ID="txtProgetto1" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div>
                                    <label for="txtProgettoLinguaggio1" class="form-label">Linguaggio</label>
                                    <asp:TextBox ID="txtProgettoLinguaggio1" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            
                            <!-- 2 -->
                            <div class="col-md-6">
                                <div>
                                    <label for="txtProgetto2" class="form-label">Progetto</label>
                                    <asp:TextBox ID="txtProgetto2" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div>
                                    <label for="txtProgettoLinguaggio2" class="form-label">Linguaggio</label>
                                    <asp:TextBox ID="txtProgettoLinguaggio2" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <!-- 3 -->
                            <div class="col-md-6">
                                <div>
                                    <label for="txtProgetto3" class="form-label">Progetto</label>
                                    <asp:TextBox ID="txtProgetto3" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div>
                                    <label for="txtProgettoLinguaggio3" class="form-label">Linguaggio</label>
                                    <asp:TextBox ID="txtProgettoLinguaggio3" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <!-- 4 -->
                            <div class="col-md-6">
                                <div>
                                    <label for="txtProgetto4" class="form-label">Progetto</label>
                                    <asp:TextBox ID="txtProgetto4" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div>
                                    <label for="txtProgettoLinguaggio4" class="form-label">Linguaggio</label>
                                    <asp:TextBox ID="txtProgettoLinguaggio4" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <!-- 5 -->
                            <div class="col-md-6">
                                <div>
                                    <label for="txtProgetto5" class="form-label">Progetto</label>
                                    <asp:TextBox ID="txtProgetto5" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div>
                                    <label for="txtProgettoLinguaggio5" class="form-label">Linguaggio</label>
                                    <asp:TextBox ID="txtProgettoLinguaggio5" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <!-- 6 -->
                            <div class="col-md-6">
                                <div>
                                    <label for="txtProgetto6" class="form-label">Progetto</label>
                                    <asp:TextBox ID="txtProgetto6" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div>
                                    <label for="txtProgettoLinguaggio6" class="form-label">Linguaggio</label>
                                    <asp:TextBox ID="txtProgettoLinguaggio6" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:Button ID="btnCreaCurriculum" runat="server" CssClass="btn btn-primary" OnClick="btnCreaCurriculum_Click" Text="Crea curriculum" />
    </div>
</asp:Content>

