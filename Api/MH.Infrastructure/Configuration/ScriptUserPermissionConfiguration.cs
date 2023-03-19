﻿using MH.Domain.DBModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MH.Infrastructure.Configuration
{
    public class ScriptUserPermissionConfiguration : IEntityTypeConfiguration<ScriptUserPermission>
    {
        public void Configure(EntityTypeBuilder<ScriptUserPermission> builder)
        {
            builder.HasIndex(x => x.ScriptId)
                .IsUnique(false);
            builder.HasIndex(x => x.UserId)
                .IsUnique(false);
            builder.HasIndex(x => x.PermissionId)
                .IsUnique(false);
            builder.HasIndex(x => x.CreatedBy)
                .IsUnique(false);
            builder.HasIndex(x => x.UpdatedBy)
                .IsUnique(false);

            builder.HasOne(x => x.Script)
                .WithMany(x => x.ScriptUserPermissions)
                .HasForeignKey(x => x.ScriptId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.ScriptUserPermissions)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Permission)
                .WithMany(x => x.ScriptUserPermissions)
                .HasForeignKey(x => x.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);



            builder.HasOne(x => x.CreatedByUser)
               .WithOne(y => y.CreatedByScriptUserPermission)
               .HasForeignKey<ScriptUserPermission>(z => z.CreatedBy)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.UpdateByUser)
               .WithOne(y => y.UpdatedByScriptUserPermission)
               .HasForeignKey<ScriptUserPermission>(z => z.UpdatedBy)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired(false);
        }
    }
}
