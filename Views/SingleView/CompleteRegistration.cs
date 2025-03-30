using Shopify.Components;
using Shopify.Etc;
using Shopify.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Views.SingleView
{
    class CompleteRegistration(string[] header) : Single(header), IView
    {
        Info _info = new Info();
        public States InitView()
        {
            _frame.ClearFrame();
            _frame.RenderBorder();
            RenderLogo();
            _info.InfoMessage("Kliknij Enter aby kontynuować.", ConsoleColor.White, ConsoleColor.Black);
            _info.InfoMessage("Udało ci się zarejestrować!", ConsoleColor.Green, ConsoleColor.Black);
            _info.InfoBox();
            WaitForEnter();
            return States.Start;
        }
        private void WaitForEnter()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Enter);
        }
    }
}
