using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace databaseMySQL
{
    class DBInfo
    {
        private MySqlConnection conn;

        public DBInfo() 
        {
            try {
                this.conn = new MySqlConnection("");
                this.conn.Open();
            } catch (Exception exception) {
                Debug.WriteLine(exception);
            }
        }

        public void Execute(string query) 
        {
            try {
                MySqlCommand command = new MySqlCommand(query, this.conn);
                command.ExecuteNonQuery();
            } catch (Exception exception) {
                Debug.WriteLine(exception);
            }
        }

        public MySqlDataReader GetRowData(string query) 
        {
            MySqlCommand command = new MySqlCommand(query, this.conn);
            MySqlDataReader row = command.ExecuteReader();

            return row;
        }

        ~DBInfo() 
        {
            this.conn.Close();
        }
    }
}
