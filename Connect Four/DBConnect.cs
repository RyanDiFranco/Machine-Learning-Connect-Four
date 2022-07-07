using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace New_Connect_Four
{
    public class DBConnect
    {
        private MySqlConnection connection; // Declaring class variables for DBConnect, which allows us to communicate to database
        private string server;
        private string database;
        private string uid;
        private string password;

        //This is the constructor that is ran when a DBConnect object is created
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "connectfour";
            uid = "root";
            password = "password";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }
        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void RunQuery(string query)
        {
            // In MySQL, to autoincrement ID, query must have NULL for input, and run this to modify the table
            // ALTER TABLE `expense_data`
            // CHANGE COLUMN `id` `id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT;

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public List<string> SelectQuery(string query)
        {
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                MySqlDataReader reader = cmd.ExecuteReader();
                List<String> list = new List<String>();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }

                this.CloseConnection();

                return list;

            }
            return null;
        }

        ////Select statement
        //public List<string>[] Select()
        //{
        //}

        ////Count statement
        //public int Count()
        //{
        //}

        ////Backup
        //public void Backup()
        //{
        //}

        ////Restore
        //public void Restore()
        //{
        //}

    }
}

