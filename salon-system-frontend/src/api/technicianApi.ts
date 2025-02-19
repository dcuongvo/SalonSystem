import api from './api';

export interface Technician {
    id: number;
    name: string;
    skills: string[];
}

export const getTechnicians = async (): Promise<Technician[]> => {
    const response = await api.get('/technicians');
    return response.data;
};

export const addTechnician = async (technician: Technician): Promise<Technician> => {
    const response = await api.post('/technicians', technician);
    return response.data;
};

export const deleteTechnician = async (id: number): Promise<void> => {
    await api.delete(`/technicians/${id}`);
};
