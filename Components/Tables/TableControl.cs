using Shopify.Components.Sorting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shopify.Components.Tables
{
    
    class TableControl(Table table, TableNavigate tableNav, Sort sort)
    {
        private readonly Table _table = table;
        private readonly TableNavigate _tableNav = tableNav;
        private readonly Sort _sort = sort;
        
        /// <summary>
        /// Inicjuje wszyskie elementy do prawidłowego działania tablicy
        /// </summary>
        public void InitTable()
        {
            _table.ClearTable();
            _table.AddRows(_sort.ConvertToStringList());
            _tableNav.MaxColumns = _table.MaxColumns;
            _tableNav.MaxRows = _table._rows.Count;
            _table.WriteTable(_tableNav._tableCord[1]);
        }
        /// <summary>
        /// Dodaje elementy do listy
        /// </summary>
        /// <param name="lp">Lp</param>
        /// <param name="name">Nazwa</param>
        /// <param name="amount">Ilość</param>
        /// <param name="price">Cena</param>
        public void AddToList(int lp, string name, int amount, decimal price)
        {
            _sort.AddToList(lp, name, amount, price);
        }
        public void Control()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                ChangeSort(key);
            } while (key != ConsoleKey.Enter);
        }
        /// <summary>
        /// Sprawdza warunki, wywołuje funkcje do zmiany sortowania i zmiany kordynatów
        /// </summary>
        /// <param name="key"></param>
        private void ChangeSort(ConsoleKey key)
        {
            if(key == ConsoleKey.RightArrow && _sort.LastSortType == SortType.Normal)
            {
                _sort.SortList(_tableNav._tableCord[1]);
                InitTable();
            } else if(key == ConsoleKey.RightArrow && _sort.LastSortType == SortType.Desc && _tableNav._tableCord[1] != _tableNav.MaxColumns - 1)
            {
                _tableNav.ChangePos(key);
                _sort.SortList(_tableNav._tableCord[1]);
                InitTable();
            } else if(key == ConsoleKey.LeftArrow && _sort.LastSortType == SortType.Normal && _tableNav._tableCord[1] != 0)
            {
                _tableNav.ChangePos(key);
                _sort.SortList(_tableNav._tableCord[1]);
                InitTable();
            } else if(key == ConsoleKey.LeftArrow && _sort.LastSortType == SortType.Desc)
            {
                _sort.SortList(_tableNav._tableCord[1]);
                InitTable();
            }
        }
    }
}
