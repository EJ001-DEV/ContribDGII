using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace adm_impuestos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    CodPersona = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PNom = table.Column<string>(type: "text", nullable: true),
                    SNom = table.Column<string>(type: "text", nullable: true),
                    PApe = table.Column<string>(type: "text", nullable: true),
                    SApe = table.Column<string>(type: "text", nullable: true),
                    RazonSocial = table.Column<string>(type: "text", nullable: true),
                    TipoIdent = table.Column<string>(type: "text", nullable: true),
                    DocumentoIdent = table.Column<string>(type: "text", nullable: true),
                    Sexo = table.Column<string>(type: "text", nullable: true),
                    FecNac = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.CodPersona);
                });

            migrationBuilder.CreateTable(
                name: "SerieNcf",
                columns: table => new
                {
                    Serie = table.Column<string>(type: "text", nullable: false),
                    DescripSerie = table.Column<string>(type: "text", nullable: true),
                    AplicaFactElect = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieNcf", x => x.Serie);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Identificacion",
                columns: table => new
                {
                    TipoIdent = table.Column<string>(type: "text", nullable: false),
                    DescripcionTipoIdent = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Identificacion", x => x.TipoIdent);
                });

            migrationBuilder.CreateTable(
                name: "TipoContribuyente",
                columns: table => new
                {
                    CodtipoContrib = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoContribuyente = table.Column<string>(type: "text", nullable: true),
                    FecReg = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoContribuyente", x => x.CodtipoContrib);
                });

            migrationBuilder.CreateTable(
                name: "VersionNcf",
                columns: table => new
                {
                    CodVersion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecini = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Desccripcion = table.Column<string>(type: "text", nullable: true),
                    Fecfin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionNcf", x => x.CodVersion);
                });

            migrationBuilder.CreateTable(
                name: "Contribuyentes",
                columns: table => new
                {
                    CodContrib = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodPersona = table.Column<int>(type: "integer", nullable: true),
                    CodtipoContrib = table.Column<int>(type: "integer", nullable: true),
                    FecReg = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FecCierre = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NumCamaraComer = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuyentes", x => x.CodContrib);
                    table.ForeignKey(
                        name: "FK_Contribuyentes_TipoContribuyente_CodtipoContrib",
                        column: x => x.CodtipoContrib,
                        principalTable: "TipoContribuyente",
                        principalColumn: "CodtipoContrib");
                    table.ForeignKey(
                        name: "FK_Contribuyentes_persona_CodPersona",
                        column: x => x.CodPersona,
                        principalTable: "persona",
                        principalColumn: "CodPersona");
                });

            migrationBuilder.CreateTable(
                name: "TipoNcfs",
                columns: table => new
                {
                    TipoNcf = table.Column<string>(type: "text", nullable: false),
                    Serie = table.Column<string>(type: "text", nullable: false),
                    CodVersion = table.Column<int>(type: "integer", nullable: false),
                    DescripTiponcf = table.Column<string>(type: "text", nullable: true),
                    LongSecuencia = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoNcfs", x => new { x.TipoNcf, x.Serie, x.CodVersion });
                    table.ForeignKey(
                        name: "FK_TipoNcfs_SerieNcf_Serie",
                        column: x => x.Serie,
                        principalTable: "SerieNcf",
                        principalColumn: "Serie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoNcfs_VersionNcf_CodVersion",
                        column: x => x.CodVersion,
                        principalTable: "VersionNcf",
                        principalColumn: "CodVersion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventosContribuyente",
                columns: table => new
                {
                    CodContrib = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NcfUsado = table.Column<string>(type: "text", nullable: true),
                    MontoNeto = table.Column<decimal>(type: "numeric", nullable: true),
                    Itbis = table.Column<decimal>(type: "numeric", nullable: true),
                    PorItbis = table.Column<decimal>(type: "numeric", nullable: true),
                    Feccarga = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ContribuyenteCodContrib = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventosContribuyente", x => x.CodContrib);
                    table.ForeignKey(
                        name: "FK_EventosContribuyente_Contribuyentes_ContribuyenteCodContrib",
                        column: x => x.ContribuyenteCodContrib,
                        principalTable: "Contribuyentes",
                        principalColumn: "CodContrib");
                });

            migrationBuilder.CreateTable(
                name: "SecuenciaNcf",
                columns: table => new
                {
                    CodSec = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoNcf = table.Column<string>(type: "text", nullable: true),
                    Serie = table.Column<string>(type: "text", nullable: true),
                    CodVersion = table.Column<int>(type: "integer", nullable: true),
                    SecIni = table.Column<long>(type: "bigint", nullable: true),
                    SecFin = table.Column<long>(type: "bigint", nullable: true),
                    CantNum = table.Column<int>(type: "integer", nullable: true),
                    Fecreg = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecuenciaNcf", x => x.CodSec);
                    table.ForeignKey(
                        name: "FK_SecuenciaNcf_TipoNcfs_TipoNcf_Serie_CodVersion",
                        columns: x => new { x.TipoNcf, x.Serie, x.CodVersion },
                        principalTable: "TipoNcfs",
                        principalColumns: new[] { "TipoNcf", "Serie", "CodVersion" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contribuyentes_CodPersona",
                table: "Contribuyentes",
                column: "CodPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Contribuyentes_CodtipoContrib",
                table: "Contribuyentes",
                column: "CodtipoContrib");

            migrationBuilder.CreateIndex(
                name: "IX_EventosContribuyente_ContribuyenteCodContrib",
                table: "EventosContribuyente",
                column: "ContribuyenteCodContrib");

            migrationBuilder.CreateIndex(
                name: "IX_SecuenciaNcf_TipoNcf_Serie_CodVersion",
                table: "SecuenciaNcf",
                columns: new[] { "TipoNcf", "Serie", "CodVersion" });

            migrationBuilder.CreateIndex(
                name: "IX_TipoNcfs_CodVersion",
                table: "TipoNcfs",
                column: "CodVersion");

            migrationBuilder.CreateIndex(
                name: "IX_TipoNcfs_Serie",
                table: "TipoNcfs",
                column: "Serie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventosContribuyente");

            migrationBuilder.DropTable(
                name: "SecuenciaNcf");

            migrationBuilder.DropTable(
                name: "Tipo_Identificacion");

            migrationBuilder.DropTable(
                name: "Contribuyentes");

            migrationBuilder.DropTable(
                name: "TipoNcfs");

            migrationBuilder.DropTable(
                name: "TipoContribuyente");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "SerieNcf");

            migrationBuilder.DropTable(
                name: "VersionNcf");
        }
    }
}
