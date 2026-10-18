import { useState, useRef, type ReactNode } from 'react';

interface DropZoneProps {
  accept: string;
  onFile: (file: File) => void;
  disabled?: boolean;
  label: string;
  hint: string;
  icon: ReactNode;
  children?: ReactNode;
}

export function DropZone({ accept, onFile, disabled = false, label, hint, icon, children }: DropZoneProps) {
  const [isDragOver, setIsDragOver] = useState(false);
  const inputRef = useRef<HTMLInputElement>(null);

  const handleDragOver = (e: React.DragEvent) => {
    e.preventDefault();
    if (!disabled) setIsDragOver(true);
  };

  const handleDragLeave = (e: React.DragEvent) => {
    e.preventDefault();
    setIsDragOver(false);
  };

  const handleDrop = (e: React.DragEvent) => {
    e.preventDefault();
    setIsDragOver(false);
    if (disabled) return;
    const file = e.dataTransfer.files[0];
    if (file) onFile(file);
  };

  const handleClick = () => {
    if (!disabled) inputRef.current?.click();
  };

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];
    if (file) onFile(file);
    if (inputRef.current) inputRef.current.value = '';
  };

  const className = [
    'drop-zone',
    isDragOver && 'drop-zone--active',
    disabled && 'drop-zone--disabled',
  ].filter(Boolean).join(' ');

  return (
    <div
      className={className}
      onClick={handleClick}
      onDragOver={handleDragOver}
      onDragLeave={handleDragLeave}
      onDrop={handleDrop}
    >
      <input
        ref={inputRef}
        type="file"
        accept={accept}
        onChange={handleFileChange}
        style={{ display: 'none' }}
      />
      <div className="drop-zone__icon">{icon}</div>
      <div className="drop-zone__label">{label}</div>
      <div className="drop-zone__hint">{hint}</div>
      {children}
    </div>
  );
}