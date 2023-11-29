using Domain.Employee;
using Domain.Permission;
using Domain.PermissionType;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Customers.Update;

internal sealed class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, ErrorOr<Unit>>
{
    private readonly IWritePermissionRepository _IWritePermissionRepository;
    private readonly IReadPermissionRepository _IReadPermissionRepository;
    private readonly IReadPermissionTypeRepository _IReadPermissionTypeRepository;
    private readonly IReadEmployeeRepository _IReadEmployeeRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdatePermissionCommandHandler(IWritePermissionRepository writeRepository, IReadPermissionRepository IReadPermissionRepository, IReadPermissionTypeRepository iReadPermissionTypeRepository, IReadEmployeeRepository IReadEmployeeRepository, IUnitOfWork unitOfWork)
    {
        _IWritePermissionRepository = writeRepository ?? throw new ArgumentNullException(nameof(writeRepository)); _IReadPermissionTypeRepository = iReadPermissionTypeRepository ?? throw new ArgumentNullException(nameof(iReadPermissionTypeRepository));
        _IReadPermissionRepository = IReadPermissionRepository ?? throw new ArgumentNullException(nameof(IReadPermissionRepository));
        _IReadEmployeeRepository = IReadEmployeeRepository ?? throw new ArgumentNullException(nameof(IReadEmployeeRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(UpdatePermissionCommand command, CancellationToken cancellationToken)
    {
        if (!await _IReadPermissionRepository.ExistsAsync(new PermissionId(command.Id)))
            return Error.NotFound("Permission.NotFound", "The Permission with the provide Id was not found.");

        if (!await _IReadPermissionTypeRepository.ExistsAsync(new PermissionTypeId(command.Id)))
            return Error.NotFound("PermissionType.NotFound", "The PermissionType Id was not found.");

        if (!await _IReadEmployeeRepository.ExistsAsync(new EmployeeId(command.Id)))
            return Error.NotFound("Employee.NotFound", "The Employee Id was not found.");

        if (command.Employee == Guid.Empty)
            return Error.Validation("Permission.Address", "Employee is empty.");

        if (command.PermissionType == Guid.Empty)
            return Error.Validation("PermissionType.Address", "PermissionType is empty.");

        Domain.Permission.Permission permission = Domain.Permission.Permission.UpdateCustomer(command.Id, new Domain.Employee.EmployeeId(command.Employee),
            new Domain.PermissionType.PermissionTypeId(command.PermissionType),
            command.PermissionReason,
            command.Active);

        _IWritePermissionRepository.Update(permission);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
