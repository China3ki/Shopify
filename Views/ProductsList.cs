using MySql.Data.MySqlClient;
using Shopify.Components;
using Shopify.Components.Sorting;
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
        private readonly TableControl _control = new(new Table(ConsoleColor.Yellow, " Lp ", "Nazwa produktu", "Dostępna ilość", "Cena (PLN)"), new TableNavigate(), new SortProducts());
        private readonly string _category = category;
        public States InitView()
        {
            _frame.ClearFrame();
            _frame.RenderBorder();
            _frame.RenderMenu(_menu, ConsoleColor.Black, ConsoleColor.White);
            _info.InfoMessage("Strzała góra lub w dół aby wyświetlić więcej", ConsoleColor.Yellow, ConsoleColor.Black);
            _info.InfoMessage("Strzałka w prawo lub w lewo aby zmienić opcje sortowania.", ConsoleColor.Yellow, ConsoleColor.Black);
            _info.InfoBox();
            GetData();
            ReadKey();
            return States.Start;
        }
        private void GetData()
        {
            SqlConnector sql = new();
            sql.InitConn();
            using (MySqlCommand query = new("SELECT ROW_NUMBER() OVER (ORDER BY product_id) AS product_num, product_name, product_price, product_amount FROM products INNER JOIN products_category ON product_category_id = category_id WHERE category_name = @category", sql._conn))
            {
                query.Parameters.AddWithValue("@category", _category);
                MySqlDataReader data = query.ExecuteReader();
                while(data.Read())
                {
                    int lp = data.GetInt32("product_num");
                    string name = data.GetString("product_name");
                    int amount = data.GetInt32("product_amount");
                    decimal price = data.GetDecimal("product_price");
                    _control.AddToList(lp, name, amount, price);
                }
            }
            sql.CloseConn();
        }
        protected override void ReadKey()
        {
            _control.InitTable();
            _control.Control();
        }
        protected override States NextView()
        {
            return States.Start;
        }
    }
}
