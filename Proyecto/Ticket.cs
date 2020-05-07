using System;
using System.Collections.Generic;
using System.IO;

namespace Proyecto
{
    public class Ticket
    {
        Json js = new Json();
        Recursos rs = new Recursos();
        string dui, NombreUsuario;
        public void menutike(string nm)
        {
            var DataVe = js.desVe();
            var DataCl = js.desCl();
            List<string> elementos = new List<string>();
            foreach (var clien in DataCl.clientes)
            {
                if (nm == clien.nombre)
                {
                    dui = clien.dui;
                    NombreUsuario = clien.nomusuario;
                }
            }
            foreach (var vei in DataVe.vehiculos)
            {
                if (dui == vei.dui)
                {
                    elementos.Add(vei.placa);
                }
            }
            elementos.Add("Salir al menú anterior");
            string[] menutik = elementos.ToArray();
            Console.WriteLine("Escoja el vehíulo para imprimir el tiket\n");

            int opt =rs.InterMenu(menutik);
            int index = Array.IndexOf(menutik, "Salir al menú anterior");

            if (opt == index)
            {
                Console.Clear(); Userdata us = new Userdata();
                us.Init(NombreUsuario);
            }
            PintTiket(menutik[opt],nm);
        }

        void PintTiket(string placa, string nombre)
        {
            var DataVe = js.desVe();
            var DataCl = js.desCl();
            var DataRe = js.desRe();
            if (File.Exists(@"ticket.txt"))
            {
                File.Delete(@"ticket.txt");
                FileStream fl = File.Create(@"ticket.txt");
                fl.Close();
            }
            else
            {
                FileStream fl = File.Create(@"ticket.txt");
                fl.Close();
            }
            using (StreamWriter output = new StreamWriter(@"ticket.txt")) { 
            Console.WriteLine("\tTaller de la empresa");
                output.WriteLine("\tTaller de la empresa");
            Console.WriteLine("Tiket #:");
                output.WriteLine("Tiket #:");
                Console.WriteLine("***************");
                output.WriteLine("***************");
                Console.WriteLine("Cliente: "+ nombre);
                output.WriteLine("Cliente: " + nombre);
                Console.WriteLine("Placa: "+placa);
                output.WriteLine("Placa: " + placa);
                Console.Write("\nFecha: "+ DateTime.Today.ToString("d"));
                output.Write("\nFecha: " + DateTime.Today.ToString("d"));
                Console.Write("\t"+DateTime.Now.ToString("hh:mm:ss"));
                output.Write("\t" + DateTime.Now.ToString("hh:mm:ss"));
                Console.WriteLine("\n***************");
                output.WriteLine("\n***************");
                Console.WriteLine("Artículo\t|Precio|Costo Hora|Horas Trabajadas|Importe|");
                output.WriteLine("Artículo\t|Precio|Costo Hora|Horas Trabajadas|Importe|");
                Console.WriteLine("***************");
                output.WriteLine("***************");

                List<string> elerepa = new List<string>();
            string[] repa = elerepa.ToArray();
            double ContTotal = 0;
            int conRepa = 0;
            foreach (var rep in DataRe.reparaciones)
            {
                if (placa == rep.placa)
                {
                    double total = double.Parse(rep.costomaterial) + (double.Parse(rep.costohora) * double.Parse(rep.horas));
                    string ttstrin = total.ToString();
                    string[] producto = { rep.materiales, rep.costomaterial, rep.costohora, rep.horas, ttstrin };
                    rs.tiketPro(producto);
                    ContTotal = ContTotal + total;
                    conRepa++;
                }
            }

            Console.WriteLine("SubTotal: "+ContTotal);
                output.WriteLine("SubTotal: " + ContTotal);
                bool Sale2 = false;
            bool Sale10 = false;
            int Descu = 0;
            foreach (var clin in DataCl.clientes)
            {
                if (nombre == clin.nombre)
                {
                    if (int.Parse(clin.visitas)>2)
                    {
                        Sale2 = true;
                    }
                    if (int.Parse(clin.visitas)>10)
                    {
                        Sale10 = true;
                    }
                }
            }

            if (Sale2 == true && Sale10 == false)
            {
                Descu = 5;
            }
            else if (Sale2 == true && Sale10 == true)
            {
                Descu = 10;
            }

            if (Descu == 0)
            {
                Console.WriteLine("Descuento aplicado: 0");
                Console.WriteLine("\nTotal: " +ContTotal);
                    output.WriteLine("Descuento aplicado: 0");
                    output.WriteLine("\nTotal: " + ContTotal);
                }
            else
            {
                double porcent = 0;
                if (Descu == 5) porcent = 0.05;
                if (Descu == 10) porcent = 0.10;
                Console.WriteLine("Descuento aplicado: "+Descu+"%");
                Console.WriteLine("\nTotal: " + (ContTotal-(ContTotal * porcent)));
                    output.WriteLine("Descuento aplicado: " + Descu + "%");
                    output.WriteLine("\nTotal: " + (ContTotal - (ContTotal * porcent)));
                }
            Console.WriteLine("Reparaciones hechas: "+conRepa);
                output.WriteLine("Reparaciones hechas: " + conRepa);
            }
        string dot()
        {
            string line = "";
            for (int i = 0; i < 15; i++)
            {
                line.Insert(line.Length,"*"); 
            }
            return line;
        }
        }
    }
}
