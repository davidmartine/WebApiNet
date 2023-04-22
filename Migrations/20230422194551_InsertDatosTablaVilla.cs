using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiNet.Migrations
{
    public partial class InsertDatosTablaVilla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[] { 1, "", "Detalle de la villa", new DateTime(2023, 4, 22, 14, 45, 51, 576, DateTimeKind.Local).AddTicks(1993), new DateTime(2023, 4, 22, 14, 45, 51, 576, DateTimeKind.Local).AddTicks(1982), "", 50, "Villa", 5, 200.0 });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[] { 2, "", "Detalle de la villa prueba n1", new DateTime(2023, 4, 22, 14, 45, 51, 576, DateTimeKind.Local).AddTicks(1996), new DateTime(2023, 4, 22, 14, 45, 51, 576, DateTimeKind.Local).AddTicks(1995), "", 30, "Prueba de viilla", 5, 100.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
