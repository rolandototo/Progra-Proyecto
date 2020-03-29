using System;
using System.IO;

namespace Proyecto
{
    class SignIn
    {
        string nombre, contra, tipo;
        int opcion;
        string op;

        public SignIn()
        {
            Json js = new Json();
            ingreso();



            void ingreso()
            {

                Console.WriteLine("Ingrese datos del nuevo Usuario");

                Console.Write("Nombre: ");
                nombre = Console.ReadLine();
                Console.Write("Pass: ");
                contra = Console.ReadLine();
                valMenu();
                filtro();

            }

            void filtro()
            {
                //Lectura de la lista 

        
                var data = js.desUS();

                //Filtro de datos
                foreach (var persona in data.usuarios)
                {
                    if (nombre == persona.user)
                    {
                        Console.WriteLine("Usuario ya registrado, intente otra ves...");
                        Console.WriteLine("Precione cualquier tecla para continuar...");
                        Console.ReadKey();
                        ingreso();
                    }
                    else
                    {
                        break;
                    }
                }


                Encriptacion ec = new Encriptacion();


                string decopass = ec.Codificacion(contra);


                data.usuarios.Add(new Usuario { user = nombre, pass = decopass, session = tipo });


                string obj = js.sereUS(data);


                File.WriteAllText(@"usuarios.json", obj);
                Console.WriteLine("Usuario Guardado");
            }
            void menutipo()
            {
                Console.Write("Tipo de usuario\n\n");
                Console.WriteLine("Elija un numero de las 3 opciones de tipo de usuario:\n");
                Console.WriteLine("\t1) Usuario");
                Console.WriteLine("\t2) Administrador");
                Console.WriteLine("\t3) Maestro");
            }

            void valMenu()
            {


                Boolean opval = false;


                do
                {
                    menutipo();
                    Console.Write("Numero de opcion: ");
                    op = Console.ReadLine();

                    // Tryparse ya que devuelve datos booleanos
                    opval = int.TryParse(op, out opcion);
                    if (opval == false)
                    {
                        Console.WriteLine("Ingrese un dato corecto, un numero del 1 al 3!!!");
                    }
                }

                while (!opval);
                Console.Clear();
                type();
            }



            void type()
            {

                switch (opcion)
                {
                    case 1: tipo = "user"; break;
                    case 2: tipo = "admin"; break;
                    case 3: tipo = "maestro"; break;
                    default:

                        menutipo();
                        Console.WriteLine("Elija una opcion valida del 1 al 3");
                        valMenu();
                        type();

                        break;

                }

            }
            Console.ReadKey();
            administrador adm = new administrador();
            adm.Init();

        }



    }
}
