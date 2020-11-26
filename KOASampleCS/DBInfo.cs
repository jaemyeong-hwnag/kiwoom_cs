using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace databaseMySQL
{
    class DBInfo
    {
        private MySqlConnection conn;
        private MySqlCommand command;

        public DBInfo() 
        {
            try {
                conn = new MySqlConnection("");
            } catch (Exception exception) {

            }
        }

        public void Execute(string query) 
        {
            try {
                conn.Open();
                command = new MySqlCommand(query, conn);
                conn.Close();
            } catch (Exception exception) {
                
            }
        }

        public MySqlDataReader GetRowData(string query) 
        {
            conn.Open();
            command = new MySqlCommand(query, conn);
            MySqlDataReader row = command.ExecuteReader();

            return row;
        }
    }
}
