using System;

namespace Proyecto
{
    public class administrador

    {
        int opcion;
        string menNV = "INGRESE UN NUMERO VALIDO (entre el 1 al 6)....";
        string mensaje = "Funcion en mantenimineto";

        public void Init() 
        {



            Console.WriteLine("Bienvenido, a ingresado en una cuenta de administrador\n\n");



            menu();
            selecMenu();

        }


       

            


            void menu()
            {
                Console.WriteLine("************************************************************************");
                Console.WriteLine("************************************************************************");
                Console.WriteLine("**                                Admin                               **");
                Console.WriteLine("**                                                                    **");
                Console.WriteLine("**                                Menu                                **");
                Console.WriteLine("**                                                                    **");
                Console.WriteLine("**               1). Crear nuevo Usuario                              **");
                Console.WriteLine("**               2). Buscar Usuario                                   **");
                Console.WriteLine("**               3). Modificar estado de veiculo                      **");
                Console.WriteLine("**               4). Agregar vehiculo a usuario                       **");
                Console.WriteLine("**               5). Cotizacion de reparacion por vehiculo            **");
                Console.WriteLine("**               6). Cerrar sesion                                    **");
                Console.WriteLine("**               7). Cerrar Programa                                  **");
                Console.WriteLine("**                                                                    **");
                Console.WriteLine("************************************************************************");
                Console.WriteLine("************************************************************************");

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
            }

            void selecMenu()
            {
                Login lg = new Login();
                switch (opcion)
                {

                    case 1: SignIn sin = new SignIn(); break;
                    case 2: Busqueda bs = new Busqueda(); break;
                    case 3: MoodVei mv = new MoodVei(); break;
                    case 4: agreVei ag = new agreVei(); break;
                    case 5: Console.WriteLine(mensaje); break;
                    case 6: lg.LogStart(); break;
                    case 7: Environment.Exit(1); break;
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
