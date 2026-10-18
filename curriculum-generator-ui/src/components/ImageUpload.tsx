import { IconCamera } from './Icons';
import { DropZone } from './DropZone';

interface Props {
  onImageUpload: (base64: string) => void;
  currentImage: string;
}

export function ImageUpload({ onImageUpload, currentImage }: Props) {
  const handleFile = (file: File) => {
    const reader = new FileReader();
    reader.onload = () => {
      const result = reader.result as string;
      const base64 = result.split(',')[1];
      onImageUpload(base64);
    };
    reader.readAsDataURL(file);
  };

  const handleRemove = () => {
    onImageUpload('');
  };

  return (
    <div className="section">
      <h2 className="section-title">
        <IconCamera className="section-icon" size={20} />
        Foto Profilo
      </h2>
      {currentImage ? (
        <div className="image-preview">
          <img src={`data:image/png;base64,${currentImage}`} alt="Foto profilo" />
          <button className="btn-remove-image" onClick={handleRemove}>Rimuovi</button>
        </div>
      ) : (
        <DropZone
          accept="image/*"
          onFile={handleFile}
          label="Carica una foto"
          hint="Trascina un'immagine qui o clicca per selezionare"
          icon={<IconCamera size={40} />}
        />
      )}
    </div>
  );
}