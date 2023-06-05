namespace BlazorWasmHostedMudBlazorGraphqlTemplate.Domain;
public abstract class BaseEntity
{
    protected BaseEntity(string lastUpdateBy)
    {
        LastUpdateBy = lastUpdateBy;
    }

    public Guid Id { get; protected set; } = Guid.NewGuid();
    public string LastUpdateBy { get; protected set; }
    public DateTimeOffset LastUpdateOn { get; protected set; } = DateTimeOffset.UtcNow;
}
