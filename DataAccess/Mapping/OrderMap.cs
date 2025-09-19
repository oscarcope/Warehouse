using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace DataAccess.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        // Configure with schema overload
        public void Configure(EntityTypeBuilder<Order> builder, string schema)
        {
            builder.ToTable("Orders", schema);

            // Primary key
            builder.HasKey(o => o.OrderId).HasName("PK_Order");

            // Columns
            builder.Property(o => o.OrderId).HasColumnName("OrderID");
            builder.Property(o => o.OrderNumber).HasMaxLength(50).IsRequired();
            builder.Property(o => o.OrderDate).IsRequired();
        }

        // Default Configure method calls the schema overload with "dbo"
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
