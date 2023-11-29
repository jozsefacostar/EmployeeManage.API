using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;
using Domain.Permission;
using Domain.Employee;
using Domain.PermissionType;

namespace Application.Permission.Create;
public sealed class CreatePermissionHandle : IRequestHandler<CreatePermissionCommand, ErrorOr<Unit>>
{
    private readonly IWritePermissionRepository _IWritePermissionRepository;
    private readonly IReadPermissionRepository _IReadPermissionRepository;
    private readonly IReadPermissionTypeRepository _IReadPermissionTypeRepository;
    private readonly IReadEmployeeRepository _IReadEmployeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePermissionHandle(IWritePermissionRepository PermissionRepository, IReadPermissionRepository IReadPermissionRepository, IReadPermissionTypeRepository iReadPermissionTypeRepository, IReadEmployeeRepository IReadEmployeeRepository, IUnitOfWork unitOfWork)
    {
        _IWritePermissionRepository = PermissionRepository ?? throw new ArgumentNullException(nameof(PermissionRepository)); _IReadPermissionTypeRepository = iReadPermissionTypeRepository ?? throw new ArgumentNullException(nameof(iReadPermissionTypeRepository));
        _IReadPermissionRepository = IReadPermissionRepository ?? throw new ArgumentNullException(nameof(IReadPermissionRepository));
        _IReadEmployeeRepository = IReadEmployeeRepository ?? throw new ArgumentNullException(nameof(IReadEmployeeRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CreatePermissionCommand command, CancellationToken cancellationToken)
    {
        if (command.Employee == Guid.Empty)
            return Domain.PermissionErrors.Errors.Permission.EmployeeRequired;
        if (command.PermissionType == Guid.Empty)
            return Domain.PermissionErrors.Errors.Permission.PermissionTypeRequired;
        if (!await _IReadPermissionTypeRepository.ExistsAsync(new PermissionTypeId(command.PermissionType)))
            return Error.NotFound("PermissionType.NotFound", "The PermissionTypeId is Inactive or was not found.");
        if (!await _IReadEmployeeRepository.ExistsAsync(new EmployeeId(command.Employee)))
            return Error.NotFound("Employee.NotFound", "The EmployeeId is Inactive or was not found.");
        if (string.IsNullOrEmpty(command.PermissionReason))
            return Domain.PermissionErrors.Errors.Permission.ReasonPermission;
        var Permission = new Domain.Permission.Permission(new PermissionId(Guid.NewGuid()), new Domain.Employee.EmployeeId(command.Employee), new Domain.PermissionType.PermissionTypeId(command.PermissionType), command.PermissionReason, true);
        await _IWritePermissionRepository.Add(Permission);
        await _unitOfWork.SaveChangesAsync();
        return Unit.Value;
    }
}