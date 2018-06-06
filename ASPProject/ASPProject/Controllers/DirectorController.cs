using ASPProject.BL;
using ASPProject.Entities;
using ASPProject.Models;
using ASPProject.Models.SecretaryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPProject.Controllers
{
    public class DirectorController : Controller
    {
        DatabaseLogic _db;
        public DirectorController()
        {
            _db = new DatabaseLogic();
        }


        public ActionResult Index()
        {
            var model = _db.GetUsers().Select(p => new PersonsViewModel()
            {
                Id = p.UserDetailsId,
                Email = p.Email,
                FirstName = p.UserDetails.FirstName,
                LastName = p.UserDetails.LastName,
                Roles = p.Roles
            });
            return View(model);
        }

        public ActionResult DetailsWorker(int id)
        {
            var user = _db.GetUserById(id);

            var model = new DetailsWorkerViewModel()
            {
                FirstName = user.UserDetails.FirstName,
                LastName = user.UserDetails.LastName,
                Teams = user.UserDetails.Teams.ToList(),
                Email = user.Email,
                Tasks = user.UserDetails.Tasks.Select(p => new TaskUserControllerViewModel()
                {
                    Id = p.Id,
                    Description = p.Description,
                    ExpectedTime = p.ExpectedTime,
                    Name = p.Name,
                    Status = p.Status,
                    TeamName = p.Team.Name,
                    Time = p.Time
                }).ToList()
            };

            return View(model);
        }

        public ActionResult DetailsTask(int id)
        {
            var temp = _db.GetTask(id);
            var model = new TaskSupExtendedViewModel()
            {
                FirstName = temp.CurrentUser.FirstName,
                LastName = temp.CurrentUser.LastName,
                Id = temp.Id,
                Description = temp.Description,
                ExpectedTime = temp.ExpectedTime,
                Name = temp.Name,
                Status = temp.Status,
                TeamName = temp.Team.Name,
                Time = temp.Time,
                Works = temp.Works.Select(p => new WorkViewModel()
                {
                    Date = p.Date,
                    EndHour = p.EndHour,
                    StartHour = p.StartHour
                }).ToList()
            };
            return View(model);
        }

        public ActionResult AddTeam()
        {
            var model = new AddTeamViewModel()
            {
                AvailableWorkers = _db.GetUsers().Select(p => new SelectListItem()
                {
                    Text = p.Email + " " + p.UserDetails.FirstName + " " + p.UserDetails.LastName,
                    Value = p.UserDetailsId.ToString()
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddTeam(AddTeamViewModel model)
        {
            var team = new Team()
            {
                Name = model.Name
            };
            var temp = model.SelectedWorkers.Select(p => _db.GetUserById(int.Parse(p)).UserDetails).ToList();
            team.Members = temp;
            team.Members.Add(_db.GetUserByEmail(User.Identity.Name).UserDetails);
            _db.AddTeam(team);


            return RedirectToAction("Index");
        }

        public ActionResult TeamList()
        {
            var model = _db.GetTeams();
            return View(model);
        }

        public ActionResult TeamDetails(int id)
        {
            var team = _db.GetTeam(id);
            var model = new TeamViewModel()
            {
                Id = id,
                DirectorName = team.Members.Where(p => p.User.Roles == "Director").FirstOrDefault().FirstName + " " + team.Members.Where(p => p.User.Roles == "Director").FirstOrDefault().LastName,
                Name = team.Name,
                Members = team.Members.Where(p => p.User.Roles != "Director").Select(p => new TeamMemberViewModel()
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName
                }).ToList(),
                Tasks = team.Tasks.Select(p => new TeamTaskViewModel()
                {
                    Id = p.Id,
                    FirstName = p.CurrentUser!=null? p.CurrentUser.FirstName: "Nieprzydzielony",
                    LastName = p.CurrentUser != null ? p.CurrentUser.LastName:"",
                    Name = p.Name,
                    Status = (ASPProject.Entities.TaskStatus)p.Status
                }).ToList()
            };
            return View(model);
        }

        public ActionResult AddTask(int id)
        {
            ViewBag.id = id;
            return PartialView("_AddTask");
        }
        [HttpPost]
        public ActionResult AddTask(AddTaskViewModel model,int id)
        {
            var task = new Task()
            {
                Team = _db.GetTeam(id),
                Name = model.Name,
                ExpectedTime = model.ExpectedTime,
                Time = 0,
                Status = TaskStatus.waiting
            };
            _db.AddTask(task);
            return RedirectToAction("TeamDetails", new { id = id});
        }

    }
}