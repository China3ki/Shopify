using Shopify.Components.Sorting.ListType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Components
{
    static class Cart
    {
        public static List<Product> _cartList { get; set; } = [];
        public static int AddToCart(Product newProduct)
        {
            bool exist = false;
            foreach (Product product in _cartList)
            {
                if (product.Name == newProduct.Name)
                {
                    product.AddedToCart++;
                    exist = true;
                    return product.AddedToCart;
                }
            }
            if(!exist) _cartList.Add(newProduct);
            return 1;
        }
        public static void RemoveFromCart(int productId)
        {
            _cartList = _cartList.Select(product =>
            {
                if (product.Lp == productId)
                {
                    product.AddedToCart--;
                }
                return product;
            }).Where(product => product.AddedToCart > 0).ToList();
        }
    }
}
