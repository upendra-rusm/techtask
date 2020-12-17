using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using WebAppTechTask.Models;

namespace WebAppTechTask.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDBContext db = null;

        public UserRepository()
        {
            db = new UserDBContext();

            CreateNewUser(new User { FullName = "Upendra", Age = 38, Email = "upendra.singh@gmail.com", Phone = "9900009" });
            CreateNewUser(new User { FullName = "Upendra2", Age = 38, Email = "upendra.singh@gmail.com", Phone = "9900009" });

        }

        public int CreateNewUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.Id;
        }

        public void DeleteUser(int userId)
        {
            User user = GetUser(userId);

            if (user == null)
                throw new UserNotExistException($"{userId} not exist");
            
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public User GetUser(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetUsers(string email, string phone)
        {
            return db.Users.Where(u=>u.Email==email && u.Phone==phone);
        }

        public IEnumerable<User> GetUsers()
        {
            return db.Users;
        }

      

        public void UpdateUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    throw new UserNotExistException($"{user.Id} does not exist ");
                }
                else
                {
                    throw;
                }
            }
        }

        

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}