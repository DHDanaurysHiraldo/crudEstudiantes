using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Microsoft.Data.SqlClient;

namespace crudEstudiantes
{
    public class EstudianteRepository
    {


        //METODO READ
        //public void Get()
        //{
        //    //Creación de Conexión
        //    using var connection = new SqlConnection(MyConnection.ConnectionString);
        //    connection.Open();

        //    var query = ("SELECT * FROM registroEstudiantes;");

        //    using var command = new SqlCommand(query, connection);

        //    using var reader = command.ExecuteReader();

        //    //Console.WriteLine("ID| NOMBRE");

        //    Console.WriteLine($"{"ID",-4}{"Nombre",-22}{"Grado",-18}{"Edad",-6}{"Correo",-28}{"Telefono",-14}{"Estado",-7}");
        //    Console.WriteLine(new string('-', 100));

        //    while (reader.Read())
        //    {
        //        var id = reader.GetInt32(0);
        //        var nombre = reader.GetString(1);
        //        var grado = reader.GetString(2);
        //        var edad = reader.GetInt32(3);
        //        var email = reader.GetString(4);
        //        var telefono = reader.GetString(5);
        //        var estado = reader.GetBoolean(6);

        //        //Console.WriteLine($"{id} | {nombre} | {grado} | {edad} | {email} | {telefono} | {estado}");

        //        Console.WriteLine($"{id,-4}{nombre,-22}{grado,-18}{edad,-6}{email,-28}{telefono,-14}{estado,-7}");


        //    }
        //}


        public List<Estudiante> Get()
        {
            //Creación de Conexión
            using var connection = new SqlConnection(MyConnection.ConnectionString);
            

            var query = ("SELECT ID, Nombre, Grado, Edad, CorreoElectronico, Telefono, Estado FROM Estudiantes;");
            var estudiantes = connection.Query<Estudiante>(query);

            return estudiantes.ToList();
            
            


            
        }





        //METODO INSERT
        public void Insert(Estudiante estudiante)
        {
            using var connection = new SqlConnection(MyConnection.ConnectionString);
            connection.Open();

            var query = ("INSERT INTO Estudiantes (Nombre, Grado, Edad, CorreoElectronico, Telefono, Estado) VALUES (@Nombre, @Grado, @Edad, @CorreoElectronico, @Telefono, @Estado);");

            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
            command.Parameters.AddWithValue("@Grado", estudiante.Grado);
            command.Parameters.AddWithValue("@Edad", estudiante.Edad);
            command.Parameters.AddWithValue("@CorreoElectronico", estudiante.CorreoElectronico);
            command.Parameters.AddWithValue("@Telefono", estudiante.Telefono);
            command.Parameters.AddWithValue("@Estado", estudiante.Estado);

            command.ExecuteNonQuery();

        }


        //METODO UPDATE
        public void Update(Estudiante estudiante)
        {
            using var connection = new SqlConnection(MyConnection.ConnectionString);
            connection.Open();

            var query = @"UPDATE Estudiantes 
                  SET Nombre = @Nombre, 
                      Grado = @Grado, 
                      Edad = @Edad, 
                      CorreoElectronico = @CorreoElectronico, 
                      Telefono = @Telefono, 
                      Estado = @Estado
                  WHERE ID = @ID;";

            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", estudiante.ID);
            command.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
            command.Parameters.AddWithValue("@Grado", estudiante.Grado);
            command.Parameters.AddWithValue("@Edad", estudiante.Edad);
            command.Parameters.AddWithValue("@CorreoElectronico", estudiante.CorreoElectronico);
            command.Parameters.AddWithValue("@Telefono", estudiante.Telefono);
            command.Parameters.AddWithValue("@Estado", estudiante.Estado);

            command.ExecuteNonQuery();

        }


        //METODO DELETE
        public void Delete(Estudiante estudiante)
        {
            using var connection = new SqlConnection(MyConnection.ConnectionString);
            connection.Open();

            var query = "DELETE FROM Estudiantes WHERE ID = @ID;";

            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", estudiante.ID);

            command.ExecuteNonQuery();

        }



        //METODO GET NOMBRE 
        public string GetNombrePorId(Estudiante estudiante)
        {
            using var connection = new SqlConnection(MyConnection.ConnectionString);
            connection.Open();

            var query = "SELECT Nombre FROM Estudiantes WHERE ID = @ID;";

            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", estudiante.ID);

            return command.ExecuteScalar().ToString();
        }




    }
}
