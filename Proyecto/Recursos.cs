using System;
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
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                    Console.Write(lol[i] + "\n");

                    Console.ResetColor();
                }
               

                switch (Console.ReadKey(true).Key)
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



                if (!done) Console.CursorTop = 2;

            }
            return selected;
        }
    }
}
