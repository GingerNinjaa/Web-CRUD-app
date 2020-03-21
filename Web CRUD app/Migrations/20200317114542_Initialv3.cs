using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_CRUD_app.Migrations
{
    public partial class Initialv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "tblProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblProduct",
                table: "tblProduct",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblProduct",
                table: "tblProduct");

            migrationBuilder.RenameTable(
                name: "tblProduct",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ID");
        }
    }
}
