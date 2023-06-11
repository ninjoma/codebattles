import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  server: {
    proxy: {
      '/api': {
        target: 'https://codebattlesapi.azurewebsites.net/',
        changeOrigin: true,
        rewrite: (path) => path.replace(/^\/api/, ''),
        ignorePath: true,
        headers: {
          'Arr-Disable-Session-Affinity' : 'True',
        }
      }
    }
  }
})

