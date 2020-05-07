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
        public void InitSing()
        {
            Json js = new Json();
            ingreso();

            void ingreso()
            {
                WriteLine("Ingrese datos del nuevo usuario");
                Write("Nombre: ");
                nombre = ReadLine();
                Write("Pass: ");
                contra = ReadLine();
                menutipo();
                filtro();
            }

            void menutipo()
            {
                Clear();
                WriteLine("Tipo de usuario\n");
                string[] MenuOpt = { "Usuario", "Administrador", "Maestro" };
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
                        WriteLine("Usuario ya registrado, intente otra vez");
                        WriteLine("Presione cualquier tecla para continuar");
                        ReadKey();
                        ingreso();
                    }
                   
                }

                Encriptacion ec = new Encriptacion();
                string decopass = Encriptacion.GetSHA256(contra);
                data.usuarios.Add(new Usuario { user = nombre, pass = decopass, session = tipo });
                js.Save(1, js.sereUS(data));
                WriteLine("Usuario guardado");
                if (tipo == "user")
                {
                    DataUser(nombre);
                }
            }
        }

        public void DataUser(string a)
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

            dataCl.clientes.Add(new Clients { nomusuario= a, nombre = name, dui = ndui, correo = email, numero = number, visitas = nvisita });
            js.Save(2,js.sereCl(dataCl));
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
            string ndui = validationDUI, brand, plate, colors, year, entrada;

            WriteLine("\n\t\tIngrese los datos del vehículo");
            Write("Entrada del vehículo D/M/A: ");
            entrada = ReadLine();
            Write("\n\tMarca: ");
            brand = ReadLine();
            Write("\tPlaca: ");
            plate = ReadLine();
            Write("\tColor: ");
            colors = ReadLine();
            Write("\tAño: ");
            year = ReadLine();

            dataVe.vehiculos.Add(new Vehicles {entrada = entrada, dui = ndui, marca = brand, placa = plate, color = colors, año = year, reparado = "En Reparacion" });
            js.Save(3, js.sereVe(dataVe));
            WriteLine("\n\t\tDatos de vehículo guardados");
            Thread.Sleep(1000); Clear();
            AddReparation(plate);

        }
        public void AddReparation(string validationPLACA)
        {
            Json js = new Json();
            var dataRe = js.desRe();
            string nplaca = validationPLACA, reparacion, date, repa, estadoREPA, materials, costm, hour, costh, VarEmpty = string.Empty;

            WriteLine("\n\t\tIngrese los datos de la reparación");
            Write("\n\tFecha de ingreso del vehículo al taller: ");
            date = ReadLine();
            Write("\tParte del vehículo a reparar: ");
            repa = ReadLine();
            Write("\tEstado de reparación: ");
            estadoREPA = ReadLine();
            SeleRe();
            void SeleRe()
            {
                Clear();
                Write("\t¿Desea agregar costos y materiales en este momento?     Presione [y] Para continuar  [n] Para Saltar");
                switch (ReadKey(true).Key)
                {
                    case ConsoleKey.Y:
                        Write("\tReparación a hacer: ");
                        reparacion = ReadLine();
                        Write("\tMateriales: ");
                        materials = ReadLine();
                        Write("\tCosto de materiales: ");
                        costm = ReadLine();
                        Write("\tHoras de mano de obra: ");
                        hour = ReadLine();
                        Write("\tCosto de mano de obra por hora: ");
                        costh = ReadLine();
                        break;
                    case ConsoleKey.N:
                        reparacion = VarEmpty;
                        materials = VarEmpty;
                        costm = VarEmpty;
                        hour = VarEmpty;
                        costh = VarEmpty;
                        break;
                    default:
                        SeleRe();
                   
                    break;
                }
            }

            dataRe.reparaciones.Add(new Reparation {reparacion = repa, materiales = materials, placa = nplaca, costomaterial = costm, horas = hour, costohora = costh, estadodeReparacion = estadoREPA });
            js.Save(4, js.sereRe(dataRe));
            WriteLine("\n\t\tDatos de reparación guardados");
        }

    }
}
