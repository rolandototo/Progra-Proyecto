using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using static System.Console;
namespace Proyecto
{
    public class MoodCliente    
    {
        public  void Mod(string validationDUI)
        {
            Clear();
            Json js = new Json();
            var dataCl = js.desCl();
            Recursos rs = new Recursos();

            List<string> elementos = new List<string>();


            foreach (var ContClient in dataCl.clientes)
            {
                if (validationDUI == ContClient.dui)
                {
                    elementos.Add(ContClient.nombre);
                }
            }

            elementos.Add("Salir al menu anterior");
            string[] MenuGetNombre = elementos.ToArray();
            Clear();
            WriteLine("Se encontro este nombre a modificar\n");
            int opt = rs.InterMenu(MenuGetNombre);
            int index = Array.IndexOf(MenuGetNombre, "Salir al menu anterior");

            if (opt == index)
            {
                Clear(); administrador ad = new administrador();
                ad.Init();
            }

            string[] MenuOpcionMood = { "Nombre", "Dui", "Correo", "Numero","Regresar al menu anterior" };
            Menumod(MenuGetNombre[opt]);


            void Menumod(string p)
            {
                Clear();
                WriteLine("Datos del usuario" + p + "\n");

                foreach (var BuscadorUsuario in dataCl.clientes)
                {
                    if (p == BuscadorUsuario.nombre)
                    {
                        WriteLine("Nombre del cliente: " + BuscadorUsuario.nombre);

                        WriteLine("Dui: " + BuscadorUsuario.dui);
                        WriteLine("Correo: " + BuscadorUsuario.correo);
                        WriteLine("Numero: " + BuscadorUsuario.numero);
                        WriteLine("Visitas realisada: " + BuscadorUsuario.visitas);

                    }
                }
                ReadKey();
                Clear();
                WriteLine("Menu de datos a modificar\n");
                int opt2 = rs.InterMenu(MenuOpcionMood);

                switch (opt2)
                {
                    case 0:
                        foreach (var BuscadorUsuario in dataCl.clientes)
                        {
                            if (p == BuscadorUsuario.nombre)
                            {
                                WriteLine("\nEscriba el nuevo nombre del usuario: ");
                                BuscadorUsuario.nombre = ReadLine();

                                js.Save(2, js.sereCl(dataCl));
                                WriteLine("Dato guardado!, presione una tecla para regresar al menu de Modificacion");
                                ReadKey();
                                Menumod(BuscadorUsuario.nombre);
                            }
                        }
                        break;
                    case 1:
                        foreach (var BuscadorUsuario in dataCl.clientes)
                        {
                            if (p == BuscadorUsuario.nombre)
                            {
                                WriteLine("\nEscriba el Dui nuevo");
                                BuscadorUsuario.dui = ReadLine();

                                js.Save(2, js.sereCl(dataCl));
                                WriteLine("Dato guardado!, presione una tecla para regresar al menu de Modificacion");
                                ReadKey();
                                Menumod(p);
                            }
                        }
                        break;
                    case 2:
                        foreach (var BuscadorUsuario in dataCl.clientes)
                        {
                            if (p == BuscadorUsuario.nombre)
                            {
                                WriteLine("\nEscriba el nuevo correo: ");
                                BuscadorUsuario.correo = ReadLine();

                                js.Save(2, js.sereCl(dataCl));
                                WriteLine("Dato guardado!, presione una tecla para regresar al menu de Modificacion");
                                ReadKey();
                                Menumod(p);
                            }
                        }
                        break;
                    case 3:
                        foreach (var BuscadorUsuario in dataCl.clientes)
                        {
                            if (p == BuscadorUsuario.numero)
                            {
                                WriteLine("\nEscriba el nuevo numero: ");
                                BuscadorUsuario.numero = ReadLine();

                                js.Save(2, js.sereCl(dataCl));
                                WriteLine("Dato guardado!, presione una tecla para regresar al menu de Modificacion");
                                ReadKey();
                                Menumod(p);
                            }
                        }
                        break;
                    case 4:
                        Mod(validationDUI);

                        break;
                    
                }

            }




            //string name, ndui, email, number, nvisita;
            //int index = 0;

            //List<string> provisional = new List<string>();
            //foreach (var person in dataCl.clientes)
            //{
            //    if (validationDUI == person.dui)
            //    {
            //        index = dataCl.clientes.IndexOf(person);
            //        name = person.nombre;
            //        ndui = person.dui;
            //        email = person.correo;
            //        number = person.numero;
            //        nvisita = person.visitas;
            //        WriteLine("\n\t\tElige la opción que desee cambiar: \n\n\t1. Nombre \n\t2. Correo \n\t3. Número de contacto\n\t4. Número de visitas");
            //        string op = ReadLine();
            //        switch (op)
            //        {
            //            case "1": Clear(); WriteLine("\n\t\tDigite el nuevo nombre"); name = ReadLine(); break;
            //            case "2": Clear(); WriteLine("\n\t\tDigite el nuevo correo"); email = ReadLine(); break;
            //            case "3": Clear(); WriteLine("\n\t\tDigite el nuevo número de contacto"); number = ReadLine(); break;
            //            case "4": Clear(); WriteLine("\n\t\tDigite el nuevo número de visitas"); nvisita = ReadLine(); break;
            //            default: break;
            //        }
            //        provisional.Add(name);
            //        provisional.Add(ndui);
            //        provisional.Add(email);
            //        provisional.Add(number);
            //        provisional.Add(nvisita);

            //    }
            //}
            //dataCl.clientes.RemoveRange(index, 1);
            //dataCl.clientes.Add(new Clients { nombre = provisional[0], dui = provisional[1], correo = provisional[2], numero = provisional[3], visitas = provisional[4] });
            //string obj = js.sereCl(dataCl);
            //File.WriteAllText(@"clientes.json", obj);
            //provisional.Clear();
            //WriteLine("\n\t\tDatos de contacto actualizados");
            //Thread.Sleep(1000); Clear();

        }
    }
}
