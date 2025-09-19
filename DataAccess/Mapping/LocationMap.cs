using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace DataAccess.Mapping
{
    public class LocationMap : IEntityTypeConfiguration<Location>
    {
        // Configure with schema overload
        public void Configure(EntityTypeBuilder<Location> builder, string schema)
        {
            builder.ToTable("Locations", schema);

            // Primary key
            builder.HasKey(l => l.LocationId).HasName("PK_Location");

            // Columns
            builder.Property(l => l.LocationId).HasColumnName("LocationID");
            builder.Property(l => l.LocationNumber).HasMaxLength(50).IsRequired();
        }

        // Default Configure method calls the schema overload with "dbo"
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            Configure(builder, "dbo");
        }
    }
}

