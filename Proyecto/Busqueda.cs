using System;
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
               
                Console.WriteLine("////Ingrese el nombre o el dui del usuario a buscar////");
                Console.Write("\n////");
                string busc = Console.ReadLine();

                foreach (var persona in data.clientes)
                {
                    
                        foreach (var car in persona.veiculos)
                        {
                            correccion = false;

                                if (busc == persona.nombre || busc == persona.dui || busc == car.placa)
                                {
                                    correccion = false;

                                    Console.WriteLine("\n....Nombre: " + persona.nombre);
                                    Console.WriteLine("....Dui: " + persona.dui);
                                    Console.WriteLine("....Correo: " + persona.correo);
                                    Console.WriteLine("\n....Marca: " + car.marca);
                                    Console.WriteLine("....Placa: " + car.placa);
                                    Console.WriteLine("....Año: " + car.ano);
                                    Console.WriteLine("....Color: " + car.color);

                                    foreach (var repa in car.reparaciones)
                                    {
                                        correccion = false;
                                        Console.WriteLine("\n.......Repareciones: " + repa);
                                        break;
                                       
                                    }
                                }

                                else if (busc != persona.nombre || busc != persona.dui || busc != car.placa)
                                {
                                    correccion = true;
                                    continue;
                                }

                        }

                        if (correccion == false)
                        {
                            break;
                        }
                }

                if(correccion == true)
                {

                    Console.WriteLine("El nombre a buscar no existe en la base de datos...");
                    Console.WriteLine("Ingrese un nombre corecto");
                    Console.Write("\n\nApreta cualquier tecla para continuar....");
                    Console.ReadKey();
                    Console.Clear();
                    FunBus();
                }

                Console.Write("\n\nApreta cualquier tecla para regresar al menu....");
                Console.ReadKey();
                Console.Clear();
                administrador adm = new administrador();
                adm.Init();

            }

           


        }
    }

}
