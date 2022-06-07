using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace planventas.Migrations
{
    public partial class Total : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pos_Tipos_Instalacion",
                columns: table => new
                {
                    Cod_TipoInstalacion = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Des_TipoInstalacion = table.Column<string>(type: "varchar(500)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(1)", nullable: true),
                    Fecha_Registro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Usuario_Registro = table.Column<string>(type: "varchar(50)", nullable: true),
                    Fecha_Borra = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Usuario_Borra = table.Column<string>(type: "varchar(50)", nullable: true),
                    Motivo_Borra = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pos_Tipos_Instalacion", x => x.Cod_TipoInstalacion);
                });

            migrationBuilder.CreateTable(
                name: "Rm_Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usuario_Registro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rm_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pos_Instalaciones",
                columns: table => new
                {
                    Cod_Instalacion = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_TipoInstalacion = table.Column<long>(type: "bigint", nullable: false),
                    Des_Instalacion = table.Column<string>(type: "varchar(900)", nullable: false),
                    Des_Direccion = table.Column<string>(type: "varchar(900)", nullable: false),
                    Num_Telefono = table.Column<string>(type: "varchar(20)", nullable: false),
                    Dir_Imagenes = table.Column<string>(type: "varchar(900)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(1)", nullable: true),
                    Fecha_Registro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Usuario_Registro = table.Column<string>(type: "varchar(50)", nullable: true),
                    Fecha_Borra = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Usuario_Borra = table.Column<string>(type: "varchar(50)", nullable: true),
                    Motivo_Borra = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pos_Instalaciones", x => x.Cod_Instalacion);
                    table.ForeignKey(
                        name: "FK_Pos_Instalaciones_Pos_Tipos_Instalacion_Cod_TipoInstalacion",
                        column: x => x.Cod_TipoInstalacion,
                        principalTable: "Pos_Tipos_Instalacion",
                        principalColumn: "Cod_TipoInstalacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pos_Entrenadores",
                columns: table => new
                {
                    Cod_Entrenador = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Instalacion = table.Column<long>(type: "bigint", nullable: false),
                    Nom_Entrenador = table.Column<string>(type: "varchar(900)", nullable: false),
                    Des_Perfil = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Dir_Imagen = table.Column<string>(type: "varchar(900)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(1)", nullable: true),
                    Fecha_Registro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Usuario_Registro = table.Column<string>(type: "varchar(50)", nullable: true),
                    Fecha_Borra = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Usuario_Borra = table.Column<string>(type: "varchar(50)", nullable: true),
                    Motivo_Borra = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pos_Entrenadores", x => x.Cod_Entrenador);
                    table.ForeignKey(
                        name: "FK_Pos_Entrenadores_Pos_Instalaciones_Cod_Instalacion",
                        column: x => x.Cod_Instalacion,
                        principalTable: "Pos_Instalaciones",
                        principalColumn: "Cod_Instalacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pos_Servicios",
                columns: table => new
                {
                    IdServicio = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Servicio = table.Column<int>(type: "int", nullable: false),
                    Cod_Instalacion = table.Column<long>(type: "bigint", nullable: false),
                    CodDia = table.Column<int>(type: "int", nullable: false),
                    Dia = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Horario = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Categoria = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Des_Servicio = table.Column<string>(type: "varchar(750)", maxLength: 750, nullable: false),
                    Tarifa = table.Column<decimal>(type: "money", nullable: false),
                    Cupos = table.Column<int>(type: "int", nullable: false),
                    Cod_Moneda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pos_Servicios", x => x.IdServicio);
                    table.ForeignKey(
                        name: "FK_Pos_Servicios_Pos_Instalaciones_Cod_Instalacion",
                        column: x => x.Cod_Instalacion,
                        principalTable: "Pos_Instalaciones",
                        principalColumn: "Cod_Instalacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temporal_Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductIdServicio = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temporal_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temporal_Sales_Pos_Servicios_ProductIdServicio",
                        column: x => x.ProductIdServicio,
                        principalTable: "Pos_Servicios",
                        principalColumn: "IdServicio",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pos_Entrenadores_Cod_Instalacion",
                table: "Pos_Entrenadores",
                column: "Cod_Instalacion");

            migrationBuilder.CreateIndex(
                name: "IX_Pos_Instalaciones_Cod_TipoInstalacion",
                table: "Pos_Instalaciones",
                column: "Cod_TipoInstalacion");

            migrationBuilder.CreateIndex(
                name: "IX_Pos_Servicios_Cod_Instalacion",
                table: "Pos_Servicios",
                column: "Cod_Instalacion");

            migrationBuilder.CreateIndex(
                name: "IX_Temporal_Sales_ProductIdServicio",
                table: "Temporal_Sales",
                column: "ProductIdServicio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pos_Entrenadores");

            migrationBuilder.DropTable(
                name: "Rm_Usuarios");

            migrationBuilder.DropTable(
                name: "Temporal_Sales");

            migrationBuilder.DropTable(
                name: "Pos_Servicios");

            migrationBuilder.DropTable(
                name: "Pos_Instalaciones");

            migrationBuilder.DropTable(
                name: "Pos_Tipos_Instalacion");
        }
    }
}
