import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import CreateSalon from './Components/CreateSalon';
import LoginPage from './Components/LoginPage';
//import Login from './Components/Login';

function App() {
  return (
    <Router>
      <div className="App">
        <h1>Welcome to Salon System</h1>
        <nav>
          <Link to="/">Create a Salon</Link>
        </nav>
        <Routes>
          <Route path="/" element={<CreateSalon />} />
          <Route path="/login" element={<LoginPage />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;