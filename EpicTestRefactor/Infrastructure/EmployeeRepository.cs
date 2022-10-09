using EpicTestRefactor.Domain;

using Microsoft.EntityFrameworkCore;

namespace EpicTestRefactor.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private EpicContext _context;

        public EmployeeRepository(EpicContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var existEmployee = await FindEmployee(employee.Id);
            if (existEmployee != null)
                throw new Exception($"Employee with id = {employee.Id} exists, can't insert new record");

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var employeeInDb = await FindEmployee(employee.Id);
            //if I have right understending this just for simulaite behavior like DB and it's not necessary deeper how implement update
            if (employeeInDb == null)
                throw new Exception($"Employee with id = {employee.Id} not found, nothing to update!");
            employeeInDb = employee;
            _context.Employees.Update(employeeInDb);
                
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<bool> DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await FindEmployee(id);
            return employee;
        }

        private async Task<Employee> FindEmployee(int id)
        {
            var employee = await _context.Employees.Where(t => t.Id == id).Where(t => t.Id == id).FirstOrDefaultAsync();
            return employee;
        }
    }
}
