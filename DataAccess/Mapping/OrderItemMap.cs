using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace DataAccess.Mapping
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        // Configure with schema overload
        public void Configure(EntityTypeBuilder<OrderItem> builder, string schema)
        {
            builder.ToTable("OrderItems", schema);

            // Primary key
            builder.HasKey(oi => oi.OrderItemId).HasName("PK_OrderItem");

            // Columns
            builder.Property(oi => oi.OrderItemId).HasColumnName("OrderItemID");
            builder.Property(oi => oi.OrderId).HasColumnName("OrderID").IsRequired();
            builder.Property(oi => oi.BatchId).HasColumnName("BatchID").IsRequired();
            builder.Property(oi => oi.Quantity).IsRequired();
        }

        // Default Configure method calls the schema overload with "dbo"
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
