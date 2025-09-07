using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace DataAccess.Mapping
{
    public class ManufacturingLotMap : IEntityTypeConfiguration<ManufacturingLot>
    {
        // Configure with schema overload
        public void Configure(EntityTypeBuilder<ManufacturingLot> builder, string schema)
        {
            builder.ToTable("ManufacturingLot", schema);

            // Primary key
            builder.HasKey(m => m.ManufacturingLotId).HasName("PK_ManufacturingLot");

            // Columns
            builder.Property(m => m.ManufacturingLotId).HasColumnName("ManufacturingLotID");
            builder.Property(m => m.LotNumber).HasMaxLength(50).IsRequired();
            builder.Property(m => m.ProductId).HasColumnName("ProductID").IsRequired();
        }

        // Default Configure method calls the schema overload with "dbo"
        public void Configure(EntityTypeBuilder<ManufacturingLot> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
