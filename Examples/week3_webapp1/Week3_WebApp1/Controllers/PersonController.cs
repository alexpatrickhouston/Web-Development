using System.Web.Mvc;
using WebApp1_Week3.Database;
using WebApp1_Week3.Models.Entity;

namespace WebApp1_Week3.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult List()
        {
            var persons = InMemoryDatabase.Persons;

            return View(persons);
        }

        public ActionResult Add(Person person)
        {
            if (ModelState.IsValid)
            {
                InMemoryDatabase.Persons.Add(person);
                return RedirectToAction("List");
            }

            return View();
        }
    }
}