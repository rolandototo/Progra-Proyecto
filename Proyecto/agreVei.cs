using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;

namespace Proyecto

{
    public class agreVei
    {
       

        public agreVei()
        {
            Json js = new Json();

            var data = js.desCl();
            WriteLine("Agregar vehiculos a un cliente");
            WriteLine("Ingrese el nombre del cliente a ingresar");
            string nom = ReadLine();
            WriteLine("Que marca del vehiculo es?");
            string marc = ReadLine();
            WriteLine("Cual es la placa del vehiculo?");
            string plac = ReadLine();
            WriteLine("Que color es el vehiculo?");
            string colo = ReadLine();
            WriteLine("Que año es el vehiculo es?");
            string an = ReadLine();
            WriteLine("Que reparaciones necesita?");

            List<string> repa = new List<string>();
            bool conti = false;
            do
            {
                repa.Add(ReadLine());
                WriteLine("Desea agregar otra reparacion? (y/n)");

                char confir = char.Parse(ReadLine());

                if (confir == 'n' || confir == 'N') conti = true;
                else if (confir == 's' || confir == 'S') conti = false;
                else WriteLine("Escriba una opcion valida");

            }
            while (!conti);



            foreach (var persona in data.clientes)
            {
                if (nom == persona.nombre)
                {
                    persona.veiculos.Add(new Veiculo { marca = marc , placa = plac, color = colo, ano = an, reparaciones = repa});

                    File.WriteAllText(@"taller.json", js.sereCl(data));
                    WriteLine("Usuario Guardado");
                    break;
                }

            }



        }
    }
}
