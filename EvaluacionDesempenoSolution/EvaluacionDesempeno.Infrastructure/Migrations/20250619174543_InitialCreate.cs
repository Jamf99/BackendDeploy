using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluacionDesempeno.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CiclosEvaluativos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Anio = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CiclosEvaluativos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelosEvaluativos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreModelo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelosEvaluativos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GruposEvaluativos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CicloEvaluativoId = table.Column<int>(type: "INTEGER", nullable: false),
                    NombreGrupo = table.Column<string>(type: "TEXT", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposEvaluativos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GruposEvaluativos_CiclosEvaluativos_CicloEvaluativoId",
                        column: x => x.CicloEvaluativoId,
                        principalTable: "CiclosEvaluativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCargo = table.Column<string>(type: "TEXT", nullable: false),
                    ModeloEvaluativoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargos_ModelosEvaluativos_ModeloEvaluativoId",
                        column: x => x.ModeloEvaluativoId,
                        principalTable: "ModelosEvaluativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    CargoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaboradores_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuestionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CargoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Pregunta = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuestionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuestionarios_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GrupoEvaluativoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ColaboradorId = table.Column<int>(type: "INTEGER", nullable: false),
                    EvaluadorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluaciones_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluaciones_GruposEvaluativos_GrupoEvaluativoId",
                        column: x => x.GrupoEvaluativoId,
                        principalTable: "GruposEvaluativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EvaluacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    CuestionarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    Calificacion = table.Column<int>(type: "INTEGER", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respuestas_Cuestionarios_CuestionarioId",
                        column: x => x.CuestionarioId,
                        principalTable: "Cuestionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Respuestas_Evaluaciones_EvaluacionId",
                        column: x => x.EvaluacionId,
                        principalTable: "Evaluaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_ModeloEvaluativoId",
                table: "Cargos",
                column: "ModeloEvaluativoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_CargoId",
                table: "Colaboradores",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuestionarios_CargoId",
                table: "Cuestionarios",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_ColaboradorId",
                table: "Evaluaciones",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_GrupoEvaluativoId",
                table: "Evaluaciones",
                column: "GrupoEvaluativoId");

            migrationBuilder.CreateIndex(
                name: "IX_GruposEvaluativos_CicloEvaluativoId",
                table: "GruposEvaluativos",
                column: "CicloEvaluativoId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_CuestionarioId",
                table: "Respuestas",
                column: "CuestionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_EvaluacionId",
                table: "Respuestas",
                column: "EvaluacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "Cuestionarios");

            migrationBuilder.DropTable(
                name: "Evaluaciones");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "GruposEvaluativos");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "CiclosEvaluativos");

            migrationBuilder.DropTable(
                name: "ModelosEvaluativos");
        }
    }
}
