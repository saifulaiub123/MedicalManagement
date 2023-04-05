using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MH.Domain.DBModel;

namespace MH.Infrastructure.Configuration
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasIndex(x => x.UserId)
              .IsUnique(false);
            builder.HasIndex(x => x.CountryId)
              .IsUnique(false);
            builder.HasIndex(x => x.StateId)
              .IsUnique(false);
            builder.HasIndex(x => x.CityId)
              .IsUnique(false);
            builder.HasIndex(x => x.CreatedBy)
               .IsUnique(false);
            builder.HasIndex(x => x.UpdatedBy)
               .IsUnique(false);

            builder.Property(x => x.FirstName)
                .HasMaxLength(250);
            builder.Property(x => x.LastName)
                .HasMaxLength(250);
            builder.Property(x => x.Email)
                .HasMaxLength(250);
            builder.Property(x => x.ZipCode)
                .HasMaxLength(50);
            builder.Property(x => x.Address1)
                .HasMaxLength(300);
            builder.Property(x => x.Address2)
                .HasMaxLength(300);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);


            builder.HasOne(x => x.User)
               .WithOne(y => y.UserProfile)
               .HasForeignKey<UserProfile>(z => z.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(x => x.CreatedByUser)
            //   .WithOne(y => y.CreatedByUserProfile)
            //   .HasForeignKey<UserProfile>(z => z.CreatedBy)
            //   .OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(x => x.UpdateByUser)
            //   .WithOne(y => y.UpdatedByUserProfile)
            //   .HasForeignKey<UserProfile>(z => z.UpdatedBy)
            //   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}