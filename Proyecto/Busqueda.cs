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
            Clear();
            bool error = true;
            Search();

            void Search()
            {
                WriteLine("\n\t\tIngrese el nombre del cliente o número de DUI que desea buscar:");
                string wanted = ReadLine().ToString();
                string validationDUI = "", FastOp = "", validationPLACA = "";
                Json js = new Json();
                var dataCl = js.desCl();
                var dataVe = js.desVe();
                var dataRe = js.desRe();
                Clear();
                WriteLine("\n\t\tRESULTADO");

                foreach (var person in dataCl.clientes)
                {
                    if (wanted == person.nombre || wanted == person.dui)
                    {
                        WriteLine("\n[A] Agregar vehículo [B] Editar datos de cliente [C] Editar datos de vehículo");
                        error = false;
                        Write("\n\tNombre: ");
                        WriteLine(person.nombre);
                        Write("\tDUI: ");
                        WriteLine(person.dui);
                        Write("\tNúmero cel.: ");
                        WriteLine(person.numero);
                        Write("\tCorreo: ");
                        WriteLine(person.correo);
                        validationDUI = person.dui;
                        foreach (var car in dataVe.vehiculos)
                        {
                            if (validationDUI == car.dui)
                            {
                                error = false;
                                Write("\tMarca de carro: ");
                                WriteLine(car.marca);
                                Write("\t" + "Placa: ");
                                WriteLine(car.placa);
                                Write("\t" + "Año: ");
                                WriteLine(car.año);
                                Write("\t" + "Color: ");
                                WriteLine(car.color);
                                validationPLACA = car.placa;
                                foreach (var daño in dataRe.reparaciones)
                                {
                                    if (validationPLACA == daño.placa)
                                    {
                                        Write("\tReparación de: ");
                                        WriteLine(daño.reparacion);
                                        Write("\tMateriales para repación: ");
                                        WriteLine(daño.materiales);
                                        Write("\tCosto de materiales: ");
                                        WriteLine(daño.costomaterial);
                                        Write("\tHoras en repación: ");
                                        WriteLine(daño.horas);
                                        Write("\tCosto por hora de mano de obra: ");
                                        WriteLine(daño.costohora);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                if (error == true)
                {
                    WriteLine("\n\t\tDatos no encontrados");
                }

                Clear(); 
            }


        }
    }

}
