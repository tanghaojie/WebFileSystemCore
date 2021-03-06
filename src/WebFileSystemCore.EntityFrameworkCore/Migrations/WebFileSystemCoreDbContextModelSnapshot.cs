﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebFileSystemCore.EntityFrameworkCore;

namespace WebFileSystemCore.Migrations
{
    [DbContext(typeof(WebFileSystemCoreDbContext))]
    partial class WebFileSystemCoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("WebFileSystemCore")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WebFileSystemCore.Entities.File", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ContentType")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Extension")
                        .HasColumnType("text");

                    b.Property<string>("FileTypeStr")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastUpdationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("LastVisitTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("Length")
                        .HasColumnType("bigint");

                    b.Property<string>("LocalFilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Owner")
                        .HasColumnType("text");

                    b.Property<string>("PermissionsStr")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
