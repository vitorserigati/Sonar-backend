namespace Sonar.Domain.Primitives;

public abstract class Entity<T>
{
    public T Id { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }

    public DateTime? UpdatedAtUtc { get; private set; }

    public Entity(T id, DateTime createdAtUtc, DateTime? updatedAtUtc)
    {
        Id = id;
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = updatedAtUtc;
    }
}
