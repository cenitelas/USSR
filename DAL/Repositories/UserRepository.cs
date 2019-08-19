using DAL.Interfaces;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class UserRepository : IRepository<Users>
    {
        private Model1 db;

        public UserRepository(Model1 context)
        {
            this.db = context;
        }

        public IEnumerable<Users> GetAll()
        {
            return db.Users;
        }

        public Users Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(Users user)
        {
            db.Users.Add(user);
        }

        public void Update(Users user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<Users> Find(Func<Users, Boolean> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Users user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }
}
