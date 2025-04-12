using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Components.Tables
{
    class TableNavigate()
    {
        public int[] _tableCord = [0, 0];
        public int MaxRows { get; set; }
        public int MaxColumns { get; set; }
        public void ChangePos(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    _tableCord[1] = _tableCord[1] == MaxColumns - 1 ? MaxColumns - 1 : _tableCord[1] += 1;
                    break;
                case ConsoleKey.LeftArrow:
                    _tableCord[1] = _tableCord[1] == 0 ? 0 : _tableCord[1] -= 1;
                    break;
                case ConsoleKey.UpArrow:
                    _tableCord[0] = _tableCord[0] == 0 ? 0 : _tableCord[1] -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    _tableCord[0] = _tableCord[0] == MaxRows ? MaxRows : _tableCord[0] += 1;
                    break;
            }
        }
    }
}
