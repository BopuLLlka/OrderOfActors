using Microsoft.AspNet.Identity;
using OrderOfStars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AspNetIdentityApp.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity.EntityFramework;
using AspNetIdentityApp.Controllers;
using System.Security.Cryptography;
using System.Text;
using ImageResizer;
using System.Drawing;

namespace OrderOfStars.Controllers
{
    public class AdminController : Controller
    {
        [HttpPost]
        public string Upload()
        {
            string fileHash = "";
            foreach (string file in Request.Files)
            {
                var upload = Request.Files[file];
                if (upload != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(upload.FileName);
                    // Хэшируем картинку с добавлением рандомного числа
                    Random rnd = new Random();
                    int newRandomNumber = rnd.Next();
                    var md5Hasher = MD5.Create();
                    byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(fileName+newRandomNumber));
                    // Создаем новый Stringbuilder (Изменяемую строку) для набора байт
                    StringBuilder sBuilder = new StringBuilder();
                    // Преобразуем каждый байт хэша в шестнадцатеричную строку
                    for (int i = 0; i < data.Length; i++)
                    {
                        //указывает, что нужно преобразовать элемент в шестнадцатиричную строку длиной в два символа
                        sBuilder.Append(data[i].ToString("x2"));
                    }
                    fileHash = sBuilder.ToString();

                    var path = "~/Content/Images/StarsImg/";
                    upload.InputStream.Seek(0, System.IO.SeekOrigin.Begin);
                    //Bitmap size = new Bitmap(upload.InputStream);
                    //upload.InputStream.Seek(0, System.IO.SeekOrigin.Begin);
                    string instructions = "maxwidth=400&maxheight=400";
                

                    // сохраняем файл в папку Files в проекте
                    ImageBuilder.Current.Build(
                        new ImageJob(
                        upload.InputStream,
                        path + fileHash + ".jpg",
                        new Instructions(instructions),
                        false,
                        false));
                   

                   // upload.SaveAs(Server.MapPath( path + fileHash +".jpg"));
                }
            }
            return fileHash;
        }
       // private ApplicationContext db = new ApplicationContext();
        /// <summary>
        /// Вьюшка с админ панелью
        /// </summary>
        [Authorize(Roles ="Admin")]
        // GET: Admin
        public ActionResult AdminPanel()
        {
            return View();
        }
        /// <summary>
        /// Вьюшка с добавлением Звезды
        /// </summary>
        [Authorize(Roles = "Admin")]
        public ActionResult CreateStar()
        {
            return View();
        }
        /// <summary>
        /// Подключаем БД для работы с пользователями и ролями
        /// </summary>
        public ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        /// <summary>
        /// Возвращает вьюшку с селектами в которых 
        /// содержатся все пользователи и все роли, пока так.
        /// </summary>
        /// <returns>Передаются лист пользователей и лист ролей</returns>
        
        public ActionResult UsersAndRoles()
        {
            using(var context = new ApplicationContext()) { 
            var allUsers = context.Users.ToList();
            var allRoles = context.Roles.ToList();
            var tuple = new Tuple<List<ApplicationUser>,  List<IdentityRole>>(allUsers, allRoles);
            return View(tuple);
            }
        }
        /// <summary>
        /// Добавляет пользователю роль и возвращает частичное представление в ajax
        /// </summary>
        /// <param name="userName">Имя пользователя из селекта</param>
        /// <param name="roleName">Имя роли из селекта</param>
        /// <returns>Возвращает текст с ошибкой или сообщающий об успехе</returns>
        [HttpPost]
        
        public ActionResult AddRoleToUser(string userName, string roleName)
        {
           ApplicationUser user = UserManager.FindByEmail(userName);
           try { 
                UserManager.AddToRole(user.Id, roleName);
            }
            catch
            {
                return PartialView(new ErrorModel() { ErrorText = "Роль не добавнлена" });
            }
            return PartialView(new ErrorModel() {ErrorText="Пользователю: "+userName+" добавлена роль: "+roleName});
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Orders()
        {
            return View();
        }

    }
}