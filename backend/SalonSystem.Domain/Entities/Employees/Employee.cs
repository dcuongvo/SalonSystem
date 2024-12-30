using SalonSystem.Common.Enums;
using SalonSystem.Domain.Entities.Salons;

namespace SalonSystem.Domain.Entities.Employees
{
    public abstract class Employee
    {
        public int EmployeeId { get; set; } // Primary Key
        public int SalonId { get; set; } // Foreign Key to Salon
        public virtual required Salon AssociatedSalon { get; set; } // Navigation Property

        public string Name { get; set; } = "";
        public int Salary { get; set; }
        public PayPeriod PayPeriodType { get; set; }

        protected Employee() {}

        protected Employee(int id, string name, int salary, PayPeriod payPeriodType, int salonId)
        {
            EmployeeId = id;
            Name = name;
            Salary = salary;
            PayPeriodType = payPeriodType;
            SalonId = salonId;
        }
    }
}
