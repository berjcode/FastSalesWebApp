
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Persistance.Configurations.CompanyDbConfiguration;

public sealed class CustomerTransactionConfiguration : IEntityTypeConfiguration<CustomerTransaction>
{
    public void Configure(EntityTypeBuilder<CustomerTransaction> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
        builder.Property(a => a.PlugNo).HasMaxLength(100).IsRequired(true);
        builder.Property(a => a.CustomerCode).HasMaxLength(100).IsRequired(true);
        builder.Property(a => a.Text).HasMaxLength(100).IsRequired(true);
        builder.Property(a => a.TransactionDate).IsRequired(true);
        builder.Property(a => a.Debt).HasMaxLength(100).IsRequired(true);
        builder.Property(a => a.Credit).HasMaxLength(100).IsRequired(true);
        builder.Property(a => a.Remainder).HasMaxLength(100).IsRequired(true);
        builder.Property(a => a.CreatorName).IsRequired(false);
        builder.Property(a => a.CreatedDate).IsRequired(false);
        builder.Property(a => a.UpdaterName).IsRequired(false);
        builder.Property(a => a.UpdateDate);

        builder.Property(a => a.DeleterName).IsRequired(false);
        builder.Property(a => a.IsActive).IsRequired(true);
        builder.HasOne(a => a.TransactionTypes).WithMany(c => c.CustomerTransactions).HasForeignKey(a => a.ProcessTypeId);

        builder.ToTable("CustomerTransactions");
    }
}
