using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB_tinkering.DB.Migrations
{
    /// <inheritdoc />
    public partial class v4_proper_foreignkey_mapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_order_proposals_products_product_code",
                table: "order_proposals");

            migrationBuilder.DropForeignKey(
                name: "fk_products_product_groups_product_group_code",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "fk_products_suppliers_supplier_code",
                table: "products");

            migrationBuilder.AlterColumn<string>(
                name: "supplier_code",
                table: "products",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "product_group_code",
                table: "products",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "product_code",
                table: "order_proposals",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_order_proposals_products_product_code",
                table: "order_proposals",
                column: "product_code",
                principalTable: "products",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_products_product_groups_product_group_code",
                table: "products",
                column: "product_group_code",
                principalTable: "product_groups",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_products_suppliers_supplier_code",
                table: "products",
                column: "supplier_code",
                principalTable: "suppliers",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_order_proposals_products_product_code",
                table: "order_proposals");

            migrationBuilder.DropForeignKey(
                name: "fk_products_product_groups_product_group_code",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "fk_products_suppliers_supplier_code",
                table: "products");

            migrationBuilder.AlterColumn<string>(
                name: "supplier_code",
                table: "products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "product_group_code",
                table: "products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "product_code",
                table: "order_proposals",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "fk_order_proposals_products_product_code",
                table: "order_proposals",
                column: "product_code",
                principalTable: "products",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "fk_products_product_groups_product_group_code",
                table: "products",
                column: "product_group_code",
                principalTable: "product_groups",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "fk_products_suppliers_supplier_code",
                table: "products",
                column: "supplier_code",
                principalTable: "suppliers",
                principalColumn: "code");
        }
    }
}
