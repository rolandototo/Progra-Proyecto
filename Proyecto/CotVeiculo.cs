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

            ElementosMenuPlaca.Add("Salir al menu anterior");
            string[] MenuGetPlaca = ElementosMenuPlaca.ToArray();
            Clear();
            WriteLine("Se encontro estos veiculos a modificar\n");
            int opt = rs.InterMenu(MenuGetPlaca);
            int index = Array.IndexOf(MenuGetPlaca, "Salir al menu anterior");

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
                WriteLine("Que desea hacer?\n");
                string[] MenuFuncion = { "Crear una nueva reparacion","Modificar una Reparacion","Salir al menu anterior"};
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
                Write("Escriba el nombre de la reparacion: ");
                reparacion = ReadLine();
                placa = p;
                material = string.Empty;
                costomate = "0";
                horas = "0";
                costohora = "0";
                estado = "En Reparacion";

                DataReparacion.reparaciones.Add(new Reparation { reparacion = reparacion, placa = placa, materiales = material, costomaterial = costomate, horas = horas, costohora = costohora, estadodeReparacion = estado });
                js.Save(4, js.sereRe(DataReparacion));
                WriteLine("Nueva reapracion guardada!");
                Clear();
                CrearOMod(placa);
            }
            

            void Menumod(string p)
            {
                string placa = p;
                Clear();
                WriteLine("Reparaciones del veiculo " + p + "\n");
                List<string> ElementosMenuReparacion = new List<string>();


                foreach (var BusquedaReparacion in DataReparacion.reparaciones)
                {
                    if (p == BusquedaReparacion.placa)
                    {
                        ElementosMenuReparacion.Add(BusquedaReparacion.reparacion);
                    }
                }

                ElementosMenuReparacion.Add("Salir al menu anterior");
                string[] MenuGetReparaciones = ElementosMenuReparacion.ToArray();
                Clear();
                WriteLine("Se encontro estas reparaciones a modificar\n");
                int optMenuRepa = rs.InterMenu(MenuGetReparaciones);
                int indexSalirAMenuPlaca = Array.IndexOf(MenuGetPlaca, "Salir al menu anterior");

                if (optMenuRepa == indexSalirAMenuPlaca)
                {
                    CrearOMod(p);
                }
                Clear();
                MenuDatosRepa(MenuGetReparaciones[optMenuRepa]);

                void MenuDatosRepa(string e) 
                {
                    string Nombrerepa = e;
                    WriteLine("Datos de la reparacion seleccionada");
                    foreach (var BusquedaNombreRepa in DataReparacion.reparaciones)
                    {
                        if (Nombrerepa == BusquedaNombreRepa.reparacion)
                        {
                            WriteLine("Nombre de la reparacion: " + BusquedaNombreRepa.reparacion);
                            WriteLine("Numero de placa: " + BusquedaNombreRepa.placa);
                            WriteLine("Nombre de material: " + BusquedaNombreRepa.materiales);
                            WriteLine("Costo del material: " + BusquedaNombreRepa.costomaterial);
                            WriteLine("Horas tranajadas: " + BusquedaNombreRepa.horas);
                            WriteLine("Costo de hora: " + BusquedaNombreRepa.costohora);
                            WriteLine("Estado de la reparacion: " + BusquedaNombreRepa.estadodeReparacion);

                        }
                    }



                    string[] MenuOpcionMood = {
                "Reparacion",
                          "Material",
                               "Costo del Material",
                                    "Horas trabajadas",
                                         "Costo de Horas",
                                              "Estado de Reparacion", "Regresar al menu anterior" };

                    ReadKey();
                    Clear();
                    WriteLine("Menu de datos a modificar\n");
                    int opt2 = rs.InterMenu(MenuOpcionMood);

                    switch (opt2)
                    {
                        case 0:
                            foreach (var BusquedaRepacion in DataReparacion.reparaciones)
                            {
                                if (Nombrerepa == BusquedaRepacion.reparacion)
                                {
                                    WriteLine("\nEscriba el nuevo nombre de la reparacion: ");
                                    BusquedaRepacion.reparacion = ReadLine();

                                    js.Save(4, js.sereRe(DataReparacion));
                                    WriteLine("Dato guardado!, presione una tecla para regresar al menu de Modificacion");
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
                                    WriteLine("Dato guardado!, presione una tecla para regresar al menu de Modificacion");
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
                                    WriteLine("Dato guardado!, presione una tecla para regresar al menu de Modificacion");
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
                                    WriteLine("\nEscriba el numero de hora: ");
                                    BusquedaRepacion.horas= ReadLine();

                                    js.Save(4, js.sereRe(DataReparacion));
                                    WriteLine("Dato guardado!, presione una tecla para regresar al menu de Modificacion");
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
                                    WriteLine("Dato guardado!, presione una tecla para regresar al menu de Modificacion");
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
                                    string[] estado = { "Reparado", "En Repara\"En Reparacion\"cion" };
                                    Clear();
                                    WriteLine("\nSeleccion el Estado de la reparacion");
                                    int opt3 = rs.InterMenu(estado);
                                    switch (opt3)
                                    {
                                        case 0:
                                            BusquedaRepacion.estadodeReparacion = "Reparado"; break;
                                        case 1:
                                            BusquedaRepacion.estadodeReparacion= "En Reparacion"; break;
                                    }


                                    js.Save(4, js.sereRe(DataReparacion));
                                    WriteLine("Dato guardado!, presione una tecla para regresar al menu de Modificacion");
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
