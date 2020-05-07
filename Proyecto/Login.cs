using System;
using System.Security;
using static System.Console;

namespace Proyecto
{
    public class Login 
    {
        string user, pass;
        bool correccion = false;
        bool correccionpass = false;
        Json js = new Json();
        public void LogStart()
        {
            logwrite();
        }
        void logwrite()
        {
            Clear();
            if (correccion == true)
            {
                WriteLine("\t\tEl usuario NO existe");
                WriteLine("\t\tIntente otra vez");
            }
            else if (correccionpass == true)
            {
                WriteLine("\t\tLa contraseña NO coincide");
                WriteLine("\t\tIntente otra vez");
            }
            WriteLine("\n\t\t**********LOG IN**********");
            Write("\n\tUsuario: ");
            user = ReadLine();
            Write("\tPass: ");
            SecureString codepass = securepass();
            pass = new System.Net.NetworkCredential(string.Empty, codepass).Password;
            Comprobacion();
            }
            static SecureString securepass()
            {
                SecureString secpass = new SecureString();
                ConsoleKeyInfo keyInfo;
                do
                {
                    keyInfo = ReadKey(true);
                    if (!char.IsControl(keyInfo.KeyChar))
                    {
                        secpass.AppendChar(keyInfo.KeyChar);
                    Write("*");
                    }
                    else if (keyInfo.Key == ConsoleKey.Backspace && secpass.Length > 0)
                    {
                        secpass.RemoveAt(secpass.Length - 1);
                    Write("\b \b");
                    }
                }
                while (keyInfo.Key != ConsoleKey.Enter);
                {
                    return secpass;
                }
            }
            
            void Comprobacion()
            {
                var data = js.desUS();
                foreach (var persona in data.usuarios)
                {
                    if (user == persona.user)
                    {
                        correccion = false;
                        string EPass = Encriptacion.GetSHA256(pass);
                        if (EPass == persona.pass)
                        {
                            correccionpass = false;
                            Clear();
                            WriteLine("\n\t\tSesión accedida");
                            ReadKey();
                            if ("admin" == persona.session)
                            {
                                Clear();
                                administrador adm = new administrador();
                                adm.Init();
                                break;
                            }
                            if ("maestro" == persona.session)
                            {
                                Clear();
                                Maestro m = new Maestro();
                                m.Init();
                                break;
                            }
                            if("user" == persona.session)
                            {
                                Clear();
                                Userdata us = new Userdata();
                                us.Init(user);
                                break;
                            }
                        }
                        else if (pass != persona.pass)
                        {
                            correccionpass = true;
                            break;
                        }
                    }
                    else if (user != persona.user)
                    {
                        correccion = true;
                        //Aqui estaba el error al poner break; se cerraba el foreach y no evaluaba los otros datos 
                        continue;
                    }
                }
                if (correccion == true || correccionpass == true) logwrite();
            }
    }      
}

