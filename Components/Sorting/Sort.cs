using Shopify.Components.Sorting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Components
{
    enum SortType { Normal, Desc }
    abstract class Sort
    {
        public SortType LastSortType { get; set; } = SortType.Normal;
        public void SortList(int x)
        {
            if (LastSortType == SortType.Normal) SortByDesc(x);
            else SortByOrder(x);
        }
        abstract public void AddToList(int lp, string name, int amount, decimal price);
        abstract public List<string[]> ConvertToStringList();
        abstract protected void SortByDesc(int x);
        abstract protected void SortByOrder(int x);
    }
}
