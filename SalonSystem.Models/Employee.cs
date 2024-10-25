using SalonSystem.Commom.Enum; 
//Abstract class for a general employee
namespace SalonSystem.Models.Employees {
    public abstract class Employee 
    {
        public int EmployeeId { get; set; }
        public string Name  {get; set;}
        public int Salary  {get; set;}
        public PayPeriod PayPeriodType { get; set; }
        //public string? EmployeeType {get;set;}

        public Employee () {}
        public Employee (int employeeId, string name, int salary, PayPeriod payPeriodType) {
            EmployeeId = EmployeeId;
            Name = name;
            Salary = salary;
            PayPeriodType = payPeriodType;
        }
    }
}




