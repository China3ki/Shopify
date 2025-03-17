using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Shopify.Views.SingleView;
namespace Shopify.Components
{
    class SqlConnector
    {
        public MySqlConnection _conn = new MySqlConnection("server=localhost;user=root;database=shopify; port=3306;password=;");
        /// <summary>
        /// Inicjuje połączenie z bazą danych
        /// </summary>
        public void InitConn()
        {
            try
            {
                _conn.Open();
             
            } catch
            {

                Error error = new Error(["  ____  _           _ ", " | __ )| | __ _  __| |", " |  _ \\|/// _` |/ _` |", " | |_) //| (_| | (_| |", " |____/|_|\\__,_|\\__,_|", "             (_(      "], "Nie udało połączyć się z naszymi serwerami, spróbuj ponownie póżniej!");
                error.InitView();
            } 
        }
        public void CloseConn()
        {
            _conn.Close();
        }
    }
}
