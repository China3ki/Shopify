using Shopify.Etc;
using Shopify.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Views
{
    class Start(string[] menu) : View(menu), IView
    {
        public States InitView()
        {
            _frame.RenderBorder();
            _frame.RenderMenu(_menu, ConsoleColor.Green, ConsoleColor.Black);
            _info.InfoMessage("Wybierz jedną z opcji aby kontynować.", ConsoleColor.Yellow, ConsoleColor.Black);
            _info.InfoMessage("Witaj w Shopify!", ConsoleColor.White, ConsoleColor.Black);
            _info.InfoBox();
            _nav.ReadKey(ConsoleColor.Green, ConsoleColor.Black);
            return States.Intro;
        }
        protected override States NextView()
        {
            switch(_nav.pos)
            {
                case 1:
                    return States.Login;
                case 2:
                    return States.Register;
                case 3:
                    return States.Exit;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
