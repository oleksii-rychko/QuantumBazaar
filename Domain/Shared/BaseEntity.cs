namespace Domain.Shared;

public class BaseEntity
{
    private readonly List<BaseEvent> _domainEvents = new();
    
    public int Id { get; set; }

    public DateTime Created { get; set; } = DateTime.Now;
    
    public DateTime Updated { get; set; } = DateTime.Now;
    
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}