using System;

namespace AsignacionI
{
    class Program
    {
        static void Main(string[] args)
        {
                        
                Producto item = new Producto();
                Console.Write("Put your ID: ");
                item.ID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Name: ");
                item.Detalle = Console.ReadLine();
                item.Existe = true;

                Console.WriteLine($" Datos: {item.ID}, {item.Detalle}, {item.Existe}");
            

            Console.Read();

        }
    }
}
