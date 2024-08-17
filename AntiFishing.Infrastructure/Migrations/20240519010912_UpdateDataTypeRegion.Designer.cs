﻿// <auto-generated />
using System;
using AntiFishing.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AntiFishing.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240519010912_UpdateDataTypeRegion")]
    partial class UpdateDataTypeRegion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AntiFishing.Data.Entities.Camera", b =>
                {
                    b.Property<int?>("CameraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("CameraId"));

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("LakeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("CameraId");

                    b.HasIndex("LakeId");

                    b.HasIndex("RegionId");

                    b.ToTable("cameras");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Fish", b =>
                {
                    b.Property<int?>("FishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("FishId"));

                    b.Property<string>("FishStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LakeId")
                        .HasColumnType("int");

                    b.Property<double>("NumberOfFish")
                        .HasColumnType("float");

                    b.HasKey("FishId");

                    b.HasIndex("LakeId");

                    b.ToTable("fish");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("LakeId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

                    b.HasIndex("LakeId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Instruction", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("LakeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("LakeId");

                    b.ToTable("instructions");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Lake", b =>
                {
                    b.Property<int?>("LakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("LakeId"));

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Depth")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LakeId");

                    b.ToTable("lakes");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<int?>("CameraId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("SensorId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("NotificationId");

                    b.HasIndex("CameraId");

                    b.HasIndex("SensorId");

                    b.ToTable("notifications");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegionId"));

                    b.Property<int?>("LakeId")
                        .HasColumnType("int");

                    b.Property<string>("RegionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionWidth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegionId");

                    b.HasIndex("LakeId");

                    b.ToTable("regions");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Schedule", b =>
                {
                    b.Property<int?>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ScheduleId"));

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LakeId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScheduleId");

                    b.HasIndex("LakeId");

                    b.HasIndex("UserId");

                    b.ToTable("schedules");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Sensor", b =>
                {
                    b.Property<int?>("SensorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("SensorId"));

                    b.Property<int?>("LakeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SensorId");

                    b.HasIndex("LakeId");

                    b.HasIndex("RegionId");

                    b.ToTable("sensors");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Video", b =>
                {
                    b.Property<int?>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("VideoId"));

                    b.Property<int?>("CameraId")
                        .HasColumnType("int");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("VideoId");

                    b.HasIndex("CameraId");

                    b.ToTable("videos");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.data", b =>
                {
                    b.Property<int?>("DataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("DataId"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SensorId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DataId");

                    b.HasIndex("SensorId");

                    b.ToTable("data");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Camera", b =>
                {
                    b.HasOne("AntiFishing.Data.Entities.Lake", "Lake")
                        .WithMany("Cameres")
                        .HasForeignKey("LakeId");

                    b.HasOne("AntiFishing.Data.Entities.Region", "Region")
                        .WithMany("Cameras")
                        .HasForeignKey("RegionId");

                    b.Navigation("Lake");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Fish", b =>
                {
                    b.HasOne("AntiFishing.Data.Entities.Lake", "Lake")
                        .WithMany("Fishs")
                        .HasForeignKey("LakeId");

                    b.Navigation("Lake");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Identity.User", b =>
                {
                    b.HasOne("AntiFishing.Data.Entities.Lake", "Lake")
                        .WithMany()
                        .HasForeignKey("LakeId");

                    b.Navigation("Lake");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Instruction", b =>
                {
                    b.HasOne("AntiFishing.Data.Entities.Lake", "Lake")
                        .WithMany("Instructions")
                        .HasForeignKey("LakeId");

                    b.Navigation("Lake");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Notification", b =>
                {
                    b.HasOne("AntiFishing.Data.Entities.Camera", "Camera")
                        .WithMany("Notifications")
                        .HasForeignKey("CameraId");

                    b.HasOne("AntiFishing.Data.Entities.Sensor", "Sensor")
                        .WithMany("Notifications")
                        .HasForeignKey("SensorId");

                    b.Navigation("Camera");

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Region", b =>
                {
                    b.HasOne("AntiFishing.Data.Entities.Lake", "Lake")
                        .WithMany("Regions")
                        .HasForeignKey("LakeId");

                    b.Navigation("Lake");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Schedule", b =>
                {
                    b.HasOne("AntiFishing.Data.Entities.Lake", "Lake")
                        .WithMany("Schedules")
                        .HasForeignKey("LakeId");

                    b.HasOne("AntiFishing.Data.Entities.Identity.User", "User")
                        .WithMany("Schedules")
                        .HasForeignKey("UserId");

                    b.Navigation("Lake");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Sensor", b =>
                {
                    b.HasOne("AntiFishing.Data.Entities.Lake", "Lake")
                        .WithMany("Sensors")
                        .HasForeignKey("LakeId");

                    b.HasOne("AntiFishing.Data.Entities.Region", "Region")
                        .WithMany("Sensors")
                        .HasForeignKey("RegionId");

                    b.Navigation("Lake");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Video", b =>
                {
                    b.HasOne("AntiFishing.Data.Entities.Camera", "Camera")
                        .WithMany("Videos")
                        .HasForeignKey("CameraId");

                    b.Navigation("Camera");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.data", b =>
                {
                    b.HasOne("AntiFishing.Data.Entities.Sensor", "Sensor")
                        .WithMany("Data")
                        .HasForeignKey("SensorId");

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AntiFishing.Data.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AntiFishing.Data.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AntiFishing.Data.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AntiFishing.Data.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Camera", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("Videos");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Identity.User", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Lake", b =>
                {
                    b.Navigation("Cameres");

                    b.Navigation("Fishs");

                    b.Navigation("Instructions");

                    b.Navigation("Regions");

                    b.Navigation("Schedules");

                    b.Navigation("Sensors");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Region", b =>
                {
                    b.Navigation("Cameras");

                    b.Navigation("Sensors");
                });

            modelBuilder.Entity("AntiFishing.Data.Entities.Sensor", b =>
                {
                    b.Navigation("Data");

                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
