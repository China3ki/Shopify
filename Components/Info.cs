using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Components
{
    class Info
    {
        private int _countInfo = 0;
        /// <summary>
        /// Wyświetla wiadomośc
        /// </summary>
        /// <param name="message">Wiadomość</param>
        /// <param name="font">Kolor czcionki</param>
        /// <param name="background">Kolor tła</param>
        public void InfoMessage(string message, ConsoleColor font, ConsoleColor background)
        {
            Console.SetCursorPosition(2, Console.WindowHeight - 2 - _countInfo);
            Console.ForegroundColor = font;
            Console.BackgroundColor = background;
            Console.Write(message);
            Console.ResetColor();
            _countInfo++;
        }
        /// <summary>
        /// Renderuje ramke wokół wiadomości
        /// </summary>
        public void InfoBox()
        {
            for(int x = 0; x < Console.WindowWidth; x++)
            {
                Console.SetCursorPosition(x, Console.WindowHeight - 2 - _countInfo);
                if (x == 0) Console.Write('╠');
                else if (x == Console.WindowWidth - 1) Console.Write('╣');
                else Console.Write('═');
            }
        }
        /// <summary>
        /// Czyści messageBox
        /// </summary>
        public void ClearInfoBox()
        {
            for(int x = 0; x < Console.WindowWidth; x++)
            {
                for(int y = 0; y < _countInfo - 2; y++)
                {
                    Console.SetCursorPosition(x, Console.WindowHeight - 2 - y);
                    if (x == 0 || x == Console.WindowWidth - 1) Console.Write('║');
                    else Console.Write('═');
                }
            }
            _countInfo = 0;
        }
    }
}
