import React from 'react';
import TechnicianWindow from './TechnicianWindow';

function DisplayTechnicianList({ technicians, onEditClick}) {
    return (
        <div>
      <h3>Technicians</h3>
      {technicians && technicians.length > 0 ? (
        <ul>
          {technicians.map((technician) => (
            <li key={technician.TechnicianId}>
                <TechnicianWindow technician={technician} onEditClick={onEditClick} />
            </li>
          ))}
        </ul>
      ) : (
        <p>No technicians available.</p>
      )}
    </div>
  );
}

export default DisplayTechnicianList;

