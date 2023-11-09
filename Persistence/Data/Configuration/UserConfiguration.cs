using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Username)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.Password)
            .IsRequired()
            .HasMaxLength(225);

            builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(100);

            builder.HasMany(p => p.Rols)
            .WithMany(c => c.Users)
            .UsingEntity<UserRol>(
                a => a.HasOne(p => p.Rols)
                .WithMany(p => p.UserRols)
                .HasForeignKey(c => c.IdRolFk),
                a => a.HasOne(p => p.Users)
                .WithMany(p => p.UserRols)
                .HasForeignKey(c => c.IdUserFk),
                a =>
                {
                    a.ToTable("userrol");
                    a.HasKey(x => new { x.IdUserFk, x.IdRolFk });
                }
            );
        }
    }
}