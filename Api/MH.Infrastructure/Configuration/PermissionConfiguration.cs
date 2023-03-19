﻿using MH.Domain.DBModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Infrastructure.Configuration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasIndex(x => x.CreatedBy)
                .IsUnique(false);
            builder.HasIndex(x => x.UpdatedBy)
                .IsUnique(false);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(250);



            builder.HasOne(x => x.CreatedByUser)
               .WithOne(y => y.CreatedByPermission)
               .HasForeignKey<Permission>(z => z.CreatedBy)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.UpdateByUser)
               .WithOne(y => y.UpdatedByPermission)
               .HasForeignKey<Permission>(z => z.UpdatedBy)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}