/*
    crudEstudiantes - Datos de ejemplo
    ----------------------------------
    Inserta estudiantes FICTICIOS para probar la aplicación.
    Solo inserta si la tabla está vacía, así que no duplica datos si se ejecuta de nuevo.

    Requiere haber ejecutado antes database\schema.sql.

    Uso (desde la raíz del repositorio):
        sqlcmd -S "(localdb)\MSSQLLocalDB" -E -f 65001 -i database\seed.sql
*/

USE EstudiantesDB;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Estudiantes)
BEGIN
    INSERT INTO dbo.Estudiantes (Nombre, Grado, Edad, CorreoElectronico, Telefono, Estado)
    VALUES
        ('Ana María Pérez',     '1ro de Secundaria', 12, 'ana.perez@example.com',     '8095550101', 1),
        ('Carlos Méndez',       '2do de Secundaria', 13, 'carlos.mendez@example.com', '8095550102', 1),
        ('Lucía Fernández',     '3ro de Secundaria', 14, 'lucia.fernandez@example.com','8095550103', 1),
        ('Javier Rodríguez',    '4to de Secundaria', 15, 'javier.rodriguez@example.com','8095550104', 0),
        ('Sofía Martínez',      '5to de Secundaria', 16, 'sofia.martinez@example.com', '8095550105', 1),
        ('Diego Ramírez',       '6to de Secundaria', 17, 'diego.ramirez@example.com',  '8095550106', 0);

    PRINT 'Datos de ejemplo insertados.';
END
ELSE
BEGIN
    PRINT 'La tabla ya contiene datos; no se insertó nada.';
END
GO
