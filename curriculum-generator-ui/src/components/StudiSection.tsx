import type { PercorsoDiStudi } from '../types/curriculum';
import { IconGraduation } from './Icons';

interface Props {
  percorsoDiStudi: PercorsoDiStudi;
  onChange: (p: PercorsoDiStudi) => void;
}

export function StudiSection({ percorsoDiStudi, onChange }: Props) {
  const update = (field: keyof PercorsoDiStudi, value: string) => {
    onChange({ ...percorsoDiStudi, [field]: value });
  };

  return (
    <div className="section">
      <h2 className="section-title">
        <IconGraduation className="section-icon" size={20} />
        Percorso di Studi
      </h2>
      <div className="form-grid">
        <div className="form-group">
          <label>Percorso 1</label>
          <input type="text" value={percorsoDiStudi.Percorso1} onChange={e => update('Percorso1', e.target.value)} placeholder="Laurea in Informatica" />
        </div>
        <div className="form-group">
          <label>Luogo 1</label>
          <input type="text" value={percorsoDiStudi.PercorsoLuogo1} onChange={e => update('PercorsoLuogo1', e.target.value)} placeholder="Università di Roma" />
        </div>
        <div className="form-group">
          <label>Percorso 2</label>
          <input type="text" value={percorsoDiStudi.Percorso2} onChange={e => update('Percorso2', e.target.value)} placeholder="Diploma di Maturità" />
        </div>
        <div className="form-group">
          <label>Luogo 2</label>
          <input type="text" value={percorsoDiStudi.PercorsoLuogo2} onChange={e => update('PercorsoLuogo2', e.target.value)} placeholder="Liceo Scientifico" />
        </div>
      </div>
    </div>
  );
}