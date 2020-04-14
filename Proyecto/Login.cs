using System;
using System.Security;
using static System.Console;

namespace Proyecto
{
    public class Login 
    {


            string user;
            string pass;
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
                WriteLine("El usuario no exixte!!! ");
                WriteLine("Intente otra ves");
                }
                else if (correccionpass == true)
                {
                WriteLine("El pass no coinside!!! ");
                WriteLine("Intente otra ves");
                }
            WriteLine("**********LOG IN**********");
            Write("Usuario: ");
                user = ReadLine();
            Write("Pass: ");
                SecureString codepass = securepass();
                pass = new System.Net.NetworkCredential(string.Empty, codepass).Password;
                Comprovacion();

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
            
            void Comprovacion()
            {
                var data = js.desUS();
                foreach (var persona in data.usuarios)
                {

                    if (user == persona.user)
                    {
                        correccion = false;
                        Encriptacion ec = new Encriptacion();
                        string decopass = ec.Decodificacion(persona.pass);


                        if (pass == decopass)
                        {
                            correccionpass = false;
                        Clear();
                        WriteLine("Sesion accedida!!!");
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

