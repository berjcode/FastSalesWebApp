
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Persistance.Configurations.CompanyDbConfiguration;

public sealed class VatTypeConfiguration : IEntityTypeConfiguration<VatType>
{
    public void Configure(EntityTypeBuilder<VatType> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
        builder.Property(a => a.Name).HasMaxLength(50).IsRequired(true);
        builder.Property(a => a.Value).HasMaxLength(50).IsRequired(true);
        builder.Property(a => a.CreatorName).IsRequired(false);
        builder.Property(a => a.CreatedDate).IsRequired(false);
        builder.Property(a => a.UpdaterName).IsRequired(false);
        builder.Property(a => a.UpdateDate);

        builder.Property(a => a.DeleterName).IsRequired(false);
        builder.Property(a => a.IsActive).IsRequired(true);
        builder.ToTable("VatTypes");
    }
}
