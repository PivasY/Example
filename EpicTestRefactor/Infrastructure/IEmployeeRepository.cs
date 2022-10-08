using EpicTestRefactor.Domain;

namespace EpicTestRefactor.Infrastructure
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee?> GetEmployee(int id);
        Task<Employee> UpdateEmployee(Employee employee);
        pubic Task<bool> DeleteEmployee(int id);

    }
}
