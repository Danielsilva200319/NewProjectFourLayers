using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.Data;

public partial class CampuxContext : DbContext
{
    public CampuxContext(DbContextOptions<CampuxContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Costumer> Costumers { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Persontype> Persontypes { get; set; }

    public virtual DbSet<State> States { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user=root;password=123456;database=newprojectfourlayers", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("city");

            entity.HasIndex(e => e.IdStateFk, "IX_City_IdstateFk");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdStateFkNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.IdStateFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_City_State_IdstateFk");
        });

        modelBuilder.Entity<Costumer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("costumer");

            entity.HasIndex(e => e.IdCustomer, "IX_Customer_IdCustomer").IsUnique();

            entity.HasIndex(e => e.IdPersonTypeFk, "IX_customer_IdPersonTypeFk");

            entity.HasIndex(e => e.IdCityFk, "IX_customer_IdcityFk");

            entity.Property(e => e.DateRegister).HasColumnName("date_register");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdCityFkNavigation).WithMany(p => p.Costumers)
                .HasForeignKey(d => d.IdCityFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_customer_city_IdcityFk");

            entity.HasOne(d => d.IdPersonTypeFkNavigation).WithMany(p => p.Costumers)
                .HasForeignKey(d => d.IdPersonTypeFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_customer_PersonType_IdPersonTypeFk");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("country");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Persontype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("persontype");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("state");

            entity.HasIndex(e => e.IdcountryFk, "IX_state_IdcountryFk");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdcountryFkNavigation).WithMany(p => p.States)
                .HasForeignKey(d => d.IdcountryFk)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}