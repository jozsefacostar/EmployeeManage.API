using Application.Employee.Create;
using FluentValidation;

namespace Application.Permission.Create
{
    public class CreatePermissionCommandValidator : AbstractValidator<CreatePermissionCommand>
    {
        public CreatePermissionCommandValidator()
        {

            RuleFor(r => r.Employee).NotEmpty();
            RuleFor(r => r.PermissionType).NotEmpty();
            RuleFor(r => r.PermissionReason).NotEmpty().MaximumLength(250).WithName("Motivo de permiso");
        }
    }
}
