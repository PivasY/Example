using System.ComponentModel.DataAnnotations;

namespace EpicTestRefactor.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public Gender? Gender { get; set; }
        
        public Position? Position { get; set; }
        
        public float Salary { get; set; }
        
        public string? Phone { get; set; }

    }

    public enum Gender
    {
        Male,
        Female
    }

    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
