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

    public virtual DbSet<PersonType> Persontypes { get; set; }

    public virtual DbSet<State> States { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}