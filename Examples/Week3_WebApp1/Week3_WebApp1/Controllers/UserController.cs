using System.Web.Mvc;
using Week3_WebApp1.Data;
using Week3_WebApp1.Data.Entities;

namespace Week3_WebApp1.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            user.Id = InMemoryDatabase.NextId();
            InMemoryDatabase.Users.Add(user);

            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var users = InMemoryDatabase.Users;

            return View(users);
        }

        public ActionResult Delete(int id)
        {
            InMemoryDatabase.DeleteUser(id);

            return RedirectToAction("List");
        }
    }
}