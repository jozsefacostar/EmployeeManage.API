using ErrorOr;
using MediatR;
using Permission.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Permission.GetAll;

public record GetAllPermissionsQuery() : IRequest<ErrorOr<IReadOnlyList<PermissionResponse>>>;
