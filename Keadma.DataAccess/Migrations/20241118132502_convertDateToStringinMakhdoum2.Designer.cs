﻿// <auto-generated />
using System;
using Keadma.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Keadma.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241118132502_convertDateToStringinMakhdoum2")]
    partial class convertDateToStringinMakhdoum2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Khedma.Entites.Models.Koral", b =>
                {
                    b.Property<int>("MakhdoumID")
                        .HasColumnType("int");

                    b.Property<int>("StageID")
                        .HasColumnType("int");

                    b.HasKey("MakhdoumID", "StageID");

                    b.HasIndex("StageID");

                    b.ToTable("Tbkoral");
                });

            modelBuilder.Entity("Khedma.Entites.Models.Makhdoum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("TBMakhdoum");
                });

            modelBuilder.Entity("Khedma.Entites.Models.TheStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("EndFrom")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateOnly?>("StartFrom")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("TBTheStage");
                });

            modelBuilder.Entity("Khedma.Entites.Models.Koral", b =>
                {
                    b.HasOne("Khedma.Entites.Models.Makhdoum", "Makhdoum")
                        .WithMany("TbKoral")
                        .HasForeignKey("MakhdoumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Khedma.Entites.Models.TheStage", "TheStage")
                        .WithMany("TbKoral")
                        .HasForeignKey("StageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Makhdoum");

                    b.Navigation("TheStage");
                });

            modelBuilder.Entity("Khedma.Entites.Models.Makhdoum", b =>
                {
                    b.Navigation("TbKoral");
                });

            modelBuilder.Entity("Khedma.Entites.Models.TheStage", b =>
                {
                    b.Navigation("TbKoral");
                });
#pragma warning restore 612, 618
        }
    }
}