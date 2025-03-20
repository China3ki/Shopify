using MySql.Data.MySqlClient;
using Shopify.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Online
{
    class Registration
    {
        public string Nickname { get; set; } = "";
        public string Pswd { get; set; } = "";
        public string RepeatedPswd { get; set; } = "";
        /// <summary>
        /// Dodaje wprowadzone dane do bazy danych
        /// </summary>
        public void InsertData()
        {
            SqlConnector conn = new SqlConnector();
            conn.InitConn();
            MySqlCommand query = new MySqlCommand("INSERT INTO users(user_type_id, user_nickname, user_password) VALUES(@type, @nick, @pswd)", conn._conn);
            query.Parameters.AddWithValue("@type", 1);
            query.Parameters.AddWithValue("@nick", Nickname);
            query.Parameters.AddWithValue("@pswd", HashPassword());
            query.ExecuteNonQuery();
        }
        private string HashPassword()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Haszowanie hasła przy użyciu PBKDF2
            using (var pbkdf2 = new Rfc2898DeriveBytes(Pswd, salt, 100000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32);

                // Łączymy sól i hash w jeden ciąg znaków
                byte[] hashBytes = new byte[salt.Length + hash.Length];
                Array.Copy(salt, 0, hashBytes, 0, salt.Length);
                Array.Copy(hash, 0, hashBytes, salt.Length, hash.Length);

                // Konwersja do Base64 i zwrócenie jako string
                return Convert.ToBase64String(hashBytes);

            }
        }
    }
}
