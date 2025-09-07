using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace DataAccess.Mapping
{
    public class SupplierMap : IEntityTypeConfiguration<Supplier>
    {
        // Configure with schema overload
        public void Configure(EntityTypeBuilder<Supplier> builder, string schema)
        {
            builder.ToTable("Supplier", schema);

            // Primary key
            builder.HasKey(s => s.SupplierId).HasName("PK_Supplier");

            // Columns
            builder.Property(s => s.SupplierId).HasColumnName("SupplierID");
            builder.Property(s => s.Name).HasMaxLength(100).IsRequired();
            builder.Property(s => s.EmailAddress).HasMaxLength(255);
        }

        // Default Configure method calls the schema overload with "dbo"
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
