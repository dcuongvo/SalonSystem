import React, { useEffect, useState } from 'react';
import { getTechnicians } from '../api/technicianApi';

interface Technician {
    technicianId: number;
    name: string;
}

const TechnicianManagement: React.FC<{ salonId: string }> = ({ salonId }) => {
    const [technicians, setTechnicians] = useState<Technician[]>([]);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchTechnicians = async () => {
            try {
                const response = await getTechnicians(salonId);
                setTechnicians(response);
            } catch (err: any) {
                console.error('Error fetching technicians:', err.message || err);
                setError(err.response?.data?.message || 'Failed to fetch technicians.');
            }
        };

        fetchTechnicians();
    }, [salonId]);

    if (error) {
        return <p>{error}</p>;
    }

    return (
        <div>
            <h2>Technicians</h2>
            <ul>
                {technicians.map((tech) => (
                    <li key={tech.technicianId}>{tech.name}</li>
                ))}
            </ul>
        </div>
    );
};

export default TechnicianManagement;
