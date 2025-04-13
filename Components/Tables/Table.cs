using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
namespace Shopify.Components.Tables
{
    class Table
    {
        public int MaxColumns { get; }
        public List<string[]> _rows = [];
        private readonly string[] _headers = [];
        private readonly ConsoleColor _color = ConsoleColor.White;
        public Table(params string[] headers)
        {
            _headers = headers;
            MaxColumns = headers.Length;
        }
        public Table(ConsoleColor headersColor, params string[] headers)
        {
            _headers = headers;
            MaxColumns = headers.Length;
            _color = headersColor;
        }
        /// <summary>
        /// Dodaje rząd
        /// </summary>
        /// <param name="row">Dane które mają znaleść się w rzędzie</param>
        public void AddRows(List<string[]> rows)
        {
            _rows.Add(_headers);
            for(int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Length == MaxColumns) _rows.Add(rows[i]);
                if (i == 9) break;
            }
        }
        /// <summary>
        /// Czyści tabele
        /// </summary>
        public void ClearTable()
        {
            for (int x = 1; x < Console.WindowWidth - 2; x++)
            {
                for(int y = 1; y < _rows.Count * 2 + 2; y++ )
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(' ');
                }
            }
            _rows.Clear();
        }
        /// <summary>
        /// Rysuje całkowicie tablice
        /// </summary>
        public void WriteTable(int headerToColor, int rowToColorX)
        {
            int maxHeight = _rows.Count + _rows.Count + 1;
            List<string> table = [];
            for(int i = 0; i < maxHeight ; i++)
            {

                if (i % 2 == 0 && i == 0) table.Add(PrintLines('╔', '╦', '╗', false));
                else if (i % 2 == 1 && i != 0 && i != maxHeight - 1) 
                {
                    table.Add(PrintLines('║', '║', '║', true));
                }
                else if (i % 2 == 0 && i != 0 && i != maxHeight - 1) table.Add(PrintLines('╠', '╬', '╣', false));
                else if (i % 2 == 0 && i == maxHeight - 1) table.Add(PrintLines('╚', '╩', '╝', false));
            }
            for(int i = 0; i < table.Count; i++)
            {
                Console.SetCursorPosition(1, 1 + i);
                Console.Write(table[i]);
            }
            PrintData(headerToColor, rowToColorX);
        }
        /// <summary>
        /// Rysuje obramowanie do tablicy
        /// </summary>
        /// <param name="left">Lewy znak</param>
        /// <param name="mid">Środkowy znak</param>
        /// <param name="right">Prawy znak</param>
        /// <param name="data">Czy dany rząd zawiera rząd</param>
        /// <param name="rowNumber">Numer rzędu</param>
        /// <returns></returns>
        private string PrintLines(char left, char mid, char right, bool data)
        {
            StringBuilder line = new();
            int[] width = CalculateTheLongestField();
            line.Append(left);
            for(int i = 0; i < MaxColumns; i++)
            { 
                if(data)
                {
                    for (int j = 0; j < width[i]; j++) line.Append(' ');
                    if (MaxColumns - 1 != i) line.Append(mid);

                } else
                {
                    for (int j = 0; j < width[i]; j++) line.Append('═');
                    if (MaxColumns - 1 != i) line.Append(mid);
                }
            }
            line.Append(right);
            return line.ToString();
        }
        /// <summary>
        /// Wypisuje dane w tablicy
        /// </summary>
        private void PrintData(int headerToColor, int rowToColorX)
        {
            int height = 2;
            for(int x = 0; x < _rows.Count; x++)
            {
                for(int y = 0; y < _rows[0].Length; y ++)
                {
                    if (x == 0) Console.ForegroundColor = _color;
                    if (x == 0 && y == headerToColor)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (x == rowToColorX && y == 0) Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(CenterTheWord(x, y), height);
                    Console.Write(_rows[x][y]);
                    Console.ResetColor();
                }
                height += 2;
            }
        }
        /// <summary>
        /// Oblicza paddingi
        /// </summary>
        /// <param name="width">Szerokość danego pola</param>
        /// <param name="wordCount">Ilość liter w polu</param>
        /// <returns></returns>
        private int Padding(int width, int wordCount)
        {
            return (width - wordCount) / 2;
        }
        /// <summary>
        /// Centruję napis w kolumnie
        /// </summary>
        /// <param name="posX">Miejsce pola w rzędzie</param>
        /// <param name="posY">Miejsce pola w kolumnie</param>
        /// <returns></returns>
        public int CenterTheWord(int posX, int posY)
        {
            int[] width = CalculateTheLongestField();
            return 2 + width.Take(posY).Sum() + posY + Padding(width[posY], _rows[posX][posY].Length);
        }
        /// <summary>
        /// Wylicza długości najszerszych pól
        /// </summary>
        /// <returns>Długości najszerszych pól</returns>
        public int[] CalculateTheLongestField()
        {
            int[] width = new int[MaxColumns];
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
