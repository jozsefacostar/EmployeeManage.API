using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EmployeeErrors
{
    public static partial class Errors
    {
        public static class Employee
        {
            public static Error PhoneNumberInvalid => Error.Validation("Employee.PhoneNumber", "PhoneNumber has not valid format. The length should be equal to 8 and only numbers");

        }
    }
}
