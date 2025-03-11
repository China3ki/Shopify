using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Components
{
    class Frame
    {
        /// <summary>
        /// Renderuje fajną ramkę
        /// </summary>
        public void RenderBorder()
        {
            for(int x = 0; x < Console.WindowWidth; x++)
            {
                for(int y = 0; y < Console.WindowHeight; y++)
                {
                    Console.SetCursorPosition(x, y);
                    if (x == 0 && y == 0) Console.Write('╔');
                    else if (x == 0 && y == Console.WindowHeight - 1) Console.Write('╚');
                    else if (x == Console.WindowWidth - 1 && y == 0) Console.Write('╗');
                    else if (x == Console.WindowWidth - 1 && y == Console.WindowHeight - 1) Console.Write('╝');
                    else if ((x > 0 && x < Console.WindowWidth - 1) && (y == 0 || y == Console.WindowHeight - 1)) Console.Write('═');
                    else if ((x == 0 || x == Console.WindowWidth - 1) && (y > 0 && y < Console.WindowHeight - 1)) Console.Write('║');

                }
            }
        }
        /// <summary>
        /// Renderuje Menu
        /// </summary>
        /// <param name="menu">Tablica zawierająca elementy menu</param>
        /// <param name="font">Kolor czcionki</param>
        /// <param name="background">Kolor tła</param>
        public void RenderMenu(string[] menu, ConsoleColor font, ConsoleColor background)
        {
            for(int i = 0; i < menu.Length; i++)
            {
                Console.SetCursorPosition(2, i);
                if (i == 0) Console.ForegroundColor = ConsoleColor.Cyan;
                else if(i == 1)
                {
                    Console.ForegroundColor = font;
                    Console.BackgroundColor = background;
                }
                Console.Write(menu[i]);
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition((Console.WindowWidth - 9) / 2, 0);
            Console.Write(" Shopify ");
            Console.ResetColor();
        }
        /// <summary>
        /// Czyści całe okno
        /// </summary>
        public void ClearFrame()
        {
            for(int x = 0; x < Console.WindowWidth; x++)
            {
                for(int y = 0; y < Console.WindowHeight; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(' ');
                }
            }
        }
    }
}
