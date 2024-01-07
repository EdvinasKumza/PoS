using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoS.Migrations
{
    /// <inheritdoc />
    public partial class OrderChanges3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Tips",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalFee",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tips",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalFee",
                table: "Orders");
        }
    }
}
