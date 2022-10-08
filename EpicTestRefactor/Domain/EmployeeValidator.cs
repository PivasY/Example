using FluentValidation;

namespace EpicTestRefactor.Domain
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(employee => employee.Name).NotNull().NotEmpty().WithMessage("Validation error: {PropertyName} is empty");
            RuleFor(employee => employee.Surname).NotNull().NotEmpty().WithMessage("Validation error: {PropertyName} is empty");
            RuleFor(employee => employee.Salary).GreaterThan(0).WithMessage("Validation error: {PropertyName} has invaliud value");
        }
    }
    
}
