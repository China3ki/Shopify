using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopify.Etc;
using Shopify.Interfaces;
namespace Shopify.Views
{
    class Main(List<string> menu) : View(menu), IView
    {
        public States InitView()
        {
            _frame.ClearFrame();
            _frame.RenderBorder();
            _frame.RenderMenu(_menu, 1, ConsoleColor.Green, ConsoleColor.Black);
            _info.InfoMessage("Zapraszamy do obejrzenia oraz zakupu naszych produktów!", ConsoleColor.Yellow, ConsoleColor.Black);
            _info.InfoMessage("Witaj ", ConsoleColor.White, ConsoleColor.Black);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{View.Nick}!");
            Console.ResetColor();
            _info.InfoBox();
            ReadKey();
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
                    return States.Categories;
                case 2:
                    return States.Cart;
                default:
                    _error.InitView();
                    return States.Exit;
            }
        }
    }
}
