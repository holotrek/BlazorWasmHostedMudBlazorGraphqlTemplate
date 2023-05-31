using BlazorWasmHostedMudBlazorGraphqlTemplate.Client.GraphQL;
using FluentValidation;

namespace BlazorWasmHostedMudBlazorGraphqlTemplate.Client.Models;

public class OrderInputValidator : AbstractValidator<OrderInput>
{
    public OrderInputValidator()
    {
        RuleFor(o => o.Name).NotNull().NotEmpty();
        RuleFor(o => o.Price).NotNull().NotEmpty().ExclusiveBetween(0m, 1e+6m);
        RuleFor(o => o.LastUpdateBy).NotNull().NotEmpty().WithName("User Name");
    }
}
