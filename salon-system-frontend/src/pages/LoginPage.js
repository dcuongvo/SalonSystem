import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { useSalon } from '../contexts/SalonContext';

function LoginPage({ onCreateSalonClick }) {
  const [salonId, setSalonId] = useState('');
  const navigate = useNavigate();
  const { setSalon } = useSalon();

  const handleLoginSubmit = async (event) => {
    event.preventDefault();
    try {
      const response = await axios.get(`http://localhost:5067/api/salon/${salonId}`);
      setSalon(response.data)
      navigate('salon-menu');
    } catch (error) {
      console.error('Error logging in:', error);
    }
  };

  return (
    <div>
      <h2>Login Page</h2>
      <form onSubmit={handleLoginSubmit}>
        <label>
          Enter Your Salon ID:
          <input
            type="text"
            value={salonId}
            onChange={(e) => setSalonId(e.target.value)}
            required
          />
        </label>
        <button type="submit">Login</button>
      </form>
      <p>Don't have a salon?</p>
      <button onClick={onCreateSalonClick}>Create New Salon</button>
    </div>
  );
}

export default LoginPage;