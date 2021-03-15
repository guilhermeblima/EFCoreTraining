using EFCoreTrainning.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreTrainning.Data.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
                builder.ToTable("Orders");
                builder.HasKey(p => p.Id);
                builder.Property(p => p.StartDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                builder.Property(p => p.EndDate).HasColumnType("CHAR(9)");
                builder.Property(p => p.OrderStatus).HasConversion<string>();
                builder.Property(p => p.ShippingType).HasConversion<int>();
                builder.Property(p => p.Comments).HasColumnType("VARCHAR(512)");
                builder.HasMany(p => p.OrderItems)
                    .WithOne(p => p.Order)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}