# crudEstudiantes

Aplicación de consola en **C# (.NET 10)** para gestionar un registro de estudiantes sobre **SQL Server LocalDB**.
Implementa las operaciones CRUD (crear, leer, actualizar y eliminar) desde un menú interactivo.

## Tecnologías

- .NET 10 (aplicación de consola, *top-level statements*)
- SQL Server LocalDB
- [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) — conexión a SQL Server
- [Dapper](https://www.nuget.org/packages/Dapper) — micro-ORM para el mapeo de consultas

## Estructura del proyecto

| Archivo | Responsabilidad |
|---|---|
| `Program.cs` | Menú principal y captura de datos por consola |
| `Estudiante.cs` | Modelo de datos del estudiante |
| `EstudianteRepository.cs` | Acceso a datos (operaciones CRUD) |
| `MyConnection.cs` | Cadena de conexión a la base de datos |

## Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server LocalDB (se instala con Visual Studio, carga de trabajo *Desarrollo de escritorio .NET* o *Almacenamiento y procesamiento de datos*)

## Base de datos

La aplicación se conecta a la instancia `(localdb)\MSSQLLocalDB` usando autenticación de Windows
(`Integrated Security=True`), por lo que no requiere usuario ni contraseña.

Script para crear la base de datos y la tabla:

```sql
CREATE DATABASE EstudiantesDB;
GO

USE EstudiantesDB;
GO

CREATE TABLE Estudiantes (
    ID                INT IDENTITY(1,1) PRIMARY KEY,
    Nombre            VARCHAR(100),
    Grado             VARCHAR(50),
    Edad              INT,
    CorreoElectronico VARCHAR(100),
    Telefono          VARCHAR(15),
    Estado            BIT
);
```

## Ejecución

```bash
dotnet restore
dotnet run
```

O bien abrir `crudEstudiantes.slnx` en Visual Studio y pulsar **F5**.

## Menú

```
1 - Mostrar Registros
2 - Agregar Registro
3 - Actualizar Registro
4 - Eliminar Registro
5 - Salir
```
