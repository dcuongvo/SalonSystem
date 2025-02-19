    import React from 'react';
    import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
    import LoginPage from './pages/LoginPage';
    import RegisterPage from './pages/RegisterPage';
    import HomePage from './pages/HomePage';
    import UserDashboard from './pages/UserDashboard';
    import SalonDashboard from './pages/SalonDashboard';
    import NavBar from './components/NavBar';
    import ProtectedRoute from './components/ProtectedRoute';
    import './App.css';

    const App: React.FC = () => {
        return (
            <Router>
                <NavBar />
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/login" element={<LoginPage />} />
                    <Route path="/register" element={<RegisterPage />} />
                    <Route path="/dashboard"element={<ProtectedRoute><UserDashboard /></ProtectedRoute>}/>
                    <Route path="/dashboard"element={<ProtectedRoute><SalonDashboard /></ProtectedRoute>}/>
                </Routes>
            </Router>
        );
    };

    export default App;
