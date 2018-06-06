using ASPProject.Entities;
using ASPProject.Models.SecretaryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPProject.BL
{
    public class DatabaseLogic
    {
        ProjectContext _context;

        public DatabaseLogic()
        {
            _context = new ProjectContext();
        }

        public void AddWork(int idTask)
        {
            Work w = new Work()
            {
                Date = DateTime.Now,
                StartHour = DateTime.Now.TimeOfDay,
                EndHour = null,
                Task = GetTask(idTask),
                User = GetTask(idTask).CurrentUser
            };
            _context.Works.Add(w);
            _context.SaveChanges();
        }

        internal void EndWork(int idTask)
        {
            var t = GetTask(idTask);
            var w = t.Works.Where(p => p.EndHour == null).LastOrDefault();
            w.EndHour = DateTime.Now.TimeOfDay;
            t.Time = t.Works.Select(p => p.EndHour.Value - p.StartHour.Value).Sum(p => p.TotalMinutes);
            _context.Entry(w);
            _context.SaveChanges();
        }

        public Team GetTeam(int id)
        {
            return _context.Teams.Find(id);
        }

        public Task GetTask(int id)
        {
            return _context.Tasks.Find(id);
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.Where(p => p.Email == email).FirstOrDefault();
        }

        public void ModyfiTaskByUser(int id, Task task)
        {
            var modeTask = GetTask(id);
            modeTask.Name = task.Name;
            modeTask.Status = task.Status;
            modeTask.Description = task.Description;
            _context.Entry(modeTask);
            _context.SaveChanges();
        }

        public void ChangePassword(string newPassword, string email)
        {
            var modUser = GetUserByEmail(email);
            modUser.Password = newPassword;
            _context.Entry(modUser);
            _context.SaveChanges();
        }

        public void ModyfiUser(int id,User user)
        {
            var modUser = GetUserById(id);
            modUser.Email = user.Email;
            modUser.Roles = user.Roles;
            modUser.UserDetails.FirstName = user.UserDetails.FirstName;
            modUser.UserDetails.LastName = user.UserDetails.LastName;
            _context.Entry(modUser);
            _context.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            _context.UserDetails.Remove(GetUserById(id).UserDetails);
            _context.Users.Remove(GetUserById(id));
            _context.SaveChanges();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUserDetails(User user)
        {
            return _context.Users.Where(u => u.Email.ToLower() == user.Email.ToLower() &&
            u.Password == user.Password).FirstOrDefault();
        }

        internal void TakeTask(int id, string name)
        {
            var takedTask = GetTask(id);
            takedTask.CurrentUser = GetUserByEmail(name).UserDetails;
            _context.Entry(takedTask);
            _context.SaveChanges();
        }

        public void AddTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public ICollection<Team> GetTeams()
        {
            return _context.Teams.ToList();
        }

        internal void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
    }
}