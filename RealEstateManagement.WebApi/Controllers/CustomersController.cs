using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateManagement.Application.Features.Customers.Commands.CreateCustomer;
using RealEstateManagement.Application.Features.Customers.Commands.DeleteCustomer;
using RealEstateManagement.Application.Features.Customers.Commands.UpdateCustomer;
using RealEstateManagement.Application.Features.Customers.Queries.GetCustomersList;

namespace RealEstateManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllCustomers", Name = "GetAllCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CustomersListVm>>> GetAllCustomers()
        {
            var customersDtos = await _mediator.Send(new GetCustomersListQuery());
            return Ok(customersDtos);
        }

        [HttpPost("CreateCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateCustomer([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            var response = await _mediator.Send(createCustomerCommand);
            return Ok(response);
        }

        [HttpPut("UpdateCustomer")]
        public async Task<ActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            await _mediator.Send(updateCustomerCommand);
            return NoContent();
        }

        [HttpDelete("DeleteCustomer/{id}", Name = "DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteCustomer(Guid id)
        {
            var deleteCustomerCommand = new DeleteCustomerCommand {Id = id};
            await _mediator.Send(deleteCustomerCommand);
            return NoContent();
        }
    }
}
