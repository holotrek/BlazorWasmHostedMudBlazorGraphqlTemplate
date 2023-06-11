using HotChocolate;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasmHostedMudBlazorGraphqlTemplate.Domain;
public class Query
{
    [Authorize]
    public async Task<IEnumerable<Order>> GetOrders([Service] SampleContext context) =>
        await context.Orders.ToListAsync();

    [Authorize]
    public async Task<Order?> GetOrder([Service] SampleContext context, Guid id) =>
        await context.Orders.SingleOrDefaultAsync(o => o.Id == id);
}
