import React, { createContext, useState, useEffect } from 'react';
import {jwtDecode} from 'jwt-decode';

export interface AuthContextType {
    isAuthenticated: boolean;
    setIsAuthenticated: React.Dispatch<React.SetStateAction<boolean>>;
    logout: () => void;
    validateToken: () => boolean;
}

export const AuthContext = createContext<AuthContextType>({
    isAuthenticated: false,
    setIsAuthenticated: () => {},
    logout: () => {},
    validateToken: () => false,
});

export const AuthProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const [isAuthenticated, setIsAuthenticated] = useState(false);

    const validateToken = (): boolean => {
        const token = localStorage.getItem('token');
        if (!token) return false;

        try {
            const decoded: { exp: number } = jwtDecode(token);
            const currentTime = Math.floor(Date.now() / 1000);
            if (decoded.exp > currentTime) {
                setIsAuthenticated(true);
                return true;
            } else {
                localStorage.removeItem('token'); // Token expired
                setIsAuthenticated(false);
                return false;
            }
        } catch {
            localStorage.removeItem('token'); // Invalid token
            setIsAuthenticated(false);
            return false;
        }
    };

    const logout = () => {
        localStorage.removeItem('token');
        setIsAuthenticated(false);
    };

    useEffect(() => {
        validateToken();
    }, []);

    return (
        <AuthContext.Provider value={{ isAuthenticated, setIsAuthenticated, logout, validateToken }}>
            {children}
        </AuthContext.Provider>
    );
};
