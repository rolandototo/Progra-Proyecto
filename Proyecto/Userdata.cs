using System;
using static System.Console;

namespace Proyecto
{
    
    public class Userdata : Recursos
    {
        Json js = new Json();

        public string nombre;
       
      
        int opcion;
        string mensaje = "Funcion en mantenimineto";



        public void Init(string a)
        {
            nombre = a;


            menu();
        }
        void menu()
        {

            WriteLine("Bienvenido Usuario : " + nombre + "\n");
            string[] MenuOpt = { "Ver informacion del usuario",
             "Ver ticket", "Cerrar sesion","Cerrar programa" };
            opcion = InterMenu(MenuOpt);
            selecMenu();
        }


        void selecMenu()
        {
            switch (opcion)
            {

                case 0:
                    Clear();
                    ImprecionDatos(); break;
                case 1:
                    Clear();
                    WriteLine(mensaje); break;
                case 2:
                    Clear();
                    Login lg = new Login();

                    lg.LogStart(); break;
                case 3: Environment.Exit(1); break;
               
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
