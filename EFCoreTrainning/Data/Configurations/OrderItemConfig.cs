using EFCoreTrainning.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreTrainning.Data.Configurations
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
                builder.ToTable("OrderItems");
                builder.HasKey(p => p.Id);
                builder.Property(p => p.Quantity).HasDefaultValue(1).IsRequired();
                builder.Property(p => p.Amount).IsRequired();
                builder.Property(p => p.Discount).IsRequired();
        }
    }
}