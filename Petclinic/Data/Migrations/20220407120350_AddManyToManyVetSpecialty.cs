using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Petclinic.Data.Migrations
{
    public partial class AddManyToManyVetSpecialty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Vets");

            migrationBuilder.CreateTable(
                name: "SpecialtyVet",
                columns: table => new
                {
                    SpecialtiesId = table.Column<int>(type: "int", nullable: false),
                    VetsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialtyVet", x => new { x.SpecialtiesId, x.VetsId });
                    table.ForeignKey(
                        name: "FK_SpecialtyVet_Specialties_SpecialtiesId",
                        column: x => x.SpecialtiesId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialtyVet_Vets_VetsId",
                        column: x => x.VetsId,
                        principalTable: "Vets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecialtyVet_VetsId",
                table: "SpecialtyVet",
                column: "VetsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecialtyVet");

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "Vets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
