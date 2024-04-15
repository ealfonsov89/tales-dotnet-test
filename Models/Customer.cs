
namespace Customer.Models;
public class Customer
{
    public int? Id { get; set; }
    public string Email { get; set; }
    public string First { get; set; }
    public string Last { get; set; }
    public string Company { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Country { get; set; }

    public Customer()
    {
        CreatedAt = DateTime.Now;
        Email = string.Empty;
        First = string.Empty;
        Last = string.Empty;
        Company = string.Empty;
        Country = string.Empty;

    }
}