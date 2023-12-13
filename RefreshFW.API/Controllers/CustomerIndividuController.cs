using Microsoft.AspNetCore.Mvc;
using RefreshFW.Application.Dtos;
using RefreshFW.Application.Helpers;
using RefreshFW.Application.Interfaces;

namespace RefreshFW.API.Controllers
{
    [Route("customerIndividu/[controller]")]
    [ApiController]
    public class CustomerIndividuController : ControllerBase
    {
        private readonly ICustomerIndividuService _customerIndividuService;

        public CustomerIndividuController(ICustomerIndividuService customerIndividuService)
        {
            _customerIndividuService = customerIndividuService;
        }

        /// <summary>
        /// Use this function to get all customer individu
        /// </summary>
        /// <returns>ActionResult of List of CustomerIndividuDto</returns>
        [HttpGet]
        public async Task<ActionResult<List<CustomerIndividuDto>>> Get()
        {
            List<CustomerIndividuDto> customerIndividuDtos = await _customerIndividuService.GetAllAsync();
            return Ok(customerIndividuDtos);
        }

        /// <summary>
        /// Use this function to get a customer individu by id
        /// </summary>
        /// <param name="id">The id of customer individu</param>
        /// <returns>ActionResult of CustomerIndividuDto</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomerIndividuDto>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ResponseCode.customerIndividuIdInvalid);
            }

            CustomerIndividuDto customerIndividuDto = await _customerIndividuService.GetByIdAsync(id);

            if (customerIndividuDto is null)
            {
                return NotFound();
            }

            return Ok(customerIndividuDto);
        }

        /// <summary>
        /// Use this function to add a customer individu
        /// </summary>
        /// <param name="customerIndividuPostDto">Json value as input parameter to add customer individu.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CustomerIndividuPostDto customerIndividuPostDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _customerIndividuService.AddAsync(customerIndividuPostDto);
            return Ok();
        }

        /// <summary>
        /// Use this function to edit a customer individu
        /// </summary>
        /// <param name="customerIndividuPutDto">Json value as input parameter to edit a customer individu.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] CustomerIndividuPutDto customerIndividuPutDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _customerIndividuService.UpdateAsync(customerIndividuPutDto);
            return Ok();
        }

        /// <summary>
        /// Use this function to delete a customer individu
        /// </summary>
        /// <param name="id">The id of customer individu</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if(id <= 0)
            {
                return BadRequest(ResponseCode.customerIndividuIdInvalid);
            }

            await _customerIndividuService.DeleteAsync(id);
            return Ok();
        }
    }
}