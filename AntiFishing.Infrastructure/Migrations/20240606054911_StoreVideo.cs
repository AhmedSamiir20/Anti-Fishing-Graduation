using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AntiFishing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StoreVideo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "videos",
                newName: "UploadedAt");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "videos",
                newName: "VideoUrl");

            migrationBuilder.AddColumn<int>(
                name: "FishCount",
                table: "videos",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FishCount",
                table: "videos");

            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "videos",
                newName: "FilePath");

            migrationBuilder.RenameColumn(
                name: "UploadedAt",
                table: "videos",
                newName: "Time");
        }
    }
}
