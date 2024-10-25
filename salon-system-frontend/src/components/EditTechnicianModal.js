import React, { useState, useEffect } from 'react';
import axios from 'axios';

function EditTechnicianModal({ technician, isOpen, onClose, onSave, onDelete }) {
  const [Name, setName] = useState('');
  const [Salary, setSalary] = useState(0);

  // Update state when technician prop changes
  useEffect(() => {
    if (technician) {
      setName(technician.Name || '');
      setSalary(technician.Salary || 0);
    }
  }, [technician]);

  //--------Save
  const handleSave = async () => {
    try {
      const updatedTechnician = {
        TechnicianId: technician.TechnicianId,
        Name,
        Salary
      };
      await axios.put(`http://localhost:5067/api/technician/${updatedTechnician.TechnicianId}`, updatedTechnician);
      onSave(updatedTechnician);
      onClose();
    } catch (error) {
      console.error('Failed to update technician:', error);
    }
  };

  //--------Delete
  const handleDelete = async () => {
    try {
      await axios.delete(`http://localhost:5067/api/technician/${technician.TechnicianId}`);
      onDelete(technician.TechnicianId);
      onClose(); // Close modal after deleting technician
    } catch (error) {
      console.error('Failed to delete technician:', error);
    }
  };

  if (!isOpen) {
    return null; // Don't render if the modal isn't open
  }

  return (
    <div className="modal">
      <div className="modal-content">
        <h3>Edit Technician</h3>
        <label>
          Name:
          <input type="text" value={Name} onChange={(e) => setName(e.target.value)} />
        </label>
        <br />
        <label>
          Salary:
          <input type="number" value={Salary} onChange={(e) => setSalary(e.target.value)} />
        </label>
        <br />
        <button onClick={handleSave}>Save</button>
        <button onClick={handleDelete} className="delete-button">Delete Technician</button>
        <button onClick={onClose}>Cancel</button>
      </div>
    </div>
  );
}

export default EditTechnicianModal;
