namespace QuickSalesApp.Domain.Abstractions;

public abstract class Entity
{
    public Entity()
    {

    }

    public Entity(string id)
    {
        Id = id;
    }
    public virtual string Id { get; set; }

    public virtual DateTime? CreatedDate { get; set; } = DateTime.Now;

    public virtual DateTime? UpdateDate { get; set; } = null;
    
}
