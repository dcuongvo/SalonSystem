import { useState } from 'react';
import CreateSalonPage from './CreateSalonPage';
import LoginPage from './LoginPage';


function HomePage() {
  const [currentPage, setCurrentPage] = useState('login');

  const goToCreateSalonPage = () => {
    setCurrentPage('createSalon');
  };

  const goToLoginPage = () => {
    setCurrentPage('login');
  };

  return (
    <div className="App">
      <h1> Welcome to Salon System !</h1>
      { currentPage === 'login' ? (
        <LoginPage onCreateSalonClick={goToCreateSalonPage} />
      ) 
      : (
        <CreateSalonPage onMainPageClick={goToLoginPage} />
      )}
    </div>  
  );
}
export default HomePage;