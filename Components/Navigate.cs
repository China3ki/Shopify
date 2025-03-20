using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Components
{
    class Navigate(string[] menu)
    {
        public int pos { get; set; } = 1;
        private int _maxPos = menu.Length - 1;
        private string[] _menu = menu;
        
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
                    pos = pos == 1 ? 1 : pos -= 1;
                    ChangeColor(pos + 1, font, background);
                    break;
                case ConsoleKey.DownArrow:
                    pos = pos == _maxPos ? _maxPos : pos += 1;
                    ChangeColor(pos - 1, font, background);
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
            Console.SetCursorPosition(2, pos);
            Console.ForegroundColor = font;
            Console.BackgroundColor = background;
            Console.Write(_menu[pos]);
            Console.ResetColor();
        }
    }
}
