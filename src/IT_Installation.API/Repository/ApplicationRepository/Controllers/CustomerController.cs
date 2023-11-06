using IT_Installation.API.Repository.ApplicationRepository.Data;
using IT_Installation.API.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IT_Installation.API.Repository.ApplicationRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Model.Customer), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        public async Task<ActionResult<Model.Customer>> Get([FromRoute] int id)
        {
            var customer = await this.customerService.GetCustomer(id);
            return customer is not null ? this.Ok(customer) : this.NotFound();
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Model.Customer), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        public async Task<ActionResult<Model.Customer>> Get()
        {
            var customerList = await this.customerService.GetAllCustomer();
            return customerList is not null ? this.Ok(customerList) : this.NotFound();
        }

    }
}
