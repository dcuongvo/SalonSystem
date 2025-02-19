import React from 'react';
import { Link } from 'react-router-dom';
import './HomePage.css';

const HomePage: React.FC = () => {
    return (
        <div className="container">
            <h1>Welcome to Salon System</h1>
            <p>Manage your salon efficiently with our system.</p>
            <div className="links">
                <Link to="/login" className="link">Login</Link>
                <Link to="/register" className="link">Register</Link>
            </div>
        </div>
    );
};

export default HomePage;
