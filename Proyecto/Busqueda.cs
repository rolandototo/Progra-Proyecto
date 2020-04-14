using System;
using static System.Console;

namespace Proyecto
{
    public class Busqueda
    {
        Json js = new Json();
        bool correccion = false;



        public Busqueda()
        {
            var data = js.desCl();

            FunBus();

            void FunBus()
            {
                WriteLine("////Ingrese el nombre o el dui del usuario a buscar////");
                Write("\n////");
                string busc = ReadLine();

                foreach (var persona in data.clientes)
                {
                    
                        foreach (var car in persona.veiculos)
                        {
                            correccion = false;

                                if (busc == persona.nombre || busc == persona.dui || busc == car.placa)
                                {
                                    correccion = false;
                            WriteLine("\n....Nombre: " + persona.nombre);
                            WriteLine("....Dui: " + persona.dui);
                            WriteLine("....Correo: " + persona.correo);
                            WriteLine("\n....Marca: " + car.marca);
                            WriteLine("....Placa: " + car.placa);
                            WriteLine("....Año: " + car.ano);
                            WriteLine("....Color: " + car.color);

                                    foreach (var repa in car.reparaciones)
                                    {
                                        correccion = false;
                                WriteLine("\n.......Repareciones: " + repa);
                                        break;
                                       
                                    }
                                }

                                else if (busc != persona.nombre || busc != persona.dui || busc != car.placa)
                                {
                                    correccion = true;
                                    continue;
                                }

                        }

                        if (correccion == false) break;
                   
                }

                if(correccion == true)
                {
                    WriteLine("El nombre a buscar no existe en la base de datos...");
                    WriteLine("Ingrese un nombre corecto");
                    Write("\n\nApreta cualquier tecla para continuar....");
                    ReadKey();
                    Clear();
                    FunBus();
                }
                Write("\n\nApreta cualquier tecla para regresar al menu....");
                ReadKey();
                Clear();
                administrador adm = new administrador();
                adm.Init();

            }

           


        }
    }

}
