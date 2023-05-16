using Messanger.Models;
using Messanger.Scripts;
using Messanger.Scripts.ConnectionToDataBase;
using Messanger.Scripts.HashPasswd;
using Messanger.Scripts.SMTPSendingToMail;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Messanger.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //if data is true;
        [HttpPost]
        public IActionResult loginData(loginData loginInfo)
        {
            if (string.IsNullOrEmpty(loginInfo.email))
            {
                ModelState.AddModelError("email", "Введите Email");
            }
            if (string.IsNullOrEmpty(loginInfo.password))
            {
                ModelState.AddModelError("password", "Введите пароль");
                
            }
            //TODO: Сохранение Cookie - loginInfo.rememberData в куки

            if (ModelState.IsValid)
            {
                string pass = string.Empty;
                string hashLoginPass = Hash.HashPassword(loginInfo.password);
                Connect connect = new Connect($"SELECT \"Users\".\"password\" FROM \"Users\" WHERE \"Users\".\"email\" = '{loginInfo.email.Trim()}'");
                connect.ConnectionOpen();

                object items = connect.reuslt();

                if (items is NpgsqlDataReader)
                {
                    NpgsqlDataReader itemsReader = (NpgsqlDataReader)items;

                        while (itemsReader.Read())
                        {
                            pass = itemsReader.GetValue(0).ToString();
                        }

                        connect.ConnectionClose();
                        if (Hash.VerifyHashedPassword(pass, loginInfo.password))
                        {
                            Connect connectTwo = new Connect($"SELECT age, email, gender, \"Users\".id, \"name\", surname, patronymic, avatar FROM \"Users\" WHERE \"Users\".\"email\" = '{loginInfo.email.Trim()}'");
                            connectTwo.ConnectionOpen();
                                object itemsTwo = connectTwo.reuslt();
                           
                            NpgsqlDataReader itemsReaderTwo = (NpgsqlDataReader)itemsTwo;
                            while (itemsReaderTwo.Read())
                            {
                                dataStepStatic.id = itemsReaderTwo.GetValue(0).ToString();
                                dataStepStatic.email = itemsReaderTwo.GetValue(1).ToString();
                                dataStepStatic.gender = itemsReaderTwo.GetValue(2).ToString();
                                dataStepStatic.age = Convert.ToUInt32(itemsReaderTwo.GetValue(3));
                                dataStepStatic.name = itemsReaderTwo.GetValue(4).ToString();
                                dataStepStatic.surname = itemsReaderTwo.GetValue(5).ToString();
                                dataStepStatic.patr = itemsReaderTwo.GetValue(6).ToString();

                                    try
                                    {
                                        dataStepStatic.avatar = (byte[])itemsReaderTwo.GetValue(7);
                                    }
                                    catch (Exception)
                                    {

                                        break;
                                    }
                                
                
                            }
                            
                            connectTwo.ConnectionClose();
                        return View();                  
                        }
                        else
                        {
                            ModelState.AddModelError("", "Пароль или логин неверный");
                            return View("Index");
                        }
                }
                else
                {
                    ModelState.AddModelError("", "Пароль или логин неверный");
                    return View("Index");
                }

            }
            else
            {
                return View("Index");
            }     
            
        }

       
        public IActionResult ResetPassword() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasstEmail resetPasstEmail)
        {
            Connect connect = new Connect($"SELECT * FROM \"Users\" WHERE email = '{resetPasstEmail.EmailForReset}'");
            connect.ConnectionOpen();
            object data = connect.reuslt();

            if (ModelState.IsValid)
            {
                if (data is NpgsqlDataReader)
                {
                    dataStepStatic.email = resetPasstEmail.EmailForReset;
                    connect.ConnectionClose();
                    dataStepStatic.code = RandomCodeConfirm.codeConfirm();
                    Sending sending = new Sending(resetPasstEmail.EmailForReset, dataStepStatic.code);
                    sending.SendMessage();
                    return View("ResetPasswordTwo");
                }
                else
                {
                    ModelState.AddModelError("EmailForReset", "Пользоватя с таким адресом не существует");
                    return View();
                }           
            }
            else
            {               
                return View();
            }
            
        }

        public IActionResult ResetPasswordTwo(ConfirmEmail confirmEmail) 
        {
            if (ModelState.IsValid)
            {
                if (dataStepStatic.code == confirmEmail.codeConfirmEmail)
                {
                    return View("ResetPasswordThree");
                   
                }
                else
                {
                    ModelState.AddModelError("", "Код неверный");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public IActionResult ResetCode()
        {
            ViewBag.email = dataStepStatic.email;
            dataStepStatic.code = RandomCodeConfirm.codeConfirm();
            Sending sending = new Sending(dataStepStatic.email, dataStepStatic.code);
            sending.SendMessage();
            ViewBag.messageResetCode = "Код выслан повторно";
            return View("ResetPasswordTwo");
        }

        public IActionResult ResetPasswordThree(ConfirmPasswords confirm) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string query = $"UPDATE \"Users\" SET \"password\" = '{Hash.HashPassword(confirm.FirstPass)}' WHERE email = '{dataStepStatic.email}'";
                    Connect connect = new Connect(query);
                    connect.ConnectionOpen();
                    connect.reuslt();
                    connect.ConnectionClose();
                    ViewBag.change = true;
                    return View("index");
                }
                catch (Exception)
                {

                    throw new Exception();
                }
                
            }
            else 
            {
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult ChangePhoto(IFormFile image)
        {
            
            byte[] photo = BinaryAvatar.binaryPhotoEncoding(image);
            string photoUTF = BinaryAvatar.binaryPhotoDecoding(photo);
            Connect connect = new Connect($"UPDATE \"Users\" SET \"avatar\" = '{photoUTF}'");
            connect.ConnectionOpen();
            connect.reuslt();
            connect.ConnectionClose();
            ViewBag.changePhoto = true;

            return View("loginData");
        }

    }
}
