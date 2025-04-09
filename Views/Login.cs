using Shopify.Components;
using Shopify.Etc;
using Shopify.Interfaces;
using Shopify.Online;
using Shopify.Views.SingleView;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Views
{
    class Login(List<string> menu) : View(menu), IView
    {
        private readonly Form _form = new Form();
        private readonly SignIn _login = new SignIn();
        public States InitView()
        {
            _frame.ClearFrame();
            _frame.RenderBorder();
            _frame.RenderMenu(_menu, ConsoleColor.Black, ConsoleColor.White);
            _info.InfoMessage("Uzupełnij dane aby się zalogować.", ConsoleColor.Yellow, ConsoleColor.Black);
            _info.InfoBox();
            ReadKey();
            return NextView();

        }
        protected override void ReadKey()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                if ((_nav.Pos == 2 && key == ConsoleKey.DownArrow) || (_nav.Pos == 4 && key == ConsoleKey.UpArrow)) _nav.ChangePos(key, ConsoleColor.DarkYellow, ConsoleColor.Black);
                else if ((_nav.Pos == 3 && key == ConsoleKey.DownArrow) || (_nav.Pos == 5 && key == ConsoleKey.UpArrow)) _nav.ChangePos(key, ConsoleColor.Green, ConsoleColor.Black);
                else if ((_nav.Pos == 4 || _nav.Pos == 5) && key == ConsoleKey.DownArrow) _nav.ChangePos(key, ConsoleColor.Red, ConsoleColor.Black);
                else _nav.ChangePos(key, ConsoleColor.Black, ConsoleColor.White);
            } while (key != ConsoleKey.Enter);
            if (_nav.Pos >= 1 && _nav.Pos <= 4) SelectTheInput();
        }
        private void SelectTheInput()
        {
            switch(_nav.Pos)
            {
                case 1:
                    _login.Nickname = _form.InitForm(_nav.Pos, _menu[_nav.Pos].Length, _login.Nickname, false);
                    ReadKey();
                    break;
                case 2:
                    _login.Pswd = _form.InitForm(_nav.Pos, _menu[_nav.Pos].Length, _login.Pswd, true);
                    ReadKey();
                    break;
                case 3:
                    if (_form._hidePswd) _form.ShowPswd(_login.Pswd);
                    else _form.HidePswd(_login.Pswd.Length);
                    ReadKey();
                    break;
                case 4:
                            if (!_login.CheckTheNickname())
                            {
                                _info.ClearInfoBox();
                                _info.InfoMessage("Użytkownik z taką nazwą użytkownika nie istnieje!", ConsoleColor.Red, ConsoleColor.Black);
                                _info.InfoBox();
                                ReadKey();
                            } else
                            {
                                if (!_login.CheckThePassword())
                                {
                                    _info.ClearInfoBox();
                                    _info.InfoMessage("Podane dane są nieprawidłowe!", ConsoleColor.Red, ConsoleColor.Black);
                                    _info.InfoBox();
                                    ReadKey();
                                } else
                                {
                                    Nick = _login.Nickname;
                                }
                            }
                            break;
                        }
        }
        protected override States NextView()
        {
            switch(_nav.Pos)
            {
                case 4:
                    return States.CompleteSig;
                case 5:
                    return States.Start;
                default:
                    _error.InitView();
                    return States.Exit;
            }
        }
    }
}
