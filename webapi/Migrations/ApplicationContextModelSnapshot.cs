﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapi.Data;

#nullable disable

namespace webapi.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("webapi.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("char(20)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Demo Organization"
                        });
                });

            modelBuilder.Entity("webapi.Models.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int?>("ShiftPositionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("ShiftPositionId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("webapi.Models.ShiftPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(275)
                        .HasColumnType("varchar(275)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("ShiftPositions");
                });

            modelBuilder.Entity("webapi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailIsConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<string>("OrganizationRole")
                        .IsRequired()
                        .HasColumnType("ENUM('Crew','Manager','Administrator')");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "JohnAdmin@demo.com",
                            EmailIsConfirmed = true,
                            Nickname = "John Admin",
                            OrganizationId = 1,
                            OrganizationRole = "Administrator",
                            PasswordHash = "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==",
                            PasswordSalt = "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=",
                            UserName = "DemoAdmin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "AmyManager@demo.com",
                            EmailIsConfirmed = true,
                            Nickname = "Amy Manager",
                            OrganizationId = 1,
                            OrganizationRole = "Manager",
                            PasswordHash = "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==",
                            PasswordSalt = "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=",
                            UserName = "DemoManager1"
                        },
                        new
                        {
                            Id = 3,
                            Email = "AdamManager@demo.com",
                            EmailIsConfirmed = true,
                            Nickname = "Adam Manager",
                            OrganizationId = 1,
                            OrganizationRole = "Manager",
                            PasswordHash = "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==",
                            PasswordSalt = "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=",
                            UserName = "DemoManager2"
                        },
                        new
                        {
                            Id = 4,
                            Email = "GeorgeCrew@demo.com",
                            EmailIsConfirmed = true,
                            Nickname = "George Crew",
                            OrganizationId = 1,
                            OrganizationRole = "Crew",
                            PasswordHash = "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==",
                            PasswordSalt = "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=",
                            UserName = "DemoCrew1"
                        },
                        new
                        {
                            Id = 5,
                            Email = "JamieCrew@demo.com",
                            EmailIsConfirmed = true,
                            Nickname = "Jamie Crew",
                            OrganizationId = 1,
                            OrganizationRole = "Crew",
                            PasswordHash = "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==",
                            PasswordSalt = "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=",
                            UserName = "DemoCrew2"
                        },
                        new
                        {
                            Id = 6,
                            Email = "RebeccaCrew@demo.com",
                            EmailIsConfirmed = true,
                            Nickname = "Rebecca Crew",
                            OrganizationId = 1,
                            OrganizationRole = "Crew",
                            PasswordHash = "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==",
                            PasswordSalt = "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=",
                            UserName = "DemoCrew3"
                        });
                });

            modelBuilder.Entity("webapi.Models.UserConfirmationKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserConfirmationKeys");
                });

            modelBuilder.Entity("webapi.Models.UserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("webapi.Models.Shift", b =>
                {
                    b.HasOne("webapi.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.ShiftPosition", "ShiftPosition")
                        .WithMany()
                        .HasForeignKey("ShiftPositionId");

                    b.HasOne("webapi.Models.User", "Worker")
                        .WithMany("Shifts")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("ShiftPosition");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("webapi.Models.ShiftPosition", b =>
                {
                    b.HasOne("webapi.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("webapi.Models.User", b =>
                {
                    b.HasOne("webapi.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("webapi.Models.UserConfirmationKey", b =>
                {
                    b.HasOne("webapi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("webapi.Models.UserToken", b =>
                {
                    b.HasOne("webapi.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("User");
                });

            modelBuilder.Entity("webapi.Models.User", b =>
                {
                    b.Navigation("Shifts");
                });
#pragma warning restore 612, 618
        }
    }
}
