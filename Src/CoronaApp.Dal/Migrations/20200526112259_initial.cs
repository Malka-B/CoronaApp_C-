using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CoronaApp.Dal.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Patient",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false),
            },
            constraints: table =>
        {
            table.PrimaryKey("PK_Patient", x => x.Id);
        });

            migrationBuilder.CreateTable(
            name: "Location",
            columns: table => new
            {
                PatientId = table.Column<int>(nullable: false)/*.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)*/,
                StartDate = table.Column<DateTime>(nullable: false),
                EndDate = table.Column<DateTime>(nullable: false),
                Address = table.Column<string>(nullable: false),
                City = table.Column<string>(nullable: false)
            },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Location",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
