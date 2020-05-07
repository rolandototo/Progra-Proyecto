using System;

using static System.Console;

namespace Proyecto
{
    public class Recursos
    {
        public int InterMenu(string[] lol)
        {
            int optionsCoun = lol.Length;
            int selected = 0;
            bool done = false;
          
            while (!done)
            {

                for (int i = 0; i < optionsCoun; i++)
                {
                    if (selected == i)
                    {
                        ForegroundColor = ConsoleColor.Cyan;
                        Write("> ");
                    }
                    else
                    {
                        Write("  ");
                    }
                    Write(lol[i] + "\n");
                    ResetColor();
                }


                switch (ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        selected = Math.Max(0, selected - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selected = Math.Min(optionsCoun - 1, selected + 1);
                        break;
                    case ConsoleKey.Enter:
                        done = true;
                        break;
                    
                }



                if (!done) CursorTop = 2;

            }
            return selected;
        }

        public void White() { ForegroundColor = ConsoleColor.White; }
        public void DBlue() { ForegroundColor = ConsoleColor.DarkBlue; }
        public void DCyan() { ForegroundColor = ConsoleColor.DarkCyan; }
        public void DYellow() { ForegroundColor = ConsoleColor.DarkYellow; }
        public void DGray() { ForegroundColor = ConsoleColor.DarkGray; }
        public void Cyan() { ForegroundColor = ConsoleColor.Cyan; }

        public void tiketPro(string[] a)
        {
            string[] x = a;

            for (int i = 1; i <= 20; i++)
            {
                if (i == 1)
                {
                    Console.Write(" * " + x[0]);

                }
                if (i > x[0].Length)
                {
                    Console.Write(".");
                }
                if (i == 15)
                {

                    for (int t = 1; t <= 10; t++)
                    {
                        if (t == 1)
                        {
                            Console.Write(x[1]);
                        }
                        if (t > x[1].Length)
                        {
                            Console.Write(".");
                        }

                        if (t == 10)
                        {


                            for (int q = 1; q <= 10; q++)
                            {
                                if (q == 1)
                                {
                                    Console.Write(x[2]);
                                }
                                if (q > x[2].Length)
                                {
                                    Console.Write(".");
                                }

                                if (q == 10)
                                {


                                    for (int z = 1; z <= 10; z++)
                                    {
                                        if (z == 1)
                                        {
                                            Console.Write(x[3]);
                                        }
                                        if (z > x[3].Length)
                                        {
                                            Console.Write(".");
                                        }

                                        if (z == 10)
                                        {

                                            Console.Write(x[4]);


                                        }

                                    }

                                }
                            }
                        }
                    }


                }

            }
        }
    }
}
