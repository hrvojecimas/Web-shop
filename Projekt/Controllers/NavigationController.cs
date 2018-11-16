using Projekt.autentifikacija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Controllers
{
    public class NavigationController : Controller
    {

        private SkladisteProizvoda repository;

        public NavigationController(SkladisteProizvoda repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string category = null)
        
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x);
            return PartialView(categories);
        }
	}
}