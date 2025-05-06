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
    class Product(int lp, string name, string manufacturer, int amount, decimal price, string desc = "") : ISort
    {
        public int Lp { get; } = lp;
        public string Name { get; } = name;
        public string Desc { get; } = desc;
        public string Manufacturer { get; } = manufacturer;
        public int Amount { get; } = amount;
        public decimal Price { get; } = price;
        public int AddedToCart { get; set; } = 1;
        public string[] ConvertToStringArray(bool specificReturn)
        {
            if(specificReturn) return [Lp.ToString(), Manufacturer.ToString(), Name.ToString(), AddedToCart.ToString(), Price.ToString()];
            else return [Lp.ToString(), Manufacturer.ToString(), Name.ToString(), Amount.ToString(), Price.ToString()];
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
                    return SortDataType.String;
                case 3:
                    return SortDataType.Int;
                case 4:
                    return SortDataType.Decimal;
                case 5:
                    return SortDataType.Int;
                case 6:
                    return SortDataType.String;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
