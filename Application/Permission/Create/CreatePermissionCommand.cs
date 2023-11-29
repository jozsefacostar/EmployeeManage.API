using ErrorOr;
using MediatR;

namespace Application.Permission.Create;
public record CreatePermissionCommand(
    Guid Employee,
    Guid PermissionType,
    string PermissionReason,
    DateTime PermissionDate,
    bool Active
    ) : IRequest<ErrorOr<Unit>>;

