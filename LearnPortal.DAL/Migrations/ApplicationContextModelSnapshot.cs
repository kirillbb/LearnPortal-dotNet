﻿// <auto-generated />
using System;
using LearnPortal.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LearnPortal.DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LearnPortal.DAL.Entities.Course.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("LearnPortal.DAL.Entities.Course.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("LearnPortal.DAL.Entities.Material.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Materials");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Material");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("LearnPortal.DAL.Entities.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LearnPortal.DAL.Entities.Material.Book", b =>
                {
                    b.HasBaseType("LearnPortal.DAL.Entities.Material.Material");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookFormat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Book");
                });

            modelBuilder.Entity("LearnPortal.DAL.Entities.Material.Publication", b =>
                {
                    b.HasBaseType("LearnPortal.DAL.Entities.Material.Material");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Publication");
                });

            modelBuilder.Entity("LearnPortal.DAL.Entities.Material.Video", b =>
                {
                    b.HasBaseType("LearnPortal.DAL.Entities.Material.Material");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("Resolution")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Video");
                });

            modelBuilder.Entity("LearnPortal.DAL.Entities.Course.Course", b =>
                {
                    b.HasOne("LearnPortal.DAL.Entities.User.User", null)
                        .WithMany("FinishedCourses")
                        .HasForeignKey("UserId");

                    b.HasOne("LearnPortal.DAL.Entities.User.User", null)
                        .WithMany("InProgressCourses")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("LearnPortal.DAL.Entities.Course.Skill", b =>
                {
                    b.HasOne("LearnPortal.DAL.Entities.Course.Course", null)
                        .WithMany("Skills")
                        .HasForeignKey("CourseId");

                    b.HasOne("LearnPortal.DAL.Entities.User.User", null)
                        .WithMany("Skills")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("LearnPortal.DAL.Entities.Material.Material", b =>
                {
                    b.HasOne("LearnPortal.DAL.Entities.Course.Course", null)
                        .WithMany("Materials")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("LearnPortal.DAL.Entities.Course.Course", b =>
                {
                    b.Navigation("Materials");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("LearnPortal.DAL.Entities.User.User", b =>
                {
                    b.Navigation("FinishedCourses");

                    b.Navigation("InProgressCourses");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
