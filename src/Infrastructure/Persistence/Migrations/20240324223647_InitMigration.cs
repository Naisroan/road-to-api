using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.persistence.migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaternalLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rfc = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Curp = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_persons_Curp",
                table: "persons",
                column: "Curp");

            migrationBuilder.CreateIndex(
                name: "IX_persons_FirstName",
                table: "persons",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_persons_LastName",
                table: "persons",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_persons_MaternalLastName",
                table: "persons",
                column: "MaternalLastName");

            migrationBuilder.CreateIndex(
                name: "IX_persons_MiddleName",
                table: "persons",
                column: "MiddleName");

            migrationBuilder.CreateIndex(
                name: "IX_persons_Rfc",
                table: "persons",
                column: "Rfc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "persons");
        }
    }
}
