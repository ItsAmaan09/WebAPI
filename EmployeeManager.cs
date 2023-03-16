using System;
using System.Collections.Generic;
using System.Linq;
namespace Tutorial_5
{
    public class EmployeeManager
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();
        public IList<Employee> GetEmployees()
        {
            IList<Employee> employeeList = new List<Employee>();
            try
            {
                employeeList = this.employeeRepository.GetEmployees();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            return employeeList;
        }
        public IList<Employee> GetEmployeeById(int Id)
        {
            IList<Employee> employeeById = new List<Employee>();
            try
            {
                var list = this.employeeRepository.GetEmployeeById(Id);
                var counter = list.Where(p => p.empId == Id);

                if (counter.Count() > 0)
                {
                    foreach (Employee emp in counter)
                    {
                        employeeById.Add(emp);
                    }
                }
                else
                {
                    throw new Exception("FAILED TO GET ! As Employee with corresponding Employee ID doesn't exist in database.");
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            return employeeById;
        }
        public IList<Employee> GetEmployees(string empName)
        {
            IList<Employee> empByName = new List<Employee>();
            try
            {
                var empList = this.employeeRepository.GetEmployees();
                var empQuery = empList.Where(p => p.firstName.StartsWith(empName));
                foreach (Employee emp in empQuery)
                {
                    empByName.Add(emp);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            return empByName;
        }
        public bool AddEmployee(Employee emp)
        {
            var getEmpList = this.employeeRepository.GetEmployeeById(emp.empId);
            var codeExists = getEmpList.Where(p => p.empId == emp.empId);

            if (codeExists.Count() > 0)
            {
                throw new Exception("FAILED TO ADD ! As Employee with corresponding Employee Id Already exist in database.");
            }
            else
            {
                this.employeeRepository.AddEmployee(emp);
            }
            return true;
        }
        public bool UpdateEmployee(Employee emp)
        {
            var getEmpList = this.employeeRepository.GetEmployeeById(emp.empId);
            var codeExists = getEmpList.Where(p => p.empId == emp.empId);

            if (codeExists.Count() > 0)
            {
                this.employeeRepository.UpdateEmployee(emp);
            }
            else
            {
                throw new Exception("FAILED TO UPDATE ! As Employee with corresponding Employee Id does not exist in database.");
            }
            return true;
        }
        public bool DeleteEmployee(Employee emp)
        {
            var getEmpList = this.employeeRepository.GetEmployeeById(emp.empId);
            var codeExists = getEmpList.Where(p => p.empId == emp.empId);

            if (codeExists.Count() > 0)
            {
                this.employeeRepository.DeleteEmployee(emp);
            }
            else
            {
                throw new Exception("FAILED TO DELETE ! As Employee with corresponding Employee Id  doesn't exist in database.");
            }
            return true;
        }
    }
}