using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MH.Domain.DBModel;

namespace MH.Infrastructure.Configuration
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            //builder.HasIndex(x => x.DestinationServerId)
            //   .IsUnique(false);
            //builder.HasIndex(x => x.CreatedBy)
            //   .IsUnique(false);
            //builder.HasIndex(x => x.UpdatedBy)
            //   .IsUnique(false);

            //builder.Property(x => x.IsDeleted)
            //    .HasDefaultValue(false);
            //builder.Property(x => x.Name)
                //.HasMaxLength(250);



                        //builder.HasOne(x => x.CreatedByUser)
            //   .WithOne(y => y.CreatedByCountry)
            //   .HasForeignKey<Country>(z => z.CreatedBy)
            //   .OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(x => x.UpdateByUser)
            //   .WithOne(y => y.UpdatedByCountry)
            //   .HasForeignKey<Country>(z => z.UpdatedBy)
            //   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}