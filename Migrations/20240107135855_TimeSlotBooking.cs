using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoS.Migrations
{
    /// <inheritdoc />
    public partial class TimeSlotBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeSlotBookings",
                columns: table => new
                {
                    BookingId = table.Column<string>(type: "TEXT", nullable: false),
                    TimeSlotId = table.Column<string>(type: "TEXT", nullable: false),
                    BookingTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlotBookings", x => x.BookingId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSlotBookings");
        }
    }
}
