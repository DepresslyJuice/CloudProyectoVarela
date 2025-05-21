using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VarelaProyectoCloud.Migrations
{
    /// <inheritdoc />
    public partial class MigrationSqlServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "espacios",
                columns: table => new
                {
                    espacio_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_espacios", x => x.espacio_id);
                });

            migrationBuilder.CreateTable(
                name: "eventos",
                columns: table => new
                {
                    evento_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipo_evento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lugar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventos", x => x.evento_id);
                });

            migrationBuilder.CreateTable(
                name: "participantes",
                columns: table => new
                {
                    participante_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    institucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participantes", x => x.participante_id);
                });

            migrationBuilder.CreateTable(
                name: "ponentes",
                columns: table => new
                {
                    ponente_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    institucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ponentes", x => x.ponente_id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_inscripcion",
                columns: table => new
                {
                    tipo_inscripcion_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    detalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    costo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_inscripcion", x => x.tipo_inscripcion_id);
                });

            migrationBuilder.CreateTable(
                name: "sesiones",
                columns: table => new
                {
                    sesion_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    evento_id = table.Column<int>(type: "int", nullable: false),
                    espacio_id = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hora_inicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    hora_fin = table.Column<TimeSpan>(type: "time", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sesiones", x => x.sesion_id);
                    table.ForeignKey(
                        name: "FK_sesiones_espacios_espacio_id",
                        column: x => x.espacio_id,
                        principalTable: "espacios",
                        principalColumn: "espacio_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sesiones_eventos_evento_id",
                        column: x => x.evento_id,
                        principalTable: "eventos",
                        principalColumn: "evento_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inscripciones",
                columns: table => new
                {
                    inscripcion_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    participante_id = table.Column<int>(type: "int", nullable: false),
                    evento_id = table.Column<int>(type: "int", nullable: false),
                    fecha_inscripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo_inscripcion_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscripciones", x => x.inscripcion_id);
                    table.ForeignKey(
                        name: "FK_inscripciones_eventos_evento_id",
                        column: x => x.evento_id,
                        principalTable: "eventos",
                        principalColumn: "evento_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inscripciones_participantes_participante_id",
                        column: x => x.participante_id,
                        principalTable: "participantes",
                        principalColumn: "participante_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inscripciones_tipo_inscripcion_tipo_inscripcion_id",
                        column: x => x.tipo_inscripcion_id,
                        principalTable: "tipo_inscripcion",
                        principalColumn: "tipo_inscripcion_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ponentes_sesiones",
                columns: table => new
                {
                    ponente_id = table.Column<int>(type: "int", nullable: false),
                    sesion_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ponentes_sesiones", x => new { x.ponente_id, x.sesion_id });
                    table.ForeignKey(
                        name: "FK_ponentes_sesiones_ponentes_ponente_id",
                        column: x => x.ponente_id,
                        principalTable: "ponentes",
                        principalColumn: "ponente_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ponentes_sesiones_sesiones_sesion_id",
                        column: x => x.sesion_id,
                        principalTable: "sesiones",
                        principalColumn: "sesion_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asistencias",
                columns: table => new
                {
                    asistencia_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inscripcion_id = table.Column<int>(type: "int", nullable: false),
                    sesion_id = table.Column<int>(type: "int", nullable: false),
                    fecha_hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    asistio = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asistencias", x => x.asistencia_id);
                    table.ForeignKey(
                        name: "FK_asistencias_inscripciones_inscripcion_id",
                        column: x => x.inscripcion_id,
                        principalTable: "inscripciones",
                        principalColumn: "inscripcion_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_asistencias_sesiones_sesion_id",
                        column: x => x.sesion_id,
                        principalTable: "sesiones",
                        principalColumn: "sesion_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "certificados",
                columns: table => new
                {
                    certificado_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha_emision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    codigo_verificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url_certificado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inscripcion_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_certificados", x => x.certificado_id);
                    table.ForeignKey(
                        name: "FK_certificados_inscripciones_inscripcion_id",
                        column: x => x.inscripcion_id,
                        principalTable: "inscripciones",
                        principalColumn: "inscripcion_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pagos",
                columns: table => new
                {
                    pago_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inscripcion_id = table.Column<int>(type: "int", nullable: false),
                    monto = table.Column<double>(type: "float", nullable: false),
                    fecha_pago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    metodo_pago = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagos", x => x.pago_id);
                    table.ForeignKey(
                        name: "FK_pagos_inscripciones_inscripcion_id",
                        column: x => x.inscripcion_id,
                        principalTable: "inscripciones",
                        principalColumn: "inscripcion_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_asistencias_inscripcion_id",
                table: "asistencias",
                column: "inscripcion_id");

            migrationBuilder.CreateIndex(
                name: "IX_asistencias_sesion_id",
                table: "asistencias",
                column: "sesion_id");

            migrationBuilder.CreateIndex(
                name: "IX_certificados_inscripcion_id",
                table: "certificados",
                column: "inscripcion_id");

            migrationBuilder.CreateIndex(
                name: "IX_inscripciones_evento_id",
                table: "inscripciones",
                column: "evento_id");

            migrationBuilder.CreateIndex(
                name: "IX_inscripciones_participante_id",
                table: "inscripciones",
                column: "participante_id");

            migrationBuilder.CreateIndex(
                name: "IX_inscripciones_tipo_inscripcion_id",
                table: "inscripciones",
                column: "tipo_inscripcion_id");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_inscripcion_id",
                table: "pagos",
                column: "inscripcion_id");

            migrationBuilder.CreateIndex(
                name: "IX_ponentes_sesiones_sesion_id",
                table: "ponentes_sesiones",
                column: "sesion_id");

            migrationBuilder.CreateIndex(
                name: "IX_sesiones_espacio_id",
                table: "sesiones",
                column: "espacio_id");

            migrationBuilder.CreateIndex(
                name: "IX_sesiones_evento_id",
                table: "sesiones",
                column: "evento_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asistencias");

            migrationBuilder.DropTable(
                name: "certificados");

            migrationBuilder.DropTable(
                name: "pagos");

            migrationBuilder.DropTable(
                name: "ponentes_sesiones");

            migrationBuilder.DropTable(
                name: "inscripciones");

            migrationBuilder.DropTable(
                name: "ponentes");

            migrationBuilder.DropTable(
                name: "sesiones");

            migrationBuilder.DropTable(
                name: "participantes");

            migrationBuilder.DropTable(
                name: "tipo_inscripcion");

            migrationBuilder.DropTable(
                name: "espacios");

            migrationBuilder.DropTable(
                name: "eventos");
        }
    }
}
