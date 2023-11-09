using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("refreshToken");
            
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Token)
            .HasMaxLength(10);

            builder.Property(p => p.Expires)
            .HasColumnType("datetime");
            
            builder.Property(p => p.Created)
            .HasColumnType("datetime");

            builder.Property(p => p.Revoked)
            .HasColumnType("datetime");

            builder.HasOne(p => p.Users)
            .WithMany(p => p.RefreshTokens)
            .HasForeignKey(p => p.IdUserFk);
        }
    }
}