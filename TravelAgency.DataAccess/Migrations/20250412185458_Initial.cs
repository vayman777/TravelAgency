using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Direction = table.Column<string>(type: "text", nullable: false),
                    DepartureDate = table.Column<DateOnly>(type: "date", nullable: false),
                    NumberOfNights = table.Column<int>(type: "integer", nullable: false),
                    CostPerPerson = table.Column<double>(type: "double precision", nullable: false),
                    PersonCount = table.Column<int>(type: "integer", nullable: false),
                    AvailabilityWiFi = table.Column<string>(type: "text", nullable: false),
                    Surcharge = table.Column<double>(type: "double precision", nullable: false),
                    TotalCost = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
