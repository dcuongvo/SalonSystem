import React, { useState } from 'react';
import { addSalon } from '../api/salonApi'; // Import the API function
import './AddSalon.css';

interface AddSalonProps {
    onSuccess: (salon: { salonId: number; name: string; address: string; city: string; state: string; zipCode: string }) => void;
}

const AddSalon: React.FC<AddSalonProps> = ({ onSuccess }) => {
    const [name, setName] = useState('');
    const [address, setAddress] = useState('');
    const [city, setCity] = useState('');
    const [state, setState] = useState('');
    const [zipCode, setZipCode] = useState('');
    const [error, setError] = useState<string | null>(null);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setError(null); // Clear previous errors

        try {
            const salonData = { name, address, city, state, zipCode };
            const response = await addSalon(salonData); // Call the API
            const newSalon = { salonId: Date.now(), ...salonData }; // Mock salonId for optimistic update
            onSuccess(newSalon); 
            setName('');
            setAddress('');
            setCity('');
            setState('');
            setZipCode('');
        } catch (err: any) {
            console.error('Error adding salon:', err.message || err);
            setError(err.response?.data?.message || 'Failed to add salon. Please try again.');
        }
    };

    return (
        <div className="add-salon">
            <h3>Add New Salon</h3>
            <form onSubmit={handleSubmit}>
                {error && <p className="error-message">{error}</p>}
                <div>
                    <label htmlFor="salon-name">Salon Name:</label>
                    <input
                        type="text"
                        id="salon-name"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        placeholder="Enter salon name"
                        required
                    />
                </div>
                <div>
                    <label htmlFor="salon-address">Address:</label>
                    <input
                        type="text"
                        id="salon-address"
                        value={address}
                        onChange={(e) => setAddress(e.target.value)}
                        placeholder="Enter address"
                        required
                    />
                </div>
                <div>
                    <label htmlFor="salon-city">City:</label>
                    <input
                        type="text"
                        id="salon-city"
                        value={city}
                        onChange={(e) => setCity(e.target.value)}
                        placeholder="Enter city"
                        required
                    />
                </div>
                <div>
                    <label htmlFor="salon-state">State:</label>
                    <input
                        type="text"
                        id="salon-state"
                        value={state}
                        onChange={(e) => setState(e.target.value)}
                        placeholder="Enter state"
                        required
                    />
                </div>
                <div>
                    <label htmlFor="salon-zipCode">Zip Code:</label>
                    <input
                        type="text"
                        id="salon-zipCode"
                        value={zipCode}
                        onChange={(e) => setZipCode(e.target.value)}
                        placeholder="Enter zip code"
                        required
                    />
                </div>
                <button type="submit">Add Salon</button>
            </form>
        </div>
    );
};

export default AddSalon;
