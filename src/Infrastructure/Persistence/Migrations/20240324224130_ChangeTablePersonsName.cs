using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.persistence.migrations
{
    /// <inheritdoc />
    public partial class ChangeTablePersonsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_persons",
                table: "persons");

            migrationBuilder.RenameTable(
                name: "persons",
                newName: "Persons");

            migrationBuilder.RenameIndex(
                name: "IX_persons_Rfc",
                table: "Persons",
                newName: "IX_Persons_Rfc");

            migrationBuilder.RenameIndex(
                name: "IX_persons_MiddleName",
                table: "Persons",
                newName: "IX_Persons_MiddleName");

            migrationBuilder.RenameIndex(
                name: "IX_persons_MaternalLastName",
                table: "Persons",
                newName: "IX_Persons_MaternalLastName");

            migrationBuilder.RenameIndex(
                name: "IX_persons_LastName",
                table: "Persons",
                newName: "IX_Persons_LastName");

            migrationBuilder.RenameIndex(
                name: "IX_persons_FirstName",
                table: "Persons",
                newName: "IX_Persons_FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_persons_Curp",
                table: "Persons",
                newName: "IX_Persons_Curp");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "persons");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_Rfc",
                table: "persons",
                newName: "IX_persons_Rfc");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_MiddleName",
                table: "persons",
                newName: "IX_persons_MiddleName");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_MaternalLastName",
                table: "persons",
                newName: "IX_persons_MaternalLastName");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_LastName",
                table: "persons",
                newName: "IX_persons_LastName");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_FirstName",
                table: "persons",
                newName: "IX_persons_FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_Curp",
                table: "persons",
                newName: "IX_persons_Curp");

            migrationBuilder.AddPrimaryKey(
                name: "PK_persons",
                table: "persons",
                column: "Id");
        }
    }
}
