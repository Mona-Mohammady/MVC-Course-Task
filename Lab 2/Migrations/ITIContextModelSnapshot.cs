﻿// <auto-generated />
using System;
using Lab_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab_2.Migrations
{
    [DbContext(typeof(ITIContext))]
    partial class ITIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab_2.Models.Course", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("crs_id")
                        .HasColumnType("int");

                    b.Property<int?>("dept_id")
                        .HasColumnType("int");

                    b.Property<int?>("ins_id")
                        .HasColumnType("int");

                    b.Property<int>("minDegree")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("dept_id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Lab_2.Models.Department", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("crs_id")
                        .HasColumnType("int");

                    b.Property<int?>("ins_id")
                        .HasColumnType("int");

                    b.Property<int?>("trainee_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("crs_id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Lab_2.Models.Instructor", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<int?>("crs_id")
                        .HasColumnType("int");

                    b.Property<int?>("dept_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("crs_id");

                    b.HasIndex("dept_id");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("Lab_2.Models.Trainee", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("crs_id")
                        .HasColumnType("int");

                    b.Property<int?>("dept_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("dept_id");

                    b.ToTable("Trainee");
                });

            modelBuilder.Entity("Lab_2.Models.crsResult", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int?>("crs_id")
                        .HasColumnType("int");

                    b.Property<int?>("trainee_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("crs_id");

                    b.HasIndex("trainee_id");

                    b.ToTable("CourseResult");
                });

            modelBuilder.Entity("Lab_2.Models.Course", b =>
                {
                    b.HasOne("Lab_2.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("dept_id");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Lab_2.Models.Department", b =>
                {
                    b.HasOne("Lab_2.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("crs_id");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Lab_2.Models.Instructor", b =>
                {
                    b.HasOne("Lab_2.Models.Course", "Course")
                        .WithMany("Instructors")
                        .HasForeignKey("crs_id");

                    b.HasOne("Lab_2.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("dept_id");

                    b.Navigation("Course");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Lab_2.Models.Trainee", b =>
                {
                    b.HasOne("Lab_2.Models.Department", "Department")
                        .WithMany("Trainees")
                        .HasForeignKey("dept_id");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Lab_2.Models.crsResult", b =>
                {
                    b.HasOne("Lab_2.Models.Course", "Course")
                        .WithMany("CourseResults")
                        .HasForeignKey("crs_id");

                    b.HasOne("Lab_2.Models.Trainee", "Trainee")
                        .WithMany("CourseResults")
                        .HasForeignKey("trainee_id");

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("Lab_2.Models.Course", b =>
                {
                    b.Navigation("CourseResults");

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("Lab_2.Models.Department", b =>
                {
                    b.Navigation("Instructors");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("Lab_2.Models.Trainee", b =>
                {
                    b.Navigation("CourseResults");
                });
#pragma warning restore 612, 618
        }
    }
}
