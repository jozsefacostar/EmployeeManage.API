using Application.Customers.Update;
using Application.Permission.Create;
using Application.Permission.GetAll;
using Azure;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Route("permissions")]
    public class Permissions : ApiController
    {
        private readonly ISender _mediator;

        public Permissions(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            var permissionResult = await _mediator.Send(new GetAllPermissionsQuery());

            return permissionResult.Match(
                permissions => Ok(permissions),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> RequestPermission([FromBody] CreatePermissionCommand command)
        {
            var createCustomerResult = await _mediator.Send(command);

            return createCustomerResult.Match(
                customer => Ok(), errors => Problem(errors));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyPermission(Guid id, [FromBody] UpdatePermissionCommand command)
        {
            if (command.Id != id)
            {
                List<Error> errors = new()
            {
                Error.Validation("Permission.UpdateInvalid", "The request Id does not match with the url Id.")
            };
                return Problem(errors);
            }

            var updateResult = await _mediator.Send(command);

            return updateResult.Match(
                permissionId => NoContent(),
                errors => Problem(errors)
            );
        }
    }
}
