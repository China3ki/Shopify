using Shopify.Interfaces;
using Shopify.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Components.Sorting.ListType
{
    class Product(int lp, string name, int amount, decimal price) : ISort
    {
        public int Lp { get; } = lp;
        public string Name { get; } = name;
        public int Amount { get; } = amount;
        public decimal Price { get; } = price;
        public string[] ConvertToStringArray()
        {
            return [Lp.ToString(), Name.ToString(), Amount.ToString(), Price.ToString()];
        }
        public SortDataType GetVarType(int x)
        {
            switch (x)
            {
                case 0:
                    return SortDataType.Int;
                case 1:
                    return SortDataType.String;
                case 2:
                    return SortDataType.Int;
                case 3:
                    return SortDataType.Decimal;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
