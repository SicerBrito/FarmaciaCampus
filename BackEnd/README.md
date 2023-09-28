# skeleton-app-webapi

dotnet ef migrations add InitialCreate --project ./Persistencia/ --startup-project ./API/ --output-dir ./Data/Migrations/

dotnet ef database update --project ./Persistencia/ --startup-project ./API/  


[
  {
    "nombres": "Nombres Proveedor A Apellido Proveedor A",
    "apellidos": "3208818203",
    "nroContacto": null,
    "compras": [
      {
        "fechaCompra": "2023-02-04T00:00:00",
        "proveedorId": 1,
        "proveedores": null,
        "metodoDePagoId": 2,
        "metodosDePagos": null,
        "numeroFactura": "1112245",
        "inventarios": null,
        "medicamentosComprados": null,
        "id": 1
      },
      {
        "fechaCompra": "2023-10-19T00:00:00",
        "proveedorId": 1,
        "proveedores": null,
        "metodoDePagoId": 3,
        "metodosDePagos": null,
        "numeroFactura": "345325345",
        "inventarios": null,
        "medicamentosComprados": null,
        "id": 6
      }
    ],
    "medicamentos": [],
    "id": 0
  },
  {
    "nombres": "Nombres Proveedor B Apellido Proveedor B",
    "apellidos": "3208818203",
    "nroContacto": null,
    "compras": [
      {
        "fechaCompra": "2023-05-24T00:00:00",
        "proveedorId": 2,
        "proveedores": null,
        "metodoDePagoId": 3,
        "metodosDePagos": null,
        "numeroFactura": "324324234",
        "inventarios": null,
        "medicamentosComprados": null,
        "id": 2
      },
      {
        "fechaCompra": "2023-06-11T00:00:00",
        "proveedorId": 2,
        "proveedores": null,
        "metodoDePagoId": 2,
        "metodosDePagos": null,
        "numeroFactura": "4343255",
        "inventarios": null,
        "medicamentosComprados": null,
        "id": 5
      },
      {
        "fechaCompra": "2023-08-06T00:00:00",
        "proveedorId": 2,
        "proveedores": null,
        "metodoDePagoId": 4,
        "metodosDePagos": null,
        "numeroFactura": "34523452345",
        "inventarios": null,
        "medicamentosComprados": null,
        "id": 7
      }
    ],
    "medicamentos": [
      {
        "nombre": "Omeprazol",
        "tipoId": 0,
        "tipos": null,
        "categoriaId": 0,
        "categorias": null,
        "presentacionId": 0,
        "presentaciones": null,
        "fechaExpiracion": "0001-01-01T00:00:00",
        "valorUnidad": "2200",
        "proveedorId": 0,
        "proveedores": null,
        "stock": 10,
        "medicamentosComprados": null,
        "medicamentosVendidos": null,
        "formulaMedicamentos": null,
        "id": 0
      },
      {
        "nombre": "Amoxicilina",
        "tipoId": 0,
        "tipos": null,
        "categoriaId": 0,
        "categorias": null,
        "presentacionId": 0,
        "presentaciones": null,
        "fechaExpiracion": "0001-01-01T00:00:00",
        "valorUnidad": "3500",
        "proveedorId": 0,
        "proveedores": null,
        "stock": 70,
        "medicamentosComprados": null,
        "medicamentosVendidos": null,
        "formulaMedicamentos": null,
        "id": 0
      },
      {
        "nombre": "Paracetamol",
        "tipoId": 0,
        "tipos": null,
        "categoriaId": 0,
        "categorias": null,
        "presentacionId": 0,
        "presentaciones": null,
        "fechaExpiracion": "0001-01-01T00:00:00",
        "valorUnidad": "1000",
        "proveedorId": 0,
        "proveedores": null,
        "stock": 45,
        "medicamentosComprados": null,
        "medicamentosVendidos": null,
        "formulaMedicamentos": null,
        "id": 0
      },
      {
        "nombre": "Ibuprofeno",
        "tipoId": 0,
        "tipos": null,
        "categoriaId": 0,
        "categorias": null,
        "presentacionId": 0,
        "presentaciones": null,
        "fechaExpiracion": "0001-01-01T00:00:00",
        "valorUnidad": "5000",
        "proveedorId": 0,
        "proveedores": null,
        "stock": 20,
        "medicamentosComprados": null,
        "medicamentosVendidos": null,
        "formulaMedicamentos": null,
        "id": 0
      },
      {
        "nombre": "Aspirina",
        "tipoId": 0,
        "tipos": null,
        "categoriaId": 0,
        "categorias": null,
        "presentacionId": 0,
        "presentaciones": null,
        "fechaExpiracion": "0001-01-01T00:00:00",
        "valorUnidad": "2000",
        "proveedorId": 0,
        "proveedores": null,
        "stock": 80,
        "medicamentosComprados": null,
        "medicamentosVendidos": null,
        "formulaMedicamentos": null,
        "id": 0
      }
    ],
    "id": 0
  },
  {
    "nombres": "Nombres Proveedor C Apellido Proveedor C",
    "apellidos": "3208818203",
    "nroContacto": null,
    "compras": [
      {
        "fechaCompra": "2023-01-30T00:00:00",
        "proveedorId": 3,
        "proveedores": null,
        "metodoDePagoId": 1,
        "metodosDePagos": null,
        "numeroFactura": "3453245435",
        "inventarios": null,
        "medicamentosComprados": null,
        "id": 4
      }
    ],
    "medicamentos": [],
    "id": 0
  },
  {
    "nombres": "Nombres Proveedor D Apellido Proveedor D",
    "apellidos": "3208818203",
    "nroContacto": null,
    "compras": [
      {
        "fechaCompra": "2023-12-01T00:00:00",
        "proveedorId": 4,
        "proveedores": null,
        "metodoDePagoId": 4,
        "metodosDePagos": null,
        "numeroFactura": "3245435325",
        "inventarios": null,
        "medicamentosComprados": null,
        "id": 3
      }
    ],
    "medicamentos": [],
    "id": 0
  }
]