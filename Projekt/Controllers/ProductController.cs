using Projekt.autentifikacija;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Controllers
{
    public class ProductController : Controller
    {
        private readonly SkladisteProizvoda repository;
        public int PageSize = 4;
        public ProductController(SkladisteProizvoda repo)
        {
            repository = repo;
        }
        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products.Where(p => category == null || p.Category == category).OrderBy(p => p.ProductId).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Products.Count() :
                    repository.Products.Where(p => p.Category == category).Count()
                },
                CurrentCategory = category
            };
            

            return View(model);
        }
	}
}