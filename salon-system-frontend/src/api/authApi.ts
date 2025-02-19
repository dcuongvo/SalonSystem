import api from './api'; // Assumes centralized Axios instance

// Register a new user
export const registerUser = async (data: {
    username: string;
    password: string;
    firstName: string;
    lastName: string;
    email: string;
}) => {
    const response = await api.post('/auth/register', data); // Adjust endpoint if necessary
    return response.data; // Return relevant data
};

// Login an existing user
export const loginUser = async (data: { username: string; password: string }) => {
    const response = await api.post('/auth/login', data);
    return response.data; 
};
/*
export const loginUser = async (data: { username: string; password: string }) => {
    try {
        console.log("Sending request to: /auth/login");
        const response = await api.post('/auth/login', data);
        console.log("Response received from: /auth/login", response.data);
        return response.data;
    } catch (error: any) {
        console.error("Error in loginUser:", error.response || error.message || error);
        throw error;
    }
};
*/
