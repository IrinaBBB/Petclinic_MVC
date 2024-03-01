using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Petclinic.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddServicesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31c04cc5-0b6e-4a87-94eb-b83418090d23", null, "Admin", "ADMIN" },
                    { "5412bd2d-f974-4b51-be48-7a128cfdd02f", null, "Vet", "VET" },
                    { "586e51b9-7c08-421c-96f6-3c283f407bb8", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31c04cc5-0b6e-4a87-94eb-b83418090d23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5412bd2d-f974-4b51-be48-7a128cfdd02f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "586e51b9-7c08-421c-96f6-3c283f407bb8");

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
    }
}
