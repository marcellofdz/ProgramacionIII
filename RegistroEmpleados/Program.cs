using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RegistroEmpleados
{
    class Program
    {
        static void Main(string[] args)
        {
        string Matricula, Direccion, Ciudad, Estado, MatriculaCentro, Cedula, NombreCentro, Nombres, Apellidos, Sexo, FechaNacimiento, Puesto, Sueldo;

            Int32 CantidadRegistros;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();
            Console.WriteLine(connection.State);

            string salir = "no";
            SqlTransaction tran = null;
            SqlCommand cmd = null;

            Console.WriteLine();

            while (salir.ToLower() == "no")
            {
                Console.Write("Ingrese el nombre del Centro: ");
                NombreCentro = Console.ReadLine();

                Console.Write("Ingrese el nombre: ");
                Nombres = Console.ReadLine();

                Console.Write("Ingrese los apellidos: ");
                Apellidos = Console.ReadLine();

                Ciudad = ConfigurationManager.AppSettings["Lugar"];
                Console.WriteLine("Ingrese la localidad: " + Ciudad);

                Console.Write("Ingrese la direccion: ");
                Direccion = Console.ReadLine();

                Console.Write("Ingrese el sexo: ");
                Sexo = Console.ReadLine();

                Console.Write("Ingrese la cédula: ");
                Cedula = Console.ReadLine();

                Console.Write("Ingrese la fecha de nacimiento: ");
                FechaNacimiento = Console.ReadLine();

                Console.Write("Ingrese la Matricula: ");
                Matricula = Console.ReadLine();

                Console.Write("Ingrese la Matricula del centro: ");
                MatriculaCentro = Console.ReadLine();

                Console.Write("Puesto designado: ");
                Puesto = Console.ReadLine();

                Console.Write("Sueldo designado: ");
                Sueldo = Console.ReadLine();

                Console.Write("Estado: ");
                Estado = Console.ReadLine();


                try
                {
                    tran = connection.BeginTransaction();

                    cmd = new SqlCommand("registrar_empleado", connection, tran);
                    cmd.Parameters.AddWithValue("@Matricula", Matricula);
                    cmd.Parameters.AddWithValue("@Direccion", Direccion);
                    cmd.Parameters.AddWithValue("@Ciudad",Ciudad);
                    cmd.Parameters.AddWithValue("@Estado", Estado);
                    cmd.Parameters.AddWithValue("@MatriculaCentro", MatriculaCentro);
                    cmd.Parameters.AddWithValue("@NombreCentro", NombreCentro);
                    cmd.Parameters.AddWithValue("@Cedula", Cedula);
                    cmd.Parameters.AddWithValue("@Nombres", Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
                    cmd.Parameters.AddWithValue("@Sexo", Sexo);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Puesto", Puesto);
                    cmd.Parameters.AddWithValue("@Sueldo", Sueldo);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    CantidadRegistros = cmd.ExecuteNonQuery();

                    tran.Commit();

                }
                catch (Exception)
                {

                    throw;
                    Console.WriteLine("Ocurrió un error, contacta con el palomo de soporte.");
                }

                Console.WriteLine($"Registros afectados: {CantidadRegistros}");
                Console.Write("Desea salir? Si/no : ");
                salir = Console.ReadLine();
            }


            Console.ReadKey();

        }
    }
}
