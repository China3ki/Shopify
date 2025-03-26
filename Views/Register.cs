using Shopify.Components;
using Shopify.Etc;
using Shopify.Interfaces;
using Shopify.Online;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Views
{
    class Register(string[] menu) : View(menu), IView
    {
        private readonly Registration _registration = new Registration();
        private readonly Validation _validation = new Validation();
        private readonly Form _form = new Form();
        public States InitView()
        {
            _frame.RenderBorder();
            _frame.RenderMenu(_menu, ConsoleColor.Black, ConsoleColor.White);
            _info.InfoMessage("- Hasło musi mieć przynajmniej 8 znaków, jedną duża literę oraz jeden znak specjalny", ConsoleColor.Yellow, ConsoleColor.Black);
            _info.InfoMessage("- Nazwa użytkownia musi być unikalna i może mieć maksymalnie 30 znaków", ConsoleColor.Yellow, ConsoleColor.Black);
            _info.InfoMessage("Wymagania do rejestracji:", ConsoleColor.White, ConsoleColor.Black);
            _info.InfoBox();
            ReadKey();
            _frame.ClearFrame();
            return NextView();
        }
        /// <summary>
        /// Odczytuję wciśnięty przycisk
        /// </summary>
        /// <param name="font">Kolor czcionki</param>
        /// <param name="background">Kolor tła</param>
        protected override void ReadKey()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                if ((_nav.pos == 3 && key == ConsoleKey.DownArrow) || (_nav.pos == 5 && key == ConsoleKey.UpArrow)) _nav.ChangePos(key, ConsoleColor.DarkYellow, ConsoleColor.Black);
                else if ((_nav.pos == 4 && key == ConsoleKey.DownArrow) || (_nav.pos == 6 && key == ConsoleKey.UpArrow)) _nav.ChangePos(key, ConsoleColor.Green, ConsoleColor.Black);
                else if ((_nav.pos == 5 || _nav.pos == 6) && key == ConsoleKey.DownArrow) _nav.ChangePos(key, ConsoleColor.Red, ConsoleColor.Black);
                else _nav.ChangePos(key, ConsoleColor.Black, ConsoleColor.White);
            } while (key != ConsoleKey.Enter);

            if (_nav.pos >= 1 && _nav.pos <= 5) SelectTheInput();
        }
        /// <summary>
        /// Wybiera odpowiedni input
        /// </summary>
        private void SelectTheInput()
        {
            switch(_nav.pos)
            {
                case 1:
                    _registration.Nickname = _form.InitForm(_nav.pos, _menu[_nav.pos].Length, _registration.Nickname, false);
                    ReadKey();
                    break;
                case 2:
                    _registration.Pswd = _form.InitForm(_nav.pos, _menu[_nav.pos].Length, _registration.Pswd, true);
                    ReadKey();
                    break;
                case 3:
                   _registration.RepeatedPswd = _form.InitForm(_nav.pos, _menu[_nav.pos].Length, _registration.RepeatedPswd, true);
                    ReadKey();
                    break;
                case 4:
                    if (_form._hidePswd) _form.ShowPswd(_registration.Pswd, _registration.RepeatedPswd);
                    else _form.HidePswd(_registration.Pswd.Length, _registration.RepeatedPswd.Length);
                        ReadKey();
                    break;
                case 5:
                    if(!_validation.InitValidation(_registration.Nickname, _registration.Pswd, _registration.RepeatedPswd))
                    {
                        _info.ClearInfoBox();
                        foreach(string message in _validation.messages)
                        {
                            _info.InfoMessage(message, ConsoleColor.Red, ConsoleColor.Black);
                        }
                        _validation.messages.Clear();
                        _info.InfoBox();
                        ReadKey();
                    } else
                    {
                        _registration.InsertData();
                    }
                        break;
            }
        }
        protected override States NextView()
        {
            switch(_nav.pos)
            {
                case 5:
                    return States.CompleteReg;
                case 6:
                    return States.Start;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
