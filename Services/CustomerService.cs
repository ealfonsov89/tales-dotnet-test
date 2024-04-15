
namespace Customer.Services;

using Customer.Data;
using Customer.DataTransferObjects;
using Customer.Models;
using Microsoft.EntityFrameworkCore;

public class CustomerService
{
    CustomerContext _customerContext;
    public CustomerService(CustomerContext customerContext)
    {
        _customerContext = customerContext;
    }

    public List<CustomerDto> GetCustomers(int page, int pageSize)
    {
        return [.. _customerContext.Customers.AsNoTracking().Skip((page - 1) * pageSize).Take(pageSize).Select(customer => new CustomerDto
        {
            Id = customer.Id,
            First = customer.First,
            Last = customer.Last,
            CreatedAt = customer.CreatedAt
        })];
    }
    public void EditCustomer(Customer customer)
    {
        var customerToEdit = _customerContext.Customers.Find(customer.Id);
        if (customerToEdit is not null)
        {
            customerToEdit.Email = customer.Email;
            customerToEdit.First = customer.First;
            customerToEdit.Last = customer.Last;
            customerToEdit.Company = customer.Company;
            customerToEdit.CreatedAt = customer.CreatedAt;
            customerToEdit.Country = customer.Country;
            _customerContext.Customers.Update(customerToEdit);
            _customerContext.SaveChanges();
        }
    }
    public void AddCustomer(Customer customer)
    {
        _customerContext.Customers.Add(customer);
        _customerContext.SaveChanges();

    }
    public void DeleteCustomer(int id)
    {
        var customerToDelete = _customerContext.Customers.Find(id);
        if (customerToDelete is not null)
        {
            _customerContext.Customers.Remove(customerToDelete);
            _customerContext.SaveChanges();
        }
    }
}
