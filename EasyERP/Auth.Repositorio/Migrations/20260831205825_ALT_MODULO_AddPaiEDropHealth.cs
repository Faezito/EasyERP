using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class ALT_MODULO_AddPaiEDropHealth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HealthCheckPath",
                table: "Modulo");

            migrationBuilder.DropColumn(
                name: "VersaoApi",
                table: "Modulo");

            migrationBuilder.AddColumn<int>(
                name: "ModuloPaiId",
                table: "Modulo",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModuloPaiId",
                table: "Modulo");

            migrationBuilder.AddColumn<string>(
                name: "HealthCheckPath",
                table: "Modulo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VersaoApi",
                table: "Modulo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
