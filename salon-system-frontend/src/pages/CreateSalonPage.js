import React, { useState } from 'react';
import axios from 'axios';

function CreateSalonPage({onMainPageClick}) {
  const [salonName, setSalonName] = useState('');
  const [message, setMessage] = useState('');

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const response = await axios.post('http://localhost:5067/api/salon', {name: salonName});
      console.log(response.data);
      setMessage(`Salon ${response.data.Name} created successfully! \n Your Id is ${response.data.SalonId}`);
      setSalonName('');
    } catch (error) {
      console.error('Error creating salon:', error);
      setMessage('Failed to create salon. Please try again.');
    }
  };


  return (
    <div>
      <h2>Create a New Salon</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Salon Name:</label>
          <input
            type="text"
            value={salonName}
            onChange={(e) => setSalonName(e.target.value)}
            required
          />
        </div>
        <button type="submit">Create Salon</button>
      </form>
      {message && <p>{message}</p>}
      <button onClick={onMainPageClick}>Go Back to Main Page</button>
    </div>
  );
}

export default CreateSalonPage;