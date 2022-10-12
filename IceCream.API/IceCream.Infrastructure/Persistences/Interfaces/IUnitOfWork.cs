namespace IceCream.Infrastructure.Persistences.Interfaces;

public interface IUnitOfWork : IDisposable
{
    //Declare interfaces to repository level
    ICategoryRepository Category { get; }

    void SaveChanges();

    Task SaveChangesAsync();
}
