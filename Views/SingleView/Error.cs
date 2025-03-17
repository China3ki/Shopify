using Shopify.Components;
using Shopify.Etc;
using Shopify.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Views.SingleView
{
    class Error(string[] header, string message) : Single(header), IView
    {
        private Info _info = new Info();
        public States InitView()
        {
            _frame.ClearFrame();
            _frame.RenderBorder();
            RenderLogo();
            _info.InfoMessage("Naciśnij Enter aby wyjść z aplikacji", ConsoleColor.Yellow, ConsoleColor.Black);
            _info.InfoMessage(message, ConsoleColor.Red, ConsoleColor.Black);
            _info.InfoBox();
            WaitForEnter();
            return States.Exit;
        }
        private void WaitForEnter()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Enter);
            Environment.Exit(0);
        }
    }
}
