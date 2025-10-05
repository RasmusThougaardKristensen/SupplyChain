using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyChain.Management.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Stock_And_LegoSet_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LegoSet",
                columns: table => new
                {
                    SKU = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Theme = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<string>(type: "text", nullable: false),
                    PieceCount = table.Column<int>(type: "integer", nullable: false),
                    Uom = table.Column<string>(type: "text", nullable: false),
                    ReleaseYear = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegoSet", x => x.SKU);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Warehouse = table.Column<string>(type: "text", nullable: false),
                    SKU = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Uom = table.Column<string>(type: "text", nullable: false),
                    Placement = table.Column<int>(type: "integer", nullable: false),
                    Shelf = table.Column<int>(type: "integer", nullable: false),
                    LegoSetEntitySKU = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_LegoSet_LegoSetEntitySKU",
                        column: x => x.LegoSetEntitySKU,
                        principalTable: "LegoSet",
                        principalColumn: "SKU");
                    table.ForeignKey(
                        name: "FK_Stock_LegoSet_SKU",
                        column: x => x.SKU,
                        principalTable: "LegoSet",
                        principalColumn: "SKU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegoSet_Theme_Weight_State",
                table: "LegoSet",
                columns: new[] { "Theme", "Weight", "State" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stock_LegoSetEntitySKU",
                table: "Stock",
                column: "LegoSetEntitySKU");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_SKU",
                table: "Stock",
                column: "SKU");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Warehouse_SKU_Quantity",
                table: "Stock",
                columns: new[] { "Warehouse", "SKU", "Quantity" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "LegoSet");
        }
    }
}
