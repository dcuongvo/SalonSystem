import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:5141/api', // Replace with your backend base URL
    headers: {
        'Content-Type': 'application/json',
    },
});

// request interceptor to include the token in headers
api.interceptors.request.use((config) => {
    const token = localStorage.getItem('token');
    console.log("Sending request to:", config.url);
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
        console.log("Token attached to headers:", token);
    }
    return config;
});


api.interceptors.response.use(
    (response) => {
        console.log("Response received from:", response.config.url, response.data);
        return response;
    },
    (error) => {
        if (error.response) {
            const errorMessage = error.response.data?.message || 'An error occurred.';
            return Promise.reject(new Error(errorMessage));
        }
        if (error.request) {
            return Promise.reject(new Error('No response from server. Please try again.'));
        }
        return Promise.reject(new Error('An unknown error occurred.'));
    }
);

export default api;
