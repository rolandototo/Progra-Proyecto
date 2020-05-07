using System;
using System.Collections.Generic;

namespace Proyecto
{
    public class administrador : Recursos
    {
        int opcion;
        Json js = new Json();
        public void Init() 
        {
            Console.Clear();
            Console.WriteLine("\tBienvenido, ha ingresado en una cuenta de administrador\n");
            menu();
            selecMenu();
        }
          void menu()
          {
                string[] MenuOpt = { 
                     "Crear nuevo usuario",
                     "Buscar usuario",
                     "Modificar datos de vehículo",
                     "Modificar reparación",
                     "Modificar datos de cliente",
                     "Cerrar sesion",
                     "Cerrar programa" };
                opcion=InterMenu(MenuOpt);
          }
          void selecMenu()
          { 
                switch (opcion)
                {
                    case 0:
                        Console.Clear();
                        SignIn sin = new SignIn();
                        sin.InitSing(); break;
                    case 1:
                        Console.Clear();
                        Busqueda bs = new Busqueda();
                        bs.initBus(); break;
                    case 2:
                        Console.Clear();
                        List<string> elementos = new List<string>();
                        
                        Console.WriteLine("\tSeleccione el número de DUI del dueño de los vehículos a modificar\n");
                        var data = js.desCl();
                        foreach (var opt in data.clientes)
                        {
                            elementos.Add(opt.dui);
                        }
                        string[] menutik = elementos.ToArray();
                        int OpcionMenu =InterMenu(menutik);
                        MoodVei md = new MoodVei(); 
                        md.ModVehiculo(menutik[OpcionMenu]); 
                        break;
                    case 3:

                        Console.Clear();
                        List<string> ElementosMenuModReparacion = new List<string>();

                        Console.WriteLine("\tSeleccione el número de DUI del usuario a modificar\n");
                        var DataVehiculo = js.desVe();
                        foreach (var BusquedaUsuario in DataVehiculo.vehiculos)
                        {
                            ElementosMenuModReparacion.Add(BusquedaUsuario.dui);
                        }
                        string[] ArrayMenuRepa = ElementosMenuModReparacion.ToArray();
                        int OpcionMenuRepa = InterMenu(ArrayMenuRepa);
                        CotVeiculo cv = new CotVeiculo();
                        cv.InitCoti(ArrayMenuRepa[OpcionMenuRepa]);
                        break;
                    case 4:
                            Console.Clear();
                        List<string> ElementosMenuModClientes = new List<string>();

                        Console.WriteLine("\tSeleccione el número de DUI del usuario a modificar\n");
                        var DataCliente = js.desCl();
                        foreach (var BusquedaUsuario in DataCliente.clientes)
                        {
                            ElementosMenuModClientes.Add(BusquedaUsuario.dui);
                        }
                        string[] ArrayMenuClientes= ElementosMenuModClientes.ToArray();
                        int OpcionMenuClientes = InterMenu(ArrayMenuClientes);
                        MoodCliente MoodCliente = new MoodCliente();
                        MoodCliente.Mod(ArrayMenuClientes[OpcionMenuClientes]);
                         break;
                    case 5:
                        Console.Clear();
                        Login lg = new Login();
                        lg.LogStart(); break;
                    case 6:
                            Console.Clear();
                            Environment.Exit(1); break;
                }
                Console.Write("\n\tPresione una tecla para regresar al menú");
                Console.ReadKey();
                Console.Clear();
                Init();
                selecMenu();
            }
        }

}
