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
    class CompleteSignIn(string[] header) : Single(header), IView
    {
        private Info _info = new Info();
        public States InitView()
        {
            _frame.ClearFrame();
            _frame.RenderBorder();
            RenderLogo();
            _info.InfoMessage("Kliknij Enter aby kontunować.", ConsoleColor.Yellow, ConsoleColor.Black);
            _info.InfoMessage($"Witaj ", ConsoleColor.White, ConsoleColor.Black);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{View.Nick}!");
            Console.ResetColor();
            _info.InfoBox();
            WaitForEnter();
            return States.Main;
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
