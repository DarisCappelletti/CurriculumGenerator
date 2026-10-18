import type { ProgettoPersonale } from '../types/curriculum';
import { IconCode } from './Icons';

interface Props {
  progetti: ProgettoPersonale[];
  onChange: (p: ProgettoPersonale[]) => void;
}

export function ProgettiSection({ progetti, onChange }: Props) {
  const MAX_PROJECTS = 6;

  const addProject = () => {
    if (progetti.length < MAX_PROJECTS) {
      onChange([...progetti, { Progetto: '', Linguaggio: '' }]);
    }
  };

  const removeProject = (index: number) => {
    onChange(progetti.filter((_, i) => i !== index));
  };

  const updateProject = (index: number, field: keyof ProgettoPersonale, value: string) => {
    const updated = progetti.map((p, i) => i === index ? { ...p, [field]: value } : p);
    onChange(updated);
  };

  return (
    <div className="section">
      <h2 className="section-title">
        <IconCode className="section-icon" size={20} />
        Progetti Personali
      </h2>
      {progetti.map((progetto, index) => (
        <div key={index} className="project-row">
          <div className="form-group">
            <label>Progetto {index + 1}</label>
            <input
              type="text"
              value={progetto.Progetto}
              onChange={e => updateProject(index, 'Progetto', e.target.value)}
              placeholder="Nome del progetto"
            />
          </div>
          <div className="form-group">
            <label>Linguaggio/Tecnologia</label>
            <input
              type="text"
              value={progetto.Linguaggio}
              onChange={e => updateProject(index, 'Linguaggio', e.target.value)}
              placeholder="es. React, Python, C#..."
            />
          </div>
          <button className="btn-remove" onClick={() => removeProject(index)} title="Rimuovi progetto">
            &times;
          </button>
        </div>
      ))}
      {progetti.length < MAX_PROJECTS && (
        <button className="btn-add" onClick={addProject}>+ Aggiungi progetto</button>
      )}
    </div>
  );
}