using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AntiFishing.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class AddAllRelations : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "AspNetRoles",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetRoles", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "lakes",
				columns: table => new
				{
					LakeId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Info = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
					Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Area = table.Column<double>(type: "float", nullable: false),
					Depth = table.Column<double>(type: "float", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_lakes", x => x.LakeId);
				});

			migrationBuilder.CreateTable(
				name: "AspNetRoleClaims",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUsers",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
					LakeId = table.Column<int>(type: "int", nullable: true),
					UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
					PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
					SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
					TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
					LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
					LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
					AccessFailedCount = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUsers", x => x.Id);
					table.ForeignKey(
						name: "FK_AspNetUsers_lakes_LakeId",
						column: x => x.LakeId,
						principalTable: "lakes",
						principalColumn: "LakeId");
				});

			migrationBuilder.CreateTable(
				name: "fish",
				columns: table => new
				{
					FishId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					NumberOfFish = table.Column<double>(type: "float", nullable: false),
					FishStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
					LakeId = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_fish", x => x.FishId);
					table.ForeignKey(
						name: "FK_fish_lakes_LakeId",
						column: x => x.LakeId,
						principalTable: "lakes",
						principalColumn: "LakeId");
				});

			migrationBuilder.CreateTable(
				name: "instructions",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
					LakeId = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_instructions", x => x.Id);
					table.ForeignKey(
						name: "FK_instructions_lakes_LakeId",
						column: x => x.LakeId,
						principalTable: "lakes",
						principalColumn: "LakeId");
				});

			migrationBuilder.CreateTable(
				name: "regions",
				columns: table => new
				{
					RegionId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					RegionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
					RegionWidth = table.Column<string>(type: "nvarchar(max)", nullable: false),
					LakeId = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_regions", x => x.RegionId);
					table.ForeignKey(
						name: "FK_regions_lakes_LakeId",
						column: x => x.LakeId,
						principalTable: "lakes",
						principalColumn: "LakeId");
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserClaims",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_AspNetUserClaims_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserLogins",
				columns: table => new
				{
					LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
					table.ForeignKey(
						name: "FK_AspNetUserLogins_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserRoles",
				columns: table => new
				{
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserTokens",
				columns: table => new
				{
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
					table.ForeignKey(
						name: "FK_AspNetUserTokens_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "schedules",
				columns: table => new
				{
					ScheduleId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
					EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
					LakeId = table.Column<int>(type: "int", nullable: true),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_schedules", x => x.ScheduleId);
					table.ForeignKey(
						name: "FK_schedules_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id");
					table.ForeignKey(
						name: "FK_schedules_lakes_LakeId",
						column: x => x.LakeId,
						principalTable: "lakes",
						principalColumn: "LakeId");
				});

			migrationBuilder.CreateTable(
				name: "cameras",
				columns: table => new
				{
					CameraId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Info = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
					LakeId = table.Column<int>(type: "int", nullable: true),
					RegionId = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_cameras", x => x.CameraId);
					table.ForeignKey(
						name: "FK_cameras_lakes_LakeId",
						column: x => x.LakeId,
						principalTable: "lakes",
						principalColumn: "LakeId");
					table.ForeignKey(
						name: "FK_cameras_regions_RegionId",
						column: x => x.RegionId,
						principalTable: "regions",
						principalColumn: "RegionId");
				});

			migrationBuilder.CreateTable(
				name: "sensors",
				columns: table => new
				{
					SensorId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
					description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
					LakeId = table.Column<int>(type: "int", nullable: true),
					RegionId = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_sensors", x => x.SensorId);
					table.ForeignKey(
						name: "FK_sensors_lakes_LakeId",
						column: x => x.LakeId,
						principalTable: "lakes",
						principalColumn: "LakeId");
					table.ForeignKey(
						name: "FK_sensors_regions_RegionId",
						column: x => x.RegionId,
						principalTable: "regions",
						principalColumn: "RegionId");
				});

			migrationBuilder.CreateTable(
				name: "videos",
				columns: table => new
				{
					VideoId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Time = table.Column<DateTime>(type: "datetime2", nullable: false),
					CameraId = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_videos", x => x.VideoId);
					table.ForeignKey(
						name: "FK_videos_cameras_CameraId",
						column: x => x.CameraId,
						principalTable: "cameras",
						principalColumn: "CameraId");
				});

			migrationBuilder.CreateTable(
				name: "data",
				columns: table => new
				{
					DataId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Date = table.Column<DateTime>(type: "datetime2", nullable: true),
					SensorId = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_data", x => x.DataId);
					table.ForeignKey(
						name: "FK_data_sensors_SensorId",
						column: x => x.SensorId,
						principalTable: "sensors",
						principalColumn: "SensorId");
				});

			migrationBuilder.CreateTable(
				name: "notifications",
				columns: table => new
				{
					NotificationId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
					DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
					SensorId = table.Column<int>(type: "int", nullable: true),
					CameraId = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_notifications", x => x.NotificationId);
					table.ForeignKey(
						name: "FK_notifications_cameras_CameraId",
						column: x => x.CameraId,
						principalTable: "cameras",
						principalColumn: "CameraId");
					table.ForeignKey(
						name: "FK_notifications_sensors_SensorId",
						column: x => x.SensorId,
						principalTable: "sensors",
						principalColumn: "SensorId");
				});

			migrationBuilder.CreateIndex(
				name: "IX_AspNetRoleClaims_RoleId",
				table: "AspNetRoleClaims",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "RoleNameIndex",
				table: "AspNetRoles",
				column: "NormalizedName",
				unique: true,
				filter: "[NormalizedName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserClaims_UserId",
				table: "AspNetUserClaims",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserLogins_UserId",
				table: "AspNetUserLogins",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserRoles_RoleId",
				table: "AspNetUserRoles",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "EmailIndex",
				table: "AspNetUsers",
				column: "NormalizedEmail");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUsers_LakeId",
				table: "AspNetUsers",
				column: "LakeId");

			migrationBuilder.CreateIndex(
				name: "UserNameIndex",
				table: "AspNetUsers",
				column: "NormalizedUserName",
				unique: true,
				filter: "[NormalizedUserName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_cameras_LakeId",
				table: "cameras",
				column: "LakeId");

			migrationBuilder.CreateIndex(
				name: "IX_cameras_RegionId",
				table: "cameras",
				column: "RegionId");

			migrationBuilder.CreateIndex(
				name: "IX_data_SensorId",
				table: "data",
				column: "SensorId");

			migrationBuilder.CreateIndex(
				name: "IX_fish_LakeId",
				table: "fish",
				column: "LakeId");

			migrationBuilder.CreateIndex(
				name: "IX_instructions_LakeId",
				table: "instructions",
				column: "LakeId");

			migrationBuilder.CreateIndex(
				name: "IX_notifications_CameraId",
				table: "notifications",
				column: "CameraId");

			migrationBuilder.CreateIndex(
				name: "IX_notifications_SensorId",
				table: "notifications",
				column: "SensorId");

			migrationBuilder.CreateIndex(
				name: "IX_regions_LakeId",
				table: "regions",
				column: "LakeId");

			migrationBuilder.CreateIndex(
				name: "IX_schedules_LakeId",
				table: "schedules",
				column: "LakeId");

			migrationBuilder.CreateIndex(
				name: "IX_schedules_UserId",
				table: "schedules",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_sensors_LakeId",
				table: "sensors",
				column: "LakeId");

			migrationBuilder.CreateIndex(
				name: "IX_sensors_RegionId",
				table: "sensors",
				column: "RegionId");

			migrationBuilder.CreateIndex(
				name: "IX_videos_CameraId",
				table: "videos",
				column: "CameraId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "AspNetRoleClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserLogins");

			migrationBuilder.DropTable(
				name: "AspNetUserRoles");

			migrationBuilder.DropTable(
				name: "AspNetUserTokens");

			migrationBuilder.DropTable(
				name: "data");

			migrationBuilder.DropTable(
				name: "fish");

			migrationBuilder.DropTable(
				name: "instructions");

			migrationBuilder.DropTable(
				name: "notifications");

			migrationBuilder.DropTable(
				name: "schedules");

			migrationBuilder.DropTable(
				name: "videos");

			migrationBuilder.DropTable(
				name: "AspNetRoles");

			migrationBuilder.DropTable(
				name: "sensors");

			migrationBuilder.DropTable(
				name: "AspNetUsers");

			migrationBuilder.DropTable(
				name: "cameras");

			migrationBuilder.DropTable(
				name: "regions");

			migrationBuilder.DropTable(
				name: "lakes");
		}
	}
}
