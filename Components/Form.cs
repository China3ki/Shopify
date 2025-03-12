using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shopify.Components
{
    class Form
    {
        public string InitForm(int pos, int lenOfOption, string oldData)
        {
            PasteOldData(pos, lenOfOption, oldData);
            Write(pos, lenOfOption, oldData);
            return "asf";
        }
        private void Write(int pos, int lenOfOption, string oldData)
        {
            StringBuilder data = new StringBuilder();
            Regex pattern = new Regex(@"[A-Za-z0-9 !""#$%&'()*+,\-./:;<=>?@[\\\]^_`{|}~]");
            ConsoleKeyInfo key;
            data.Append(oldData);

            Console.SetCursorPosition(4 + lenOfOption + oldData.Length, pos);
            do
            {
                key = Console.ReadKey(true);
                //if (pattern.IsMatch(key.KeyChar.ToString())) Debug.Write(true);
                Debug.Write(key.KeyChar.ToString());
                
               

            } while (key.Key != ConsoleKey.Enter);

        }
        private void PasteOldData(int pos, int lenOfOption, string oldData)
        {
            Console.SetCursorPosition(4 + lenOfOption, pos);
            Console.Write(oldData);
           
        }
    }
}
