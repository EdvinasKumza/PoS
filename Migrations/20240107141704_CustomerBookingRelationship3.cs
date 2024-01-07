using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoS.Migrations
{
    /// <inheritdoc />
    public partial class CustomerBookingRelationship3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlotBookings_Customers_CustomerId",
                table: "TimeSlotBookings");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlotBookings_Customers_CustomerId",
                table: "TimeSlotBookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlotBookings_Customers_CustomerId",
                table: "TimeSlotBookings");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlotBookings_Customers_CustomerId",
                table: "TimeSlotBookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
