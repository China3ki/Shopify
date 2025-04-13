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
        public int[] _tableCord = [1, 0];
        public int MaxRows { get; set; }
        public int MaxColumns { get; set; }
        public int Height { get; set; } = 4;
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
                    _tableCord[0] = _tableCord[0] == 1 ? 1 : _tableCord[0] -= 1;
                    Height = Height == 4 ? 4 : Height -= 2;
                    break;
                case ConsoleKey.DownArrow:
                    _tableCord[0] = _tableCord[0] == MaxRows ? MaxRows - 1: _tableCord[0] += 1;
                    Height = Height == 1 + 2 * MaxRows - 1 ? 1 + 2 * MaxRows - 1 : Height += 2;
                    break;
            }
        }
        public void DefaultRowNum()
        {
            _tableCord[0] = 1;
            Height = 4;
        }
        public void SetLastRowNum()
        {
            Height = 1 + 2 * MaxRows - 1;
            _tableCord[0] = MaxRows - 1;
        }
        public void ChangeFirstColumnColor(int maxWidth, int prevHeight, string oldFieldName, string fieldName)
        {
            Console.SetCursorPosition(maxWidth, prevHeight);
            Console.Write(oldFieldName);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(maxWidth, Height);
            Console.Write(fieldName);
            Console.ResetColor();

        }
    }
}
