using AdminPanel.Models;
using Npgsql;using Messanger.Scripts.ConnectionToDataBase;
namespace AdminPanel.Scripts
{
    public static class Update
    {
        public static void upd() 
        {
            List<List<object>> list = new List<List<object>>();
            List<object> mas;
            Connect Connect = new Connect($"SELECT * FROM \"ModerationPost\" ORDER BY id DESC");
            Connect.ConnectionOpen();
            object all = Connect.reuslt();

            try
            {
                NpgsqlDataReader itemsReader = (NpgsqlDataReader)all;

                while (itemsReader.Read())
                {
                    mas = new List<object>();
                    for (int i = 0; i < 7; i++)
                    {
                        mas.Add(itemsReader.GetValue(i));
                    }
                    list.Add(mas);
                }
                Connect.ConnectionClose();
                ListViews.list = list;
            }
            catch (Exception)
            {
                ListViews.list = list;
            }
        }
    }
}
