using FluentValidation;

namespace BlazorWasmHostedMudBlazorGraphqlTemplate.Domain;
public class Order : BaseEntity
{
    internal Order(string name, decimal price, string lastUpdateBy)
        : base(lastUpdateBy)
    {
        Name = name;
        Price = price;
    }

    public static Order Create(OrderInput input)
    {
        return new Order(input.Name, input.Price, input.LastUpdateBy);
    }

    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public void Update(OrderInput input)
    {
        Name = input.Name;
        Price = input.Price;
        LastUpdateBy = input.LastUpdateBy;
        LastUpdateOn = DateTimeOffset.UtcNow;
    }
}

public class OrderInput
{
    public OrderInput(Guid? id, string name, decimal price, string lastUpdateBy)
    {
        Id = id;
        Name = name;
        Price = price;
        LastUpdateBy = lastUpdateBy;
    }

    public Guid? Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public string LastUpdateBy { get; }
}

public class OrderInputValidator : AbstractValidator<OrderInput>
{
    public OrderInputValidator()
    {
        RuleFor(input => input.Name).NotNull().NotEmpty();
        RuleFor(input => input.Price).NotNull().NotEmpty().ExclusiveBetween(0m, 1e+6m);
        RuleFor(input => input.LastUpdateBy).NotNull().NotEmpty().WithName("User Name");
    }
}
