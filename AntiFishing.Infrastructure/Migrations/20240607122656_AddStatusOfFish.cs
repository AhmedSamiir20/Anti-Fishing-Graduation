using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AntiFishing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusOfFish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FishStatus",
                table: "videos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FishStatus",
                table: "videos");
        }
    }
}
