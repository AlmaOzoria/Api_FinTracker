using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_FinTracker.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    categoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    tipo = table.Column<string>(type: "TEXT", nullable: false),
                    icono = table.Column<string>(type: "TEXT", nullable: false),
                    colorFondo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.categoriaId);
                });

            migrationBuilder.CreateTable(
                name: "MetaAhorro",
                columns: table => new
                {
                    metaAhorroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombreMeta = table.Column<string>(type: "TEXT", nullable: false),
                    montoObjetivo = table.Column<double>(type: "REAL", nullable: false),
                    fechaFinalizacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    contribucionRecurrente = table.Column<double>(type: "REAL", nullable: true),
                    imagen = table.Column<string>(type: "TEXT", nullable: true),
                    montoActual = table.Column<double>(type: "REAL", nullable: true),
                    montoAhorrado = table.Column<double>(type: "REAL", nullable: true),
                    fechaMontoAhorrado = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaAhorro", x => x.metaAhorroId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    usuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    apellido = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    contraseña = table.Column<string>(type: "TEXT", nullable: false),
                    fotoPerfil = table.Column<string>(type: "TEXT", nullable: true),
                    divisa = table.Column<string>(type: "TEXT", nullable: false),
                    saldoTotal = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.usuarioId);
                });

            migrationBuilder.CreateTable(
                name: "LimiteGasto",
                columns: table => new
                {
                    limiteGastoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    categoriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    montoLimite = table.Column<double>(type: "REAL", nullable: false),
                    periodo = table.Column<string>(type: "TEXT", nullable: false),
                    gastadoActual = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LimiteGasto", x => x.limiteGastoId);
                    table.ForeignKey(
                        name: "FK_LimiteGasto_Categoria_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categoria",
                        principalColumn: "categoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagoRecurrente",
                columns: table => new
                {
                    pagoRecurrenteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    monto = table.Column<double>(type: "REAL", nullable: false),
                    categoriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    frecuencia = table.Column<string>(type: "TEXT", nullable: false),
                    fechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    fechaFin = table.Column<DateTime>(type: "TEXT", nullable: true),
                    activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagoRecurrente", x => x.pagoRecurrenteId);
                    table.ForeignKey(
                        name: "FK_PagoRecurrente_Categoria_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categoria",
                        principalColumn: "categoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaccion",
                columns: table => new
                {
                    transaccionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    monto = table.Column<double>(type: "REAL", nullable: false),
                    categoriaId = table.Column<int>(type: "INTEGER", nullable: true),
                    fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    notas = table.Column<string>(type: "TEXT", nullable: true),
                    tipo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaccion", x => x.transaccionId);
                    table.ForeignKey(
                        name: "FK_Transaccion_Categoria_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categoria",
                        principalColumn: "categoriaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LimiteGasto_categoriaId",
                table: "LimiteGasto",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoRecurrente_categoriaId",
                table: "PagoRecurrente",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaccion_categoriaId",
                table: "Transaccion",
                column: "categoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LimiteGasto");

            migrationBuilder.DropTable(
                name: "MetaAhorro");

            migrationBuilder.DropTable(
                name: "PagoRecurrente");

            migrationBuilder.DropTable(
                name: "Transaccion");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
