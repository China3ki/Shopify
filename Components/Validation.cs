using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shopify.Components
{
    class Validation
    {
        public List<string> messages = new List<string>();
        /// <summary>
        /// Inicjuje walidacje
        /// </summary>
        /// <param name="nickname">Nazwa użytkownika</param>
        /// <param name="pswd">Hasło</param>
        /// <param name="repeatedPswd">Powtórzone hasło</param>
        /// <returns></returns>
        public bool InitValidation(string nickname, string pswd, string repeatedPswd)
        {
            CheckTheNickname(nickname);
            CheckThePassword(pswd, repeatedPswd);
            if (messages.Count == 0) return true;
            else return false;

        }
        /// <summary>
        /// Sprawdza czy konto istnieje i czy input nie jest pusty
        /// </summary>
        /// <param name="nickname">Nazwa użytkownika</param>
        private void CheckTheNickname(string nickname)
        {
            SqlConnector conn = new SqlConnector();
            using (MySqlCommand query = new MySqlCommand(@"SELECT COUNT(*) FROM users WHERE user_nickname = @nickname", conn._conn))
            {
                if (nickname.Length == 0) messages.Add("Nazwa użytkownika nie może być pusta!");
                else 
                { 
                conn.InitConn();
                query.Parameters.AddWithValue("@nickname", nickname);
                int count = Convert.ToInt32(query.ExecuteScalar());
                if (count >= 1) messages.Add("Podana nazwa użytkownika już istnieje!");
                }
                
            }
        }
        private void CheckThePassword(string pswd, string repeatedPswd)
        {
            Regex pattern = new Regex("(?=.*[A-Z])(?=.*)");
            if (pswd.Length < 8) messages.Add("Hasło musi mieć przynajmniej 8 znaków!");
            if (pswd != repeatedPswd) messages.Add("Hasła muszą być takie same!");
            if (!pattern.IsMatch(pswd)) messages.Add("Hasło musi zawierać przynajmniej jedną literę oraz jedną liczbę!");
        }
    }
}
