import { IconUpload } from './Icons';
import { DropZone } from './DropZone';

interface Props {
  onImport: (file: File) => void;
  loading: boolean;
}

export function XmlImport({ onImport, loading }: Props) {
  return (
    <div className="section xml-import">
      <h2 className="section-title">
        <IconUpload className="section-icon" size={20} />
        Importa da XML
      </h2>
      <DropZone
        accept=".xml"
        onFile={onImport}
        disabled={loading}
        label="Importa curriculum XML"
        hint="Trascina un file XML qui o clicca per selezionare"
        icon={<IconUpload size={40} />}
      />
    </div>
  );
}