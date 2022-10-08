using EpicTestRefactor.Domain;

using Microsoft.AspNetCore.Mvc;

namespace EpicTestRefactor.Application
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployee(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int id);

    }
}
