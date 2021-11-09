using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P2_AP1_Vismar_20190425.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DescripcionProyecto = table.Column<string>(type: "TEXT", nullable: true),
                    Total = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.ProyectoId);
                });

            migrationBuilder.CreateTable(
                name: "TiposTareas",
                columns: table => new
                {
                    TipoTareaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DescripcionTipoTarea = table.Column<string>(type: "TEXT", nullable: true),
                    TiempoAcumulado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTareas", x => x.TipoTareaId);
                });

            migrationBuilder.CreateTable(
                name: "ProyectosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProyectoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoTareaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Requerimiento = table.Column<string>(type: "TEXT", nullable: true),
                    Tiempo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectosDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProyectosDetalle_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "ProyectoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProyectosDetalle_TiposTareas_TipoTareaId",
                        column: x => x.TipoTareaId,
                        principalTable: "TiposTareas",
                        principalColumn: "TipoTareaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposTareas",
                columns: new[] { "TipoTareaId", "DescripcionTipoTarea", "TiempoAcumulado" },
                values: new object[] { 1, "Analisis", 0 });

            migrationBuilder.InsertData(
                table: "TiposTareas",
                columns: new[] { "TipoTareaId", "DescripcionTipoTarea", "TiempoAcumulado" },
                values: new object[] { 2, "Diseño", 0 });

            migrationBuilder.InsertData(
                table: "TiposTareas",
                columns: new[] { "TipoTareaId", "DescripcionTipoTarea", "TiempoAcumulado" },
                values: new object[] { 3, "Programacion", 0 });

            migrationBuilder.InsertData(
                table: "TiposTareas",
                columns: new[] { "TipoTareaId", "DescripcionTipoTarea", "TiempoAcumulado" },
                values: new object[] { 4, "Prueba", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_ProyectosDetalle_ProyectoId",
                table: "ProyectosDetalle",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectosDetalle_TipoTareaId",
                table: "ProyectosDetalle",
                column: "TipoTareaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProyectosDetalle");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "TiposTareas");
        }
    }
}
