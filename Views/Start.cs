using Shopify.Etc;
using Shopify.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Views
{
    class Start(List<string> menu) : View(menu), IView
    {
        public States InitView()
        {
            _frame.ClearFrame();
            _frame.RenderBorder();
            _frame.RenderMenu(_menu, ConsoleColor.Green, ConsoleColor.Black);
            _info.InfoMessage("Wybierz jedną z opcji aby kontynować.", ConsoleColor.Yellow, ConsoleColor.Black);
            _info.InfoMessage("Witaj w Shopify!", ConsoleColor.White, ConsoleColor.Black);
            _info.InfoBox();
            ReadKey();
            _frame.ClearFrame();
            return NextView();
        }
        protected override void ReadKey()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                _nav.ChangePos(key, ConsoleColor.Green, ConsoleColor.Black);
            } while (key != ConsoleKey.Enter);
        }
        protected override States NextView()
        {
            switch(_nav.Pos)
            {
                case 1:
                    return States.Login;
                case 2:
                    return States.Register;
                case 3:
                    return States.Exit;
                default:
                    _error.InitView();
                    return States.Exit;
            }
        }
    }
}
