namespace ASPProject.Migrations
{
    using ASPProject.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ASPProject.Entities.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ASPProject.Entities.ProjectContext context)
        {
            context.Users.Add(new User()
            {
                Email = "ententa12@gmail.com",
                Password = "aaa",
                Roles = "Secretary",
                UserDetails = new UserDetails()
                {
                    FirstName = "Patryk",
                    LastName = "Kiszczak",
                }
            });
        }
    }
}
