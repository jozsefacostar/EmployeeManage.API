using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.Create;
public record CreateEmployeeCommand(
    string Name,
    string LastName,
    string Email,
    string PhoneNumber,
    string Country
    ) : IRequest<ErrorOr<Unit>>;

