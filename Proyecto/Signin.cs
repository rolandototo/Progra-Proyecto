using System;
using System.IO;
using static System.Console;

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
                WriteLine("Ingrese datos del nuevo Usuario");
                Write("Nombre: ");
                nombre = ReadLine();
                Write("Pass: ");
                contra = ReadLine();
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
                        WriteLine("Usuario ya registrado, intente otra ves...");
                        WriteLine("Precione cualquier tecla para continuar...");
                        ReadKey();
                        ingreso();
                    }
                    else break;
                   
                }


                Encriptacion ec = new Encriptacion();


                string decopass = Encriptacion.GetSHA256(contra);


                data.usuarios.Add(new Usuario { user = nombre, pass = decopass, session = tipo });


                File.WriteAllText(@"usuarios.json", js.sereUS(data));
                WriteLine("Usuario Guardado");
            }
            void menutipo()
            {
                Write("Tipo de usuario\n\n");
                WriteLine("Elija un numero de las 3 opciones de tipo de usuario:\n");
                WriteLine("\t1) Usuario");
                WriteLine("\t2) Administrador");
                WriteLine("\t3) Maestro");
            }

            void valMenu()
            {


                Boolean opval = false;


                do
                {
                    menutipo();
                    Write("Numero de opcion: ");
                    op = ReadLine();

                    // Tryparse ya que devuelve datos booleanos
                    opval = int.TryParse(op, out opcion);
                    if (opval == false) WriteLine("Ingrese un dato corecto, un numero del 1 al 3!!!");

                }

                while (!opval);
                Clear();
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
                        WriteLine("Elija una opcion valida del 1 al 3");
                        valMenu();
                        type();

                        break;

                }

            }
            ReadKey();
            administrador adm = new administrador();
            adm.Init();

        }



    }
}
