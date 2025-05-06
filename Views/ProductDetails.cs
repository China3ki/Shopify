using MySql.Data.MySqlClient;
using Shopify.Components;
using Shopify.Components.Sorting.ListType;
using Shopify.Etc;
using Shopify.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Views
{
    class ProductDetails(List<string> menu, string productName) : View(menu), IView
    {
        private readonly string _product = productName;
        private Product _productInfo;
        private int _addedAmount= 1;
        public States InitView()
        {
            _frame.ClearFrame();
            _frame.RenderBorder();
            GetFullProductData();
            _frame.RenderMenu(_menu, 6, ConsoleColor.Green, ConsoleColor.Black);
            _info.InfoMessage("Zapraszamy do zapoznania się z szczegółowymi danymi na temat produktu", ConsoleColor.White, ConsoleColor.Black);
            _info.InfoBox();
            _nav.ChangeSizeOfMenu(6, _menu);
            ReadKey();
            return NextView();
        }
        private void GetFullProductData()
        {
            SqlConnector sql = new();
            sql.InitConn();
            string[] productDetails = [];
            using (MySqlCommand query = new("SELECT product_id, manufacturer_name, product_name, product_desc, product_amount, product_price FROM products INNER JOIN manufacturers ON product_manufacturer_id = manufacturer_id WHERE product_name = @name", sql._conn))
            {
                query.Parameters.AddWithValue("@name", _product);
                MySqlDataReader data = query.ExecuteReader();
                while(data.Read())
                {
                    string id = data.GetInt32("product_id").ToString();
                    string name = data.GetString("product_name");
                    string manufacturer = data.GetString("manufacturer_name");
                    string productDesc = data.GetString("product_desc");
                    string amount = data.GetInt32("product_amount").ToString();
                    string price = data.GetDecimal("product_price").ToString();
                    _menu = [" == Produkt == ", $"Marka: {manufacturer}", $"Nazwa produktu: {name}", $"Opis: {productDesc}", $"Ilość: {amount}", $"Cena: {price}", "Dodaj do koszyka", "Powrót"];
                    _productInfo = new Product(int.Parse(id), name, manufacturer, int.Parse(amount), decimal.Parse(price), productDesc);
                }       
            }
        }
        private void AddToCart()
        {   
            _info.ClearInfoBox();
            _info.InfoMessage($"Pomyślnie dodano produkt do koszyka! [{Cart.AddToCart(_productInfo)}]", ConsoleColor.Green, ConsoleColor.White);
            _info.InfoBox();
            _addedAmount++;
        }
        protected override void ReadKey()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                if ((_nav.Pos == 6 || _nav.Pos == 7) && key == ConsoleKey.DownArrow) _nav.ChangePos(key, ConsoleColor.Red, ConsoleColor.Black);
                else if ((_nav.Pos == 7 || _nav.Pos == 6) && key == ConsoleKey.UpArrow) _nav.ChangePos(key, ConsoleColor.Green, ConsoleColor.Black);
            } while (key != ConsoleKey.Enter);
            if (_nav.Pos == 6)
            {
                AddToCart();
                ReadKey();
            }
        }
        protected override States NextView()
        {
            return States.ProductsList;
        }
    }
}
