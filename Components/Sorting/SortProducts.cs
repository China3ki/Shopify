using Shopify.Components.Sorting.Type;
using Shopify.Etc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Components.Sorting
{
    
    class SortProducts : Sort
    {

        private List<Product> _products = [];     
        public override void AddToList(int lp, string name, int amount, decimal price)
        {
            _products.Add(new Product(lp, name, amount, price));
        }
        public override List<string[]> ConvertToStringList()
        {
            List<string[]> rows = [];
            foreach (var row in _products)
            {
                rows.Add([row.Lp.ToString(), row.Name.ToString(), row.Amount.ToString(), row.Price.ToString()]);
            }
            return rows;
        }
        
        protected override void SortByDesc(int x)
        {
            switch (x)
            {
                case 0:
                    _products = _products.OrderByDescending(i => i.Lp).ToList();
                    break;
                case 1:
                    _products = _products.OrderByDescending(i => i.Name).ToList();
                    break;
                case 2:
                    _products = _products.OrderByDescending(i => i.Amount).ToList();
                    break;
                case 3:
                    _products = _products.OrderByDescending(i => i.Price).ToList();
                    break;
            }
            LastSortType = SortType.Desc;
        }
        protected override void SortByOrder(int x)
        {
            switch (x)
            {
                case 0:
                     _products =  _products.OrderBy(i => i.Lp).ToList();
                    break;
                case 1:
                    _products =  _products.OrderBy(i => i.Name).ToList();
                    break;
                case 2:
                    _products = _products.OrderBy(i => i.Amount).ToList();
                    break;
                case 3:
                    _products = _products.OrderBy(i => i.Price).ToList();
                    break;
            }
            Debug.WriteLine(":a");
            LastSortType = SortType.Normal;
        }
    }
}
