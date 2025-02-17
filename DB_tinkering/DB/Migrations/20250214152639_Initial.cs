#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace DB_tinkering.DB.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_locations", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "product_groups",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_groups", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    min_order_quantity = table.Column<float>(type: "real", nullable: false),
                    max_order_quantity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_suppliers", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    purchase_price = table.Column<float>(type: "real", nullable: false),
                    sales_price = table.Column<float>(type: "real", nullable: false),
                    supplier_code = table.Column<string>(type: "text", nullable: true),
                    category = table.Column<string>(type: "text", nullable: false),
                    product_group_code = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.code);
                    table.ForeignKey(
                        name: "fk_products_product_groups_product_group_code",
                        column: x => x.product_group_code,
                        principalTable: "product_groups",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "fk_products_suppliers_supplier_code",
                        column: x => x.supplier_code,
                        principalTable: "suppliers",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "order_proposals",
                columns: table => new
                {
                    order_number = table.Column<string>(type: "text", nullable: false),
                    product_code = table.Column<string>(type: "text", nullable: true),
                    location_code = table.Column<string>(type: "text", nullable: false),
                    order_date = table.Column<DateOnly>(type: "date", nullable: false),
                    delivery_date = table.Column<DateOnly>(type: "date", nullable: false),
                    proposed_quantity = table.Column<float>(type: "real", nullable: false),
                    corrected_quantity = table.Column<float>(type: "real", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    batch_size = table.Column<float>(type: "real", nullable: false),
                    supplier = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    editable_from = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    editable_to = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_proposals", x => x.order_number);
                    table.ForeignKey(
                        name: "fk_order_proposals_locations_location_code",
                        column: x => x.location_code,
                        principalTable: "locations",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_proposals_products_product_code",
                        column: x => x.product_code,
                        principalTable: "products",
                        principalColumn: "code");
                });

            migrationBuilder.CreateIndex(
                name: "ix_order_proposals_location_code",
                table: "order_proposals",
                column: "location_code");

            migrationBuilder.CreateIndex(
                name: "ix_order_proposals_product_code",
                table: "order_proposals",
                column: "product_code");

            migrationBuilder.CreateIndex(
                name: "ix_products_product_group_code",
                table: "products",
                column: "product_group_code");

            migrationBuilder.CreateIndex(
                name: "ix_products_supplier_code",
                table: "products",
                column: "supplier_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_proposals");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "product_groups");

            migrationBuilder.DropTable(
                name: "suppliers");
        }
    }
}
