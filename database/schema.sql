/*
    crudEstudiantes - Esquema de la base de datos
    ---------------------------------------------
    Crea la base de datos EstudiantesDB y la tabla Estudiantes.
    Es idempotente: puede ejecutarse varias veces sin error ni pérdida de datos.

    Uso (desde la raíz del repositorio):
        sqlcmd -S "(localdb)\MSSQLLocalDB" -E -f 65001 -i database\schema.sql
*/

IF DB_ID(N'EstudiantesDB') IS NULL
BEGIN
    CREATE DATABASE EstudiantesDB;
END
GO

USE EstudiantesDB;
GO

IF OBJECT_ID(N'dbo.Estudiantes', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Estudiantes (
        ID                INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Estudiantes PRIMARY KEY,
        Nombre            VARCHAR(100)      NULL,
        Grado             VARCHAR(50)       NULL,
        Edad              INT               NULL,
        CorreoElectronico VARCHAR(100)      NULL,
        Telefono          VARCHAR(15)       NULL,
        Estado            BIT               NULL
    );
END
GO

PRINT 'Esquema listo: EstudiantesDB.dbo.Estudiantes';
GO
