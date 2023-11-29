using Application.Employee.Create;
using FluentValidation;

namespace Application.PermissionType.Create
{
    public class CreatePermissionCommandValidator : AbstractValidator<CreatePermissionTypeCommand>
    {
        public CreatePermissionCommandValidator()
        {

            RuleFor(r => r.Name).NotEmpty().MaximumLength(50);
            RuleFor(r => r.Code).NotEmpty().MaximumLength(50).WithName("Code");
        }
    }
}
