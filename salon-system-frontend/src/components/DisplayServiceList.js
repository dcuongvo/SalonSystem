function DisplayServiceList({ services }) {
    return (
      <div>
        <h3>Service List</h3>
        {services && services.length > 0 ? (
          <ul>
            {services.map((service) => (
              <li key={service.serviceId}>
                <p><strong>Service Name:</strong> {service.serviceName}</p>
                <p><strong>Duration:</strong> {service.duration} mins</p>
                <p><strong>Required Skills:</strong></p>
                <ul>
                  {service.requiredSkills.map((skill) => (
                    <li key={skill.skillId}>{skill.skillName}</li>
                  ))}
                </ul>
              </li>
            ))}
          </ul>
        ) : (
          <p>No services available.</p>
        )}
      </div>
    );
  }
  
  export default DisplayServiceList;
  