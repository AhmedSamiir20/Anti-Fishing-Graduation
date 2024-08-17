﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AntiFishing.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class AddChatMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "ChatMessages",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
					DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ChatMessages", x => x.Id);
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "ChatMessages");
		}
	}
}
