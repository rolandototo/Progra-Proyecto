using System;
using static System.Console;

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
            WriteLine("Bienvenido Usuario : " + nombre);

            menu();
        }
        void menu()
        {
            WriteLine("Que opciones desea ejecuar?");
            WriteLine("\t1) Ver informacion del usuario");
            WriteLine("\t2) Ver ticket");
            WriteLine("\t3) Cerrar sesion");
            WriteLine("\t4) Cerrar programa");
            valMenu();
        }

        void valMenu()
        {

            string op;


            Boolean opval = false;


            do
            {
                Write("Ingrese el numero de la opcion que desee ejecutar:..... ");
                op = ReadLine();

                opval = int.TryParse(op, out opcion);
                if (opval == false) WriteLine(menNV);

            }

            while (!opval);
            Clear();
            selecMenu();
        }

        void selecMenu()
        {
            switch (opcion)
            {

                case 1: ImprecionDatos(); break;
                case 2: WriteLine(mensaje); break;
                case 3:
                    Login lg = new Login();

                    lg.LogStart(); break;
                case 4: Environment.Exit(1); break;
                default:
                    menu();
                    WriteLine(menNV);
                    selecMenu();
                    break;

            }
            Write("Precione una tecla para regresar al menu......");
            ReadKey();
            Clear();
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
                        WriteLine("\n....Nombre: " + persona.nombre);
                        WriteLine("....Dui: " + persona.dui);
                        WriteLine("....Correo: " + persona.correo);
                        WriteLine("\n....Marca: " + car.marca);
                        WriteLine("....Placa: " + car.placa);
                        WriteLine("....Año: " + car.ano);
                        WriteLine("....Color: " + car.color);

                        foreach (var repa in car.reparaciones)
                        {
                            WriteLine("\n.......Repareciones: " + repa);
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
