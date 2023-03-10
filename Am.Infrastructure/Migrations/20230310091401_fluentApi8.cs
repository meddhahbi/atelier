using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Am.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fluentApi8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassengerName",
                table: "passangers",
                newName: "FullName_firstName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "passangers",
                newName: "FullName_lastName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName_lastName",
                table: "passangers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FullName_firstName",
                table: "passangers",
                newName: "PassengerName");
        }
    }
}
