using System;
using static System.Console;

namespace Proyecto
{
    
    public class Userdata : Recursos 
    {
        Json js = new Json();

       
        public string Nombre;
      
        int opcion;



        public void Init(string a)
        {
            var data = js.desCl();
            foreach (var persona in data.clientes)
            {
                if (a == persona.nomusuario)
                {
                    Nombre = persona.nombre;
                }
            }


            menu();
        }
        void menu()
        {

            WriteLine("Bienvenid: " + Nombre + " escoja una opcion\n");
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
                    Busqueda bs =new Busqueda();
                    bs.BusHere(Nombre); break;
                case 1:
                    Clear();
                    Ticket tk = new Ticket();
                    tk.menutike(Nombre); break;
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
    }
}
