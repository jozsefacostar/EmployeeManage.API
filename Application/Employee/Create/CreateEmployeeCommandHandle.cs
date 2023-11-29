using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;
using Domain.EmployeeErrors;
using Domain.Employee;

namespace Application.Employee.Create;
public sealed class CreateEmployeeCommandHandle : IRequestHandler<CreateEmployeeCommand, ErrorOr<Unit>>
{
    private readonly IWriteEmployeeRepository _customerRepository;

    private readonly IUnitOfWork _unitofWork;

    public CreateEmployeeCommandHandle(IWriteEmployeeRepository customerRepository, IUnitOfWork unitOfWork)
    {
        this._customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        this._unitofWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }


    public async Task<ErrorOr<Unit>> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        if (PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
            return Errors.Employee.PhoneNumberInvalid;

        var Customer = new Domain.Employee.Employee(new EmployeeId(Guid.NewGuid()), command.Name, command.LastName, command.Email, phoneNumber, true);
        await _customerRepository.Add(Customer);
        await _unitofWork.SaveChangesAsync();
        return Unit.Value;
    }
}