using AdminPanel.Models;
using AdminPanel.Scripts;
using Messanger.Scripts.ConnectionToDataBase;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Diagnostics;

namespace AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        //Заполнить модель
        public IActionResult Index()
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
                return View(list);
            }
            catch (Exception)
            {
                TempData["empty"] = true;
                ListViews.list = list;
                return View(list);
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Delete(int id)
        {
            Connect connect = new Connect($"DELETE FROM \"ModerationPost\" WHERE id = {id};");
            connect.ConnectionOpen();
            connect.reuslt();
            connect.ConnectionClose();
            TempData["delete"] = true;
            Update.upd();
            return View("index");
        }
        public IActionResult Added(int id)
        {
            
            Connect connect = new Connect($"INSERT INTO \"Publications\" (\"name\", photo, \"text\", \"time\", title, user_public) SELECT \"NameUser\", photo, \"description\", time, title, id_user \r\nFROM \"ModerationPost\" WHERE \"ModerationPost\".id = {id}; ");
            connect.ConnectionOpen();
            connect.reuslt();
            connect.ConnectionClose();

            Connect connectTwo = new Connect($"DELETE FROM \"ModerationPost\" WHERE id = {id};");
            connectTwo.ConnectionOpen();
            connectTwo.reuslt();
            connectTwo.ConnectionClose();

            Update.upd();
            TempData["added"] = true;
            return View("index");
        }



    }
}