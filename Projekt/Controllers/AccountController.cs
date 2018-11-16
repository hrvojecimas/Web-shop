using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Projekt.Models;
using Projekt.autentifikacija;
using System.Web.Security;

namespace Projekt.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        Autentifikacija autentifikacija;
        public AccountController(Autentifikacija autentifikacija)
        {
            this.autentifikacija = autentifikacija;
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


    

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                if(autentifikacija.Autentifikacija(model.UserName, model.Password ) )
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return Redirect(ReturnUrl ?? Url.Action("Index", "Admin"));

                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password"); 
                    return View();
                }
            }

            else
            {
                return View();
            }
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Admin");
        }

    }

}