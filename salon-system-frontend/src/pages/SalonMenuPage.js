import React, { useEffect, useState } from 'react';
import DisplayTechnicianList from '../components/DisplayTechnicianList';
import DisplayServiceList from '../components/DisplayServiceList';
import AddTechnicianModal from '../components/AddTechnicianModal';
import EditTechnicianModal from '../components/EditTechnicianModal';
import { useSalon } from '../contexts/SalonContext';
import { useNavigate } from 'react-router-dom';

function SalonMenuPage() {
  const { salon, setSalon } = useSalon(); 
  const navigate = useNavigate();
  const [isAddModalOpen, setIsAddModalOpen] = useState(false); 
  const [isEditModalOpen, setIsEditModalOpen] = useState(false); 
  const [selectedTechnician, setSelectedTechnician] = useState(null);
  
  // Handle salon state
  useEffect(() => {
    if (!salon) {
      console.error('Salon data is missing. Redirecting to login.');
      navigate('/');
    }
  }, [salon, navigate]);

  if (!salon) {
    return <p>Error: Please login again</p>;
  }

  // Handle adding a technician
  const handleAddTechnician = (newTechnician) => {
    setSalon({
      ...salon,
      Technicians: [...(salon.Technicians || []), newTechnician],
    });
    setIsAddModalOpen(false); // Close the add technician modal after adding
  };

  // Handle editing a technician
  const handleEditClick = (technician) => {
    setSelectedTechnician(technician);
    setIsEditModalOpen(true);
  };

  const handleTechnicianSave = (updatedTechnician) => {
    setSalon((prevSalon) => {
      const updatedTechnicians = prevSalon.Technicians.map((tech) =>
        tech.TechnicianId === updatedTechnician.TechnicianId ? updatedTechnician : tech
      );
  
      return {
        ...prevSalon,
        Technicians: updatedTechnicians,
      };
    });
  
    console.log('Technician updated successfully:', updatedTechnician);
  };

   // Handle delete technician
   const handleTechnicianDelete = (technicianId) => {
    setSalon({
      ...salon,
      Technicians: salon.Technicians.filter((tech) => tech.TechnicianId !== technicianId),
    });

    console.log('Technician deleted:', technicianId);
  };


  return (
    <div>
      <h2>Salon Menu</h2>
      <h3>Salon Name: {salon.Name}</h3>
      <h4>Salon ID: {salon.SalonId}</h4>

      {/* Technician List */}
      <DisplayTechnicianList technicians={salon.Technicians} onEditClick={handleEditClick} />
      <button onClick={() => setIsAddModalOpen(true)}>Add Technician</button>

      {/* Add Technician Modal */}
      <AddTechnicianModal
        isOpen={isAddModalOpen}
        onClose={() => setIsAddModalOpen(false)}
        onAddTechnician={handleAddTechnician}
        SalonId={salon.SalonId}
      />

      {/* Edit Technician Modal */}
      {selectedTechnician && (
        <EditTechnicianModal
          technician={selectedTechnician}
          isOpen={isEditModalOpen}
          onClose={() => setIsEditModalOpen(false)}
          onSave={handleTechnicianSave}
          onDelete={handleTechnicianDelete}
        />
      )}

      {/* Service List */}
      <DisplayServiceList services={salon.services} />
      <button>Add Service</button>
    </div>
  );
}

export default SalonMenuPage;
