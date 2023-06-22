

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Persistance.Configurations.CompanyDbConfiguration;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.Property(c => c.Code).IsRequired().HasMaxLength(20).HasColumnType("varchar");
        builder.Property(c => c.GroupCode).IsRequired().HasMaxLength(50).HasColumnType("varchar");
        builder.Property(c => c.Name).IsRequired().HasMaxLength(150).HasColumnType("varchar");
        builder.Property(c => c.Address).IsRequired().HasMaxLength(150).HasColumnType("varchar");
        builder.Property(c => c.Address2).IsRequired().HasMaxLength(150).HasColumnType("varchar");
        builder.Property(c => c.Email).IsRequired().HasMaxLength(50).HasColumnType("nvarchar");
        builder.Property(c => c.TaxOffice).IsRequired().HasMaxLength(250).HasColumnType("varchar");
        builder.Property(c => c.Telephone).IsRequired().HasMaxLength(12).HasColumnType("char");
        builder.Property(c => c.SPECode1).IsRequired().HasColumnType("int");
        builder.Property(c => c.SPECode2).IsRequired().HasColumnType("int");
        builder.Property(c => c.SPECode3).IsRequired().HasColumnType("int");
        builder.Property(c => c.SPECode4).IsRequired().HasColumnType("int");
        builder.Property(c => c.SPECode5).IsRequired().HasColumnType("int");
        builder.Property(a => a.CreatorName).IsRequired(false);
        builder.Property(a => a.CreatedDate).IsRequired(false);
        builder.Property(a => a.UpdaterName).IsRequired(false);
        builder.Property(a => a.UpdateDate);

        builder.Property(a => a.DeleterName).IsRequired(false);
        builder.Property(a => a.IsActive).IsRequired(true);
        builder.Property(c => c.IsView).HasColumnType("bit");
        builder.HasOne(c => c.CustomerType).WithMany(c => c.Customers).HasForeignKey(c => c.CustomerTypeId);


        builder.ToTable("Customers");
    }
}
