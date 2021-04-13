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
        string Matricula, Direccion, Ciudad, Estado, MatriculaCentro, Cedula, Nombres, Apellidos, Sexo, FechaNacimiento, Puesto, Sueldo;

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

                Console.Write("Ingrese el nombre: ");
                Nombres = Console.ReadLine();

                Console.Write("Ingrese los apellidos: ");
                Apellidos = Console.ReadLine();

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

                }
                catch (Exception)
                {

                    throw;
                    Console.WriteLine("Ocurrió un error, contacta con el palomo de soporte.");
                }

                Console.Write("Desea salir? Si/no : ");
                salir = Console.ReadLine();
            }


            Console.ReadKey();

        }
    }
}
