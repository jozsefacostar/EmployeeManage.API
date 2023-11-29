using Application.Employee.Create;
using Domain.Employee;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.employees.UnitTests.Create
{
    public class CreateEmployeeCommandHandlerUnitTests
    {
        private readonly Mock<IWriteEmployeeRepository> _iCustomerRepository;
        private readonly Mock<IUnitOfWork> _iUnitOfWork;
        private readonly CreateEmployeeCommandHandle _CreateCustomerCommandHandle;

        public CreateEmployeeCommandHandlerUnitTests()
        {
            _iCustomerRepository = new Mock<IWriteEmployeeRepository>();
            _iUnitOfWork = new Mock<IUnitOfWork>();
            _CreateCustomerCommandHandle = new CreateEmployeeCommandHandle(_iCustomerRepository.Object, _iUnitOfWork.Object);
        }

        //Cuando se realiza la creación del objeto empleado
        //El escenario
        //Lo que debe arrojar
        [Fact]
        public async Task HandreCreateEmployee_WhenPhoneNumberHasInvalidFormat_ShoudlReturnValidationError()
        {
            //Arrange: Configuramos parametros de entrada de prueba unitaria
            CreateEmployeeCommand createCustomerCommand = new CreateEmployeeCommand("Jozsef", "Acosta", "jozsef@gmai.com", "3004189192", "Colombia");

            //Act: Se ejecuta el metodo a probar en nuestra prueba unitaria
            var result = await _CreateCustomerCommandHandle.Handle(createCustomerCommand, default);

            //Assert: Se verifica los datos de retorno de nuestro metodo probado
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            result.FirstError.Code.Should().Be(Domain.EmployeeErrors.Errors.Employee.PhoneNumberInvalid.Code);
            result.FirstError.Description.Should().Be(Domain.EmployeeErrors.Errors.Employee.PhoneNumberInvalid.Description);

        }
    }
}
