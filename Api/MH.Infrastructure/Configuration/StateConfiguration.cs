using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MH.Domain.DBModel;

namespace MH.Infrastructure.Configuration
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasMaxLength(100);
            builder.Property(x => x.CountryId);
            builder.Property(x => x.CountryCode)
                .HasMaxLength(10);
            builder.Property(x => x.CountryName)
                .HasMaxLength(100);

            builder.Property(x => x.DateCreated)
                .HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.CreatedBy)
                .HasDefaultValue(0);
            builder.Property(x => x.LastUpdated)
                .HasDefaultValue(DateTime.UtcNow); ;
            builder.Property(x => x.UpdatedBy)
                .HasDefaultValue(0);
        }
    }
}