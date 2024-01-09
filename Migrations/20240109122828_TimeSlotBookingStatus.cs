using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoS.Migrations
{
    /// <inheritdoc />
    public partial class TimeSlotBookingStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "TimeSlotBookings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TimeSlotBookings");
        }
    }
}
