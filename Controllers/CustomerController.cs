using Customer.Services;
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
    public List<Models.Customer> Get(int page, int pageSize)
    {
        return _customerService.GetCustomers(page, pageSize);
    }
    [HttpPost]
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