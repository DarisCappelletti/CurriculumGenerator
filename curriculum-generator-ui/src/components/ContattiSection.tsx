import type { Contatti } from '../types/curriculum';
import { IconEnvelope } from './Icons';

interface Props {
  contatti: Contatti;
  onChange: (c: Contatti) => void;
  errors?: string[];
}

export function ContattiSection({ contatti, onChange, errors = [] }: Props) {
  const update = (field: keyof Contatti, value: string) => {
    onChange({ ...contatti, [field]: value });
  };

  const hasError = (field: string) => errors.includes(field);

  return (
    <div className="section">
      <h2 className="section-title">
        <IconEnvelope className="section-icon" size={20} />
        Contatti
      </h2>
      <div className="form-grid">
        <div className="form-group">
          <label>Telefono</label>
          <input type="tel" value={contatti.Telefono} onChange={e => update('Telefono', e.target.value)} placeholder="+39 333 1234567" autoComplete="tel" />
        </div>
        <div className={`form-group${hasError('contatti.Email') ? ' form-group--invalid' : ''}`}>
          <label>Email *</label>
          <input type="email" value={contatti.Email} onChange={e => update('Email', e.target.value)} placeholder="mario.rossi@email.com" autoComplete="email" />
          {hasError('contatti.Email') && <span className="form-group__error">L'email è obbligatoria</span>}
        </div>
        <div className="form-group">
          <label>Indirizzo</label>
          <input type="text" value={contatti.Indirizzo} onChange={e => update('Indirizzo', e.target.value)} placeholder="Roma, Italia" />
        </div>
        <div className="form-group">
          <label>Sito Web</label>
          <input type="url" value={contatti.SitoWeb} onChange={e => update('SitoWeb', e.target.value)} placeholder="https://mariosito.it" />
        </div>
      </div>
    </div>
  );
}