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
        public bool InitValidation(string nickname, string pswd, string repeatedPswd)
        {
            CheckTheNickname(nickname);
            CheckThePassword(pswd, repeatedPswd);
            Debug.Write(messages.Count);
            if (messages.Count == 0) return true;
            else return false;

        }
        private void CheckTheNickname(string nickname)
        {
            SqlConnector conn = new SqlConnector();
            using (MySqlCommand query = new MySqlCommand(@"SELECT user_nickname FROM users WHERE user_nickname = @nickname", conn._conn))
            {
                conn.InitConn();
                query.Parameters.AddWithValue("@nickname", nickname);
                int count = Convert.ToInt32(query.ExecuteScalar());
                if (count > 1) messages.Add("Podana nazwa użytkownika już istnieje!");
                if (nickname.Length == 0) messages.Add("Nazwa użytkownika nie może być pusta!");
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
