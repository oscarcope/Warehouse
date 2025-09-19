using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace DataAccess.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        // Configure with schema overload
        public void Configure(EntityTypeBuilder<Product> builder, string schema)
        {
            builder.ToTable("Products", schema);

            // Primary key
            builder.HasKey(p => p.ProductId).HasName("PK_Product");

            // Columns
            builder.Property(p => p.ProductId).HasColumnName("ProductID");
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.SupplierId).HasColumnName("SupplierID").IsRequired();
        }

        // Default Configure method calls the schema overload with "dbo"
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
