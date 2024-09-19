using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_ASP.NET.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAreaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegionCapitalId",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_RegionCapitalId",
                table: "Areas",
                column: "RegionCapitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Cities_RegionCapitalId",
                table: "Areas",
                column: "RegionCapitalId",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Cities_RegionCapitalId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_RegionCapitalId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "RegionCapitalId",
                table: "Areas");
        }
    }
}
