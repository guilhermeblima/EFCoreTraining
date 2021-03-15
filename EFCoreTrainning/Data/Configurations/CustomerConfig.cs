using EFCoreTrainning.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreTrainning.Data.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
                builder.ToTable("Customers");
                builder.HasKey(p => p.Id);
                builder.Property(p => p.Name).HasColumnType("VARCHAR(80)").IsRequired();
                builder.Property(p => p.Phone).HasColumnType("CHAR(9)");
                builder.Property(p => p.PostCode).HasColumnType("CHAR(4)").IsRequired();
                builder.Property(p => p.State).HasColumnType("VARCHAR(30)").IsRequired();
                builder.Property(p => p.City).HasMaxLength(60).IsRequired();
                builder.HasIndex(i => i.Phone).HasName("idx_customer_phone");
        }
    }
}