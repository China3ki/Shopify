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
        protected readonly Navigate _nav = new Navigate(menu);
        protected readonly Frame _frame = new Frame();
        protected readonly Info _info = new Info();
        protected string[] _menu = menu;
        abstract protected States NextView();
        abstract protected void ReadKey();
    }
}
