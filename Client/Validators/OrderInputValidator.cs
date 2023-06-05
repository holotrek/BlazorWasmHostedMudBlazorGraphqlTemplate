using BlazorWasmHostedMudBlazorGraphqlTemplate.Client.GraphQL;
using FluentValidation;

namespace BlazorWasmHostedMudBlazorGraphqlTemplate.Client.Models;

public class OrderInputValidator : AbstractValidator<OrderInput>
{
    public OrderInputValidator()
    {
        RuleFor(input => input.Name).NotNull().NotEmpty();
        RuleFor(input => input.Price).NotNull().NotEmpty().ExclusiveBetween(0m, 1e+6m);
        RuleFor(input => input.LastUpdateBy).NotNull().NotEmpty().WithName("User Name");
    }
}
