using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Am.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matricule = table.Column<int>(type: "int", nullable: true),
                    Specialite = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personnes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "planes",
                columns: table => new
                {
                    PlaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaneType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planes", x => x.PlaneId);
                });

            migrationBuilder.CreateTable(
                name: "flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveArrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedDuration = table.Column<int>(type: "int", nullable: false),
                    PlaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_flights_planes_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "planes",
                        principalColumn: "PlaneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "passangers",
                columns: table => new
                {
                    PassportNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNumber = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: true),
                    EmployementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: true),
                    HealthInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passangers", x => x.PassportNumber);
                    table.ForeignKey(
                        name: "FK_passangers_flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "flights",
                        principalColumn: "FlightId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_flights_PlaneId",
                table: "flights",
                column: "PlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_passangers_FlightId",
                table: "passangers",
                column: "FlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "passangers");

            migrationBuilder.DropTable(
                name: "personnes");

            migrationBuilder.DropTable(
                name: "flights");

            migrationBuilder.DropTable(
                name: "planes");
        }
    }
}
