using AppAny.HotChocolate.FluentValidation;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasmHostedMudBlazorGraphqlTemplate.Domain;
public class Mutation
{
    [Authorize]
    public async Task<Order> UpsertOrder(
        [Service] SampleContext context,
        [UseFluentValidation] OrderInput orderInput)
    {
        var existing = await context.Orders.SingleOrDefaultAsync(o => o.Id == orderInput.Id);
        if (existing == default)
        {
            var existsByName = await context.Orders.AnyAsync(o => o.Name.ToLower() == orderInput.Name.ToLower());
            if (existsByName)
            {
                throw new QueryException($"Order {orderInput.Name} already exists.");
            }

            existing = Order.Create(orderInput);
            context.Orders.Add(existing);
        }
        else
        {
            existing.Update(orderInput);
        }

        await context.SaveChangesAsync();
        return existing;
    }
}
