import type { Curriculum } from '../types/curriculum';

// Relativo alla pagina, così l'app funziona anche hostata in una sottocartella
const API_BASE = 'api/curriculum';

export async function generateCv(curriculum: Curriculum): Promise<Blob> {
  const response = await fetch(`${API_BASE}/generate`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(curriculum),
  });

  if (!response.ok) throw new Error('Errore nella generazione del CV');

  return response.blob();
}

export async function importFromXml(file: File): Promise<Curriculum> {
  const formData = new FormData();
  formData.append('file', file);

  const response = await fetch(`${API_BASE}/from-xml`, {
    method: 'POST',
    body: formData,
  });

  if (!response.ok) throw new Error('Errore nell\'importazione del file XML');

  return response.json();
}