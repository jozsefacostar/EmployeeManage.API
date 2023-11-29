using FluentValidation;

namespace Application.Customers.Update;

public class UpdatePermissionCommandValidator : AbstractValidator<UpdatePermissionCommand>
{
    public UpdatePermissionCommandValidator()
    {
        RuleFor(r => r.Employee).NotEmpty();
        RuleFor(r => r.PermissionType).NotEmpty();
        RuleFor(r => r.PermissionReason).NotEmpty().MaximumLength(250).WithName("Motivo de permiso");
    }
}