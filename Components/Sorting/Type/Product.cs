using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Components.Sorting.Type
{
    class Product(int lp, string name, int amount, decimal price)
    {
        public int Lp { get; } = lp;
        public string Name { get; } = name;
        public int Amount { get; } = amount;
        public decimal Price { get; } = price;
    }
}
