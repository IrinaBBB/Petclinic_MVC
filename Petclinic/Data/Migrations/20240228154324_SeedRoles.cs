using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Petclinic.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Vets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Vets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Owners",
                type: "TEXT",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "About",
                table: "Vets");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Vets");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Owners");
        }
    }
}
