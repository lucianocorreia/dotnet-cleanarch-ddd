namespace BuberDinner.Domain.Models;

public abstract class AggregatRoot<TId> : Entity<TId>
    where TId : notnull
{
    protected AggregatRoot(TId id) : base(id)
    {
    }
}
