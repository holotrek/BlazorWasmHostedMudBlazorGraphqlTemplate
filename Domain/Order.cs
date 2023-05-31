namespace BlazorWasmHostedMudBlazorGraphqlTemplate.Domain;
public class Order : BaseEntity
{
    public Order(Guid id, string name, decimal price, string lastUpdateBy)
        : base(id, lastUpdateBy)
    {
        Name = name;
        Price = price;
    }

    public static Order Create(OrderInput input)
    {
        return new Order(Guid.NewGuid(), input.Name, input.Price, input.LastUpdateBy);
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