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
    class CompleteSignIn(string[] header) : Single(header)
    {
        private Info _info = new Info();
        public States InitUser(string nickname)
        {
            _frame.ClearFrame();
            _frame.RenderBorder();
            _info.InfoMessage("Kliknij Enter aby kontunować.", ConsoleColor.Yellow, ConsoleColor.Black);
            _info.InfoMessage($"Witaj {nickname}!", ConsoleColor.White, ConsoleColor.Black);
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
