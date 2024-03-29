﻿// <auto-generated />
using System;
using Mangau.Demos.StockChat.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mangau.Demos.StockChat.Infrastructure.MySql.Migrations
{
    [DbContext(typeof(SCContext))]
    partial class SCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Mangau.Demos.StockChat.Entities.ChatMessage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasMaxLength(100000);

                    b.Property<long>("PostedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("PostedById");

                    b.ToTable("scchatmessage");
                });

            modelBuilder.Entity("Mangau.Demos.StockChat.Entities.Group", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("secgroup");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Active = true,
                            Description = "Everyone",
                            Name = "Everyone"
                        },
                        new
                        {
                            Id = 2L,
                            Active = true,
                            Description = "System Administrators",
                            Name = "Administrators"
                        },
                        new
                        {
                            Id = 3L,
                            Active = true,
                            Description = "System's Internal Users",
                            Name = "Internals"
                        },
                        new
                        {
                            Id = 4L,
                            Active = true,
                            Description = "Users for Testing",
                            Name = "TestUsers"
                        });
                });

            modelBuilder.Entity("Mangau.Demos.StockChat.Entities.GroupPermission", b =>
                {
                    b.Property<long>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<long>("PermissionId")
                        .HasColumnType("bigint");

                    b.HasKey("GroupId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("secgrouppermission");

                    b.HasData(
                        new
                        {
                            GroupId = 1L,
                            PermissionId = 1L
                        },
                        new
                        {
                            GroupId = 2L,
                            PermissionId = 1L
                        },
                        new
                        {
                            GroupId = 2L,
                            PermissionId = 2L
                        },
                        new
                        {
                            GroupId = 4L,
                            PermissionId = 1L
                        });
                });

            modelBuilder.Entity("Mangau.Demos.StockChat.Entities.GroupUser", b =>
                {
                    b.Property<long>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("GroupId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("secgroupuser");

                    b.HasData(
                        new
                        {
                            GroupId = 1L,
                            UserId = 1L
                        },
                        new
                        {
                            GroupId = 1L,
                            UserId = 2L
                        },
                        new
                        {
                            GroupId = 1L,
                            UserId = 3L
                        },
                        new
                        {
                            GroupId = 1L,
                            UserId = 4L
                        },
                        new
                        {
                            GroupId = 1L,
                            UserId = 5L
                        },
                        new
                        {
                            GroupId = 1L,
                            UserId = 6L
                        },
                        new
                        {
                            GroupId = 1L,
                            UserId = 7L
                        },
                        new
                        {
                            GroupId = 1L,
                            UserId = 8L
                        },
                        new
                        {
                            GroupId = 1L,
                            UserId = 9L
                        },
                        new
                        {
                            GroupId = 1L,
                            UserId = 10L
                        },
                        new
                        {
                            GroupId = 1L,
                            UserId = 11L
                        },
                        new
                        {
                            GroupId = 2L,
                            UserId = 1L
                        },
                        new
                        {
                            GroupId = 3L,
                            UserId = 12L
                        },
                        new
                        {
                            GroupId = 4L,
                            UserId = 2L
                        },
                        new
                        {
                            GroupId = 4L,
                            UserId = 3L
                        },
                        new
                        {
                            GroupId = 4L,
                            UserId = 4L
                        },
                        new
                        {
                            GroupId = 4L,
                            UserId = 5L
                        },
                        new
                        {
                            GroupId = 4L,
                            UserId = 6L
                        },
                        new
                        {
                            GroupId = 4L,
                            UserId = 7L
                        },
                        new
                        {
                            GroupId = 4L,
                            UserId = 8L
                        },
                        new
                        {
                            GroupId = 4L,
                            UserId = 9L
                        },
                        new
                        {
                            GroupId = 4L,
                            UserId = 10L
                        },
                        new
                        {
                            GroupId = 4L,
                            UserId = 11L
                        });
                });

            modelBuilder.Entity("Mangau.Demos.StockChat.Entities.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasMaxLength(64);

                    b.Property<long>("PermissionCategoryId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PermissionCategoryId");

                    b.ToTable("secpermission");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Active = false,
                            Description = "The user can Login in the System",
                            Name = "Users.Login",
                            PermissionCategoryId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Active = false,
                            Description = "The user can add other users to the System",
                            Name = "Users.AddUser",
                            PermissionCategoryId = 1L
                        });
                });

            modelBuilder.Entity("Mangau.Demos.StockChat.Entities.PermissionCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("secpermissioncategory");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Active = false,
                            Description = "User Management Permissions",
                            Name = "Users"
                        },
                        new
                        {
                            Id = 2L,
                            Active = false,
                            Description = "System Management Permissions",
                            Name = "System"
                        });
                });

            modelBuilder.Entity("Mangau.Demos.StockChat.Entities.SessionToken", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("LoggedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("secsessiontoken");
                });

            modelBuilder.Entity("Mangau.Demos.StockChat.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasMaxLength(128);

                    b.Property<bool>("Recover")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("FirstName");

                    b.HasIndex("LastName");

                    b.HasIndex("UserName");

                    b.ToTable("secuser");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Active = true,
                            FirstName = "System",
                            LastName = "Administrator",
                            Password = "$2y$10$nLgfDdhTjYdUH6wbEctoLe0Ua6yjzx8YCksWZ/aaVGLpAb0hmtddG",
                            Recover = false,
                            UserName = "administrator"
                        },
                        new
                        {
                            Id = 2L,
                            Active = true,
                            FirstName = "Test",
                            LastName = "01",
                            Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy",
                            Recover = false,
                            UserName = "test01"
                        },
                        new
                        {
                            Id = 3L,
                            Active = true,
                            FirstName = "Test",
                            LastName = "02",
                            Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy",
                            Recover = false,
                            UserName = "test02"
                        },
                        new
                        {
                            Id = 4L,
                            Active = true,
                            FirstName = "Test",
                            LastName = "03",
                            Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy",
                            Recover = false,
                            UserName = "test03"
                        },
                        new
                        {
                            Id = 5L,
                            Active = true,
                            FirstName = "Test",
                            LastName = "04",
                            Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy",
                            Recover = false,
                            UserName = "test04"
                        },
                        new
                        {
                            Id = 6L,
                            Active = true,
                            FirstName = "Test",
                            LastName = "05",
                            Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy",
                            Recover = false,
                            UserName = "test05"
                        },
                        new
                        {
                            Id = 7L,
                            Active = true,
                            FirstName = "Test",
                            LastName = "06",
                            Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy",
                            Recover = false,
                            UserName = "test06"
                        },
                        new
                        {
                            Id = 8L,
                            Active = true,
                            FirstName = "Test",
                            LastName = "07",
                            Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy",
                            Recover = false,
                            UserName = "test07"
                        },
                        new
                        {
                            Id = 9L,
                            Active = true,
                            FirstName = "Test",
                            LastName = "08",
                            Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy",
                            Recover = false,
                            UserName = "test08"
                        },
                        new
                        {
                            Id = 10L,
                            Active = true,
                            FirstName = "Test",
                            LastName = "09",
                            Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy",
                            Recover = false,
                            UserName = "test09"
                        },
                        new
                        {
                            Id = 11L,
                            Active = true,
                            FirstName = "Test",
                            LastName = "10",
                            Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy",
                            Recover = false,
                            UserName = "test10"
                        },
                        new
                        {
                            Id = 12L,
                            Active = true,
                            FirstName = "Chat",
                            LastName = "Bot",
                            Password = "",
                            Recover = false,
                            UserName = "chatbot"
                        });
                });

            modelBuilder.Entity("Mangau.Demos.StockChat.Entities.ChatMessage", b =>
                {
                    b.HasOne("Mangau.Demos.StockChat.Entities.User", "PostedBy")
                        .WithMany("Messages")
                        .HasForeignKey("PostedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mangau.Demos.StockChat.Entities.GroupPermission", b =>
                {
                    b.HasOne("Mangau.Demos.StockChat.Entities.Group", "Group")
                        .WithMany("GroupsPermissions")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mangau.Demos.StockChat.Entities.Permission", "Permission")
                        .WithMany("GroupsPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mangau.Demos.StockChat.Entities.GroupUser", b =>
                {
                    b.HasOne("Mangau.Demos.StockChat.Entities.Group", "Group")
                        .WithMany("GroupsUsers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mangau.Demos.StockChat.Entities.User", "User")
                        .WithMany("GroupsUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mangau.Demos.StockChat.Entities.Permission", b =>
                {
                    b.HasOne("Mangau.Demos.StockChat.Entities.PermissionCategory", "PermissionCategory")
                        .WithMany("Permissions")
                        .HasForeignKey("PermissionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mangau.Demos.StockChat.Entities.SessionToken", b =>
                {
                    b.HasOne("Mangau.Demos.StockChat.Entities.User", "User")
                        .WithMany("SessionTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
