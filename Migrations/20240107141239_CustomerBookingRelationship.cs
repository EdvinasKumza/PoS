using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoS.Migrations
{
    /// <inheritdoc />
    public partial class CustomerBookingRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "TimeSlotBookings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlotBookings_CustomerId",
                table: "TimeSlotBookings",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlotBookings_Customers_CustomerId",
                table: "TimeSlotBookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlotBookings_Customers_CustomerId",
                table: "TimeSlotBookings");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlotBookings_CustomerId",
                table: "TimeSlotBookings");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "TimeSlotBookings");
        }
    }
}
