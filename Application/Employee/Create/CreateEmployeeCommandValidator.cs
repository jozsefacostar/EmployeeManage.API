using FluentValidation;

namespace Application.Employee.Create
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {

            RuleFor(r => r.Name).NotEmpty().MaximumLength(50);
            RuleFor(r => r.LastName).NotEmpty().MaximumLength(50).WithName("Last Name");
            RuleFor(r => r.Email).EmailAddress().MaximumLength(255);
        }
    }
}
