using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PermissionTypeErrors
{
    public static partial class Errors
    {
        public static class PermissionType
        {
            public static Error NameInvalid => Error.Validation("PermissionTypes.Name", "The name is not valid format");
            public static Error CodeInvalid => Error.Validation("PermissionTypes.Code", "The code is not valid format");

        }
    }
}
