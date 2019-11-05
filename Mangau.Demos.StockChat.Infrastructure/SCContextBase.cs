using Mangau.Demos.StockChat.Configuration;
using Mangau.Demos.StockChat.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mangau.Demos.StockChat.Infrastructure
{
    public abstract class SCContextBase : DbContext
    {
        protected AppSettings AppSettings { get; private set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<GroupUser> GroupsUsers { get; set; }

        public DbSet<PermissionCategory> PermissionCategories { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<GroupPermission> GroupsPermissions { get; set; }

        public DbSet<SessionToken> SessionTokens { get; set; }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        public SCContextBase(AppSettings appSettings) : base()
        {
            AppSettings = appSettings;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userMB = modelBuilder.Entity<User>();
            userMB
                .Property(u => u.Active)
                .HasDefaultValue(false);
            userMB
                .Property(u => u.Recover)
                .HasDefaultValue(false);
            userMB
                .HasIndex(u => u.UserName)
                .IsUnique(false);
            userMB
                .HasIndex(u => u.FirstName)
                .IsUnique(false);
            userMB
                .HasIndex(u => u.LastName)
                .IsUnique(false);
            userMB
                .HasData(
                    new User { Id = 1, Active = true, UserName = "administrator", Password = "$2y$10$nLgfDdhTjYdUH6wbEctoLe0Ua6yjzx8YCksWZ/aaVGLpAb0hmtddG", FirstName = "System", LastName = "Administrator" },
                    new User { Id = 2, Active = true, UserName = "test01", Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", FirstName = "Test", LastName = "01" },
                    new User { Id = 3, Active = true, UserName = "test02", Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", FirstName = "Test", LastName = "02" },
                    new User { Id = 4, Active = true, UserName = "test03", Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", FirstName = "Test", LastName = "03" },
                    new User { Id = 5, Active = true, UserName = "test04", Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", FirstName = "Test", LastName = "04" },
                    new User { Id = 6, Active = true, UserName = "test05", Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", FirstName = "Test", LastName = "05" },
                    new User { Id = 7, Active = true, UserName = "test06", Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", FirstName = "Test", LastName = "06" },
                    new User { Id = 8, Active = true, UserName = "test07", Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", FirstName = "Test", LastName = "07" },
                    new User { Id = 9, Active = true, UserName = "test08", Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", FirstName = "Test", LastName = "08" },
                    new User { Id = 10, Active = true, UserName = "test09", Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", FirstName = "Test", LastName = "09" },
                    new User { Id = 11, Active = true, UserName = "test10", Password = "$2y$12$NisvmmSjik8b3FMY8Muhb.tvuW/FDQyMhvM879rRVaaBSXajktHYy", FirstName = "Test", LastName = "10" },
                    new User { Id = 12, Active = true, UserName = "chatbot", Password = "", FirstName = "Chat", LastName = "Bot" }
                    );

            var groupMB = modelBuilder.Entity<Group>();
            groupMB
                .Property(u => u.Active)
                .HasDefaultValue(true);
            groupMB
                .HasIndex(u => u.Name)
                .IsUnique(true);
            groupMB
                .HasData(
                    new Group { Id = 1, Active = true, Name = "Everyone", Description = "Everyone" },
                    new Group { Id = 2, Active = true, Name = "Administrators", Description = "System Administrators" },
                    new Group { Id = 3, Active = true, Name = "Internals", Description = "System's Internal Users" },
                    new Group { Id = 4, Active = true, Name = "TestUsers", Description = "Users for Testing" }
                );

            var groupsUsersMB = modelBuilder.Entity<GroupUser>();
            groupsUsersMB
                .HasKey(gu => new { gu.GroupId, gu.UserId });
            groupsUsersMB
                .HasOne(gu => gu.Group)
                .WithMany(g => g.GroupsUsers)
                .HasForeignKey(g => g.GroupId);
            groupsUsersMB
                .HasOne(gu => gu.User)
                .WithMany(g => g.GroupsUsers)
                .HasForeignKey(g => g.UserId);
            groupsUsersMB
                .HasData(
                    new GroupUser { GroupId = 1, UserId = 1 }, // Everyone - administrator
                    new GroupUser { GroupId = 1, UserId = 2 }, // Everyone - test01
                    new GroupUser { GroupId = 1, UserId = 3 }, // Everyone - test02
                    new GroupUser { GroupId = 1, UserId = 4 }, // Everyone - test03
                    new GroupUser { GroupId = 1, UserId = 5 }, // Everyone - test04
                    new GroupUser { GroupId = 1, UserId = 6 }, // Everyone - test05
                    new GroupUser { GroupId = 1, UserId = 7 }, // Everyone - test06
                    new GroupUser { GroupId = 1, UserId = 8 }, // Everyone - test07
                    new GroupUser { GroupId = 1, UserId = 9 }, // Everyone - test08
                    new GroupUser { GroupId = 1, UserId = 10 }, // Everyone - test09
                    new GroupUser { GroupId = 1, UserId = 11 }, // Everyone - test10
                    new GroupUser { GroupId = 2, UserId = 1 }, // Administrators - administrator
                    new GroupUser { GroupId = 3, UserId = 12 }, // Internals - chatbot
                    new GroupUser { GroupId = 4, UserId = 2 }, // TestUsers - test01
                    new GroupUser { GroupId = 4, UserId = 3 }, // TestUsers - test02
                    new GroupUser { GroupId = 4, UserId = 4 }, // TestUsers - test03
                    new GroupUser { GroupId = 4, UserId = 5 }, // TestUsers - test04
                    new GroupUser { GroupId = 4, UserId = 6 }, // TestUsers - test05
                    new GroupUser { GroupId = 4, UserId = 7 }, // TestUsers - test06
                    new GroupUser { GroupId = 4, UserId = 8 }, // TestUsers - test07
                    new GroupUser { GroupId = 4, UserId = 9 }, // TestUsers - test08
                    new GroupUser { GroupId = 4, UserId = 10 }, // TestUsers - test09
                    new GroupUser { GroupId = 4, UserId = 11 } // TestUsers - test10
                );

            var percatMB = modelBuilder.Entity<PermissionCategory>();
            percatMB
                .Property(u => u.Active)
                .HasDefaultValue(true);
            percatMB
                .HasIndex(u => u.Name)
                .IsUnique(true);
            percatMB
                .HasData(
                    new PermissionCategory { Id = 1, Name = "Users", Description = "User Management Permissions" },
                    new PermissionCategory { Id = 2, Name = "System", Description = "System Management Permissions" }
                );

            var perMB = modelBuilder.Entity<Permission>();
            perMB
                .Property(u => u.Active)
                .HasDefaultValue(true);
            perMB
                .HasIndex(u => u.Name)
                .IsUnique(true);
            perMB
                .HasOne(p => p.PermissionCategory)
                .WithMany(pc => pc.Permissions)
                .HasForeignKey(p => p.PermissionCategoryId);
            perMB
                .HasData(
                    new Permission { Id = 1, Name = "Users.Login", Description = "The user can Login in the System", PermissionCategoryId = 1 },
                    new Permission { Id = 2, Name = "Users.AddUser", Description = "The user can add other users to the System", PermissionCategoryId = 1 }
                );

            var groupsPersMB = modelBuilder.Entity<GroupPermission>();
            groupsPersMB
                .HasKey(gp => new { gp.GroupId, gp.PermissionId });
            groupsPersMB
                .HasOne(gp => gp.Group)
                .WithMany(g => g.GroupsPermissions)
                .HasForeignKey(g => g.GroupId);
            groupsPersMB
                .HasOne(gp => gp.Permission)
                .WithMany(g => g.GroupsPermissions)
                .HasForeignKey(g => g.PermissionId);
            groupsPersMB
                .HasData(
                    new GroupPermission { GroupId = 1, PermissionId = 1 },
                    new GroupPermission { GroupId = 2, PermissionId = 1 },
                    new GroupPermission { GroupId = 2, PermissionId = 2 },
                    new GroupPermission { GroupId = 4, PermissionId = 1 }
                );

            var sessionTokenMB = modelBuilder.Entity<SessionToken>();
            sessionTokenMB
                .HasOne(st => st.User)
                .WithMany(u => u.SessionTokens)
                .HasForeignKey(u => u.UserId);

            var chatMessageMB = modelBuilder.Entity<ChatMessage>();
            chatMessageMB
                .HasOne(st => st.PostedBy)
                .WithMany(u => u.Messages)
                .HasForeignKey(u => u.PostedById);
        }
    }
}
