using Npgsql;

namespace Messanger.Scripts.ConnectionToDataBase
{
    public class Connect : IDataBase
    {
        string query;
        public Connect(string query) 
        {
            this.query = query;
        }
            
        static string ConnectionString => "Server=localhost;Port=5432;User=postgres;Password=159753;Database=Messanger;";
        NpgsqlConnection connection = new NpgsqlConnection(ConnectionString);


        public void ConnectionOpen() 
        {
            connection.Open();
            
        }
        public void ConnectionClose() 
        {
            connection.Close();
        }

        public NpgsqlDataReader reuslt()
        {
            
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            NpgsqlDataReader npgSqlDataReader = command.ExecuteReader();

            if (npgSqlDataReader.HasRows)
            {
                return npgSqlDataReader;
            }
            else
            {
                return npgSqlDataReader = null;
            }
        }
    }
}