using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoS.Migrations
{
    /// <inheritdoc />
    public partial class CustomerBookingRelationship4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlotBookings_Customers_CustomerId",
                table: "TimeSlotBookings");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlotBookings_CustomerId",
                table: "TimeSlotBookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
