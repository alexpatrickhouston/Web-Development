using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Week4_WebApp1.Data;
using Week4_WebApp1.Data.Entities;
using Week4_WebApp1.Models.View;

namespace Week4_WebApp1.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = MapToUser(userViewModel);

                Save(user);

                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }

        public ActionResult List()
        {
            var users = GetAllUsers();

            return View(users);
        }

        public ActionResult Delete(int id)
        {
            DeleteUser(id);

            return RedirectToAction("List");
        }

        //private void Save(User user)
        //{
        //    user.Id = InMemoryDatabase.NextId();
        //    InMemoryDatabase.Users.Add(user);
        //}

        private void Save(User user)
        {
            var dbContext = new AppDbContext();

            dbContext.Users.Add(user);

            dbContext.SaveChanges();
        }

        //private IEnumerable<UserViewModel> GetAllUsers()
        //{
        //    var userViewModels = new List<UserViewModel>();

        //    var users = InMemoryDatabase.Users;
        //    foreach (var user in users)
        //    {
        //        var userViewModel = MapToUserViewModel(user);
        //        userViewModels.Add(userViewModel);
        //    }

        //    return userViewModels;
        //}

        private IEnumerable<UserViewModel> GetAllUsers()
        {
            var userViewModels = new List<UserViewModel>();

            var dbContext = new AppDbContext();

            var users = dbContext.Users;

            foreach (var user in users)
            {
                var userViewModel = MapToUserViewModel(user);
                userViewModels.Add(userViewModel);
            }

            return userViewModels;
        }

        //private void DeleteUser(int id)
        //{
        //    InMemoryDatabase.DeleteUser(id);
        //}

        private void DeleteUser(int id)
        {
            var dbContext = new AppDbContext();

            var users = dbContext.Users;

            var user = users.SingleOrDefault(u => u.Id == id);

            if (user != null)
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
        }

        private User MapToUser(UserViewModel userViewModel)
        {
            return new User
            {
                Id = userViewModel.Id,
                FirstName = userViewModel.FirstName,
                MiddleName = userViewModel.MiddleName,
                LastName = userViewModel.LastName,
                EmailAddress = userViewModel.EmailAddress,
                DateOfBirth = userViewModel.DOB,
                YearsInSchool = userViewModel.YearsInSchool
            };
        }

        private UserViewModel MapToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                DOB = user.DateOfBirth,
                YearsInSchool = user.YearsInSchool
            };
        }
    }
}