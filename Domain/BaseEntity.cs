namespace BlazorWasmHostedMudBlazorGraphqlTemplate.Domain;
public abstract class BaseEntity
{
    protected BaseEntity(
        Guid id, 
        string lastUpdateBy)
    {
        Id = id;
        LastUpdateBy = lastUpdateBy;
    }

    public Guid Id { get; private set; }
    public string LastUpdateBy { get; protected set; }
    public DateTimeOffset LastUpdateOn { get; protected set; } = DateTimeOffset.UtcNow;
}
