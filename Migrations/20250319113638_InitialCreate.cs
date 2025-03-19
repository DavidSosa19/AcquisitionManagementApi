using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AcquisitionManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "proveedores",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("proveedores_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipos_bien_servicio",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tipos_bien_servicio_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "unidades",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('unidad_id_seq'::regclass)"),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("unidad_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "adquisiciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    presupuesto = table.Column<decimal>(type: "numeric(30)", precision: 30, nullable: false),
                    unidad = table.Column<int>(type: "integer", nullable: false),
                    tipo_bien_servicio = table.Column<int>(type: "integer", nullable: false),
                    cantidad = table.Column<decimal>(type: "numeric(20)", precision: 20, nullable: false),
                    valor_unitario = table.Column<decimal>(type: "numeric(30)", precision: 30, nullable: false),
                    valor_total = table.Column<decimal>(type: "numeric(30)", precision: 30, nullable: false),
                    fecha_adquisicion = table.Column<DateOnly>(type: "date", nullable: false),
                    proveedor = table.Column<int>(type: "integer", nullable: false),
                    documentacion = table.Column<List<string>>(type: "character varying[]", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("adquisiciones_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_tipos_bien_servicio",
                        column: x => x.tipo_bien_servicio,
                        principalTable: "tipos_bien_servicio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_unidad",
                        column: x => x.unidad,
                        principalTable: "unidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fkey_proveedores",
                        column: x => x.proveedor,
                        principalTable: "proveedores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_adquisiciones_proveedor",
                table: "adquisiciones",
                column: "proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_adquisiciones_tipo_bien_servicio",
                table: "adquisiciones",
                column: "tipo_bien_servicio");

            migrationBuilder.CreateIndex(
                name: "IX_adquisiciones_unidad",
                table: "adquisiciones",
                column: "unidad");

            migrationBuilder.CreateIndex(
                name: "proveedores_nombre_key",
                table: "proveedores",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "tipos_bien_servicio_nombre_key",
                table: "tipos_bien_servicio",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unidad_nombre_key",
                table: "unidades",
                column: "nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adquisiciones");

            migrationBuilder.DropTable(
                name: "tipos_bien_servicio");

            migrationBuilder.DropTable(
                name: "unidades");

            migrationBuilder.DropTable(
                name: "proveedores");
        }
    }
}
