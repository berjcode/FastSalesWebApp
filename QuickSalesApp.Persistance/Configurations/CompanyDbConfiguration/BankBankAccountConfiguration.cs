

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Persistance.Configurations.CompanyDbConfiguration;

public sealed class BankBankAccountConfiguration : IEntityTypeConfiguration<BankBankAccount>
{
    public void Configure(EntityTypeBuilder<BankBankAccount> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
        builder.HasOne(b => b.Bank).WithMany(b => b.BankBankAccounts).HasForeignKey(b => b.BankId);
        builder.HasOne(b => b.BankAccount).WithMany(b => b.BankBankAccounts).HasForeignKey(b => b.AccountId);
        builder.Property(a => a.CreatorName).IsRequired(false);
        builder.Property(a => a.CreatedDate).IsRequired(false);
        builder.Property(a => a.UpdaterName).IsRequired(false);
        builder.Property(a => a.UpdateDate);

        builder.Property(a => a.DeleterName).IsRequired(false);
        builder.Property(a => a.IsActive).IsRequired(true);
        builder.ToTable("BankBankAccounts");
    }
}
