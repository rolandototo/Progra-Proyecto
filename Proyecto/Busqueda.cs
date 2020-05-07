using System;
using System.Collections.Generic;
using static System.Console;

namespace Proyecto
{
    public class Busqueda : Recursos
    {
        Json js = new Json();
        administrador ad = new administrador();
        public void initBus()
        {
            Clear();
            Search();
            void Search()
            {
                List<string> ElementosDuiMenu = new List<string>();
                WriteLine("\tSeleccione el nombre del cliente a buscar\n");
                var data = js.desCl();
                foreach (var opt in data.clientes)
                {
                    ElementosDuiMenu.Add(opt.nombre);
                }
                ElementosDuiMenu.Add("Salir al menú anterior");
                string[] menutik = ElementosDuiMenu.ToArray();
                int OpcionMenu = InterMenu(menutik);
                int index = Array.IndexOf(menutik, "Salir al menú anterior");
                if (OpcionMenu == index)
                {
                    Clear();
                    ad.Init();
                }
                BusHere(menutik[OpcionMenu]);
                ReadKey();
                WriteLine("\n\tPresione cualquier tecla para regresar al menú anterior");
                ad.Init();
                Clear();
            }
        }
        public void BusHere(string wanted)
        {
            string NombrePersona = wanted;
            string validationDUI = "", validationPLACA = "";
            bool error = true;
            var dataCl = js.desCl();
            var dataVe = js.desVe();
            var dataRe = js.desRe();
            Clear();
            WriteLine("\tRESULTADO\n");

            foreach (var person in dataCl.clientes)
            {
                if (NombrePersona == person.nombre )
                {
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
                WriteLine("\n\t\tDatos NO encontrados");
            }
        }
    }
}
