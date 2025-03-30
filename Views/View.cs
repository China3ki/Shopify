using Shopify.Components;
using Shopify.Etc;
using Shopify.Views.SingleView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Views
{
    abstract class View(string[] menu)
    {
        public static string Nick { get; set; } = "";
        protected readonly Navigate _nav = new Navigate(menu);
        protected readonly Error _error = new Error(["  ____  _           _ ", " | __ )| | __ _  __| |", " |  _ \\|/// _` |/ _` |", " | |_) //| (_| | (_| |", " |____/|_|\\__,_|\\__,_|", "             (_(      "], "Błąd, nie ma takiego menu!");
        protected readonly Frame _frame = new Frame();
        protected readonly Info _info = new Info();
        protected string[] _menu = menu;
        abstract protected States NextView();
        abstract protected void ReadKey();
    }
}
