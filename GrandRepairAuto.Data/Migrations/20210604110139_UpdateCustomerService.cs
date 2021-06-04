using Microsoft.EntityFrameworkCore.Migrations;

namespace GrandRepairAuto.Data.Migrations
{
    public partial class UpdateCustomerService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FixedPrice",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CustomerServices",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PricePerHour",
                table: "CustomerServices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "CustomerServices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleType",
                table: "CustomerServices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "WorkHours",
                table: "CustomerServices",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CustomerServices");

            migrationBuilder.DropColumn(
                name: "PricePerHour",
                table: "CustomerServices");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "CustomerServices");

            migrationBuilder.DropColumn(
                name: "VehicleType",
                table: "CustomerServices");

            migrationBuilder.DropColumn(
                name: "WorkHours",
                table: "CustomerServices");

            migrationBuilder.AddColumn<double>(
                name: "FixedPrice",
                table: "Services",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
