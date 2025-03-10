using Shopify.Components;
using Shopify.Etc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify
{
    class Shopify
    {
        private Menu _menu = new Menu();
        private bool _run = false;

        public Shopify()
        {
            _run = true;
            RunApp();
        }
        /// <summary>
        /// Metoda służąca działania aplikacji
        /// </summary>
        private void RunApp()
        {
            do
            {
                _menu.ChangeMenu();
                _run = _menu.currentMenu != States.Exit ? true : false;
            } while (_run);
        }
    }
}
