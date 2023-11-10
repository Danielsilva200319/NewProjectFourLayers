﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Data;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(CampuxContext))]
    [Migration("20231110170740_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdStateFk")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdStateFk" }, "IX_City_IdstateFk");

                    b.ToTable("city", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Costumer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("DateRegister")
                        .HasColumnType("date")
                        .HasColumnName("date_register");

                    b.Property<int>("IdCityFk")
                        .HasColumnType("int");

                    b.Property<string>("IdCustomer")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("IdPersonTypeFk")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdCustomer" }, "IX_Customer_IdCustomer")
                        .IsUnique();

                    b.HasIndex(new[] { "IdPersonTypeFk" }, "IX_customer_IdPersonTypeFk");

                    b.HasIndex(new[] { "IdCityFk" }, "IX_customer_IdcityFk");

                    b.ToTable("costumer", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("country", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.PersonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("persontype", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdcountryFk")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdcountryFk" }, "IX_state_IdcountryFk");

                    b.ToTable("state", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.HasOne("Domain.Entities.State", "IdStateFkNavigation")
                        .WithMany("Cities")
                        .HasForeignKey("IdStateFk")
                        .IsRequired()
                        .HasConstraintName("FK_City_State_IdstateFk");

                    b.Navigation("IdStateFkNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Costumer", b =>
                {
                    b.HasOne("Domain.Entities.City", "IdCityFkNavigation")
                        .WithMany("Costumers")
                        .HasForeignKey("IdCityFk")
                        .IsRequired()
                        .HasConstraintName("FK_customer_city_IdcityFk");

                    b.HasOne("Domain.Entities.PersonType", "IdPersonTypeFkNavigation")
                        .WithMany("Costumers")
                        .HasForeignKey("IdPersonTypeFk")
                        .IsRequired()
                        .HasConstraintName("FK_customer_PersonType_IdPersonTypeFk");

                    b.Navigation("IdCityFkNavigation");

                    b.Navigation("IdPersonTypeFkNavigation");
                });

            modelBuilder.Entity("Domain.Entities.State", b =>
                {
                    b.HasOne("Domain.Entities.Country", "IdcountryFkNavigation")
                        .WithMany("States")
                        .HasForeignKey("IdcountryFk")
                        .IsRequired();

                    b.Navigation("IdcountryFkNavigation");
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Navigation("Costumers");
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("Domain.Entities.PersonType", b =>
                {
                    b.Navigation("Costumers");
                });

            modelBuilder.Entity("Domain.Entities.State", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}