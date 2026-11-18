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
| `database/schema.sql` | Script de creación de la base de datos y la tabla |
| `database/seed.sql` | Script con datos de ejemplo |

## Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server LocalDB (se instala con Visual Studio, carga de trabajo *Desarrollo de escritorio .NET* o *Almacenamiento y procesamiento de datos*)

## Base de datos

La aplicación se conecta a la instancia `(localdb)\MSSQLLocalDB` usando autenticación de Windows
(`Integrated Security=True`), por lo que no requiere usuario ni contraseña.

Los scripts están en la carpeta [`database/`](database/):

| Script | Qué hace |
|---|---|
| [`schema.sql`](database/schema.sql) | Crea la base de datos `EstudiantesDB` y la tabla `Estudiantes` |
| [`seed.sql`](database/seed.sql) | Inserta 6 estudiantes **ficticios** de ejemplo (solo si la tabla está vacía) |

Ambos son idempotentes: pueden ejecutarse varias veces sin errores ni datos duplicados.

### Opción A — Línea de comandos

Desde la raíz del repositorio:

```bash
sqlcmd -S "(localdb)\MSSQLLocalDB" -E -f 65001 -i database\schema.sql
sqlcmd -S "(localdb)\MSSQLLocalDB" -E -f 65001 -i database\seed.sql
```

> `-f 65001` indica que los scripts están en UTF-8 (para que las tildes se guarden correctamente).

### Opción B — Visual Studio o SQL Server Management Studio

1. Conectarse al servidor `(localdb)\MSSQLLocalDB`.
2. Abrir y ejecutar `database/schema.sql`.
3. Abrir y ejecutar `database/seed.sql` (opcional).

### Estructura de la tabla `Estudiantes`

| Columna | Tipo | Notas |
|---|---|---|
| `ID` | `INT` | Clave primaria, autoincremental |
| `Nombre` | `VARCHAR(100)` | |
| `Grado` | `VARCHAR(50)` | |
| `Edad` | `INT` | |
| `CorreoElectronico` | `VARCHAR(100)` | |
| `Telefono` | `VARCHAR(15)` | Sin guiones |
| `Estado` | `BIT` | `1` = activo, `0` = inactivo |

## Ejecución

Con la base de datos ya creada (ver sección anterior):

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
