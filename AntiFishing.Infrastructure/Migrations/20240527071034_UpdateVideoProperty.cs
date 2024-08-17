using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AntiFishing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVideoProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "videos");
        }
    }
}
