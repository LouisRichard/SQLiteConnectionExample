using System;
//For this test, you'll need to install the package "System.Data.SQLite".
//To do that, go to -> Tools -> NuGet Package Manager -> Manage NuGet Package for Solution...
//Go to the browse and type in the search bar "SQLite".
using System.Data.SQLite;

namespace SQliteConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) //Infinite loop
            {
                #region asking for the user's info
                Console.WriteLine("Enter your username : ");
                string username = Console.ReadLine();

                Console.WriteLine("\nEnter your password : ");
                string password = Console.ReadLine();
                #endregion

                #region Create the database
                string createQuery = @"CREATE TABLE IF NOT EXISTS 
                                [Users]([Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                [Name] VARCHAR(255) NOT NULL,
                                [Password] VARCHAR(255) NOT NULL)";
                ExecuteQuery.Create(createQuery);
                #endregion

                #region Insert the user's info in the database
                string queryInsert = "INSERT INTO Users(Name, Password) values (\'" + username + "\', \'" + password + "\')";
                ExecuteQuery.Insert(queryInsert); //Define the next query to execute as a hard coded string value
                #endregion

                #region Select everything from the database
                string querySelect = "SELECT * from Users";
                SQLiteDataReader queryResult = ExecuteQuery.Select(querySelect);
                #endregion

                #region Go though every result from the select query
                while (queryResult.Read())
                {
                    Console.WriteLine(queryResult["Name"] + ":" + queryResult["Password"]);
                }
                #endregion

                Console.ReadLine();
            }
        }
    }
}
