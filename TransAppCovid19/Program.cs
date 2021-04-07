using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TransAppCovid19
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables globales

            string vMarca = "";
            string vLote = "";
            string vSecuencia = "";
            string vEstado = "";
            string vCantidadGramos = "";
            string vLugar = "";
            string vUsuario = "";
            string vDescripcion = "";

            Int32 CantidadRegistros = 0;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            conn.Open();
            Console.WriteLine(conn.State);
            string salir = "no";
            SqlTransaction tran = null;
            SqlCommand cmd = null;

            Console.WriteLine(); ;
            while (salir.ToLower() == "no")
            {
                //Console.Clear();
                Console.Write("Ingrese el codigo de barra: ");
                string vCodigoBarra = Console.ReadLine();

                cmd = new SqlCommand("ppGetVacunasByCodigo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoBarras", vCodigoBarra);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Console.WriteLine("Fecha de Ingreso: " + dr["FechaIngreso"].ToString());
                    Console.WriteLine("Lote: " + dr["Lote"].ToString());
                    Console.WriteLine("Secuencia: " + dr["Secuencia"].ToString());
                    Console.WriteLine("Descripcion: " + dr["Descripcion"].ToString());
                }

                else
                {

                    vLugar = ConfigurationManager.AppSettings["Lugar"];
                    Console.WriteLine("Ingrese la localidad: " + vLugar);

                    Console.Write("Ingrese la marca: ");
                    vMarca = Console.ReadLine();

                    Console.Write("Ingrese el lote: ");
                    vLote = Console.ReadLine();

                    Console.Write("Ingrese la secuencia: ");
                    vSecuencia = Console.ReadLine();

                    //Console.Write("Ingrese la cantidad traida: ");
                    //string vCantidad = Console.ReadLine();

                    Console.Write("Ingrese el Estado: ");
                    vEstado = Console.ReadLine();

                    Console.Write("Cantidad en gramos: ");
                    vCantidadGramos = Console.ReadLine();

                    Console.Write("Ingrese la cedula: ");
                    vUsuario = Console.ReadLine();

                    Console.Write("Descripcion: ");
                    vDescripcion = Console.ReadLine();
                }

                dr.Close();
                dr = null;

                vLugar = ConfigurationManager.AppSettings["Lugar"];
                Console.WriteLine("Ingrese la localidad: " + vLugar);


                Console.Write("Ingrese la marca: ");
                vMarca = Console.ReadLine();

                Console.Write("Ingrese el lote: ");
                vLote = Console.ReadLine();

                Console.Write("Ingrese la secuencia: ");
                vSecuencia = Console.ReadLine();

                //Console.Write("Ingrese la cantidad traida: ");
                //string vCantidad = Console.ReadLine();

                Console.Write("Ingrese el Estado: ");
                vEstado = Console.ReadLine();

                Console.Write("Cantidad en gramos: ");
                vCantidadGramos = Console.ReadLine();

                Console.Write("Ingrese la cedula: ");
                vUsuario = Console.ReadLine();

                Console.Write("Descripcion: ");
                vDescripcion = Console.ReadLine();

                try
                {
                    //Inicio de la transaccion
                    tran = conn.BeginTransaction();

                    cmd = new SqlCommand("registrar_vacuna", conn, tran);
                    cmd.Parameters.AddWithValue("@CodigoBarra", vCodigoBarra);
                    cmd.Parameters.AddWithValue("@Descripcion", vDescripcion);
                    cmd.Parameters.AddWithValue("@Lote", vLote);
                    cmd.Parameters.AddWithValue("@Secuencia", vSecuencia);
                    cmd.Parameters.AddWithValue("@Estado", vEstado);
                    cmd.Parameters.AddWithValue("@CantidadGramos", vCantidadGramos);
                    cmd.Parameters.AddWithValue("@Cedula", vUsuario);
                    //cmd.ExecuteNonQuery();

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    CantidadRegistros = cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("unidad_vacuna", conn, tran);
                    cmd.Parameters.AddWithValue("@CodigoBarra", vCodigoBarra);
                    cmd.Parameters.AddWithValue("@Marca", vMarca);
                    cmd.Parameters.AddWithValue("@Localidad", vLugar);
                    cmd.Parameters.AddWithValue("@Estado", vEstado);
                    //cmd.Parameters.AddWithValue("@CantidadExistencia", vCantidad);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    CantidadRegistros = cmd.ExecuteNonQuery();

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    //throw;
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
