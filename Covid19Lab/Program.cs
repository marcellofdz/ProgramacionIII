using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Covid19Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            conn.Open();
            Console.WriteLine(conn.State);
            string salir = "no";
            //SqlCommand cmd = new SqlCommand();

            Console.WriteLine();;
            while (salir.ToLower() == "no")
            {
                //Console.Clear();
                Console.Write("Nombre paciente: ");
                string vName = Console.ReadLine();
                Console.Write("Apellidos paciente: ");
                string vLastname = Console.ReadLine();
                Console.Write("Cedula: ");
                string vCedula = Console.ReadLine();
                Console.Write("Fecha Nacimiento [dd/mm/yyyy]: ");
                string vBirthD = Console.ReadLine();
                Console.Write("Tipo de vacuna: ");
                string vacuna = Console.ReadLine();
                Console.Write("Estado: ");
                string vEstado = Console.ReadLine();
                Console.Write("Nota: ");
                string nota = Console.ReadLine();



               SqlCommand cmd = new SqlCommand("insertar_paciente", conn);
                cmd.Parameters.AddWithValue("@Nombres", vName);
                cmd.Parameters.AddWithValue("@Apellidos", vLastname);
                cmd.Parameters.AddWithValue("@Cedula", vCedula);
                cmd.Parameters.AddWithValue("@FechaNacimiento", vBirthD);
                cmd.Parameters.AddWithValue("@Estado", vEstado);
                cmd.Parameters.AddWithValue("@TipoVacuna", vacuna);
                cmd.Parameters.AddWithValue("@Nota", nota);
                //cmd.ExecuteNonQuery();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                int CantidadRegistros = cmd.ExecuteNonQuery();

                Console.WriteLine($"Registros afectados: {CantidadRegistros}");
                Console.Write("Desea salir? Si/no : ");
                salir = Console.ReadLine();
            }

            Console.ReadKey();
            


        }
    }
}
