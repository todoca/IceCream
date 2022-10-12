using IceCream.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IceCream.Infrastructure.Persistences.Contexts;

public partial class IceCreamContext : DbContext
{
	public IceCreamContext(DbContextOptions<IceCreamContext> options) : base(options)
	{
	}
	public virtual DbSet<Category> Categories => Set<Category>();
	public virtual DbSet<Domain.Entities.IceCream> IceCreams => Set<Domain.Entities.IceCream>();
	public virtual DbSet<Provider> Providers => Set<Provider>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		OnModelCreatingPartial(modelBuilder);
	}
	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
