using ErrorOr;
using MediatR;

namespace Application.Customers.Update;

public record UpdatePermissionCommand(
    Guid Id,
    Guid Employee,
    Guid PermissionType,
    string PermissionReason,
    DateTime PermissionDate,
    bool Active) : IRequest<ErrorOr<Unit>>;