using EpicTestRefactor.Domain;
using EpicTestRefactor.Infrastructure;

namespace EpicTestRefactor.Application
{
    public class EmployeeService
    {
        public EmployeeRepository EmployeeRepository { get; set; }

        public EmployeeService()
        {
            EmployeeRepository = new EmployeeRepository();
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            ValidateFields(employee);
            var result = await EmployeeRepository.AddEmployee(employee);

            return result;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            ValidateFields(employee);
            var result = await EmployeeRepository.UpdateEmployee(employee);

            return result;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var result = await EmployeeRepository.DeleteEmployee(id);
            return result;
        }

        public async Task<Employee?> GetEmployee(int id)
        {
            var employee = await EmployeeRepository.GetEmployee(id);

            return employee;
        }


        private void ValidateFields(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Name))
                throw new Exception("Validation error: " + nameof(employee.Name) + " is empty");

            if (string.IsNullOrEmpty(employee.Surname))
                throw new Exception("Validation error: " + nameof(employee.Surname) + " is empty");

            if (employee.Salary < 0)
                throw new Exception("Validation error: " + nameof(employee.Salary) + " invalida value");
        }
    }
}
