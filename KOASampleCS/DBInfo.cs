using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using DBCommon;

namespace databaseMySQL
{
    class DBInfo
    {
        DBConnSet connSet = new DBConnSet();
        public void Execute(string query) 
        {
            try {
                MySqlConnection conn = this.Connection();
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                Debug.WriteLine(query);
                command.ExecuteNonQuery();
                Debug.WriteLine(query);
                conn.Close();
            } catch (Exception exception) {
                // Debug.WriteLine(exception);
            }
        }

        public string GetRowData(string query) 
        {
            MySqlConnection conn = this.Connection();
            conn.Open();
            //Debug.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader rdr = command.ExecuteReader();

            string temp = string.Empty;

            if (rdr == null) temp = "No return";
            else
            {
                while (rdr.Read())
                {
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        if (i != rdr.FieldCount - 1)
                            temp += rdr[i] + ";";    // parser 넣어주기
                        else if (i == rdr.FieldCount - 1)
                            temp += rdr[i] + "\n";
                    }
                }
            }
            //Debug.WriteLine(temp);

            rdr.Close();
            conn.Close();
            return temp;
        }
        
        public int RowCount(string query) 
        {
            MySqlConnection conn = this.Connection();
            conn.Open();
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader row = command.ExecuteReader();

            row.Read();
            int myCount = Convert.ToInt32(row["cnt"].ToString());
            row.Close();
            conn.Close();
            /*Debug.WriteLine(myCount);
            Debug.WriteLine(query);*/
            return myCount;
        }

        private MySqlConnection Connection() 
        {
            return new MySqlConnection(connSet.getConnectionStr());
    }
    }
}
