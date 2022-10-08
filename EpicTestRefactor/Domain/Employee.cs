using System.ComponentModel.DataAnnotations;

namespace EpicTestRefactor.Domain
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
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
