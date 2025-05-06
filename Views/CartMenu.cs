using Shopify.Components.Tables;
using Shopify.Components;
using Shopify.Etc;
using Shopify.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopify.Components.Sorting.ListType;
using System.Diagnostics;

namespace Shopify.Views
{
    class CartMenu(List<string> menu) : View(menu), IView
    {
        private TableControl _control = new(new Table(" Id Produktu ", "Producent", "Nazwa produktu", "Ilość", "Cena produktu"), new TableNavigate(), new Sort<ISort>());
        private ConsoleKey _key;
        private bool _elementExists;
        public States InitView()
        {
            _frame.ClearFrame();
            _frame.RenderBorder();
            _frame.RenderMenu(_menu, 0, ConsoleColor.Green, ConsoleColor.Black);
            AddToTheTable();
            ReadKey();
            return NextView();
        }
        private void AddToTheTable()
        {
            List<Product> products = Cart._cartList;
            if (products.Count == 0)
            {
                _info.InfoMessage("Kliknij Escape aby wrócić do menu głównego.", ConsoleColor.Yellow, ConsoleColor.Black);
                _info.InfoMessage("Twoja lista zakupów jest pusta!", ConsoleColor.Red, ConsoleColor.Black);
                _info.InfoBox();
                _elementExists = false;
            }
            else
            {
                decimal price = 0;
                foreach (Product product in products)
                {
                    _control._sort.AddData(product);
                    price += product.Price * product.AddedToCart;
                }
                _control._sort.ConvertToStringList(true);
                _info.InfoMessage("Kliknij Escape aby wrócić do menu głównego.", ConsoleColor.White, ConsoleColor.Black);
                _info.InfoMessage("Kliknij DEL aby usunąć towar.", ConsoleColor.White, ConsoleColor.Black);
                _info.InfoMessage("Kliknij enter aby przejść do szczegółów zamówienia.", ConsoleColor.White, ConsoleColor.Black);
                _info.InfoMessage($"Cena za wszystkie towary wynosi: {price}zł", ConsoleColor.Yellow, ConsoleColor.Black);
                _info.InfoBox();
                _elementExists = true;
            }
        }
        protected override void ReadKey()
        {
            ConsoleKey key;
            if (_elementExists)
            {
                _control.InitTable();
                do
                {
                    key = Console.ReadKey(true).Key;
                    _control.Control(key);
                } while (key != ConsoleKey.Enter && key != ConsoleKey.Escape && key != ConsoleKey.Delete);
                if (key == ConsoleKey.Delete)
                {
                    Cart.RemoveFromCart(_control.getProductId());
                    _control.ClearTableData();
                    _info.ClearInfoBox();
                    AddToTheTable();
                    ReadKey();
                }
                else _key = key;
            } else
            {
                do
                {
                    key = Console.ReadKey(true).Key;
                } while (key != ConsoleKey.Escape);
                _key = key;
            }
        }
        protected override States NextView()
        {
            if (_key == ConsoleKey.Enter) return States.Main;
            else return States.Main;
        }
    }
}
