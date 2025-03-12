using Shopify.Components;
using Shopify.Etc;
using Shopify.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Views.SingleView
{
    class Error(string[] header) : Single(header), IView
    {
        public States InitView()
        {
            throw new NotImplementedException();
        }
    }
}
