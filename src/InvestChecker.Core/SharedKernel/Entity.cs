namespace InvestChecker.Core.SharedKernel;

public abstract class Entity
{
    protected Entity() => Id = Guid.NewGuid();
    protected Entity(Guid userId, DateTimeOffset date) : this()
    {
        CreatedAt = date;
        CreatedById = userId;
        UpdatedBy(userId, date);
    }

    public Guid Id { get; private init; }
    public DateTimeOffset CreatedAt { get; private set; }
    public Guid CreatedById { get; init; }

    public DateTimeOffset UpdatedAt { get; private set; }
    public Guid UpdatedById { get; private set; }

    public void UpdatedBy(Guid userId, DateTimeOffset date)
    {
        this.UpdatedAt = date;
        this.UpdatedById = userId;
    }

}
