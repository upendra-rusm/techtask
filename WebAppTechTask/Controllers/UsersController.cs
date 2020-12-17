using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAppTechTask.Models;
using WebAppTechTask.Services;

namespace WebAppTechTask.Controllers
{
    public class UsersController : ApiController
    {
        

        private UserRepository _userRepository = null;
        public UsersController()
        {
            _userRepository = new UserRepository();
        }

        // GET: api/Users
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        // GET: api/Users/5       
        public IHttpActionResult GetUser(string email,string phone,string sortBy)
        {
            var user = _userRepository.GetUsers(email, phone);
            if (user == null)
            {
                return NotFound();
            }

            List<User> _resultSet;

            if(sortBy.ToUpper()=="PHONE")
                _resultSet = user.ToList().OrderBy(i => i.Phone).ToList();
            else
                _resultSet= user.ToList().OrderBy(i => i.Email).ToList();


            return Ok(_resultSet);
        }

        // PUT: api/Users/5       
        public IHttpActionResult PutUser(int id, User user)
        {
            
            if (id != user.Id)
            {
                return BadRequest();
            }

            _userRepository.UpdateUser(user);         

            return Ok(id);
        }

        // POST: api/Users
       
        public IHttpActionResult PostUser(User user)
        {

            int userId = _userRepository.CreateNewUser(user);
            return Ok();
        }

        // DELETE: api/Users/5
       
        public IHttpActionResult DeleteUser(int id)        {
           
            _userRepository.DeleteUser(id);
            return Ok(id);
        }



       

       
    }
}