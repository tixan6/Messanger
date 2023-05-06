using Npgsql;

namespace Messanger.Scripts.ConnectionToDataBase
{
    public interface IDataBase
    {    
         static string ConnectionString { get; }

        void ConnectionOpen();
        void ConnectionClose();

        NpgsqlDataReader reuslt();
    }
}
