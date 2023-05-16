using Messanger.Models;
using Messanger.Scripts.ConnectionToDataBase;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
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
            Connect Connect = new Connect($"SELECT \"Users\".id, \"name\", surname, patronymic, avatar FROM \"Users\" WHERE \"id\" != {Convert.ToInt32(dataStepStatic.id)};");
            Connect.ConnectionOpen();
            object all = Connect.reuslt();

            NpgsqlDataReader itemsReader = (NpgsqlDataReader)all;
            
            while (itemsReader.Read())
            {              
                mas = new List<object>();
                for (int i = 0; i < 5; i++)
                {
                    mas.Add(itemsReader.GetValue(i));
                }
                list.Add(mas); 
            }
            Connect.ConnectionClose();  
            return View(list);
        }
    }
}
