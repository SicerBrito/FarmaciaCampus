using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CargoEmpleado",
                columns: table => new
                {
                    IdCargoEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreCargo = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoEmpleado", x => x.IdCargoEmpleado);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoriaMedicamento",
                columns: table => new
                {
                    IdCategoriaMedicamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreMedicamento = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaMedicamento", x => x.IdCategoriaMedicamento);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstadoCita",
                columns: table => new
                {
                    IdEstadoCita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreEstado = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCita", x => x.IdEstadoCita);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Farmacia",
                columns: table => new
                {
                    IdFarmacia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreFarmacia = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Propietario = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaInauguracion = table.Column<DateTime>(type: "DateTime", nullable: false),
                    NumeroContacto = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    URLSitioWeb = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmacia", x => x.IdFarmacia);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreGenero = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.IdGenero);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MetodoDePago",
                columns: table => new
                {
                    IdMetodoDePago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreMetodo = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoDePago", x => x.IdMetodoDePago);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    IdPais = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombrePais = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.IdPais);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Presentacion",
                columns: table => new
                {
                    IdPresentacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentacion", x => x.IdPresentacion);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombres = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellidos = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NroContacto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.IdProveedor);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id_Rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreRol = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id_Rol);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoDireccion",
                columns: table => new
                {
                    IdTipoDireccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreDireccion = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDireccion", x => x.IdTipoDireccion);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoMedicamento",
                columns: table => new
                {
                    IdTipoMedicamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMedicamento", x => x.IdTipoMedicamento);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoVia",
                columns: table => new
                {
                    IdTipoVia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipoVia = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abreviatura = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVia", x => x.IdTipoVia);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id_Usuario);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Farmacia_Id = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellidos = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cargo_Id = table.Column<int>(type: "int", nullable: false),
                    Sueldo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaContratacion = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleado_CargoEmpleado_Cargo_Id",
                        column: x => x.Cargo_Id,
                        principalTable: "CargoEmpleado",
                        principalColumn: "IdCargoEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleado_Farmacia_Farmacia_Id",
                        column: x => x.Farmacia_Id,
                        principalTable: "Farmacia",
                        principalColumn: "IdFarmacia",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombres = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellidos = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NroContacto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Genero_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.IdPaciente);
                    table.ForeignKey(
                        name: "FK_Paciente_Genero_Genero_Id",
                        column: x => x.Genero_Id,
                        principalTable: "Genero",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    IdDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreDepartamento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pais_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.IdDepartamento);
                    table.ForeignKey(
                        name: "FK_Departamento_Pais_Pais_Id",
                        column: x => x.Pais_Id,
                        principalTable: "Pais",
                        principalColumn: "IdPais",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCompra = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Proveedor_Id = table.Column<int>(type: "int", nullable: false),
                    MetodoDePago_Id = table.Column<int>(type: "int", nullable: false),
                    NumeroFactura = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_Compra_MetodoDePago_MetodoDePago_Id",
                        column: x => x.MetodoDePago_Id,
                        principalTable: "MetodoDePago",
                        principalColumn: "IdMetodoDePago",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compra_Proveedor_Proveedor_Id",
                        column: x => x.Proveedor_Id,
                        principalTable: "Proveedor",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    IdMedicamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreMedicamento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoMedicamento_Id = table.Column<int>(type: "int", nullable: false),
                    CategoriaMedicamento_Id = table.Column<int>(type: "int", nullable: false),
                    PresentacionMedicamento_Id = table.Column<int>(type: "int", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ValorUnidad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Proveedor_Id = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.IdMedicamento);
                    table.ForeignKey(
                        name: "FK_Medicamento_CategoriaMedicamento_CategoriaMedicamento_Id",
                        column: x => x.CategoriaMedicamento_Id,
                        principalTable: "CategoriaMedicamento",
                        principalColumn: "IdCategoriaMedicamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicamento_Presentacion_PresentacionMedicamento_Id",
                        column: x => x.PresentacionMedicamento_Id,
                        principalTable: "Presentacion",
                        principalColumn: "IdPresentacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicamento_Proveedor_Proveedor_Id",
                        column: x => x.Proveedor_Id,
                        principalTable: "Proveedor",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicamento_TipoMedicamento_TipoMedicamento_Id",
                        column: x => x.TipoMedicamento_Id,
                        principalTable: "TipoMedicamento",
                        principalColumn: "IdTipoMedicamento",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RolUsuario",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuario", x => new { x.RolesId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_RolUsuario_Rol_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Rol",
                        principalColumn: "Id_Rol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUsuario_Usuario_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioRol",
                columns: table => new
                {
                    Id_UsuarioRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    Rol_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRol", x => x.Id_UsuarioRol);
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Rol_Rol_Id",
                        column: x => x.Rol_Id,
                        principalTable: "Rol",
                        principalColumn: "Id_Rol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Usuario_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    IdCita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCita = table.Column<DateTime>(type: "DateTime", nullable: false),
                    EstadoCita_Id = table.Column<int>(type: "int", nullable: false),
                    Medico_Id = table.Column<int>(type: "int", nullable: false),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.IdCita);
                    table.ForeignKey(
                        name: "FK_Cita_Empleado_Medico_Id",
                        column: x => x.Medico_Id,
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_EstadoCita_EstadoCita_Id",
                        column: x => x.EstadoCita_Id,
                        principalTable: "EstadoCita",
                        principalColumn: "IdEstadoCita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_Usuario_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaVenta = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Cliente_Id = table.Column<int>(type: "int", nullable: false),
                    VentaEmpleado_Id = table.Column<int>(type: "int", nullable: false),
                    MetodoDePago_Id = table.Column<int>(type: "int", nullable: false),
                    NumeroFactura = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.IdVenta);
                    table.ForeignKey(
                        name: "FK_Venta_Empleado_VentaEmpleado_Id",
                        column: x => x.VentaEmpleado_Id,
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_MetodoDePago_MetodoDePago_Id",
                        column: x => x.MetodoDePago_Id,
                        principalTable: "MetodoDePago",
                        principalColumn: "IdMetodoDePago",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_Usuario_Cliente_Id",
                        column: x => x.Cliente_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FormulaMedica",
                columns: table => new
                {
                    IdFormulaMedica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Paciente_Id = table.Column<int>(type: "int", nullable: false),
                    FechaPrescripcion = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Medico_Id = table.Column<int>(type: "int", nullable: false),
                    Posologia = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DuracionTratamiento = table.Column<int>(type: "int", nullable: false),
                    Indicaciones = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulaMedica", x => x.IdFormulaMedica);
                    table.ForeignKey(
                        name: "FK_FormulaMedica_Empleado_Medico_Id",
                        column: x => x.Medico_Id,
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormulaMedica_Paciente_Paciente_Id",
                        column: x => x.Paciente_Id,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HistorialMedico",
                columns: table => new
                {
                    IdHistorialMedico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Paciente_Id = table.Column<int>(type: "int", nullable: false),
                    Medico_Id = table.Column<int>(type: "int", nullable: false),
                    Diagnostico = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tratamiento = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observaciones = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialMedico", x => x.IdHistorialMedico);
                    table.ForeignKey(
                        name: "FK_HistorialMedico_Empleado_Medico_Id",
                        column: x => x.Medico_Id,
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialMedico_Paciente_Paciente_Id",
                        column: x => x.Paciente_Id,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    IdCiudad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreCiudad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Departamento_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.IdCiudad);
                    table.ForeignKey(
                        name: "FK_Ciudad_Departamento_Departamento_Id",
                        column: x => x.Departamento_Id,
                        principalTable: "Departamento",
                        principalColumn: "IdDepartamento",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicamentosComprados",
                columns: table => new
                {
                    IdMedicamentosComprados = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Compra_Id = table.Column<int>(type: "int", nullable: false),
                    Medico_Id = table.Column<int>(type: "int", nullable: false),
                    CantidadCompra = table.Column<int>(type: "int", nullable: false),
                    ValorTotalCompra = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentosComprados", x => x.IdMedicamentosComprados);
                    table.ForeignKey(
                        name: "FK_MedicamentosComprados_Compra_Compra_Id",
                        column: x => x.Compra_Id,
                        principalTable: "Compra",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicamentosComprados_Medicamento_Medico_Id",
                        column: x => x.Medico_Id,
                        principalTable: "Medicamento",
                        principalColumn: "IdMedicamento",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    IdInventario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Farmacia_Id = table.Column<int>(type: "int", nullable: false),
                    Compra_Id = table.Column<int>(type: "int", nullable: false),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.IdInventario);
                    table.ForeignKey(
                        name: "FK_Inventario_Compra_Compra_Id",
                        column: x => x.Compra_Id,
                        principalTable: "Compra",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventario_Farmacia_Farmacia_Id",
                        column: x => x.Farmacia_Id,
                        principalTable: "Farmacia",
                        principalColumn: "IdFarmacia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventario_Venta_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Venta",
                        principalColumn: "IdVenta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicamentosVendidos",
                columns: table => new
                {
                    IdMedicamentosVendidos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Venta_Id = table.Column<int>(type: "int", nullable: false),
                    Medicamento_Id = table.Column<int>(type: "int", nullable: false),
                    CantidadVendida = table.Column<int>(type: "int", nullable: false),
                    ValorTotalVenta = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentosVendidos", x => x.IdMedicamentosVendidos);
                    table.ForeignKey(
                        name: "FK_MedicamentosVendidos_Medicamento_Medicamento_Id",
                        column: x => x.Medicamento_Id,
                        principalTable: "Medicamento",
                        principalColumn: "IdMedicamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicamentosVendidos_Venta_Venta_Id",
                        column: x => x.Venta_Id,
                        principalTable: "Venta",
                        principalColumn: "IdVenta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FormulaMedicamentos",
                columns: table => new
                {
                    IdFormulaMedicamentos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FomulaMedica_Id = table.Column<int>(type: "int", nullable: false),
                    Medicamento_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulaMedicamentos", x => x.IdFormulaMedicamentos);
                    table.ForeignKey(
                        name: "FK_FormulaMedicamentos_FormulaMedica_FomulaMedica_Id",
                        column: x => x.FomulaMedica_Id,
                        principalTable: "FormulaMedica",
                        principalColumn: "IdFormulaMedica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormulaMedicamentos_Medicamento_Medicamento_Id",
                        column: x => x.Medicamento_Id,
                        principalTable: "Medicamento",
                        principalColumn: "IdMedicamento",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    IdDireccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoDireccion_Id = table.Column<int>(type: "int", nullable: false),
                    TipoVia_Id = table.Column<int>(type: "int", nullable: false),
                    NroDireccion = table.Column<int>(type: "int", nullable: false),
                    Ciudad_Id = table.Column<int>(type: "int", nullable: false),
                    CodigoPostal = table.Column<int>(type: "int", nullable: false),
                    Farmacia_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.IdDireccion);
                    table.ForeignKey(
                        name: "FK_Direccion_Ciudad_Ciudad_Id",
                        column: x => x.Ciudad_Id,
                        principalTable: "Ciudad",
                        principalColumn: "IdCiudad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Direccion_Farmacia_Farmacia_Id",
                        column: x => x.Farmacia_Id,
                        principalTable: "Farmacia",
                        principalColumn: "IdFarmacia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Direccion_TipoDireccion_TipoDireccion_Id",
                        column: x => x.TipoDireccion_Id,
                        principalTable: "TipoDireccion",
                        principalColumn: "IdTipoDireccion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Direccion_TipoVia_TipoVia_Id",
                        column: x => x.TipoVia_Id,
                        principalTable: "TipoVia",
                        principalColumn: "IdTipoVia",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CargoEmpleado",
                columns: new[] { "IdCargoEmpleado", "NombreCargo" },
                values: new object[,]
                {
                    { 1, "Medico" },
                    { 2, "Farmaceutico" },
                    { 3, "Cajero" },
                    { 4, "Repartidor" },
                    { 5, "Contador" }
                });

            migrationBuilder.InsertData(
                table: "CategoriaMedicamento",
                columns: new[] { "IdCategoriaMedicamento", "NombreMedicamento" },
                values: new object[,]
                {
                    { 1, "Analgesico" },
                    { 2, "Antiinflamatorio" },
                    { 3, "Antibiotico" },
                    { 4, "Antiulceroso" }
                });

            migrationBuilder.InsertData(
                table: "EstadoCita",
                columns: new[] { "IdEstadoCita", "NombreEstado" },
                values: new object[,]
                {
                    { 1, "Programada" },
                    { 2, "Confirmada" },
                    { 3, "No confirmada" },
                    { 4, "Cancelada" },
                    { 5, "Atendida" },
                    { 6, "En espera" },
                    { 7, "Reprogramada" },
                    { 8, "Rechazada" }
                });

            migrationBuilder.InsertData(
                table: "Farmacia",
                columns: new[] { "IdFarmacia", "FechaInauguracion", "NombreFarmacia", "NumeroContacto", "Propietario", "URLSitioWeb" },
                values: new object[] { 1, new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "FarmacooParte2", "3208818203", "Sicer Andres Brito Gutierrez", "https://github.com/SicerBrito" });

            migrationBuilder.InsertData(
                table: "Genero",
                columns: new[] { "IdGenero", "NombreGenero" },
                values: new object[,]
                {
                    { 1, "Masculino" },
                    { 2, "Femenino" },
                    { 3, "Otro" },
                    { 4, "Helicoptero" },
                    { 5, "Prefiero no decirlo" }
                });

            migrationBuilder.InsertData(
                table: "MetodoDePago",
                columns: new[] { "IdMetodoDePago", "NombreMetodo" },
                values: new object[,]
                {
                    { 1, "Tarjeta de credito" },
                    { 2, "Tarjeta de debito" },
                    { 3, "Efectivo" },
                    { 4, "Cheque" },
                    { 5, "Transferencia bancaria" }
                });

            migrationBuilder.InsertData(
                table: "Pais",
                columns: new[] { "IdPais", "NombrePais" },
                values: new object[,]
                {
                    { 1, "Estados Unidos" },
                    { 2, "Canada" },
                    { 3, "Mexico" },
                    { 4, "Europa" },
                    { 5, "Asia" },
                    { 6, "Africa" },
                    { 7, "Oceania" },
                    { 8, "Australia" },
                    { 9, "Brasil" },
                    { 10, "China" },
                    { 11, "India" },
                    { 12, "Indonesia" },
                    { 13, "Japon" },
                    { 14, "Marruecos" },
                    { 15, "Nigeria" },
                    { 16, "Rusia" },
                    { 17, "Sudafrica" },
                    { 18, "Tailandia" },
                    { 19, "Argentina" },
                    { 20, "Austria" },
                    { 21, "Belgica" },
                    { 22, "Bulgaria" },
                    { 23, "Chile" },
                    { 24, "Colombia" },
                    { 25, "Costa Rica" }
                });

            migrationBuilder.InsertData(
                table: "Presentacion",
                columns: new[] { "IdPresentacion", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Caja de 30 tabletas" },
                    { 2, "Botella de 100 capsulas" },
                    { 3, "Caja de 50 tabletas" },
                    { 4, "Botella de 30 capsulas" },
                    { 5, "Caja de 60 capsulas" }
                });

            migrationBuilder.InsertData(
                table: "Proveedor",
                columns: new[] { "IdProveedor", "Apellidos", "Nombres", "NroContacto" },
                values: new object[,]
                {
                    { 1, "Apellido Proveedor A", "Nombres Proveedor A", "3208818203" },
                    { 2, "Apellido Proveedor B", "Nombres Proveedor B", "3208818203" },
                    { 3, "Apellido Proveedor C", "Nombres Proveedor C", "3208818203" },
                    { 4, "Apellido Proveedor D", "Nombres Proveedor D", "3208818203" },
                    { 5, "ApellidoA", "ProveedorA", "3208818203" }
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id_Rol", "NombreRol" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Gerente" },
                    { 3, "Empleado" }
                });

            migrationBuilder.InsertData(
                table: "TipoDireccion",
                columns: new[] { "IdTipoDireccion", "NombreDireccion" },
                values: new object[,]
                {
                    { 1, "Residencial" },
                    { 2, "Distrital" },
                    { 3, "Oficina Principal" },
                    { 4, "Comercial" }
                });

            migrationBuilder.InsertData(
                table: "TipoMedicamento",
                columns: new[] { "IdTipoMedicamento", "NombreTipo" },
                values: new object[,]
                {
                    { 1, "Tableta" },
                    { 2, "Capsula" }
                });

            migrationBuilder.InsertData(
                table: "TipoVia",
                columns: new[] { "IdTipoVia", "Abreviatura", "NombreTipoVia" },
                values: new object[,]
                {
                    { 1, "Cal", "Calle" },
                    { 2, "Av", "Avenida" },
                    { 3, "Blvd", "Boulevard" },
                    { 4, "Carr", "Carretera" },
                    { 5, "Pso", "Paseo" },
                    { 6, "Cam", "Camino" },
                    { 7, "Plz", "Plaza" },
                    { 8, "Via", "Via" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id_Usuario", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "britodelgado514@gmail.com", "123456", "Sicer Brito" },
                    { 2, "angedeveloper@gmail.com", "123", "Angelica Morales" }
                });

            migrationBuilder.InsertData(
                table: "Compra",
                columns: new[] { "IdCompra", "FechaCompra", "MetodoDePago_Id", "NumeroFactura", "Proveedor_Id" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "1112245", 1 },
                    { 2, new DateTime(2023, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "324324234", 2 },
                    { 3, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "3245435325", 4 },
                    { 4, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "3453245435", 3 },
                    { 5, new DateTime(2023, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "4343255", 2 },
                    { 6, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "345325345", 1 },
                    { 7, new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "34523452345", 2 }
                });

            migrationBuilder.InsertData(
                table: "Departamento",
                columns: new[] { "IdDepartamento", "NombreDepartamento", "Pais_Id" },
                values: new object[,]
                {
                    { 1, "Putumayo", 24 },
                    { 2, "Huila", 24 },
                    { 3, "La Guajira", 24 },
                    { 4, "Magdalena", 24 },
                    { 5, "Meta", 24 },
                    { 6, "Santander", 24 }
                });

            migrationBuilder.InsertData(
                table: "Empleado",
                columns: new[] { "IdEmpleado", "Apellidos", "Cargo_Id", "Farmacia_Id", "FechaContratacion", "Nombres", "Sueldo" },
                values: new object[,]
                {
                    { 1, "Perez Numa", 1, 1, new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan David", "5000000" },
                    { 2, "Alucema Torres", 1, 1, new DateTime(2024, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Konny Liseth", "2000000" },
                    { 3, "Morales Silva", 2, 1, new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria Angelica", "2200000" }
                });

            migrationBuilder.InsertData(
                table: "Medicamento",
                columns: new[] { "IdMedicamento", "CategoriaMedicamento_Id", "FechaExpiracion", "NombreMedicamento", "PresentacionMedicamento_Id", "Proveedor_Id", "Stock", "TipoMedicamento_Id", "ValorUnidad" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aspirina", 2, 2, 80L, 1, "2000" },
                    { 2, 2, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ibuprofeno", 2, 2, 20L, 2, "5000" },
                    { 3, 1, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paracetamol", 2, 2, 45L, 1, "1000" },
                    { 4, 3, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoxicilina", 2, 2, 70L, 2, "3500" },
                    { 5, 4, new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Omeprazol", 2, 2, 10L, 2, "2200" }
                });

            migrationBuilder.InsertData(
                table: "Paciente",
                columns: new[] { "IdPaciente", "Apellidos", "FechaNacimiento", "Genero_Id", "Nombres", "NroContacto" },
                values: new object[,]
                {
                    { 1, "Polanco Silva", new DateTime(2003, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Owell Andry", "3221243579" },
                    { 2, "Torres Alvares", new DateTime(2003, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sherman Andres", "6355050" }
                });

            migrationBuilder.InsertData(
                table: "UsuarioRol",
                columns: new[] { "Id_UsuarioRol", "Rol_Id", "Usuario_Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Cita",
                columns: new[] { "IdCita", "EstadoCita_Id", "FechaCita", "Medico_Id", "Usuario_Id" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 2, 6, new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Ciudad",
                columns: new[] { "IdCiudad", "Departamento_Id", "NombreCiudad" },
                values: new object[,]
                {
                    { 1, 6, "Bogota" },
                    { 2, 2, "Medellin" },
                    { 3, 4, "Cartagena" },
                    { 4, 1, "Cali" },
                    { 5, 2, "Barranquilla" },
                    { 6, 4, "Santa Marta" },
                    { 7, 6, "Bucaramanga" }
                });

            migrationBuilder.InsertData(
                table: "FormulaMedica",
                columns: new[] { "IdFormulaMedica", "DuracionTratamiento", "FechaPrescripcion", "Indicaciones", "Medico_Id", "Paciente_Id", "Posologia" },
                values: new object[,]
                {
                    { 1, 30, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hipertension, Diabetes", 2, 2, "Aspirina: 1 tableta diaria después de la comida" },
                    { 2, 90, new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chequeo de rutina", 2, 1, "Ventolin: 2 inhalaciones cuando sea necesario" }
                });

            migrationBuilder.InsertData(
                table: "HistorialMedico",
                columns: new[] { "IdHistorialMedico", "Diagnostico", "Medico_Id", "Observaciones", "Paciente_Id", "Tratamiento" },
                values: new object[,]
                {
                    { 1, "Hipertensión, Diabetes", 1, "Paciente en seguimiento regular", 1, "Medicamentos recetados, dieta, ejercicio" },
                    { 2, "Asma, Alergias", 1, "Ocasionales episodios asmáticos.", 1, "Inhalador de rescate, evitar alérgenos " },
                    { 3, "Sin problemas de salud", 1, "Chequeo de rutina sin novedades", 1, "Medicamento, control de presión " }
                });

            migrationBuilder.InsertData(
                table: "MedicamentosComprados",
                columns: new[] { "IdMedicamentosComprados", "CantidadCompra", "Compra_Id", "Medico_Id", "ValorTotalCompra" },
                values: new object[,]
                {
                    { 1, 5, 1, 5, "50000" },
                    { 2, 2, 2, 1, "60000" },
                    { 3, 21, 1, 3, "21000" }
                });

            migrationBuilder.InsertData(
                table: "Venta",
                columns: new[] { "IdVenta", "Cliente_Id", "FechaVenta", "MetodoDePago_Id", "NumeroFactura", "VentaEmpleado_Id" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "5363634231", 2 },
                    { 2, 1, new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "473567356465", 2 }
                });

            migrationBuilder.InsertData(
                table: "Direccion",
                columns: new[] { "IdDireccion", "Ciudad_Id", "CodigoPostal", "Farmacia_Id", "Direccion", "NroDireccion", "TipoDireccion_Id", "TipoVia_Id" },
                values: new object[,]
                {
                    { 1, 7, 680001, 1, "Cristal Alto Casa 1 piso2 Peatonal", 5, 1, 1 },
                    { 2, 7, 680001, 1, "Barrio Santa Ana", 249, 1, 8 }
                });

            migrationBuilder.InsertData(
                table: "FormulaMedicamentos",
                columns: new[] { "IdFormulaMedicamentos", "FomulaMedica_Id", "Medicamento_Id" },
                values: new object[,]
                {
                    { 1, 1, 4 },
                    { 2, 2, 1 },
                    { 3, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Inventario",
                columns: new[] { "IdInventario", "Compra_Id", "Farmacia_Id", "Usuario_Id" },
                values: new object[,]
                {
                    { 1, 5, 1, 2 },
                    { 2, 7, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "MedicamentosVendidos",
                columns: new[] { "IdMedicamentosVendidos", "CantidadVendida", "Medicamento_Id", "ValorTotalVenta", "Venta_Id" },
                values: new object[,]
                {
                    { 1, 2, 1, "60000", 1 },
                    { 2, 21, 3, "21000", 2 },
                    { 3, 5, 5, "50000", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cita_EstadoCita_Id",
                table: "Cita",
                column: "EstadoCita_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_Medico_Id",
                table: "Cita",
                column: "Medico_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_Usuario_Id",
                table: "Cita",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_Departamento_Id",
                table: "Ciudad",
                column: "Departamento_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_MetodoDePago_Id",
                table: "Compra",
                column: "MetodoDePago_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_Proveedor_Id",
                table: "Compra",
                column: "Proveedor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_Pais_Id",
                table: "Departamento",
                column: "Pais_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_Ciudad_Id",
                table: "Direccion",
                column: "Ciudad_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_Farmacia_Id",
                table: "Direccion",
                column: "Farmacia_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_TipoDireccion_Id",
                table: "Direccion",
                column: "TipoDireccion_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_TipoVia_Id",
                table: "Direccion",
                column: "TipoVia_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_Cargo_Id",
                table: "Empleado",
                column: "Cargo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_Farmacia_Id",
                table: "Empleado",
                column: "Farmacia_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaMedica_Medico_Id",
                table: "FormulaMedica",
                column: "Medico_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaMedica_Paciente_Id",
                table: "FormulaMedica",
                column: "Paciente_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaMedicamentos_FomulaMedica_Id",
                table: "FormulaMedicamentos",
                column: "FomulaMedica_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaMedicamentos_Medicamento_Id",
                table: "FormulaMedicamentos",
                column: "Medicamento_Id");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialMedico_Medico_Id",
                table: "HistorialMedico",
                column: "Medico_Id");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialMedico_Paciente_Id",
                table: "HistorialMedico",
                column: "Paciente_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_Compra_Id",
                table: "Inventario",
                column: "Compra_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_Farmacia_Id",
                table: "Inventario",
                column: "Farmacia_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_Usuario_Id",
                table: "Inventario",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_CategoriaMedicamento_Id",
                table: "Medicamento",
                column: "CategoriaMedicamento_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_PresentacionMedicamento_Id",
                table: "Medicamento",
                column: "PresentacionMedicamento_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_Proveedor_Id",
                table: "Medicamento",
                column: "Proveedor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_TipoMedicamento_Id",
                table: "Medicamento",
                column: "TipoMedicamento_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentosComprados_Compra_Id",
                table: "MedicamentosComprados",
                column: "Compra_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentosComprados_Medico_Id",
                table: "MedicamentosComprados",
                column: "Medico_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentosVendidos_Medicamento_Id",
                table: "MedicamentosVendidos",
                column: "Medicamento_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentosVendidos_Venta_Id",
                table: "MedicamentosVendidos",
                column: "Venta_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_Genero_Id",
                table: "Paciente",
                column: "Genero_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuario_UsuariosId",
                table: "RolUsuario",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_Rol_Id",
                table: "UsuarioRol",
                column: "Rol_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_Usuario_Id",
                table: "UsuarioRol",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_Cliente_Id",
                table: "Venta",
                column: "Cliente_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_MetodoDePago_Id",
                table: "Venta",
                column: "MetodoDePago_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_VentaEmpleado_Id",
                table: "Venta",
                column: "VentaEmpleado_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "FormulaMedicamentos");

            migrationBuilder.DropTable(
                name: "HistorialMedico");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "MedicamentosComprados");

            migrationBuilder.DropTable(
                name: "MedicamentosVendidos");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "RolUsuario");

            migrationBuilder.DropTable(
                name: "UsuarioRol");

            migrationBuilder.DropTable(
                name: "EstadoCita");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "TipoDireccion");

            migrationBuilder.DropTable(
                name: "TipoVia");

            migrationBuilder.DropTable(
                name: "FormulaMedica");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "CategoriaMedicamento");

            migrationBuilder.DropTable(
                name: "Presentacion");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "TipoMedicamento");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "MetodoDePago");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "CargoEmpleado");

            migrationBuilder.DropTable(
                name: "Farmacia");
        }
    }
}
