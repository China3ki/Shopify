using Shopify.Etc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Interfaces
{
    interface IView
    {
        /// <summary>
        /// Służy do inicjacji widoku
        /// </summary>
        /// <returns>Następny widok</returns>
        public States InitView();
    }
}
