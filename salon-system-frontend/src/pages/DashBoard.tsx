import React from 'react';
import { Link } from 'react-router-dom';
import './DashBoard.css';

const DashBoard: React.FC = () => {
    return (
        <div className="container">
            <h1>Welcome to DashBoard</h1>
            <p>Manage your salon efficiently with our system.</p>
            <div className="links">
                <Link to="/login" className="link">Login</Link>
                <Link to="/register" className="link">Register</Link>
            </div>
        </div>
    );
};

export default DashBoard;
