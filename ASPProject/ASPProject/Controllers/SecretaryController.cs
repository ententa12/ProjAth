using ASPProject.BL;
using ASPProject.Entities;
using ASPProject.Models.SecretaryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPProject.Controllers
{
    [Authorize(Roles = "Secretary")]
    public class SecretaryController : Controller
    {
        DatabaseLogic _db;
        public SecretaryController()
        {
            _db = new DatabaseLogic();
        }


        public ActionResult Index()
        {
            
            var model = _db.GetUsers().Select(p=> new PersonsViewModel() {
                Id = p.UserDetailsId,
                Email = p.Email,
                FirstName = p.UserDetails.FirstName,
                LastName = p.UserDetails.LastName,
                Roles = p.Roles
            });
            return View(model);
        }

        // GET: Secretary/Create
        public ActionResult Create()
        {
            //        Dictionary<string, string> mounthPl =
            //new Dictionary<string, string>() {
            //    { "January", "Styczeń" },
            //    { "February", "Luty" },
            //    { "March", "Marzec" },
            //    { "April", "Kwiecień" },
            //    { "May", "Maj" },
            //    { "June", "Czerwiec" },
            //    { "July", "Lipiec" },
            //    { "August", "Sierpień" },
            //    { "September", "Wrzesień" },
            //    { "October", "Październik" },
            //    { "November", "Listopad" },
            //    { "December", "Grudzień" },
            //};
            //mounthPl[]
            return View();
        }



        // POST: Secretary/Create
        [HttpPost]
        public ActionResult Create(PersonsViewModel model)
        {
            try
            {
                var password = string.Join("",Guid.NewGuid().ToString().Take(8));
                var user = new User()
                {
                    Email = model.Email,
                    Password = password,
                    Roles = model.Roles,
                    UserDetails = new UserDetails()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName
                    }
                };
                _db.AddUser(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Secretary/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _db.GetUserById(id);
            var model = new PersonsViewModel()
            {
                Email = user.Email,
                FirstName = user.UserDetails.FirstName,
                LastName = user.UserDetails.LastName,
                Roles = user.Roles,
                Id = user.UserDetailsId
            };
            return View(model);
        }

        // POST: Secretary/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PersonsViewModel model)
        {
            try
            {
                var user = new User()
                {
                    Email = model.Email,
                    Roles = model.Roles,
                    UserDetails = new UserDetails()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName
                    }
                };
                _db.ModyfiUser(id, user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _db.DeleteUser(id);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
