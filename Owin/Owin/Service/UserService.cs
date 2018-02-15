using Owin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin.Service
{
    public class UserService
    {
        public User GetUserByCredentials(string email, string password)
        {
            if (email != "email@domain.com" || password != "password")
            {
                return null;
            }
            User user = new User() { Id = "1", Email = "email@domain.com", Password = "password", Name = "Name" };
            if (user != null)
            {
                user.Password = string.Empty;
            }
            return user;
        }
    }
}