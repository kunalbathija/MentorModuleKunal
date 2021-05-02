using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductsAPI.Migrations
{
    public partial class Initial_Products_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    availability = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "availability", "description", "name" },
                values: new object[,]
                {
                    { 1, 1, "Product 1 description", "Product1" },
                    { 2, 4, "Product 2 description", "Product2" },
                    { 3, 6, "Product 3 description", "Product3" },
                    { 4, 32, "Product 4 description", "Product4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
