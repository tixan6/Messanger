using Messanger.Models;
using Messanger.Scripts;
using Messanger.Scripts.ConnectionToDataBase;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Data;
using System.Drawing;

namespace Messanger.Controllers
{
    public class MainWindowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Firends()
        {
            List<List<object>> list = new List<List<object>>();
            List<object> mas;
            Connect Connect = new Connect($"SELECT \"Users\".id, \"name\", surname, patronymic, avatar, friends FROM \"Users\" WHERE \"id\" != {Convert.ToInt32(dataStepStatic.id)};");
            Connect.ConnectionOpen();
            object all = Connect.reuslt();

            NpgsqlDataReader itemsReader = (NpgsqlDataReader)all;
            
            while (itemsReader.Read())
            {              
                mas = new List<object>();
                for (int i = 0; i < 6; i++)
                {
                    mas.Add(itemsReader.GetValue(i));
                }
                list.Add(mas); 
            }
            Connect.ConnectionClose();  
            return View(list);
        }


        public IActionResult addedUser(int idUser) 
        {

            Connect connect = new Connect($"update \"Users\" \r\nset friends = ARRAY_APPEND(friends, '{idUser}' ) \r\n where id = {dataStepStatic.id};");
            connect.ConnectionOpen();
            connect.reuslt();
            connect.ConnectionClose();
            TempData["AddedUser"] = true;
            Test.invokeReset();
            return Redirect("/MainWindow/Firends");

        }


        public IActionResult Delete(int idUser)
        {

            Connect connect = new Connect($"update \"Users\" set friends = array_remove(friends, '{idUser}') ");
            connect.ConnectionOpen();
            connect.reuslt();
            connect.ConnectionClose();
            TempData["DeleteUser"] = true;
            Test.invokeReset();
            return Redirect("/MainWindow/Firends");
        }


        //Вывод новостей
        public static int[] getFriends() 
        {
            int[] massFriend;
            Connect Connect = new Connect($"Select friends FROM \"Users\" where id = {dataStepStatic.id};");
            Connect.ConnectionOpen();
            object all = Connect.reuslt();
            NpgsqlDataReader itemsReader = (NpgsqlDataReader)all;
            while (itemsReader.Read())
            {
                try
                {
                    massFriend = Array.ConvertAll((string[])itemsReader.GetValue(0), s => int.Parse(s));
                    return massFriend;
                }
                catch (Exception)
                {
                    return null;
                }
                
                
            }
            return null;
            
        }
        public IActionResult news()
        {
            int[] ints = getFriends();
            List<List<object>> list = new List<List<object>>();
            List<object> mas;
            if (ints.Length == 0)
            {
                TempData["NullFriends"] = true;
                return View();
            }
            else
            {

                for (int i = 0; i < ints.Length; i++)
                {

                    Connect Connect = new Connect($"SELECT * FROM \"Publications\" WHERE user_public = {ints[i]};");
                    Connect.ConnectionOpen();
                    object all = Connect.reuslt();
                    if (all is Exception)
                    {
                        break;
                    }
                    NpgsqlDataReader itemsReader = (NpgsqlDataReader)all;

                    while (itemsReader.Read())
                    {
                        mas = new List<object>();
                        for (int j = 0; j < 7; j++)
                        {
                            mas.Add(itemsReader.GetValue(j));
                        }
                        list.Add(mas);
                    }
                    Connect.ConnectionClose();
                }
                dataStepStatic.MassFiends = list;
                return View();
            }

        }





        //Добавление записи
        [HttpPost]
        public IActionResult addNews(IFormFile image, NewsAdd newsAdd)
        {
            if (ModelState.IsValid)
            {
                if (image == null)
                {
                    return View("loginData");
                }
                else
                {
                    byte[] photo = BinaryAvatar.binaryPhotoEncoding(image);
                    string photoUTF = BinaryAvatar.binaryPhotoDecoding(photo);
                    Connect connect = new Connect($"INSERT INTO \"ModerationPost\" (id_user, photo, title, description, \"NameUser\", \"time\") VALUES ({dataStepStatic.id}, '{photoUTF}', '{newsAdd.title}', '{newsAdd.textDesc}', '{dataStepStatic.name}', '{DateTime.Now}')");
                    connect.ConnectionOpen();
                    connect.reuslt();
                    connect.ConnectionClose();
                    TempData["SuccsesNews"] = true;

                    return View("news");

                }

                
            }
            else
            {
                TempData["ErrorNews"] = true;
                return View("news");
            }
            
        }









    }
}
