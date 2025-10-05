using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyChain.Management.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Unqiue_Indexs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stock_Warehouse_SKU_Quantity",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_LegoSet_Theme_Weight_State",
                table: "LegoSet");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Warehouse_SKU_Quantity",
                table: "Stock",
                columns: new[] { "Warehouse", "SKU", "Quantity" });

            migrationBuilder.CreateIndex(
                name: "IX_LegoSet_Theme_Weight_State",
                table: "LegoSet",
                columns: new[] { "Theme", "Weight", "State" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stock_Warehouse_SKU_Quantity",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_LegoSet_Theme_Weight_State",
                table: "LegoSet");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Warehouse_SKU_Quantity",
                table: "Stock",
                columns: new[] { "Warehouse", "SKU", "Quantity" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegoSet_Theme_Weight_State",
                table: "LegoSet",
                columns: new[] { "Theme", "Weight", "State" },
                unique: true);
        }
    }
}
