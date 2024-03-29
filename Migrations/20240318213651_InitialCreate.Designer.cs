﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using adm_impuestos.Models;

#nullable disable

namespace adm_impuestos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240318213651_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("adm_impuestos.Models.Contribuyente", b =>
                {
                    b.Property<int>("CodContrib")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CodContrib"));

                    b.Property<int?>("CodPersona")
                        .HasColumnType("integer");

                    b.Property<int?>("CodtipoContrib")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("FecCierre")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FecReg")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NumCamaraComer")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("CodContrib");

                    b.HasIndex("CodPersona");

                    b.HasIndex("CodtipoContrib");

                    b.ToTable("Contribuyentes");
                });

            modelBuilder.Entity("adm_impuestos.Models.EventoContribuyente", b =>
                {
                    b.Property<int>("CodContrib")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CodContrib"));

                    b.Property<int?>("ContribuyenteCodContrib")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Feccarga")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("Itbis")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("MontoNeto")
                        .HasColumnType("numeric");

                    b.Property<string>("NcfUsado")
                        .HasColumnType("text");

                    b.Property<decimal?>("PorItbis")
                        .HasColumnType("numeric");

                    b.HasKey("CodContrib");

                    b.HasIndex("ContribuyenteCodContrib");

                    b.ToTable("EventosContribuyente");
                });

            modelBuilder.Entity("adm_impuestos.Models.Persona", b =>
                {
                    b.Property<int>("CodPersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CodPersona"));

                    b.Property<string>("DocumentoIdent")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FecNac")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PApe")
                        .HasColumnType("text");

                    b.Property<string>("PNom")
                        .HasColumnType("text");

                    b.Property<string>("RazonSocial")
                        .HasColumnType("text");

                    b.Property<string>("SApe")
                        .HasColumnType("text");

                    b.Property<string>("SNom")
                        .HasColumnType("text");

                    b.Property<string>("Sexo")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("TipoIdent")
                        .HasColumnType("text");

                    b.HasKey("CodPersona");

                    b.ToTable("persona");
                });

            modelBuilder.Entity("adm_impuestos.Models.SecuenciaNcf", b =>
                {
                    b.Property<int>("CodSec")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CodSec"));

                    b.Property<int?>("CantNum")
                        .HasColumnType("integer");

                    b.Property<int?>("CodVersion")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Fecreg")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("SecFin")
                        .HasColumnType("bigint");

                    b.Property<long?>("SecIni")
                        .HasColumnType("bigint");

                    b.Property<string>("Serie")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("TipoNcf")
                        .HasColumnType("text");

                    b.HasKey("CodSec");

                    b.HasIndex("TipoNcf", "Serie", "CodVersion");

                    b.ToTable("SecuenciaNcf");
                });

            modelBuilder.Entity("adm_impuestos.Models.SerieNcf", b =>
                {
                    b.Property<string>("Serie")
                        .HasColumnType("text");

                    b.Property<string>("AplicaFactElect")
                        .HasColumnType("text");

                    b.Property<string>("DescripSerie")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Serie");

                    b.ToTable("SerieNcf");
                });

            modelBuilder.Entity("adm_impuestos.Models.Tipo_Contribuyente", b =>
                {
                    b.Property<int>("CodtipoContrib")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CodtipoContrib"));

                    b.Property<DateTime?>("FecReg")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("TipoContribuyente")
                        .HasColumnType("text");

                    b.HasKey("CodtipoContrib");

                    b.ToTable("TipoContribuyente");
                });

            modelBuilder.Entity("adm_impuestos.Models.Tipo_Identificacion", b =>
                {
                    b.Property<string>("TipoIdent")
                        .HasColumnType("text");

                    b.Property<string>("DescripcionTipoIdent")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Status")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("TipoIdent");

                    b.ToTable("Tipo_Identificacion");
                });

            modelBuilder.Entity("adm_impuestos.Models.Tipo_Ncf", b =>
                {
                    b.Property<string>("TipoNcf")
                        .HasColumnType("text");

                    b.Property<string>("Serie")
                        .HasColumnType("text");

                    b.Property<int>("CodVersion")
                        .HasColumnType("integer");

                    b.Property<string>("DescripTiponcf")
                        .HasColumnType("text");

                    b.Property<int>("LongSecuencia")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("TipoNcf", "Serie", "CodVersion");

                    b.HasIndex("CodVersion");

                    b.HasIndex("Serie");

                    b.ToTable("TipoNcfs");
                });

            modelBuilder.Entity("adm_impuestos.Models.VersionNcf", b =>
                {
                    b.Property<int>("CodVersion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CodVersion"));

                    b.Property<string>("Desccripcion")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Fecfin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Fecini")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("CodVersion");

                    b.ToTable("VersionNcf");
                });

            modelBuilder.Entity("adm_impuestos.Models.Contribuyente", b =>
                {
                    b.HasOne("adm_impuestos.Models.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("CodPersona");

                    b.HasOne("adm_impuestos.Models.Tipo_Contribuyente", "TipoContribuyente")
                        .WithMany()
                        .HasForeignKey("CodtipoContrib");

                    b.Navigation("Persona");

                    b.Navigation("TipoContribuyente");
                });

            modelBuilder.Entity("adm_impuestos.Models.EventoContribuyente", b =>
                {
                    b.HasOne("adm_impuestos.Models.Contribuyente", "Contribuyente")
                        .WithMany("EventosContribuyente")
                        .HasForeignKey("ContribuyenteCodContrib");

                    b.Navigation("Contribuyente");
                });

            modelBuilder.Entity("adm_impuestos.Models.SecuenciaNcf", b =>
                {
                    b.HasOne("adm_impuestos.Models.Tipo_Ncf", "Tipo_Ncf")
                        .WithMany()
                        .HasForeignKey("TipoNcf", "Serie", "CodVersion");

                    b.Navigation("Tipo_Ncf");
                });

            modelBuilder.Entity("adm_impuestos.Models.Tipo_Ncf", b =>
                {
                    b.HasOne("adm_impuestos.Models.VersionNcf", "VersionNcf")
                        .WithMany()
                        .HasForeignKey("CodVersion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("adm_impuestos.Models.SerieNcf", "SerieNcf")
                        .WithMany()
                        .HasForeignKey("Serie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SerieNcf");

                    b.Navigation("VersionNcf");
                });

            modelBuilder.Entity("adm_impuestos.Models.Contribuyente", b =>
                {
                    b.Navigation("EventosContribuyente");
                });
#pragma warning restore 612, 618
        }
    }
}
