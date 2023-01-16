﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Salon.Data;

#nullable disable

namespace Salon.Migrations
{
    [DbContext(typeof(SalonContext))]
    [Migration("20230115205838_ClientNume")]
    partial class ClientNume
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("salon.Models.Angajat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Angajat");
                });

            modelBuilder.Entity("salon.Models.AngajatServiciu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AngajatID")
                        .HasColumnType("int");

                    b.Property<int>("ServiciuID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AngajatID");

                    b.HasIndex("ServiciuID");

                    b.ToTable("AngajatServiciu");
                });

            modelBuilder.Entity("salon.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("salon.Models.Programare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("AngajatID")
                        .HasColumnType("int");

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Durata")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<double>("Pret")
                        .HasColumnType("float");

                    b.Property<int?>("ServiciuID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("ID");

                    b.HasIndex("AngajatID");

                    b.HasIndex("ClientID");

                    b.HasIndex("ServiciuID");

                    b.ToTable("Programare");
                });

            modelBuilder.Entity("salon.Models.Serviciu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Denumire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descriere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Durata")
                        .HasColumnType("int");

                    b.Property<double>("Pret")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Serviciu");
                });

            modelBuilder.Entity("salon.Models.AngajatServiciu", b =>
                {
                    b.HasOne("salon.Models.Angajat", "Angajat")
                        .WithMany("AngajatiServicii")
                        .HasForeignKey("AngajatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("salon.Models.Serviciu", "Serviciu")
                        .WithMany("AngajatiServicii")
                        .HasForeignKey("ServiciuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Angajat");

                    b.Navigation("Serviciu");
                });

            modelBuilder.Entity("salon.Models.Programare", b =>
                {
                    b.HasOne("salon.Models.Angajat", "Angajat")
                        .WithMany()
                        .HasForeignKey("AngajatID");

                    b.HasOne("salon.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID");

                    b.HasOne("salon.Models.Serviciu", "Serviciu")
                        .WithMany()
                        .HasForeignKey("ServiciuID");

                    b.Navigation("Angajat");

                    b.Navigation("Client");

                    b.Navigation("Serviciu");
                });

            modelBuilder.Entity("salon.Models.Angajat", b =>
                {
                    b.Navigation("AngajatiServicii");
                });

            modelBuilder.Entity("salon.Models.Serviciu", b =>
                {
                    b.Navigation("AngajatiServicii");
                });
#pragma warning restore 612, 618
        }
    }
}
