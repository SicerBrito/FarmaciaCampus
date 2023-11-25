DROP DATABASE IF EXISTS FarmaciaCampusMysql;
CREATE DATABASE IF NOT EXISTS FarmaciaCampusMysql;
USE FarmaciaCampusMysql;

-- Tabla CargoEmpleado
CREATE TABLE CargoEmpleado (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(255)
);

-- Tabla CategoriaMedicamento
CREATE TABLE CategoriaMedicamento (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(255)
);

-- Tabla EstadoCita
CREATE TABLE EstadoCita (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(255)
);

-- Tabla Farmacia
CREATE TABLE Farmacia (
    Id INT PRIMARY KEY,
    NombreFarmacia VARCHAR(255),
    Propietario VARCHAR(255),
    FechaInauguracion DATE,
    NumeroContacto VARCHAR(255),
    URLSitioWeb VARCHAR(255)
);

-- Tabla Genero
CREATE TABLE Genero (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(255)
);

-- Tabla MetodoDePago
CREATE TABLE MetodoDePago (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(255)
);

-- Tabla Pais
CREATE TABLE Pais (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(255)
);

-- Tabla Presentacion
CREATE TABLE Presentacion (
    Id INT PRIMARY KEY,
    Descripcion VARCHAR(255)
);

-- Tabla Proveedor
CREATE TABLE Proveedor (
    Id INT PRIMARY KEY,
    Nombres VARCHAR(255),
    Apellidos VARCHAR(255),
    NroContacto VARCHAR(255)
);

-- Tabla TipoDireccion
CREATE TABLE TipoDireccion (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(255)
);

-- Tabla TipoMedicamento
CREATE TABLE TipoMedicamento (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(255)
);

-- Tabla TipoVia
CREATE TABLE TipoVia (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(255),
    Abreviatura VARCHAR(255)
);

-- Tabla Usuario
CREATE TABLE Usuario (
    Id_Usuario INT PRIMARY KEY,
    Username VARCHAR(255),
    Email VARCHAR(255),
    Password VARCHAR(255)
);

-- Tabla Rol
CREATE TABLE Rol (
    Id_Rol INT PRIMARY KEY,
    NombreRol VARCHAR(255)
);

-- Tabla UsuarioRol
CREATE TABLE UsuarioRol (
    Id_UsuarioRol INT PRIMARY KEY,
    Usuario_Id INT,
    Rol_Id INT
);

-- Tabla Empleado
CREATE TABLE Empleado (
    Id INT PRIMARY KEY,
    Nombres VARCHAR(255),
    Apellidos VARCHAR(255),
    Sueldo DECIMAL(10, 2),
    FechaContratacion DATE,
    FarmaciaId INT,
    CargoId INT
);

-- Tabla Departamento
CREATE TABLE Departamento (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(255),
    PaisId INT
);

-- Tabla Ciudad
CREATE TABLE Ciudad (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(255),
    DepartamentoId INT
);

-- Tabla Compra
CREATE TABLE Compra (
    Id INT PRIMARY KEY,
    NumeroFactura VARCHAR(255),
    FechaCompra DATE,
    ProveedorId INT,
    MetodoDePagoId INT
);

-- Tabla Medicamento
CREATE TABLE Medicamento (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(255),
    FechaExpiracion DATE,
    ValorUnidad DECIMAL(10, 2),
    TipoId INT,
    CategoriaId INT,
    PresentacionId INT,
    ProveedorId INT,
    Stock INT
);

-- Tabla Paciente
CREATE TABLE Paciente (
    Id INT PRIMARY KEY,
    Nombres VARCHAR(255),
    Apellidos VARCHAR(255),
    NumeroContacto VARCHAR(255),
    FechaNacimiento DATE,
    GeneroId INT
);

-- Tabla Cita
CREATE TABLE Cita (
    Id INT PRIMARY KEY,
    FechaCita DATE,
    EstadoCitaId INT,
    MedicoId INT,
    UsuarioId INT
);

-- Tabla Direccion
CREATE TABLE Direccion (
    Id INT PRIMARY KEY,
    NombreDireccion VARCHAR(255),
    NroDireccion VARCHAR(255),
    CodigoPostal VARCHAR(255),
    TipoDireccionId INT,
    TipoViaId INT,
    CiudadId INT,
    FarmaciaId INT
);

-- Tabla FormulaMedica
CREATE TABLE FormulaMedica (
    Id INT PRIMARY KEY,
    FechaPrescripcion DATE,
    PacienteId INT,
    MedicoId INT,
    Posologia TEXT,
    DuracionTratamiento INT,
    Indicaciones TEXT
);

-- Tabla FormulaMedicamentos
CREATE TABLE FormulaMedicamentos (
    Id INT PRIMARY KEY,
    FomulaMedicaId INT,
    MedicamentoId INT
);

-- Tabla Venta
CREATE TABLE Venta (
    Id INT PRIMARY KEY,
    NumeroFactura VARCHAR(255),
    FechaVenta DATE,
    ClienteId INT,
    VentaEmpleadoId INT,
    MetodoDePagoId INT
);

-- Tabla Inventario
CREATE TABLE Inventario (
    Id INT PRIMARY KEY,
    FarmaciaId INT,
    CompraId INT,
    VentaId INT
);

-- Tabla MedicamentosComprados
CREATE TABLE MedicamentosComprados (
    Id INT PRIMARY KEY,
    CantidadCompra INT,
    ValorTotalCompra DECIMAL(10, 2),
    CompraId INT,
    MedicamentoId INT
);

