using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB_tinkering.DB.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "supplier",
                table: "order_proposals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "supplier",
                table: "order_proposals",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
