using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using static System.Console;

namespace Proyecto
{
    public class CotVeiculo
    {
        Json js = new Json();
        Recursos rs = new Recursos();
        public void InitCoti(string ValidacionDui)
        {
            Clear();
            var DataVeiculos = js.desVe();
            var DataReparacion = js.desRe();

            List<string> ElementosMenuPlaca= new List<string>();

            foreach (var BusquedaVeiculo in DataVeiculos.vehiculos)
            {
                if (ValidacionDui == BusquedaVeiculo.dui)
                {
                    ElementosMenuPlaca.Add(BusquedaVeiculo.placa);
                }
            }

            ElementosMenuPlaca.Add("Salir al menú anterior");
            string[] MenuGetPlaca = ElementosMenuPlaca.ToArray();
            Clear();
            WriteLine("Se encontraron estos vehículos a modificar\n");
            int opt = rs.InterMenu(MenuGetPlaca);
            int index = Array.IndexOf(MenuGetPlaca, "Salir al menú anterior");

            if (opt == index)
            {
                Clear(); administrador ad = new administrador();
                ad.Init();
            }
            CrearOMod(MenuGetPlaca[opt]);

            void CrearOMod(string p)
            {
                string placa = p;
                Clear();
                WriteLine("¿Qué desea hacer?\n");
                string[] MenuFuncion = { "Crear una nueva reparación","Modificar una reparación","Salir al menú anterior"};
                int OpcionMenu = rs.InterMenu(MenuFuncion);
                switch (OpcionMenu)
                {
                    case 0: CrearReparacion(placa);break;
                    case 1: Menumod(placa); break;
                    case 2: InitCoti(ValidacionDui);break;
                }
            }

            void CrearReparacion(string p)
            {
                string reparacion, placa, material, costomate, horas, costohora, estado;
                Clear();
                Write("\n\tEscriba el nombre de la reparación: ");
                reparacion = ReadLine();
                placa = p;
                material = string.Empty;
                costomate = "0";
                horas = "0";
                costohora = "0";
                estado = "En reparación";

                DataReparacion.reparaciones.Add(new Reparation { reparacion = reparacion, placa = placa, materiales = material, costomaterial = costomate, horas = horas, costohora = costohora, estadodeReparacion = estado });
                js.Save(4, js.sereRe(DataReparacion));
                WriteLine("Nueva reparación guardada");
                Clear();
                CrearOMod(placa);
            }
            

            void Menumod(string p)
            {
                string placa = p;
                Clear();
                WriteLine("Reparaciones del vehículo " + p + "\n");
                List<string> ElementosMenuReparacion = new List<string>();

                foreach (var BusquedaReparacion in DataReparacion.reparaciones)
                {
                    if (p == BusquedaReparacion.placa)
                    {
                        ElementosMenuReparacion.Add(BusquedaReparacion.reparacion);
                    }
                }

                ElementosMenuReparacion.Add("Salir al menú anterior");
                string[] MenuGetReparaciones = ElementosMenuReparacion.ToArray();
                Clear();
                WriteLine("\tSe encontraron estas reparaciones a modificar\n");
                int optMenuRepa = rs.InterMenu(MenuGetReparaciones);
                int indexSalirAMenuPlaca = Array.IndexOf(MenuGetReparaciones, "Salir al menú anterior");

                if (optMenuRepa == indexSalirAMenuPlaca)
                {
                    CrearOMod(placa);
                }
                Clear();
                MenuDatosRepa(MenuGetReparaciones[optMenuRepa]);

                void MenuDatosRepa(string e) 
                {
                    string Nombrerepa = e;
                    WriteLine("\tDatos de la reparación seleccionada");
                    foreach (var BusquedaNombreRepa in DataReparacion.reparaciones)
                    {
                        if (Nombrerepa == BusquedaNombreRepa.reparacion)
                        {
                            WriteLine("\tNombre de la reparación: " + BusquedaNombreRepa.reparacion);
                            WriteLine("\tNúmero de placa: " + BusquedaNombreRepa.placa);
                            WriteLine("\tNombre de material: " + BusquedaNombreRepa.materiales);
                            WriteLine("\tCosto del material: " + BusquedaNombreRepa.costomaterial);
                            WriteLine("\tHoras trabajadas: " + BusquedaNombreRepa.horas);
                            WriteLine("\tCosto de hora: " + BusquedaNombreRepa.costohora);
                            WriteLine("\tEstado de la reparación: " + BusquedaNombreRepa.estadodeReparacion);
                        }
                    }

                    string[] MenuOpcionMood = 
                    {
                        "Reparación",
                        "Material",
                        "Costo del material",
                        "Horas trabajadas",
                        "Costo de horas",
                        "Estado de reparación", 
                        "Regresar al menú anterior" 
                    };

                    ReadKey();
                    Clear();
                    WriteLine("Menú de datos a modificar\n");
                    int opt2 = rs.InterMenu(MenuOpcionMood);

                    switch (opt2)
                    {
                        case 0:
                            foreach (var BusquedaRepacion in DataReparacion.reparaciones)
                            {
                                if (Nombrerepa == BusquedaRepacion.reparacion)
                                {
                                    WriteLine("\nEscriba el nuevo nombre de la reparación: ");
                                    BusquedaRepacion.reparacion = ReadLine();

                                    js.Save(4, js.sereRe(DataReparacion));
                                    WriteLine("\tDato guardado. Presione una tecla para regresar al menú de modificación");
                                    ReadKey();
                                    MenuDatosRepa(BusquedaRepacion.reparacion);
                                }
                            }
                            break;
                        case 1:
                            foreach (var BusquedaRepacion in DataReparacion.reparaciones)
                            {
                                if (Nombrerepa == BusquedaRepacion.reparacion)
                                {
                                    WriteLine("\nEscriba el nombre del material");
                                    BusquedaRepacion.materiales= ReadLine();

                                    js.Save(4, js.sereRe(DataReparacion));
                                    WriteLine("\tDato guardado. Presione una tecla para regresar al menú de modificación");
                                    ReadKey();
                                    MenuDatosRepa(Nombrerepa);
                                }
                            }
                            break;
                        case 2:
                            foreach (var BusquedaRepacion in DataReparacion.reparaciones)
                            {
                                if (Nombrerepa == BusquedaRepacion.reparacion)
                                {
                                    WriteLine("\nEscriba el precio del material: ");
                                    BusquedaRepacion.costomaterial= ReadLine();

                                    js.Save(4, js.sereRe(DataReparacion));
                                    WriteLine("\tDato guardado. Presione una tecla para regresar al menu de modificación");
                                    ReadKey();
                                    MenuDatosRepa(Nombrerepa);
                                }
                            }
                            break;
                        case 3:
                            foreach (var BusquedaRepacion in DataReparacion.reparaciones)
                            {
                                if (Nombrerepa == BusquedaRepacion.reparacion)
                                {
                                    WriteLine("\nEscriba el número de horas de trabajo: ");
                                    BusquedaRepacion.horas= ReadLine();

                                    js.Save(4, js.sereRe(DataReparacion));
                                    WriteLine("\tDato guardado. Presione una tecla para regresar al menú de modificación");
                                    ReadKey();
                                    MenuDatosRepa(Nombrerepa);
                                }
                            }
                            break;
                        case 4:
                            foreach (var BusquedaRepacion in DataReparacion.reparaciones)
                            {
                                if (Nombrerepa == BusquedaRepacion.reparacion)
                                {
                                    WriteLine("\nEscriba el costo de la hora: ");
                                    BusquedaRepacion.costohora= ReadLine();

                                    js.Save(4, js.sereRe(DataReparacion));
                                    WriteLine("\tDato guardado. Presione una tecla para regresar al menú de modificación");
                                    ReadKey();
                                    MenuDatosRepa(Nombrerepa);
                                }
                            }
                            break;
                        case 5:
                            foreach (var BusquedaRepacion in DataReparacion.reparaciones)
                            {
                                if (Nombrerepa == BusquedaRepacion.reparacion)
                                {
                                    string[] estado = { "Reparado", "En reparación" };
                                    Clear();
                                    WriteLine("\nSeleccione el estado de la reparacion");
                                    int opt3 = rs.InterMenu(estado);
                                    switch (opt3)
                                    {
                                        case 0:
                                            BusquedaRepacion.estadodeReparacion = "Reparado"; break;
                                        case 1:
                                            BusquedaRepacion.estadodeReparacion= "En reparación"; break;
                                    }
                                    js.Save(4, js.sereRe(DataReparacion));
                                    WriteLine("\tDato guardado. Presione una tecla para regresar al menú de modificación");
                                    ReadKey();
                                    MenuDatosRepa(Nombrerepa);
                                }
                            }
                            break;
                        case 6:
                            Menumod(p);
                            break;
                    }
                }
            }
        }
    }
}
