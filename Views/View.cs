using Shopify.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Views
{
    abstract class View(string[] menu)
    {
        protected Navigate _nav = new Navigate(menu);
        protected string[] _menu = menu;
    }
}
