using MySql.Data.MySqlClient;
using Shopify.Components;
using Shopify.Components.Sorting.ListType;
using Shopify.Components.Tables;
using Shopify.Etc;
using Shopify.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Shopify.Views
{
    class ProductsList(List<string> menu, string category) : View(menu), IView
    {
        static public string ProductInfo { get; set; } = "";
        private readonly TableControl _tableControl = new(new Table(ConsoleColor.Yellow, " Lp ", "Producent", "Nazwa produktu", "Dostępna ilość", "Cena (PLN)"), new TableNavigate(), new Sort<ISort>());
        private readonly string _category = category;
        private ConsoleKey _key;

        public States InitView()
        {
            _frame.ClearFrame();
            _frame.RenderBorder();
            _frame.RenderMenu(_menu, 1, ConsoleColor.Black, ConsoleColor.White);
            _info.InfoMessage("Kliknij Escape aby wrócić do wyboru kategorii!", ConsoleColor.White, ConsoleColor.Black);
            _info.InfoMessage("Strzała góra lub w dół aby wyświetlić więcej", ConsoleColor.Yellow, ConsoleColor.Black);
            _info.InfoMessage("Strzałka w prawo lub w lewo aby zmienić opcje sortowania.", ConsoleColor.Yellow, ConsoleColor.Black);
            _info.InfoBox();
            GetData();
            ReadKey();
            return NextView();
        }
        private void GetData()
        {
            SqlConnector sql = new();
            sql.InitConn();
            using (MySqlCommand query = new("SELECT ROW_NUMBER() OVER (ORDER BY product_id) AS product_num, product_id, manufacturer_name, product_name, product_price, product_amount FROM products INNER JOIN products_category ON product_category_id = category_id INNER JOIN manufacturers ON product_manufacturer_id = manufacturers.manufacturer_id WHERE category_name = @category", sql._conn))
            {
                query.Parameters.AddWithValue("@category", _category);
                MySqlDataReader data = query.ExecuteReader();
                while(data.Read())
                {
                    int lp = data.GetInt32("product_num");
                    string name = data.GetString("product_name");
                    string manufacturer = data.GetString("manufacturer_name");
                    int amount = data.GetInt32("product_amount");
                    decimal price = data.GetDecimal("product_price");

                    _tableControl._sort.AddData(new Product(lp, name, manufacturer, amount, price));
                }
                _tableControl._sort.ConvertToStringList(false);
            }
            sql.CloseConn();
        }
        protected override void ReadKey()
        {
            _tableControl.InitTable();
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                _tableControl.Control(key);
            } while (key != ConsoleKey.Enter && key != ConsoleKey.Escape);
            _key = key;
        }
        protected override States NextView()
        {
            if (_key == ConsoleKey.Enter)
            {
                ProductInfo = _tableControl.GetProductName();
                return States.ProductDetails;
            } else
            {
                return States.Categories;
            }
        }
    }
}
