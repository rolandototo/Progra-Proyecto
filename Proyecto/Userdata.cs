using System;

namespace Proyecto
{
    
    public class Userdata
    {
        Json js = new Json();

        public string nombre;
       
      
        int opcion;
        string menNV = "INGRESE UN NUMERO VALIDO (entre el 1 al 2)....";
        string mensaje = "Funcion en mantenimineto";



        public void Init(string a)
        {
            nombre = a;
            Console.WriteLine("Bienvenido Usuario : " + nombre);

            menu();
        }
        void menu()
        {
            Console.WriteLine("Que opciones desea ejecuar?");
            Console.WriteLine("\t1) Ver informacion del usuario");
            Console.WriteLine("\t2) Ver ticket");
            Console.WriteLine("\t3) Cerrar sesion");
            Console.WriteLine("\t4) Cerrar programa");
            valMenu();
        }

        void valMenu()
        {

            string op;


            Boolean opval = false;


            do
            {
                Console.Write("Ingrese el numero de la opcion que desee ejecutar:..... ");
                op = Console.ReadLine();

                opval = int.TryParse(op, out opcion);
                if (opval == false)
                {
                    Console.WriteLine(menNV);
                }
            }

            while (!opval);
            Console.Clear();
            selecMenu();
        }

        void selecMenu()
        {
            switch (opcion)
            {

                case 1: ImprecionDatos(); break;
                case 2: Console.WriteLine(mensaje); break;
                case 3:
                    Login lg = new Login();

                    lg.LogStart(); break;
                case 4: Environment.Exit(1); break;
                default:
                    menu();
                    Console.WriteLine(menNV);
                    selecMenu();
                    break;

            }

            Console.Write("Precione una tecla para regresar al menu......");
            Console.ReadKey();
            Console.Clear();
            menu();
            selecMenu();
        }

        void ImprecionDatos()
        {
            var data = js.desCl();
            foreach (var persona in data.clientes)
            {

                foreach (var car in persona.veiculos)
                {


                    if (nombre == persona.nombre)
                    {


                        Console.WriteLine("\n....Nombre: " + persona.nombre);
                        Console.WriteLine("....Dui: " + persona.dui);
                        Console.WriteLine("....Correo: " + persona.correo);
                        Console.WriteLine("\n....Marca: " + car.marca);
                        Console.WriteLine("....Placa: " + car.placa);
                        Console.WriteLine("....Año: " + car.ano);
                        Console.WriteLine("....Color: " + car.color);

                        foreach (var repa in car.reparaciones)
                        {

                            Console.WriteLine("\n.......Repareciones: " + repa);
                            break;

                        }
                    }

                    else if (nombre != persona.nombre)
                    {

                        continue;
                    }

                }


            }
        }

    }
}
