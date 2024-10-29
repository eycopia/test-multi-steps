﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using catalogo;

#nullable disable

namespace app.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241029003618_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("catalogo.Models.Afiliacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aplicacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Correo")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("ResponsableSeguridad")
                        .HasColumnType("TEXT");

                    b.Property<string>("ResponsableSquad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tecnologia")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoAfiliacion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Afiliaciones");
                });

            modelBuilder.Entity("catalogo.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Rubro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("catalogo.Models.EmpresaAfiliacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AfiliacionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SquadResponsable")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AfiliacionId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("EmpresaAfiliaciones");
                });

            modelBuilder.Entity("catalogo.Models.RutaServidor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AfiliacionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ruta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AfiliacionId");

                    b.ToTable("RutasServidores");
                });

            modelBuilder.Entity("catalogo.Models.RutaSftp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AfiliacionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ruta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AfiliacionId");

                    b.ToTable("RutasSftp");
                });

            modelBuilder.Entity("catalogo.Models.EmpresaAfiliacion", b =>
                {
                    b.HasOne("catalogo.Models.Afiliacion", "Afiliacion")
                        .WithMany()
                        .HasForeignKey("AfiliacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("catalogo.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Afiliacion");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("catalogo.Models.RutaServidor", b =>
                {
                    b.HasOne("catalogo.Models.Afiliacion", "Afiliacion")
                        .WithMany()
                        .HasForeignKey("AfiliacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Afiliacion");
                });

            modelBuilder.Entity("catalogo.Models.RutaSftp", b =>
                {
                    b.HasOne("catalogo.Models.Afiliacion", "Afiliacion")
                        .WithMany()
                        .HasForeignKey("AfiliacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Afiliacion");
                });
#pragma warning restore 612, 618
        }
    }
}
