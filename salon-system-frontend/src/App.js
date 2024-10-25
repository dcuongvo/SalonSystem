import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomePage from './pages/HomePage';
import CreateSalonPage from './pages/CreateSalonPage';
import LoginPage from './pages/LoginPage';
import SalonMenuPage from './pages/SalonMenuPage';
import { SalonProvider } from './contexts/SalonContext'

function App() {
  return (
    <SalonProvider> 
    <Router>
      <Routes>
      <Route path="/" element={<HomePage />} />
        <Route path="/create-salon" element={<CreateSalonPage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/salon-menu" element={<SalonMenuPage />} />
      </Routes>
    </Router>
    </SalonProvider>
  );
}

export default App;
