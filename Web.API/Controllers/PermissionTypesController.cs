using Application.Employee.Create;
using Application.PermissionType.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("permissionTypes")]
    public class PermissionTypes : ApiController
    {
        private readonly ISender _mediator;

        public PermissionTypes(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePermissionTypeCommand command)
        {
            var createCustomerResult = await _mediator.Send(command);

            return createCustomerResult.Match(
                customer => Ok(), errors => Problem(errors));
        }
    }
}
