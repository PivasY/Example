using EpicTestRefactor.Domain;
using EpicTestRefactor.Infrastructure;

using FluentValidation;

using Microsoft.AspNetCore.Mvc;

namespace EpicTestRefactor.Application
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IValidator<Employee> _employeeValidator; 

        public EmployeeService(IEmployeeRepository employeeRepository, IValidator<Employee> employeeValidator)
        {
            _employeeRepository = employeeRepository;
            _employeeValidator = employeeValidator;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            Validate(employee);
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
            Validate(employee);
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


        private void Validate(Employee employee)
        {
            var result = _employeeValidator.Validate(employee);
            if (result.IsValid) return;
            
            throw new Exception(result.ToString("; "));
        }
    }
}
