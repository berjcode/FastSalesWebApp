

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Persistance.Configurations.CompanyDbConfiguration;

public sealed class PersonalConfiguration : IEntityTypeConfiguration<Personal>
{
    public void Configure(EntityTypeBuilder<Personal> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn(1, 1);
        builder.HasIndex(x => x.Code).IsUnique();
        builder.Property(p => p.Code).IsRequired().HasColumnType("varchar(20)").HasMaxLength(20);
        builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(150)").HasMaxLength(150);
        builder.Property(p => p.Adress1).HasColumnType("varchar(150)").HasMaxLength(150).IsRequired(false); ;
        builder.Property(p => p.Adress2).HasColumnType("varchar(150)").HasMaxLength(150).IsRequired(false); ;
        builder.Property(p => p.CellPhone1).HasColumnType("char(11)").HasMaxLength(11).IsRequired(false); ;
        builder.Property(p => p.CellPhone2).HasColumnType("char(11)").HasMaxLength(11).IsRequired(false); ;
        builder.Property(p => p.Telephone).HasColumnType("char(11)").HasMaxLength(11).IsRequired(false); ;
        builder.Property(p => p.Email).HasMaxLength(50).IsRequired(false);
        builder.Property(p => p.EndDate).IsRequired(false);
        builder.Property(p => p.BeginDate).IsRequired(true);
        builder.Property(p => p.DepartmentId).IsRequired();

        builder.Property(a => a.CreatorName).IsRequired(false);
        builder.Property(a => a.CreatedDate).IsRequired(false);
        builder.Property(a => a.UpdaterName).IsRequired(false);
        builder.Property(a => a.UpdateDate);

        builder.Property(a => a.DeleterName).IsRequired(false);
        builder.Property(a => a.IsActive).IsRequired(true);
        builder.HasOne(p => p.Department).WithMany(d => d.Personals).HasForeignKey(p => p.DepartmentId);

        builder.ToTable("Personals");
    }
}
