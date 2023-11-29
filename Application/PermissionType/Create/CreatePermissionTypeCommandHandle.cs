using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;
using Domain.PermissionType;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.PermissionType.Create;
public sealed class CreatePermissionTypeHandle : IRequestHandler<CreatePermissionTypeCommand, ErrorOr<Unit>>
{
    private readonly IWritePermissionTypeRepository _IPermissionTypeRepository;

    private readonly IUnitOfWork _unitofWork;

    public CreatePermissionTypeHandle(IWritePermissionTypeRepository permissionTypeRepository, IUnitOfWork unitOfWork)
    {
        this._IPermissionTypeRepository = permissionTypeRepository ?? throw new ArgumentNullException(nameof(permissionTypeRepository));
        this._unitofWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }


    public async Task<ErrorOr<Unit>> Handle(CreatePermissionTypeCommand command, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(command.Name))
            return Domain.PermissionTypeErrors.Errors.PermissionType.NameInvalid;
        if (string.IsNullOrEmpty(command.Code))
            return Domain.PermissionTypeErrors.Errors.PermissionType.CodeInvalid;

        var PermissionType = new Domain.PermissionType.PermissionType(new PermissionTypeId(Guid.NewGuid()), command.Name, command.Code, true);
        await _IPermissionTypeRepository.Add(PermissionType);
        await _unitofWork.SaveChangesAsync();
        return Unit.Value;
    }
}