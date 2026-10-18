import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  // Base relativa: la build funziona hostata in qualsiasi sottocartella
  base: './',
  server: {
    // Porta 3000: quella attesa dal middleware di sviluppo ASP.NET (CRA-style),
    // qualunque porta controlli la trova. host: tutti gli indirizzi (IPv4+IPv6),
    // perché il polling risolve "localhost" ora come ::1 ora come 127.0.0.1
    host: true,
    port: 3000,
    strictPort: true,
    proxy: {
      '/api': {
        target: 'https://localhost:5001',
        changeOrigin: true,
        secure: false,
      },
    },
  },
})