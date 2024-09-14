using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_GEO.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddConfandModelToTayota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TayotaModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TayotaModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigurationModels_TayotaModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "TayotaModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationColorModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ConfigurationId = table.Column<int>(type: "int", nullable: false),
                    CarImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationColorModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigurationColorModels_ColorModels_ColorId",
                        column: x => x.ColorId,
                        principalTable: "ColorModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigurationColorModels_ConfigurationModels_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "ConfigurationModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationColorModels_ColorId",
                table: "ConfigurationColorModels",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationColorModels_ConfigurationId",
                table: "ConfigurationColorModels",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationModels_ModelId",
                table: "ConfigurationModels",
                column: "ModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigurationColorModels");

            migrationBuilder.DropTable(
                name: "ConfigurationModels");

            migrationBuilder.DropTable(
                name: "TayotaModels");
        }
    }
}
