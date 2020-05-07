using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;
using System.Threading;
namespace Proyecto
{
    public class MoodVei
    {
        public void ModVehiculo(string validationDUI)
        {
            Json js = new Json();
            Recursos rs = new Recursos();
            var dataVe = js.desVe();
            List<string> elementos = new List<string>();


            foreach (var Vei in dataVe.vehiculos)
            {
                if (validationDUI == Vei.dui)
                {
                    elementos.Add(Vei.placa);
                }
            }

            elementos.Add("Salir al menu anterior");
            string[] MenuGetDui = elementos.ToArray();
            Clear();
            WriteLine("Escoja el veiculo a modificar\n");
            int opt = rs.InterMenu(MenuGetDui);
            int index = Array.IndexOf(MenuGetDui, "Salir al menu anterior");

            if (opt == index)
            {
                Clear(); administrador ad = new administrador();
                ad.Init();
            }


            string[] MenuOpcionMood = {"Entrada","dui","Marca","Placa","Color","Año","Estado","Regresar al menu anterior" };
            Menumod(MenuGetDui[opt]);


            void Menumod(string p)
            {
                Clear();
                WriteLine("Datos del veiculo de placa " + p + "\n");

                foreach (var vei in dataVe.vehiculos)
                {
                    if (p == vei.placa)
                    {
                        WriteLine("Entrada del veiculo: " + vei.entrada);

                        WriteLine("Marca: " + vei.marca);
                        WriteLine("Placa: " + vei.placa);
                        WriteLine("color: " + vei.color);
                        WriteLine("Año: " + vei.año);
                        WriteLine("Estado: " + vei.reparado);

                    }
                }
                ReadKey();
                Clear();
                WriteLine("Menu de datos a modificar\n");
                int opt2 = rs.InterMenu(MenuOpcionMood);

                switch (opt2)
                {
                    case 0: 
                        foreach (var vei in dataVe.vehiculos)
                        {
                            if (p == vei.placa)
                            {
                                WriteLine("\nEscriba la fecha dde entreda en formato D/M/A");
                                vei.entrada = ReadLine();

                                js.Save(3,js.sereVe(dataVe));
                                WriteLine("Dato guardado!, presione una tecla para regresar al menu de Modificacion");
                                ReadKey();
                                Menumod(p);
                            }
                        }
                        break;
                    case 1:
                        foreach (var vei in dataVe.vehiculos)
                        {
                            if (p == vei.placa)
                            {
                                WriteLine("\nEscriba el Dui nuevo");
                                vei.dui = ReadLine();

                                js.Save(3, js.sereVe(dataVe));
                                WriteLine("Dato guardado!, presione una tecla para regresar al menu de Modificacion");
                                ReadKey();
                                Menumod(p);
                            }
                        }
                        break;
                    case 2:
                        foreach (var vei in dataVe.vehiculos)
                        {
                            if (p == vei.placa)
                            {
                                WriteLine("\nEscriba la nueva marca");
                                vei.marca = ReadLine();

                                js.Save(3, js.sereVe(dataVe));
                                WriteLine("Dato guardado!, presione una tecla para regresar al menu de Modificacion");
                                ReadKey();
                                Menumod(p);
                            }
                        }
                        break;
                    case 3:
                        foreach (var vei in dataVe.vehiculos)
                        {
                            if (p == vei.placa)
                            {
                                WriteLine("\nEscriba la Placa nueva");
                                vei.placa = ReadLine();

                                js.Save(3, js.sereVe(dataVe));
                                WriteLine("Dato guardado!, presione una tecla para regresar al menu de Modificacion");
                                ReadKey();
                                Menumod(vei.placa);
                            }
                        }
                        break;
                    case 4:
                        foreach (var vei in dataVe.vehiculos)
                        {
                            if (p == vei.placa)
                            {
                                WriteLine("\nEscriba el nuevo color");
                                vei.color = ReadLine();

                                js.Save(3, js.sereVe(dataVe));
                                WriteLine("Dato guardado!, presione una tecla para regresar al menu de Modificacion");
                                ReadKey();
                                Menumod(p);
                            }
                        }
                        break;
                    case 5:
                        foreach (var vei in dataVe.vehiculos)
                        {
                            if (p == vei.placa)
                            {
                                WriteLine("\nEscriba el nuevo año");
                                vei.año = ReadLine();

                                js.Save(3, js.sereVe(dataVe));
                                WriteLine("Dato guardado!, presione una tecla para regresar al menu de Modificacion");
                                ReadKey();
                                Menumod(p);
                            }
                        }
                        break;
                    case 6:
                        foreach (var vei in dataVe.vehiculos)
                        {
                            if (p == vei.placa)
                            {
                                string[] estado={"Reparado","En Reparacion" };
                                Clear();
                                WriteLine("\nSeleccion el Estado del veiculo");
                                int opt3 =rs.InterMenu(estado);
                                switch (opt3)
                                {
                                    case 0:
                                        vei.reparado = "Reparado"; break;
                                    case 1:
                                        vei.reparado = "En Reparacion"; break;
                                }

                                js.Save(3, js.sereVe(dataVe));
                                WriteLine("Dato guardado!, presione una tecla para regresar al menu de Modificacion");
                                ReadKey();
                                Menumod(p);
                            }
                        }
                        break;
                    case 7:
                        ModVehiculo(validationDUI);
                        break;

                }

            }



            //string pdui, pmarca, pplaca, pcolor, paño, pestado;
            //int index = 0;

            //List<string> provisionalVe = new List<string>();
            //foreach (var car in dataVe.vehiculos)
            //{
            //    if (validationDUI == car.dui)
            //    {
            //        index = dataVe.vehiculos.IndexOf(car);
            //        pdui = car.dui;
            //        pmarca = car.marca;
            //        pplaca = car.placa;
            //        pcolor = car.color;
            //        paño = car.año;
            //        pestado = car.estado;

            //        WriteLine("\n\t\tElige la opción que desee cambiar: \n\n\t1. Marca \n\t2. Placa \n\t3. Color\n\t4. Año\n\t5. Estado");
            //        string op = ReadLine();
            //        switch (op)
            //        {
            //            case "1": Clear(); WriteLine("\n\t\tDigite la nueva marca"); pmarca = ReadLine(); break;
            //            case "2": Clear(); WriteLine("\n\t\tDigite la nueva placa"); pplaca = ReadLine(); break;
            //            case "3": Clear(); WriteLine("\n\t\tDigite el nuevo color"); pcolor = ReadLine(); break;
            //            case "4": Clear(); WriteLine("\n\t\tDigite el nuevo año"); paño = ReadLine(); break;
            //            case "5": Clear(); WriteLine("\n\t\tDigite el nuevo estado"); pestado = ReadLine(); break;
            //            default: break;
            //        }
            //        provisionalVe.Add(pdui);
            //        provisionalVe.Add(pmarca);
            //        provisionalVe.Add(pplaca);
            //        provisionalVe.Add(pcolor);
            //        provisionalVe.Add(paño);
            //        provisionalVe.Add(pestado);
            //    }
            //}
            //dataVe.vehiculos.RemoveRange(index, 1);
            //dataVe.vehiculos.Add(new Vehicles { dui = provisionalVe[0], marca = provisionalVe[1], placa = provisionalVe[2], color = provisionalVe[3], año = provisionalVe[4], estado = provisionalVe[5] });
            //string obj = js.sereVe(dataVe);
            //File.WriteAllText(@"vehiculos.json", obj);
            //provisionalVe.Clear();
            //WriteLine("\n\t\tDatos de vehículo actualizados");
            //Thread.Sleep(1000); Clear();
        }
    }
}
