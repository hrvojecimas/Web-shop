using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Entities;
namespace Projekt.autentifikacija
{
    public interface SkladisteProizvoda
    {
        IEnumerable<Product> Products { get; }

        void SavaProduct(Product product);

        Product DeleteProduct(int productId);
    }
}
