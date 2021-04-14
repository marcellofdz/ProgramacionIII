using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CitasCovid_Log4Net
{
    class Program
    {
        static void Main(string[] args)
        {
        
        string Nombres, Apellidos, Sexo, Direccion, Ciudad, Estado, Cedula, FechaNacimiento, MatriculaCentro, NombreCentro, FechaCita, HoraCita, FaseVacunacion;

            Int32 CantidadRegistros;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            connection.Open();
            Console.WriteLine(connection.State);

            string salir = "no";
            SqlTransaction tran = null;
            SqlDataReader dr = null;
            SqlCommand cmd = null;

            Console.WriteLine();

            while (salir.ToLower() == "no")
            {
                Console.Write("Ingrese el nombre del Centro: ");
                NombreCentro = Console.ReadLine();

                Console.Write("Ingrese la Matricula del centro: ");
                MatriculaCentro = Console.ReadLine();

                Console.Write("Ingrese el nombre: ");
                Nombres = Console.ReadLine();

                Console.Write("Ingrese los apellidos: ");
                Apellidos = Console.ReadLine();

                Ciudad = ConfigurationManager.AppSettings["Lugar"];
                Console.WriteLine("Ciudad: " + Ciudad);

                Console.Write("Ingrese la direccion: ");
                Direccion = Console.ReadLine();

                Console.Write("Ingrese el sexo: ");
                Sexo = Console.ReadLine();

                Console.Write("Ingrese la cédula: ");
                Cedula = Console.ReadLine();

                Console.Write("Ingrese la fecha de nacimiento: ");
                FechaNacimiento = Console.ReadLine();

                Console.Write("Fecha de cita: ");
                FechaCita = Console.ReadLine();

                Console.Write("Hora cita: ");
                HoraCita = Console.ReadLine();

                Console.Write("Fase de vacunacion: ");
                FaseVacunacion = Console.ReadLine();

                Console.Write("Estado: ");
                Estado = Console.ReadLine();


                try
                {
                    tran = connection.BeginTransaction();

                    cmd = new SqlCommand("registrar_usuario", connection, tran);
                    cmd.Parameters.AddWithValue("@Nombres", Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
                    cmd.Parameters.AddWithValue("@Sexo", Sexo);
                    cmd.Parameters.AddWithValue("@Direccion", Direccion);
                    cmd.Parameters.AddWithValue("@Ciudad", Ciudad);
                    cmd.Parameters.AddWithValue("@Estado", Estado);
                    cmd.Parameters.AddWithValue("@Cedula", Cedula);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);


                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    CantidadRegistros = cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("registrar_citas", connection, tran);
                    cmd.Parameters.AddWithValue("@Nombres", Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
                    cmd.Parameters.AddWithValue("@Cedula", Cedula);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
                    cmd.Parameters.AddWithValue("@MatriculaCentro", MatriculaCentro);
                    cmd.Parameters.AddWithValue("@NombreCentro", NombreCentro);
                    cmd.Parameters.AddWithValue("@FechaCita", FechaCita);
                    cmd.Parameters.AddWithValue("@HoraCita", HoraCita);
                    cmd.Parameters.AddWithValue("@Estados", Estado);
                    cmd.Parameters.AddWithValue("@FaseVacunacion", FaseVacunacion);



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


            cmd = new SqlCommand("ppGetCitas", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"{dr["Cedula"]}\t {dr["Nombres"]}\t {dr["Apellido"]}\t{dr["CantidadVisitas"]}\t{dr["FaseVacunacion"]} ");
            }
            Console.ReadKey();


        }
    }
}
