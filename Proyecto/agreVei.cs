using System;
using System.IO;
using System.Collections.Generic;
namespace Proyecto

{
    public class agreVei
    {
       

        public agreVei()
        {
            Json js = new Json();

            var data = js.desCl();

            Console.WriteLine("Agregar vehiculos a un cliente");
            Console.WriteLine("Ingrese el nombre del cliente a ingresar");
            string nom = Console.ReadLine();
            Console.WriteLine("Que marca del vehiculo es?");
            string marc = Console.ReadLine();
            Console.WriteLine("Cual es la placa del vehiculo?");
            string plac = Console.ReadLine();
            Console.WriteLine("Que color es el vehiculo?");
            string colo = Console.ReadLine();
            Console.WriteLine("Que año es el vehiculo es?");
            string an = Console.ReadLine();
            Console.WriteLine("Que reparaciones necesita?");
            List<string> repa = new List<string>();
            bool conti = false;
            do
            {
                repa.Add(Console.ReadLine());

                Console.WriteLine("Desea agregar otra reparacion? (y/n)");

                char confir = char.Parse(Console.ReadLine());
                if(confir == 'n'|| confir == 'N')
                {
                    conti = true;
                }
            }
            while (!conti);



            foreach (var persona in data.clientes)
            {
                if (nom == persona.nombre)
                {
                    persona.veiculos.Add(new Veiculo { marca = marc , placa = plac, color = colo, ano = an, reparaciones = repa});
                    string obj = js.sereCl(data);


                    File.WriteAllText(@"taller.json", obj);
                    Console.WriteLine("Usuario Guardado");
                    break;
                }

            }



        }
    }
}
