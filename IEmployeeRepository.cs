using System.Collections.Generic;

namespace Tutorial_5
{
    public interface IEmployeeRepository
    {
        IList<Employee> GetEmployees();
        IList<Employee> GetEmployeeById(int Id);
        bool AddEmployee(Employee emp);
        bool UpdateEmployee(Employee emp);
        bool DeleteEmployee(Employee emp);
    }
}