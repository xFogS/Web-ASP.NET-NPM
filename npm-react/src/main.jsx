import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import "../src/assets/css/styles.css"
import App from '../src/App.jsx'

createRoot(document.getElementById('root')).render(
    <StrictMode>
        <App />
    </StrictMode>,
)