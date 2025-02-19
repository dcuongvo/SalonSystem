import React, { useState, useContext } from 'react';
import { useNavigate } from 'react-router-dom';
import { loginUser } from '../api/authApi';
import { AuthContext } from '../contexts/AuthContext'; // Import the AuthContext
import './LoginPage.css';

const LoginPage: React.FC = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [message, setMessage] = useState('');
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();
    const { setIsAuthenticated, validateToken } = useContext(AuthContext); // Use AuthContext here

    const handleLogin = async (e: React.FormEvent) => {
        e.preventDefault();
        setMessage('');
        setLoading(true);

        try {
            const token = await loginUser({ username, password });
            localStorage.setItem('token', token.token); 
            setIsAuthenticated(true);
            validateToken(); 
            setMessage('Login successful!');
            setTimeout(() => navigate('/'), 2000);
        } catch (error: unknown) {
            setMessage(error instanceof Error ? error.message : 'Login failed. Please try again.');
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="login-page">
            <form className="login-form" onSubmit={handleLogin}>
                <h2>Login</h2>
                <div>
                    <label>Username:</label>
                    <input
                        type="text"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        placeholder="Enter username"
                        required
                    />
                </div>
                <div>
                    <label>Password:</label>
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        placeholder="Enter password"
                        required
                    />
                </div>
                <button type="submit" disabled={loading}>
                    {loading ? 'Logging in...' : 'Login'}
                </button>
                {message && <p className="error-message">{message}</p>}
            </form>
        </div>
    );
};

export default LoginPage;
