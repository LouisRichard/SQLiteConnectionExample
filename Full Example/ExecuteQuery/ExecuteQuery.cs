using System.IO;
//For this test, you'll need to install the package "System.Data.SQLite".
//To do that, go to -> Tools -> NuGet Package Manager -> Manage NuGet Package for Solution...
//Go to the browse and type in the search bar "SQLite".
using System.Data.SQLite;


namespace SQliteConnection
{
    public class ExecuteQuery
    {
        /// <summary>
        /// Execute a Select query
        /// </summary>
        /// <param name="query">Select query to execute</param>
        /// <returns>Query result as an SQLiteDataReader</returns>
        public static SQLiteDataReader Select(string query)
        {
            SQLiteCommand command = ConnectToDatabase(false); //open db connection

            command.CommandText = query;
            System.Data.SQLite.SQLiteDataReader reader = command.ExecuteReader();
            _ = ConnectToDatabase(true); //close db connection  Using Ignore(_) as we don't care what it returns.
            return reader;
        }

        /// <summary>
        /// Execute a Create query
        /// </summary>
        /// <param name="query">Create query to execute</param>
        public static void Create(string query)
        {
            SQLiteCommand command = ConnectToDatabase(false); //open db connection
            command.CommandText = query;
            command.ExecuteNonQuery(); //Execute the query

            _ = ConnectToDatabase(true); //close db connection   Using Ignore(_) as we don't care what it returns.
        }

        /// <summary>
        /// Execute a Insert query
        /// </summary>
        /// <param name="query">Insert query to execute</param>
        public static void Insert(string query)
        {
            SQLiteCommand command = ConnectToDatabase(false); //open db connection
            command.CommandText = query;
            command.ExecuteNonQuery(); //Execute the query

            _ = ConnectToDatabase(true); //close db connection   Using Ignore(_) as we don't care what it returns.
        }


        /// <summary>
        /// Connect to the SQLite database
        /// </summary>
        /// <param name="close">If true : Close database connection. If false : Open database connection</param>
        /// <returns>SQLiteCommand cmd if database is getting opened.</returns>
        /// <returns>Null if database is getting closed</returns>
        private static SQLiteCommand ConnectToDatabase(bool close)
        {
            if (!File.Exists("GLdb.db3"))
            {
                System.Data.SQLite.SQLiteConnection.CreateFile(
                    Path.Combine(
                        Directory.GetCurrentDirectory(),"GLdb.db3")); //Create the database
            }

            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("data source=GLdb.db3");
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(conn);

            if (!close)
            {
                conn.Open(); //Open connection to the SQLite database
                return cmd;
            }
            else
            {
                cmd = null;
                conn.Close();
                return cmd;
            }
        }
    }
}
