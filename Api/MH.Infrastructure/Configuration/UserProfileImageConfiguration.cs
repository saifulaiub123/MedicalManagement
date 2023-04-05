using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MH.Domain.DBModel;

namespace MH.Infrastructure.Configuration
{
    public class UserProfileImageConfiguration : IEntityTypeConfiguration<UserProfileImage>
    {
        public void Configure(EntityTypeBuilder<UserProfileImage> builder)
        {
            builder.HasIndex(x => x.UserProfileId)
               .IsUnique(false);
            builder.HasIndex(x => x.CreatedBy)
               .IsUnique(false);
            builder.HasIndex(x => x.UpdatedBy)
               .IsUnique(false);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.HasOne(x => x.CreatedByUser)
               .WithOne(y => y.CreatedByUserProfileImage)
               .HasForeignKey<UserProfileImage>(z => z.CreatedBy)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.UpdateByUser)
               .WithOne(y => y.UpdatedByUserProfileImage)
               .HasForeignKey<UserProfileImage>(z => z.UpdatedBy)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}