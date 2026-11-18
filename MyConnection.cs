using System;
using System.Collections.Generic;
using System.Text;


namespace crudEstudiantes
{
    public class MyConnection
    {
        public static string ConnectionString => "Server=(localdb)\\MSSQLLocalDB;Database=EstudiantesDB;Integrated Security=True;TrustServerCertificate=True";
    }
}
