using EpicTestRefactor.Domain;

namespace EpicTestRefactor.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private List<Employee> _employees;
 
        public EmployeeRepository()
        {
            _employees = new List<Employee>();
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            await Task.Delay(100); // imitation db inserting delay
            var existEmployee = await FindEmployee(employee.Id);
            if (existEmployee != null)
                throw new Exception($"Employee with id = {employee.Id} exists, can't insert new record");
            
            this._employees.Add(employee);
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var employeeInDb = await FindEmployee(employee.Id);
            //if I have right understending this just for simulaite behavior like DB and it's not necessary deeper how implement update
            if (employeeInDb == null)
                throw new Exception($"Employee with id = {employee.Id} not found, nothing to update!");
            _employees.Remove(employeeInDb);
            _employees.Add(employee);

            return employee;
        }

        public async Task<bool> DeleteEmployee(Employee employee)
        {
            _employees.Remove(employee);
            return true;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await FindEmployee(id);
            return employee;
        }

        private async Task<Employee> FindEmployee(int id)
        {
            await Task.Delay(100); // imitation db reading delay
            
            return _employees.Where(t => t.Id == id).FirstOrDefault();

        }

        private void InitData()
        {
            _employees.Add(new Employee()
            {
                Id = 1,
                Name = "Pavel",
                Surname = "Vasylenko",
                Position = new Position() { Id = 1, Name = ".Net dev" },
                Gender = Gender.Male,
                Salary = 5,
                Phone = "0688766776"
            });

            _employees.Add(new Employee()
            {
                Id = 2,
                Name = "Kat",
                Surname = "Usova",
                Position = new Position() { Id = 2, Name = "Accounter" },
                Gender = Gender.Female,
                Salary = 2,
                Phone = "09954334566"
            });

        }
    }
}
