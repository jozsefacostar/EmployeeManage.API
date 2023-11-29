using Domain.Permission;
using ErrorOr;
using MediatR;
using Permission.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permission.GetAll
{
    internal sealed class GetAllPermissionsQueryHandler : IRequestHandler<GetAllPermissionsQuery, ErrorOr<IReadOnlyList<PermissionResponse>>>
    {
        private readonly IReadPermissionRepository _ReadPermissionRepository;

        public GetAllPermissionsQueryHandler(IReadPermissionRepository PermissionRepository)
        {
            _ReadPermissionRepository = PermissionRepository ?? throw new ArgumentNullException(nameof(PermissionRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<PermissionResponse>>> Handle(GetAllPermissionsQuery query, CancellationToken cancellationToken)
        {
            IReadOnlyList<Domain.Permission.Permission> Permissions = await _ReadPermissionRepository.GetAll();

            return Permissions.Select(Permission => new PermissionResponse(
                    Permission.Id.value,
                    Permission.Employee.value,
                    Permission.PermissionType.value,
                    Permission.PermissionDate,
                    Permission.ReasonPermission,
                        Permission.Active
                )).ToList();
        }
    }
}

