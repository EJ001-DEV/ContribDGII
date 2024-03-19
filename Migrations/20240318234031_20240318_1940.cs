using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace adm_impuestos.Migrations
{
    /// <inheritdoc />
    public partial class _20240318_1940 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventosContribuyente",
                table: "EventosContribuyente");

            migrationBuilder.AlterColumn<string>(
                name: "NcfUsado",
                table: "EventosContribuyente",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CodContrib",
                table: "EventosContribuyente",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventosContribuyente",
                table: "EventosContribuyente",
                columns: new[] { "CodContrib", "NcfUsado" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventosContribuyente",
                table: "EventosContribuyente");

            migrationBuilder.AlterColumn<string>(
                name: "NcfUsado",
                table: "EventosContribuyente",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "CodContrib",
                table: "EventosContribuyente",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventosContribuyente",
                table: "EventosContribuyente",
                column: "CodContrib");
        }
    }
}
