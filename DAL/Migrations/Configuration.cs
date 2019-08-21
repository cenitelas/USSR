namespace DAL.Migrations
{
    using DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Entities.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Entities.Model1 context)
        {
            Users user = new Users() { name = "sasha", pass = "123" };
            Users user2 = new Users() { name = "pasha", pass = "asd" };
            context.Users.Add(user);
            context.Users.Add(user2);
            context.SaveChanges();
        }
    }
}
