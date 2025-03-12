using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen_Parcial1_Verdesoto_Ruben.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRecetasIngredientesChefs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chefs",
                columns: table => new
                {
                    Id_Chef = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chefs", x => x.Id_Chef);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    Receta_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tiempo_Preparacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dificultad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id_Chef = table.Column<int>(type: "int", nullable: false),
                    ChefId_Chef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.Receta_Id);
                    table.ForeignKey(
                        name: "FK_Recetas_Chefs_ChefId_Chef",
                        column: x => x.ChefId_Chef,
                        principalTable: "Chefs",
                        principalColumn: "Id_Chef",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Ingrediente_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calorias = table.Column<int>(type: "int", nullable: false),
                    Receta_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.Ingrediente_Id);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Recetas_Receta_Id",
                        column: x => x.Receta_Id,
                        principalTable: "Recetas",
                        principalColumn: "Receta_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_Receta_Id",
                table: "Ingredientes",
                column: "Receta_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_ChefId_Chef",
                table: "Recetas",
                column: "ChefId_Chef");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "Chefs");
        }
    }
}
