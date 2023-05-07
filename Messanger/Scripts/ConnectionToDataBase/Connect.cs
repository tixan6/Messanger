using Npgsql;

namespace Messanger.Scripts.ConnectionToDataBase
{
    public class Connect : IDataBase
    {
        string query;
        NpgsqlConnection connection;
        public Connect(string query) 
        {
            this.query = query;
        }
        private static string Host = "localhost";
        private static string User = "postgres";
        private static string DBname = "Messanger";
        private static string Password = "159753";
        private static string Port = "5432";

        string connString =
               String.Format(
                   "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                   Host,
                   User,
                   DBname,
                   Port,
                   Password);



        public void ConnectionOpen() 
        {
            connection = new NpgsqlConnection(connString);
            connection.Open();
            
        }
        public void ConnectionClose() 
        {
            connection.Close();
        }

        public object reuslt()
        {
            
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            NpgsqlDataReader npgSqlDataReader = command.ExecuteReader();

            if (npgSqlDataReader.HasRows)
            {
                return npgSqlDataReader;
            }
            else
            {
                return new Exception("Нет данных");
            }
        }
    }
}