-- Tabla MedicamentosVendidos
CREATE TABLE MedicamentosVendidos (
    Id INT PRIMARY KEY,
    CantidadVendida INT,
    ValorTotalVenta DECIMAL(10, 2),
    VentaId INT,
    MedicamentoId INT
);

-- Datos de CargoEmpleado
INSERT INTO CargoEmpleado (Id, Nombre) VALUES
    (1, 'Medico'),
    (2, 'Farmaceutico'),
    (3, 'Cajero'),
    (4, 'Repartidor'),
    (5, 'Contador');

-- Datos de CategoriaMedicamento
INSERT INTO CategoriaMedicamento (Id, Nombre) VALUES
    (1, 'Analgesico'),
    (2, 'Antiinflamatorio'),
    (3, 'Antibiotico'),
    (4, 'Antiulceroso');

-- Inserta datos para otras tablas aquí...

-- Datos de EstadoCita
INSERT INTO EstadoCita (Id, Nombre) VALUES
    (1, 'Programada'),
    (2, 'Confirmada'),
    (3, 'No confirmada'),
    (4, 'Cancelada'),
    (5, 'Atendida'),
    (6, 'En espera'),
    (7, 'Reprogramada'),
    (8, 'Rechazada');

-- Datos de Farmacia
INSERT INTO Farmacia (Id, NombreFarmacia, Propietario, FechaInauguracion, NumeroContacto, URLSitioWeb) VALUES
    (1, 'FarmacooParte2', 'Sicer Andres Brito Gutierrez', '2023-09-25', '3208818203', 'https://github.com/SicerBrito');

-- Datos de Genero
INSERT INTO Genero (Id, Nombre) VALUES
    (1, 'Masculino'),
    (2, 'Femenino'),
    (3, 'Otro'),
    (4, 'Helicoptero'),
    (5, 'Prefiero no decirlo');

-- Datos de MetodoDePago
INSERT INTO MetodoDePago (Id, Nombre) VALUES
    (1, 'Tarjeta de credito'),
    (2, 'Tarjeta de debito'),
    (3, 'Efectivo'),
    (4, 'Cheque'),
    (5, 'Transferencia bancaria');

-- Datos de Pais
INSERT INTO Pais (Id, Nombre) VALUES
    (1, 'Estados Unidos'),
    (2, 'Canada'),
    (3, 'Mexico'),
    (4, 'Europa'),
    (5, 'Asia'),
    (6, 'Africa'),
    (7, 'Oceania'),
    (8, 'Australia'),
    (9, 'Brasil'),
    (10, 'China'),
    (11, 'India'),
    (12, 'Indonesia'),
    (13, 'Japon'),
    (14, 'Marruecos'),
    (15, 'Nigeria'),
    (16, 'Rusia'),
    (17, 'Sudafrica'),
    (18, 'Tailandia'),
    (19, 'Argentina'),
    (20, 'Austria'),
    (21, 'Belgica'),
    (22, 'Bulgaria'),
    (23, 'Chile'),
    (24, 'Colombia'),
    (25, 'Costa Rica');

-- Datos de Presentacion
INSERT INTO Presentacion (Id, Descripcion) VALUES
    (1, 'Caja de 30 tabletas'),
    (2, 'Botella de 100 capsulas'),
    (3, 'Caja de 50 tabletas'),
    (4, 'Botella de 30 capsulas'),
    (5, 'Caja de 60 capsulas');

-- Datos de Proveedor
INSERT INTO Proveedor (Id, Nombres, Apellidos, NroContacto) VALUES
    (1, 'Nombres Proveedor A', 'Apellido Proveedor A', '3208818203'),
    (2, 'Nombres Proveedor B', 'Apellido Proveedor B', '3208818203'),
    (3, 'Nombres Proveedor C', 'Apellido Proveedor C', '3208818203'),
    (4, 'Nombres Proveedor D', 'Apellido Proveedor D', '3208818203');

-- Datos de TipoDireccion
INSERT INTO TipoDireccion (Id, Nombre) VALUES
    (1, 'Residencial'),
    (2, 'Distrital'),
    (3, 'Oficina Principal'),
    (4, 'Comercial');

-- Datos de TipoMedicamento
INSERT INTO TipoMedicamento (Id, Nombre) VALUES
    (1, 'Tableta'),
    (2, 'Capsula');

-- Datos de TipoVia
INSERT INTO TipoVia (Id, Nombre, Abreviatura) VALUES
    (1, 'Calle', 'Cal'),
    (2, 'Avenida', 'Av'),
    (3, 'Boulevard', 'Blvd'),
    (4, 'Carretera', 'Carr'),
    (5, 'Paseo', 'Pso'),
    (6, 'Camino', 'Cam'),
    (7, 'Plaza', 'Plz'),
    (8, 'Via', 'Via');

-- Datos de Usuario
INSERT INTO Usuario (Id_Usuario, Username, Email, Password) VALUES
    (1, 'Sicer Brito', 'britodelgado514@gmail.com', '123456'),
    (2, 'Angelica Morales', 'angedeveloper@gmail.com', '123');

-- Datos de Rol
INSERT INTO Rol (Id_Rol, NombreRol) VALUES
    (1, 'Administrador'),
    (2, 'Gerente'),
    (3, 'Empleado');

-- Datos de UsuarioRol
INSERT INTO UsuarioRol (Id_UsuarioRol, Usuario_Id, Rol_Id) VALUES
    (1, 1, 1),
    (2, 2, 3);
