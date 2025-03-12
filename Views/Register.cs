using Shopify.Components;
using Shopify.Etc;
using Shopify.Interfaces;
using Shopify.Online;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Views
{
    class Register(string[] menu) : View(menu), IView
    {
        private Registration _registration = new Registration();
        private Form _form = new Form();
        public States InitView()
        {
            _frame.RenderBorder();
            _frame.RenderMenu(_menu, ConsoleColor.Black, ConsoleColor.White);
            ReadKey();
            throw new NotImplementedException();
        }
        /// <summary>
        /// Odczytuję wciśnięty przycisk
        /// </summary>
        /// <param name="font">Kolor czcionki</param>
        /// <param name="background">Kolor tła</param>
        private void ReadKey()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                if ((_nav.pos == 3 && key == ConsoleKey.DownArrow) || (_nav.pos == 5 && key == ConsoleKey.UpArrow)) _nav.ChangePos(key, ConsoleColor.Green, ConsoleColor.Black);
                else if((_nav.pos == 4 || _nav.pos == 5) && key == ConsoleKey.DownArrow) _nav.ChangePos(key, ConsoleColor.Red, ConsoleColor.Black);
                else _nav.ChangePos(key, ConsoleColor.Black, ConsoleColor.White);
            } while (key != ConsoleKey.Enter);
            _form.InitForm(_nav.pos, _menu[_nav.pos].Length, _registration.Nickname);
        }
        protected override States NextView()
        {
            throw new NotImplementedException();
        }
    }
}
