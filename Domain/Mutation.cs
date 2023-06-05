using AppAny.HotChocolate.FluentValidation;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasmHostedMudBlazorGraphqlTemplate.Domain;
public class Mutation
{
    public async Task<Order> UpsertOrder(
        [Service] SampleContext context,
        [UseFluentValidation] OrderInput orderInput)
    {
        var existing = await context.Orders.SingleOrDefaultAsync(o => o.Id == orderInput.Id);
        if (existing == null)
        {
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
