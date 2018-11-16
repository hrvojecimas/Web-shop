using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekt.Abstract;
using Projekt.Entities;


namespace Projekt.Concrete
{
    public class IProductRepository : IProductRepository
    {
        private readonly DBContext context = new DBContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }




        public void SavaProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }

            }
            context.SaveChanges();
        }


        public Product DeleteProduct(int productId)
        {
            Product dbEntry = context.Products.Find(productId);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}