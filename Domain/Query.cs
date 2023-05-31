using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasmHostedMudBlazorGraphqlTemplate.Domain;
public class Query
{
    public async Task<IEnumerable<Order>> GetOrders([Service] SampleContext context) =>
        await context.Orders.ToListAsync();

    public async Task<Order?> GetOrder([Service] SampleContext context, Guid id) =>
        await context.Orders.SingleOrDefaultAsync(o => o.Id == id);
}
