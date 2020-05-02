using System;
using System.Threading;
using System.IO;
using static System.Console;

namespace Proyecto
{
    class SignIn : Recursos
    {
        string nombre, contra, tipo;
        int opcion;


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
                menutipo();
                filtro();

            }

            void menutipo()
            {
                Write("Tipo de usuario\n");
                string[] MenuOpt = { "Usuario","Administrador","Maestro" };
                opcion = InterMenu(MenuOpt);
                switch (opcion)
                {
                    case 0: tipo = "user"; break;
                    case 1: tipo = "admin"; break;
                    case 2: tipo = "maestro"; break;

                }
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
                DataUser();
            }

            //ReadKey();
            //administrador adm = new administrador();
            //adm.Init();

        }

        public void DataUser()
        {
            Json js = new Json();
            var dataCl = js.desCl();
            string name, ndui, email, number, nvisita;
            //string VarEmpty = string.Empty;
            Clear();
            WriteLine("\n\t\tIngrese los datos del NUEVO cliente");
            Write("\n\tNombre: ");
            name = ReadLine();
            Write("\tDUI: ");
            ndui = ReadLine();
            Write("\tCorreo: ");
            email = ReadLine();
            Write("\tNúmero de contacto: ");
            number = ReadLine();
            nvisita = string.Empty;

            dataCl.clientes.Add(new Clients { nombre = name, dui = ndui, correo = email, numero = number, visitas = nvisita });
            File.WriteAllText(@"clientes.json", js.sereCl(dataCl));
            WriteLine("\n\t\tDatos de contacto guardados");
            Thread.Sleep(1000); 
            Clear();
            AddCar(ndui);
            ReadKey();
        }
        public void AddCar(string validationDUI)
        {
            Json js = new Json();
            var dataVe = js.desVe();
            string ndui = validationDUI, brand, plate, colors, year, estadoVE;

            WriteLine("\n\t\tIngrese los datos del vehículo");

            Write("\n\tMarca: ");
            brand = ReadLine();
            Write("\tPlaca: ");
            plate = ReadLine();
            Write("\tColor: ");
            colors = ReadLine();
            Write("\tAño: ");
            year = ReadLine();
            Write("\tEstado del vehículo: ");
            estadoVE = ReadLine();

            dataVe.vehiculos.Add(new Vehicles { dui = ndui, marca = brand, placa = plate, color = colors, año = year, estado = estadoVE });
            File.WriteAllText(@"vehiculos.json", js.sereVe(dataVe));
            WriteLine("\n\t\tDatos de vehículo guardado");
            Thread.Sleep(1000); Clear();
            AddReparation(plate);

        }
        public void AddReparation(string validationPLACA)
        {
            Json js = new Json();
            var dataRe = js.desRe();
            string nplaca = validationPLACA, date, repa, estadoREPA, opt, materials, costm, hour, costh, tcuenta, VarEmpty = string.Empty;

            WriteLine("\n\t\tIngrese los datos de la reparación");
            Write("\n\tFecha de ingreso del vehículo al taller: ");
            date = ReadLine();
            Write("\tParte del vehículo a reparar: ");
            repa = ReadLine();
            Write("\tEstado de reparación: ");
            estadoREPA = ReadLine();
            Write("\t¿Desea agregar costos y materiales en este momento? Digite [SI] Para continuar    [NO] Para ");
            opt = ReadLine();
            if (opt == "SI")
            {
                Write("\tMateriales: ");
                materials = ReadLine();
                Write("\tCosto de materiales: ");
                costm = ReadLine();
                Write("\tHoras de mano de obra: ");
                hour = ReadLine();
                Write("\tCosto de mano de obra por hora: ");
                costh = ReadLine();

            }
            else
            {
                materials = VarEmpty;
                costm = VarEmpty;
                hour = VarEmpty;
                costh = VarEmpty;
            }
            tcuenta = VarEmpty;
            dataRe.reparaciones.Add(new Reparation { fecha = date, reparacion = repa, materiales = materials, placa = nplaca, costomaterial = costm, horas = hour, costohora = costh, cuenta = tcuenta, estadodeReparacion = estadoREPA });
            File.WriteAllText(@"reparaciones.json", js.sereRe(dataRe));
            WriteLine("\n\t\tDatos de reparación guardado");
        }
    }
}
