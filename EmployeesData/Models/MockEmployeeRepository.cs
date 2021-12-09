using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesData.Models
{
    public class MockEmployeeRepository:IEmployeeRepository
    {
        private readonly List<Employee> _employees;
        public MockEmployeeRepository()
        {
            _employees = new List<Employee>()
            {
            new Employee { Id = 1, Name = "Sneha", Email = "snehamainkar@gmail.com", Department = Dept.IT },
            new Employee { Id = 2, Name = "Ram", Email = "ram@gmail.com", Department = Dept.HR },
            new Employee { Id = 3, Name = "Joe", Email = "joe@gmail.com", Department = Dept.Marketing },
            new Employee { Id = 4, Name = "John", Email = "john@gmail.com", Department = Dept.Payroll }
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = _employees.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public Employee GetEmployee(int Id)
        {
           return this._employees.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employees.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;

            }
            return employee;
        }
    }
}
