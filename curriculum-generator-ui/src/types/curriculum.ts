export interface Anagrafica {
  Nome: string;
  Cognome: string;
  Eta: string;
  Nazionalita: string;
  Lingua: string;
}

export interface Contatti {
  Telefono: string;
  Email: string;
  Indirizzo: string;
  SitoWeb: string;
}

export interface PercorsoDiStudi {
  Percorso1: string;
  PercorsoLuogo1: string;
  Percorso2: string;
  PercorsoLuogo2: string;
}

export interface EsperienzaLavorativa {
  Professione: string;
  Azienda: string;
  DataInizio: string;
  DataFine: string;
  Descrizione: string;
}

export interface ProgettoPersonale {
  Progetto: string;
  Linguaggio: string;
}

export interface Curriculum {
  hidImgBase64: string;
  anagrafica: Anagrafica;
  contatti: Contatti;
  percorsoDiStudi: PercorsoDiStudi;
  skills: string;
  profilo: string;
  esperienzaLavorativa: EsperienzaLavorativa;
  progettiPersonali: ProgettoPersonale[];
}

export const emptyCurriculum: Curriculum = {
  hidImgBase64: '',
  anagrafica: { Nome: '', Cognome: '', Eta: '', Nazionalita: '', Lingua: '' },
  contatti: { Telefono: '', Email: '', Indirizzo: '', SitoWeb: '' },
  percorsoDiStudi: { Percorso1: '', PercorsoLuogo1: '', Percorso2: '', PercorsoLuogo2: '' },
  skills: '',
  profilo: '',
  esperienzaLavorativa: { Professione: '', Azienda: '', DataInizio: '', DataFine: '', Descrizione: '' },
  progettiPersonali: [{ Progetto: '', Linguaggio: '' }],
};