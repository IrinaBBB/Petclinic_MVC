using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Petclinic.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentBookingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5433c15e-a596-4c8b-b94e-e558541d4c07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58162c8d-40bb-4665-9464-33be0f43c078");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afa8c7e7-9117-4cc1-acf3-ecd1e504f024");

            migrationBuilder.CreateTable(
                name: "AppointmentBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Pending = table.Column<bool>(type: "INTEGER", nullable: false),
                    Processed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentBookings", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentBookings");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5433c15e-a596-4c8b-b94e-e558541d4c07", null, "Admin", "ADMIN" },
                    { "58162c8d-40bb-4665-9464-33be0f43c078", null, "User", "USER" },
                    { "afa8c7e7-9117-4cc1-acf3-ecd1e504f024", null, "Vet", "VET" }
                });
        }
    }
}
