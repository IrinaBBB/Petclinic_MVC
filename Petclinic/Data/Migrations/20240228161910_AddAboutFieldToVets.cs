using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Petclinic.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAboutFieldToVets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c664764-b0c1-412c-af7a-607822f7693f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e898964-0994-4323-96cb-051456a35f34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "accfcbce-2025-48d7-80a7-8682a5e0048e");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c664764-b0c1-412c-af7a-607822f7693f", null, "Vet", "VET" },
                    { "9e898964-0994-4323-96cb-051456a35f34", null, "User", "USER" },
                    { "accfcbce-2025-48d7-80a7-8682a5e0048e", null, "Admin", "ADMIN" }
                });
        }
    }
}
