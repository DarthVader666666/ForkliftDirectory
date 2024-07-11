﻿// <auto-generated />
using System;
using ForkliftDirectory.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ForkliftDirectory.Server.Migrations
{
    [DbContext(typeof(ForkliftDirectoryDbContext))]
    partial class ForkliftDirectoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ForkliftDirectory.Server.Entities.Forklift", b =>
                {
                    b.Property<int?>("ForkliftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("ForkliftId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int?>("LiftCapacity")
                        .HasColumnType("integer");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("ForkliftId");

                    b.HasIndex("UserId");

                    b.ToTable("Forklifts");
                });

            modelBuilder.Entity("ForkliftDirectory.Server.Entities.Malfunction", b =>
                {
                    b.Property<int?>("MalfunctionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("MalfunctionId"));

                    b.Property<string>("Describtion")
                        .HasColumnType("text");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ForkliftId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TimeSpan")
                        .HasColumnType("text");

                    b.HasKey("MalfunctionId");

                    b.HasIndex("ForkliftId");

                    b.ToTable("Malfunctions");
                });

            modelBuilder.Entity("ForkliftDirectory.Server.Entities.User", b =>
                {
                    b.Property<int?>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("UserId"));

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ForkliftDirectory.Server.Entities.Forklift", b =>
                {
                    b.HasOne("ForkliftDirectory.Server.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ForkliftDirectory.Server.Entities.Malfunction", b =>
                {
                    b.HasOne("ForkliftDirectory.Server.Entities.Forklift", "Forklift")
                        .WithMany("Malfunctions")
                        .HasForeignKey("ForkliftId");

                    b.Navigation("Forklift");
                });

            modelBuilder.Entity("ForkliftDirectory.Server.Entities.Forklift", b =>
                {
                    b.Navigation("Malfunctions");
                });
#pragma warning restore 612, 618
        }
    }
}
