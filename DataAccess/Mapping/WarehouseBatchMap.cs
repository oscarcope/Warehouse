using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace DataAccess.Mapping
{
    public class WarehouseBatchMap : IEntityTypeConfiguration<WarehouseBatch>
    {
        public void Configure(EntityTypeBuilder<WarehouseBatch> builder, string schema)
        {
            builder.ToTable("WarehouseBatch", schema);

            builder.HasKey(wb => wb.WarehouseBatchId).HasName("PK_WarehouseBatch");

            builder.Property(wb => wb.WarehouseBatchId).HasColumnName("WarehouseBatchID");
            builder.Property(wb => wb.BatchId).HasColumnName("BatchID").IsRequired();
            builder.Property(wb => wb.LocationId).HasColumnName("LocationID").IsRequired();
            builder.Property(wb => wb.Quantity).IsRequired();

            builder.HasOne(wb => wb.Batch)
                   .WithMany(b => b.WarehouseBatches)
                   .HasForeignKey(wb => wb.BatchId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(wb => wb.Location)
                   .WithMany(l => l.WarehouseBatches)
                   .HasForeignKey(wb => wb.LocationId)
                   .HasPrincipalKey(l => l.LocationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }

        public void Configure(EntityTypeBuilder<WarehouseBatch> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
