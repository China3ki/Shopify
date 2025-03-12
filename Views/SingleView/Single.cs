using Shopify.Components;
using Shopify.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Views.SingleView
{
    class Single(string[] header) 
    {
        protected Frame _frame = new Frame();
        protected string[] _header = header;
        /// <summary>
        /// Wyświetla logo aplikacji
        /// </summary>
        protected void RenderLogo()
        {
            for (int y = 0; y < _header.Length; y++)
            {
                Console.SetCursorPosition((Console.WindowWidth - _header[y].Length) / 2, Console.WindowHeight / 2 + y - 3);
                Console.Write(_header[y]);
            }
        }
    }
}
