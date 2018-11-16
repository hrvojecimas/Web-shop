using Projekt.autentifikacija;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projekt.Datebase
{
    public class AuthenticationProvider : Autentifikacija
    {

        private readonly DBContext context = new DBContext();
        public bool Autentifikacija(string username, string password)
        {
            var result = context.Users.FirstOrDefault(u => u.UserId == username && u.Password == password);

            if (result == null)
                return false;
            return true;
        }

        public bool Logout()
        {
            return true;
        }
    }
}