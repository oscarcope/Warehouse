using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace DataAccess.Mapping
{
    public class WarehouseBatchMap : IEntityTypeConfiguration<WarehouseBatch>
    {
        // Configure with schema overload
        public void Configure(EntityTypeBuilder<WarehouseBatch> builder, string schema)
        {
            builder.ToTable("WarehouseBatch", schema);

            // Primary key
            builder.HasKey(wb => wb.WarehouseBatchId).HasName("PK_WarehouseBatch");

            // Columns
            builder.Property(wb => wb.WarehouseBatchId).HasColumnName("WarehouseBatchID");
            builder.Property(wb => wb.BatchId).HasColumnName("BatchID").IsRequired();
            builder.Property(wb => wb.LocationId).HasColumnName("LocationID").IsRequired();
        }

        // Default Configure method calls the schema overload with "dbo"
        public void Configure(EntityTypeBuilder<WarehouseBatch> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
