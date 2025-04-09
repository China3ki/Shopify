using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Components
{
    class Navigate(List<String> menu)
    {
        public int Pos { get; set; } = 1;
        public int MaxPos = menu.Count - 1;
        private List<String> _menu = menu;
        
        /// <summary>
        /// Zmienia pozycję
        /// </summary>
        /// <param name="key">Kliknięty przycisk</param>
        /// <param name="font">Kolor czcionki</param>
        /// <param name="background">Kolor tła</param>
        public void ChangePos(ConsoleKey key, ConsoleColor font, ConsoleColor background)
        {
            switch(key)
            {
                case ConsoleKey.UpArrow:
                    Pos = Pos == 1 ? 1 : Pos -= 1;
                    ChangeColor(Pos + 1, font, background);
                    break;
                case ConsoleKey.DownArrow:
                    Pos = Pos == MaxPos ? MaxPos : Pos += 1;
                    ChangeColor(Pos - 1, font, background);
                    break;
            }
        }
        /// <summary>
        /// Zmienia kolor wcześnie i aktualnej wybranej pozycji
        /// </summary>
        /// <param name="prevPos">Poprzednia pozycja</param>
        /// <param name="font">Kolor czcionki</param>
        /// <param name="background">Kolor tła</param>
        private void ChangeColor(int prevPos, ConsoleColor font, ConsoleColor background)
        {
            Console.SetCursorPosition(2, prevPos);
            Console.Write(_menu[prevPos]);
            Console.SetCursorPosition(2, Pos);
            Console.ForegroundColor = font;
            Console.BackgroundColor = background;
            Console.Write(_menu[Pos]);
            Console.ResetColor();
        }
    }
}
