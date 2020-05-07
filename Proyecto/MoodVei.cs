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

            elementos.Add("Salir al menú anterior");
            string[] MenuGetDui = elementos.ToArray();
            Clear();
            WriteLine("\tEscoja el vehículo a modificar\n");
            int opt = rs.InterMenu(MenuGetDui);
            int index = Array.IndexOf(MenuGetDui, "Salir al menú anterior");

            if (opt == index)
            {
                Clear(); administrador ad = new administrador();
                ad.Init();
            }
            string[] MenuOpcionMood = {"Entrada","dui","Marca","Placa","Color","Año","Estado","Regresar al menú anterior" };
            Menumod(MenuGetDui[opt]);

            void Menumod(string p)
            {
                Clear();
                WriteLine("\tDatos del vehículo de placa: " + p + "\n");

                foreach (var vei in dataVe.vehiculos)
                {
                    if (p == vei.placa)
                    {
                        WriteLine("Entrada del vehículo: " + vei.entrada);
                        WriteLine("Marca: " + vei.marca);
                        WriteLine("Placa: " + vei.placa);
                        WriteLine("color: " + vei.color);
                        WriteLine("Año: " + vei.año);
                        WriteLine("Estado: " + vei.reparado);
                    }
                }
                ReadKey();
                Clear();
                WriteLine("\tMenú de datos a modificar\n");
                int opt2 = rs.InterMenu(MenuOpcionMood);

                switch (opt2)
                {
                    case 0: 
                        foreach (var vei in dataVe.vehiculos)
                        {
                            if (p == vei.placa)
                            {
                                Write("\n\tEscriba la fecha de entrada en formato D/M/A: ");
                                vei.entrada = ReadLine();
                                js.Save(3,js.sereVe(dataVe));
                                WriteLine("\n\tDato guardado. Presione una tecla para regresar al menú de modificación");
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
                                Write("\n\tEscriba el DUI nuevo: ");
                                vei.dui = ReadLine();
                                js.Save(3, js.sereVe(dataVe));
                                WriteLine("\n\tDato guardado. Presione una tecla para regresar al menú de modificación");
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
                                Write("\n\tEscriba la nueva marca: ");
                                vei.marca = ReadLine();
                                js.Save(3, js.sereVe(dataVe));
                                WriteLine("\n\tDato guardado. Presione una tecla para regresar al menú de modificación");
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
                                WriteLine("\n\tEscriba la placa nueva: ");
                                vei.placa = ReadLine();
                                js.Save(3, js.sereVe(dataVe));
                                WriteLine("\n\tDato guardado. Presione una tecla para regresar al menú de modificación");
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
                                WriteLine("\n\tEscriba el nuevo color: ");
                                vei.color = ReadLine();
                                js.Save(3, js.sereVe(dataVe));
                                WriteLine("\n\tDato guardado. Presione una tecla para regresar al menú de modificación");
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
                                WriteLine("\n\tEscriba el nuevo año: ");
                                vei.año = ReadLine();
                                js.Save(3, js.sereVe(dataVe));
                                WriteLine("\n\tDato guardado. Presione una tecla para regresar al menú de modificación");
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
                                string[] estado={"Reparado","En reparación" };
                                Clear();
                                WriteLine("\nSeleccione el estado del vehículo");
                                int opt3 =rs.InterMenu(estado);
                                switch (opt3)
                                {
                                    case 0:
                                        vei.reparado = "Reparado"; break;
                                    case 1:
                                        vei.reparado = "En reparación"; break;
                                }

                                js.Save(3, js.sereVe(dataVe));
                                WriteLine("\n\tDato guardado. Presione una tecla para regresar al menú de modificación");
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
