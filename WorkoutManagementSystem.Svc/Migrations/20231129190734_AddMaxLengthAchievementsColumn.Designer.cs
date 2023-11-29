﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WorkoutManagementSystem.Svc.Infrastracture;

#nullable disable

namespace WorkoutManagementSystem.Svc.Migrations
{
    [DbContext(typeof(WorkoutManagementSystemContext))]
    [Migration("20231129190734_AddMaxLengthAchievementsColumn")]
    partial class AddMaxLengthAchievementsColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ExerciseGymEquipment", b =>
                {
                    b.Property<long>("ExercisesId")
                        .HasColumnType("bigint");

                    b.Property<long>("GymEquipmentId")
                        .HasColumnType("bigint");

                    b.HasKey("ExercisesId", "GymEquipmentId");

                    b.HasIndex("GymEquipmentId");

                    b.ToTable("ExerciseGymEquipment");
                });

            modelBuilder.Entity("WorkoutManagementSystem.Svc.Infrastracture.Entities.Exercise", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("WorkoutId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutId");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("WorkoutManagementSystem.Svc.Infrastracture.Entities.GymEquipment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GymEquipment");
                });

            modelBuilder.Entity("WorkoutManagementSystem.Svc.Infrastracture.Entities.StarParticipants", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Achievements")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("WorkoutId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutId")
                        .IsUnique();

                    b.ToTable("StarParticipants");
                });

            modelBuilder.Entity("WorkoutManagementSystem.Svc.Infrastracture.Entities.Workout", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("ExerciseGymEquipment", b =>
                {
                    b.HasOne("WorkoutManagementSystem.Svc.Infrastracture.Entities.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExercisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkoutManagementSystem.Svc.Infrastracture.Entities.GymEquipment", null)
                        .WithMany()
                        .HasForeignKey("GymEquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkoutManagementSystem.Svc.Infrastracture.Entities.Exercise", b =>
                {
                    b.HasOne("WorkoutManagementSystem.Svc.Infrastracture.Entities.Workout", null)
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkoutManagementSystem.Svc.Infrastracture.Entities.StarParticipants", b =>
                {
                    b.HasOne("WorkoutManagementSystem.Svc.Infrastracture.Entities.Workout", null)
                        .WithOne("StarParticipants")
                        .HasForeignKey("WorkoutManagementSystem.Svc.Infrastracture.Entities.StarParticipants", "WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkoutManagementSystem.Svc.Infrastracture.Entities.Workout", b =>
                {
                    b.Navigation("Exercises");

                    b.Navigation("StarParticipants");
                });
#pragma warning restore 612, 618
        }
    }
}
