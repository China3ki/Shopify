using Shopify.Components;
using Shopify.Components.Sorting.ListType;
using Shopify.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Interfaces
{
    interface ISort
    {
        string[] ConvertToStringArray();
        SortDataType GetVarType(int x);
    }
}
