namespace BlazorWasmHostedMudBlazorGraphqlTemplate.Domain;
public class Order : BaseEntity
{
    public Order(Guid id, string name, decimal price, string lastUpdateBy, DateTimeOffset lastUpdateOn)
        : base(id, lastUpdateBy, lastUpdateOn)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; private set; }
    public decimal Price { get; private set; }
}
