using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Components
{
    class Navigate(List<string> menu)
    {
        public int Pos { get; set; } = 1;
        private int _minPos = 1;
        public int MaxPos { get; set; } = menu.Count - 1;
        private List<string> _menu = menu;
        public void ChangeSizeOfMenu(int minPos, List<string> menu)
        {
            Pos = minPos;
            _minPos = minPos;
            MaxPos = menu.Count - 1;
            _menu = menu;
        }
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
                    Pos = Pos == _minPos ? _minPos : Pos -= 1;
                    ChangeColor(Pos + 1, font, background);
                    break;
                case ConsoleKey.DownArrow:
                    Pos = Pos == MaxPos ? MaxPos : Pos += 1;
                    ChangeColor(Pos - 1,  font, background);
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
