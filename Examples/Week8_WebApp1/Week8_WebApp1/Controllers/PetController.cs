using System;
using System.Web.Mvc;
using log4net;
using Microsoft.AspNet.Identity;
using Week8_WebApp1.Models.View;
using Week8_WebApp1.Services;

namespace Week8_WebApp1.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetService _petService;
        private readonly ILog _log = LogManager.GetLogger(typeof(PetController));

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [Authorize]
        public ActionResult List()
        {
            var userId = User.Identity.GetUserId();

            _log.Debug("Getting list of pets for user: " + userId);

            ViewBag.UserId = userId;

            var petViewModels = _petService.GetPetsForUser(userId);

            return View(petViewModels);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        //public ActionResult Create(int userId)
        {
            var userId = User.Identity.GetUserId();

            ViewBag.UserId = userId;

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(PetViewModel petViewModel)
        {
            _log.Info("Creating pet");

            if (!ModelState.IsValid) return View();

            try
            {
                var userId = User.Identity.GetUserId();
                _petService.SavePet(userId, petViewModel);
            }
            catch (Exception ex)
            {
                _log.Error("Failed to save pet.", ex);
                throw;
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            var pet = _petService.GetPet(id);

            return View(pet);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(PetViewModel petViewModel)
        {
            if (ModelState.IsValid)
            {
                _petService.UpdatePet(petViewModel);

                return RedirectToAction("List");
            }

            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int id)
        {
            var pet = _petService.GetPet(id);

            return View(pet);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            _petService.DeletePet(id);

            return RedirectToAction("List");
        }
    }
}