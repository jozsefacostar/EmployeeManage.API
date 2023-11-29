using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PermissionErrors
{
    public static partial class Errors
    {
        public static class Permission
        {
            public static Error ReasonPermission => Error.Validation("Permission.ReasonPermission", "The reason permission can´t be empty");
            public static Error EmployeeRequired=> Error.Validation("Permission.Employee", "The employee is required");
            public static Error PermissionTypeRequired => Error.Validation("Permission.PermissionType", "The PermissionType is required");

        }
    }
}
