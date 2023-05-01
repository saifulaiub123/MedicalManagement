﻿using SS.Domain.DBModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SS.Infrastructure.Configuration
{
    public class ContactEntityConfiguration : IEntityTypeConfiguration<ContactEntity>
    {
        public void Configure(EntityTypeBuilder<ContactEntity> builder)
        {
            builder.Property(x => x.Id)
               .IsRequired()
               .ValueGeneratedNever();
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
