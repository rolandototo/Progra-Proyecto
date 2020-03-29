using System;
using System.Security;

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

                Console.Clear();
                if (correccion == true)
                {
                    Console.WriteLine("El usuario no exixte!!! ");
                    Console.WriteLine("Intente otra ves");
                }
                else if (correccionpass == true)
                {
                    Console.WriteLine("El pass no coinside!!! ");
                    Console.WriteLine("Intente otra ves");
                }


                Console.WriteLine("**********LOG IN**********");
                Console.Write("Usuario: ");
                user = Console.ReadLine();
                Console.Write("Pass: ");
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
                    keyInfo = Console.ReadKey(true);
                    if (!char.IsControl(keyInfo.KeyChar))
                    {
                        secpass.AppendChar(keyInfo.KeyChar);
                        Console.Write("*");
                    }
                    else if (keyInfo.Key == ConsoleKey.Backspace && secpass.Length > 0)
                    {
                        secpass.RemoveAt(secpass.Length - 1);
                        Console.Write("\b \b");
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
                            Console.Clear();
                            Console.WriteLine("Sesion accedida!!!");
                            Console.ReadKey();

                                if ("admin" == persona.session)
                                {
                                    Console.Clear();
                            administrador adm = new administrador();
                            adm.Init();

                                    break;
                                }
                                if ("maestro" == persona.session)
                                {
                                    Console.Clear();
                            Maestro m = new Maestro();
                            m.Init();

                                    break;
                                }
                                if("user" == persona.session)
                                {

                            Console.Clear();

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



                if (correccion == true || correccionpass == true)
                {
                    logwrite();
                }

            }

        }
        

    }

