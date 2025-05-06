using MySql.Data.MySqlClient;
using Shopify.Components;
using Shopify.Etc;
using Shopify.Interfaces;
using Shopify.Views.SingleView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Views
{
    class Categories(List<string> menu) : View(menu), IView
    {
        static public string SelectedCategory { get; set; } = ""; // Wybrana kategoria przez użytkownika
        public States InitView()
        {
            _frame.ClearFrame();
            _frame.RenderBorder();
            AddCategoriesToMenu();
            _frame.RenderMenu(_menu, 1, ConsoleColor.Black, ConsoleColor.White);
            _info.InfoMessage("Wybierz jedną z kategorii.", ConsoleColor.Yellow, ConsoleColor.Black);
            _info.InfoBox();
            ReadKey();
            SelectedCategory = _menu[_nav.Pos];
            return NextView();
        }
        /// <summary>
        /// Wyszukuje wszystkie dostępne kategorie w bazie danych i wyświetla je w menu
        /// </summary>
        private void AddCategoriesToMenu()
        {
            SqlConnector sql = new SqlConnector();
            sql.InitConn();
            using (MySqlCommand query = new MySqlCommand("SELECT category_name FROM products_category", sql._conn))
            {
                MySqlDataReader data = query.ExecuteReader();
                while(data.Read())
                {
                    _menu.Add(data.GetString("category_name"));
                }
                _menu.Add("Menu główne");
                _nav.ChangeSizeOfMenu(1, _menu);
            }
            sql.CloseConn();
        }
        protected override void ReadKey()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                if ((_nav.Pos == _menu.Count - 2 || _nav.Pos == _menu.Count - 1) && key == ConsoleKey.DownArrow) _nav.ChangePos(key, ConsoleColor.Red, ConsoleColor.Black);
                else _nav.ChangePos(key, ConsoleColor.Black, ConsoleColor.White);
            } while (key != ConsoleKey.Enter);
        }
        protected override States NextView()
        {
            if (_nav.Pos > 0 && _nav.Pos < _menu.Count - 1) return States.ProductsList;
            else if (_nav.Pos == _nav.MaxPos) return States.Main;
            else
            {
                _error.InitView();
                return States.Exit;
            }
        }
    }
}
