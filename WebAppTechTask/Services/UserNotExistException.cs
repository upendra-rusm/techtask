using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppTechTask.Services
{
    public class UserNotExistException : Exception
    {
        public UserNotExistException(string message) : base(message)
        {
        }
    }
}