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
    [Migration("20241123201517_editInArtTable23")]
    partial class editInArtTable23
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Khedma.Entites.Models.Alhan", b =>
                {
                    b.Property<int>("MakhdoumID")
                        .HasColumnType("int");

                    b.Property<int>("StageID")
                        .HasColumnType("int");

                    b.HasKey("MakhdoumID", "StageID");

                    b.HasIndex("StageID");

                    b.ToTable("Alhan");
                });

            modelBuilder.Entity("Khedma.Entites.Models.Arts", b =>
                {
                    b.Property<int>("MakhdoumID")
                        .HasColumnType("int");

                    b.Property<int>("StageID")
                        .HasColumnType("int");

                    b.Property<int>("ArtID")
                        .HasColumnType("int");

                    b.Property<int>("InGroup")
                        .HasColumnType("int");

                    b.HasKey("MakhdoumID", "StageID", "ArtID", "InGroup");

                    b.HasIndex("ArtID");

                    b.HasIndex("StageID");

                    b.ToTable("Arts");
                });

            modelBuilder.Entity("Khedma.Entites.Models.ArtsName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("TBArtsName");
                });

            modelBuilder.Entity("Khedma.Entites.Models.BooksAndSaves", b =>
                {
                    b.Property<int>("MakhdoumID")
                        .HasColumnType("int");

                    b.Property<int>("StageID")
                        .HasColumnType("int");

                    b.HasKey("MakhdoumID", "StageID");

                    b.HasIndex("StageID");

                    b.ToTable("BooksAndSaves");
                });

            modelBuilder.Entity("Khedma.Entites.Models.Coptic", b =>
                {
                    b.Property<int>("MakhdoumID")
                        .HasColumnType("int");

                    b.Property<int>("StageID")
                        .HasColumnType("int");

                    b.HasKey("MakhdoumID", "StageID");

                    b.HasIndex("StageID");

                    b.ToTable("Coptic");
                });

            modelBuilder.Entity("Khedma.Entites.Models.ForSingle", b =>
                {
                    b.Property<int>("MakhdoumID")
                        .HasColumnType("int");

                    b.Property<int>("StageID")
                        .HasColumnType("int");

                    b.HasKey("MakhdoumID", "StageID");

                    b.HasIndex("StageID");

                    b.ToTable("ForSingle");
                });

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

            modelBuilder.Entity("Khedma.Entites.Models.Learning", b =>
                {
                    b.Property<int>("MakhdoumID")
                        .HasColumnType("int");

                    b.Property<int>("StageID")
                        .HasColumnType("int");

                    b.HasKey("MakhdoumID", "StageID");

                    b.HasIndex("StageID");

                    b.ToTable("Learning");
                });

            modelBuilder.Entity("Khedma.Entites.Models.Makhdoum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateOfBirth")
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

            modelBuilder.Entity("Khedma.Entites.Models.Theater", b =>
                {
                    b.Property<int>("MakhdoumID")
                        .HasColumnType("int");

                    b.Property<int>("StageID")
                        .HasColumnType("int");

                    b.HasKey("MakhdoumID", "StageID");

                    b.HasIndex("StageID");

                    b.ToTable("Theater");
                });

            modelBuilder.Entity("Khedma.Entites.Models.Alhan", b =>
                {
                    b.HasOne("Khedma.Entites.Models.Makhdoum", "Makhdoum")
                        .WithMany("TbAlhan")
                        .HasForeignKey("MakhdoumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Khedma.Entites.Models.TheStage", "TheStage")
                        .WithMany("TbAlhan")
                        .HasForeignKey("StageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Makhdoum");

                    b.Navigation("TheStage");
                });

            modelBuilder.Entity("Khedma.Entites.Models.Arts", b =>
                {
                    b.HasOne("Khedma.Entites.Models.ArtsName", "ArtsName")
                        .WithMany("TBArts")
                        .HasForeignKey("ArtID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Khedma.Entites.Models.Makhdoum", "Makhdoum")
                        .WithMany("TBArts")
                        .HasForeignKey("MakhdoumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Khedma.Entites.Models.TheStage", "TheStage")
                        .WithMany("TBArts")
                        .HasForeignKey("StageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArtsName");

                    b.Navigation("Makhdoum");

                    b.Navigation("TheStage");
                });

            modelBuilder.Entity("Khedma.Entites.Models.BooksAndSaves", b =>
                {
                    b.HasOne("Khedma.Entites.Models.Makhdoum", "Makhdoum")
                        .WithMany("TBBooksAndSaves")
                        .HasForeignKey("MakhdoumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Khedma.Entites.Models.TheStage", "TheStage")
                        .WithMany("TBBooksAndSaves")
                        .HasForeignKey("StageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Makhdoum");

                    b.Navigation("TheStage");
                });

            modelBuilder.Entity("Khedma.Entites.Models.Coptic", b =>
                {
                    b.HasOne("Khedma.Entites.Models.Makhdoum", "Makhdoum")
                        .WithMany("TBCoptic")
                        .HasForeignKey("MakhdoumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Khedma.Entites.Models.TheStage", "TheStage")
                        .WithMany("TBCoptic")
                        .HasForeignKey("StageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Makhdoum");

                    b.Navigation("TheStage");
                });

            modelBuilder.Entity("Khedma.Entites.Models.ForSingle", b =>
                {
                    b.HasOne("Khedma.Entites.Models.Makhdoum", "Makhdoum")
                        .WithMany("TBForSingle")
                        .HasForeignKey("MakhdoumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Khedma.Entites.Models.TheStage", "TheStage")
                        .WithMany("TBForSingle")
                        .HasForeignKey("StageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Makhdoum");

                    b.Navigation("TheStage");
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

            modelBuilder.Entity("Khedma.Entites.Models.Learning", b =>
                {
                    b.HasOne("Khedma.Entites.Models.Makhdoum", "Makhdoum")
                        .WithMany("TBLearning")
                        .HasForeignKey("MakhdoumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Khedma.Entites.Models.TheStage", "TheStage")
                        .WithMany("TBLearning")
                        .HasForeignKey("StageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Makhdoum");

                    b.Navigation("TheStage");
                });

            modelBuilder.Entity("Khedma.Entites.Models.Theater", b =>
                {
                    b.HasOne("Khedma.Entites.Models.Makhdoum", "Makhdoum")
                        .WithMany("TBTheater")
                        .HasForeignKey("MakhdoumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Khedma.Entites.Models.TheStage", "TheStage")
                        .WithMany("TBTheater")
                        .HasForeignKey("StageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Makhdoum");

                    b.Navigation("TheStage");
                });

            modelBuilder.Entity("Khedma.Entites.Models.ArtsName", b =>
                {
                    b.Navigation("TBArts");
                });

            modelBuilder.Entity("Khedma.Entites.Models.Makhdoum", b =>
                {
                    b.Navigation("TBArts");

                    b.Navigation("TBBooksAndSaves");

                    b.Navigation("TBCoptic");

                    b.Navigation("TBForSingle");

                    b.Navigation("TBLearning");

                    b.Navigation("TBTheater");

                    b.Navigation("TbAlhan");

                    b.Navigation("TbKoral");
                });

            modelBuilder.Entity("Khedma.Entites.Models.TheStage", b =>
                {
                    b.Navigation("TBArts");

                    b.Navigation("TBBooksAndSaves");

                    b.Navigation("TBCoptic");

                    b.Navigation("TBForSingle");

                    b.Navigation("TBLearning");

                    b.Navigation("TBTheater");

                    b.Navigation("TbAlhan");

                    b.Navigation("TbKoral");
                });
#pragma warning restore 612, 618
        }
    }
}
