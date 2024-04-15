using System.Text.Json;
namespace Customer.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CustomerContext context)
        {

            if (context.Customers.Any())
            {
                return;
            }

            var customersJson = File.ReadAllText("customers.json");
            List<Models.Customer>? custoemers = JsonSerializer.Deserialize<List<Models.Customer>>(customersJson);
            if (custoemers is null || !custoemers.Any())
            {
                return;
            }
            context.Customers.AddRange(custoemers);
            context.SaveChanges();
        }
    }
}