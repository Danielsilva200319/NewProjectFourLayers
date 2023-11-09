using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CostumerConfiguration : IEntityTypeConfiguration<Costumer>
    {
        public void Configure(EntityTypeBuilder<Costumer> builder)
        {
            builder.ToTable("costumer");

            builder.HasKey(e => e.Id)
            .HasName("PRIMARY");

            builder.HasIndex(e => e.IdCustomer, "IX_Customer_IdCustomer")
            .IsUnique();

            builder.HasIndex(e => e.IdPersonTypeFk, "IX_customer_IdPersonTypeFk");

            builder.HasIndex(e => e.IdCityFk, "IX_customer_IdcityFk");

            builder.Property(e => e.DateRegister)
            .HasColumnName("date_register");

            builder.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");

            builder.HasOne(d => d.IdCityFkNavigation)
            .WithMany(p => p.Costumers)
            .HasForeignKey(d => d.IdCityFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_customer_city_IdcityFk");

            builder.HasOne(d => d.IdPersonTypeFkNavigation)
            .WithMany(p => p.Costumers)
            .HasForeignKey(d => d.IdPersonTypeFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_customer_PersonType_IdPersonTypeFk");
        }
    }
}