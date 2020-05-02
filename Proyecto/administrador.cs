using System;

namespace Proyecto
{
    public class administrador : Recursos

    {
        int opcion;
        string menNV = "INGRESE UN NUMERO VALIDO (entre el 1 al 6)....";
        string mensaje = "Funcion en mantenimineto";
        
        public void Init() 
        {

            Console.WriteLine("Bienvenido, a ingresado en una cuenta de administrador\n");

            menu();
            selecMenu();

        }
          void menu()
            {


            string[] MenuOpt = { "Crear nuevo Usuario",
                 "Buscar Usuario",
                 "Modificar estado de veiculo",
                 "Agregar vehiculo a usuario",
                 "Cotizacion de reparacion por vehiculo",
                 "Cerrar sesion",
                 "Cerrar Programa" };
            opcion=InterMenu(MenuOpt);
                
               
            }


            void selecMenu()
            {
                Login lg = new Login();
                switch (opcion)
                {

                    case 0:
                    Console.Clear();
                    SignIn sin = new SignIn(); break;
                    case 1:
                    Console.Clear();
                    Busqueda bs = new Busqueda(); break;
                    case 2:
                    Console.Clear();
                    MoodVei mv = new MoodVei(); break;
                    case 3:
                    Console.Clear();
                    agreVei ag = new agreVei(); break;
                    case 4:
                    Console.Clear();
                    Console.WriteLine(mensaje); break;
                    case 5:
                    Console.Clear();
                    lg.LogStart(); break;
                    case 6:
                    Console.Clear();
                    Environment.Exit(1); break;
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
        }

}
