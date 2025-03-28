﻿using Shopify.Etc;
using Shopify.Views;
using Shopify.Views.SingleView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Components
{
    class Menu
    {
        public States currentMenu { get; set; } = States.Intro;

        /// <summary>
        /// Zmienia aktualne menu na kolejne
        /// </summary>
        public void ChangeMenu()
        {
            switch(currentMenu)
            {
                case States.Intro:
                    Intro intro = new Intro([
            "  ____  _                 _  __       ",
            " / ___|| |__   ___  _ __ (_)/ _|_   _ ",
            " \\___ \\| '_ \\ / _ \\| '_ \\| | |_| | | |",
            "  ___) | | | | (_) | |_) | |  _| |_| |",
            " |____/|_| |_|\\___/| .__/|_|_|  \\__, |",
            "                   |_|          |___/ "
            ]);
                    currentMenu = intro.InitView();
                    break;
                case States.Start:
                    Start start = new Start([" == Start == ", "Zaloguj się", "Zarejestruj się", "Wyjdź"]);
                    currentMenu = start.InitView();
                    break;
                case States.Register:
                    Register register = new Register([" == Rejestracja == ", "Nazwa użytkownika:", "Hasło:", "Powtórzone hasło:", "Pokaż/Schowaj hasła", "Zarejestruj się", "Powrót"]);
                    currentMenu = register.InitView();
                    break;
                case States.CompleteReg:
                    CompleteRegistration completeReg = new CompleteRegistration([
                " __        ___ _                        _ ",
                " \\ \\      / (_) |_ __ _ _ __ ___  _   _| |",
                "  \\ \\ /\\ / /| | __/ _` | '_ ` _ \\| | | | |",
                "   \\ V  V / | | || (_| | | | | | | |_| |_|",
                "    \\_/\\_/  |_|\\__\\__,_|_| |_| |_|\\__, (_)",
                "                                  |___/   "
                ]);
                    currentMenu = completeReg.InitView();
                    break;
                case States.Login:
                    Login login = new Login([" == Login == ", "Nazwa użytkownika:", "Hasło:", "Pokaż/Schowaj hasło", "Zaloguj się", "Powrót"]);
                    currentMenu = login.InitView();
                    break;
                case States.CompleteSig:
                    CompleteSignIn completeSig = new CompleteSignIn([
                        "  _____     _                                            ",
                        " |__  /__ _| | ___   __ _  _____      ____ _ _ __   ___  ",
                        "   / // _` | |/ _ \\ / _` |/ _ \\ \\ /\\ / / _` | '_ \\ / _ \\ ",
                        "  / /| (_| | | (_) | (_| | (_) \\ V  V / (_| | | | | (_) |",
                        " /____\\__,_|_|\\___/ \\__, |\\___/ \\_/\\_/ \\__,_|_| |_|\\___/ ",
                        "                    |___/                                "
                        ]);
                    //completeSig.InitUser(); // do zrobienia
                    break;
            }
        }
    }
}