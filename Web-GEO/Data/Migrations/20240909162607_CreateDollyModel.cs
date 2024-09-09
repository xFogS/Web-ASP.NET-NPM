using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_GEO.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDollyModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DollyColorModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DollyColorModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StyleModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DollyModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    StyleId = table.Column<int>(type: "int", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DollyModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DollyModels_DollyColorModels_ColorId",
                        column: x => x.ColorId,
                        principalTable: "DollyColorModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DollyModels_ImageModels_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ImageModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DollyModels_StyleModels_StyleId",
                        column: x => x.StyleId,
                        principalTable: "StyleModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DollyModels_ColorId",
                table: "DollyModels",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_DollyModels_ImageId",
                table: "DollyModels",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_DollyModels_StyleId",
                table: "DollyModels",
                column: "StyleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DollyModels");

            migrationBuilder.DropTable(
                name: "DollyColorModels");

            migrationBuilder.DropTable(
                name: "ImageModels");

            migrationBuilder.DropTable(
                name: "StyleModels");
        }
    }
}
