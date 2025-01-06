using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassMan
{

    public class DatabaseHelper
    {
        private static string dbPath = "PasswordManager.db";
        private static string connectionString = $"Data Source={dbPath};Version=3;";

        public static void InitializeDatabase()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"
                    CREATE TABLE Passwords (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Username TEXT,
                        EncryptedPassword TEXT NOT NULL,
                        Website TEXT,
                        Notes TEXT,
                        CreatedDate DATETIME NOT NULL,
                        ModifiedDate DATETIME NOT NULL
                    )";

                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        // Método para insertar una nueva contraseña
        public static void InsertPassword(Password password)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = @"
                INSERT INTO Passwords (Title, Username, EncryptedPassword, Website, Notes, CreatedDate, ModifiedDate)
                VALUES (@Title, @Username, @EncryptedPassword, @Website, @Notes, @CreatedDate, @ModifiedDate)";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Title", password.Title);
                    command.Parameters.AddWithValue("@Username", password.Username);
                    command.Parameters.AddWithValue("@EncryptedPassword", password.EncryptedPassword);
                    command.Parameters.AddWithValue("@Website", password.Website);
                    command.Parameters.AddWithValue("@Notes", password.Notes);
                    command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }
        }
    }

}
