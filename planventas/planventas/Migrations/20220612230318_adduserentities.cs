using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace planventas.Migrations
{
    public partial class adduserentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Document = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    LastName2 = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true),
                    Sexo = table.Column<string>(type: "varchar(10)", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pos_Padron",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true),
                    LastName2 = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pos_Padron", x => x.ID);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Pos_Entrenadores");

            migrationBuilder.DropTable(
                name: "Pos_Padron");

            migrationBuilder.DropTable(
                name: "Rm_Usuarios");

            migrationBuilder.DropTable(
                name: "Temporal_Sales");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Pos_Servicios");

            migrationBuilder.DropTable(
                name: "Pos_Instalaciones");

            migrationBuilder.DropTable(
                name: "Pos_Tipos_Instalacion");
        }
    }
}
