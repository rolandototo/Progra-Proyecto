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

    }
}
