import React, { useState } from 'react';
import axios from 'axios';

function AddTechnicianModal({ isOpen, onClose, onAddTechnician, SalonId }) {
  const [Name, setName] = useState('');
  const [Salary, setSalary] = useState('');

  if (!isOpen) {
    return null;
  }

  const handleSubmit = async (event) => {
    event.preventDefault();
    const newTechnician = {
      SalonId,
      Name,
      Salary,
      payPeriodType: 1
    };
    
    try {
      const response = await axios.post('http://localhost:5067/api/technician', newTechnician);
      onAddTechnician(response.data);
      onClose();
      resetForm();
    } catch (error) {
      console.error('Failed to add technician:', error);
    }
  };

  // Function to reset form values
  const resetForm = () => {
    setName('');
    setSalary('');
  };

  return (
    <div className="modal">
      <div className="modal-content">
        <h2>Add Technician</h2>
        <form onSubmit={handleSubmit}>
          <label>
            Name:
            <input
              type="text"
              value={Name}
              onChange={(e) => setName(e.target.value)}
              required
            />
          </label>
          <label>
            Salary:
            <input
              type="number"
              value={Salary}
              onChange={(e) => setSalary(e.target.value)}
              required
            />
          </label>
          <button type="submit">Add Technician</button>
          <button type="button" onClick={onClose}>Cancel</button>
        </form>
      </div>
    </div>
  );
}

export default AddTechnicianModal;
