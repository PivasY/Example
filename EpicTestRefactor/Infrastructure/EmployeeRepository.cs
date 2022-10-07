using EpicTestRefactor.Domain;

namespace EpicTestRefactor.Infrastructure
{
    public class EmployeeRepository
    {
        public List<Employee> Employees { get; set; }

        public EmployeeRepository()
        {
            Employees = new List<Employee>();
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            await Task.Delay(100); // imitation db inserting delay
            Employees.AddRange(Employees);

            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var employeeInDb = await FindEmployee(employee.Id);
            Employees.Remove(employeeInDb);
            Employees.Add(employee);

            return employee;
        }

        public async void DeleteEmployee(int id)
        {
            var employee = await FindEmployee(id);
            Employees.Remove(employee);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await FindEmployee(id);

            return employee;
        }

        public async Task<Employee> FindEmployee(int id)
        {
            var result = new Employee();

            foreach (var employee in Employees)
            {
                if (employee.Id == id)
                {
                    result = employee;
                }
            }

            await Task.Delay(100); // imitation db reading delay

            return result;
        }
    }
}
