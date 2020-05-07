using System;
namespace Proyecto
{
    public class Maestro
    {

        public void Init()
        {
        
            Console.WriteLine("Bienvenido Maestro. Este Usuario le da control total tanto el modo de consulta del usuario como el modo de adminsitrador");
            string[] OpcionMenu = { "Ingresar como administrador", "Ingresar como Usuario de prueva (Alberto)", "Regresar al login","Cerrar programa" };
            Recursos re = new Recursos();
            int opcion = re.InterMenu(OpcionMenu);
            switch (opcion)
            {
                case 0: Console.Clear(); administrador ad = new administrador();ad.Init();break;
                case 1: Console.Clear(); Userdata us = new Userdata(); us.Init("Alberto");break;
                case 2: Console.Clear(); Login lg = new Login();lg.LogStart();break;
                case 3: Environment.Exit(1);break;
            }
        }
    }
}
