import React, { useState, useContext } from 'react';
import { useNavigate } from 'react-router-dom';
import './UserDropdown.css';
import { AuthContext } from '../contexts/AuthContext';
import api from '../api/api'; // Ensure your centralized Axios instance is imported

const UserDropdown: React.FC = () => {
    const [showMenu, setShowMenu] = useState(false);
    const { setIsAuthenticated, logout } = useContext(AuthContext); // Updated to include logout from context
    const navigate = useNavigate();

    const handleLogout = async () => {
        try {
            // Call logout API if needed
            await api.post('/auth/logout'); // Adjust if your backend supports this endpoint
            logout(); // Clear token and update context state
            navigate('/login'); // Redirect to login
        } catch (error) {
            console.error("Logout failed:", error);
            logout(); // Ensure logout state is still updated
        }
    };

    return (
        <div className="user-dropdown-container">
            <div className="user-icon" onClick={() => setShowMenu((prev) => !prev)}>
                <span>👤</span> {/* User Icon */}
            </div>
            {showMenu && (
                <div className="user-dropdown-menu">
                    <ul>
                        <li onClick={() => navigate('/dashboard')}>User Dashboard</li> {/* Added UserDashboard */}
                        <li onClick={handleLogout}>Logout</li> {/* Logout using context and API */}
                    </ul>
                </div>
            )}
        </div>
    );
};

export default UserDropdown;
