using Microsoft.AspNetCore.Mvc.Infrastructure;
using MySql.Data.MySqlClient;

namespace MDK._01._01_PR_38.Data.Common
{
    public class Connection
    {
        readonly static string ConnectionData = "server=127.0.0.1;port=3307;database=Shop;uid=root;pwd=";

        public static MySqlConnection MySqlOpen()
        {
            MySqlConnection NewMySqlConnection = new MySqlConnection(ConnectionData);
            NewMySqlConnection.Open();

            return NewMySqlConnection;
        }

        public static MySqlDataReader MySqlQuery(string Query, MySqlConnection Connection)
        {
            MySqlCommand NewMySqlCommand = new MySqlCommand(Query, Connection);
            return NewMySqlCommand.ExecuteReader();
        }

        public static void MySqlClose(MySqlConnection connection) => connection.Close();
    }
}
