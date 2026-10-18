import type { EsperienzaLavorativa } from '../types/curriculum';
import { IconBriefcase } from './Icons';

interface Props {
  esperienzaLavorativa: EsperienzaLavorativa;
  onChange: (e: EsperienzaLavorativa) => void;
}

export function EsperienzaSection({ esperienzaLavorativa, onChange }: Props) {
  const update = (field: keyof EsperienzaLavorativa, value: string) => {
    onChange({ ...esperienzaLavorativa, [field]: value });
  };

  return (
    <div className="section">
      <h2 className="section-title">
        <IconBriefcase className="section-icon" size={20} />
        Esperienza Lavorativa
      </h2>
      <div className="form-grid">
        <div className="form-group">
          <label>Professione</label>
          <input type="text" value={esperienzaLavorativa.Professione} onChange={e => update('Professione', e.target.value)} placeholder="Sviluppatore Software" />
        </div>
        <div className="form-group">
          <label>Azienda</label>
          <input type="text" value={esperienzaLavorativa.Azienda} onChange={e => update('Azienda', e.target.value)} placeholder="Nome Azienda S.r.l." />
        </div>
        <div className="form-group">
          <label>Data Inizio</label>
          <input type="text" value={esperienzaLavorativa.DataInizio} onChange={e => update('DataInizio', e.target.value)} placeholder="Gennaio 2020" />
        </div>
        <div className="form-group">
          <label>Data Fine</label>
          <input type="text" value={esperienzaLavorativa.DataFine} onChange={e => update('DataFine', e.target.value)} placeholder="In corso" />
        </div>
      </div>
      <div className="form-group" style={{ marginTop: '16px' }}>
        <label>Descrizione</label>
        <textarea
          value={esperienzaLavorativa.Descrizione}
          onChange={e => update('Descrizione', e.target.value)}
          rows={3}
          placeholder="Descrivi la tua esperienza lavorativa..."
        />
      </div>
    </div>
  );
}