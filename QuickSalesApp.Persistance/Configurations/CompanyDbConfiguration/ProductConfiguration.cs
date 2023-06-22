using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;


namespace QuickSalesApp.Persistance.Configurations.CompanyDbConfiguration;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
        builder.Property(a => a.Code).HasMaxLength(50).IsRequired(true);
        builder.Property(a => a.Name).HasMaxLength(100).IsRequired(true);

        builder.Property(a => a.Photo).IsRequired(false);
        builder.Property(c => c.SPECode1).IsRequired().HasColumnType("int");
        builder.Property(c => c.SPECode2).IsRequired().HasColumnType("int");
        builder.Property(c => c.SPECode3).IsRequired().HasColumnType("int");
        builder.Property(c => c.SPECode4).IsRequired().HasColumnType("int");
        builder.Property(c => c.SPECode5).IsRequired().HasColumnType("int");
        builder.Property(c => c.GroupCode).IsRequired(false).HasMaxLength(50);
        builder.Property(a => a.CreatorName).IsRequired(false);
        builder.Property(a => a.CreatedDate).IsRequired(false);
        builder.Property(a => a.UpdaterName).IsRequired(false);
        builder.Property(a => a.UpdateDate);

        builder.Property(a => a.DeleterName).IsRequired(false);
        builder.Property(a => a.IsActive).IsRequired(true);
        builder.HasOne(c => c.Category).WithMany(c => c.Products).HasForeignKey(a => a.CategoryId);
        builder.HasOne(c => c.VatType).WithMany(c => c.Products).HasForeignKey(a => a.VatTypeId);
        builder.HasOne(c => c.ProductType).WithMany(c => c.Product).HasForeignKey(a => a.ProductTypeId);
        builder.ToTable("Products");

    }
}
