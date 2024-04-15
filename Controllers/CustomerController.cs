using Customer.DataTransferObjects;
using Customer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Customer.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("{page:int}/{pageSize:int}")]
    [Authorize]
    public List<CustomerDto> Get(int page, int pageSize)
    {
        return _customerService.GetCustomers(page, pageSize);
    }
    [HttpPost]
    [Authorize]
    public IActionResult Post(Models.Customer customer)
    {
        try
        {
            _customerService.AddCustomer(customer);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
    [Authorize]
    public IActionResult IActionResult(Models.Customer customer)
    {
        try
        {
            _customerService.EditCustomer(customer);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id)
    {
        try
        {
            _customerService.DeleteCustomer(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}