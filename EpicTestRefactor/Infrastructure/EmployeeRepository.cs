using EpicTestRefactor.Domain;

namespace EpicTestRefactor.Infrastructure
{
    public class EmployeeRepository
    {

        private static List<Employee> employeesSingleton;
 
        public EmployeeRepository()
        {
            if (employeesSingleton == null)
                employeesSingleton = new List<Employee>();
        }

        public List<Employee> Employees { get { return employeesSingleton; } set { employeesSingleton = value; } }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            await Task.Delay(100); // imitation db inserting delay
            var existEmployee = await FindEmployee(employee.Id);
            if (existEmployee != null)
                throw new Exception($"Employee with id = {employee.Id} exists, can't insert new record");
            Employees.Add(employee);
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var employeeInDb = await FindEmployee(employee.Id);
            //if I have right understending this just for simulaite behavior like DB and it's not necessary deeper how implement update
            if (employeeInDb == null)
                throw new Exception($"Employee with id = {employee.Id} not found, nothing to update!");
            Employees.Remove(employeeInDb);
            Employees.Add(employee);

            return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await FindEmployee(id);
            if (employee == null) throw new Exception($"Employee with id = {id} not found, nothing to delete");
            Employees.Remove(employee);
            return true;
        }

        public async Task<Employee?> GetEmployee(int id)
        {
            var employee = await FindEmployee(id);
            if (employee == null) throw new Exception($"Employee with id = {id} not found!");

            return employee;
        }

        public async Task<Employee?> FindEmployee(int id)
        {
            var result = Employees.Where(t => t.Id == id).FirstOrDefault();

            await Task.Delay(100); // imitation db reading delay

            return result;
        }
    }
}
