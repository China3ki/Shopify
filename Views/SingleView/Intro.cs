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
    class Intro(string[] header) : Single(header), IView
    { 

        public States InitView()
        {
            _frame.RenderBorder();
            RenderLogo();
            LoadingLogo();
            Thread.Sleep(600);
            return States.Start;
        }
       
        /// <summary>
        /// Wyświetla czas ładowania
        /// </summary>
        private void LoadingLogo()
        {
            int percent = 0;
            for(int i = 0; i < 26; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 13 + i, Console.WindowHeight / 2 + 5);
                Console.Write('█');
                percent = percent == 100 ? 100 : percent += 4;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 13, Console.WindowHeight / 2 + 6);
                Console.Write($"{percent}%");
                Thread.Sleep(70);
            }
        }
    }
}
