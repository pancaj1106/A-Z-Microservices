using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation($"Seed database associated with context {typeof(OrderContext).Name}");
            }
        }

        private static Order[] GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {UserName = "Pankaj", FirstName = "Pankaj", LastName = "Agrawal", EmailAddress = "test@gmail.com", AddressLine = "Pune", Country = "India", TotalPrice = 3500 }
            }.ToArray();
        }
    }
}
