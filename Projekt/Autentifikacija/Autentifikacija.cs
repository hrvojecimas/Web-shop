using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.autentifikacija
{
    public interface Autentifikacija
    {
        bool Autentifikacija(string username, string password);
        bool Logout();
    }
}
