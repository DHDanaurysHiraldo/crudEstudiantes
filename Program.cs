using crudEstudiantes;

var estudianteRepository = new EstudianteRepository();
Estudiante GetDatos()
{
    Estudiante estudiante = new Estudiante();

    Console.WriteLine("(<---Precione Tecla ENTER vacia para volver--->)");

    //NOMBRE
    Console.Write("Ingrese el Nombre Completo: ");
    estudiante.Nombre = Console.ReadLine();

    //Si la variable está vacia ejecuta "continue;"
    //if (string.IsNullOrWhiteSpace(estudiante.Nombre))
    //{
    //    continue;
    //}

    //GRADO
    Console.Write("Ingrese el Grado: ");
    estudiante.Grado = Console.ReadLine();

    //if (string.IsNullOrWhiteSpace(estudiante.Grado))
    //{
    //    continue;
    //}


    //EDAD
    Console.Write("Ingrese la Edad: ");
    estudiante.Edad = Convert.ToInt32(Console.ReadLine());

    //if (string.IsNullOrWhiteSpace(estudiante.Edad.ToString()))
    //{
    //    continue;
    //}

    //CORREO ELECTRONICO
    Console.Write("Ingrese el Correo Electrónico: ");
    estudiante.CorreoElectronico = Console.ReadLine();

    //if (string.IsNullOrWhiteSpace(estudiante.CorreoElectronico))
    //{
    //    continue;
    //}


    //NUMERO DE TELEFONO
    Console.Write("Ingrese el Número de Telefono (Estudiante o Tutor) (Sin Guiones): ");
    estudiante.Telefono = Console.ReadLine();

    //if (string.IsNullOrWhiteSpace(estudiante.Telefono))
    //{
    //    continue;
    //}


    //ESTADO DEL ESTUDIANTE
    Console.Write("Ingrese el Estado de Estudio del Estudiante (True / False): ");
    estudiante.Estado = Convert.ToBoolean(Console.ReadLine());

    //if (string.IsNullOrWhiteSpace(estudiante.Estado.ToString()))
    //{
    //    continue;
    //}
    return estudiante;

}

while (true)
{
    Console.Clear();


    Console.WriteLine("=====================================");
    Console.WriteLine("SISTEMA DE REGISTRO DE ESTUDIANTES");
    Console.WriteLine("=====================================");
    Console.WriteLine();

    Console.WriteLine("========================");
    Console.WriteLine("1 - Mostrar Registros");
    Console.WriteLine("2 - Agregar Registro");
    Console.WriteLine("3 - Actualizar Registro");
    Console.WriteLine("4 - Eliminar Registro");
    Console.WriteLine("========================");
    Console.WriteLine("5 - Salir");
    Console.WriteLine();

    var opcion = Console.ReadLine();
    var estudiante = new Estudiante();

    switch (opcion)
    {
        
        //READ
        case "1":

            var estudiantes = estudianteRepository.Get();
            foreach (var item in estudiantes)
            {
                Console.WriteLine($"{item.ID} - {item.Nombre}");
            }

            Console.ReadLine();

            break;

        //INSERT
        case "2":

            estudiante = GetDatos();


            //LLAMADA DEL METODO INSERT 
            estudianteRepository.Insert(estudiante);
            break;
            


            //UPDATE
        case "3":

            estudiante = GetDatos();

            Console.Write("Ingrese el ID a Actualizar: ");
            estudiante.ID = Convert.ToInt32(Console.ReadLine());

            

            //Si la variable nombre está vacia ejecuta "continue;"
            if (string.IsNullOrWhiteSpace(estudiante.ID.ToString()))
            {
                continue;
            }

            

            estudianteRepository.Update(estudiante);
            break;


            //DELETE
        case "4":
            Console.WriteLine("(<---Precione Tecla ENTER vacia para volver--->)");
            Console.Write("Ingrese el ID a Eliminar: ");
            estudiante.ID = Convert.ToInt32(Console.ReadLine());

            //Si la variable nombre está vacia ejecuta "continue;"
            if (string.IsNullOrWhiteSpace(estudiante.ID.ToString()))
            {
                continue;
            }

            var nombreEstudiante = estudianteRepository.GetNombrePorId(estudiante);

            Console.WriteLine($"¿Está seguro que desea eliminar a {nombreEstudiante} (ID: {estudiante.ID})? Si = 1 / No = 0");
            var confirmacion = Console.ReadLine();

            if (confirmacion != "1")
            {
                continue;
            }

            estudianteRepository.Delete(estudiante);
            break;

        //Close Windows
        case "5":
            Console.WriteLine("¿Desea Cerrar el Registro?");
            Console.WriteLine("Si = 1");
            Console.WriteLine("No = 0");
            var respuesta = Console.ReadLine();


            if (respuesta == "1")
            {
                Console.WriteLine("Cerrando Registro...");
                return;
            }
            else if (respuesta == "0")
            {
                break;
            }
            else
            {
                Console.WriteLine("Seleccione una de las opciones:");
                Console.WriteLine("Si = 1");
                Console.WriteLine("No = 0");
            }
            break;


        default:
            break;
    }

}


