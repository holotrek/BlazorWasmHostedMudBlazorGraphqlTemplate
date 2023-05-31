namespace BlazorWasmHostedMudBlazorGraphqlTemplate.Domain;
public abstract class BaseEntity
{
    protected BaseEntity(
        Guid id, 
        string lastUpdateBy, 
        DateTimeOffset lastUpdateOn)
    {
        Id = id;
        LastUpdateBy = lastUpdateBy;
        LastUpdateOn = lastUpdateOn;
    }

    public Guid Id { get; private set; }
    public string LastUpdateBy { get; private set; }
    public DateTimeOffset LastUpdateOn { get; private set; }
}
