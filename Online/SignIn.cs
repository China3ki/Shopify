using MySql.Data.MySqlClient;
using Shopify.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Online
{
    class SignIn
    {
        public string Nickname { get; set; } = "";
        public string Pswd { get; set; } = "";
        /// <summary>
        /// Sprawdza czy istnieje konto z wpisanym pseudonimem
        /// </summary>
        /// <returns>Zwraca czy istnieje</returns>
        public bool CheckTheNickname()
        {
            SqlConnector sql = new SqlConnector();
            using (MySqlCommand query = new MySqlCommand("SELECT COUNT(*) FROM users WHERE user_nickname = @nickname", sql._conn))
            {
                sql.InitConn();
                query.Parameters.AddWithValue("@nickname", Nickname);
                int count = Convert.ToInt32(query.ExecuteScalar());
                if (count == 0) return false;
                else return true;
            }
        }
        /// <summary>
        /// Sprawdza czy wprowadzone hasło zgadza się z hasłem z bazy danych
        /// </summary>
        /// <returns>Zwraca czy się zgadza</returns>
        public bool CheckThePassword()
        {
            SqlConnector sql = new SqlConnector();
            using (MySqlCommand query = new MySqlCommand("SELECT user_password FROM users WHERE user_nickname = @nickname", sql._conn))
            {
                sql.InitConn();
                query.Parameters.AddWithValue("@nickname", Nickname);
                MySqlDataReader reader = query.ExecuteReader();
                reader.Read();
                return VerifyPassword(reader.GetString(0));
            }        
        }
        /// <summary>
        /// Weryfikuje poprawność hasła
        /// </summary>
        /// <param name="storedPswd">Hasło z bazy danych</param>
        /// <returns></returns>
        private bool VerifyPassword(string storedPswd)
        {
            byte[] hashBytes = Convert.FromBase64String(storedPswd);
            byte[] salt = [244, 2, 87, 13, 44, 84, 21, 210, 65, 1, 62, 14, 36, 149, 203, 11];
            Array.Copy(hashBytes, 0, salt, 0, salt.Length);

            using (var pbkdf2 = new Rfc2898DeriveBytes(Pswd, salt, 100000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32);

                // Porównanie hashy
                for (int i = 0; i < hash.Length; i++)
                {
                    if (hashBytes[salt.Length + i] != hash[i])
                        return false;
                }
            }
            return true;
        }
    }
}
