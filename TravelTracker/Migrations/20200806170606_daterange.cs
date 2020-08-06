using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelTracker.Migrations
{
    public partial class daterange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VisitDate",
                table: "DestinationTraveller",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "DestinationTraveller",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "DestinationTraveller");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "DestinationTraveller",
                newName: "VisitDate");
        }
    }
}
