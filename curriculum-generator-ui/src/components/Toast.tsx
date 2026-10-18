import { IconCheck, IconError } from './Icons';

interface ToastProps {
  type: 'success' | 'error';
  message: string;
  onClose: () => void;
}

export function Toast({ type, message, onClose }: ToastProps) {
  return (
    <div className={`toast toast--${type}`} role="alert">
      {type === 'success' ? <IconCheck size={20} /> : <IconError size={20} />}
      <span>{message}</span>
      <button className="toast__close" onClick={onClose} aria-label="Chiudi">&times;</button>
    </div>
  );
}