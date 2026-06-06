using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basic_CURD_Operation.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnStockInProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "stock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "stock",
                table: "Products");
        }
    }
}
