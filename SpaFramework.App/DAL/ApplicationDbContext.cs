using SpaFramework.App.Models.Data.Accounts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SpaFramework.App.Models.Data;
using SpaFramework.App.Models.Data.Content;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using SpaFramework.App.Models.Data.Donors;
using SpaFramework.App.Models;
using SpaFramework.Core.Models;
using Newtonsoft.Json;
using SpaFramework.App.Models.Data.Jobs;
using SpaFramework.App.Models.Data.Clients;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;
using Microsoft.Extensions.Configuration;
using SpaFramework.Core.Utilities;

namespace SpaFramework.App.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, IdentityUserClaim<Guid>, ApplicationUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        private readonly IEncryptionProvider _encryptionProvider;
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ExternalCredential> ExternalCredentials { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public DbSet<ContentBlock> ContentBlocks { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ClientStats> ClientStats { get; set; }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobItem> JobItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            string hexEncryptionKey = configuration.GetValue<string>("EncryptionKey");
            string hexEncryptionIV = configuration.GetValue<string>("EncryptionIV");

            byte[] encryptionKey = EncryptionUtilities.StringToByteArray(hexEncryptionKey);
            byte[] encryptionIV = EncryptionUtilities.StringToByteArray(hexEncryptionIV);

            _encryptionProvider = new AesProvider(encryptionKey, encryptionIV);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseEncryption(_encryptionProvider);

            /* Accounts */

            modelBuilder.Entity<ExternalCredential>()
                .HasOne(x => x.ApplicationUser)
                .WithMany(x => x.ExternalCredentials)
                .HasForeignKey(x => x.ApplicationUserId);

            modelBuilder.Entity<IdentityUserRole<long>>()
                .HasKey(x => new { x.UserId, x.RoleId });

            modelBuilder.Entity<ApplicationUserRole>()
                .HasIndex(x => x.Id)
                .IsUnique();

            modelBuilder.Entity<ApplicationUserRole>()
                .HasOne(x => x.ApplicationRole)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .IsRequired();

            modelBuilder.Entity<ApplicationUserRole>()
                .HasOne(x => x.ApplicationUser)
                .WithMany(x => x.Roles)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            /* Content */

            modelBuilder.Entity<ContentBlock>()
                .ToTable("ContentBlocks", b => b.IsTemporal());

            modelBuilder.Entity<ContentBlock>()
                .HasIndex(x => x.Slug)
                .IsUnique(false);

            modelBuilder.Entity<ContentBlock>()
                .Property(x => x.AllowedTokens)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<AllowedToken>>(v)
                );

            /* Clients */

            modelBuilder.Entity<Client>()
                .ToTable("Clients", b => b.IsTemporal());

            modelBuilder.Entity<Project>()
                .ToTable("Projects", b => b.IsTemporal());

            modelBuilder.Entity<Client>()
                .HasIndex(x => x.Abbreviation);

            modelBuilder.Entity<Project>()
                .HasOne(x => x.Client)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.ClientId);

            modelBuilder.Entity<ClientStats>()
                .ToView("ClientStats")
                .HasKey(x => x.ClientId);

            modelBuilder.Entity<ClientStats>()
                .HasOne(x => x.Client)
                .WithOne(x => x.ClientStats)
                .HasForeignKey<ClientStats>(x => x.ClientId);

            /* Jobs */

            modelBuilder.Entity<Job>()
                .ToTable("Jobs", b => b.IsTemporal());

            modelBuilder.Entity<JobItem>()
                .ToTable("JobItems", b => b.IsTemporal());

            modelBuilder.Entity<JobItem>()
                .HasOne(x => x.Job)
                .WithMany(x => x.JobItems)
                .HasForeignKey(x => x.JobId);

            modelBuilder.Entity<Job>()
                .HasIndex(x => x.Created);

            /* Seed Data */

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            SeedRoles(modelBuilder);
            SeedUsers(modelBuilder);
            SeedContent(modelBuilder);
            SeedAppData(modelBuilder);
        }

        private static class RoleIds
        {
            public static Guid SuperAdmin = Guid.Parse("9770d744-5c62-4d76-a4ef-163f94b33dad");
            public static Guid ProjectManager = Guid.Parse("558669b9-49a9-4520-90b8-51ba5b12c33e");
            public static Guid ProjectViewer = Guid.Parse("b67f4c23-5886-41ee-bbbb-6ae377f8f2ad");
            public static Guid ContentManager = Guid.Parse("18b6e930-29db-4c03-88e9-840adf59f2f7");
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole()
            {
                Id = RoleIds.SuperAdmin,
                Name = ApplicationRoleNames.SuperAdmin,
                NormalizedName = ApplicationRoleNames.SuperAdmin
            });

            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole()
            {
                Id = RoleIds.ProjectManager,
                Name = ApplicationRoleNames.ProjectManager,
                NormalizedName = ApplicationRoleNames.ProjectManager
            });

            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole()
            {
                Id = RoleIds.ProjectViewer,
                Name = ApplicationRoleNames.ProjectViewer,
                NormalizedName = ApplicationRoleNames.ProjectViewer
            });

            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole()
            {
                Id = RoleIds.ContentManager,
                Name = ApplicationRoleNames.ContentManager,
                NormalizedName = ApplicationRoleNames.ContentManager
            });
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var id0 = Guid.Parse("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be");
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = id0,
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                Email = "admin@test.com",
                NormalizedEmail = "admin@test.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = passwordHasher.HashPassword(null, "abcd1234"),
                SecurityStamp = string.Empty,
                FirstName = "Admin",
                LastName = "Admin"
            });

            foreach (Guid userId in new Guid[] { id0 })
            {
                foreach (Guid roleId in new Guid[] { RoleIds.SuperAdmin, RoleIds.ProjectManager, RoleIds.ProjectViewer, RoleIds.ContentManager })
                {
                    modelBuilder.Entity<ApplicationUserRole>().HasData(new ApplicationUserRole()
                    {
                        Id = Guid.NewGuid(),
                        RoleId = roleId,
                        UserId = userId
                    });
                }
            }

        }

        private void SeedContent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentBlock>().HasData(new ContentBlock()
            {
                Id = Guid.NewGuid(),
                Slug = "password-reset-email",
                IsPage = false,
                Description = "The text that appears in a password reset message",
                Title = "Reset Your Password",
                Value = @"To reset your account, follow this link: %passwordResetUrl%",
                AllowedTokens = new List<AllowedToken>()
                {
                    new AllowedToken()
                    {
                        Token = "passwordResetUrl",
                        Description = "The URL for the user to reset their password"
                    }
                }
            });

            modelBuilder.Entity<ContentBlock>().HasData(new ContentBlock()
            {
                Id = Guid.NewGuid(),
                Slug = "about",
                IsPage = true,
                Description = "The text that appears on the About page",
                Title = "About Us",
                Value = "About us..."
            });

            modelBuilder.Entity<ContentBlock>().HasData(new ContentBlock()
            {
                Id = Guid.NewGuid(),
                Slug = "placeholder",
                IsPage = true,
                Description = "",
                Title = "Placeholder",
                Value = "This is a placeholder page. The underlying functionality has not yet been implemented."
            });

            modelBuilder.Entity<ContentBlock>().HasData(new ContentBlock()
            {
                Id = Guid.NewGuid(),
                Slug = "dashboard",
                IsPage = false,
                Description = "Content that appears on the Home/Dashboard page",
                Title = "Hello",
                Value = "Hello, world. Or whoever else is here. This content is editable within the app."
            });

            modelBuilder.Entity<ContentBlock>().HasData(new ContentBlock()
            {
                Id = Guid.NewGuid(),
                Slug = "help",
                IsPage = true,
                Description = "The help page that appears in the top nav",
                Title = "Help!",
                Value = "Need help? Don't we all."
            });
        }

        private void SeedAppData(ModelBuilder modelBuilder)
        {
            var acmeId = Guid.NewGuid();
            var northwoodsId = Guid.NewGuid();
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                Id = acmeId,
                Name = "Acme, Inc.",
                Abbreviation = "ACME"
            });

            modelBuilder.Entity<Client>().HasData(new Client()
            {
                Id = northwoodsId,
                Name = "Northwoods",
                Abbreviation = "NWS"
            });

            modelBuilder.Entity<Project>().HasData(new Project()
            {
                Id = Guid.NewGuid(),
                ClientId = acmeId,
                Name = "Operation Purple Midnight",
                StartDate = new NodaTime.LocalDate(2021, 1, 1),
                EndDate = new NodaTime.LocalDate(2022, 12, 31),
                State = ProjectState.Open
            });

            modelBuilder.Entity<Project>().HasData(new Project()
            {
                Id = Guid.NewGuid(),
                ClientId = northwoodsId,
                Name = "Rapidest",
                StartDate = new NodaTime.LocalDate(2016, 9, 1),
                EndDate = new NodaTime.LocalDate(2019, 3, 30),
                State = ProjectState.Closed
            });

            modelBuilder.Entity<Project>().HasData(new Project()
            {
                Id = Guid.NewGuid(),
                ClientId = northwoodsId,
                Name = "Rapidester",
                StartDate = new NodaTime.LocalDate(2021, 3, 1),
                EndDate = new NodaTime.LocalDate(2021, 6, 30),
                State = ProjectState.OnHold
            });

            modelBuilder.Entity<Project>().HasData(new Project()
            {
                Id = Guid.NewGuid(),
                ClientId = northwoodsId,
                Name = "Rapidesterester",
                StartDate = new NodaTime.LocalDate(2021, 7, 1),
                EndDate = new NodaTime.LocalDate(2022, 6, 30),
                State = ProjectState.Open
            });
        }
    }
}
