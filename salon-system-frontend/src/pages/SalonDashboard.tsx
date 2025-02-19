import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import TechnicianManagement from '../components/TechnicianManagement';
import ServiceManagement from '../components/ServiceManagement';
// Add more components as needed
import './SalonDashboard.css';

const SalonDashboard: React.FC = () => {
    const { salonId } = useParams<{ salonId: string }>(); // Access salonId from the route
    const [salonName, setSalonName] = useState<string>('');
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchSalonDetails = async () => {
            try {
                // Call API to fetch salon details by salonId
                const response = await api.get(`/salon/${salonId}`);
                setSalonName(response.data.name);
            } catch (err: any) {
                console.error('Error fetching salon details:', err.message || err);
                setError(err.response?.data?.message || 'Failed to fetch salon details.');
            }
        };

        fetchSalonDetails();
    }, [salonId]);

    if (error) {
        return <p className="error-message">{error}</p>;
    }

    return (
        <div className="salon-dashboard">
            <h1>Manage {salonName}</h1>

            <div className="dashboard-sections">
                <TechnicianManagement salonId={salonId} />
                <ServiceManagement salonId={salonId} />
                {/* Add more management components */}
            </div>
        </div>
    );
};

export default SalonDashboard;
