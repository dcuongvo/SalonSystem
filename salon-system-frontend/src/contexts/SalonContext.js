import React, { createContext, useContext, useState } from 'react';

// Create the context
const SalonContext = createContext();

// Custom hook to use SalonContext
export const useSalon = () => {
  return useContext(SalonContext);
};

// SalonProvider component to wrap the app
export const SalonProvider = ({ children }) => {
  const [salon, setSalon] = useState(null);
  return (
    <SalonContext.Provider value={{ salon, setSalon }}>
      {children}
    </SalonContext.Provider>
  );
};

// Exporting both the context itself and the custom hook
export { SalonContext };