using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IceCream.Infrastructure.Persistences.Contexts.Configurations;

public class IceCreamConfiguration : IEntityTypeConfiguration<Domain.Entities.IceCream>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.IceCream> builder)
    {
    }
}
