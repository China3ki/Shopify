using Shopify.Components.Sorting;
using Shopify.Components.Sorting.ListType;
using Shopify.Interfaces;
using Shopify.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Shopify.Etc;
namespace Shopify.Components.Tables
{

    class TableControl(Table table, TableNavigate tableNav, Sort<ISort> sort)
    {
        private readonly Table _table = table;
        private readonly TableNavigate _tableNav = tableNav;
        public readonly Sort<ISort> _sort = sort;
        /// <summary>
        /// Inicjuje wszyskie elementy do prawidłowego działania tablicy
        /// </summary>
        public void InitTable()
        {
            _table.ClearTable();
            _table.AddRows(_sort._rows);
            SetMaxValues();
            _sort.MaxPages = (_sort.ReturnRowsNum() / 10);
            _table.WriteTable(_tableNav._tableCord[1], _tableNav._tableCord[0]);
        }
        public void ClearTableData()
        {
            _table.ClearTable();
            _sort.Page = 0;
            _sort.ClearData();
        }
        /// <summary>
        /// Sprawdza warunki oraz aktywuję odpowiednią funkcję
        /// </summary>
        public void Control(ConsoleKey key)
        {
            int rowNum = _tableNav._tableCord[0];
            if (key == ConsoleKey.RightArrow || key == ConsoleKey.LeftArrow) HandleSorting(key);
            if ((key == ConsoleKey.UpArrow && rowNum != 1) || (key == ConsoleKey.DownArrow && rowNum != _tableNav.MaxRows - 1)) HandleRowColor(key);
            if ((key == ConsoleKey.UpArrow && rowNum == 1 && _sort.Page != 0) || (key == ConsoleKey.DownArrow && rowNum == _tableNav.MaxRows - 1 && _sort.Page != _sort.MaxPages)) HandlePagination(key);
        }
        public string GetProductName()
        {
            int x = _tableNav._tableCord[0] - 1;
            return _sort._rows[x][2];
        }
        public int getProductId()
        {
            int x = _tableNav._tableCord[0] - 1;
            return int.Parse(_sort._rows[x][0]);
        }
        /// <summary>
        /// Zmienia metodę sortowania
        /// </summary>
        /// <param name="key">Wciśnięty przycisk</param>
        private void HandleSorting(ConsoleKey key)
        {
            int headerNum = _tableNav._tableCord[1];
            if (key == ConsoleKey.LeftArrow && _sort.LastSortType == SortType.Normal && headerNum == 0) return;
            if (key == ConsoleKey.RightArrow && _sort.LastSortType == SortType.Desc && headerNum == _tableNav.MaxColumns - 1) return;
            if ((key == ConsoleKey.LeftArrow && _sort.LastSortType == SortType.Normal && headerNum != 0) || (key == ConsoleKey.RightArrow && _sort.LastSortType == SortType.Desc && headerNum != _tableNav.MaxColumns - 1)) _tableNav.ChangePos(key);
            _sort.ToogleSort(_tableNav._tableCord[1]);
            _tableNav.DefaultRowNum();
            _sort.Page = 0;
            InitTable();
        }
        /// <summary>
        /// Zmienia kolor pierwszej kulumny
        /// </summary>
        /// <param name="key">Wciśnięty przycisk</param>
        private void HandleRowColor(ConsoleKey key)
        {
            int rowNum = _tableNav._tableCord[0];
            int colNum = _tableNav._tableCord[1];
            int oldHeight = _tableNav.Height;
            _tableNav.ChangePos(key);
            _tableNav.ChangeFirstColumnColor(_table.CenterTheWord(_tableNav._tableCord[0], _tableNav._tableCord[1]), _table.CenterTheWord(rowNum, colNum) ,oldHeight, _table._rows[rowNum][0], _table._rows[_tableNav._tableCord[0]][0]);
        }
        /// <summary>
        /// Paginacja tabeli
        /// </summary>
        /// <param name="key">Wciśnięty przycisk</param>
        private void HandlePagination(ConsoleKey key)
        {
            _table.ClearTable();
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    _sort.Page--;
                    _table.AddRows(_sort.Pagination());
                    SetMaxValues();
                    _tableNav.SetLastRowNum();
                    break;
                case ConsoleKey.DownArrow:
                    _sort.Page++;
                    _table.AddRows(_sort.Pagination());
                    SetMaxValues();
                    _tableNav.DefaultRowNum();
                    break;
            }
            _table.WriteTable(_tableNav._tableCord[1], _tableNav._tableCord[0]);
        }     
        private void SetMaxValues()
        {
            _tableNav.MaxColumns = _table.MaxColumns;
            _tableNav.MaxRows = _table._rows.Count;
        }
    }
}
