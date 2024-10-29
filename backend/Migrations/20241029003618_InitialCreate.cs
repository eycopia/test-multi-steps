using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Afiliaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tecnologia = table.Column<string>(type: "TEXT", nullable: true),
                    Aplicacion = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ResponsableSquad = table.Column<string>(type: "TEXT", nullable: true),
                    ResponsableSeguridad = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Correo = table.Column<string>(type: "TEXT", nullable: true),
                    TipoAfiliacion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afiliaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Rubro = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RutasServidores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ruta = table.Column<string>(type: "TEXT", nullable: false),
                    AfiliacionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutasServidores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RutasServidores_Afiliaciones_AfiliacionId",
                        column: x => x.AfiliacionId,
                        principalTable: "Afiliaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RutasSftp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ruta = table.Column<string>(type: "TEXT", nullable: false),
                    AfiliacionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutasSftp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RutasSftp_Afiliaciones_AfiliacionId",
                        column: x => x.AfiliacionId,
                        principalTable: "Afiliaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaAfiliaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false),
                    AfiliacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    SquadResponsable = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaAfiliaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpresaAfiliaciones_Afiliaciones_AfiliacionId",
                        column: x => x.AfiliacionId,
                        principalTable: "Afiliaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaAfiliaciones_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaAfiliaciones_AfiliacionId",
                table: "EmpresaAfiliaciones",
                column: "AfiliacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaAfiliaciones_EmpresaId",
                table: "EmpresaAfiliaciones",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_RutasServidores_AfiliacionId",
                table: "RutasServidores",
                column: "AfiliacionId");

            migrationBuilder.CreateIndex(
                name: "IX_RutasSftp_AfiliacionId",
                table: "RutasSftp",
                column: "AfiliacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpresaAfiliaciones");

            migrationBuilder.DropTable(
                name: "RutasServidores");

            migrationBuilder.DropTable(
                name: "RutasSftp");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Afiliaciones");
        }
    }
}
