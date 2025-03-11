using Shopify.Components;
using Shopify.Etc;
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
        protected Frame _frame = new Frame();
        protected Info _info = new Info();
        protected string[] _menu = menu;
        abstract protected States NextView();
    }
}
