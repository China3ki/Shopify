using MySql.Data.MySqlClient;
using Shopify.Components;
using Shopify.Etc;
using Shopify.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Views
{
    class ProductsList(List<string> menu, string category) : View(menu), IView
    {
        private string _category = category;
        public States InitView()
        {
            _frame.ClearFrame();
            _frame.RenderBorder();
            _frame.RenderMenu(_menu, ConsoleColor.Black, ConsoleColor.White);
            GetData();
            Console.ReadKey(true);
            return States.Start;
        }
        private void GetData()
        {
            SqlConnector sql = new SqlConnector();
            sql.InitConn();
            using (MySqlCommand query = new MySqlCommand("SELECT product_name, product_price, product_amount FROM products INNER JOIN products_category ON product_category_id = category_id WHERE category_name = @category ", sql._conn))
            {
                query.Parameters.AddWithValue("@category", _category);
                MySqlDataReader data = query.ExecuteReader();
                while(data.Read())
                {

                }
            }
            sql.CloseConn();
        }
        protected override void ReadKey()
        {

        }
        protected override States NextView()
        {
            return States.Start;
        }
    }
}
