using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Am.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class testtt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName_lastName",
                table: "passangers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FullName_firstName",
                table: "passangers",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "passangers",
                newName: "FullName_lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "passangers",
                newName: "FullName_firstName");
        }
    }
}
