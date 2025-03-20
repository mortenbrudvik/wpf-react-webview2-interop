import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import * as path from 'path';

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  resolve: {
    alias: {
      'users': path.resolve(__dirname, 'src/users')
    }
  },
  build: {
    rollupOptions: {
      output: {
        // Customize JS output
        entryFileNames: 'index.js',
        chunkFileNames: 'index.js', // For dynamic imports, if any
        // Customize CSS output
        assetFileNames: (assetInfo) => {
          if (assetInfo.name && assetInfo.name.endsWith('.css')) {
            return 'index.css';
          }
          return assetInfo.name || 'default-asset-name'; // Ensure a string is always returned
        },
      },
    },
  },
})
