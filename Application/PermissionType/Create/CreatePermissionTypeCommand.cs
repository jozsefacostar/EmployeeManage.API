using ErrorOr;
using MediatR;

namespace Application.PermissionType.Create;
public record CreatePermissionTypeCommand(
    string Name,
    string Code,
    bool Active
    ) : IRequest<ErrorOr<Unit>>;

