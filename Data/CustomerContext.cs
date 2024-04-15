using Microsoft.EntityFrameworkCore;

namespace Customer.Data;

public class CustomerContext : DbContext
{
    public CustomerContext(DbContextOptions<CustomerContext> options)
        : base(options)
    {
    }

    public DbSet<Models.Customer> Customers => Set<Models.Customer>();
}