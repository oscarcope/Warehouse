using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace DataAccess.Mapping
{
    public class OrderItemLocationMap : IEntityTypeConfiguration<OrderItemLocation>
    {
        // Configure with schema overload
        public void Configure(EntityTypeBuilder<OrderItemLocation> builder, string schema)
        {
            builder.ToTable("OrderItemLocation", schema);

            // Primary key
            builder.HasKey(oil => oil.OrderItemLocationId).HasName("PK_OrderItemLocation");

            // Columns
            builder.Property(oil => oil.OrderItemLocationId).HasColumnName("OrderItemLocationID");
            builder.Property(oil => oil.OrderItemId).HasColumnName("OrderItemID").IsRequired();
            builder.Property(oil => oil.WarehouseBatchId).HasColumnName("WarehouseBatchID").IsRequired();
            builder.Property(oil => oil.ProductId).HasColumnName("ProductID").IsRequired();
            builder.Property(oil => oil.Quantity).IsRequired();
        }

        // Default Configure method calls the schema overload with "dbo"
        public void Configure(EntityTypeBuilder<OrderItemLocation> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
