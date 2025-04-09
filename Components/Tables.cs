using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Shopify.Components
{
    class Tables
    {
        private List<String[]> _rows = [];
        private int _maxColumns;
        private ConsoleColor _color = ConsoleColor.White;
        public Tables(params string[] headers)
        {
            _rows.Add(headers);
            _maxColumns = headers.Length;
        }
        public Tables(ConsoleColor headersColor, params string[] headers)
        {
            _rows.Add(headers);
            _maxColumns = headers.Length;
            _color = headersColor;
        }
        public void AddRow(params string[] row)
        {
            if (row.Length == _maxColumns) _rows.Add(row);
        }
        public void WriteTable()
        {
            int maxHeight = _rows.Count + _rows.Count + 1;
            int rowNumber = 0;
            List<string> table = [];
            for(int i = 0; i < maxHeight ; i++)
            {
                if (i % 2 == 0 && i == 0) table.Add(PrintLines('╔', '╦', '╗', false));
                else if (i % 2 == 1 && i != 0 && i != maxHeight - 1) 
                {
                    table.Add(PrintLines('║', '║', '║', true, rowNumber));
                    rowNumber++;
                }
                else if (i % 2 == 0 && i != 0 && i != maxHeight - 1) table.Add(PrintLines('╠', '╬', '╣', false));
                else if (i % 2 == 0 && i == maxHeight - 1) table.Add(PrintLines('╚', '╩', '╝', false));
            }
            for(int i = 0; i < table.Count; i++)
            {
                Console.SetCursorPosition(1, 1 + i);
                Console.Write(table[i]);
            }
            PrintData();
            Thread.Sleep(2000);
        }
        private string PrintLines(char left, char mid, char right, bool data, int rowNumber = 0)
        {
            StringBuilder line = new StringBuilder();
            int[] width = CalculateTheLongestField();
            line.Append(left);
            for(int i = 0; i < _maxColumns; i++)
            { 
                if(data)
                {
                    for (int j = 0; j < width[i]; j++) line.Append(' ');
                    if (_maxColumns - 1 != i) line.Append(mid);

                } else
                {
                    for (int j = 0; j < width[i]; j++) line.Append('═');
                    if (_maxColumns - 1 != i) line.Append(mid);
                }
            }
            line.Append(right);
            return line.ToString();
        }
        private void PrintData()
        {
            int[] width = CalculateTheLongestField();
            int maxHeight = _rows.Count + _rows.Count + 1;
            int height = 2;
            for(int x = 0; x < _rows.Count; x++)
            {
                for(int y = 0; y < _rows[0].Length; y ++)
                {
                    if (x == 0) Console.ForegroundColor = _color;
                    Console.SetCursorPosition(2 + width.Take(y).Sum() + y + Padding(width[y], _rows[x][y].Length), height);
                    Console.Write(_rows[x][y]);
                    Console.ResetColor();
                }
                height += 2;
            }
        }
        private int Padding(int width, int wordCount)
        {
            return (width - wordCount) / 2;
        }
        public int[] CalculateTheLongestField()
        {
            int[] width = new int[_maxColumns];
            for(int i = 0; i < _rows.Count; i++)
            {
                for(int j = 0; j < _rows[i].Length; j++)
                {
                    width[j] = width[j] < _rows[i][j].Length ? _rows[i][j].Length : width[j];
                }
            }
            return width;
        }
    }
}
