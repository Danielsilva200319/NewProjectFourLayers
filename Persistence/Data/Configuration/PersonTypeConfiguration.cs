using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PersonTypeConfiguration : IEntityTypeConfiguration<PersonType>
    {
        public void Configure(EntityTypeBuilder<PersonType> builder)
        {
            builder.ToTable("persontype");

            builder.HasKey(e => e.Id)
            .HasName("PRIMARY");

            builder.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");
        }
    }
}