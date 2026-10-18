import { useState, useEffect } from 'react';
import type { Curriculum } from '../types/curriculum';
import { emptyCurriculum } from '../types/curriculum';
import { generateCv, importFromXml } from '../api/curriculumApi';
import { AnagraficaSection } from './AnagraficaSection';
import { ContattiSection } from './ContattiSection';
import { StudiSection } from './StudiSection';
import { SkillsSection } from './SkillsSection';
import { EsperienzaSection } from './EsperienzaSection';
import { ProgettiSection } from './ProgettiSection';
import { ImageUpload } from './ImageUpload';
import { XmlImport } from './XmlImport';
import { Spinner } from './Spinner';
import { Toast } from './Toast';
import { IconDocument } from './Icons';

function getNestedValue(obj: Record<string, unknown>, path: string): string {
  const keys = path.split('.');
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  let current: any = obj;
  for (const key of keys) {
    if (current == null || typeof current !== 'object') return '';
    current = current[key];
  }
  return typeof current === 'string' ? current : '';
}

const REQUIRED_FIELDS = [
  'anagrafica.Nome',
  'anagrafica.Cognome',
  'anagrafica.Eta',
  'anagrafica.Lingua',
  'contatti.Email',
  'contatti.Telefono',
  'skills',
  'profilo',
];

const VALIDATION_FIELDS = [
  'anagrafica.Nome',
  'anagrafica.Cognome',
  'contatti.Email',
];

export function CurriculumForm() {
  const [cv, setCv] = useState<Curriculum>(emptyCurriculum);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [validationErrors, setValidationErrors] = useState<string[]>([]);
  const [toast, setToast] = useState<{ type: 'success' | 'error'; message: string } | null>(null);

  const updateCv = (partial: Partial<Curriculum>) => {
    setCv(prev => ({ ...prev, ...partial }));
  };

  // Calculate progress
  const progress = Math.round(
    (REQUIRED_FIELDS.filter(f => getNestedValue(cv as unknown as Record<string, unknown>, f).trim() !== '').length / REQUIRED_FIELDS.length) * 100
  );

  // Auto-dismiss toast
  useEffect(() => {
    if (toast) {
      const timer = setTimeout(() => setToast(null), 4000);
      return () => clearTimeout(timer);
    }
  }, [toast]);

  const handleImageUpload = (base64: string) => {
    updateCv({ hidImgBase64: base64 });
  };

  const handleGenerate = async () => {
    // Validate required fields
    const errors: string[] = [];
    for (const field of VALIDATION_FIELDS) {
      if (getNestedValue(cv as unknown as Record<string, unknown>, field).trim() === '') {
        errors.push(field);
      }
    }

    if (errors.length > 0) {
      setValidationErrors(errors);
      setToast({ type: 'error', message: 'Compila i campi obbligatori: Nome, Cognome, Email' });
      return;
    }

    setValidationErrors([]);
    setLoading(true);
    setError(null);
    try {
      const blob = await generateCv(cv);
      const url = URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = `Curriculum - ${cv.anagrafica.Nome} ${cv.anagrafica.Cognome}.zip`;
      a.click();
      URL.revokeObjectURL(url);
      setToast({ type: 'success', message: 'Curriculum generato con successo!' });
    } catch (err) {
      setToast({ type: 'error', message: err instanceof Error ? err.message : 'Errore imprevisto' });
    } finally {
      setLoading(false);
    }
  };

  const handleXmlImport = async (file: File) => {
    setLoading(true);
    setError(null);
    try {
      const imported = await importFromXml(file);
      setCv(imported);
      setToast({ type: 'success', message: 'Curriculum importato con successo!' });
    } catch (err) {
      setToast({ type: 'error', message: err instanceof Error ? err.message : "Errore nell'importazione XML" });
    } finally {
      setLoading(false);
    }
  };

  const hasError = (field: string) => validationErrors.includes(field);

  return (
    <div className="curriculum-form">
      <header className="form-header">
        <h1 className="form-header__title">Generatore di Curriculum</h1>
        <p className="form-header__subtitle">Compila i tuoi dati per creare un CV professionale</p>
      </header>

      {toast && (
        <Toast type={toast.type} message={toast.message} onClose={() => setToast(null)} />
      )}

      <div className="progress-bar-container">
        <div className="progress-bar-label">
          <span>Completamento</span>
          <span>{progress}%</span>
        </div>
        <div className="progress-bar-track">
          <div className="progress-bar-fill" style={{ width: `${progress}%` }} />
        </div>
      </div>

      <XmlImport onImport={handleXmlImport} loading={loading} />

      <ImageUpload onImageUpload={handleImageUpload} currentImage={cv.hidImgBase64} />

      <AnagraficaSection
        anagrafica={cv.anagrafica}
        onChange={a => updateCv({ anagrafica: a })}
        errors={validationErrors}
      />

      <ContattiSection
        contatti={cv.contatti}
        onChange={c => updateCv({ contatti: c })}
        errors={validationErrors}
      />

      <StudiSection
        percorsoDiStudi={cv.percorsoDiStudi}
        onChange={p => updateCv({ percorsoDiStudi: p })}
      />

      <SkillsSection
        skills={cv.skills}
        onChange={s => updateCv({ skills: s })}
      />

      <EsperienzaSection
        esperienzaLavorativa={cv.esperienzaLavorativa}
        onChange={e => updateCv({ esperienzaLavorativa: e })}
      />

      <div className="section">
        <h2 className="section-title">
          <IconDocument className="section-icon" size={20} />
          Profilo
        </h2>
        <div className="form-group">
          <textarea
            value={cv.profilo}
            onChange={e => updateCv({ profilo: e.target.value })}
            placeholder="Descrivi il tuo profilo professionale..."
            rows={4}
          />
        </div>
      </div>

      <ProgettiSection
        progetti={cv.progettiPersonali}
        onChange={p => updateCv({ progettiPersonali: p })}
      />

      <button
        className="btn-generate"
        onClick={handleGenerate}
        disabled={loading}
      >
        {loading ? (
          <>
            <Spinner size={18} />
            Generazione in corso...
          </>
        ) : (
          'Genera Curriculum (PDF + XML)'
        )}
      </button>
    </div>
  );
}