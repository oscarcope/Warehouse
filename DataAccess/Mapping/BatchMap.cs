using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace DataAccess.Mapping
{
    public class BatchMap : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> builder, string schema)
        {
            builder.ToTable("Batch", schema);

            builder.HasKey(b => b.BatchId).HasName("PK_Batch");

            builder.Property(b => b.BatchId).HasColumnName("BatchID");
            builder.Property(b => b.BatchNumber).HasMaxLength(50).IsRequired();
            builder.Property(b => b.ManufacturingLotId).HasColumnName("ManufacturingLotID").IsRequired();
            builder.Property(b => b.Quantity).IsRequired();
        }

        public void Configure(EntityTypeBuilder<Batch> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
