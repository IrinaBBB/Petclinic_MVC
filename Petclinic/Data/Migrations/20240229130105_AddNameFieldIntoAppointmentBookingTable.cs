using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Petclinic.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNameFieldIntoAppointmentBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d9efc08-6b11-4004-92f1-610ff2f632b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35609fa0-57be-4ed2-8636-3434b5ec279c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2c6b46f-09b3-4195-8d82-bf3849eb463e");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AppointmentBookings",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AppointmentBookings",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppointmentBookings",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AppointmentBookings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5219a824-a7d8-42fa-a0e2-6bd1e5a7373a", null, "Admin", "ADMIN" },
                    { "e126a331-b70f-4cbc-a92f-a6ba0a8d2cab", null, "User", "USER" },
                    { "f40bab7e-aad6-4329-a8bb-fcf76d0a6c75", null, "Vet", "VET" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5219a824-a7d8-42fa-a0e2-6bd1e5a7373a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e126a331-b70f-4cbc-a92f-a6ba0a8d2cab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f40bab7e-aad6-4329-a8bb-fcf76d0a6c75");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AppointmentBookings");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AppointmentBookings",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AppointmentBookings",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppointmentBookings",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d9efc08-6b11-4004-92f1-610ff2f632b2", null, "Admin", "ADMIN" },
                    { "35609fa0-57be-4ed2-8636-3434b5ec279c", null, "User", "USER" },
                    { "e2c6b46f-09b3-4195-8d82-bf3849eb463e", null, "Vet", "VET" }
                });
        }
    }
}
