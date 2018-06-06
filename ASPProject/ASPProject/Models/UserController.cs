using ASPProject.BL;
using ASPProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPProject.Models
{
    public class UserController : Controller
    {
        DatabaseLogic _db;
        public UserController()
        {
            _db = new DatabaseLogic();
        }

        public ActionResult StartWork(int id)
        {
            _db.AddWork(id);
            return RedirectToAction("TaskDetails", new { id = id });
        }

        public ActionResult EndWork(int id)
        {
            _db.EndWork(id);
            return RedirectToAction("TaskDetails", new { id = id });
        }

        public ActionResult Index()
        {
            var model = _db.GetUserByEmail(User.Identity.Name).UserDetails.Tasks.Select(p => new TaskUserViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                TeamName = p.Team.Name,
                Status = p.Status,
            }).ToList();
            return View(model);
        }

        public ActionResult WorkDetails(int id)
        {
            var temp = _db.GetTask(id).Works;
            var Works = temp.Select(p => new WorkViewModel()
            {
                Date = p.Date,
                EndHour = p.EndHour,
                StartHour = p.StartHour
            }).ToList();
            return PartialView("_WorkDetails", Works);
        }

        public ActionResult TaskDetails(int id)
        {
            var temp = _db.GetTask(id);
            var model = new TaskUserControllerViewModel()
            {
                Description = temp.Description,
                ExpectedTime = temp.ExpectedTime,
                Id = temp.Id,
                Name = temp.Name,
                Status = temp.Status,
                TeamName = temp.Team.Name,
                Time = temp.Time,
                InWork = temp.Works.Where(x => x.EndHour == null).FirstOrDefault() == null ? false : true
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult ModyfyTask(int id, TaskUserControllerViewModel model)
        {
            _db.ModyfiTaskByUser(id, new Task()
            {
                Name = model.Name,
                Description = model.Description,
                Status = model.Status
            });
            return RedirectToAction("TaskDetails", new { id = id });
        }

        public ActionResult MyTeams()
        {
            var model = _db.GetUserByEmail(User.Identity.Name).UserDetails.Teams.Select(p => new TeamViewModel()
            {
                Id = p.Id,
                Name = p.Name
            });
            return View(model);
        }

        public ActionResult FreeTeamTasks(int id)
        {
            var model = _db.GetTeam(id).Tasks.Where(p => p.UserId == null).Select(p => new TaskUserViewModel()
            {
                Id = p.Id,
                Name = p.Name,
            });

            return View(model);
        }

        public ActionResult TakeTask(int id)
        {
            _db.TakeTask(id, User.Identity.Name);

            return RedirectToAction("FreeTeamTasks", new { id = _db.GetTask(id).Team.Id });
        }
    }
}