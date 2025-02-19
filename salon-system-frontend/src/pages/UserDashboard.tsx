import React, { useContext, useEffect, useState } from 'react';
import { AuthContext } from '../contexts/AuthContext';
import { getSalons } from '../api/salonApi';
import AddSalon from '../components/AddSalon'; // Import the AddSalon component
import './UserDashboard.css';

interface Salon {
    salonId: number;
    name: string;
    address: string;
    city: string;
    state: string;
    zipCode: string;
}

const UserDashboard: React.FC = () => {
    const { isAuthenticated } = useContext(AuthContext);
    const [salons, setSalons] = useState<Salon[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    const [showAddSalonForm, setShowAddSalonForm] = useState(false);

    // Fetch salons for the logged-in user
    useEffect(() => {
        const fetchSalons = async () => {
            try {
                const data = await getSalons();
                setSalons(data);
            } catch (err: any) {
                console.error('Error fetching salons:', err.message || err);
                setError(err.response?.data?.message || 'Failed to fetch salon data. Please try again.');
            } finally {
                setLoading(false);
            }
        };

        if (isAuthenticated) {
            fetchSalons();
        }
    }, [isAuthenticated]);

    // Handle new salon added
    const handleSalonAdded = (newSalon: Salon) => {
        setSalons((prevSalons) => [...prevSalons, newSalon]); // Update salon list
        setShowAddSalonForm(false); // Hide the form
    };

    if (!isAuthenticated) {
        return <p>You are not authorized to view this page. Please log in.</p>;
    }

    if (loading) {
        return <p>Loading your salons...</p>;
    }

    if (error) {
        return <p className="error-message">{error}</p>;
    }

    return (
        <div className="user-dashboard">
            <h1>Welcome to Your Dashboard</h1>

            <h2>Your Salons</h2>
            {salons.length > 0 ? (
                <ul>
                    {salons.map((salon) => (
                        <li key={salon.salonId}>
                            <h3>{salon.name}</h3>
                            <p>{salon.address}, {salon.city}, {salon.state}, {salon.zipCode}</p>
                        </li>
                    ))}
                </ul>
            ) : (
                <p>You don't have any salons yet.</p>
            )}

            {/* Add Salon Form Toggle */}
            <button onClick={() => setShowAddSalonForm((prev) => !prev)}>
                {showAddSalonForm ? 'Cancel' : 'Add New Salon'}
            </button>

            {showAddSalonForm && <AddSalon onSuccess={handleSalonAdded} />}
        </div>
    );
};

export default UserDashboard;
