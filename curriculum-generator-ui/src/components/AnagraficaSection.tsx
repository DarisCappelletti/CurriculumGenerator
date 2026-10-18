import type { Anagrafica } from '../types/curriculum';
import { IconPerson } from './Icons';

interface Props {
  anagrafica: Anagrafica;
  onChange: (a: Anagrafica) => void;
  errors?: string[];
}

export function AnagraficaSection({ anagrafica, onChange, errors = [] }: Props) {
  const update = (field: keyof Anagrafica, value: string) => {
    onChange({ ...anagrafica, [field]: value });
  };

  const hasError = (field: string) => errors.includes(field);

  return (
    <div className="section">
      <h2 className="section-title">
        <IconPerson className="section-icon" size={20} />
        Anagrafica
      </h2>
      <div className="form-grid">
        <div className={`form-group${hasError('anagrafica.Nome') ? ' form-group--invalid' : ''}`}>
          <label>Nome *</label>
          <input type="text" value={anagrafica.Nome} onChange={e => update('Nome', e.target.value)} placeholder="Mario" autoComplete="given-name" />
          {hasError('anagrafica.Nome') && <span className="form-group__error">Il nome è obbligatorio</span>}
        </div>
        <div className={`form-group${hasError('anagrafica.Cognome') ? ' form-group--invalid' : ''}`}>
          <label>Cognome *</label>
          <input type="text" value={anagrafica.Cognome} onChange={e => update('Cognome', e.target.value)} placeholder="Rossi" autoComplete="family-name" />
          {hasError('anagrafica.Cognome') && <span className="form-group__error">Il cognome è obbligatorio</span>}
        </div>
        <div className="form-group">
          <label>Età</label>
          <input type="text" value={anagrafica.Eta} onChange={e => update('Eta', e.target.value)} placeholder="30" inputMode="numeric" />
        </div>
        <div className="form-group">
          <label>Nazionalità</label>
          <input type="text" value={anagrafica.Nazionalita} onChange={e => update('Nazionalita', e.target.value)} placeholder="Italiana" />
        </div>
        <div className="form-group">
          <label>Lingua</label>
          <input type="text" value={anagrafica.Lingua} onChange={e => update('Lingua', e.target.value)} placeholder="Italiano, Inglese" />
        </div>
      </div>
    </div>
  );
}