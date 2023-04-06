﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpaFramework.App.DAL;

#nullable disable

namespace SpaFramework.App.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230406234358_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("IdentityUserRole<long>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Accounts.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("9770d744-5c62-4d76-a4ef-163f94b33dad"),
                            ConcurrencyStamp = "1184d0d3-9ea3-4865-b9d7-a65a3b68d1ed",
                            Name = "SuperAdmin",
                            NormalizedName = "SuperAdmin"
                        },
                        new
                        {
                            Id = new Guid("558669b9-49a9-4520-90b8-51ba5b12c33e"),
                            ConcurrencyStamp = "ede6fe63-1651-4ebb-997d-b53f9149409e",
                            Name = "ProjectManager",
                            NormalizedName = "ProjectManager"
                        },
                        new
                        {
                            Id = new Guid("b67f4c23-5886-41ee-bbbb-6ae377f8f2ad"),
                            ConcurrencyStamp = "6c910474-e1cc-4db7-baaa-48f9e7333830",
                            Name = "ProjectViewer",
                            NormalizedName = "ProjectViewer"
                        },
                        new
                        {
                            Id = new Guid("18b6e930-29db-4c03-88e9-840adf59f2f7"),
                            ConcurrencyStamp = "f7d0c7b7-c4c5-4bad-8e71-a57c11a11ee5",
                            Name = "ContentManager",
                            NormalizedName = "ContentManager"
                        });
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Accounts.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "be7b587e-37ca-4584-9c85-a831384b8389",
                            Email = "admin@test.com",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@TEST.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEGxYFf+OZ0fW0ym/mAokEEOnOlDx/jwLScALn6RRKG6Tq7NWPq89ZCSicLDWdk1fDA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Accounts.ApplicationUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"),
                            RoleId = new Guid("9770d744-5c62-4d76-a4ef-163f94b33dad"),
                            Id = new Guid("8493be7b-63e9-4a70-b39f-f706a82e7d2d")
                        },
                        new
                        {
                            UserId = new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"),
                            RoleId = new Guid("558669b9-49a9-4520-90b8-51ba5b12c33e"),
                            Id = new Guid("cf761526-4b84-447b-be8a-77b90ae609ee")
                        },
                        new
                        {
                            UserId = new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"),
                            RoleId = new Guid("b67f4c23-5886-41ee-bbbb-6ae377f8f2ad"),
                            Id = new Guid("25610020-e4e8-4bc2-a7b3-2d65a6a133de")
                        },
                        new
                        {
                            UserId = new Guid("c9db7b0d-5889-4a71-b1a9-cf59ef2fa4be"),
                            RoleId = new Guid("18b6e930-29db-4c03-88e9-840adf59f2f7"),
                            Id = new Guid("702e4bc5-5235-44ea-9b40-f9af13324c76")
                        });
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Accounts.ExternalCredential", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ConcurrencyTimestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Provider")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ExternalCredentials");
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Clients.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Abbreviation")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<byte[]>("ConcurrencyTimestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.HasKey("Id");

                    b.HasIndex("Abbreviation");

                    b.ToTable("Clients", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb
                                .HasPeriodStart("PeriodStart")
                                .HasColumnName("PeriodStart");
                            ttb
                                .HasPeriodEnd("PeriodEnd")
                                .HasColumnName("PeriodEnd");
                        }
                    ));

                    b.HasData(
                        new
                        {
                            Id = new Guid("1338df5c-99f3-4d21-97af-4cf7e14f9620"),
                            Abbreviation = "ACME",
                            Name = "Acme, Inc."
                        },
                        new
                        {
                            Id = new Guid("da29d24f-dddf-4161-b55f-f35c6eaf593b"),
                            Abbreviation = "NWS",
                            Name = "Northwoods"
                        });
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Clients.ClientStats", b =>
                {
                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FirstStartDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("LastEndDate")
                        .HasColumnType("date");

                    b.Property<int>("NumberOfProjects")
                        .HasColumnType("int");

                    b.HasKey("ClientId");

                    b.ToView("ClientStats");
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Clients.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ConcurrencyTimestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Projects", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb
                                .HasPeriodStart("PeriodStart")
                                .HasColumnName("PeriodStart");
                            ttb
                                .HasPeriodEnd("PeriodEnd")
                                .HasColumnName("PeriodEnd");
                        }
                    ));

                    b.HasData(
                        new
                        {
                            Id = new Guid("c92444a6-fb4a-441b-bb83-7dc0fbc315e0"),
                            ClientId = new Guid("1338df5c-99f3-4d21-97af-4cf7e14f9620"),
                            EndDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Operation Purple Midnight",
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            State = 1
                        },
                        new
                        {
                            Id = new Guid("6d6001b8-1c89-43c7-a499-24f0ea21c21e"),
                            ClientId = new Guid("da29d24f-dddf-4161-b55f-f35c6eaf593b"),
                            EndDate = new DateTime(2019, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Rapidest",
                            StartDate = new DateTime(2016, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            State = 3
                        },
                        new
                        {
                            Id = new Guid("27956b1a-4837-4898-b141-cb457e4a813c"),
                            ClientId = new Guid("da29d24f-dddf-4161-b55f-f35c6eaf593b"),
                            EndDate = new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Rapidester",
                            StartDate = new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            State = 2
                        },
                        new
                        {
                            Id = new Guid("9b64a99f-9a8a-4a0f-a640-181568149975"),
                            ClientId = new Guid("da29d24f-dddf-4161-b55f-f35c6eaf593b"),
                            EndDate = new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Rapidesterester",
                            StartDate = new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            State = 1
                        });
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Content.ContentBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AllowedTokens")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ConcurrencyTimestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPage")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<string>("Slug")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Slug");

                    b.ToTable("ContentBlocks", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb
                                .HasPeriodStart("PeriodStart")
                                .HasColumnName("PeriodStart");
                            ttb
                                .HasPeriodEnd("PeriodEnd")
                                .HasColumnName("PeriodEnd");
                        }
                    ));

                    b.HasData(
                        new
                        {
                            Id = new Guid("da5a645b-1951-43bc-b032-eedead09d15f"),
                            AllowedTokens = "[{\"Token\":\"passwordResetUrl\",\"Description\":\"The URL for the user to reset their password\"}]",
                            Description = "The text that appears in a password reset message",
                            IsPage = false,
                            Slug = "password-reset-email",
                            Title = "Reset Your Password",
                            Value = "To reset your account, follow this link: %passwordResetUrl%"
                        },
                        new
                        {
                            Id = new Guid("c827a7ec-2dbb-4530-a1c5-9562b03cfdcc"),
                            Description = "The text that appears on the About page",
                            IsPage = true,
                            Slug = "about",
                            Title = "About Us",
                            Value = "About us..."
                        },
                        new
                        {
                            Id = new Guid("436e16ed-e5c8-4aaa-97fc-843f18e5aa94"),
                            Description = "",
                            IsPage = true,
                            Slug = "placeholder",
                            Title = "Placeholder",
                            Value = "This is a placeholder page. The underlying functionality has not yet been implemented."
                        },
                        new
                        {
                            Id = new Guid("816d2f1c-e174-42c0-abe0-2e36379da725"),
                            Description = "Content that appears on the Home/Dashboard page",
                            IsPage = false,
                            Slug = "dashboard",
                            Title = "Hello",
                            Value = "Hello, world. Or whoever else is here. This content is editable within the app."
                        },
                        new
                        {
                            Id = new Guid("92077e8e-45ce-4ecf-aa4b-17a5bfe91118"),
                            Description = "The help page that appears in the top nav",
                            IsPage = true,
                            Slug = "help",
                            Title = "Help!",
                            Value = "Need help? Don't we all."
                        });
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Jobs.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Ended")
                        .HasColumnType("datetime2");

                    b.Property<long>("ExpectedCount")
                        .HasColumnType("bigint");

                    b.Property<long>("FailureCount")
                        .HasColumnType("bigint");

                    b.Property<string>("ItemType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<string>("SerializedItemIds")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ItemIds");

                    b.Property<DateTime?>("Started")
                        .HasColumnType("datetime2");

                    b.Property<long>("SuccessCount")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Created");

                    b.ToTable("Jobs", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb
                                .HasPeriodStart("PeriodStart")
                                .HasColumnName("PeriodStart");
                            ttb
                                .HasPeriodEnd("PeriodEnd")
                                .HasColumnName("PeriodEnd");
                        }
                    ));
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Jobs.JobItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("JobItems", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb
                                .HasPeriodStart("PeriodStart")
                                .HasColumnName("PeriodStart");
                            ttb
                                .HasPeriodEnd("PeriodEnd")
                                .HasColumnName("PeriodEnd");
                        }
                    ));
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("SpaFramework.App.Models.Data.Accounts.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("SpaFramework.App.Models.Data.Accounts.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("SpaFramework.App.Models.Data.Accounts.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("SpaFramework.App.Models.Data.Accounts.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Accounts.ApplicationUserRole", b =>
                {
                    b.HasOne("SpaFramework.App.Models.Data.Accounts.ApplicationRole", "ApplicationRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpaFramework.App.Models.Data.Accounts.ApplicationUser", "ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationRole");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Accounts.ExternalCredential", b =>
                {
                    b.HasOne("SpaFramework.App.Models.Data.Accounts.ApplicationUser", "ApplicationUser")
                        .WithMany("ExternalCredentials")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Clients.ClientStats", b =>
                {
                    b.HasOne("SpaFramework.App.Models.Data.Clients.Client", "Client")
                        .WithOne("ClientStats")
                        .HasForeignKey("SpaFramework.App.Models.Data.Clients.ClientStats", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Clients.Project", b =>
                {
                    b.HasOne("SpaFramework.App.Models.Data.Clients.Client", "Client")
                        .WithMany("Projects")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Jobs.JobItem", b =>
                {
                    b.HasOne("SpaFramework.App.Models.Data.Jobs.Job", "Job")
                        .WithMany("JobItems")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Accounts.ApplicationRole", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Accounts.ApplicationUser", b =>
                {
                    b.Navigation("ExternalCredentials");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Clients.Client", b =>
                {
                    b.Navigation("ClientStats");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("SpaFramework.App.Models.Data.Jobs.Job", b =>
                {
                    b.Navigation("JobItems");
                });
#pragma warning restore 612, 618
        }
    }
}
