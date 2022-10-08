using EpicTestRefactor.Domain;
using EpicTestRefactor.Infrastructure;

using Microsoft.AspNetCore.Mvc;

namespace EpicTestRefactor.Application
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            ValidateFields(employee);
            var checkWithId = await _employeeRepository.GetEmployee(employee.Id);
            if (checkWithId == null)
            {
                var result = await _employeeRepository.AddEmployee(employee);
                return result;
            }
            return null;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            ValidateFields(employee);
            var result = await _employeeRepository.UpdateEmployee(employee);

            return result;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            if (employee == null) 
                return false;
            var result = await _employeeRepository.DeleteEmployee(employee);
            return true;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            return employee;
        }


        private void ValidateFields(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Name))
                throw new Exception("Validation error: " + nameof(employee.Name) + " is empty");

            if (string.IsNullOrEmpty(employee.Surname))
                throw new Exception("Validation error: " + nameof(employee.Surname) + " is empty");

            if (employee.Salary < 0)
                throw new Exception("Validation error: " + nameof(employee.Salary) + " has invalid value");
        }
    }
}
