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
        public bool _hidePswd = true;
        public string InitForm(int pos, int lenOfOption, string oldData, bool isPswd)
        {
            PasteOldData(pos, lenOfOption, oldData, isPswd);            
            return Write(pos, lenOfOption, oldData, isPswd);
        }
        /// <summary>
        /// Pokazuje hasła w inputach
        /// </summary>
        /// <param name="pswd">Hasło</param>
        /// <param name="repeatedPswd">Powtórzone hasło</param>
        public void ShowPswd(string pswd, string repeatedPswd)
        {
            Console.SetCursorPosition(8, 2);
            Console.Write(pswd);
            Console.SetCursorPosition(19, 3);
            Console.Write(repeatedPswd);
            _hidePswd = false;
        }
        /// <summary>
        /// Ukrywa hasła w inputach
        /// </summary>
        /// <param name="lenOfPswd">Długość hasła</param>
        /// <param name="lenOfReaptedPswd">Długość powtórzonego hasłą</param>
        public void HidePswd(int lenOfPswd, int lenOfReaptedPswd)
        {
            for(int i = 0; i < lenOfPswd; i++)
            {
                Console.SetCursorPosition(8 + i, 2);
                Console.Write('*');
            }
            for(int i = 0; i < lenOfReaptedPswd; i++)
            {
                Console.SetCursorPosition(19 + i, 3);
                Console.Write('*');
            }
            _hidePswd = true;
        }
        /// <summary>
        /// Obsługa pisania w danym formularzu
        /// </summary>
        /// <param name="pos">Aktualna pozycja</param>
        /// <param name="lenOfOption">Długość Label'u</param>
        /// <param name="oldData">Poprzednio wpisane dane</param>
        /// /// <param name="isPswd">Czy wprowadzane dane są hasłami</param>
        private string Write(int pos, int lenOfOption, string oldData, bool isPswd)
        {
            StringBuilder data = new StringBuilder();
            Regex pattern = new Regex(@"[A-Za-z0-9 !""#$%&'()*+,\-./:;<=>?@[\\\]^_`{|}~]");
            ConsoleKeyInfo key;

            data.Append(oldData);
        
            do
            {               
                key = Console.ReadKey(true);

                if (pattern.IsMatch(key.KeyChar.ToString()) && data.Length != 30)
                {
                    Console.SetCursorPosition(2 + lenOfOption + data.Length, pos);
                    if (_hidePswd && isPswd) Console.Write('*');
                    else Console.Write(key.KeyChar);
                    data.Append(key.KeyChar);
                }
                else if(key.KeyChar == '' && data.Length != 0)
                {
                    Console.SetCursorPosition(2 + lenOfOption + data.Length - 1, pos);
                    Console.Write(' ');
                    data.Length--;
                }
            } while (key.Key != ConsoleKey.Enter);
            return data.ToString();
        }
        /// <summary>
        /// Wpisuje poprzednio wprowadzone dane
        /// </summary>
        /// <param name="pos">Aktualna pozycja</param>
        /// <param name="lenOfOption">Długość label'u</param>
        /// <param name="oldData">Poprzednio wprowadzone dane</param>
        /// <param name="isPswd">Czy wprowadzane dane są hasłami</param>
        private void PasteOldData(int pos, int lenOfOption, string oldData, bool isPswd)
        {
            if (_hidePswd && isPswd)
            {
                for(int i = 0; i < oldData.Length; i++)
                {
                    Console.SetCursorPosition(2 + lenOfOption + i, pos);
                    Console.Write('*');
                }
            } else
            {
                Console.SetCursorPosition(2 + lenOfOption, pos);
                Console.Write(oldData);
            }
               
           
        }
    }
}
