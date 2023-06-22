

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Persistance.Configurations.CompanyDbConfiguration;

public sealed class SafeConfiguration : IEntityTypeConfiguration<Safe>
{
    public void Configure(EntityTypeBuilder<Safe> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
        builder.Property(a => a.CurrencyType).HasMaxLength(50).IsRequired(true);
        builder.Property(a => a.Name).HasMaxLength(100).IsRequired(true);
        builder.Property(a => a.Debt).HasMaxLength(100).IsRequired(false);
        builder.Property(a => a.Credit).HasMaxLength(100).IsRequired(false);
        builder.Property(a => a.Remainder).HasMaxLength(100).IsRequired(false);
        builder.Property(a => a.Code).HasMaxLength(50).IsRequired(true);
        builder.Property(a => a.CreatorName).IsRequired(false);
        builder.Property(a => a.CreatedDate).IsRequired(false);
        builder.Property(a => a.UpdaterName).IsRequired(false);
        builder.Property(a => a.UpdateDate);

        builder.Property(a => a.DeleterName).IsRequired(false);
        builder.Property(a => a.IsActive).IsRequired(true);
        builder.HasOne(c => c.Currency).WithMany(c => c.Safes).HasForeignKey(a => a.CurrencyType);
        builder.ToTable("Safes");
    }
}
