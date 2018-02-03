using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Week4_WebApp1.Data;
using Week4_WebApp1.Data.Entities;

namespace Week4_WebApp1.Controllers
{
    public class PetController : Controller
    {
        public ActionResult List(int userId)
        {
            ViewBag.UserId = userId;

            var pets = GetPetsForUser(userId);

            return View(pets);
        }

        [HttpGet]
        public ActionResult Create(int userId)
        {
            ViewBag.UserId = userId;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Pet pet)
        {
            if (ModelState.IsValid)
            {
                Save(pet);
                return RedirectToAction("List", new {UserId = pet.UserId});
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var pet = GetPet(id);

            DeletePet(id);

            return RedirectToAction("List", new {UserId = pet.UserId});
        }

        private Pet GetPet(int petId)
        {
            var dbContext = new AppDbContext();

            return dbContext.Pets.Find(petId);
        }

        private ICollection<Pet> GetPetsForUser(int userId)
        {
            var dbContext = new AppDbContext();

            var pets = dbContext.Pets.Where(pet => pet.UserId == userId).ToList();

            return pets;
        }

        private void Save(Pet pet)
        {
            var dbContext = new AppDbContext();

            dbContext.Pets.Add(pet);

            dbContext.SaveChanges();
        }

        private void DeletePet(int id)
        {
            var dbContext = new AppDbContext();

            var pet = dbContext.Pets.Find(id);

            if (pet != null)
            {
                dbContext.Pets.Remove(pet);
                dbContext.SaveChanges();
            }
        }
    }
}