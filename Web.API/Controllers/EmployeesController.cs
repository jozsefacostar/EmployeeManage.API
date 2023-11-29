using Application.Employee.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("employees")]
    public class Employees : ApiController
    {
        private readonly ISender _mediator;

        public Employees(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand command)
        {
            var createCustomerResuñt = await _mediator.Send(command);

            return createCustomerResuñt.Match(
                customer => Ok(), errors => Problem(errors));
        }
    }
}
