using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Components
{
    class Navigate(string[] menu)
    {
        public int pos { get; set; } = 1;
        private int _maxPos = menu.Length;
        private string[] _menu = menu;
        public void ReadKey(ConsoleColor font, ConsoleColor background)
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                ChangePos(key, font, background);
            } while (key != ConsoleKey.Enter);
        }
        private void ChangePos(ConsoleKey key, ConsoleColor font, ConsoleColor background)
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
        private void ChangeColor(int prevPos, ConsoleColor font, ConsoleColor background)
        {
            Console.SetCursorPosition(1, prevPos);
            Console.Write(_menu[prevPos]);
            Console.SetCursorPosition(1, pos);
            Console.ForegroundColor = font;
            Console.BackgroundColor = background;
            Console.Write(_menu[pos]);
            Console.ResetColor();


        }
    }
}
