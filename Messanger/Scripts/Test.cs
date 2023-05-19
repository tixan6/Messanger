using Messanger.Controllers;
using Messanger.Scripts.ConnectionToDataBase;
using Npgsql;

namespace Messanger.Scripts
{
    public static class Test
    {
        public static void invokeReset() 
        {
            Connect connectTwo = new Connect($"SELECT age, email, gender, \"Users\".id, \"name\", surname, patronymic, avatar, friends FROM \"Users\" WHERE \"Users\".\"id\" = '{dataStepStatic.id}'");
            connectTwo.ConnectionOpen();
            object itemsTwo = connectTwo.reuslt();

            NpgsqlDataReader itemsReaderTwo = (NpgsqlDataReader)itemsTwo;
            while (itemsReaderTwo.Read())
            {
                dataStepStatic.age = Convert.ToUInt32(itemsReaderTwo.GetValue(0));
                dataStepStatic.email = itemsReaderTwo.GetValue(1).ToString();
                dataStepStatic.gender = itemsReaderTwo.GetValue(2).ToString();
                dataStepStatic.id = Convert.ToInt32(itemsReaderTwo.GetValue(3));
                dataStepStatic.name = itemsReaderTwo.GetValue(4).ToString();
                dataStepStatic.surname = itemsReaderTwo.GetValue(5).ToString();
                dataStepStatic.patr = itemsReaderTwo.GetValue(6).ToString();


                try
                {
                    dataStepStatic.avatar = (byte[])itemsReaderTwo.GetValue(7);
                    dataStepStatic.friendsId = (string[])itemsReaderTwo.GetValue(8);
                }
                catch (Exception)
                {

                    break;
                }


            }

            connectTwo.ConnectionClose();
        }
    }
}
