using Shopify.Components.Sorting;
using Shopify.Interfaces;
using Shopify.Enums;
using Shopify.Components.Sorting.ListType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Components
{
    class Sort<T> where T : ISort
    {
        private List<T> _data = new();
        public List<string[]> _rows = new();
        public SortType LastSortType { get; set; } = SortType.Normal;
        public int Page { get; set; } = 0;
        public int MaxPages { get; set; }
        public void AddData(T data)
        {
            _data.Add(data);
        }
        public void ClearData()
        {
            _data = [];
        }
        public void ConvertToStringList(bool specificReturn)
        {
            List<string[]> rows = [];
            foreach(var data in _data)
            {
                rows.Add(data.ConvertToStringArray(specificReturn));
            }
            _rows = rows;
        }
        /// <summary>
        /// Zwraca ilość rzędów w tablicy
        /// </summary>
        /// <returns>Ilość rzędów</returns>
        public int ReturnRowsNum()
        {
            return _rows.Count;
        }
        /// <summary>
        /// Paginacja
        /// </summary>
        /// <returns>Zwraca listę z aktualną stroną</returns>
        public List<string[]> Pagination()
        {
            List<string[]> rows = [];
            int start = Page * 10;
            int end = Math.Min(start + 10, _rows.Count);
            for (int i = start; i < end; i++)
            {
                rows.Add(_rows[i]) ;
            }
            return rows;
        }
        /// <summary>
        /// Wybiera typ sortowania w zależności od poprzedniego typu
        /// </summary>
        /// <param name="x">Aktualna pozycja headera</param>
        public void ToogleSort(int x)
        {
            SortDataType SortDataType = _data[0].GetVarType(x);
            if (LastSortType == SortType.Normal) SortDescending(x, SortDataType);
            else SortAscending(x, SortDataType);
        }
        /// <summary>
        /// Sortuje od największego do najmniejszego lub nie alfabetycznie
        /// </summary>
        /// <param name="x">Aktualna pozycja headera</param>
        /// <param name="SortDataType">Typ danych</param>
        private void SortDescending(int x, SortDataType SortDataType)
        {
            switch(SortDataType)
            {
                case SortDataType.String:
                    _rows = _rows.OrderByDescending(i => i[x]).ToList();
                    break;
                case SortDataType.Int:
                    _rows = _rows.OrderByDescending(i => int.Parse(i[x])).ToList();
                    break;
                case SortDataType.Decimal:
                    _rows = _rows.OrderByDescending(i => decimal.Parse(i[x])).ToList();
                    break;
            }
            LastSortType = SortType.Desc;
        }
        /// <summary>
        /// Sortuje od najmniejszego do największego
        /// </summary>
        /// <param name="x">Aktualna pozycja headera</param>
        /// <param name="SortDataType">Typ danych</param>
        private void SortAscending(int x, SortDataType SortDataType)
        {
            switch (SortDataType)
            {
                case SortDataType.String:
                    _rows = _rows.OrderBy(i => i[x]).ToList();
                    break;
                case SortDataType.Int:
                    _rows = _rows.OrderBy(i => int.Parse(i[x])).ToList();
                    break;
                case SortDataType.Decimal:
                    _rows = _rows.OrderBy(i => decimal.Parse(i[x])).ToList();
                    break;
            }
            LastSortType = SortType.Normal;
        }
    }
}
