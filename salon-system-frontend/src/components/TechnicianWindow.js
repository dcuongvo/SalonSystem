import React from 'react';

function TechnicianWindow({ technician, onEditClick }) {
  return (
    <div className="technician-window" onClick={() => onEditClick(technician)}>
        <li key={technician.TechnicianId}>
        <p>Name: {technician.Name}</p>
        <p>
        Skills: {technician.SkillSet && technician.SkillSet.length > 0
            ? technician.SkillSet.map((skill) => skill.SkillName).join(', ')
            : 'No skills assigned'}
        </p></li>
    </div>
  );
}

export default TechnicianWindow;