using EFCoreTrainning.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreTrainning.Data.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
                builder.ToTable("Products");
                builder.HasKey(p => p.Id);
                builder.Property(p => p.BarCode).HasColumnType("VARCHAR(14)").IsRequired();
                builder.Property(p => p.Description).HasColumnType("VARCHAR(60)");
                builder.Property(p => p.Amount).IsRequired();
                builder.Property(p => p.ProductType).HasConversion<string>();
        }
    }
}