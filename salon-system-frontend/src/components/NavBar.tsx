import React, { useContext } from 'react';
import { Link } from 'react-router-dom';
import './NavBar.css';
import UserDropdown from '../components/UserDropdown';
import { AuthContext } from '../contexts/AuthContext'; // Updated to contexts if that's the directory name

const NavBar: React.FC = () => {
    const { isAuthenticated } = useContext(AuthContext);

    return (
        <nav className="nav-bar">
            <div className="nav-left">
                <Link to="/">Home</Link>
                <Link to="/browse">Browse</Link>
            </div>
            <div className="nav-right">
                {isAuthenticated ? (
                    <UserDropdown />
                ) : (
                    <>
                        <Link to="/login">Login</Link>
                        <Link to="/register">Create Account</Link>
                    </>
                )}
            </div>
        </nav>
    );
};

export default NavBar;
