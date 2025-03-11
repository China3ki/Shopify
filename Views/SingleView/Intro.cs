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
    class Intro : IView
    {
        private Frame _frame = new Frame();
        private string[] _logo = [
            "  ____  _                 _  __       ",
            " / ___|| |__   ___  _ __ (_)/ _|_   _ ",
            " \\___ \\| '_ \\ / _ \\| '_ \\| | |_| | | |",
            "  ___) | | | | (_) | |_) | |  _| |_| |",
            " |____/|_| |_|\\___/| .__/|_|_|  \\__, |",
            "                   |_|          |___/ "
            ];
        /// <summary>
        /// Wyświetla logo aplikacji
        /// </summary>
        public States InitView()
        {
            _frame.RenderBorder();
            RenderLogo();
            LoadingLogo();
            Thread.Sleep(600);
            _frame.ClearFrame();
            return States.Start;
        }
        private void RenderLogo()
        {
            for(int y = 0; y < _logo.Length; y++)
            {
                Console.SetCursorPosition((Console.WindowWidth - _logo[y].Length) / 2, Console.WindowHeight / 2 + y - 3);
                Console.Write(_logo[y]);
            }
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
