using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTechTask.Models;

namespace WebAppTechTask.Services
{
    interface IUserRepository
    {
        int CreateNewUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int userId);

        IEnumerable<User> GetUsers(string email, string phone);

        IEnumerable<User> GetUsers();

        User GetUser(int id);



    }
}
