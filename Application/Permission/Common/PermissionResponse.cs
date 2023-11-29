using System;

namespace Permission.Common;

public record PermissionResponse(
Guid Id,
Guid Employee,
Guid PermissionType,
DateTime PermissionDate,
string ReasonPermission,
bool Active);