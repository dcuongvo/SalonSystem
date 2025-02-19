import api from './api'; // Import the centralized Axios instance

// Function to add a new salon
export const addSalon = async (data: { 
    name: string; 
    address: string; 
    city: string; 
    state: string; 
    zipcode: string; 
}) => {
    try {
        const response = await api.post('/salon/add', data); 
        return response.data; 
    } catch (error: unknown) {
        handleError(error); 
        throw error; 
    }
};


// Function to fetch salons for the logged-in user
export const getSalons = async () => {
    try {
        const response = await api.get('/user/salons');
        return response.data; 
    } catch (error) {
        handleError(error);
    }
};

// Function to fetch a single salon by its ID
export const getSalonById = async (id: number) => {
    try {
        const response = await api.get(`/salon/${id}`);
        return response.data; // Return the salon details
    } catch (error) {
        handleError(error);
    }
};

// Function to update a salon
export const updateSalon = async (id: number, data: { name: string }) => {
    try {
        const response = await api.put(`/salon/${id}`, data);
        return response.data; // Return the updated salon details
    } catch (error) {
        handleError(error);
    }
};

// Function to delete a salon
export const deleteSalon = async (id: number) => {
    try {
        const response = await api.delete(`/salon/${id}`);
        return response.data; // Return the success message
    } catch (error) {
        handleError(error);
    }
};

// Helper function to handle errors
const handleError = (error: unknown): never => {
    if (error instanceof Error) {
        console.error('Error message:', error.message);
        throw new Error(error.message || 'An unknown error occurred.');
    } else {
        console.error('Unknown error:', error);
        throw new Error('An unknown error occurred.');
    }
};
